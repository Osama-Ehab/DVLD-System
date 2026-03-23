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
using DVLD_UiLayer.EventArgsClasses;

namespace DVLD_UiLayer.UserControls
{
    public partial class ctrLocalDriverLicenseInfoWithFilter : UserControl
    {

        public event EventHandler<LicenseEventArgs> LicenseSelected;

        private void OnLicenseSelected(clsLicense license)
        {
            OnLicenseSelected(new LicenseEventArgs(license));
        }

        protected virtual void OnLicenseSelected(LicenseEventArgs e)
        {
            LicenseSelected?.Invoke(this, e);
        }
        public ctrLocalDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return LocalDriverLicenseCard.LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { get { return LocalDriverLicenseCard.SelectedLicenseInfo; } }

        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            txtLicenseID.Text = LicenseID.ToString();
            if(LicenseID == -1)
            {
                LocalDriverLicenseCard.ResetDefaultData();
                return;
            }

            FindNow();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

        }

        private void FindNow()
        {
            LocalDriverLicenseCard.LoadLicenseInfo(int.Parse(txtLicenseID.Text.Trim()));
            _LicenseID = LocalDriverLicenseCard.LicenseID;

            OnLicenseSelected(SelectedLicenseInfo);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;

            }
            FindNow();
        }

        public void txtLicenseIDFocus()
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtLicenseID, null);
            }
        }


    }
}
