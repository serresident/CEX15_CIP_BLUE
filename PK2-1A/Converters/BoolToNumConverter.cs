using System;
using System.Globalization;
using System.Windows.Data;

namespace cip_blue.Converters
{
  
    public class BoolToNumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool res = false;
            if (value != null && value.GetType() == typeof(UInt16))
                try
                {
                    res = ((UInt16)value == UInt16.Parse(parameter.ToString()));
                }
                catch { };

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return UInt16.Parse(parameter.ToString());//DependencyProperty.UnsetValue;
        }
    }
}