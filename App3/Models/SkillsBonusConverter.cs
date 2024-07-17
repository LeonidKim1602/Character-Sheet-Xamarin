using System;
using System.Globalization;
using Xamarin.Forms;

namespace App3.Models
{
    internal class SkillsBonusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int skillValue)
            {
                int bonus = skillValue;
                return bonus >= 0 ? $"(+{bonus})" : $"({bonus})";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
