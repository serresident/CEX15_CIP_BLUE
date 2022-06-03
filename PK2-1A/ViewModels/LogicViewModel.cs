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
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using Prism.Services.Dialogs;
using cip_blue.Dialogs;
using User = cip_blue.Models.User;
using Prism.Events;
using System.Windows;
using WindowState = Xceed.Wpf.Toolkit.WindowState;
using System.Configuration;

namespace cip_blue.ViewModels
{
    public class LogicViewModel : BindableBase
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private bool initVM;
        private PeriodicalTaskStarter chartUpdater;
        private PeriodicalTaskStarter internalUpdater;
        private readonly IDialogService dialogService;
        

        private readonly ArchivRepository archivRepository;

        public DelegateCommand WaterLoadingStartCommand { get; private set; }
        public DelegateCommand WaterLoadingStopCommand { get; private set; }     
        
        public DelegateCommand HotWaterLoadingStartCommand { get; private set; }
        public DelegateCommand HotWaterLoadingStopCommand { get; private set; }      

        public DelegateCommand Hot480WaterLoadingStartCommand { get; private set; }
        public DelegateCommand Hot480WaterLoadingStopCommand { get; private set; }

        public DelegateCommand UnloadFromR422StartCommand { get; private set; }
        public DelegateCommand UnloadFromR422StopCommand { get; private set; }


        public DelegateCommand Ohlagd480StartCommand { get; private set; }
        public DelegateCommand Ohlagd480StopCommand { get; private set; }

        public DelegateCommand RegPhK480aStartCommand { get; private set; }
        public DelegateCommand RegPhK480aStopCommand { get; private set; }

        public DelegateCommand RegPhK480bStartCommand { get; private set; }
        public DelegateCommand RegPhK480bStopCommand { get; private set; }

        public DelegateCommand ZagrMorfolin480StartCommand { get; private set; }
        public DelegateCommand ZagrMorfolin480StopCommand { get; private set; }

        public DelegateCommand ZagrDietil480StartCommand { get; private set; }
        public DelegateCommand ZagrDietil480StopCommand { get; private set; }

        public DelegateCommand ZagrDietilAmin480StartCommand { get; private set; }
        public DelegateCommand ZagrDietilAmin480StopCommand { get; private set; }

        public DelegateCommand ZagrAnilin480StartCommand { get; private set; }
        public DelegateCommand ZagrAnilin480StopCommand { get; private set; }



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
        public DelegateCommand ShowSettingsDialogCommand { get; private set; }

        public User User { get; set; }

