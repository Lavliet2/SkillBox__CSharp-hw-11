using System;
using System.Globalization;
using System.Windows.Data;

namespace Homework_10
{
    public class AccessModeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Проверяем, является ли значение AccessMode.ConsultantMode
            return AccessMode.IsConsultantMode;
            //return value as AccessMode == AccessMode.IsConsultantMode;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
   
}
