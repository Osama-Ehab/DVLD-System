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
    public partial class ctrReleaseDetainedLicenseAppCard : UserControl
    {
        private clsDetainedLicense _DetainedLicense;
        private int? _ReleaseDetainedLicenseAppID { get; set; }
        public int? ReleaseDetainedLicenseAppID { get { return _ReleaseDetainedLicenseAppID; } }

        decimal ApplicationFees = clsApplicationType.Find((byte)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;

        public ctrReleaseDetainedLicenseAppCard()
        {
            InitializeComponent();
            _ReleaseDetainedLicenseAppID = -1;
        }


        public void LoadInfoByDetainID(int DetainID = -1)
        {
            if (DetainID == -1)
            {
                ResetDefaultData();
                return;
            }
            _DetainedLicense = clsDetainedLicense.Find(DetainID);
            if (this._DetainedLicense == null)
            { 
                ResetDefaultData();
                return;
            }
            
            LoadData();

        }
        public void LoadInfoByReleaseApplicationID(int ReleaseApplicationID = -1)
        {
            if (ReleaseApplicationID == -1)
            {
                ResetDefaultData();
                return;
            }
            _DetainedLicense = clsDetainedLicense.FindByReleaseApplicationID(ReleaseApplicationID);
            if (this._DetainedLicense == null)
            {
                ResetDefaultData();
                return;
            }

            LoadData();

        }

        private void LoadData()
        {

            if (this._DetainedLicense == null) return;

            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.DateToShort();
            lblApplicationFees.Text = ApplicationFees.ToString("0.00");
            lblCreatedBy.Text =_DetainedLicense.CreatedByUserInfo.UserName;
            lblFineFees.Text = _DetainedLicense.FineFees.ToString("0.00");
            lblTotalFees.Text = (_DetainedLicense.FineFees + _DetainedLicense.FineFees).ToString("0.00");
            linklblShowNewLicenseInfo.Enabled = true;


            if (_DetainedLicense.ReleaseApplicationID == null) return;


            _ReleaseDetainedLicenseAppID = _DetainedLicense.ReleaseApplicationID;
            lblReleaseApplicationID.Text = _ReleaseDetainedLicenseAppID.ToString();
        }

        public void ResetDefaultData()
        {
            lblDetainID.Text = "[????]";
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = ApplicationFees.ToString("0.00");
            lblDetainDate.Text = DateTime.Now.DateToShort(); ;
            linklblShowNewLicenseInfo.Enabled = false;
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo LicenseInfo = new frmLicenseInfo(new DTOs.LicenseInfoParameters { LicenseId = _DetainedLicense.LicenseID });
            LicenseInfo.ShowDialog();
        }

     
    }
}
