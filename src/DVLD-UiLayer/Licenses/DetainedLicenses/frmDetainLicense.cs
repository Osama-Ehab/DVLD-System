using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.ExtensionsClasses;
using DVLD_UiLayer.Licenses;
using DVLD_UiLayer.UserControls;
using DVLD_UiLayer.HelperClasses; // for clsMessageService

namespace DVLD_UiLayer
{
    public partial class frmDetainLicense : Form
    {
        public Action<int> SendDetainID;

        public delegate void delRefreshManageDetainedLicensesList();
        public event delRefreshManageDetainedLicensesList RefreshManageDetainedLicensesList;

        private enum enMode { AddNew, Update }
        private enMode _Mode;
        private int _DetainID = -1;
        private clsLicense _SelectedLicenseInfo;

        public frmDetainLicense(int DetainID = -1)
        {
            InitializeComponent();

            _DetainID = DetainID;
            _Mode = (DetainID == -1) ? enMode.AddNew : enMode.Update;

        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            DetainLicenseInfoCard.lblDetainDate.Text = DateTime.Now.DateToShort();
            DetainLicenseInfoCard.lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            LocalDriverLicenseCardWithFilter.FilterEnabled = btnDetain.Enabled = (_Mode == enMode.AddNew);
        }

        private void GetAnotherActiveLicenseID()
        {
            if (_SelectedLicenseInfo == null) return;

            int activeLicenseID = clsLicense.GetActiveLicenseIDByPersonID(_SelectedLicenseInfo.DriverInfo.PersonID, _SelectedLicenseInfo.LicenseClassID);

            if (activeLicenseID == -1) return;

            bool confirmFetch = clsMessageService.Confirm(
                $"Another active license exists with LicenseID = {activeLicenseID} for the same Person and license class. Do you want to fetch it?",
                "Active License Found"
            );

            if (confirmFetch)
                LocalDriverLicenseCardWithFilter.LoadLicenseInfo(activeLicenseID);
        }

        private void SaveUpdates()
        {
            // Guard Clauses
            if (_SelectedLicenseInfo == null)
            {
                clsMessageService.ShowError("No license selected. Please choose a valid license first.");
                return;
            }

            if (!decimal.TryParse(DetainLicenseInfoCard.txtFineFees.Text.Trim(), out decimal fineFees))
            {
                clsMessageService.ShowValidationError("Please enter a valid fine amount.");
                return;
            }

            if (fineFees < 0)
            {
                clsMessageService.ShowValidationError("Fine amount cannot be negative.");
                return;
            }

            if (_Mode != enMode.AddNew) return;

            _DetainID = _SelectedLicenseInfo.Detain(fineFees, clsGlobal.CurrentUser.UserID);

            if (_DetainID == -1)
            {
                clsMessageService.ShowError("Failed to save data. Please try again.");
                return;
            }

            _RefereshAfterSave();
        }

        private void _RefereshAfterSave()
        {
            RefreshManageDetainedLicensesList?.Invoke();
            SendDetainID?.Invoke(_DetainID);

            clsMessageService.ShowSuccess($"License detained successfully with Detain ID = {_DetainID}", "Saved");

            _Mode = enMode.Update;
            btnDetain.Enabled =
                LocalDriverLicenseCardWithFilter.FilterEnabled =
                DetainLicenseInfoCard.txtFineFees.Enabled = false;

            DetainLicenseInfoCard.LoadDetainedLicenseInfo(_DetainID);
            LocalDriverLicenseCardWithFilter.LoadLicenseInfo(_SelectedLicenseInfo.LicenseID);
        }

        private void frmDetainLicenseApplication_Activated(object sender, EventArgs e)
        {
            LocalDriverLicenseCardWithFilter.txtLicenseIDFocus();
        }

        private void txtNumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (clsMessageService.Confirm("Are you sure you want to close the form and ignore changes?", "Confirm Close"))
                Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure you want to save updates?", "Confirm Save"))
                return;

            if (!ValidateChildren())
            {
                clsMessageService.ShowValidationError("Cannot save data because some required fields are empty or invalid.");
                return;
            }

            SaveUpdates();
        }

        private void SelectedLocalDriverLicense_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode != enMode.Update)
                e.Cancel = LocalDriverLicenseCardWithFilter.LocalDriverLicenseCard.LicenseID == -1;
        }

        private void linklblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int DriverID = LocalDriverLicenseCardWithFilter.LocalDriverLicenseCard.SelectedLicenseInfo.DriverID;

            if (DriverID == -1)
            {
                clsMessageService.ShowError("Unable to retrieve driver history. Invalid Driver LicenseID.");
                return;
            }

            var frm = new frmShowPersonLicenseHistory(DriverID);
            frm.ShowDialog();
        }

        private void DetainLicenseInfoCard_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrWhiteSpace(DetainLicenseInfoCard.txtFineFees.Text);
        }

        private void LocalDriverLicenseCardWithFilter_LicenseSelected(object sender, EventArgsClasses.LicenseEventArgs e)
        {
            
            _SelectedLicenseInfo = e.License;

            if (_SelectedLicenseInfo == null)
            {
                clsMessageService.ShowError("License information could not be retrieved.");
                return;
            }


            DetainLicenseInfoCard.lblLicenseID.Text = _SelectedLicenseInfo.LicenseID != -1 ? _SelectedLicenseInfo.LicenseID.ToString() : "[???]";
            DetainLicenseInfoCard.linklblShowLicenseInfo.Enabled = (_SelectedLicenseInfo.LicenseID != -1);

            if (_SelectedLicenseInfo.LicenseID == -1) return;
            if (LocalDriverLicenseCardWithFilter.LocalDriverLicenseCard.SelectedLicenseInfo == null) return;

            // Guard Clauses for invalid license states

            if (_SelectedLicenseInfo.IsDetained)
            {
                clsMessageService.ShowError("Local Driving License is already detained.");
                return;
            }

            if (!_SelectedLicenseInfo.IsActive)
            {
                clsMessageService.ShowWarning("Local Driving License is not active.");
                GetAnotherActiveLicenseID();
                return;
            }

            DetainLicenseInfoCard.txtFineFees.Focus();
            btnDetain.Enabled = true;
        }
    }
}
