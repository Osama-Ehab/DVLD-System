using System;
using System.Collections.Generic;
using System.Data;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer.DTOs;

namespace DVLD_BusinessLayer
{
    public class clsLocalDL_App
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        public int LocalDLAppID { get; set; } = -1;
        public int ApplicationID { get; set; } = -1;
        public byte? LicenseClassID { get; set; } = 3;

        // Lazy navigation props
        private clsApplication _application;
        public clsApplication ApplicationInfo
        {
            get
            {
                if (_application == null && ApplicationID > 0)
                    _application = clsApplication.FindBaseApplication(ApplicationID);
                return _application;
            }
            private set => _application = value;
        }

        private clsLicenseClass _licenseClass;
        public clsLicenseClass LicenseClassInfo
        {
            get
            {
                if (_licenseClass == null && LicenseClassID > 0)
                    _licenseClass = clsLicenseClass.Find(LicenseClassID);
                return _licenseClass;
            }
            private set => _licenseClass = value;
        }

        // Constructors
        private clsLocalDL_App(clsLocalDLADTO dto, bool includeApp = false, bool includeLicenseClass = false)
        {
            this.LocalDLAppID = dto.LocalDLAppID;
            this.ApplicationID = dto.ApplicationID;
            this.LicenseClassID = dto.LicenseClassID;
            this._Mode = enMode.Update;

            if (includeApp) _application = clsApplication.FindBaseApplication(dto.ApplicationID);
            if (includeLicenseClass) _licenseClass = clsLicenseClass.Find(dto.LicenseClassID);
        }

        public clsLocalDL_App()
        {
            LocalDLAppID = -1;
            ApplicationID = -1;
            LicenseClassID = 3;
            _application = new clsApplication();
            _licenseClass = new clsLicenseClass();
            _Mode = enMode.AddNew;
        }

        // Factory find
        public static clsLocalDL_App Find(int id, bool includeApplication = false, bool includeLicenseClass = false)
        {
            var dto = clsLocalDLA_DataAccess.GetDTOByID(id);
            return dto == null ? null : new clsLocalDL_App(dto, includeApplication, includeLicenseClass);
        }

        public static clsLocalDL_App FindByBasicAppID(int applicationID, bool includeApplication = false, bool includeLicenseClass = false)
        {
            var dto = clsLocalDLA_DataAccess.GetDTOByBasicAppID(applicationID);
            return dto == null ? null : new clsLocalDL_App(dto, includeApplication, includeLicenseClass);
        }

        // Map to DTO
        private clsLocalDLADTO ToDTO()
        {
            return new clsLocalDLADTO
            {
                LocalDLAppID = this.LocalDLAppID,
                ApplicationID = this.ApplicationID,
                LicenseClassID = this.LicenseClassID
            };
        }

        // ============ Business rules helpers ============
        // Example: validate minimum age according to license class (assumes clsLicenseClass has MinimumAllowedAge property)
        private bool IsApplicantOldEnough()
        {
            if (this.ApplicationInfo == null) return false;
            var personId = this.ApplicationInfo.ApplicantPersonID;
            if (personId <= 0) return false;

            var license = this.LicenseClassInfo ?? clsLicenseClass.Find(this.LicenseClassID);
            if (license == null) return false;

            // license.MinimumAllowedAge assumed int
            var person = clsPerson.Find(personId);
            if (person == null || person.DateOfBirth == DateTime.MinValue) return false;

            var allowedDate = person.DateOfBirth.AddYears(license.MinimumAllowedAge);
            return allowedDate <= DateTime.Now;
        }

        private bool HasActiveDuplicateApplication()
        {
            if (this.ApplicationInfo == null) return false;
            return clsLocalDLA_DataAccess.FindActiveDuplicateApplication(this.ApplicationInfo.ApplicantPersonID, this.LicenseClassID) != -1;
        }

