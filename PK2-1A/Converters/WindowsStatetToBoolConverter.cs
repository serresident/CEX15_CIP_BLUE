using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace cip_blue.Converters
{
    public class WindowsStatetToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool res = false;
            if (value != null && value.GetType() == typeof(Xceed.Wpf.Toolkit.WindowState))
                res = ((Xceed.Wpf.Toolkit.WindowState)value == Xceed.Wpf.Toolkit.WindowState.Open);

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if ((bool)value)
                return Xceed.Wpf.Toolkit.WindowState.Open;
            else
                return Xceed.Wpf.Toolkit.WindowState.Closed;
            //return DependencyProperty.UnsetValue;
        }
    }

}
