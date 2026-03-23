using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.Tests.TestAppointments.Controls;

namespace DVLD_UiLayer.Tests.TestAppointments
{
    public partial class frmTakeTest : Form
    {
        public delegate void ReloadLocalDL_AppsData();
        public event ReloadLocalDL_AppsData ReloadData;

        private clsTestType.enTestType _TestTypeID { get; set; }
        private clsTest _Test;
        private int _TestAppointmentID { get; set; }
        private int _TestID { get; set; }

        public int TestID => _TestID;

        public frmTakeTest(int testAppointmentID, clsTestType.enTestType testTypeID)
        {
            InitializeComponent();
            _TestAppointmentID = testAppointmentID;
            _TestTypeID = testTypeID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadTestAppointmentInfo();
        }

        private void _LoadTestAppointmentInfo()
        {
            // 🛡 Guard Clauses
            if (_TestAppointmentID <= 0)
            {
                clsMessageService.ShowError("Invalid Test Appointment DriverID.");
                btnSave.Enabled = false;
                return;
            }

            ctrScheduledTestCard1.TestTypeID = _TestTypeID;
            ctrScheduledTestCard1.LoadInfo(_TestAppointmentID);

            _TestID = ctrScheduledTestCard1.TestID;

            if (_TestID == -1)
            {
                btnSave.Enabled = true;
                return;
            }

            _Test = clsTest.Find(_TestID);

            if (_Test == null)
            {
                return;
            }

            rbFail.Checked = !(rbPass.Checked = _Test.TestResult);
            txtNotes.Text = _Test.Notes;
            lblUserMessage.Visible = true;
            rbFail.Enabled = false;
            rbPass.Enabled = false;
        }

        private void _FillTestObj()
        {
            _Test = new clsTest
            {
                TestAppointmentID = _TestAppointmentID,
                TestResult = rbPass.Checked,
                CreatedByUserID = clsGlobal.CurrentUser?.UserID ?? -1,
                Notes = txtNotes.Text.Trim()
            };
        }

        private void SaveUpdates()
        {
            // 🛡 Guard Clause
            if (_TestAppointmentID <= 0)
            {
                clsMessageService.ShowError("Invalid Test Appointment DriverID.");
                return;
            }

            _FillTestObj();

            var saveResult = _Test.Save();
            if (saveResult != clsTest.SaveResult.Success)
            {
                clsMessageService.ShowError("Data was not saved successfully.");
                return;
            }
            _TestID = _Test.TestID;
            ctrScheduledTestCard1.lblTestID.Text = _TestID.ToString();
            ReloadData?.Invoke();
            clsMessageService.ShowSuccess("Data saved successfully.");
            btnSave.Enabled = false;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure you want to save updates?", "Confirm"))
                return;

            if (!ValidateChildren())
            {
                clsMessageService.ShowValidationError(
                    "Data not saved. One or more required fields are empty or invalid."
                );
                return;
            }

            SaveUpdates();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure you want to close the form and ignore changes?", "Confirm"))
                return;

            Close();
        }
    }
}
