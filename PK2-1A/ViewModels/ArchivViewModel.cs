using NLog;
using OxyPlot.Wpf;
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

        private Plot plot;


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
        public void OnLoadingChart(Plot plot) => this.plot = plot;

        public void OnLoading()
        {
            if (!initVM)
            {
                var t = new Thread(() =>
                {
                    IsBusy = true;

                    var _archivItems = new List<ArchivItem>();
                    foreach (PropertyInfo prop in PD.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && p.PropertyType != typeof(bool) && !p.CanWrite && Attribute.IsDefined(p, typeof(ArchivAttribute))))
                    {

                        var attr = (ArchivAttribute[])prop.GetCustomAttributes(typeof(ArchivAttribute), false);
                        if (attr[0].Group == "")
                        {
                            var ai = new ArchivItem() { Title = attr[0].Title, MaxY = attr[0].MaxY };
                            ai.MeasuresName.Add(prop.Name);
                            ai.MeasuresCaption.Add(attr[0].Title);
                            _archivItems.Add(ai);
                        }
                        else
                        {
                            var finding = _archivItems.Find(x => x.Title == "+ " + attr[0].Group);
                            if (finding == null)
                            {
                                var ai = new ArchivItem() { Title = "+ " + attr[0].Group, IsGroup = true, MaxY = attr[0].MaxY };
                                ai.MeasuresName.Add(prop.Name);
                                ai.MeasuresCaption.Add(attr[0].Title);
                                _archivItems.Add(ai);
                            }
                            else
                            {
                                finding.MeasuresName.Add(prop.Name);
                                finding.MeasuresCaption.Add(attr[0].Title);
                                if (finding.MaxY < attr[0].MaxY) finding.MaxY = attr[0].MaxY;
                            }
                        }
                    }

                    ArchivItems = new ObservableRangeCollection<ArchivItem>(_archivItems.OrderBy(p => p.Title));
                    SelectedArchivItem = ArchivItems.First();

                    updateMinMaxDate();

                    IsBusy = false;
                });

                t.Priority = ThreadPriority.Lowest;
                t.IsBackground = true;
                t.Start();

                t = null;
                initVM = true;
            }
        }

        private void updateMinMaxDate()
        {
            // Interval
            DateTime[] dates = archivRepository.GetMinMaxDateForMeasurements();

            if (dates == null) // повтор
                dates = archivRepository.GetMinMaxDateForMeasurements();

            MinDTS = dates[0];
            MaxDTS = dates[1];

            SelectedDTS = MaxDTS;
        }
    }
}