        public LogicViewModel(ProcessDataTcp pd, ArchivRepository archivRepository, IDialogService dialogService, IEventAggregator eventAggregator, User user)
        {
            this.User = user;
            this.dialogService = dialogService;

           
            
            PD = pd;
            this.archivRepository = archivRepository;

            //WaterLoadingStartCommand = new DelegateCommand(waterLoadingStart, canWaterLoadingStart);
            //WaterLoadingStopCommand = new DelegateCommand(waterLoadingStop, canWaterLoadingStop);

            //HotWaterLoadingStartCommand = new DelegateCommand(hotwaterLoadingStart, canHotWaterLoadingStart);
            //HotWaterLoadingStopCommand = new DelegateCommand(hotwaterLoadingStop, canHotWaterLoadingStop);

            //Hot480WaterLoadingStartCommand = new DelegateCommand(hot480waterLoadingStart, canHot480WaterLoadingStart);
            //Hot480WaterLoadingStopCommand = new DelegateCommand(hot480waterLoadingStop, canHot480WaterLoadingStop);

            //UnloadFromR422StartCommand = new DelegateCommand(unloadFromR422Start, canUnloadFromR422Start);
            //UnloadFromR422StopCommand = new DelegateCommand(unloadFromR422stop, canUnloadFromR422Stop);

            //Ohlagd480StartCommand = new DelegateCommand(Ohlagd480Start, canOhlagd480Start);
            //Ohlagd480StopCommand = new DelegateCommand(Ohlagd480stop, canOhlagd480Stop);

            //RegPhK480aStartCommand = new DelegateCommand(RegPh480aStart, canRegPh480aStart);
            //RegPhK480aStopCommand = new DelegateCommand(RegPh480astop, canRegPh480aStop);

            //RegPhK480bStartCommand = new DelegateCommand(RegPh480bStart, canRegPh480bStart);
            //RegPhK480bStopCommand = new DelegateCommand(RegPh480bstop, canRegPh480bStop);


            //ZagrMorfolin480StartCommand = new DelegateCommand(ZagrMorfolin480Start, canZagrMorfolin480Start);
            //ZagrMorfolin480StopCommand = new DelegateCommand(ZagrMorfolin480stop, canZagrMorfolin480Stop);

            //ZagrDietil480StartCommand = new DelegateCommand(ZagrDietil480Start, canZagrDietil480Start);
            //ZagrDietil480StopCommand = new DelegateCommand(ZagrDietil480stop, canZagrDietil480Stop);


            //ZagrDietilAmin480StartCommand = new DelegateCommand(ZagrDietilAmin480Start, canZagrDietilAmin480Start);
            //ZagrDietilAmin480StopCommand = new DelegateCommand(ZagrDietilAmin480stop, canZagrDietilAmin480Stop);

            //ZagrAnilin480StartCommand = new DelegateCommand(ZagrAnilin480Start, canZagrAnilin480Start);
            //ZagrAnilin480StopCommand = new DelegateCommand(ZagrAnilin480stop, canZagrAnilin480Stop);



            chartUpdater = new PeriodicalTaskStarter(TimeSpan.FromMilliseconds(50));
            internalUpdater = new PeriodicalTaskStarter(TimeSpan.FromSeconds(1));
           // ShowDialog();


        }
        //команды на кнопким
        //private bool canWaterLoadingStart() {return !PD.ZagrVodaComm_Start ; }// проверяем доступность кнопким
        //private void waterLoadingStart() =>  PD.ZagrVodaComm_Start = true; // предаем старт  на плк
        //private bool canWaterLoadingStop() { return PD.ZagrVodaComm_Start; } // проверяем доступность кнопким
        //private void waterLoadingStop() => PD.ZagrVodaComm_Start = false;// предаем стоп  на плк

        //private bool canHotWaterLoadingStart() { return !PD.ZagrKond460Comm_Start; }
        //private void hotwaterLoadingStart() =>  PD.ZagrKond460Comm_Start = true;
        //private bool canHotWaterLoadingStop() {return PD.ZagrKond460Comm_Start; } 
        //private void hotwaterLoadingStop() => PD.ZagrKond460Comm_Start = false;

        //private bool canHot480WaterLoadingStart() { return !PD.ZagrKond480Comm_Start; }
        //private void hot480waterLoadingStart() =>  PD.ZagrKond480Comm_Start = true;
        //private bool canHot480WaterLoadingStop() {return PD.ZagrKond480Comm_Start; } 
        //private void hot480waterLoadingStop() => PD.ZagrKond480Comm_Start = false;

        //private bool canUnloadFromR422Start() { return !PD.fromR422_xStart; }
        //private void unloadFromR422Start() =>  PD.fromR422_xStart = true;
        //private bool canUnloadFromR422Stop() {return PD.fromR422_xStart; } 
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

                  chartUpdater.Start(() => updateChart(), null);
                    
