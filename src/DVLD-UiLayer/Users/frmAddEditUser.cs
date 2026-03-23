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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_UiLayer
{
    public partial class frmAddEditUser : Form
    {
        public delegate void delSendUserID(int UserID);
        public event delSendUserID SendUserID;
        //public event EventHandler RefreshUserDetails;
        public delegate void delRefreshManageUsersList();
        public event delRefreshManageUsersList RefreshManageUsersList;
        enum enMode { AddNew, Update }
        private enMode _Mode;
        private int _UserID = -1;
        private clsUser _User;
        public frmAddEditUser(int UserID = -1)
        {
            InitializeComponent();

            _UserID = UserID;
            if (UserID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                LoadData();
        }


        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User";
                _User = new clsUser();
                txtPassword.ReadOnly = false;
                txtConfirmPassword.ReadOnly = false;
                btnSave.Enabled = true;

            }
            else
            {

                lblMode.Text = "Update User";
                ctrPersonCardWithFilter.FilterEnabled = false;
                txtPassword.ReadOnly = true;
                txtConfirmPassword.ReadOnly = true;

            }
        }
        private void LoadData()
        {

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show($"This from will be closed because there is no User with ID = {_UserID}");
                this.Close();
            }

            ctrPersonCardWithFilter.PersonCard.LoadPersonInfo(_User.PersonID);
            ctrPersonCardWithFilter.txtSearchingForAPerson.Text = _User.PersonID.ToString();
            lblUserID.Text = _UserID.ToString();
            txtUserName.Text = _User.UserName;
            //txtPassword.Text = _User.Password.ToString();
            txtConfirmPassword.Text = _User.Password.ToString();
            chkIsActive.Checked = _User.IsActive;
        }

        private void _InvokeEventsAfterSave()
        {
            //RefreshUserDetails?.Invoke(this, EventArgs.Empty);
            RefreshManageUsersList?.Invoke();
            SendUserID?.Invoke(_User.UserID);
        }

        private void UpdateUI()
        {
            MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK);
            txtPassword.ReadOnly = true;
            txtConfirmPassword.ReadOnly = true;
            ctrPersonCardWithFilter.gbFilterBy.Enabled = false;
            lblMode.Text = "Update User";
            _UserID = _User.UserID;
            _Mode = enMode.Update;
            lblUserID.Text = _UserID.ToString();
        }


        private void FillUserObjectBeforeSave()
        {
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chkIsActive.Checked;
            _User.PersonID = ctrPersonCardWithFilter.PersonID;
        }
        private void _SaveUpdates()
        {

            FillUserObjectBeforeSave();

            if (_User.Save())
            {
                _InvokeEventsAfterSave();
                UpdateUI();
            }
            else
                MessageBox.Show("Data not Saved Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void txtNumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
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
                    _SaveUpdates();
                }
                else
                    MessageBox.Show("Data not Saved Successfully,Couse there is field(s) Empty or Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckIfUserNameExist(string UserName) => (UserName != _User?.UserName) && clsUser.IsUserNameExist(UserName);

        private void UserName_Validateing(object sender, CancelEventArgs e)
        {
            TextBox txtUName = (TextBox)sender;
            string UserName = txtUName.Text;
            if (string.IsNullOrWhiteSpace(UserName))
            {
                errorProvider1.SetError(txtUName, "This Field is Required!");
                e.Cancel = true;
            }
            else if (CheckIfUserNameExist(UserName))
            {
                errorProvider1.SetError(txtUName, "This UserName already exist,choose another one!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUName, string.Empty); // Clear the error
            }
        }
        private void Password_Validateing(object sender, CancelEventArgs e)
        {
            if ((txtPassword.Text != txtConfirmPassword.Text) || !txtPassword.MaskCompleted)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password confirmation does not match Password,Or are not Completed!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, string.Empty); // Clear the error
            }
        }

        private void SelectedPerson_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode != enMode.Update)
            {
                if (ctrPersonCardWithFilter.PersonID != -1)
                {
                    if (!clsUser.IsPersonIDExist(ctrPersonCardWithFilter.PersonID))
                    { return; }
                    else
                    {
                        MessageBox.Show("Selected Person already has a user ,choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("There is no Person selected to connect with User", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            { tControlAddEditUser.SelectedTab = tPageLoginInfo; return; }

            if (ctrPersonCardWithFilter.PersonID != -1)
            {
                if (!clsUser.IsPersonIDExist(ctrPersonCardWithFilter.PersonID))
                { tControlAddEditUser.SelectedTab = tPageLoginInfo; }
                else
                {
                    MessageBox.Show("Selected Person already has a user ,choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There is no Person selected to connect with User", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewPasswordVisibility_Click(object sender, EventArgs e) => txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        private void ConfirmPasswordVisibility_Click(object sender, EventArgs e) => txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
    }
}
