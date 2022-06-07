using NLog;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading;
using cip_blue.Helpers;
using cip_blue.Models;
using cip_blue.Repositories;
using cip_blue.Services;
using Xceed.Wpf.Toolkit;
using System.Net.NetworkInformation;

namespace cip_blue.ViewModels
{
    public class MnemonicViewModel : BindableBase
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private bool initVM;
        private PeriodicalTaskStarter chartUpdater;
        private PeriodicalTaskStarter internalUpdater;

        private readonly ArchivRepository archivRepository;






        private ObservableRangeCollection<ThermoChartPoint> points;
        public ObservableRangeCollection<ThermoChartPoint> Points
        {
            get { return points; }
            set { SetProperty(ref points, value); }
        }

        private WindowState waterLoadingWndStatus = WindowState.Closed;
        public WindowState WaterLoadingWndStatus
        {
            get { return waterLoadingWndStatus; }
            set { SetProperty(ref waterLoadingWndStatus, value); }
        }

        private WindowState hotwaterLoadingWndStatus = WindowState.Closed;
        public WindowState HotWaterLoadingWndStatus
        {
            get { return hotwaterLoadingWndStatus; }
            set { SetProperty(ref hotwaterLoadingWndStatus, value); }

        }

        private WindowState hot480waterLoadingWndStatus = WindowState.Closed;

        public WindowState Hot480WaterLoadingWndStatus
        {
            get { return hot480waterLoadingWndStatus; }
            set { SetProperty(ref hot480waterLoadingWndStatus, value); }
        }
        // выгрузка r422
        private WindowState unloadFromR422WndStatus = WindowState.Closed;
        public WindowState UnloadFromR422WndStatus
        {
            get { return unloadFromR422WndStatus; }
            set { SetProperty(ref unloadFromR422WndStatus, value); }
        }

        // охлаждение 480
        private WindowState ohlagd480WndStatus = WindowState.Closed;
        public WindowState Ohlagd480WndStatus
        {
            get { return ohlagd480WndStatus; }
            set { SetProperty(ref ohlagd480WndStatus, value); }

        }


        // PH 480a
        private WindowState regPh480aWndStatus = WindowState.Closed;
        public WindowState RegPh480aWndStatus
        {
            get { return regPh480aWndStatus; }
            set { SetProperty(ref regPh480aWndStatus, value); }
        }


        // PH 480b
        private WindowState regPh480bWndStatus = WindowState.Closed;
        public WindowState RegPh480bWndStatus
        {
            get { return regPh480bWndStatus; }
            set { SetProperty(ref regPh480bWndStatus, value); }
        }

        //Морфолин в 480

        private WindowState zagrMorfolin480WndStatus = WindowState.Closed;
        public WindowState ZagrMorfolin480WndStatus
        {
            get { return zagrMorfolin480WndStatus; }
            set { SetProperty(ref zagrMorfolin480WndStatus, value); }
        }

        //Диэтил в 480

        private WindowState zagrDietil480WndStatus = WindowState.Closed;
        public WindowState ZagrDietil480WndStatus
        {
            get { return zagrDietil480WndStatus; }
            set { SetProperty(ref zagrDietil480WndStatus, value); }
        }

        //ДиэтилАмин в 480

        private WindowState zagrDietilAmin480WndStatus = WindowState.Closed;
        public WindowState ZagrDietilAmin480WndStatus
        {
            get { return zagrDietilAmin480WndStatus; }
            set { SetProperty(ref zagrDietilAmin480WndStatus, value); }
        }

        //анилин в 480

        private WindowState zagrAnilin480WndStatus = WindowState.Closed;
        public WindowState ZagrAnilin480WndStatus
        {
            get { return zagrAnilin480WndStatus; }
            set { SetProperty(ref zagrAnilin480WndStatus, value); }
        }


