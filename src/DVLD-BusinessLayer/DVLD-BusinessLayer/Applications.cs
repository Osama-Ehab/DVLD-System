using System;
using System.Collections.Generic;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer.DTOs;

namespace DVLD_BusinessLayer
{
    public class clsApplication
    {
        // =========================
        // Enums
        // =========================
        public enum enMode { AddNew = 0, Update = 1 }
        public enum SaveResult { Success, ValidationFailed, DbError }

        public enum enApplicationType : byte
        {
            NewDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }

        public enum enApplicationStatus : byte { New = 1, Cancelled = 2, Completed = 3 }

        // =========================
        // State & Properties
        // =========================
        public enMode Mode { get; private set; } = enMode.AddNew;

        public int ApplicationID { get; private set; } = -1;
        public int ApplicantPersonID { get; set; } = -1;
        public DateTime ApplicationDate { get; private set; } = DateTime.Now;
        public byte ApplicationTypeID { get; set; } = 0;
        public enApplicationStatus ApplicationStatus { get; set; } = enApplicationStatus.New;
        public DateTime LastStatusDate { get; private set; } = DateTime.Now;
        public decimal PaidFees { get; set; } = 0m;
        public int CreatedByUserID { get; set; } = -1;

        // =========================
        // Lazy Loaded Properties
        // =========================
        private clsApplicationType _ApplicationTypeInfo;
        public clsApplicationType ApplicationTypeInfo
        {
            get
            {
                if (_ApplicationTypeInfo == null && ApplicationTypeID > 0)
                    _ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
                return _ApplicationTypeInfo;
            }
            set => _ApplicationTypeInfo = value;
        }

        private clsPerson _personInfo;
        public clsPerson PersonInfo
        {
            get
            {
                if (_personInfo == null && ApplicantPersonID > 0)
                    _personInfo = clsPerson.Find(ApplicantPersonID);
                return _personInfo;
            }
            set => _personInfo = value;
        }

        private clsUser _createdByUserInfo;
        public clsUser CreatedByUserInfo
        {
            get
            {
                if (_createdByUserInfo == null && CreatedByUserID > 0)
                    _createdByUserInfo = clsUser.Find(CreatedByUserID);
                return _createdByUserInfo;
            }
            set => _createdByUserInfo = value;
        }

        // =========================
        // Computed Properties
        // =========================
        public string StatusText => this.ApplicationStatus.ToString() ?? "Unknown";
        public string ApplicantFullName => PersonInfo?.FullName ?? "Unknown";

        // =========================
        // Constructors
        // =========================
        public clsApplication() { }

        private clsApplication(clsApplicationDTO dto)
        {
            this.ApplicationID = dto.ApplicationID;
            this.ApplicantPersonID = dto.ApplicantPersonID;
            this.ApplicationDate = dto.ApplicationDate;
            this.ApplicationTypeID = dto.ApplicationTypeID;
            this.ApplicationStatus = (enApplicationStatus)dto.ApplicationStatus;
            this.LastStatusDate = dto.LastStatusDate;
            this.PaidFees = dto.PaidFees;
            this.CreatedByUserID = dto.CreatedByUserID;

            // Do not load PersonInfo or CreatedByUserInfo here — lazy loading will handle it
            this.Mode = enMode.Update;
        }

        // =========================
        // Private Helpers
        // =========================
        private clsApplicationDTO ToDTO()
        {
            return new clsApplicationDTO
            {
                ApplicationID = this.ApplicationID,
                ApplicantPersonID = this.ApplicantPersonID,
                ApplicationDate = this.ApplicationDate,
                ApplicationTypeID = this.ApplicationTypeID,
                ApplicationStatus = (byte)this.ApplicationStatus,
                LastStatusDate = this.LastStatusDate,
                PaidFees = this.PaidFees,
                CreatedByUserID = this.CreatedByUserID
            };
        }

        private bool RefreshFromDB(int applicationId)
        {
            var fresh = clsApplicationData.GetApplicationByID(applicationId);
            if (fresh == null)
                return false;

            this.ApplicationID = fresh.ApplicationID;
            this.ApplicantPersonID = fresh.ApplicantPersonID;
            this.ApplicationDate = fresh.ApplicationDate;
            this.ApplicationTypeID = fresh.ApplicationTypeID;
            this.ApplicationStatus = (enApplicationStatus)fresh.ApplicationStatus;
            this.LastStatusDate = fresh.LastStatusDate;
            this.PaidFees = fresh.PaidFees;
            this.CreatedByUserID = fresh.CreatedByUserID;

            // Reset cached references
            _personInfo = null;
            _createdByUserInfo = null;

            return true;
        }

