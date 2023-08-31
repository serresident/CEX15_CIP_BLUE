using cip_blue;
using cip_blue.Models;
using Events;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Throw;
using System.Text.Json;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Services
{

    internal class ChartUpdateService : IService
    {
        private readonly IEventAggregator _eventAggregator;
        private  ChartData _chartData;
        private readonly ProcessDataTcp _modbusData;
        private bool isStarted;
        private readonly Random random = new();
        

        public ChartUpdateService(ProcessDataTcp modbusData, IEventAggregator eventAggregator, ChartData chartData)
        {
            _eventAggregator = eventAggregator;
            _chartData = chartData;
            _modbusData = modbusData;
            _chartData.DataPoints = new();
            _chartData.DataPoints2 = new();
        }
        public void DoWork()
        {
            App.Current.Dispatcher.BeginInvoke((Action)delegate
            {
                string _fileName = "ChartData.json";
                string jsonString = "";

                if (!isStarted)
                {
                    using StreamReader data = File.OpenText(_fileName);
                    try
                    {


                        string readData = data.ReadToEnd();
                        ChartData? convertedData = JsonConvert.DeserializeObject<ChartData>(readData);
                        _chartData.DataPoints = convertedData?.DataPoints;
                        _chartData.DataPoints2 = convertedData?.DataPoints2;

                    }
                    catch( Exception ex)
                    {
                        _chartData.DataPoints = new();
                        _chartData.DataPoints2 = new();
                       // _logger.Error("Error in ChartUpdate Service >>>> " + ex.Message);
                    }
                    //for (int i = 0; i < 360; i++)
                    //{

                    //  _chartData.DataPoints?.Add(new Tuple<float, double>(_modbusData.TE2, DateTime.Now.AddMinutes(i).ToOADate()));
                    //    _chartData.DataPoints2?.Add(new Tuple<float, double>(random.Next(20, 24), DateTime.Now.AddMinutes(i).ToOADate()));
                    //}
                    _eventAggregator.GetEvent<ChartUpdateStartedEvent>().Publish();
                    isStarted = true;
                    return;
                }
                else
                {

                     _chartData.DataPoints?.Add(new Tuple<float, double>(_modbusData.TE2, DateTime.Now.ToOADate()));
                     
                    if (_chartData.DataPoints.Count>360)
                    _chartData.DataPoints?.RemoveAt(0);

                    _chartData.DataPoints2?.Add(new Tuple<float, double>(_modbusData.Tzad_pvs, DateTime.Now.ToOADate()));
                    if (_chartData.DataPoints2.Count > 360)
                        _chartData.DataPoints2?.RemoveAt(0);
                    //}
                  //  _eventAggregator.GetEvent<ChartUpdateStartedEvent>().Publish();

                    //string fileName = "ChartData.json";
                    //string ChartDataJson = JsonSerializer.Serialize(_chartData);
                    //File.WriteAllText(fileName, ChartDataJson);
                }
            });

        }
    }
}
