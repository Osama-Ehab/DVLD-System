using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD_UiLayer
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void delSendPersonID(int PersonID);

        public event delSendPersonID SendPersonID;

        public event EventHandler RefreshPersonDetails;

        public delegate void delRefreshManagePeopleList();

        public event delRefreshManagePeopleList RefreshManagePeopleList;
        enum enMode { AddNew, Update }
        private enMode _Mode;
        private int _PersonID;
        public string _SelectedImagePath { get; set; }
        private clsPerson _Person;
        public frmAddEditPerson(int PersonID = -1)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = (PersonID == -1) ? enMode.AddNew : enMode.Update;
        }

        private void FrmAddEditPerson_Load(object sender, EventArgs e)
        {

            LoadData();
        }

        private void _FillAllCountriesInCb()
        {
            DataTable CountriesDataTable = frmMain.CountriesDataTable;
            if (CountriesDataTable != null)
            {
                foreach (DataRow Row in CountriesDataTable.Rows)
                {
                    cbCountry.Items.Add(Row["CountryName"]);
                }
            }
        }

        private void LoadData()
        {
            _FillAllCountriesInCb();
            cbCountry.SelectedIndex = 0;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
                cbCountry.SelectedItem = "Egypt";
                rbMale.Checked = true;
                return;
            }


            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"This from will be closed because there is no Person with ID = {_PersonID}");
                this.Close();
                return;
            }

            lblMode.Text = "Update Person";
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;
            mtxtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (_Person.ImagePath != "")
            {
                _SelectedImagePath = _Person.ImagePath;
                clsImages.LoadImageIntoPictureBox(_SelectedImagePath, pbProfilePicture);
            }

            llRemoveImage.Visible = (_Person.ImagePath != "");

            cbCountry.SelectedIndex = cbCountry.FindString(clsCountries.Find(_Person.NationalityCountryID).CountryName);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to close form And ignore changes?", "Confirmed", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to save Updates?", "Confirmed", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (this.ValidateChildren())
                {
                    SaveUpdates();
                }
                else
                    MessageBox.Show("Data not Saved Successfully,Couse there is field(s) Empty or Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveUpdates()
        {
            int CountryID = clsCountries.Find(cbCountry.Text).ID;

            _Person.NationalityCountryID = CountryID;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            if (rbMale.Checked)
                _Person.Gender = 0;
            else
                _Person.Gender = 1;

            _Person.Email = txtEmail.Text;
            _Person.Phone = mtxtPhone.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value.Date;

            bool hasOldImage = !string.IsNullOrEmpty(_Person.ImagePath);
            bool hasNewImage = !string.IsNullOrEmpty(_SelectedImagePath);

            if (!hasOldImage && hasNewImage)
            {
                // New image selected; no previous image
                _Person.ImagePath = clsImages.SaveImage(_SelectedImagePath);
            }
            else if (hasOldImage && !hasNewImage)
            {
                // Old image exists, but user removed the image
                clsImages.RemoveImage(_Person.ImagePath, pbProfilePicture);
                _Person.ImagePath = "";
            }
            else if (hasOldImage && hasNewImage && _Person.ImagePath != _SelectedImagePath)
            {
                // User replaced the existing image with a new one
                clsImages.RemoveImage(_Person.ImagePath, pbProfilePicture);
                _Person.ImagePath = clsImages.SaveImage(_SelectedImagePath);
            }
            if (_Person.Save())
            {
                RefreshPersonDetails?.Invoke(this, EventArgs.Empty);
                RefreshManagePeopleList?.Invoke();
                SendPersonID?.Invoke(_Person.ID);
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK);
                if (_Person.ImagePath != "")
                    clsImages.LoadImageIntoPictureBox(_SelectedImagePath, pbProfilePicture);
                else
                    _LoadDefaultImage();

                lblMode.Text = "Update Person";
                _PersonID = _Person.ID;
                _Mode = enMode.Update;
                lblPersonID.Text = _PersonID.ToString();
            }
            else
                MessageBox.Show("Data not Saved Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

           
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select an Image";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _SelectedImagePath = openFileDialog.FileName;
                clsImages.LoadImageIntoPictureBox(_SelectedImagePath, pbProfilePicture);
            }


            llRemoveImage.Visible = (_SelectedImagePath != null);
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SelectedImagePath = null;
            llRemoveImage.Visible = false;
            _LoadDefaultImage();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, ""); // Clear the error
                return;
            }

            if (!(txtEmail.Text.Contains("@") && txtEmail.Text.Contains(".com")))
            {
                errorProvider1.SetError(txtEmail, "Email must contain '@'.");
                e.Cancel = true; // Prevents focus from leaving the textbox
            }
            else
            {
                errorProvider1.SetError(txtEmail, ""); // Clear the error
            }
        }

        private void mtxtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!mtxtPhone.MaskFull)
            {
                errorProvider1.SetError(mtxtPhone, "Input is incomplete.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(mtxtPhone, string.Empty); // Clear the error
            }
        }

        private void rbGenderChecked(object sender, EventArgs e)
        {
            _LoadDefaultImage();
        }

        private void _LoadDefaultImage()
        {
            if(!llRemoveImage.Visible)
            {
                pbProfilePicture.Image = rbMale.Checked
                    ? ImageResources.Male_512
                    : ImageResources.Female_512;
            }
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox TempText = (System.Windows.Forms.TextBox)sender;
            if (string.IsNullOrWhiteSpace(TempText.Text))
            {
                errorProvider1.SetError(TempText, "This Field is Required!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(TempText, string.Empty); // Clear the error
            }
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the ding sound
                txtSecondName.Focus(); // Move focus to textBox2
            }
        }

        private void txtSecondName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the ding sound
                txtThirdName.Focus(); // Move focus to textBox2
            }
        }

        private void txtThirdName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the ding sound
                txtLastName.Focus(); // Move focus to textBox2
            }
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the ding sound
                txtNationalNo.Focus(); // Move focus to textBox2
            }
        }

        private void txtNationalNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the ding sound
                dtpDateOfBirth.Focus(); // Move focus to textBox2
            }
        }

        private void dtpDateOfBirth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the ding sound
                txtEmail.Focus(); // Move focus to textBox2
            }
        }

      
        private void cbCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the ding sound
                txtAddress.Focus(); // Move focus to textBox2
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the ding sound
                cbCountry.Focus(); // Move focus to textBox2
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmptyTextBox(sender, e);
            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another Person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }
    }
}