        // ============ Persistence ============
        private bool _AddNew()
        {
            // 1) Save base application first
            var appSaveResult = this.ApplicationInfo.Save();
            if (appSaveResult != clsApplication.SaveResult.Success) return false;

            this.ApplicationID = this.ApplicationInfo.ApplicationID;

            // 2) Validate business rules: age + duplicates
            if (!IsApplicantOldEnough())
                return false;

            if (HasActiveDuplicateApplication())
                return false;

            // 3) Persist local DLA
            var dto = new clsLocalDLADTO
            {
                ApplicationID = this.ApplicationID,
                LicenseClassID = this.LicenseClassID
            };

            this.LocalDLAppID = clsLocalDLA_DataAccess.Add(dto);
            return this.LocalDLAppID != -1;
        }

        private bool _Update()
        {
            // 1) Update base application first
            var appSaveResult = this.ApplicationInfo.Save();
            if (appSaveResult != clsApplication.SaveResult.Success) return false;

            // 2) Validate rules if license class changed etc.
            if (!IsApplicantOldEnough()) return false;

            var dto = ToDTO();
            return clsLocalDLA_DataAccess.Update(dto);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        // Delete must remove local record then base application to avoid orphans
        public static bool Delete(int localDLAppId)
        {
            var dto = clsLocalDLA_DataAccess.GetDTOByID(localDLAppId);
            if (dto == null) return false;

            if (!clsLocalDLA_DataAccess.Delete(localDLAppId)) return false;
            return clsApplication.Delete(dto.ApplicationID);
        }


        // Delete must remove local record then base application to avoid orphans
        public bool Delete()
        {
            if (this.LocalDLAppID <= 0) return false;

            if (!clsLocalDLA_DataAccess.Delete(LocalDLAppID)) return false;
            return clsApplication.Delete(this.ApplicationID);
        }

        public bool Cancel()
        {
            if (this.LocalDLAppID <= 0) return false;
            if (!clsLocalDLA_DataAccess.Exists(this.LocalDLAppID)) return false;
            return this.ApplicationInfo.Cancel();
        }


        public static bool Cancel(int localDLAppId)
        {
            if (localDLAppId <= 0) return false;

            var dto = clsLocalDLA_DataAccess.GetDTOByID(localDLAppId);
            if (dto == null) return false;

            return clsApplication.FindBaseApplication(dto.ApplicationID).Cancel();
        }

        // ============ Queries / Utilities ============
        public static DataTable GetAllAsDataTable() => clsLocalDLA_DataAccess.GetAllAsDataTable();
        public static List<clsLocalDL_App> GetAll(bool includeApplication = false, bool includeLicenseClass = false)
        {
            var dtos = clsLocalDLA_DataAccess.GetAllDTOs();
            var list = new List<clsLocalDL_App>();
            foreach (var dto in dtos)
                list.Add(new clsLocalDL_App(dto, includeApplication, includeLicenseClass));
            return list;
        }

        public static bool Exists(int id) => clsLocalDLA_DataAccess.Exists(id);
        public static bool IsApplicationIDExist(int applicationId) => clsLocalDLA_DataAccess.IsApplicationIDExist(applicationId);
        public static int FindActiveDuplicate(int applicantPersonId, byte? LicenseClassID) => clsLocalDLA_DataAccess.FindActiveDuplicateApplication(applicantPersonId, LicenseClassID);

        // Test-related wrappers
        public bool HasTakenTest(clsTestType.enTestType testType) =>
            clsLocalDLA_DataAccess.HasTakenTest(this.LocalDLAppID, Convert.ToByte(testType));

        public static bool HasTakenTest(int localDLAppId, clsTestType.enTestType testType) =>
            clsLocalDLA_DataAccess.HasTakenTest(localDLAppId, Convert.ToByte(testType));

        public int GetTakenTestCountWithResult(clsTestType.enTestType testType, bool result = true) =>
            clsLocalDLA_DataAccess.GetTakenTestCountWithResult(this.LocalDLAppID, Convert.ToByte(testType), result);

        public static int GetTakenTestCountWithResult(int localDLAppId, clsTestType.enTestType testType, bool result = true) =>
            clsLocalDLA_DataAccess.GetTakenTestCountWithResult(localDLAppId, Convert.ToByte(testType), result);

        public byte GetPassedTestCount() => clsTestsDataAccess.PassedTestsOfLocalDL_AppID(this.LocalDLAppID);
        public static byte PassedTestsOf(int localDLAppId) => clsTestsDataAccess.PassedTestsOfLocalDL_AppID(localDLAppId);
       
        public static bool PassedAllTests(int localDLAppId) => (clsTestsDataAccess.PassedTestsOfLocalDL_AppID(localDLAppId) == 3);
        public bool PassedAllTests() => (clsTestsDataAccess.PassedTestsOfLocalDL_AppID(this.LocalDLAppID) == 3);

        public bool HasActiveAppointment(clsTestType.enTestType testType, bool isActive = true) =>
            clsLocalDLA_DataAccess.HasAppointmentWithTestType(this.LocalDLAppID, Convert.ToByte(testType), isActive);

        public static bool HasActiveAppointment(int localDLAppId, clsTestType.enTestType testType, bool isActive = true) =>
            clsLocalDLA_DataAccess.HasAppointmentWithTestType(localDLAppId, Convert.ToByte(testType), isActive);

        public static bool HasAppointmentInSystem(int localDLAppId) =>
            clsLocalDLA_DataAccess.HasAnyAppointmentInSystem(localDLAppId);

        public bool RelatedWithAppointmentsInSystem() =>
            clsLocalDLA_DataAccess.HasAnyAppointmentInSystem(this.LocalDLAppID);

        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)

