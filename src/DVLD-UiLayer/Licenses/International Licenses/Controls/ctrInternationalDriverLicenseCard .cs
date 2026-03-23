using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using System.ComponentModel.DataAnnotations;
using DVLD_UiLayer.ExtensionsClasses;


namespace DVLD_UiLayer
{
    public partial class ctrInternationalDriverLicenseCard : UserControl
    {
        //public event EventHandler InternationalLicenseIsNotFound
        public enum enGender : byte { Male, Female }
        public enum enAnswer : byte { No, Yes }
    
        private clsInternationalLicense _InternationalLicense;
        private int _InternationalLicenseID {  get; set; }
        public int InternationalLicenseID { get { return _InternationalLicenseID; } }
        
        private clsPerson _Person;
        
        public ctrInternationalDriverLicenseCard()
        {
            InitializeComponent();
            _InternationalLicenseID = -1;
        }


        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            this._InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);
            if (this._InternationalLicense != null)
            { _LoadInternationalLicenseInfoAfterFind(); }
            else
            {
                _LoadDefaultData();
            }

        }

        public void LoadInternationalLicenseInfoByID(int ID)
        {
            this._InternationalLicense = clsInternationalLicense.Find(ID);
            if (this._InternationalLicense != null)
            { _LoadInternationalLicenseInfoAfterFind(); }
            else
            {
                MessageBox.Show($"No International License with Application InternationalDL_AppID  = {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LoadDefaultData();
            }
        }
        public void LoadInternationalLicenseInfoByInternationalDL_AppID(int InternationalDL_AppID)
        {
            this._InternationalLicense = clsInternationalLicense.FindByApplicationID(InternationalDL_AppID);
            if (this._InternationalLicense != null)
            { _LoadInternationalLicenseInfoAfterFind(); }
            else
            {
                MessageBox.Show($"No International License with Application InternationalDL_AppID  = {InternationalDL_AppID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LoadDefaultData();
            }
        }


        private void _LoadInternationalLicenseInfoAfterFind()
        {
            if (this._InternationalLicense != null)
            {

                _Person = clsPerson.Find(clsDriver.FindByDriverID(_InternationalLicense.DriverID).PersonID);
                if (this._Person != null)
                {
                    _InternationalLicenseID = this._InternationalLicense.InternationalLicenseID;
                    lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                    lblName.Text = _Person.FullName.ToString();
                    lblNationalNo.Text = _Person.NationalNo.ToString();
                    lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();

                    if (Enum.IsDefined(typeof(enGender), _Person.Gender))
                    {
                        lblGender.Text = ((enGender)_Person.Gender).ToString();
                    }

                    lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                    lblDateOfBirth.Text = _Person.DateOfBirth.DateToShort();
                    lblDriverID.Text = _InternationalLicense.DriverID.ToString();
                    lblIssueDate.Text = _InternationalLicense.IssueDate.DateToShort();
                    lblExpirationDate.Text = _InternationalLicense.ExpirationDate.DateToShort();
                    lblIsActive.Text = ((enAnswer)(_InternationalLicense.IsActive?1:0)).ToString();

                    if (_Person.ImagePath != "")
                        clsImages.LoadImageIntoPictureBox(_Person.ImagePath, pbProfilePicture);
                    else
                    {
                        if ((enGender)_Person.Gender == 0)
                            pbProfilePicture.Image = ImageResources.Male_512;
                        else
                            pbProfilePicture.Image = ImageResources.Female_512;
                    }
                }
            }
        }
        private void ctrDriverInternationalLicenseCard_Load(object sender, EventArgs e)
        {
            if (_InternationalLicense != null) { LoadInternationalLicenseInfo(_InternationalLicense.InternationalLicenseID); }
        }
        
        private void  _LoadDefaultData()
        {
            lblInternationalLicenseID.Text = "[????]";
            lblInternationalLicenseID.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblApplicationID.Text = "[????]";
            pbProfilePicture.Image = ImageResources.Male_512;
        }

    
    }
}
