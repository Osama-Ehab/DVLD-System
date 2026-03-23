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
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.Licenses;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_UiLayer.UserControls
{
    public partial class ctrLocalDL_AppCard : UserControl
    {
        private clsLocalDL_App _LocalDL_App;
        private int _LocalDL_AppID { get; set; }
        public int LocalDL_AppID { get { return _LocalDL_AppID; } }
        public ctrLocalDL_AppCard()
        {
            InitializeComponent();
            _LocalDL_AppID = -1;
        }


        public void LoadLocalDL_AppInfo(int LocalDL_AppID)
        {
            if (LocalDL_AppID == -1)
            {
                ResetLocalDL_ApplicationInfo();
                clsMessageService.ShowError($"No Application with LocalDL_ApplicationID = {LocalDL_AppID}");
                return;
            }
            this._LocalDL_App = clsLocalDL_App.Find(LocalDL_AppID);
            if (this._LocalDL_App == null)
            {
                ResetLocalDL_ApplicationInfo();
                clsMessageService.ShowError($"No Application with LocalDL_ApplicationID = {LocalDL_AppID}");
                return;
            }

            LoadData();

        }


        public void LoadLocalDL_ApplicationInfoByApplicationID(int ApplicationID)
        {
            if (ApplicationID == -1)
            {
                ResetLocalDL_ApplicationInfo();
                clsMessageService.ShowError($"No Application with ApplicationID = {ApplicationID}");
                return;
            }
            this._LocalDL_App = clsLocalDL_App.FindByBasicAppID(ApplicationID);
            if (this._LocalDL_App == null)
            {
                ResetLocalDL_ApplicationInfo();
                clsMessageService.ShowError($"No Application with ApplicationID = {ApplicationID}");
                return;
            }

            LoadData();

        }

        private void LoadData()
        {
            if (this._LocalDL_App != null)
            {
                _LocalDL_AppID = this._LocalDL_App.LocalDLAppID;
                lblLocalDL_AppID.Text = _LocalDL_App.LocalDLAppID.ToString();
                lblLicenseClass.Text = _LocalDL_App.LicenseClassInfo.ClassName;
                lblPassedTests.Text = $"{_LocalDL_App.GetPassedTestCount()}/3";
                ApplicationBasicInfoCard.LoadApplicationInfo(_LocalDL_App.ApplicationID);
                linklblShowLicenseInfo.Enabled = _LocalDL_App.IsLicenseIssued();
            }
        }


        private void ctrLocalDL_AppCard_Load(object sender, EventArgs e)
        {
            if (_LocalDL_App != null) {  }
        }


        public void ResetLocalDL_ApplicationInfo()
        {
            lblLocalDL_AppID.Text = "[????]";
            lblLicenseClass.Text = "[????]";
            lblPassedTests.Text = "[????]";
            ApplicationBasicInfoCard.ResetApplicationInfo();
            linklblShowLicenseInfo.Enabled = false;
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo LicenseInfo = new frmLicenseInfo(new DTOs.LicenseInfoParameters { LocalDLAppId = LocalDL_AppID});
            LicenseInfo.ShowDialog();
            
        }
    }
}
