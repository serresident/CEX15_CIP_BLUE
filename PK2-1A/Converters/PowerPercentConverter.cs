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
    public class PowerPercentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float res = 0;

            if (value != null)// && value.GetType() == typeof(UInt16))
            {
                try
                {
                    res = System.Convert.ToInt32(value) / (float)10;
                    if (res < 0) res = 0;
                    if (res > 100) res = 100;
                }
                catch { }
            }

            //res = 99;
            return res;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
