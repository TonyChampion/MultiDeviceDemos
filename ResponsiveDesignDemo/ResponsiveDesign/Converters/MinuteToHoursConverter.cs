using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ResponsiveDesign.Converters
{
    public class MinuteToHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if(value is int)
            {
                int totalMinutes = (int)value;

                int hours = (int)Math.Floor(totalMinutes / 60.0);
                int minutes = totalMinutes % 60;

                return String.Format("{0} hr {1} min", hours, minutes);
            } else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
