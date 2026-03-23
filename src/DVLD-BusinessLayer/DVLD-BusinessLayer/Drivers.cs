using System;
using System.Data;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer.DTOs;

namespace DVLD_BusinessLayer
{
    public class clsDriver
    {
        private enum enMode { AddNew, Update }
        private enMode _mode = enMode.AddNew;

        public enum SaveResult
        {
            Success,
            ValidationFailed,
            DbError
        }

        public int DriverID { get; private set; }
        public int PersonID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }

        private clsPerson _person;

        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedDate = DateTime.Now;
            CreatedByUserID = -1;
            _mode = enMode.AddNew;
        }

        private clsDriver(clsDriverDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            DriverID = dto.DriverID;
            PersonID = dto.PersonID;
            CreatedDate = dto.CreatedDate;
            CreatedByUserID = dto.CreatedByUserID;
            _mode = enMode.Update;
        }

        public clsPerson PersonInfo
        {
            get
            {
                if (_person == null && PersonID > 0)
                    _person = clsPerson.Find(PersonID);
                return _person;
            }
        }

        private clsDriverDTO ToDTO() => new clsDriverDTO
        {
            DriverID = DriverID,
            PersonID = PersonID,
            CreatedDate = CreatedDate,
            CreatedByUserID = CreatedByUserID
        };

        private bool AddNew()
        {
            if (PersonID <= 0 || CreatedByUserID <= 0)
                return false;

            clsDriverDTO dto = ToDTO();
            int newId = clsDriversDataAccess.AddNewDriver(dto);
            if (newId == -1) return false;

            DriverID = newId;
            _mode = enMode.Update;
            return true;
        }

        private bool Update()
        {
            if (DriverID <= 0)
                return false;

            clsDriverDTO dto = ToDTO();
            return clsDriversDataAccess.UpdateDriver(dto);
        }

        public SaveResult Save()
        {
            if (PersonID <= 0 || CreatedByUserID <= 0)
                return SaveResult.ValidationFailed;

            bool isSuccess = (_mode == enMode.AddNew) ? AddNew() : Update();

            return isSuccess ? SaveResult.Success : SaveResult.DbError;
        }

        public static bool Delete(int driverID)
        {
            if (driverID <= 0) return false;
            return clsDriversDataAccess.DeleteDriver(driverID);
        }

        public static clsDriver FindByDriverID(int driverID)
        {
            if (driverID <= 0) return null;

            clsDriverDTO dto = clsDriversDataAccess.Find(driverID);
            return dto != null ? new clsDriver(dto) : null;
        }

        public static clsDriver FindByPersonID(int personID)
        {
            if (personID <= 0) return null;

            clsDriverDTO dto = clsDriversDataAccess.FindByPersonID(personID);
            return dto != null ? new clsDriver(dto) : null;
        }

        public static bool IsExist(int driverID) => clsDriversDataAccess.IsDriverExist(driverID);
        public static bool IsPersonExist(int personID) => clsDriversDataAccess.IsPersonIDExist(personID);
        public static int GetDriverIDByPersonID(int personID) => clsDriversDataAccess.GetDriverIDByPersonID(personID);
        public static DataTable GetAll() => clsDriversDataAccess.GetAllDrivers();
    }
}
