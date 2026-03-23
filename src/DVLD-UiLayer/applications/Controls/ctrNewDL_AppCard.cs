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
using DVLD_UiLayer.ExtensionsClasses;
using DVLD_UiLayer.Licenses;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UiLayer.UserControls
{
    public partial class ctrNewDL_AppCard : UserControl
    {
        private clsLicense _NewLicense;

        private clsApplication _NewDL_App;
        private clsApplication.enApplicationType _AppType;
        private int _NewDL_AppID { get; set; }
        public int NewDL_AppID { get { return _NewDL_AppID; } }
        public ctrNewDL_AppCard()
        {
            InitializeComponent();
            _NewDL_AppID = -1;
        }


        public void LoadNewDL_AppInfo(clsApplication.enApplicationType ApplicationType = clsApplication.enApplicationType.RenewDrivingLicense,int NewDL_AppID = -1)
        {
            _AppType = ApplicationType;
            if(NewDL_AppID == -1)
            {
                ResetDefaultData();
                return;
            }

            this._NewDL_App = clsApplication.FindBaseApplication(NewDL_AppID);
            if (this._NewDL_App == null)
            {
                ResetDefaultData();
                return;
            }

            LoadData();

        }

        private void LoadData()
        {

            if (this._NewDL_App == null) return;

            _NewDL_AppID = this._NewDL_App.ApplicationID;
            lblNewDL_AppID.Text = _NewDL_App.ApplicationID.ToString();
            lblApplicationDate.Text = _NewDL_App.ApplicationDate.DateToShort();
            lblApplicationFees.Text = _NewDL_App.PaidFees.ToString("0.00");
            lblCreatedBy.Text = clsUser.Find(_NewDL_App.CreatedByUserID)?.UserName;
            _NewLicense = clsLicense.FindByApplicationID(_NewDL_AppID);
            if (_NewLicense != null)
            {
                lblNewLicenseID.Text = _NewLicense.LicenseID.ToString();
                lblIssueDate.Text = _NewLicense.IssueDate.DateToShort();
                lblExpirationDate.Text = _NewLicense.ExpirationDate.DateToShort();
                lblNewLicenseFees.Text = _NewLicense.PaidFees.ToString("0.00");
                lblTotalFees.Text = (_NewLicense.PaidFees + _NewDL_App.PaidFees).ToString("0.00");
                linklblShowNewLicenseInfo.Enabled = true;
                txtNotes.Text = _NewLicense.Notes.ToString();
                txtNotes.Enabled = false;
            }
            else
            {
                lblNewLicenseID.Text = "[???]";
                lblOldLicenseID.Text = "[???]";
                lblIssueDate.Text = "[???]";
                lblExpirationDate.Text = "[???]";
                linklblShowNewLicenseInfo.Enabled = false;
                txtNotes.Enabled = true;
            }
        }



        public void ResetDefaultData()
        {
            decimal ApplicationFees = clsApplicationType.Find(Convert.ToByte(_AppType)).Fees;
            lblNewDL_AppID.Text = "[????]";
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = ApplicationFees.ToString("0.00");
            lblNewLicenseID.Text = "[???]";
            lblApplicationDate.Text = DateTime.Now.DateToShort(); ;
            lblOldLicenseID.Text = "[???]";
            lblIssueDate.Text = DateTime.Now.DateToShort();
            lblExpirationDate.Text = "dd/MMM/yyyy";
            lblNewLicenseFees.Text = "[$$$]";
            lblTotalFees.Text = "[$$$]";
            linklblShowNewLicenseInfo.Enabled = false;
            txtNotes.Enabled = true;
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo LicenseInfo = new frmLicenseInfo(new DTOs.LicenseInfoParameters { ApplicationId =  NewDL_AppID });
            LicenseInfo.ShowDialog();
        }
    }
}
