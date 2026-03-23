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

namespace DVLD_UiLayer
{
    public partial class ctrApplicationBasicInfoCard : UserControl
    {
        
        private clsApplication _Application;
        private int _ApplicationID { get; set; }
        public int ApplicationID { get { return _ApplicationID; } }

        public ctrApplicationBasicInfoCard()
        {
            InitializeComponent();
            _ApplicationID = -1;
        }


        public void LoadApplicationInfo(int ApplicationID)
        {
            if(ApplicationID == -1)
            {
                ResetApplicationInfo();
                return;
            }

            this._Application = clsApplication.FindBaseApplication(ApplicationID);
            if(this._Application == null)
            {
                ResetApplicationInfo();
                return;
            }

            LoadData();

        }

        private void LoadData()
        {
            if (this._Application != null)
            {
                _ApplicationID = this._Application.ApplicationID;
                lblApplicationID.Text = _Application.ApplicationID.ToString();
                lblApplicationType.Text = _Application.ApplicationTypeInfo.Title;
                lblStatus.Text = _Application.StatusText;
                lblApplicant.Text = _Application.ApplicantFullName;
                lblDate.Text = _Application.ApplicationDate.ToString("yyyy-MM-dd");
                lblLastStatusDate.Text = _Application.LastStatusDate.ToString("yyyy-MM-dd");
                lblFees.Text = _Application.PaidFees.ToString();
                lblCreatedBy.Text = _Application.CreatedByUserInfo.UserName;
                linklblViewPerson.Enabled = true;
            }
        }

        private void linklblViewPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Application != null)
            {
                frmPersonDetails PersonDetails = new frmPersonDetails(_Application.ApplicantPersonID);
                PersonDetails.ShowDialog();
            }
        }
     
        public void ResetApplicationInfo()
        {
            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblApplicationType.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblLastStatusDate.Text = "[????]";
            lblFees.Text = "[????]";
            lblCreatedBy.Text = "[????]";
            linklblViewPerson.Enabled = false;
        }

    
    }
}

