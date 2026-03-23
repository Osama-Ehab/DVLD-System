using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.ExtensionsClasses;
using DVLD_UiLayer.HelperClasses;

namespace DVLD_UiLayer
{
    public partial class ctrLocalDriverLicenseCard : UserControl
    {
        private clsLicense _License;
        private int _LicenseID { get; set; }
        private clsPerson _Person;

        public int LicenseID => _LicenseID;
        public clsLicense SelectedLicenseInfo => _License;

        public ctrLocalDriverLicenseCard()
        {
            InitializeComponent();
            _LicenseID = -1;
        }

        public void LoadLicenseInfo(int licenseID)
        {
            if (licenseID <= 0)
            {
                clsMessageService.ShowValidationError("Invalid License LicenseID.");
                ResetDefaultData();
                return;
            }

            _License = clsLicense.Find(licenseID);
            if (_License == null)
            {
                clsMessageService.ShowError($"No License found with LicenseID = {licenseID}");
                ResetDefaultData();
                return;
            }

            _LoadLicenseInfoAfterFind();
        }

        public void LoadLicenseInfoByApplicationID(int applicationID)
        {
            if (applicationID <= 0)
            {
                clsMessageService.ShowValidationError("Invalid Application LicenseID.");
                ResetDefaultData();
                return;
            }

            _License = clsLicense.FindByApplicationID(applicationID);
            if (_License == null)
            {
                clsMessageService.ShowError($"No License found for Application LicenseID = {applicationID}");
                ResetDefaultData();
                return;
            }

            _LoadLicenseInfoAfterFind();
        }

        public void LoadLicenseInfoByLocalDL_AppID(int localDL_AppID)
        {
            if (localDL_AppID <= 0)
            {
                clsMessageService.ShowValidationError("Invalid Local Driving License Application LicenseID.");
                ResetDefaultData();
                return;
            }

            var localApp = clsLocalDL_App.Find(localDL_AppID);
            int applicationID = localApp?.ApplicationID ?? -1;

            if (applicationID == -1)
            {
                clsMessageService.ShowError($"No Application found for Local Driving License App LicenseID = {localDL_AppID}");
                ResetDefaultData();
                return;
            }

            _License = clsLicense.FindByApplicationID(applicationID);
            if (_License == null)
            {
                clsMessageService.ShowError($"No License found for Local Driving License App LicenseID = {localDL_AppID}");
                ResetDefaultData();
                return;
            }

            _LoadLicenseInfoAfterFind();
        }

        private void _LoadLicenseInfoAfterFind()
        {
            if (_License == null)
            {
                clsMessageService.ShowError("License information is missing.");
                ResetDefaultData();
                return;
            }

            _Person = _License.DriverInfo.PersonInfo;
            if (_Person == null)
            {
                clsMessageService.ShowError("Person information is missing.");
                ResetDefaultData();
                return;
            }

            _LicenseID = _License.LicenseID;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblLicenseClass.Text = _License.LicenseClassInfo.ClassName;
            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblGender.Text = (_Person.Gender == 0) ? "Male" : "Female";
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = string.IsNullOrEmpty(_License.Notes) ? "No Notes." : _License.Notes;
            lblDateOfBirth.Text = _Person.DateOfBirth.DateToShort();
            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = _License.IssueDate.DateToShort();
            lblExpirationDate.Text = _License.ExpirationDate.DateToShort();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";

            _LoadPersonImage();
        }

        private void ctrDriverLicenseCard_Load(object sender, EventArgs e)
        {
            if (_License != null)
                LoadLicenseInfo(_License.LicenseID);
        }

        private void _LoadPersonImage()
        {
            if (_Person == null)
            {
                pbProfilePicture.Image = ImageResources.Male_512;
                return;
            }

            if (string.IsNullOrWhiteSpace(_Person.ImagePath))
                pbProfilePicture.Image = (_Person.Gender == 0) ? ImageResources.Male_512 : ImageResources.Female_512;
            else
                clsImages.LoadImageIntoPictureBox(_Person.ImagePath, pbProfilePicture);
        }

        public void ResetDefaultData()
        {
            _LicenseID = -1;
            lblLicenseID.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblIssueReason.Text = "[????]";
            lblNotes.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblLicenseClass.Text = "[????]";
            lblIsDetained.Text = "[????]";
            lblIsActive.Text = "[????]";
            pbProfilePicture.Image = ImageResources.Male_512;
        }
    }
}
