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
using DVLD_UiLayer.HelperClasses;

namespace DVLD_UiLayer
{
    public partial class frmAddEditLocalDL_App : Form
    {
        List<clsLicenseClass> LicenseClasses;

        public event Action<int> SendLocalDL_AppID;

        public delegate void delRefreshManageLocalDL_AppsList();
        public event delRefreshManageLocalDL_AppsList RefreshManageLocalDL_AppsList;
        enum enMode { AddNew, Update }
        private enMode _Mode;
        private int _LocalDL_AppID = -1;
        private clsLocalDL_App _LocalDL_App;
        public frmAddEditLocalDL_App(int LocalDL_AppID = -1)
        {
            InitializeComponent();

            _LocalDL_AppID = LocalDL_AppID;
            _Mode = (LocalDL_AppID == -1) ? enMode.AddNew : enMode.Update;
        }

        private void frmAddEditLocalDL_App_Load(object sender, EventArgs e)
        {
            LicenseClasses = new List<clsLicenseClass>
            {
              clsLicenseClass.Find(1),
              clsLicenseClass.Find(2),
              clsLicenseClass.Find(3),
              clsLicenseClass.Find(4),
              clsLicenseClass.Find(5),
              clsLicenseClass.Find(6),
              clsLicenseClass.Find(7)
            }.Where(x => x != null).ToList();
            _LoadCbLicenseClassesData();
            _ResetDefualtValues();
            if (_Mode == enMode.AddNew) return;

            LoadData();
        }

        private void _ResetDefualtValues()
        {
            this.Text = lblMode.Text = (_Mode == enMode.AddNew)? "New Local Driving License Application": "Update Local Driving License Application";
            _LocalDL_App = new clsLocalDL_App();
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblApplicationFees.Text = clsApplicationType.Find((byte)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
            lblUserName.Text = clsGlobal.CurrentUser.UserName;
        }
        private void _LoadCbLicenseClassesData()
        {
            cbLicenseClass.DataSource = LicenseClasses;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
            cbLicenseClass.SelectedIndex = 2;
        }
        private void LoadData()
        {
            ctrPersonCardWithFilter.FilterEnabled = false;
            _LocalDL_App = clsLocalDL_App.Find(_LocalDL_AppID);

            if (_LocalDL_App == null)
            {
                MessageBox.Show($"This from will be closed because there is no _LocalDrivingLicenseApplication with ID = {_LocalDL_AppID}");
                this.Close();
            }

            ctrPersonCardWithFilter.LoadPersonInfo(_LocalDL_App.ApplicationInfo.ApplicantPersonID);
            lblLocalDL_AppID.Text = _LocalDL_AppID.ToString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDL_App.LicenseClassInfo.ClassName);
            lblApplicationDate.Text = _LocalDL_App.ApplicationInfo.ApplicationDate.DateToShort();
            lblApplicationFees.Text = _LocalDL_App.ApplicationInfo.PaidFees.ToString();
            lblUserName.Text =  _LocalDL_App.ApplicationInfo.CreatedByUserInfo.UserName;
        }

        private void SaveUpdates()
        {
            _LocalDL_App.LicenseClassID = Convert.ToByte(cbLicenseClass.SelectedValue);

            _LocalDL_App.ApplicationInfo.ApplicantPersonID = ctrPersonCardWithFilter.PersonCard.PersonID;

            if (_LocalDL_App.LicenseClassInfo.MinimumAllowedAge > (_LocalDL_App.ApplicationInfo.PersonInfo.Age))
            {
                MessageBox.Show($"Data not Saved Successfully,Cause the minimum allowed age of license class older than age of Aplicant Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (clsLicense.IsLicenseExistByPersonID(_LocalDL_App.ApplicationInfo.ApplicantPersonID, _LocalDL_App.LicenseClassID))
            {
                MessageBox.Show($"Data not Saved Successfully,Cause Person already have a license with the same applied driving class,Choose diffrent driving class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int ActiveApplicationID = clsLocalDL_App.FindActiveDuplicate(_LocalDL_App.ApplicationInfo.ApplicantPersonID, _LocalDL_App.LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }


            _LocalDL_App.ApplicationInfo.ApplicationTypeID = (byte)clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDL_App.ApplicationInfo.PaidFees = clsApplicationType.Find((byte)clsApplication.enApplicationType.NewDrivingLicense).Fees;
            _LocalDL_App.ApplicationInfo.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!_LocalDL_App.Save())
            {
                MessageBox.Show("Data not Saved Successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            _LocalDL_AppID = _LocalDL_App.LocalDLAppID;
            RefreshManageLocalDL_AppsList?.Invoke();
            SendLocalDL_AppID?.Invoke(_LocalDL_App.LocalDLAppID);
            MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK);
            lblMode.Text = "Update Local Driving License Application";
            _Mode = enMode.Update;
            lblLocalDL_AppID.Text = _LocalDL_AppID.ToString();
            ctrPersonCardWithFilter.FilterEnabled = false;
            lblUserName.Text = clsGlobal.CurrentUser.UserName;

        }


        private void txtNumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure that you want to close form And ignore changes?"))return;

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure that you want to save Updates?", "Confirmed"))return;

            if (!this.ValidateChildren())
            {
                clsMessageService.ShowValidationError("Data not Saved Successfully,Couse there is field(s) Empty or Required");
                return;
            }

            SaveUpdates();
        }

        private void SelectedPerson_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == enMode.Update)return;

            if (ctrPersonCardWithFilter.PersonCard.PersonID != -1) return;

            e.Cancel = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrPersonCardWithFilter.PersonCard.PersonID == -1)
            {
                MessageBox.Show("There is no Person selected to connect with _LocalDrivingLicenseApplication", "No Person Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrPersonCardWithFilter.FilterFocus();
                return;
            }

            tControlAddEditLocalDL_App.SelectedTab = tPageApplicationInfo;

        }
    }
}
