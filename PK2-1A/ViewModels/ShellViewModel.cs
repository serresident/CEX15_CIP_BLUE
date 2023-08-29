using NLog;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using cip_blue.Models;
using cip_blue.Services;
using Microsoft.Web.WebView2.Wpf;
using System.Threading;
using cip_blue.Events;

namespace cip_blue.ViewModels
{
    public class ShellViewModel : BindableBase
    {


        private Logger logger = LogManager.GetCurrentClassLogger();

        private readonly IDialogService dialogService;

        private readonly IEventAggregator eventAggregator;

        private PeriodicalTaskStarter modbusTask = new PeriodicalTaskStarter(TimeSpan.FromMilliseconds(50));
        private readonly ModbusTcpService modbusTcpService;



        private PeriodicalTaskStarter archivTask = new PeriodicalTaskStarter(TimeSpan.FromSeconds(3));
        private readonly ArchivService archivService;

        private PeriodicalTaskStarter logicTask= new PeriodicalTaskStarter(TimeSpan.FromMilliseconds(100));
        private readonly LogicService logicService;

        public User User { get; set; }

        const string title = "Схема ЦИП ФЦМ пресс 4101/4201";
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, title + value); }
        }


        public void ConnectedChanged(bool status) => PlcStatus = status;
        private bool plcStatus = false;
        public bool PlcStatus
        {
            get { return plcStatus; }
            set { SetProperty(ref plcStatus, value); }
        }

        private bool iPStatus = false;
        public bool IPStatus
        {
            get { return iPStatus; }
            set { SetProperty(ref iPStatus, value); }
        }
        LogicViewModel recept;
        public DelegateCommand ShowSettingsDialogCommand { get; private set; }

        public ShellViewModel( IDialogService dialogService, IEventAggregator eventAggregator, User user, ModbusTcpService modbusTcpService, ArchivService archivService,LogicService logicService)
        {
            this.dialogService = dialogService;
            this.eventAggregator = eventAggregator;
            this.User = user;
            this.modbusTcpService = modbusTcpService;
            this.archivService = archivService;

            this.logicService = logicService;
          

            ShowSettingsDialogCommand = new DelegateCommand(ShowSettingsDialog, () => User.IsAuthorized).ObservesProperty(() => User.IsAuthorized); ;

        }

        public void ShowSettingsDialog()
        {

            dialogService.ShowDialog("settings");
          

        }
        bool set_access;
        public bool Set_access
        {
            get
            {
                return this.set_access;
            }
            set
            {
                this.SetProperty<bool>(ref this.set_access, value, "Set_access");
            }
        }


        public void Subscribe()
        {
            eventAggregator.GetEvent<TcpConnect>().Subscribe((o) => IPStatus = o);
        }

        public void Unsubscribe()
        {
            eventAggregator.GetEvent<TcpConnect>().Unsubscribe((o) => IPStatus = o);
        }

        internal void InputPassword()
        {
            dialogService.ShowDialog("password", r =>
            {
                if (r.Parameters.ContainsKey("password"))
                {
                    if (r.Parameters.GetValue<string>("password") == "1515")
                    {
                        User.IsAuthorized = true;
                        Set_access = true;
                        
                    }
                       
                }
            });
        }

        internal void OnLoad()
        {
            modbusTcpService.ConnectedChangedHandler += ConnectedChanged;
            modbusTask.Start(() => modbusTcpService.Worker(), () => modbusTcpService.AfterStop());
          //  archivTask.Start(() => archivService.Worker(), null);
           // journalTask.Start(() => journalService.Worker(), null);
            //logicTask.Start(() => logicService.Worker(), null);
        }

        internal void OnClosing()
        {
           
            
          
            archivTask.Stop();
            logicTask.Stop();
            modbusTcpService.ConnectedChangedHandler -= ConnectedChanged;
            modbusTask.Stop();

        }
    }

}

