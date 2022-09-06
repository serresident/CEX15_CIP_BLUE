using NLog;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using cip_blue.Attributes;
using cip_blue.Helpers;
using cip_blue.Models;
using cip_blue.Repositories;

namespace cip_blue.ViewModels
{
    public class ArchivViewModel : BindableBase
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private bool initVM;

        private readonly ArchivRepository archivRepository;

     


        private DateTime maxDTS;
        public DateTime MaxDTS
        {
            get { return maxDTS; }
            set { SetProperty(ref maxDTS, value); }
        }

        private DateTime minDTS;
        public DateTime MinDTS
        {
            get { return minDTS; }
            set { SetProperty(ref minDTS, value); }
        }

        private DateTime selectedDTS;
        public DateTime SelectedDTS
        {
            get { return selectedDTS; }
            set { SetProperty(ref selectedDTS, value); }
        }

        private ArchivItem selectedArchivItem;
        public ArchivItem SelectedArchivItem
        {
            get { return selectedArchivItem; }
            set { SetProperty(ref selectedArchivItem, value); }
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

        private ObservableRangeCollection<ArchivItem> archivItems;
        public ObservableRangeCollection<ArchivItem> ArchivItems
        {
            get { return archivItems; }
            set { SetProperty(ref archivItems, value); }
        }


        public ArchivViewModel(ProcessDataTcp pd, ArchivRepository archivRepository)
        {
            PD = pd;
            this.archivRepository = archivRepository;
        }
     
    }
}