        private bool AddNew()
        {
            if (!clsPerson.IsPersonExist(this.ApplicantPersonID))
                return false;

            var dto = this.ToDTO();
            dto.ApplicationStatus = (byte)enApplicationStatus.New;

            int newId = clsApplicationData.AddNewApplication(dto);
            if (newId == -1)
                return false;

            if (!this.RefreshFromDB(newId))
                return false;

            this.Mode = enMode.Update;
            return true;
        }

        private bool Update()
        {
            if (this.ApplicationID <= 0)
                return false;

            if (!clsApplicationData.IsApplicationExist(this.ApplicationID))
                return false;

            var dto = this.ToDTO();
            if (!clsApplicationData.UpdateApplication(dto))
                return false;

            return this.RefreshFromDB(this.ApplicationID);
        }

        // =========================
        // Public Methods
        // =========================
        public SaveResult Save()
        {
            if (this.ApplicantPersonID <= 0 || this.CreatedByUserID <= 0 || this.ApplicationTypeID == 0)
                return SaveResult.ValidationFailed;

            if (this.Mode == enMode.AddNew)
                return AddNew() ? SaveResult.Success : SaveResult.DbError;

            return Update() ? SaveResult.Success : SaveResult.DbError;
        }

        public bool Delete()
        {
            if (this.ApplicationID <= 0)
                return false;

            if (!clsApplicationData.IsApplicationExist(this.ApplicationID))
                return false;

            if (!clsApplicationData.DeleteApplication(this.ApplicationID))
                return false;

            this.ApplicationID = -1;
            this.Mode = enMode.AddNew;
            return true;
        }

        public static bool Delete(int applicationID)
        {
            if (applicationID <= 0)
                return false;

            if (!clsApplicationData.IsApplicationExist(applicationID))
                return false;

            return clsApplicationData.DeleteApplication(applicationID);
        }

        public bool Cancel()
        {
            if (this.ApplicationID <= 0)
                return false;

            if (this.ApplicationStatus == enApplicationStatus.Cancelled ||
                this.ApplicationStatus == enApplicationStatus.Completed)
                return false;

            if (!clsApplicationData.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Cancelled))
                return false;

            return this.RefreshFromDB(this.ApplicationID);
        }

        public bool SetComplete()
        {
            if (this.ApplicationID <= 0)
                return false;

            if (this.ApplicationStatus == enApplicationStatus.Cancelled ||
                this.ApplicationStatus == enApplicationStatus.Completed)
                return false;

            if (!clsApplicationData.UpdateStatus(this.ApplicationID, (byte)enApplicationStatus.Completed))
                return false;

            return this.RefreshFromDB(this.ApplicationID);
        }

        // =========================
        // Static Methods
        // =========================
        public static clsApplication FindBaseApplication(int applicationId)
        {
            var dto = clsApplicationData.GetApplicationByID(applicationId);
            return dto == null ? null : new clsApplication(dto);
        }

        public static List<clsApplication> GetAll()
        {
            var dtos = clsApplicationData.GetAllApplications();
            var list = new List<clsApplication>();
            foreach (var dto in dtos)
                list.Add(new clsApplication(dto));
            return list;
        }

        public static bool IsApplicationExist(int applicationId) =>
            clsApplicationData.IsApplicationExist(applicationId);

        public static bool DoesPersonHaveActiveApplication(int personId, enApplicationType applicationType) =>
            clsApplicationData.GetActiveApplicationID(personId, (byte)applicationType) != -1;

        public static int GetActiveApplicationID(int personId, enApplicationType applicationType) =>
            clsApplicationData.GetActiveApplicationID(personId, (byte)applicationType);

        public static int GetActiveApplicationIDForLicenseClass(int personId, enApplicationType applicationType, byte? LicenseClassID) =>
            clsApplicationData.GetActiveApplicationIDForLicenseClass(personId, (byte)applicationType, LicenseClassID);

        public bool DoesHaveAnActiveApplication(enApplicationType applicationType) =>
            clsApplicationData.GetActiveApplicationID(this.ApplicantPersonID, (byte)applicationType) != -1;

        public int GetActiveApplicationID(enApplicationType applicationType) =>
            clsApplicationData.GetActiveApplicationID(this.ApplicantPersonID, (byte)applicationType);

        public int GetActiveApplicationIDForLicenseClass(enApplicationType applicationType, byte? LicenseClassID) =>
            clsApplicationData.GetActiveApplicationIDForLicenseClass(this.ApplicantPersonID, (byte)applicationType, LicenseClassID);
    }
}
