using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.Licenses;

namespace DVLD_UiLayer
{
    public partial class frmManageDrivers : Form
    {
        private enum FilterBy { None, DriverID, PersonID, NationalNo, FullName }

        private FilterBy _filterBy;
        private DataTable _driversTable;
        private DataView _driversView;

        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void SetRecordsCountLabel()
        {
            lblRecordsCount.Text = dgvManageDrivers.Rows.Count.ToString();
        }

        private async Task RefreshDriversListAsync()
        {
            // Optional async pattern; wrap GetAll in Task.Run if it's synchronous.
            _driversTable = await Task.Run(() => clsDriver.GetAll());
            _driversView = _driversTable.DefaultView;
            dgvManageDrivers.DataSource = _driversView;

            SetRecordsCountLabel();

            if (dgvManageDrivers.Rows.Count == 0)
                return;

            if (dgvManageDrivers.Columns.Contains("Full Name"))
                dgvManageDrivers.Columns["Full Name"].Width = 270;

            RefreshDataWithFilter();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshFilterTextboxState()
        {
            mtxtFilterSearch.Visible = (_filterBy != FilterBy.None);
            mtxtFilterSearch.Text = string.Empty;
            mtxtFilterSearch.Focus();
        }

        private void RefreshDataWithFilter()
        {
            if (_driversView == null)
                return;

            var text = mtxtFilterSearch.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(text) || _filterBy == FilterBy.None)
            {
                _driversView.RowFilter = string.Empty;
                SetRecordsCountLabel();
                return;
            }

            text = text.Replace("'", "''"); // Escape single quotes for DataView filter safety.

            switch (_filterBy)
            {
                case FilterBy.DriverID:
                    if (int.TryParse(text, out int driverId))
                        _driversView.RowFilter = $"[Driver ID] = {driverId}";
                    else
                        _driversView.RowFilter = "1 = 0";
                    break;

                case FilterBy.PersonID:
                    if (int.TryParse(text, out int personId))
                        _driversView.RowFilter = $"[Person ID] = {personId}";
                    else
                        _driversView.RowFilter = "1 = 0";
                    break;

                case FilterBy.NationalNo:
                    _driversView.RowFilter = $"[National No.] LIKE '{text}%'";
                    break;

                case FilterBy.FullName:
                    _driversView.RowFilter = $"[Full Name] LIKE '{text}%'";
                    break;

                default:
                    _driversView.RowFilter = string.Empty;
                    break;
            }

            SetRecordsCountLabel();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filterBy = (FilterBy)cbFilterBy.SelectedIndex;
            RefreshFilterTextboxState();
        }

        private void mtxtFilterSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshDataWithFilter();
        }

        private void mtxtFilterSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_filterBy == FilterBy.DriverID || _filterBy == FilterBy.PersonID)
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private async void frmManageDrivers_Load(object sender, EventArgs e)
        {
            await RefreshDriversListAsync();
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnSearchDriverLicenseHistory_Click(object sender, EventArgs e)
        {
            using (var licenseHistory = new frmShowPersonLicenseHistory())
            {
                licenseHistory.RefereshLocalDL_AppsData += frmManageDrivers_Load;
                licenseHistory.ShowDialog();
                licenseHistory.RefereshLocalDL_AppsData -= frmManageDrivers_Load;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageDrivers.CurrentRow == null)
                return;

            if (int.TryParse(dgvManageDrivers.CurrentRow.Cells[1].Value.ToString(), out int personId))
            {
                using (var licenseHistory = new frmShowPersonLicenseHistory(personId))
                {
                    licenseHistory.RefereshLocalDL_AppsData += frmManageDrivers_Load;
                    licenseHistory.ShowDialog();
                    licenseHistory.RefereshLocalDL_AppsData -= frmManageDrivers_Load;
                }
            }
        }
    }
}

