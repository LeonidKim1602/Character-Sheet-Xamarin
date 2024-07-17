using System;
using Xamarin.Forms;

namespace App3.Models
{
    public class AttributeBonusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int attributeValue)
            {
                int bonus = (attributeValue - 10) / 2;
                return bonus >= 0 ? $"(+{bonus})" : $"({bonus})";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}