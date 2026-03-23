using System;

namespace DVLD_DataAccessLayer.DTOs
{
    public class clsTestAppointmentDTO
    {
        public int TestAppointmentID { get; set; }
        public byte TestTypeID { get; set; }
        public int LocalDLAppID { get; set; }                 // maps to LocalDrivingLicenseApplicationID
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }                 // maps to PaidFees column
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestAppID { get; set; } = -1;        // -1 = null
    }
}
