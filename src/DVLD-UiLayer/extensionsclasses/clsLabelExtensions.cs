using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UiLayer.ExtensionsClasses
{
    public static class clsLabelExtensions
    {
        public static void SetRecordsCount(this Label label, int RecordsCount)
        {
            label.Text = (RecordsCount == 0) ? "No Records Found" : RecordsCount.ToString();
        }
    }
}
