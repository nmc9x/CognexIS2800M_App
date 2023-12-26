using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace OCR_Camera_Printer.Views.Converter
{
    public class NumToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = (int)value;
            switch (number)
            {
                case 1:
                    return new SolidColorBrush(Colors.Green); // connected
                case 2:
                    return new SolidColorBrush(Colors.Yellow); // processing
                case 3:
                    return new SolidColorBrush(Colors.Red); // disconnected
                case 0:
                default:
                    return new SolidColorBrush(Colors.Gray); // unknown
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
