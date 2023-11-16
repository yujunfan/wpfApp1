using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp1
{
    public class ButtonColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush defaultColor = Brushes.Gray;
            Brush highlightColor = Brushes.Red;

            if (value != null && value.ToString() == parameter.ToString())
            {
                return highlightColor;
            }
            else
            {
                return defaultColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
