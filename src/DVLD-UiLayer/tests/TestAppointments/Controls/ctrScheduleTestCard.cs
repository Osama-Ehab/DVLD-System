using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer;
using DVLD_UiLayer.HelperClasses; 


namespace DVLD_UiLayer.UserControls
{
    public partial class ctrlScheduleTest : UserControl
    {

        public delegate void ReloadLocalDL_AppsData();
        public event ReloadLocalDL_AppsData ReloadData;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsLocalDL_App _LocalDrivingLicenseApplication;
        private clsTestAppointment _TestAppointment;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _TestAppointmentID = -1;

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }

        public clsTestType.enTestType TestTypeID
        {
            get => _TestTypeID;
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        gbTestType.Text = "Vision Test";
                        pbTestTypeImage.Image = ImageResources.Vision_512;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        gbTestType.Text = "Written Test";
                        pbTestTypeImage.Image = ImageResources.Written_Test_512;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        gbTestType.Text = "Street Test";
                        pbTestTypeImage.Image = ImageResources.driving_test_512;
                        break;
                }
            }
        }

        public void LoadInfo(int localDLAppId, int appointmentId = -1)
        {
            _Mode = (appointmentId == -1) ? enMode.AddNew : enMode.Update;
            _LocalDrivingLicenseApplicationID = localDLAppId;
            _TestAppointmentID = appointmentId;
            _LocalDrivingLicenseApplication = clsLocalDL_App.Find(localDLAppId);

            if (_LocalDrivingLicenseApplication == null)
            {
                clsMessageService.ShowError($"No Local Driving License Application found with DriverID = {localDLAppId}");
                btnSave.Enabled = false;
                return;
            }

            SetCreationMode();
            SetApplicationInfoLabels();

            if (_Mode == enMode.AddNew)
            {
                PrepareAddNewMode();
                if (!_HandleActiveTestAppointmentConstraintInAddNewMode()) return;
            }
            else
            {
                if (!_LoadTestAppointmentData()) return;
                if (!_HandleAppointmentLockedConstraintInUpdateMode()) return;
            }

            lblTotalFees.Text = (Convert.ToDecimal(lblTestFees.Text) + Convert.ToDecimal(lblRetakeAppFees.Text)).ToString();

            if (!_HandlePreviousTestConstraint()) return;
        }

        private void SetCreationMode()
        {
            bool hasAttended = _LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID);
            _CreationMode = hasAttended ? enCreationMode.RetakeTestSchedule : enCreationMode.FirstTimeSchedule;

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRetakeAppFees.Text = clsApplicationType.Find((byte)clsApplication.enApplicationType.RetakeTest).Fees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "0";
                return;
            }

            gbRetakeTestInfo.Enabled = false;
            lblTitle.Text = "Schedule Test";
            lblRetakeAppFees.Text = "0";
            lblRetakeTestAppID.Text = "N/A";
        }

   
        private void SetApplicationInfoLabels()
        {
            lblLocalDL_AppID.Text = _LocalDrivingLicenseApplication.LocalDLAppID.ToString();
            lblLicenseClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblApplicantName.Text = _LocalDrivingLicenseApplication.ApplicationInfo.ApplicantFullName;
            lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();
        }

        private void PrepareAddNewMode()
        {
            lblTestFees.Text = clsTestType.Find(_TestTypeID).Fees.ToString();
            dtpTestDate.MinDate = DateTime.Now;
            lblRetakeTestAppID.Text = "N/A";
            _TestAppointment = new clsTestAppointment();
        }

        private bool _HandleActiveTestAppointmentConstraintInAddNewMode()
        {
            bool hasActive = clsLocalDL_App.HasActiveAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID);
            if (!hasActive) return true;

            return DenyScheduling("Person already has an active appointment for this test.");

        }

        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                clsMessageService.ShowError($"No Appointment found with DriverID = {_TestAppointmentID}");
                btnSave.Enabled = false;
                return false;
            }

            lblTestFees.Text = _TestAppointment.PaidFees.ToString();
            dtpTestDate.MinDate = DateTime.Now < _TestAppointment.AppointmentDate
                ? DateTime.Now
                : _TestAppointment.AppointmentDate;
            dtpTestDate.Value = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestAppID == -1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
                return true;
            }

            lblRetakeAppFees.Text = _TestAppointment.RetakeTestAppInfo.PaidFees.ToString("00,00");
            //gbRetakeTestInfo.Enabled = true;
            lblTitle.Text = "Schedule Retake Test";
            lblRetakeTestAppID.Text = _TestAppointment.RetakeTestAppID.ToString();
            lblTotalFees.Text = (_TestAppointment.RetakeTestAppInfo.PaidFees + _TestAppointment.PaidFees).ToString("00,00");
            return true;
        }

        private bool _HandleAppointmentLockedConstraintInUpdateMode()
        {
            if (!_TestAppointment.IsLocked) return true;

            return DenyScheduling("Person already sat for the test, appointment locked.");
        }

        private bool _HandlePreviousTestConstraint()
        {

            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    break;
                case clsTestType.enTestType.WrittenTest:
                    if(!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest))
                    {
                        return DenyScheduling("Cannot schedule, Vision Test must be passed first.");
                    }
                    break;

                case clsTestType.enTestType.StreetTest:
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest))
                    {
                        return DenyScheduling("Cannot schedule, Written Test must be passed first.");
                    }
                    break;

                default:
                    clsMessageService.ShowError("Unknown test type.");
                    return false;
            }

            ResetLockState();
            return true;
        }

        private bool DenyScheduling(string message)
        {
            lblLockedMessage.Text = message;
            lblLockedMessage.Visible = true;
            btnSave.Enabled = false;
            dtpTestDate.Enabled = false;
            return false;
        }

        private void ResetLockState()
        {
            lblLockedMessage.Visible = false;
            btnSave.Enabled = true;
            dtpTestDate.Enabled = true;
        }


        private bool _HandleRetakeApplication()
        {
            bool needsRetakeApp = _Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule;
            if (!needsRetakeApp) return true;

            var application = new clsApplication
            {
                ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicationInfo.ApplicantPersonID,
                ApplicationTypeID = (byte)clsApplication.enApplicationType.RetakeTest,
                ApplicationStatus = clsApplication.enApplicationStatus.Completed,
                PaidFees = clsApplicationType.Find((byte)clsApplication.enApplicationType.RetakeTest).Fees,
                CreatedByUserID = clsGlobal.CurrentUser.UserID
            };

            if (application.Save() != clsApplication.SaveResult.Success)
            {
                _TestAppointment.RetakeTestAppID = -1;
                clsMessageService.ShowError("Failed to create retake test application.");
                return false;
            }

            _TestAppointment.RetakeTestAppID = application.ApplicationID;
            return true;
        }

        private void FillTestAppointmentObject()
        {
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDLAppID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToDecimal(lblTestFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure you want to save updates?", "Confirm"))
                return;

            if (!_HandleRetakeApplication()) return;

            FillTestAppointmentObject();

            var result = _TestAppointment.Save();
            if (result != clsTestAppointment.SaveResult.Success)
            {
                clsMessageService.ShowError("Error: Data not saved successfully.");
                return;
            }

            btnSave.Enabled = false;
            lblRetakeTestAppID.Text = (_TestAppointment.RetakeTestAppID == -1)? "N/A" : _TestAppointment.RetakeTestAppID.ToString();
            _Mode = enMode.Update;
            clsMessageService.ShowSuccess("Data saved successfully.");
            ReloadData.Invoke();
        }
    }
}
