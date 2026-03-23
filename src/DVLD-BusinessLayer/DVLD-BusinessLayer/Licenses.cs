using System;
using System.Data;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer.DTOs;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusinessLayer
{
    public class clsLicense
    {

        
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason : byte { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 }
        public enum enSaveResult : byte { Success = 1, Failed = 2, AlreadyExists = 3, InvalidData = 4 }
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
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

        public byte? LicenseClassID { get; set; }
        private clsLicenseClass _licenseClassInfo;
        public clsLicenseClass LicenseClassInfo
        {
            get
            {
                if (_licenseClassInfo == null && LicenseClassID > 0)
                    _licenseClassInfo = clsLicenseClass.Find(LicenseClassID);
                return _licenseClassInfo;
            }
        }

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }

        // Instance & static issue reason text
        public string IssueReasonText
        {
            get { return GetIssueReasonText(this.IssueReason); }
        }

        public static string GetIssueReasonText(enIssueReason reason)
        {
            switch (reason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        private clsDetainedLicense _detainedInfo;
        public clsDetainedLicense DetainedInfo
        {
            get
            {
                if (_detainedInfo == null && LicenseID > 0)
                    _detainedInfo = clsDetainedLicense.FindByLicenseID(LicenseID);
                return _detainedInfo;
            }
        }

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

        public int CreatedByUserID { get; set; }

        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseCurrentlyDetained(this.LicenseID); }
        }

        public clsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = 3;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0m;
            IsActive = true;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        // Fill-object pattern using an initializer (constructed in FindByDriverID)
        private bool _AddNewLicense()
        {
            var dto = new clsLicenseDTO
            {
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                Notes = string.IsNullOrWhiteSpace(this.Notes) ? string.Empty : this.Notes,
                PaidFees = this.PaidFees,
                IsActive = this.IsActive,
                IssueReason = (byte)this.IssueReason,
                CreatedByUserID = this.CreatedByUserID
            };

            this.LicenseID = clsLicenseData.AddNewLicense(dto);
            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            var dto = new clsLicenseDTO
            {
                LicenseID = this.LicenseID,
                ApplicationID = this.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = this.IssueDate,
                ExpirationDate = this.ExpirationDate,
                Notes = string.IsNullOrWhiteSpace(this.Notes) ? string.Empty : this.Notes,
                PaidFees = this.PaidFees,
                IsActive = this.IsActive,
                IssueReason = (byte)this.IssueReason,
                CreatedByUserID = this.CreatedByUserID
            };

            return clsLicenseData.UpdateLicense(dto);
        }

        public static clsLicense Find(int licenseID)
        {
            if (licenseID <= 0) return null;

            var dto = clsLicenseData.GetLicenseByID(licenseID);
            if (dto == null) return null;

            var license = new clsLicense
            {
                LicenseID = dto.LicenseID,
                ApplicationID = dto.ApplicationID,
                DriverID = dto.DriverID,
                LicenseClassID = dto.LicenseClassID,
                IssueDate = dto.IssueDate,
                ExpirationDate = dto.ExpirationDate,
                Notes = dto.Notes,
                PaidFees = dto.PaidFees,
                IsActive = dto.IsActive,
                IssueReason = (enIssueReason)dto.IssueReason,
                CreatedByUserID = dto.CreatedByUserID,
                Mode = enMode.Update
            };

            // Do not eagerly load compositions here; the lazy properties will load on demand.
            return license;
        }

        public static clsLicense FindByApplicationID(int ApplictionID)
        {
            if (ApplictionID <= 0) return null;

            var dto = clsLicenseData.GetLicenseBApplicationID(ApplictionID);
            if (dto == null) return null;

            var license = new clsLicense
            {
                LicenseID = dto.LicenseID,
                ApplicationID = dto.ApplicationID,
                DriverID = dto.DriverID,
                LicenseClassID = dto.LicenseClassID,
                IssueDate = dto.IssueDate,
                ExpirationDate = dto.ExpirationDate,
                Notes = dto.Notes,
                PaidFees = dto.PaidFees,
                IsActive = dto.IsActive,
                IssueReason = (enIssueReason)dto.IssueReason,
                CreatedByUserID = dto.CreatedByUserID,
                Mode = enMode.Update
            };

            // Do not eagerly load compositions here; the lazy properties will load on demand.
            return license;
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }
        public enSaveResult Save()
        {
            // guard clauses
            if (DriverID <= 0 || LicenseClassID  <= 0 || CreatedByUserID <= 0)
                return enSaveResult.InvalidData;

            if (Mode == enMode.AddNew && this.IssueReason == enIssueReason.FirstTime &&
                clsLicenseData.GetActiveLicenseIDByPersonID(DriverInfo.PersonID, LicenseClassID) != -1)
                return enSaveResult.AlreadyExists;

            bool success = (Mode == enMode.AddNew) ? _AddNewLicense() : _UpdateLicense();

            if (!success)
            {
                return enSaveResult.Failed;
            }

            Mode = enMode.Update;
            return enSaveResult.Success;

        }

        public static bool IsLicenseExistByPersonID(int personID, byte? LicenseClassID)
        {
            if (personID <= 0 || LicenseClassID == null) return false;
            return (clsLicenseData.GetActiveLicenseIDByPersonID(personID, LicenseClassID) != -1);
        }

        public static int GetActiveLicenseIDByPersonID(int personID, byte? LicenseClassID)
        {
            if (personID <= 0 || LicenseClassID == null) return -1;
            return clsLicenseData.GetActiveLicenseIDByPersonID(personID, LicenseClassID);
        }

        public static int GetOldLicenseIDByPersonID(int personID, byte? LicenseClassID)
        {
            if (personID <= 0 || LicenseClassID == null) return -1;
            return clsLicenseData.GetOldLicenseIDByPersonID(personID, LicenseClassID);
        }

        public static DataTable GetDriverLicenses(int driverID)
        {
            if (driverID <= 0) return new DataTable();
            return clsLicenseData.GetDriverLicenses(driverID);
        }

        public bool IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }

        // Detain: changed signature to decimal for fine fees
        public int Detain(decimal fineFees, int createdByUserID)
        {
            if (this.LicenseID <= 0) throw new InvalidOperationException("License must be saved before detaining.");
            if (fineFees < 0) throw new ArgumentException("fineFees must be >= 0", nameof(fineFees));

            var detainedLicense = new clsDetainedLicense
            {
                LicenseID = this.LicenseID,
                DetainDate = DateTime.Now,
                FineFees = fineFees, // assumes clsDetainedLicense has decimal FineFees; if not, convert appropriately
                CreatedByUserID = createdByUserID
            };

            if (detainedLicense.Save() != clsDetainedLicense.enSaveResult.Success)
            {
                return -1;
            }

            return detainedLicense.DetainID;
        }

        // Release detained license -> returns created application object (or null on failure)
        public clsApplication ReleaseDetainedLicense(int releasedByUserID)
        {
            if (this.DetainedInfo == null) return null;

            // Create application (guard checks happen inside clsApplication.Save)
            var application = new clsApplication
            {
                ApplicantPersonID = this.DriverInfo?.PersonID ?? throw new InvalidOperationException("Driver info required to release detained license."),
                ApplicationTypeID = (byte)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense,
                ApplicationStatus = clsApplication.enApplicationStatus.Completed,
                PaidFees = clsApplicationType.Find((byte)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees,
                CreatedByUserID = releasedByUserID
            };

            if (application.Save() != clsApplication.SaveResult.Success)
            {
                return null;
            }

            // call detained license release (assumed to exist)
            bool released = this.DetainedInfo.Release(application.ApplicationID, releasedByUserID);

            if (!released) return null;
            Mode = enMode.Update;
            this.IsActive = true;
            // return full application object
            return application;
        }

        // Renew only if expired (per your request)
        public clsLicense RenewLicense(string notes, int createdByUserID)
        {
            if (!IsLicenseExpired()) return null;

            // Create application
            var application = new clsApplication
            {
                ApplicantPersonID = this.DriverInfo?.PersonID ?? throw new InvalidOperationException("Driver info required to renew license."),
                ApplicationTypeID = (byte)clsApplication.enApplicationType.RenewDrivingLicense,
                ApplicationStatus = clsApplication.enApplicationStatus.Completed,
                PaidFees = clsApplicationType.Find((byte)clsApplication.enApplicationType.RenewDrivingLicense).Fees,
                CreatedByUserID = createdByUserID
            };

            if (application.Save() != clsApplication.SaveResult.Success) return null;

            var newLicense = new clsLicense
            {
                ApplicationID = application.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo != null ? this.LicenseClassInfo.DefaultValidityLength : 1),
                Notes = notes,
                PaidFees = this.LicenseClassInfo != null ? this.LicenseClassInfo.ClassFees : 0m,
                IsActive = true,
                IssueReason = enIssueReason.Renew,
                CreatedByUserID = createdByUserID
            };

            if (newLicense.Save() != enSaveResult.Success) return null;

            // Deactivate current license
            DeactivateCurrentLicense();

            return newLicense;
        }

        public bool CanIssueInternationalLicense()
        {
            return !clsInternationalLicensesDataAccess.IsPersonIDHaveAnActiveInternationalLicenseWithL_ClassID(this.ApplicationInfo.ApplicantPersonID, this.LicenseClassID);
        }

        // Issue New International Driving License
        public clsInternationalLicense IssueNewInternationalDrivingLicense(int createdByUserID)
        {
            if (IsLicenseExpired()) return null;
            if (!CanIssueInternationalLicense()) return null;

            // Create application
            var application = new clsApplication
            {
                ApplicantPersonID = this.DriverInfo?.PersonID ?? throw new InvalidOperationException("Driver info required to renew license."),
                ApplicationTypeID = (byte)clsApplication.enApplicationType.NewInternationalLicense,
                ApplicationStatus = clsApplication.enApplicationStatus.Completed,
                PaidFees = clsApplicationType.Find((byte)clsApplication.enApplicationType.NewInternationalLicense).Fees,
                CreatedByUserID = createdByUserID
            };

            if (application.Save() != clsApplication.SaveResult.Success) return null;

            var newInternationalLicense = new clsInternationalLicense
            {
                ApplicationID = application.ApplicationID,
                DriverID = this.DriverID,
                IssuedUsingLocalLicenseID = this.LicenseID,                
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(1),
                IsActive = true,
                CreatedByUserID = createdByUserID
            };

            if (newInternationalLicense.Save() != clsInternationalLicense.enSaveResult.Success) return null;

            return newInternationalLicense;
        }

     

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {


            //First Create Applicaiton 
            clsApplication Application = new clsApplication
            {

                ApplicantPersonID = this.DriverInfo?.PersonID ?? throw new InvalidOperationException("Driver info required to Replace license."),
                ApplicationTypeID = Convert.ToByte((IssueReason == enIssueReason.DamagedReplacement) ?
                clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                clsApplication.enApplicationType.ReplaceLostDrivingLicense),
                ApplicationStatus = clsApplication.enApplicationStatus.Completed,
                PaidFees = clsApplicationType.Find(Convert.ToByte(clsApplication.enApplicationType.ReplaceLostDrivingLicense)).Fees,
                CreatedByUserID = CreatedByUserID
            };

            if (Application.Save() != clsApplication.SaveResult.Success)
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense
            {
                ApplicationID = Application.ApplicationID,
                DriverID = this.DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = this.ExpirationDate,
                Notes = this.Notes,
                PaidFees = 0,// no fees for the license because it's a replacement.
                IsActive = true,
                IssueReason = IssueReason,
                CreatedByUserID = CreatedByUserID
            };


            if (NewLicense.Save() != enSaveResult.Success)
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public bool DeactivateCurrentLicense()
        {
            if (this.LicenseID <= 0) return false;
            return clsLicenseData.DeactivateLicense(this.LicenseID);
        }
    }
}