        {
            return clsLocalDLA_DataAccess.DoesPassTestType(this.LocalDLAppID, (byte)TestTypeID);
        }
        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDLA_DataAccess.DoesAttendTestType(this.LocalDLAppID, (byte)TestTypeID);
        }

        public bool DoesPassPreviousTest(clsTestType.enTestType CurrentTestType)
        {

            switch (CurrentTestType)
            {
                case clsTestType.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    return true;

                case clsTestType.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.

                    return this.DoesPassTestType(clsTestType.enTestType.VisionTest);


                case clsTestType.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    return this.DoesPassTestType(clsTestType.enTestType.WrittenTest);

                default:
                    return false;
            }
        }


        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDLA_DataAccess.TotalTrialsPerTest(this.LocalDLAppID, (byte)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)

        {
            return clsLocalDLA_DataAccess.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (byte)TestTypeID);
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }

        public int GetActiveLicenseID()
        {//this will get the license id that belongs to this application
            return clsLicenseData.GetActiveLicenseIDByPersonID(this.ApplicationInfo.ApplicantPersonID, this.LicenseClassID);
        }

        public static clsTest FindLastTestByLocalDrivingLicenseApplicaionPerTestType(int LocalDrivingLicenseApplicaionID, clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLastTestByLocalDrivingLicenseApplicaionPerTestType(LocalDrivingLicenseApplicaionID, TestTypeID);
        }

        public clsTest FindLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLastTestByLocalDrivingLicenseApplicaionPerTestType(this.LocalDLAppID, TestTypeID);
        }
        public int IssueLicenseForTheFirtTime(string notes, int createdByUserID)
        {
            if (this.LocalDLAppID <= 0 || createdByUserID <= 0 || !this.PassedAllTests() || this.IsLicenseIssued()) return -1;

            int DriverID = clsDriver.GetDriverIDByPersonID(this.ApplicationInfo.ApplicantPersonID);

            if (DriverID == -1)
            {
                clsDriver NewDriver = new clsDriver
                {
                    PersonID = this.ApplicationInfo.ApplicantPersonID,
                    CreatedByUserID = createdByUserID,
                };

                if(NewDriver.Save() != clsDriver.SaveResult.Success)
                {
                    return -1;
                }

                DriverID = NewDriver.DriverID;
            }


            var newLicense = new clsLicense
            {
                ApplicationID = this.ApplicationInfo.ApplicationID,
                DriverID = DriverID,
                LicenseClassID = this.LicenseClassID,
                IssueDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo != null ? this.LicenseClassInfo.DefaultValidityLength : 1),
                Notes = notes.Trim(),
                PaidFees = this.LicenseClassInfo != null ? this.LicenseClassInfo.ClassFees : 0m,
                IsActive = true,
                IssueReason = clsLicense.enIssueReason.FirstTime,
                CreatedByUserID = createdByUserID
            };

            if (newLicense.Save() != clsLicense.enSaveResult.Success) return -1;

            if (!this.ApplicationInfo.SetComplete()) return -1;

            return newLicense.LicenseID;
        }
    }
}
