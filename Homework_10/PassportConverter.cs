using System;
using System.Globalization;
using System.Windows.Data;

namespace Homework_10
{
    internal class PassportConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value is string passport || value is string tb_PassportSerial || value is string tb_PassportNumber ) && AccessMode.IsConsultantMode)
            {
                // Возвращаем "*******" вместо реального значения паспорта
                return "*******";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
