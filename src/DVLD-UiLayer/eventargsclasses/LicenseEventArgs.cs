using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer;

namespace DVLD_UiLayer.EventArgsClasses
{
    public class LicenseEventArgs : EventArgs
    {
        public readonly clsLicense License;
        public LicenseEventArgs(clsLicense License)
        {
            this.License = License;
        }

    }

}
