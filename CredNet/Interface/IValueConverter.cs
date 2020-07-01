using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredNet.Interface
{
    public interface IValueConverter
    {
        object Convert(object value, Type targetType);

        object ConvertBack(object value, Type targetType);
    }
}
