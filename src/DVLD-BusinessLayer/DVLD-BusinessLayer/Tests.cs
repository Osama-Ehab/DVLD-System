using System;
using System.Data;
using DVLD_DataAccessLayer;
using DVLD_DataAccessLayer.DTOs;

namespace DVLD_BusinessLayer
{
    public class clsTest
    {
        private enum enMode { AddNew, Update }
        private enMode _mode = enMode.AddNew;
        public enum SaveResult
        {
            Success,
            ValidationFailed,
            DbError
        }

        public int TestID { get; private set; }
        public int TestAppointmentID { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public bool TestResult { get; set; }

        private clsTestAppointment _testAppointment;

        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            Notes = string.Empty;
            CreatedByUserID = 0;
            TestResult = false;
            _mode = enMode.AddNew;
        }

        private clsTest(clsTestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            TestID = dto.TestID;
            TestAppointmentID = dto.TestAppointmentID;
            Notes = dto.Notes;
            CreatedByUserID = dto.CreatedByUserID;
            TestResult = dto.TestResult;

            _mode = enMode.Update;
        }

        #region Lazy Loading
        public clsTestAppointment TestAppointment
        {
            get
            {
                if (_testAppointment == null && TestAppointmentID > 0)
                    _testAppointment = clsTestAppointment.Find(TestAppointmentID);
                return _testAppointment;
            }
        }
        #endregion

        #region DTO Mapping
        private clsTestDTO ToDTO() =>
            new clsTestDTO
            {
                TestID = this.TestID,
                TestAppointmentID = this.TestAppointmentID,
                Notes = this.Notes,
                CreatedByUserID = this.CreatedByUserID,
                TestResult = this.TestResult
            };
        #endregion

        #region CRUD
        private bool AddNew()
        {
            if (TestAppointmentID <= 0 || CreatedByUserID <= 0)
                return false;

            var dto = ToDTO();
            int newId = clsTestsDataAccess.AddNewTest(dto);

            if (newId == -1) return false;

            TestID = newId;
            _mode = enMode.Update;
            return true;
        }

        private bool Update()
        {
            if (TestID <= 0) return false;

            var dto = ToDTO();
            return clsTestsDataAccess.UpdateTest(dto);
        }

        public SaveResult Save()
        {
            if (TestAppointmentID <= 0 || CreatedByUserID <= 0)
                return SaveResult.ValidationFailed;

            bool isSuccess = (_mode == enMode.AddNew) ? AddNew() : (_mode == enMode.Update ? Update() : false);

            return isSuccess ? SaveResult.Success : SaveResult.DbError;
        }


        public static bool Delete(int testID)
        {
            if (testID <= 0) return false;
            return clsTestsDataAccess.DeleteTest(testID);
        }

        public static clsTest Find(int testID)
        {
            if (testID <= 0) return null;

            var dto = clsTestsDataAccess.Find(testID);
            return dto != null ? new clsTest(dto) : null;
        }
        public static clsTest FindLastTestByLocalDrivingLicenseApplicaionPerTestType(int LocalDrivingLicenseApplicaionID,clsTestType.enTestType TestTypeID)
        {
            if ((LocalDrivingLicenseApplicaionID <= 0) || ((byte)TestTypeID <= 0)) return null;

            var dto = clsTestsDataAccess.GetLastTestByLocalDrivingLicenseApplicaionPerTestType(new clsTestAppointmentDTO{ LocalDLAppID = LocalDrivingLicenseApplicaionID,TestTypeID = (byte)TestTypeID } );
            return dto != null ? new clsTest(dto) : null;
        }

        public static DataTable GetAll() => clsTestsDataAccess.GetAllTests();

        public static bool IsExist(int testID) => clsTestsDataAccess.IsTestExist(testID);

        public static bool IsTestAppointmentExist(int testAppointmentID) =>
            clsTestsDataAccess.IsTestAppointmentExist(testAppointmentID);


        public byte GetPassedTestCount() => clsTestsDataAccess.PassedTestsOfLocalDL_AppID(this.TestAppointment.LocalDrivingLicenseApplicationID);
        public static byte PassedTestsOf(int LocalDrivingLicenseApplicationID) => clsTestsDataAccess.PassedTestsOfLocalDL_AppID(LocalDrivingLicenseApplicationID);

        public static bool HasPassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return clsTestsDataAccess.PassedTestsOfLocalDL_AppID(LocalDrivingLicenseApplicationID) == 3;
        }

        public  bool HasPassedAllTests()
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return clsTestsDataAccess.PassedTestsOfLocalDL_AppID(this.TestAppointment.LocalDrivingLicenseApplicationID) == 3;
        }
        #endregion
    }


}

