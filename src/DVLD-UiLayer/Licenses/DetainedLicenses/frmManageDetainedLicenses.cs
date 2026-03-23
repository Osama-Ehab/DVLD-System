using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.ApplicationTypes;
using DVLD_UiLayer.ExtensionsClasses;
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.Licenses;

namespace DVLD_UiLayer
{
    public partial class frmManageDetainedLicenses : Form
    {
        private enum enFilterBy : byte
        {
            None,
            DetainID,
            IsReleased,
            NationalNo,
            FullName,
            ReleaseApplicationID
        }

        private enum enIsReleasedFilterBy : byte
        {
            All,
            Yes,
            No
        }

        private enFilterBy _FilterBy;
        private enIsReleasedFilterBy _IsReleasedFilterBy;

        private DataTable _DetainedLicensesTable;
        private DataView _ManageDetainedLicensesView;

        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshManageDetainedLicensesList();
        }

        private void _RefreshManageDetainedLicensesList()
        {
            _DetainedLicensesTable = clsDetainedLicense.GetAllDetainedLicenses();
            _ManageDetainedLicensesView = _DetainedLicensesTable.DefaultView;

            dgvManageDetainedLicenses.DataSource = _ManageDetainedLicensesView;
            lblRecordsCount.SetRecordsCount(dgvManageDetainedLicenses.Rows.Count);

            if (dgvManageDetainedLicenses.Rows.Count == 0)
                return;

            dgvManageDetainedLicenses.Columns[7].Width = 240;

            cbFilterBy.SelectedIndex = 0;
            cbIsReleasedFilter.SelectedIndex = 0;
            _RefreshDataWithFilter();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure you want to close this window?", "Confirm Close"))
                return;

            this.Close();
        }

        private void _RefreshTxtFilterFormat()
        {
            bool isReleasedFilter = _FilterBy == enFilterBy.IsReleased;

            mtxtFilterSearch.Visible = !isReleasedFilter && _FilterBy != enFilterBy.None;
            cbIsReleasedFilter.Visible = isReleasedFilter;

            if (mtxtFilterSearch.Visible)
            {
                mtxtFilterSearch.Clear();
                mtxtFilterSearch.Focus();
            }
            else if (isReleasedFilter)
            {
                cbIsReleasedFilter.SelectedIndex = 0;
                cbIsReleasedFilter.Focus();
            }

            _ManageDetainedLicensesView.RowFilter = string.Empty;
            lblRecordsCount.SetRecordsCount(dgvManageDetainedLicenses.Rows.Count);
        }

        private void _RefreshDataWithFilter()
        {
            if ((_FilterBy != enFilterBy.IsReleased && string.IsNullOrWhiteSpace(mtxtFilterSearch.Text))
                || _FilterBy == enFilterBy.None)
            {
                _ManageDetainedLicensesView.RowFilter = string.Empty;
                lblRecordsCount.SetRecordsCount(dgvManageDetainedLicenses.Rows.Count);
                return;
            }

            string securedText = mtxtFilterSearch.Text.Trim().Replace("'", "''");

            switch (_FilterBy)
            {
                case enFilterBy.IsReleased:
                    switch (_IsReleasedFilterBy)
                    {
                        case enIsReleasedFilterBy.Yes:
                            _ManageDetainedLicensesView.RowFilter = "[Is Released] = 1";
                            break;
                        case enIsReleasedFilterBy.No:
                            _ManageDetainedLicensesView.RowFilter = "[Is Released] = 0";
                            break;
                        default:
                            _ManageDetainedLicensesView.RowFilter = string.Empty;
                            break;
                    }
                    break;

                case enFilterBy.DetainID:
                    if (int.TryParse(mtxtFilterSearch.Text, out int detainID))
                        _ManageDetainedLicensesView.RowFilter = $"[D.ID] = {detainID}";
                    else
                        _ManageDetainedLicensesView.RowFilter = "1 = 0";
                    break;

                case enFilterBy.NationalNo:
                    _ManageDetainedLicensesView.RowFilter = $"[N.No.] LIKE '{securedText}%'";
                    break;

                case enFilterBy.FullName:
                    _ManageDetainedLicensesView.RowFilter = $"[Full Name] LIKE '{securedText}%'";
                    break;

                case enFilterBy.ReleaseApplicationID:
                    if (int.TryParse(mtxtFilterSearch.Text, out int releaseAppId))
                        _ManageDetainedLicensesView.RowFilter = $"[Release App.LicenseID] = {releaseAppId}";
                    else
                        _ManageDetainedLicensesView.RowFilter = "1 = 0";
                    break;

                default:
                    _ManageDetainedLicensesView.RowFilter = string.Empty;
                    break;
            }

            lblRecordsCount.SetRecordsCount(dgvManageDetainedLicenses.Rows.Count);
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
            if ((_FilterBy == enFilterBy.DetainID || _FilterBy == enFilterBy.ReleaseApplicationID))
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }

        private void cbIsReleasedFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IsReleasedFilterBy = (enIsReleasedFilterBy)cbIsReleasedFilter.SelectedIndex;
            _RefreshDataWithFilter();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense form = new frmDetainLicense();
            form.RefreshManageDetainedLicensesList += _RefreshManageDetainedLicensesList;
            form.ShowDialog();
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmAddEditLicenseApplication form = new frmAddEditLicenseApplication(
                clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense);
            form.RefreshManageBasicApplicationsList += _RefreshManageDetainedLicensesList;
            form.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow == null)
                return;

            string nationalNo = dgvManageDetainedLicenses.CurrentRow.Cells[6].Value?.ToString();
            if (string.IsNullOrEmpty(nationalNo))
                return;
            frmShowPersonLicenseHistory form = new frmShowPersonLicenseHistory(nationalNo);
            form.RefereshLocalDL_AppsData += frmManageDetainedLicenses_Load;
            form.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow == null)
                return;

            string nationalNo = dgvManageDetainedLicenses.CurrentRow.Cells[6].Value?.ToString();
            if (string.IsNullOrEmpty(nationalNo))
                return;

            frmPersonDetails form = new frmPersonDetails(nationalNo);
            form.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageDetainedLicenses.CurrentRow.Cells[1].Value.ToString(), out int licenseId))
                return;

            frmLicenseInfo form = new frmLicenseInfo(new DTOs.LicenseInfoParameters { LicenseId = licenseId });
            form.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow == null)
                return;

            string nationalNo = dgvManageDetainedLicenses.CurrentRow.Cells[6].Value?.ToString();
            if (string.IsNullOrEmpty(nationalNo))
                return;

            frmShowPersonLicenseHistory form = new frmShowPersonLicenseHistory(nationalNo);
            form.RefereshLocalDL_AppsData += frmManageDetainedLicenses_Load;
            form.ShowDialog();
        }

        private void releaseDetainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageDetainedLicenses.CurrentRow.Cells[1].Value.ToString(), out int licenseId))
                return;

            frmAddEditLicenseApplication form = new frmAddEditLicenseApplication(
                clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense, licenseId);
            form.RefreshManageBasicApplicationsList += _RefreshManageDetainedLicensesList;
            form.ShowDialog();
        }

        private void cmsManageDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            if (dgvManageDetainedLicenses.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }

            bool isReleased = (bool)dgvManageDetainedLicenses.CurrentRow.Cells[3].Value;
            releaseDetainToolStripMenuItem.Enabled = !isReleased;
        }
    }
}
