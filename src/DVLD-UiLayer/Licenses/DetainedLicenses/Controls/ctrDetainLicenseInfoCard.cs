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
    public partial class ctrDetainLicenseInfoCard : UserControl
    {
        private clsDetainedLicense _DetainedLicense;
        private int _DetainedLicenseID { get; set; }
        public int LicenseID { get { return _DetainedLicenseID; } }
        public ctrDetainLicenseInfoCard()
        {
            InitializeComponent();
            _DetainedLicenseID = -1;
        }


        public void LoadDetainedLicenseInfo(int DetainID)
        {
            this._DetainedLicense = clsDetainedLicense.Find(DetainID);
            if (this._DetainedLicense != null)
            { LoadDetainedLicenseApplicationInfo(); }
            else
            {
                ResetDefaultData();
            }

        }

        private void LoadDetainedLicenseApplicationInfo()
        {
            
            if (this._DetainedLicense != null)
            {
                _DetainedLicenseID = _DetainedLicense.LicenseID;
                lblDetainID.Text = _DetainedLicense.DetainID.ToString();
                lblDetainDate.Text = _DetainedLicense.DetainDate.DateToShort();
                txtFineFees.Text = _DetainedLicense.FineFees.ToString("0.00");
                lblCreatedBy.Text = _DetainedLicense.CreatedByUserInfo.UserName;
                linklblShowLicenseInfo.Enabled = true;

            }
            else
            {
                ResetDefaultData();
            }
        }


        private void ResetDefaultData()
        {
            lblDetainID.Text = "[????]";
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text = DateTime.Now.DateToShort(); ;
            txtFineFees.Text = "0";
            linklblShowLicenseInfo.Enabled = false;
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseInfo LicenseInfo = new frmLicenseInfo(new DTOs.LicenseInfoParameters { LicenseId = _DetainedLicenseID });
            LicenseInfo.ShowDialog();
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the key press
            }
        }


    }
}
