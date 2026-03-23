using System;
namespace DVLD_DataAccessLayer.DTOs
{
    // Shared DTO used by DAL <-> BL

    public class clsDriverDTO
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
    }


}