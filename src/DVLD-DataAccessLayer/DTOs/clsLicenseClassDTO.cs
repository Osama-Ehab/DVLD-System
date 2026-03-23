using System;

namespace DVLD_DataAccessLayer.DTOs
{
    public class clsLicenseClassDTO
    {
        public byte? LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }
    }
}
