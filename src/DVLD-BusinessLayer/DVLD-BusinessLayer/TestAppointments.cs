using System;
using System.Collections.Generic;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer.DTOs;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enum SaveResult { Success, ValidationFailed, DbError }

        // State & Properties
        public enMode Mode { get; private set; } = enMode.AddNew;

        public int TestAppointmentID { get; private set; } = -1;
        public clsTestType.enTestType TestTypeID { get; set; } = 0;
        public int LocalDrivingLicenseApplicationID { get; set; } = -1;
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public decimal PaidFees { get; set; } = 0m;
        public int CreatedByUserID { get; set; } = -1;
        public bool IsLocked { get; set; } = false;
        public int RetakeTestAppID { get; set; } = -1;

        // Lazy-loaded composition references (similar to clsApplication)
        private clsApplication _RetakeTestApp;
        public clsApplication RetakeTestAppInfo
        {
            get
            {
                if (_RetakeTestApp == null && this.RetakeTestAppID > 0)
                    _RetakeTestApp = clsApplication.FindBaseApplication(this.RetakeTestAppID);
                return _RetakeTestApp;
            }
        }

        private clsUser _CreatedByUser;
        public clsUser CreatedByUser
        {
            get
            {
                if (_CreatedByUser == null && this.CreatedByUserID > 0)
                    _CreatedByUser = clsUser.Find(this.CreatedByUserID);
                return _CreatedByUser;
            }
        }

        private clsTestType _TestType;
        public clsTestType TestType
        {
            get
            {
                if (_TestType == null && this.TestTypeID != 0)
                    _TestType = clsTestType.Find(this.TestTypeID);
                return _TestType;
            }
        }

        public int TestID
        {
            get { return _GetTestID(); }

        }
        
        // Constructors
        public clsTestAppointment() { /* defaults set above */ }

        private clsTestAppointment(clsTestAppointmentDTO dto)
        {
            this.TestAppointmentID = dto.TestAppointmentID;
            this.TestTypeID = (clsTestType.enTestType)dto.TestTypeID;
            this.LocalDrivingLicenseApplicationID = dto.LocalDLAppID;
            this.AppointmentDate = dto.AppointmentDate;
            this.PaidFees = dto.PaidFees;
            this.CreatedByUserID = dto.CreatedByUserID;
            this.IsLocked = dto.IsLocked;
            this.RetakeTestAppID = dto.RetakeTestAppID;
            this.Mode = enMode.Update;
        }

        // Conversion helpers
        private clsTestAppointmentDTO ToDTO()
        {
            return new clsTestAppointmentDTO
            {
                TestAppointmentID = this.TestAppointmentID,
                TestTypeID = (byte)this.TestTypeID,
                LocalDLAppID = this.LocalDrivingLicenseApplicationID,
                AppointmentDate = this.AppointmentDate,
                PaidFees = this.PaidFees,
                CreatedByUserID = this.CreatedByUserID,
                IsLocked = this.IsLocked,
                RetakeTestAppID = this.RetakeTestAppID
            };
        }

        private bool RefreshFromDB(int id)
        {
            var dto = clsTestAppointmentData.GetByID(id);
            if (dto == null) return false;

            this.TestAppointmentID = dto.TestAppointmentID;
            this.TestTypeID = (clsTestType.enTestType)dto.TestTypeID;
            this.LocalDrivingLicenseApplicationID = dto.LocalDLAppID;
            this.AppointmentDate = dto.AppointmentDate;
            this.PaidFees = dto.PaidFees;
            this.CreatedByUserID = dto.CreatedByUserID;
            this.IsLocked = dto.IsLocked;
            this.RetakeTestAppID = dto.RetakeTestAppID;

            // Clear cached related objects so they re-load lazily when accessed
            _RetakeTestApp = null;
            _CreatedByUser = null;
            _TestType = null;

            return true;
        }

        // Add / Update
        private bool AddNew()
        {
            // Validate person/application existence if necessary
            if (this.LocalDrivingLicenseApplicationID <= 0 || this.CreatedByUserID <= 0 || this.TestTypeID == 0)
                return false;

            var dto = this.ToDTO();
            int newId = clsTestAppointmentData.AddNew(dto);
            if (newId <= 0) return false;

            return this.RefreshFromDB(newId);
        }

        private bool Update()
        {
            if (this.TestAppointmentID <= 0) return false;
            if (!clsTestAppointmentData.IsExist(this.TestAppointmentID)) return false;

            var dto = this.ToDTO();
            if (!clsTestAppointmentData.Update(dto)) return false;

            return this.RefreshFromDB(this.TestAppointmentID);
        }

        // Public Save
        public SaveResult Save()
        {
            // Simple validation
            if (this.LocalDrivingLicenseApplicationID <= 0 || this.CreatedByUserID <= 0 || this.TestTypeID == 0)
                return SaveResult.ValidationFailed;

            if (!clsLocalDLA_DataAccess.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (byte)(this.TestTypeID - 1)))
                return SaveResult.ValidationFailed;

            bool IsSuccess;
            if (this.Mode == enMode.AddNew)
            {
                IsSuccess = AddNew();
            }
            else
            {
                IsSuccess = Update();
            }

            return IsSuccess ? SaveResult.Success : SaveResult.DbError;
        }

        // Public Delete
        public bool Delete()
        {
            if (this.TestAppointmentID <= 0) return false;
            if (!clsTestAppointmentData.IsExist(this.TestAppointmentID)) return false;
            if (!clsTestAppointmentData.Delete(this.TestAppointmentID)) return false;

            // Reset state
            this.TestAppointmentID = -1;
            this.Mode = enMode.AddNew;
            return true;
        }

        // Static helpers & factories
        public static clsTestAppointment Find(
            int id,
            bool includeApplication = false,
            bool includeUser = false,
            bool includeTestType = false)
        {
            var dto = clsTestAppointmentData.GetByID(id);
            if (dto == null) return null;

            var obj = new clsTestAppointment(dto);

            if (includeApplication) _ = obj.RetakeTestAppInfo;
            if (includeUser) _ = obj.CreatedByUser;
            if (includeTestType) _ = obj.TestType;

            return obj;
        }

        public static clsTestAppointment GetLastTestAppointment(int localDLAppID, clsTestType.enTestType testType)
        {
            var dto = clsTestAppointmentData.GetLastTestAppointment(localDLAppID, (byte)testType);
            return dto == null ? null : new clsTestAppointment(dto);
        }

        public static bool Delete(int id)
        {
            if (id <= 0) return false;
            if (!clsTestAppointmentData.IsExist(id)) return false;
            return clsTestAppointmentData.Delete(id);
        }

        public static bool Lock(int id)
        {
            if (id <= 0) return false;
            if (!clsTestAppointmentData.IsExist(id)) return false;
            return clsTestAppointmentData.Lock(id);
        }
        public  bool Lock()
        {
            if (this.TestAppointmentID <= 0) return false;
            if (!clsTestAppointmentData.IsExist(this.TestAppointmentID)) return false;
            return clsTestAppointmentData.Lock(this.TestAppointmentID);
        }

        // Cancel behaves the same as Lock in the old code (keeps compatibility)
        public static bool Cancel(int id) => Lock(id);

        public static List<clsTestAppointment> GetAll()
        {
            var dtos = clsTestAppointmentData.GetAll();
            var list = new List<clsTestAppointment>();
            foreach (var d in dtos) list.Add(new clsTestAppointment(d));
            return list;
        }

        public static List<clsTestAppointment> GetByLocalDLAppID(int localDLAppID, clsTestType.enTestType testType = 0)
        {
            var dtos = clsTestAppointmentData.GetByLocalDLAppID(localDLAppID, (byte)testType);
            var list = new List<clsTestAppointment>();
            foreach (var d in dtos) list.Add(new clsTestAppointment(d));
            return list;
        }

        public static List<clsTestAppointment> GetByTestType(clsTestType.enTestType testType)
        {
            var dtos = clsTestAppointmentData.GetByTestType((byte)testType);
            var list = new List<clsTestAppointment>();
            foreach (var d in dtos) list.Add(new clsTestAppointment(d));
            return list;
        }

        public static bool IsExist(int id) => clsTestAppointmentData.IsExist(id);

        public static int GetTestID(int testAppointmentID) => clsTestAppointmentData.GetTestID(testAppointmentID);

        public  int _GetTestID() => clsTestAppointmentData.GetTestID(this.TestAppointmentID);

        // ==== UI helper DataTable wrappers ====
        public static System.Data.DataTable GetAllAsDataTable() =>
            clsTestAppointmentData.GetAllAsDataTable();

        public static System.Data.DataTable GetByLocalDLAppIDAsDataTable(int localDLAppID, clsTestType.enTestType testType = 0) =>
            clsTestAppointmentData.GetByLocalDLAppIDAsDataTable(localDLAppID, (byte)testType);

        public static System.Data.DataTable GetByTestTypeAsDataTable(clsTestType.enTestType testType) =>
            clsTestAppointmentData.GetByTestTypeAsDataTable((byte)testType);

    }
}
