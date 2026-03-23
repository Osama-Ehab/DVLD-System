using System;

namespace DVLD_DataAccessLayer.DTOs
{
    // Shared DTO used between DAL <-> BL
    public class clsTestDTO
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public bool TestResult { get; set; }
    }
}
