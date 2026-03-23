using System;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.Users;
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.ExtensionsClasses;

namespace DVLD_UiLayer
{
    public partial class frmManageUsers : Form
    {
        private enum FilterBy
        {
            None, UserID, UserName, PersonID, FullName, IsActive
        }

        private enum IsActiveFilter { All, Yes, No }

        private FilterBy currentFilterBy = FilterBy.None;
        private IsActiveFilter currentIsActiveFilter = IsActiveFilter.All;

        private DataTable usersTable;
        private DataView usersView;

        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            RefreshManageUsersList();
        }

        private void RefreshManageUsersList()
        {
            usersTable = clsUser.GetAllUsers();
            usersView = usersTable.DefaultView;
            dgvManageUsers.DataSource = usersView;

            if (dgvManageUsers.Columns.Count > 2)
                dgvManageUsers.Columns[2].Width = 300;

            RefreshDataWithFilter();
            lblRecordsCount.SetRecordsCount(dgvManageUsers.Rows.Count);
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnCloseForm_Click(object sender, EventArgs e) => Close();

        private void RefreshFilterControls()
        {
            if (currentFilterBy == FilterBy.None)
            {
                txtFilterSearch.Visible = cbIsActiveFilter.Visible = false;
                cbIsActiveFilter.SelectedIndex = 0;
                txtFilterSearch.Text = string.Empty;
            }
            else if (currentFilterBy == FilterBy.IsActive)
            {
                txtFilterSearch.Visible = false;
                txtFilterSearch.Text = string.Empty;
                cbIsActiveFilter.Visible = true;
                cbIsActiveFilter.SelectedIndex = 0;
                cbIsActiveFilter.Focus();
            }
            else
            {
                cbIsActiveFilter.Visible = false;
                cbIsActiveFilter.SelectedIndex = 0;
                txtFilterSearch.Visible = true;
                txtFilterSearch.Text = string.Empty;
                txtFilterSearch.Focus();
            }
        }

        private void RefreshDataWithFilter()
        {

            string SecuredFilterText = clsFilterHelper.SecureFilterText(txtFilterSearch.Text);

            if ((string.IsNullOrWhiteSpace(SecuredFilterText) && currentFilterBy != FilterBy.IsActive)
                 || currentFilterBy == FilterBy.None)
            {
                usersView.RowFilter = string.Empty;
                lblRecordsCount.SetRecordsCount(dgvManageUsers.Rows.Count);
                return;
            }

            if (currentFilterBy == FilterBy.IsActive)
            {
                switch (currentIsActiveFilter)
                {
                    case IsActiveFilter.Yes:
                        usersView.RowFilter = "[Is Active] = 1";
                        break;
                    case IsActiveFilter.No:
                        usersView.RowFilter = "[Is Active] = 0";
                        break;
                    default:
                        usersView.RowFilter = string.Empty;
                        break;
                }
            }
            else
            {
                switch (currentFilterBy)
                {
                    case FilterBy.UserID:
                        if (int.TryParse(SecuredFilterText, out int userId))
                            usersView.RowFilter = $"[User ID] = {userId}";
                        else
                            usersView.RowFilter = "1 = 0";
                        break;

                    case FilterBy.UserName:
                        usersView.RowFilter = $"UserName LIKE '{SecuredFilterText}%'";
                        break;

                    case FilterBy.PersonID:
                        if (int.TryParse(SecuredFilterText, out int personId))
                            usersView.RowFilter = $"[Person ID] = {personId}";
                        else
                            usersView.RowFilter = "1 = 0";
                        break;

                    case FilterBy.FullName:
                        usersView.RowFilter = $"[Full Name] LIKE '{SecuredFilterText}%'";
                        break;

                    default:
                        usersView.RowFilter = string.Empty;
                        break;
                }
            }

            lblRecordsCount.SetRecordsCount(dgvManageUsers.Rows.Count);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFilterBy = (FilterBy)cbFilterBy.SelectedIndex;
            RefreshFilterControls();
        }

        private void txtFilterSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshDataWithFilter();
        }

        private void txtFilterSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentFilterBy == FilterBy.UserID || currentFilterBy == FilterBy.PersonID)
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActiveFilter.SelectedIndex)
            {
                case 1:
                    currentIsActiveFilter = IsActiveFilter.Yes;
                    break;
                case 2:
                    currentIsActiveFilter = IsActiveFilter.No;
                    break;
                default:
                    currentIsActiveFilter = IsActiveFilter.All;
                    break;
            }
            RefreshDataWithFilter();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvManageUsers.CurrentRow.Cells[0].Value.ToString(), out int userId))
            {
                new frmUserInfo(userId).ShowDialog();
            }
        }

        private void AddNewUser_Click(object sender, EventArgs e)
        {
            var addUser = new frmAddEditUser(-1);
            addUser.RefreshManageUsersList += RefreshManageUsersList;
            addUser.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvManageUsers.CurrentRow.Cells[0].Value.ToString(), out int userId))
            {
                var editUser = new frmAddEditUser(userId);
                editUser.RefreshManageUsersList += RefreshManageUsersList;
                editUser.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageUsers.CurrentRow == null)
                return;

            int userId = Convert.ToInt32(dgvManageUsers.CurrentRow.Cells[0].Value);

            if (userId == clsGlobal.CurrentUser.UserID)
            {
                clsMessageService.ShowError("Can't delete this user because it is the current user.");
                return;
            }

            if (!clsMessageService.Confirm("Are you sure that you want to delete this user?"))
                return;

            if (clsUser.DeleteUser(userId))
            {
                clsMessageService.ShowSuccess("User deleted successfully.");
                RefreshManageUsersList();
            }
            else
            {
                clsMessageService.ShowError("User was not deleted successfully, because other data is connected with this user.");
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvManageUsers.CurrentRow.Cells[0].Value.ToString(), out int userId))
            {
                new frmChangePassword(userId).ShowDialog();
            }
        }
    }
}