        //термоцикл
        private WindowState thermoCycl_1AWndStatus = WindowState.Closed;
        public WindowState ThermoCycl_1AWndStatus
        {
            get { return thermoCycl_1AWndStatus; }
            set { SetProperty(ref thermoCycl_1AWndStatus, value); }
        }

        // счетчик воды
        private Single count_emis_A;
        public Single Count_emis_A
        {
            get { return count_emis_A; }
            set { SetProperty(ref count_emis_A, value); }
        }

        // счетчик воды
        private bool reset_A = true;
        public bool Reset_A
        {
            get { return reset_A; }
            set { SetProperty(ref reset_A, value); }
        }
        // счетчик воды
        private Single count_emis_B;
        public Single Count_emis_B
        {
            get { return count_emis_B; }
            set { SetProperty(ref count_emis_B, value); }
        }

        private bool reset_B=true;
        public bool Reset_B
        {
            get { return reset_B; }
            set { SetProperty(ref reset_B, value); }
        }

     
        // счетчик Мэк 450
        private Single сount_fq450_mek;
        public Single Count_fq450_mek
        {
            get { return сount_fq450_mek; }
            set { SetProperty(ref сount_fq450_mek, value); }
        }

        private bool alarm_notanswerModule = true;
        public bool Alarm_notanswerModule
        {
            get { return alarm_notanswerModule; }
            set { SetProperty(ref alarm_notanswerModule, value); }
        }

        private string status_4101="0" ;
        public string Status_4101
        {
            get { return status_4101; }
            set { SetProperty(ref status_4101, value); }
        }

