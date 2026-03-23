using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_UiLayer
{
    public partial class ctrPersonCard : UserControl
    {
        //public event EventHandler PersonIsNotFound
        public enum enGender : byte { Male, Female }
        private clsPerson _Person { get; set; }
        private int _PersonID {  get; set; }
        public int PersonID { get { return _PersonID; } }
        public clsPerson SelectedPerson { get { return _Person; } }
        
        public ctrPersonCard()
        {
            InitializeComponent();
            _PersonID = -1;
        }


        public void LoadPersonInfo(int PersonID)
        {
            this._Person = clsPerson.Find(PersonID);
            if (this._Person != null)
            { _LoadPersonInfoAfterFind(); }
            else
            {
                ResetDefaultData();
            }

        }

        public void LoadPersonInfo(string NationalNo)
        {
            this._Person = clsPerson.Find(NationalNo);
            if (this._Person != null)
            { _LoadPersonInfoAfterFind(); }
            else
            {
                MessageBox.Show($"No Person with National No = {NationalNo}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultData();
            }
        }

        private void _LoadPersonImage()
        {
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

        private void _LoadPersonInfoAfterFind()
        {
            if (this._Person != null)
            {
                _PersonID = this._Person.ID;
                lblPersonID.Text = _Person.ID.ToString();
                lblName.Text = _Person.FullName.ToString();
                lblNationalNo.Text = _Person.NationalNo.ToString();
                if (Enum.IsDefined(typeof(enGender), _Person.Gender))
                {
                    lblGender.Text = ((enGender)_Person.Gender).ToString();
                }
                lblEmail.Text = _Person.Email?.ToString();
                lblAddress.Text = _Person.Address?.ToString();
                lblDateOfBirth.Text = _Person.DateOfBirth.ToString("yyyy-MM-dd");
                lblPhone.Text = _Person.Phone.ToString();
                lblCountry.Text = clsCountries.Find(_Person.NationalityCountryID).CountryName?.ToString();
                _LoadPersonImage();
                linklblEditPerson.Enabled = true;
            }
        }

        private void linklblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Person != null)
            {
                frmAddEditPerson EditPerson = new frmAddEditPerson(_Person.ID);
                EditPerson.RefreshPersonDetails += ctrPersonCard_Load;
                EditPerson.ShowDialog();
            }
        }
        private void ctrPersonCard_Load(object sender, EventArgs e)
        {
            if (_Person != null) { LoadPersonInfo(_Person.ID); }
        }
        
        public void  ResetDefaultData()
        {
            lblPersonID.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblAddress.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblPhone.Text = "[????]";
            lblCountry.Text = "[????]";
            pbProfilePicture.Image = ImageResources.Male_512;
            linklblEditPerson.Enabled = false;
        }

    }
}
