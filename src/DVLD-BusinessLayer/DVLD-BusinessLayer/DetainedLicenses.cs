using System;
using System.Data;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer.DTOs;

namespace DVLD_BusinessLayer
{
    public class clsDetainedLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enum enSaveResult : byte
        {
            Success = 1,
            Failed = 2,
            AlreadyDetained = 3,
            InvalidData = 4
        }

        // Primary properties
        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; private set; }
        public DateTime? ReleaseDate { get; private set; }
        public int? ReleasedByUserID { get; private set; }
        public int? ReleaseApplicationID { get; private set; }

        // Internal mode state
        private enMode _mode;

        // Lazy-loaded compositions
        private clsUser _createdByUserInfo;
        private clsUser _releasedByUserInfo;
        private clsApplication _releaseApplication;

        // Lazy-loaded properties
        public clsUser CreatedByUserInfo
        {
            get
            {
                if (_createdByUserInfo == null && CreatedByUserID > 0)
                    _createdByUserInfo = clsUser.Find(CreatedByUserID);
                return _createdByUserInfo;
            }
        }

        public clsUser ReleasedByUserInfo
        {
            get
            {
                if (_releasedByUserInfo == null && ReleasedByUserID.HasValue && ReleasedByUserID.Value > 0)
                    _releasedByUserInfo = clsUser.Find(ReleasedByUserID.Value);
                return _releasedByUserInfo;
            }
        }

        public clsApplication ReleaseApplication
        {
            get
            {
                if (_releaseApplication == null && ReleaseApplicationID.HasValue && ReleaseApplicationID.Value > 0)
                    _releaseApplication = clsApplication.FindBaseApplication(ReleaseApplicationID.Value);
                return _releaseApplication;
            }
        }

        // Constructors
        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0m;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;
            _mode = enMode.AddNew;
        }

        private clsDetainedLicense(clsDetainedLicenseDTO dto)
        {
            if (dto == null) throw new ArgumentNullException("dto");

            DetainID = dto.DetainID;
            LicenseID = dto.LicenseID;
            DetainDate = dto.DetainDate;
            FineFees = dto.FineFees;
            CreatedByUserID = dto.CreatedByUserID;
            IsReleased = dto.IsReleased;
            ReleaseDate = dto.ReleaseDate;
            ReleasedByUserID = dto.ReleasedByUserID;
            ReleaseApplicationID = dto.ReleaseApplicationID;
            _mode = enMode.Update;
        }

        // Map to DTO
        private clsDetainedLicenseDTO ToDTO()
        {
            return new clsDetainedLicenseDTO
            {
                DetainID = this.DetainID,
                LicenseID = this.LicenseID,
                DetainDate = this.DetainDate,
                FineFees = this.FineFees,
                CreatedByUserID = this.CreatedByUserID,
                IsReleased = this.IsReleased,
                ReleaseDate = this.ReleaseDate,
                ReleasedByUserID = this.ReleasedByUserID,
                ReleaseApplicationID = this.ReleaseApplicationID
            };
        }

        // Private add/update implementations
        private bool AddNewInternal()
        {
            var dto = new clsDetainedLicenseDTO
            {
                LicenseID = this.LicenseID,
                DetainDate = this.DetainDate,
                FineFees = this.FineFees,
                CreatedByUserID = this.CreatedByUserID,
                IsReleased = this.IsReleased,
                ReleaseDate = this.ReleaseDate,
                ReleasedByUserID = this.ReleasedByUserID,
                ReleaseApplicationID = this.ReleaseApplicationID
            };

            int newId = clsDetainedLicensesDataAccess.Add(dto);
            if (newId <= 0)
                return false;

            this.DetainID = newId;
            this._mode = enMode.Update;
            return true;
        }

        private bool UpdateInternal()
        {
            var dto = ToDTO();
            return clsDetainedLicensesDataAccess.Update(dto);
        }

        // Public Save
        public enSaveResult Save()
        {
            if (this.LicenseID <= 0 || this.CreatedByUserID <= 0)
                return enSaveResult.InvalidData;

            if (_mode == enMode.AddNew)
            {
                if (clsDetainedLicensesDataAccess.IsLicenseCurrentlyDetained(this.LicenseID))
                    return enSaveResult.AlreadyDetained;

                bool added = AddNewInternal();
                return added ? enSaveResult.Success : enSaveResult.Failed;
            }

            bool updated = UpdateInternal();
            return updated ? enSaveResult.Success : enSaveResult.Failed;
        }

        // Release instance method
        public bool Release(int releaseApplicationId, int releasedByUserId)
        {
            if (this.DetainID <= 0) return false;
            if (releaseApplicationId <= 0 || releasedByUserId <= 0) return false;

            bool ok = clsDetainedLicensesDataAccess.MarkAsReleased(this.DetainID, releaseApplicationId, releasedByUserId);
            if (!ok) return false;

            this.IsReleased = true;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = releasedByUserId;
            this.ReleaseApplicationID = releaseApplicationId;
            this._releasedByUserInfo = null;
            this._releaseApplication = null;
            return true;
        }

        // Static finders
        public static clsDetainedLicense Find(int detainID)
        {
            if (detainID <= 0) return null;
            clsDetainedLicenseDTO dto = clsDetainedLicensesDataAccess.GetByID(detainID);
            if (dto == null) return null;
            return new clsDetainedLicense(dto);
        }

        public static clsDetainedLicense FindByReleaseApplicationID(int releaseApplicationID)
        {
            if (releaseApplicationID <= 0) return null;
            clsDetainedLicenseDTO dto = clsDetainedLicensesDataAccess.GetByReleaseApplicationID(releaseApplicationID);
            if (dto == null) return null;
            return new clsDetainedLicense(dto);
        }

        public static clsDetainedLicense FindByLicenseID(int licenseID)
        {
            if (licenseID <= 0) return null;
            clsDetainedLicenseDTO dto = clsDetainedLicensesDataAccess.GetByLicenseID(licenseID);
            if (dto == null) return null;
            return new clsDetainedLicense(dto);
        }

        // Static convenience methods
        public static bool IsLicenseCurrentlyDetained(int licenseID)
        {
            if (licenseID <= 0) return false;
            return clsDetainedLicensesDataAccess.IsLicenseCurrentlyDetained(licenseID);
        }

        public static bool Delete(int detainID)
        {
            if (detainID <= 0) return false;
            return clsDetainedLicensesDataAccess.Delete(detainID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesDataAccess.GetAll();
        }
    }
}
