using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace 使用静态资源
{
    class ConverterTitle2 : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return "3." + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