                    IsBusy = false;
                });

                t.Priority = ThreadPriority.Lowest;
                t.IsBackground = true;
                t.Start();

                t = null;
                initVM = true;
            }

        }

        private bool start_recept;
        public bool Start_recept
        {
            get { return start_recept; }
            set { SetProperty(ref start_recept, value); }
        }
       
        private int state;
        public int State
        {
            get { return state; }
            set { SetProperty(ref state, value); }
        }
        // ph уставка на 1 шаге
        private float setPh_st1_1_A=7.5f;
        public float SetPh_st1_1_A
        {
            get { return setPh_st1_1_A; }
            set { SetProperty(ref setPh_st1_1_A, value); }
        }
        // доза на всю стадию
        private float setPh_zadDdoza_st1_1_A=500;
        public float SetPh_zadDoza_st1_1_A
        {
            get { return setPh_zadDdoza_st1_1_A; }
            set { SetProperty(ref setPh_zadDdoza_st1_1_A, value); }
        }


        // таймаут стабилизации ph
        private float set_time_Ph_st1_A=1;
        public float Set_time_Ph_st1_A 
        {
            get { return set_time_Ph_st1_A; }
            set { SetProperty(ref set_time_Ph_st1_A, value); }
        }



        // ph уставка на 2 шаге
        private float setPh_st2_1_A = 7.5f;
        public float SetPh_st2_1_A
        {
            get { return setPh_st2_1_A; }
            set { SetProperty(ref setPh_st2_1_A, value); }
        }

        // доза анилина
        private float doza_anilin_st2_A = 462;
        public float Doza_anilin_st2_A
        {
            get { return doza_anilin_st2_A; }
            set { SetProperty(ref doza_anilin_st2_A, value); }
        }

        // % откр клапана анилина
        private float percent_valve_Anilin  = 80;
        public float Percent_valve_Anilin
        {
            get { return percent_valve_Anilin; }
            set { SetProperty(ref percent_valve_Anilin, value); }
        }

        // ph уставка на 3 шаге
        private float setPh_st3_1_A =7.5f;
        public float SetPh_st3_1_A
        {
            get { return setPh_st3_1_A; }
            set { SetProperty(ref setPh_st3_1_A, value); }
        }

        //  доза1 диэтиламин на 3 шаге
        private float dietilAmin_doza1 = 807f;
        public float DietilAmin_doza1
        {
            get { return dietilAmin_doza1; }
            set { SetProperty(ref dietilAmin_doza1, value); }
        }


        // доза2 диэтиламин на 3 шаге
        private float dietilAmin_doza2 = 200f;
        public float DietilAmin_doza2
        {
            get { return dietilAmin_doza2; }
            set { SetProperty(ref dietilAmin_doza2, value); }
        }

        //  Температура диэтиламин для дозы2 на 3 шаге
        private float dietilAmin_Tnagr = 60f;
        public float DietilAmin_Tnagr
        {
            get { return dietilAmin_Tnagr; }
            set { SetProperty(ref dietilAmin_Tnagr, value); }
        }

        // ph уставка на 4 шаге
        private float setPh_st4_1_A = 8f;
        public float SetPh_st4_1_A
        {
            get { return setPh_st4_1_A; }
            set { SetProperty(ref setPh_st4_1_A, value); }
        }


        // ph уставка на 2,1 шаге
        private float setPh_st5_1_A = 8.5f;
        public float SetPh_st5_1_A
        {
            get { return setPh_st5_1_A; }
            set { SetProperty(ref setPh_st5_1_A, value); }
        }

        // % прикрытия клапана шаг 2,1
        private float set_ValveSteam = 40f;
        public float Set_ValveSteam
        {
            get { return set_ValveSteam; }
            set { SetProperty(ref set_ValveSteam, value); }
        }

        // Тдегазации шаг 2.1
        private float t_degaz = 67f;
        public float T_degaz
        {
            get { return t_degaz; }
            set { SetProperty(ref t_degaz, value); }
        }


        //  T_off  перегона А
        private float t_on_per_A = 72;
        public float T_On_per_A
        {
            get { return t_on_per_A; }
            set { SetProperty(ref t_on_per_A, value); }
        }



        // объем воды на перегонку A
        private float volume_water_A  = 67f;
        public float Volume_water_A
        {
            get { return volume_water_A; }
            set { SetProperty(ref volume_water_A, value); }
        }

        // время  на перегонку A
        private float time_per_A = 67f;
        public float Time_per_A
        {
            get { return time_per_A; }
            set { SetProperty(ref time_per_A, value); }
        }


        //  T  перегона А
        private float t_per_A = 67f;
        public float T_per_A
        {
            get { return t_per_A; }
            set { SetProperty(ref t_per_A, value); }
        }


        //  T_off  перегона А
        private float t_off_per_A = 97.0f;
        public float T_off_per_A
        {
            get { return t_off_per_A; }
            set { SetProperty(ref t_off_per_A, value); }
        }

        //  PH_avar  перегона А
        private float pH_avar_per_A = 7.8f;
        public float PH_avar_per_A
        {
            get { return pH_avar_per_A; }
            set { SetProperty(ref pH_avar_per_A, value); }
        }

        //  подтверждение перевода r481
        private bool  next = false;
        public bool Next
        {
            get { return next; }
            set { SetProperty(ref next, value); }
        }

        // результат выбор из диалога
        private int dialog_return = 0;
        public int Dialog_return
        {
            get { return dialog_return; }
            set { SetProperty(ref dialog_return, value); }
        }

        // заголовок диалогового окна
        private string dialogTitle="Выберите действие";
        public string DialogTitle
        {
            get { return dialogTitle; }
            set { SetProperty(ref dialogTitle, value); }
        }

        // уровень R481
        private float setLevel_R481 = 50;
        public float SetLevel_R481
        {
            get { return setLevel_R481; }
            set { SetProperty(ref setLevel_R481, value); }
        }

       // время выдержки
        private double setTime_viderzhA = 60;
        public double SetTime_viderzhA
        {
            get { return setTime_viderzhA; }
            set { SetProperty(ref setTime_viderzhA, value); }
        }

        // время выдержки
        private double lastTime_viderzhA ;
        public double LastTime_viderzhA
        {
            get { return lastTime_viderzhA; }
            set { SetProperty(ref lastTime_viderzhA, value); }
        }


        // Температура охл-е
        private double t_ohlazhd_A;
        public double T_ohlazhd_A
        {
            get { return t_ohlazhd_A; }
            set { SetProperty(ref t_ohlazhd_A, value); }
        }

        // время отстаивания
        private double setTime_otstoi_A = 180;
        public double SetTime_otstoi_A
        {
            get { return setTime_otstoi_A; }
            set { SetProperty(ref setTime_otstoi_A, value); }
        }

        // время отстаивания осталось
        private double lastTime_otstoi_A;
        public double LastTime_otstoi_A
        {
            get { return lastTime_otstoi_A; }
            set { SetProperty(ref lastTime_otstoi_A, value); }
        }

        DateTime time_mem ;
        HLTrigger_OFF tr_state_1_4=new HLTrigger_OFF() ;



        bool check_one;
        private String statusOut ;
        // текущий статус
        public String StatusOut
        {
            get { return statusOut; }
            set { if(statusOut!= value) SetProperty(ref statusOut, value); }
        }
        int n;
        DateTime time_last;
        DateTime exposur_time;

        #region Logging
        // You can generate a Token from the "Tokens Tab" in the UI
        const string token = "mHucveNRwLyyPprDcHlGTjtXAE3B6aV3hRGW61Q3UfvT0_G6plFQvpJwS62jFrNK2g4fGEEDNU1HCAJzKoajlQ==";
        const string bucket_journal = "cip_blue_detail";
        const string bucket_serias = "cip_blue";
        const string org = "cip_blue";
        string mem;
        InfluxDBClient client = InfluxDBClientFactory.Create("http://192.168.120.143:8086", token.ToCharArray());
        void Send_Log (string msg)
        {
            if(!(mem==msg))
            try
            {
                string data_journal = "Log_Action,title=cip_blue_hmi_LogState Statelog=" + "\"" + msg + "\"";

                string data_serias = "cip_blue,title=mnemonic_seria_10s ";
                var writeApi = client.GetWriteApiAsync();

                // writeApi.WriteRecord(bucket_journal, org, WritePrecision.Ns, data_journal);

             
                    writeApi.WriteRecordAsync(bucket_journal, org, WritePrecision.Ns, data_journal);

                mem = msg;

            }
            catch(Exception ex)
            {

            }
            

        }
       
    #endregion

    private void updateChart()
        {
           
          
        }


        
        static string ReadRetane(string name)
        {
            string result = null;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[name] ?? "Not Found";
                // result = "1";
                //MessageBox.Show(result);
            }
            catch (ConfigurationErrorsException e)
            {
                // MessageBox.Show(e.ToString()); 
              //  logger.Error("ReadSetting" + e.ToString());
            }

            return result;
        }

        /// <summary>
        /// суммирует передаваемое значение к значению параметра в app.config (сумматор)
        /// </summary>
        /// <param name="value">значение</param>
        /// <param name="nameTag">имя</param>
        /// <returns></returns>
        public void  WriteRetane(double value, string nameTag)
        {

           
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
              

                if (settings[nameTag] == null)
                {
                    settings.Add(nameTag, value.ToString());
                }
                else
                {
                    settings[nameTag].Value = value.ToString();
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

            }
            catch (ConfigurationErrorsException e)
            {
                //  MessageBox.Show("Error writing app settings" + e.Message);
            }

            //logger.Info(total+" total "+nameTag);
            

        }
        public string Title;

        private void ShowDialog()
        {

            var message = "This is a message that should be shown in the dialog.";
            //using the dialog service as-is
        
            dialogService.ShowDialog("next", new DialogParameters($"message={DialogTitle}"), r =>
            {
                if (r.Result == ButtonResult.None)
                {
                    Next = false;
                   // Start_recept = false;
                    Dialog_return = 2;
                }
                else if (r.Result == ButtonResult.OK)
                {
                    Next = true;
                    Dialog_return = 1;
                }
                else if (r.Result == ButtonResult.Cancel)
                {
                    Next = false;
                  //  Start_recept = false;
                    Dialog_return = 3;
                }
                //else
                //{
                //    Next = false;
                //    Start_recept = false;
                //}
            });
           // dialogService.ShowDialog("password");
        }

      

        private void internalUpdate()
        {
            WaterLoadingStartCommand.RaiseCanExecuteChanged();
            WaterLoadingStopCommand.RaiseCanExecuteChanged(); 

            HotWaterLoadingStartCommand.RaiseCanExecuteChanged();
            HotWaterLoadingStopCommand.RaiseCanExecuteChanged();  

            Hot480WaterLoadingStartCommand.RaiseCanExecuteChanged();
            Hot480WaterLoadingStopCommand.RaiseCanExecuteChanged();

            UnloadFromR422StartCommand.RaiseCanExecuteChanged();
            UnloadFromR422StopCommand.RaiseCanExecuteChanged();

            Ohlagd480StartCommand.RaiseCanExecuteChanged();
            Ohlagd480StopCommand.RaiseCanExecuteChanged();

            RegPhK480aStartCommand.RaiseCanExecuteChanged();
            RegPhK480aStopCommand.RaiseCanExecuteChanged();


            RegPhK480bStartCommand.RaiseCanExecuteChanged();
            RegPhK480bStopCommand.RaiseCanExecuteChanged();

            ZagrMorfolin480StartCommand.RaiseCanExecuteChanged();
            ZagrMorfolin480StopCommand.RaiseCanExecuteChanged();

            ZagrDietil480StartCommand.RaiseCanExecuteChanged();
            ZagrDietil480StopCommand.RaiseCanExecuteChanged();

            ZagrDietilAmin480StartCommand.RaiseCanExecuteChanged();
            ZagrDietilAmin480StopCommand.RaiseCanExecuteChanged();

            ZagrAnilin480StartCommand.RaiseCanExecuteChanged();
            ZagrAnilin480StopCommand.RaiseCanExecuteChanged();

        }

        ~LogicViewModel()
        {
            internalUpdater.Stop();
            chartUpdater.Stop();

        }
    }

    internal class  HLTrigger_OFF
   {


        bool prevV = false;

        public bool Check(bool tVal)
    {
        if (!tVal && prevV)
        {
            prevV = tVal;
            return true;
        }
        else
        {
            prevV = tVal;
            return false;
        }

    }

    
    
}


}
