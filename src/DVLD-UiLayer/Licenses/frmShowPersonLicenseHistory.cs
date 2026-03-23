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
using DVLD_UiLayer.UserControls;

namespace DVLD_UiLayer.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        public EventHandler RefereshLocalDL_AppsData;
        enum enMode { ReadOnly, Searching }
        private enMode _Mode;
        private int _PersonID { get; set; }
        public int PersonID { get { return _PersonID; } }
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
            _PersonID = -1;
            _Mode = enMode.Searching;
        }
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.ReadOnly;
        }
        public frmShowPersonLicenseHistory(string NationalNo)
        {
            InitializeComponent();
            _PersonID = clsPerson.Find(NationalNo).ID;
            _Mode = enMode.ReadOnly;
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e )
        {
            if (_Mode == enMode.ReadOnly)
            {
                ctrPersonCardWithFilter.LoadPersonInfo(_PersonID);
                ctrPersonCardWithFilter.FilterEnabled = false;
                ctrDriverLicenses.LoadByPersonId(PersonID);
            }
            else
            {
                ctrPersonCardWithFilter.FilterEnabled =true;
                ctrPersonCardWithFilter.FilterFocus();
            }
            
        }
    

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            RefereshLocalDL_AppsData?.Invoke(this, new EventArgs());
            this.Close();
        }

        private void ctrPersonCardWithFilter_PersonSelected(object sender, EventArgsClasses.PersonEventArgs e)
        {
            _PersonID = e.Person.ID;
            if (_PersonID == -1)
                ctrDriverLicenses.Clear();
            else if (!clsDriver.IsPersonExist(_PersonID))
            {
                ctrDriverLicenses.Clear();
                clsMessageService.ShowWarning("No driver found for the provided Person LicenseID.", "Driver Not Found");
                return;

            }
            else
                ctrDriverLicenses.LoadByPersonId(_PersonID);
        }
    }
}
