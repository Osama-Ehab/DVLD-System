using System;
using System.ComponentModel;
using System.Windows.Forms;
using CryptographyExtensions;
using DVLD_BusinessLayer;
using DVLD_UiLayer.helperclasses.Validation;
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.Helpers;

namespace DVLD_UiLayer.Users
{
    public partial class frmChangePassword : Form
    {
        private clsUser _User;
        private readonly int _UserID;

        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ResetFields();

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                clsMessageService.ShowError($"Could not find user with UserID = {_UserID}.");
                Close();
                return;
            }

            UserCard.LoadUserInfo(_User);

            // 🔹 Hook Enter navigation
            txtCurrentPassword.HandleEnterKey(() => txtNewPassword.Focus());
            txtNewPassword.HandleEnterKey(() => txtConfirmPassword.Focus());
            txtConfirmPassword.HandleEnterKey(() => btnSave.PerformClick());
        }

        private void ResetFields()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            txtCurrentPassword.Focus();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure you want to close and ignore changes?")) return;

            Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            if (!ValidateChildren())
            {
                clsMessageService.ShowValidationError("Some fields are invalid. Hover over the red icons to see the error.");
                return;
            }

            if (!clsMessageService.Confirm("Are you sure you want to save changes?"))
                return;

            if (!_User.ChangePassword(txtNewPassword.Text.Trim()))
            {
                clsMessageService.ShowError("An error occurred. Password did not change.");
                return;
            }

            clsMessageService.ShowSuccess("Password changed successfully.");
            ResetFields();

        }


        // 🔹 Validation events → call clsPasswordValidator
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!clsPasswordValidator.ValidateCurrentPassword(txtCurrentPassword.Text.Trim().Hashing(), _User.Password, out string ErrorMessage))
            {
                txtCurrentPassword.SetErrorAndFocus(errorProvider1, ErrorMessage);
                e.Cancel = true;
                return;
            }
            else
                txtCurrentPassword.ClearError(errorProvider1);
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!clsPasswordValidator.ValidateNewPassword(txtNewPassword.Text.Trim(), out string ErrorMessage))
            {
                txtNewPassword.SetErrorAndFocus(errorProvider1, ErrorMessage);
                e.Cancel = true;
            }
            else
                txtNewPassword.ClearError(errorProvider1);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!clsPasswordValidator.ValidateConfirmPassword(txtNewPassword.Text.Trim(), txtConfirmPassword.Text.Trim(), out string ErrorMessage))
            {
                txtConfirmPassword.SetErrorAndFocus(errorProvider1, ErrorMessage);
                e.Cancel = true;
            }
            else
                txtConfirmPassword.ClearError(errorProvider1);
        }

        private void CurrentPasswordVisibility_Click(object sender, EventArgs e) =>  txtCurrentPassword.UseSystemPasswordChar = !txtCurrentPassword.UseSystemPasswordChar;
        private void NewPasswordVisibility_Click(object sender, EventArgs e) => txtNewPassword.UseSystemPasswordChar = !txtNewPassword.UseSystemPasswordChar;
        private void ConfirmPasswordVisibility_Click(object sender, EventArgs e) => txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;

       
    }
}
