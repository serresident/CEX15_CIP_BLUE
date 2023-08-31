using Meziantou.Framework.WPF.Collections;
using Prism.Mvvm;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cip_blue.Models
{
	public class ChartData:BindableBase
	{

        public ConcurrentObservableCollection<Tuple<float, double>>? DataPoints { get; set; }
        public ConcurrentObservableCollection<Tuple<float, double>>? DataPoints2 { get; set; }
    }
}
