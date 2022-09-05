using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace cip_blue.Converters
{
    public class SingleSeondsToStringTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

          
           // TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
           
            String res = "";
            
            if (value != null && value.GetType() == typeof(Single))
                try
                {
                    TimeSpan time = TimeSpan.FromSeconds((Single)value);
                    res= time.ToString("hh':'mm");
                }
                catch { };

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}