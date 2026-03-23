using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_UiLayer.ExtensionsClasses
{
    public static class clsDateTimeExtensions
    {
        public static string DateToShort(this DateTime Dt1)
        {

            return Dt1.ToString("dd/MMM/yyyy");
        }
    }
}
