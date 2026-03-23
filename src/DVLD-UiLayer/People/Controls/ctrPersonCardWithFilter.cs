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
using DVLD_UiLayer.HelperClasses;


namespace DVLD_UiLayer
{
    public partial class ctrPersonCardWithFilter : UserControl
    {
        public event EventHandler<PersonEventArgs> PersonSelected;

        private void OnPersonSelected(clsPerson person)
        {
            OnPersonSelected(new PersonEventArgs(person));
        }

        protected virtual void OnPersonSelected(PersonEventArgs e)
        {
            PersonSelected?.Invoke(this, e);
        }

        private enum enFindBy
        {
            NationalNo, PersonID
        }

        private enFindBy _FindBy;

        public int PersonID { get { return PersonCard.PersonID; }  }
        public clsPerson SelectedPerson { get { return PersonCard.SelectedPerson; } }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson {  get { return _ShowAddPerson; } set { _ShowAddPerson = value; btnAddPerson.Enabled = _ShowAddPerson; } }

        private bool _FilterEnabled = true;
        public bool FilterEnabled {  get { return _FilterEnabled; } set { _FilterEnabled = value; gbFilterBy.Enabled = _FilterEnabled; } }
        public ctrPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 1;
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFindBy.SelectedIndex == 0)
               {_FindBy = enFindBy.NationalNo;}
            else
                {_FindBy = enFindBy.PersonID;}

            txtSearchingForAPerson.Text = string.Empty;
        }

        private void txtSearchingForAPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FindBy ==  enFindBy.PersonID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnSearchingForAPerson_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                clsMessageService.ShowValidationError("Some filed(s) are empty or required!");
                return;
            }

            FindNow();
        }


        private void AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddNewPerson = new frmAddEditPerson(-1);
            AddNewPerson.SendPersonID += LoadPersonInfo;
            AddNewPerson.ShowDialog();
        }

        public void LoadPersonInfo(int PersonID)
        {          
            cbFindBy.SelectedIndex = 1;
            txtSearchingForAPerson.Text = PersonID.ToString();
            if (PersonID == -1)
            {
                PersonCard.ResetDefaultData();
                return;
            }

            FindNow();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            cbFindBy.SelectedIndex = 0;
            txtSearchingForAPerson.Text = NationalNo;
            if (string.IsNullOrWhiteSpace(NationalNo))
            {
                PersonCard.ResetDefaultData();
                return;
            }

            FindNow();
        }

        private void FindNow()
        {
            switch (cbFindBy.SelectedIndex)
            {
                case 0:
                    PersonCard.LoadPersonInfo(txtSearchingForAPerson.Text.Trim());
                    break;
                case 1:
                    PersonCard.LoadPersonInfo(int.Parse(txtSearchingForAPerson.Text)); break;

                default:
                    break;
            }
            OnPersonSelected(PersonCard.SelectedPerson);
        }


        public void FilterFocus()
        {
           txtSearchingForAPerson.Focus();
        }

        private void txtSearchingForAPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // Prevents the ding sound
                btnSearchingForAPerson.PerformClick();
            }
        }

        private void txtSearchingForAPerson_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchingForAPerson.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSearchingForAPerson, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtSearchingForAPerson, null);
            }
        }
    }
}
