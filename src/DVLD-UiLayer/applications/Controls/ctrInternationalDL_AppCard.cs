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
using DVLD_UiLayer.InternationalLicenses;
using DVLD_UiLayer.Licenses;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UiLayer.UserControls
{
    public partial class ctrInternationalDL_AppCard : UserControl
    {
        private clsInternationalLicense _InternationalLicense;
        private clsApplication _InternationalDL_App;
        private int _InternationalDL_AppID { get; set; }
        public int InternationalDL_AppID { get { return _InternationalDL_AppID; } }
        public ctrInternationalDL_AppCard()
        {
            InitializeComponent();
            _InternationalDL_AppID = -1;
        }


        public void LoadInternationalDL_AppInfo(int InternationalDL_AppID = -1)
        {
            this._InternationalDL_App = clsApplication.FindBaseApplication(InternationalDL_AppID);
            if (this._InternationalDL_App != null)
            { _LoadInternationalDL_AppInfoAfterFind(); }
            else
            {
                ResetDefaultData();
            }

        }

        private void _LoadInternationalDL_AppInfoAfterFind()
        {
            if (this._InternationalDL_App != null)
            {
                _InternationalDL_AppID = this._InternationalDL_App.ApplicationID;
                lblInternationalDL_AppID.Text = _InternationalDL_App.ApplicationID.ToString();
                lblApplicationDate.Text = _InternationalDL_App.ApplicationDate.DateToShort();
                lblFees.Text = _InternationalDL_App.PaidFees.ToString("00.00");
                lblCreatedBy.Text = _InternationalDL_App.CreatedByUserInfo.UserName;
               
                _InternationalLicense = clsInternationalLicense.FindByApplicationID(_InternationalDL_App.ApplicationID);
                if (_InternationalLicense != null)
                {
                    lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                    lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
                    lblIssueDate.Text = _InternationalLicense.IssueDate.DateToShort();
                    lblExpirationDate.Text = _InternationalLicense.ExpirationDate.DateToShort();
                    linklblShowLicenseInfo.Enabled = true;
                }
                else
                {
                    lblInternationalLicenseID.Text = "[???]";
                    lblLocalLicenseID.Text = "[???]";
                    lblIssueDate.Text = "[???]";
                    lblExpirationDate.Text = "[???]";
                    linklblShowLicenseInfo.Enabled = false; 
                }

            }
        }


        private void ctrInternationalDL_AppCard_Load(object sender, EventArgs e)
        {
            if (_InternationalDL_App != null) { LoadInternationalDL_AppInfo(_InternationalDL_App.ApplicationID); }
        }

        public void ResetDefaultData()
        {
            lblInternationalDL_AppID.Text = "[????]";
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblFees.Text = clsApplicationType.Find(6).Fees.ToString("00.00");
            lblInternationalLicenseID.Text = "[???]";
            lblApplicationDate.Text = DateTime.Now.DateToShort(); ;
            lblLocalLicenseID.Text = "[???]";
            lblIssueDate.Text = DateTime.Now.DateToShort();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).DateToShort();
            linklblShowLicenseInfo.Enabled = false;
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInternationalLicenseInfo InternationalLicenseInfo = new frmInternationalLicenseInfo(InternationalDL_AppID, true);
            InternationalLicenseInfo.ShowDialog();
        }
    }
}