        private ProcessDataTcp _pd;
        public ProcessDataTcp PD
        {
            get { return _pd; }
            set { SetProperty(ref _pd, value); }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public DelegateCommand Promivka_4101_StartCommand { get; private set; }
        public DelegateCommand Promivka_4101_StopCommand { get; private set; }
        private WindowState promivka_4101WndStatus = WindowState.Closed;
        public WindowState Promivka_4101WndStatus
        {
            get { return promivka_4101WndStatus; }
            set { SetProperty(ref promivka_4101WndStatus, value); }
        }

        /// <summary>
        /// Pfuheprf djls 
        /// </summary>
        public DelegateCommand ZagrVodi160a_StartCommand { get; private set; }
        public DelegateCommand  ZagrVodi160a_StopCommand { get; private set; }
        private WindowState  zagrVodi160aWndStatus = WindowState.Closed;
        public WindowState  ZagrVodi160aWndStatus
        {
            get { return zagrVodi160aWndStatus; }
            set { SetProperty(ref zagrVodi160aWndStatus, value); }

        }

        public DelegateCommand Promivka_4201_StartCommand { get; private set; }
        public DelegateCommand Promivka_4201_StopCommand { get; private set; }

        private WindowState promivka_4201WndStatus = WindowState.Closed;
        public WindowState Promivka_4201WndStatus
        {
            get { return promivka_4201WndStatus; }
            set { SetProperty(ref promivka_4201WndStatus, value); }
        }


        public Dictionary<int, string> Dictionary_Status;
        public MnemonicViewModel(ProcessDataTcp pd, ArchivRepository archivRepository)
        {
            PD = pd;
            this.archivRepository = archivRepository;

            Promivka_4101_StartCommand = new DelegateCommand(promivka_4101_Start, canPromivka_4101_Start);
            Promivka_4101_StopCommand = new DelegateCommand(promivka_4101_Stop, canPromivka_4101_Stop);

             ZagrVodi160a_StartCommand = new DelegateCommand( ZagrVodi160a_Start, canZagrVodi160a_Start);
             ZagrVodi160a_StopCommand = new DelegateCommand( ZagrVodi160a_Stop, canZagrVodi160a_Stop);

            Promivka_4201_StartCommand = new DelegateCommand(promivka_4201_Start, canPromivka_4201_Start);
            Promivka_4201_StopCommand = new DelegateCommand(promivka_4201_Stop, canPromivka_4201_Stop);

            Dictionary_Status = new Dictionary<int, string>() {
                {0, "НЕ бЫЛО ЗАПУСКА"},
                { 1, "Цикл промывки:1. Клапан воды открыт. Ожидание таймера на закрытие" }, 
                { 2, "Цикл промывки:2. Клапан воды закрыт. Ожидание таймера паузы 1" },
                { 3, "Цикл промывки:3. Клапан воздуха открыт. Ожидание таймера на закрытие" }, 
                { 4, "Цикл промывки:4. Клапан воздуха закрыт. Ожидание таймера на перезапуск" },
                { 5, "5. Финальная продувка воздухом" },
                { 7, "Завершение по условию" },
                 { 10, "Условие выполнено" },
                { 11, "Остановлено оператором" } };


            chartUpdater = new PeriodicalTaskStarter(TimeSpan.FromSeconds(1));
            internalUpdater = new PeriodicalTaskStarter(TimeSpan.FromSeconds(1));
        }

        private bool canPromivka_4101_Start() { return !PD.switch_promivka4101; }
        private void promivka_4101_Start() => PD.switch_promivka4101 = true;
        private bool canPromivka_4101_Stop() { return PD.switch_promivka4101; }
        private void promivka_4101_Stop() => PD.switch_promivka4101 = false;

        private bool canZagrVodi160a_Start() { return !PD.switch_ZagrVodi_160a; }
        private void  ZagrVodi160a_Start() => PD.switch_ZagrVodi_160a = true;
        private bool canZagrVodi160a_Stop() { return PD.switch_ZagrVodi_160a; }
        private void ZagrVodi160a_Stop() => PD.switch_ZagrVodi_160a = false;

        private bool canPromivka_4201_Start() { return !PD.switch_promivka4201; }
        private void promivka_4201_Start() => PD.switch_promivka4201 = true;
        private bool canPromivka_4201_Stop() { return PD.switch_promivka4201; }
        private void promivka_4201_Stop() => PD.switch_promivka4201 = false;

        //private void waterLoadingStart() => PD.ZagrVodaComm_Start = true;
        //private bool canWaterLoadingStop() { return PD.ZagrVodaComm_Start; }
        //private void waterLoadingStop() => PD.ZagrVodaComm_Start = false;

        //private bool canHotWaterLoadingStart() { return !PD.ZagrKond460Comm_Start; }
        //private void hotwaterLoadingStart() => PD.ZagrKond460Comm_Start = true;
        //private bool canHotWaterLoadingStop() { return PD.ZagrKond460Comm_Start; }
        //private void hotwaterLoadingStop() => PD.ZagrKond460Comm_Start = false;

        //private bool canHot480WaterLoadingStart() { return !PD.ZagrKond480Comm_Start; }
        //private void hot480waterLoadingStart() => PD.ZagrKond480Comm_Start = true;
        //private bool canHot480WaterLoadingStop() { return PD.ZagrKond480Comm_Start; }
        //private void hot480waterLoadingStop() => PD.ZagrKond480Comm_Start = false;

        //private bool canUnloadFromR422Start() { return !PD.fromR422_xStart; }
        //private void unloadFromR422Start() => PD.fromR422_xStart = true;
        //private bool canUnloadFromR422Stop() { return PD.fromR422_xStart; }
        //private void unloadFromR422stop() => PD.fromR422_xStart = false;

        //private bool canOhlagd480Start() { return !PD.Ohlagd480_Start; }
        //private void Ohlagd480Start() => PD.Ohlagd480_Start = true;
        //private bool canOhlagd480Stop() { return PD.Ohlagd480_Start; }
        //private void Ohlagd480stop() => PD.Ohlagd480_Start = false;


        //private bool canRegPh480aStart() { return !PD.RegPH480A_Start; }
        //private void RegPh480aStart() => PD.RegPH480A_Start = true;
        //private bool canRegPh480aStop() { return PD.RegPH480A_Start; }
        //private void RegPh480astop() => PD.RegPH480A_Start = false;

        //private bool canRegPh480bStart() { return !PD.RegPH480B_Start; }
        //private void RegPh480bStart() => PD.RegPH480B_Start = true;
        //private bool canRegPh480bStop() { return PD.RegPH480B_Start; }
        //private void RegPh480bstop() => PD.RegPH480B_Start = false;

        //private bool canZagrMorfolin480Start() { return !PD.ZagrMorfolinK480_Start; }
        //private void ZagrMorfolin480Start() => PD.ZagrMorfolinK480_Start = true;
        //private bool canZagrMorfolin480Stop() { return PD.ZagrMorfolinK480_Start; }
        //private void ZagrMorfolin480stop() => PD.ZagrMorfolinK480_Start = false;


        //private bool canZagrDietil480Start() { return !PD.ZagrDietilK480_Start; }
        //private void ZagrDietil480Start() => PD.ZagrDietilK480_Start = true;
        //private bool canZagrDietil480Stop() { return PD.ZagrDietilK480_Start; }
        //private void ZagrDietil480stop() => PD.ZagrDietilK480_Start = false;


        //private bool canZagrDietilAmin480Start() { return !PD.ZagrDietilAminK480_Start; }
        //private void ZagrDietilAmin480Start() => PD.ZagrDietilAminK480_Start = true;
        //private bool canZagrDietilAmin480Stop() { return PD.ZagrDietilAminK480_Start; }
        //private void ZagrDietilAmin480stop() => PD.ZagrDietilAminK480_Start = false;

        //private bool canZagrAnilin480Start() { return !PD.ZagrAnilin480_Start; }
        //private void ZagrAnilin480Start() => PD.ZagrAnilin480_Start = true;
        //private bool canZagrAnilin480Stop() { return PD.ZagrAnilin480_Start; }
        //private void ZagrAnilin480stop() => PD.ZagrAnilin480_Start = false;

        Single mem_count1;
        Single mem_count2;
        Single mem_count3;
        public void OnLoading()
        {
            if (!initVM)
            {
                var t = new Thread(() =>
                {
                    IsBusy = true;

                    internalUpdater.Start(() => internalUpdate(), null);
                    
                    List<ThermoChartPoint> _points = new List<ThermoChartPoint>();
                    DateTime dt = DateTime.MinValue;

                    var dataPoints = archivRepository.GetMeasurements(DateTime.Now.AddHours(-5), DateTime.Now);
                    if (dataPoints == null) // повторяем запрос если возникло исключение
                        dataPoints = archivRepository.GetMeasurements(DateTime.Now.AddHours(-5), DateTime.Now);



                    //foreach (KeyValuePair<DateTime, Dictionary<string, string>> entry in dataPoints)
                    //{
                    //    try
                    //    {
                    //        _points.Add(new ThermoChartPoint()
                    //        {
                    //            DTS = entry.Key,
                    //            TE_1_1A = entry.Value.ContainsKey("TE_1_1A") ? float.Parse(entry.Value["TE_1_1A"], CultureInfo.InvariantCulture) : float.NaN,
                    //            TE_1_1A = entry.Value.ContainsKey("TE_1_1A") ? float.Parse(entry.Value["TE_1_1A"], CultureInfo.InvariantCulture) : float.NaN,
                    //            TE_2_1A = entry.Value.ContainsKey("TE_2_1A") ? float.Parse(entry.Value["TE_2_1A"], CultureInfo.InvariantCulture) : float.NaN,
                    //            TE_3_1A = entry.Value.ContainsKey("TE_3_1A") ? float.Parse(entry.Value["TE_3_1A"], CultureInfo.InvariantCulture) : float.NaN,
                    //            TE_4_1A = entry.Value.ContainsKey("TE_4_1A") ? float.Parse(entry.Value["TE_4_1A"], CultureInfo.InvariantCulture) : float.NaN
                    //        });
                    //        dt = entry.Key;
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        logger.Error(ex, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
                    //    }

                    //}

                    Points = new ObservableRangeCollection<ThermoChartPoint>(_points);

                    //  chartUpdater.Start(() => updateChart(), null);

                    IsBusy = false;
                });

                t.Priority = ThreadPriority.Lowest;
                t.IsBackground = true;
                t.Start();

                t = null;
                initVM = true;
            }

        }
        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        private void updateChart()
        {
            //App.Current.Dispatcher?.Invoke(() =>
            //{
            //    Points.Add(new ThermoChartPoint()
            //    {
            //        DTS = DateTime.Now,
            //        TE_1_1A = PD.TE_1_1A,
            //        TE_2_1A = PD.TE_2_1A,
            //        TE_3_1A = PD.TE_3_1A,
            //        TE_4_1A = PD.TE_4_1A
            //    });

            //    IEnumerable<ThermoChartPoint> deletedItem = (from p in Points where p.DTS < DateTime.Now.AddHours(-5) select p).ToList();
            //    if (deletedItem.Count() > 0)
            //        Points.RemoveRange(deletedItem);

            //});
        }
        Single save=0;
        int t;


        private void internalUpdate()
        {
        //    PingHost("192.168.101.117");
            Alarm_notanswerModule = PD.err_module_ad2 || PD.err_module_ad3 || PD.err_module_ad4 || PD.err_module_ad5 || PD.err_module_ad6 || PD.err_module_ad7;

            Promivka_4101_StartCommand.RaiseCanExecuteChanged();
            Promivka_4101_StopCommand.RaiseCanExecuteChanged();

            ZagrVodi160a_StartCommand.RaiseCanExecuteChanged();
            ZagrVodi160a_StopCommand.RaiseCanExecuteChanged();

            Promivka_4201_StartCommand.RaiseCanExecuteChanged();
            Promivka_4201_StopCommand.RaiseCanExecuteChanged();

            try
            {
                t = Convert.ToInt32(PD.cip4101_status);
               Status_4101 = Dictionary_Status[t];
              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
         


            //WaterLoadingStartCommand.RaiseCanExecuteChanged();
            //WaterLoadingStopCommand.RaiseCanExecuteChanged();

            //HotWaterLoadingStartCommand.RaiseCanExecuteChanged();
            //HotWaterLoadingStopCommand.RaiseCanExecuteChanged();

            //Hot480WaterLoadingStartCommand.RaiseCanExecuteChanged();
            //Hot480WaterLoadingStopCommand.RaiseCanExecuteChanged();

            //UnloadFromR422StartCommand.RaiseCanExecuteChanged();
            //UnloadFromR422StopCommand.RaiseCanExecuteChanged();

            //Ohlagd480StartCommand.RaiseCanExecuteChanged();
            //Ohlagd480StopCommand.RaiseCanExecuteChanged();

            //RegPhK480aStartCommand.RaiseCanExecuteChanged();
            //RegPhK480aStopCommand.RaiseCanExecuteChanged();


            //RegPhK480bStartCommand.RaiseCanExecuteChanged();
            //RegPhK480bStopCommand.RaiseCanExecuteChanged();

            //ZagrMorfolin480StartCommand.RaiseCanExecuteChanged();
            //ZagrMorfolin480StopCommand.RaiseCanExecuteChanged();

            //ZagrDietil480StartCommand.RaiseCanExecuteChanged();
            //ZagrDietil480StopCommand.RaiseCanExecuteChanged();

            //ZagrDietilAmin480StartCommand.RaiseCanExecuteChanged();
            //ZagrDietilAmin480StopCommand.RaiseCanExecuteChanged();

            //ZagrAnilin480StartCommand.RaiseCanExecuteChanged();
            //ZagrAnilin480StopCommand.RaiseCanExecuteChanged();

        }

        ~MnemonicViewModel()
        {
            internalUpdater.Stop();
            // chartUpdater.Stop();
        }
    }


}
