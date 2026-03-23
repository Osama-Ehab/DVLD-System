using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer.DTOs
{
    public class clsLocalDLADTO
    {
        public int LocalDLAppID { get; set; }    // PK
        public int ApplicationID { get; set; }   // FK -> Applications.ApplicationID
        public byte? LicenseClassID { get; set; }
    }
}
