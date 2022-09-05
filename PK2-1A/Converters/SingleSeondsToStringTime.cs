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
            String res = "";
            try
            {
               


                TimeSpan time = TimeSpan.FromSeconds(Single.Parse(value.ToString()));
                res = time.ToString("hh':'mm");
            }
            catch ( Exception ex)
            {
                res = "-";
            }
           // TimeSpan time = TimeSpan.FromSeconds(totalSeconds);
           
        
               

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}