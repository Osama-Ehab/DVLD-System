using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.HelperClasses;

namespace DVLD_UiLayer.Licenses
{
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {
        public EventHandler RefreshManageLocalDL_AppsList;

        private clsLocalDL_App _LocalDrivingLicenseApplication;
        private int _LocalDL_AppID { get; set; }

        public frmIssueDriverLicenseForTheFirstTime(int localDL_AppID)
        {
            InitializeComponent();
            _LocalDL_AppID = localDL_AppID;
        }

        private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            txtNotes.Focus();

            _LocalDrivingLicenseApplication = clsLocalDL_App.Find(_LocalDL_AppID);

            // 🛡 Guard Clause: Application not found
            if (_LocalDrivingLicenseApplication == null)
            {
                clsMessageService.ShowError($"No Application found with LicenseID = {_LocalDL_AppID}", "Not Allowed");
                Close();
                return;
            }

            // 🛡 Guard Clause: Not passed all tests
            if (!_LocalDrivingLicenseApplication.PassedAllTests())
            {
                clsMessageService.ShowError("Person should pass all required tests first.", "Not Allowed");
                Close();
                return;
            }

            // 🛡 Guard Clause: Already has active license
            int licenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();
            if (licenseID != -1)
            {
                clsMessageService.ShowError($"Person already has an active license (License LicenseID = {licenseID})", "Not Allowed");
                Close();
                return;
            }

            LocalDL_AppCard.LoadLocalDL_AppInfo(_LocalDL_AppID);
        }

        private void SaveUpdates()
        {
            // 🛡 Guard Clause: No valid application loaded
            if (_LocalDrivingLicenseApplication == null)
            {
                clsMessageService.ShowError($"No Application found with LicenseID = {_LocalDL_AppID}", "Not Allowed");
                Close();
                return;
            }

            int newLicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirtTime
            (
                txtNotes.Text.Trim(),
                clsGlobal.CurrentUser.UserID
            );

            // 🛡 Guard Clause: License issue failed
            if (newLicenseID == -1)
            {
                clsMessageService.ShowError("Failed to issue driving license for the first time.", "Error");
                return;
            }

            clsMessageService.ShowSuccess($"License issued successfully with License LicenseID = {newLicenseID}", "Succeeded");

            RefreshManageLocalDL_AppsList?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure you want to issue this license?", "Confirm"))
                return;

            // 🛡 Guard Clause: Validation failed
            if (!ValidateChildren())
            {
                clsMessageService.ShowValidationError("Data not saved successfully. Some required fields are empty.");
                return;
            }

            SaveUpdates();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            // 🛡 Confirmation before closing
            if (!clsMessageService.Confirm("Are you sure you want to close this form without saving changes?", "Confirm Close"))
                return;
           
            
            Close();
        }
    }
}
