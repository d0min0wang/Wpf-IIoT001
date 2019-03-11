using System;
using System.Windows.Media;
using System.Windows.Data;

namespace Wpf_IIoT001
{
    [ValueConversion(typeof(int), typeof(SolidColorBrush))]
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush=new SolidColorBrush(Colors.DarkGray);
            int b = (int)value;
            switch (b)
            {
                case 0:
                    brush = new SolidColorBrush(Colors.DarkGray);
                    break;
                case 1:
                    brush = new SolidColorBrush(Colors.Red);
                    break;
                case 2:
                    brush = new SolidColorBrush(Colors.LimeGreen);
                    break;
                case 3:
                    brush = new SolidColorBrush(Colors.Orange);
                    break;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
