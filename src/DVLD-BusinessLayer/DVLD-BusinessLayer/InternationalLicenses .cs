using System;
using System.Data;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer.DTOs;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enum enSaveResult : byte { Success = 1, Failed = 2, InvalidData = 3 }

        public int InternationalLicenseID { get; private set; }
        public int ApplicationID { get; set; }
        private clsApplication _applicationInfo;
        public clsApplication ApplicationInfo
        {
            get
            {
                if (_applicationInfo == null && ApplicationID > 0)
                    _applicationInfo = clsApplication.FindBaseApplication(ApplicationID);
                return _applicationInfo;
            }
        }

        public int DriverID { get; set; }
        private clsDriver _driverInfo;
        public clsDriver DriverInfo
        {
            get
            {
                if (_driverInfo == null && DriverID > 0)
                    _driverInfo = clsDriver.FindByDriverID(DriverID);
                return _driverInfo;
            }
        }

        public int IssuedUsingLocalLicenseID { get; set; }
        private clsLicense _issuedUsingLocalLicenseInfo;
        public clsLicense IssuedUsingLocalLicenseInfo
        {
            get
            {
                if (_issuedUsingLocalLicenseInfo == null && IssuedUsingLocalLicenseID > 0)
                    _issuedUsingLocalLicenseInfo = clsLicense.Find(IssuedUsingLocalLicenseID);
                return _issuedUsingLocalLicenseInfo;
            }
        }

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        private enMode _Mode { get; set; }

        public clsInternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = this.IssueDate.AddYears(1);
            this.IsActive = true;
            this.CreatedByUserID = -1;
            this._Mode = enMode.AddNew;
        }

        private clsInternationalLicense(clsInternationalLicenseDTO dto)
        {
            this.InternationalLicenseID = dto.InternationalLicenseID;
            this.ApplicationID = dto.ApplicationID;
            this.DriverID = dto.DriverID;
            this.IssuedUsingLocalLicenseID = dto.IssuedUsingLocalLicenseID;
            this.IssueDate = dto.IssueDate;
            this.ExpirationDate = dto.ExpirationDate;
            this.IsActive = dto.IsActive;
            this.CreatedByUserID = dto.CreatedByUserID;
            this._Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            var dto = new clsInternationalLicenseDTO
            {
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                IssuedUsingLocalLicenseID = this.IssuedUsingLocalLicenseID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                IsActive = this.IsActive,
                CreatedByUserID = this.CreatedByUserID
            };

            int inserted = clsInternationalLicensesDataAccess.AddNewInternationalLicense(dto);
            if (inserted != -1)
            {
                this.InternationalLicenseID = inserted;
                return true;
            }
            return false;
        }

        private bool _UpdateInternationalLicense()
        {
            var dto = new clsInternationalLicenseDTO
            {
                InternationalLicenseID = this.InternationalLicenseID,
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                IssuedUsingLocalLicenseID = this.IssuedUsingLocalLicenseID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                IsActive = this.IsActive,
                CreatedByUserID = this.CreatedByUserID
            };

            return clsInternationalLicensesDataAccess.UpdateInternationalLicense(dto);
        }

        public static clsInternationalLicense Find(int id)
        {
            if (id <= 0) return null;
            var dto = clsInternationalLicensesDataAccess.GetInternationalLicenseByID(id);
            if (dto == null) return null;
            return new clsInternationalLicense(dto);
        }

        public static clsInternationalLicense FindByApplicationID(int applicationID)
        {
            if (applicationID <= 0) return null;
            var dto = clsInternationalLicensesDataAccess.GetInternationalLicenseByApplicationID(applicationID);
            if (dto == null) return null;
            return new clsInternationalLicense(dto);
        }

        public static clsInternationalLicense FindByLocalLicenseID(int localLicenseID)
        {
            if (localLicenseID <= 0) return null;
            var dto = clsInternationalLicensesDataAccess.GetInternationalLicenseByLocalLicenseID(localLicenseID);
            if (dto == null) return null;
            return new clsInternationalLicense(dto);
        }

        public enSaveResult Save()
        {
            // simple guards
            if (this.DriverID <= 0 || this.IssuedUsingLocalLicenseID <= 0 || this.CreatedByUserID <= 0)
                return enSaveResult.InvalidData;

            bool Success;
            if (this._Mode == enMode.AddNew)
                Success = _AddNewInternationalLicense();
            else
                Success = _UpdateInternationalLicense();

            if (!Success) return enSaveResult.Failed;

            this._Mode = enMode.Update;
            return enSaveResult.Success;
        }

        public static bool DeleteInternationalLicense(int id)
        {
            if (!clsInternationalLicensesDataAccess.IsInternationalLicenseExist(id)) return false;
            return clsInternationalLicensesDataAccess.DeleteInternationalLicense(id);
        }

        public static bool IsApplicationIDExist(int applicationID)
        {
            return clsInternationalLicensesDataAccess.IsApplicationIDExist(applicationID);
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesDataAccess.GetAllInternationalLicenses();
        }

        public static DataTable GetAllInternationalLicensesRelatedToPersonID(int personID)
        {
            return clsInternationalLicensesDataAccess.GetAllInternationalLicensesRelatedToPersonID(personID);
        }

        public static DataTable GetDriverInternationalLicenses(int driverID)
        {
            return clsInternationalLicensesDataAccess.GetAllInternationalLicensesRelatedToDriverID(driverID);
        }

        public static bool IsInternationalLicenseExist(int id)
        {
            return clsInternationalLicensesDataAccess.IsInternationalLicenseExist(id);
        }

        public bool IsDetained()
        {
            return clsInternationalLicensesDataAccess.IsInternationalLicenseDetained(this.InternationalLicenseID);
        }


        public static bool IsPersonIDHaveAnActiveInternationalLicenseWithL_ClassID(int personID, byte? licenseClassID)
        {
            return clsInternationalLicensesDataAccess.IsPersonIDHaveAnActiveInternationalLicenseWithL_ClassID(personID, licenseClassID);
        }

        public static bool IsDriverIDHaveAnActiveInternationalLicenseWithL_ClassID(int driverID, byte? licenseClassID)
        {
            return clsInternationalLicensesDataAccess.IsDriverIDHaveAnActiveInternationalLicenseWithL_ClassID(driverID, licenseClassID);
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int driverID)
        {
            return clsInternationalLicensesDataAccess.GetActiveInternationalLicenseIDByDriverID(driverID);
        }
    }
}