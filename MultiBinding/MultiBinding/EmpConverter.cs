using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using System.Windows.Data;

namespace MultiBinding
{
    class EmpConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string EmpData;

            switch((string)parameter)
            {
                case "reverse": EmpData = values[1] + " : " + values[0]; break;
                default: EmpData = values[0] + " : " + values[1]; break;
            }

            return EmpData;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var splitValues = ((string)value).Split(':');
            return splitValues;
        }
    }
}
