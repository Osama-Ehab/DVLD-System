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
using DVLD_UiLayer.Users;
using DVLD_UiLayer.ApplicationTypes;
using DVLD_UiLayer.TestTypes;

namespace DVLD_UiLayer
{
    public partial class frmMain : Form
    {
        Form ManageAll;
        static public DataTable CountriesDataTable {  get; set; }
        public frmMain()
        {
           
            InitializeComponent();
            this.IsMdiContainer = true;
            CountriesDataTable = clsCountries.GetAllCountries();
            MainMenu.BringToFront();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            if (ManageAll == null || ManageAll.IsDisposed)
            { 
                ManageAll = new frmManagePeople();
                ManageAll.MdiParent = this;
            }
            ManageAll.Show();
            ManageAll.BringToFront();
          
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ManageAll == null || ManageAll.IsDisposed)
            {
                ManageAll = new frmManageUsers();
                ManageAll.MdiParent = this;
            }
            ManageAll.Show();
            ManageAll.BringToFront();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUserInfo UserDetails = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            UserDetails.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            ChangePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to Sign Out?", "Confirmed", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {  
                clsGlobal.CurrentUser = null;
                this.Close();             
            }
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes ManageApplicationTypes = new frmManageApplicationTypes();
            ManageApplicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes ManageTestTypes = new frmManageTestTypes();
            ManageTestTypes.ShowDialog();
        }

  

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDL_Apps  ManageLocalDL_Apps = new frmManageLocalDL_Apps();
            ManageLocalDL_Apps.ShowDialog();
        }

        private void localLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDL_App AddEditLocalDL_App = new frmAddEditLocalDL_App();
            AddEditLocalDL_App.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers ManageDrivers = new frmManageDrivers();
            ManageDrivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditLicenseApplication AddEditInternationalDL_App = new frmAddEditLicenseApplication(clsApplication.enApplicationType.NewInternationalLicense);
            AddEditInternationalDL_App.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalDL_Apps ManageInternationalDL_Apps = new frmManageInternationalDL_Apps();
            ManageInternationalDL_Apps.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLicenseApplication AddEditRenewDL_App = new frmAddEditLicenseApplication(clsApplication.enApplicationType.RenewDrivingLicense);
            AddEditRenewDL_App.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLicenseApplication AddEditReplacementDL_App = new frmAddEditLicenseApplication(clsApplication.enApplicationType.ReplaceDamagedDrivingLicense);
            AddEditReplacementDL_App.ShowDialog();

        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense DetainLicense = new frmDetainLicense();
             DetainLicense.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLicenseApplication ReleaseDetainedLicense_App = new frmAddEditLicenseApplication(clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense);
            ReleaseDetainedLicense_App.ShowDialog();
        }

        private void manageDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses ManageDetainedLicenses = new frmManageDetainedLicenses();
           ManageDetainedLicenses.ShowDialog();
        }

     
    }
};
