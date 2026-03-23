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
using DVLD_UiLayer.Licenses;

namespace DVLD_UiLayer
{

    public partial class frmManagePeople : Form
    {

        private enum enFilterBy { None, PersonID ,NationalNo,FirstName,SecondName,ThirdName,LastName,
         Gender ,Phone  ,Email};

        private enFilterBy _FilterBy;

        private DataTable _PeopleTable;

        private DataView _ManagePeopleView;
        public frmManagePeople()
        {
            InitializeComponent();
         
        }

        private void _RefreshManagePeopleList()
        {
            _PeopleTable = clsPerson.GetAllPeople();
            _ManagePeopleView = _PeopleTable.DefaultView;
            dgvManagePeople.DataSource = _ManagePeopleView;
            _RefreshDataWithFilter();
            _UpdateRecordsCount();
        }
        private void btnCloseForm_Click(object sender, EventArgs e) => this.Close();

        private void _RefreshTxtFilterFormat()
        {
           
            if (mtxtFilterSearch.Visible = _FilterBy != enFilterBy.None)
            {
                if (_FilterBy == enFilterBy.Phone)
                    mtxtFilterSearch.Mask = "000 000 0000";
                else
                    mtxtFilterSearch.Mask = null;

                mtxtFilterSearch.Text = string.Empty;
                mtxtFilterSearch.Focus();
            }
        }


        private void _RefreshDataWithFilter()
        {

            if (string.IsNullOrWhiteSpace(mtxtFilterSearch.Text) || _FilterBy == enFilterBy.None)
            {
                _ManagePeopleView.RowFilter = string.Empty;
                _UpdateRecordsCount();
                return;
            }
            string TxtFilterSearchAfterProtectingFromSqlInjection = mtxtFilterSearch.Text.Replace("'", "''");

            switch (_FilterBy)
            {
                case enFilterBy.PersonID:
                    if (int.TryParse(mtxtFilterSearch.Text, out int personId))
                        _ManagePeopleView.RowFilter = $"[Person ID] = {personId}";
                    else
                        _ManagePeopleView.RowFilter = "1 = 0"; // No match
                    break;

                case enFilterBy.NationalNo:
                    _ManagePeopleView.RowFilter = $"[National No.] LIKE '{TxtFilterSearchAfterProtectingFromSqlInjection}%'";
                    break;

                case enFilterBy.FirstName:
                    _ManagePeopleView.RowFilter = $"[First Name] LIKE '{TxtFilterSearchAfterProtectingFromSqlInjection}%'";
                    break;

                case enFilterBy.SecondName:
                    _ManagePeopleView.RowFilter = $"[Second Name] LIKE '{TxtFilterSearchAfterProtectingFromSqlInjection}%'";
                    break;

                case enFilterBy.ThirdName:
                    _ManagePeopleView.RowFilter = $"[Third Name] LIKE '{TxtFilterSearchAfterProtectingFromSqlInjection}%'";
                    break;

                case enFilterBy.LastName:
                    _ManagePeopleView.RowFilter = $"[Last Name] LIKE '{TxtFilterSearchAfterProtectingFromSqlInjection}%'";
                    break;

                case enFilterBy.Gender:
                    _ManagePeopleView.RowFilter = $"Gender LIKE '{TxtFilterSearchAfterProtectingFromSqlInjection}%'";
                    break;
                case enFilterBy.Phone:
                    _ManagePeopleView.RowFilter = $"Phone LIKE '{TxtFilterSearchAfterProtectingFromSqlInjection}%'";
                    break;

                case enFilterBy.Email:
                    _ManagePeopleView.RowFilter = $"Email LIKE '{TxtFilterSearchAfterProtectingFromSqlInjection}%'";
                    break;

                default:
                    _ManagePeopleView.RowFilter = string.Empty;
                    break;
            }


            
            _UpdateRecordsCount();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterBy = (enFilterBy)cbFilterBy.SelectedIndex;
            _RefreshTxtFilterFormat();
        }

        private void mtxtFilterSearch_TextChanged(object sender, EventArgs e)
        {
            _RefreshDataWithFilter();
        }

        private void mtxtFilterSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (_FilterBy == enFilterBy.PersonID ||  _FilterBy == enFilterBy.Phone)
           {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
           }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvManagePeople.CurrentRow.Cells[0].Value.ToString(), out int PersonID))
            {
                frmPersonDetails PersonDetails = new frmPersonDetails(PersonID);
                PersonDetails.ShowDialog();
            }
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshManagePeopleList();
            cbFilterBy.SelectedIndex = 0;
        }

        private void AddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson AddNewPerson = new frmAddEditPerson(-1);
            AddNewPerson.RefreshManagePeopleList += _RefreshManagePeopleList;
            AddNewPerson.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvManagePeople.CurrentRow.Cells[0].Value.ToString(), out int result))
            {
                frmAddEditPerson EditPerson = new frmAddEditPerson(result);
                EditPerson.RefreshManagePeopleList += _RefreshManagePeopleList;
                EditPerson.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete this Person?", "Confirmed", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (int.TryParse(dgvManagePeople.CurrentRow.Cells[0].Value.ToString(), out int result))
                {
                   
                    if (clsPerson.DeletePerson(result))
                    {
                        MessageBox.Show("Person Deleted Successfully", "Saved", MessageBoxButtons.OK);
                        _RefreshManagePeopleList();
                    }
                    else
                        MessageBox.Show("Person not deleted Successfully,Couse another data connected with this Person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
        }

        private void btnSearchPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory LicenseHistory = new frmShowPersonLicenseHistory();
            LicenseHistory.RefereshLocalDL_AppsData += frmManagePeople_Load;
            LicenseHistory.ShowDialog();
        }
        private void _UpdateRecordsCount() => lblRecordsCount.Text = dgvManagePeople.Rows.Count.ToString();

    }
}
