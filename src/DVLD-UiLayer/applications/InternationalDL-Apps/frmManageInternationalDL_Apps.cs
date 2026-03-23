using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.ExtensionsClasses;
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.InternationalLicenses;
using DVLD_UiLayer.Licenses;
using DVLD_UiLayer.TestAppointments;

namespace DVLD_UiLayer
{
    public partial class frmManageInternationalDL_Apps : Form
    {
        private enum enFilterBy : byte
        {
            None,
            InternationalDL_AppID,
            DriverID,
            LocalLicenseID,
            IsActive
        }

        private enum enIsActiveFilterBy : byte
        {
            All,
            Active,
            NotActive
        }

        private enFilterBy _FilterBy;
        private enIsActiveFilterBy _IsActiveFilterBy;

        private DataTable _InternationalDL_AppsTable;
        private DataView _ManageInternationalDL_AppsView;

        public frmManageInternationalDL_Apps()
        {
            InitializeComponent();
        }

        private void frmManageInternationalDL_Apps_Load(object sender, EventArgs e)
        {
            _RefreshManageInternationalDL_AppsList();
        }

        private void _RefreshManageInternationalDL_AppsList()
        {
            _InternationalDL_AppsTable = clsInternationalLicense.GetAllInternationalLicenses();
            _ManageInternationalDL_AppsView = _InternationalDL_AppsTable.DefaultView;

            dgvManageInternationalDL_Apps.DataSource = _ManageInternationalDL_AppsView;
            lblRecordsCount.SetRecordsCount(dgvManageInternationalDL_Apps.Rows.Count);

            if (dgvManageInternationalDL_Apps.Rows.Count == 0)
                return;

            dgvManageInternationalDL_Apps.Columns[4].Width = 140;
            dgvManageInternationalDL_Apps.Columns[5].Width = 140;

            cbFindBy.SelectedIndex = 0;
            cbIsActiveFilter.SelectedIndex = 0;

            _RefreshDataWithFilter();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure you want to close this window?", "Confirm Close"))
                return;

            Close();
        }

        private void _RefreshTxtFilterFormat()
        {
            bool isActiveFilter = _FilterBy == enFilterBy.IsActive;

            txtFilterSearch.Visible = !isActiveFilter && _FilterBy != enFilterBy.None;
            cbIsActiveFilter.Visible = isActiveFilter;

            if (txtFilterSearch.Visible)
            {
                txtFilterSearch.Clear();
                txtFilterSearch.Focus();
            }
            else if (isActiveFilter)
            {
                cbIsActiveFilter.SelectedIndex = 0;
                cbIsActiveFilter.Focus();
            }

            _ManageInternationalDL_AppsView.RowFilter = string.Empty;
            lblRecordsCount.SetRecordsCount(dgvManageInternationalDL_Apps.Rows.Count);
        }

        private void _RefreshDataWithFilter()
        {
            if ((_FilterBy != enFilterBy.IsActive && string.IsNullOrWhiteSpace(txtFilterSearch.Text))
                || _FilterBy == enFilterBy.None)
            {
                _ManageInternationalDL_AppsView.RowFilter = string.Empty;
                lblRecordsCount.SetRecordsCount(dgvManageInternationalDL_Apps.Rows.Count);
                return;
            }

            string securedText = txtFilterSearch.Text.Trim().Replace("'", "''");

            switch (_FilterBy)
            {
                case enFilterBy.IsActive:
                    switch (_IsActiveFilterBy)
                    {
                        case enIsActiveFilterBy.Active:
                            _ManageInternationalDL_AppsView.RowFilter = "[Is Active] = true";
                            break;
                        case enIsActiveFilterBy.NotActive:
                            _ManageInternationalDL_AppsView.RowFilter = "[Is Active] = false";
                            break;
                        default:
                            _ManageInternationalDL_AppsView.RowFilter = string.Empty;
                            break;
                    }
                    break;

                case enFilterBy.InternationalDL_AppID:
                    if (int.TryParse(securedText, out int intlAppId))
                        _ManageInternationalDL_AppsView.RowFilter = $"[Int.License ID] = {intlAppId}";
                    else
                        _ManageInternationalDL_AppsView.RowFilter = "1 = 0";
                    break;

                case enFilterBy.DriverID:
                    if (int.TryParse(securedText, out int driverId))
                        _ManageInternationalDL_AppsView.RowFilter = $"[Driver ID] = {driverId}";
                    else
                        _ManageInternationalDL_AppsView.RowFilter = "1 = 0";
                    break;

                case enFilterBy.LocalLicenseID:
                    if (int.TryParse(securedText, out int localLicenseId))
                        _ManageInternationalDL_AppsView.RowFilter = $"[L.License ID] = {localLicenseId}";
                    else
                        _ManageInternationalDL_AppsView.RowFilter = "1 = 0";
                    break;

                default:
                    _ManageInternationalDL_AppsView.RowFilter = string.Empty;
                    break;
            }

            lblRecordsCount.SetRecordsCount(dgvManageInternationalDL_Apps.Rows.Count);
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterBy = (enFilterBy)cbFindBy.SelectedIndex;
            _RefreshTxtFilterFormat();
        }

        private void txtFilterSearch_TextChanged(object sender, EventArgs e)
        {
            _RefreshDataWithFilter();
        }

        private void txtFilterSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterBy == enFilterBy.InternationalDL_AppID ||
                _FilterBy == enFilterBy.DriverID ||
                _FilterBy == enFilterBy.LocalLicenseID)
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IsActiveFilterBy = (enIsActiveFilterBy)cbIsActiveFilter.SelectedIndex;
            _RefreshDataWithFilter();
        }

        private void AddNewInternationalDL_App_Click(object sender, EventArgs e)
        {
            var form = new frmAddEditLicenseApplication(clsApplication.enApplicationType.NewInternationalLicense);
            form.RefreshManageBasicApplicationsList += _RefreshManageInternationalDL_AppsList;
            form.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageInternationalDL_Apps.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageInternationalDL_Apps.CurrentRow.Cells[0].Value.ToString(), out int intlLicenseId))
                return;

            var form = new frmInternationalLicenseInfo(intlLicenseId);
            form.ShowDialog();
        }

        private void showPersonLiceseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageInternationalDL_Apps.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageInternationalDL_Apps.CurrentRow.Cells[2].Value.ToString(), out int driverId))
                return;

            var driver = clsDriver.FindByDriverID(driverId);
            if (driver == null)
                return;

            var form = new frmShowPersonLicenseHistory(driver.PersonID);
            form.RefereshLocalDL_AppsData += frmManageInternationalDL_Apps_Load;
            form.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageInternationalDL_Apps.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageInternationalDL_Apps.CurrentRow.Cells[1].Value.ToString(), out int applicationId))
                return;

            var form = new frmShowInternationalDL_AppDetails(applicationId);
            form.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageInternationalDL_Apps.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageInternationalDL_Apps.CurrentRow.Cells[2].Value.ToString(), out int driverId))
                return;

            var driver = clsDriver.FindByDriverID(driverId);
            if (driver == null)
                return;

            var form = new frmPersonDetails(driver.PersonID);
            form.ShowDialog();
        }

        private void cmsManageInternationalDL_Apps_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = dgvManageInternationalDL_Apps.CurrentRow == null;
        }
    }
}
