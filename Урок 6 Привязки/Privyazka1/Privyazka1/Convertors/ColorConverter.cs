using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Privyazka1.Convertors
{
    class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double d = (double)value;
            byte b = (byte)d;
            Random rand = new Random();
            Color color = new Color {
                A = 255,
                R = (byte)rand.Next(b+155),
                G = (byte)rand.Next(b+155),
                B= (byte)rand.Next(b+155),
            };
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
