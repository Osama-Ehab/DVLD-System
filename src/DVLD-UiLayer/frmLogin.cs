using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using DVLD_BusinessLayer;
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.Helpers;
using static DVLD_UiLayer.HelperClasses.clsMessageService;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DVLD_UiLayer.helperclasses.WidowsRegistry;
using Microsoft.Win32;
using System.Diagnostics;
using CryptographyExtensions;

namespace DVLD_UiLayer
{
    public partial class frmLogin : Form
    {

        private clsUser _LoginUser;
        string username;
        string password;
        string hashedPassword;
        public frmLogin()
        {
            InitializeComponent();
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            txtUserName.HandleEnterKey(() => txtPassword.Focus());
            txtPassword.HandleEnterKey(() => btnLogin.PerformClick());
            if (!clsWidowsRegistry.GetUserCredentials(ref username, ref hashedPassword)) return;
            txtUserName.Text = username;
            //txtPassword.Text = password;
        }


        private bool HandleFindUser()
        {

            username = txtUserName.Text.Trim();
            password = txtPassword.Text.Trim();


            _LoginUser = clsUser.Find(username);

            if (_LoginUser == null || !_LoginUser.Password.IsValid(password))
                return ShowErrorReturnBoolean("Invalid Username/Password.", "Wrong Credentials");

            return true;

        }
        private bool HandleUserActiveState()
        {

            if (_LoginUser == null || !_LoginUser.IsActive)
                return ShowErrorReturnBoolean("Your Account is deactivated, please contact your Admin.",
                    "Account Disabled");

            return true;
        }

        private void btnLogin_Click(object sender, EventArgs e)

        {


            if (!HandleFindUser() || !HandleUserActiveState()) return;



            if (chkRememberMe.Checked)
                clsWidowsRegistry.SaveUserCredentials(
                    new UserCredentials
                    {
                        Username = _LoginUser.UserName,
                        Password = _LoginUser.Password
                    });
            else
                clsWidowsRegistry.ClearUserCredentials();

            clsGlobal.CurrentUser = _LoginUser;

            frmMain mainForm = new frmMain();
            this.Visible = false;
            mainForm.ShowDialog();
            this.Visible = true;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (!Confirm("Are you sure that you want to close form?"))
                return;

            this.Close();
        }

        private void NewPasswordVisibility_Click(object sender, EventArgs e) => txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
       
    }
}
