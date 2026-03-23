using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.ExtensionsClasses;
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.InternationalLicenses;
using DVLD_UiLayer.Licenses;

namespace DVLD_UiLayer.UserControls
{
    public partial class ctrDriverLicenses : UserControl
    {
        private int _driverId = -1;
        private clsDriver _driver;
        private DataGridView _currentGrid;

        public ctrDriverLicenses()
        {
            InitializeComponent();
        }

        public int DriverId => _driverId;
        public clsDriver SelectedDriverInfo => _driver;

        #region Load Methods

        public void LoadByPersonId(int personId)
        
        {
            _driver = clsDriver.FindByPersonID(personId);
            if (_driver == null)
            {
                this.Clear();
                clsMessageService.ShowWarning("No driver found for the provided Person LicenseID.", "Driver Not Found");
                return;
            }

            _driverId = _driver.DriverID;
            LoadAllLicenses();
        }

        public void LoadByDriverId(int driverId)
        {
            _driver = clsDriver.FindByDriverID(driverId);
            if (_driver == null)
            {
                this.Clear();
                clsMessageService.ShowError("Driver not found.", "Error");
                return;
            }

            _driverId = _driver.DriverID;
            LoadAllLicenses();
        }

        private void LoadAllLicenses()
        {
            LoadLicenses(
                _dgvManageLocalDriverLicenses,
                clsLicense.GetDriverLicenses,
                lblLocalDriverLicensesRecordsCount,
                grid =>
                {
                    grid.Columns[0].Width = 50;
                    grid.Columns[1].Width = 60;
                    grid.Columns[2].Width = 250;
                    grid.Columns[3].Width = 170;
                    grid.Columns[4].Width = 170;
                });

            LoadLicenses(
                _dgvManageInternationlDriverLicenses,
                clsInternationalLicense.GetDriverInternationalLicenses,
                lblInternationalDriverLicensesRecordsCount,
                grid =>
                {
                    grid.Columns[3].Width = 200;
                    grid.Columns[4].Width = 200;
                });
        }

        private void LoadLicenses(
            DataGridView grid,
            Func<int, object> getData,
            Label recordCountLabel,
            Action<DataGridView> configureColumns)
        {
            if (_driverId <= 0) return;

            var data = getData(_driverId);
            grid.DataSource = data;
            recordCountLabel.SetRecordsCount(grid.Rows.Count);

            if (grid.Columns.Count > 0)
                configureColumns(grid);
        }

        #endregion

        #region UI Actions

        private void ShowLicenseInfo_Click(object sender, EventArgs e)
        {
            if (_currentGrid?.CurrentRow == null)
            {
                clsMessageService.ShowWarning("Please select a license first.");
                return;
            }

            if (!int.TryParse(_currentGrid.CurrentRow.Cells[0].Value?.ToString(), out int licenseId))
            {
                clsMessageService.ShowError("Invalid license selected.");
                return;
            }

            if (_currentGrid == _dgvManageLocalDriverLicenses)
            {
                using (var form = new frmLicenseInfo(new DTOs.LicenseInfoParameters { LicenseId = licenseId }))
                    form.ShowDialog();
            }
            else
            {
                using (var form = new frmInternationalLicenseInfo(licenseId))
                    form.ShowDialog();
            }
        }

        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _currentGrid = sender as DataGridView;
        }

        public void Clear()
        {
            _dgvManageLocalDriverLicenses.DataSource = null;
            _dgvManageInternationlDriverLicenses.DataSource = null;
            lblLocalDriverLicensesRecordsCount.SetRecordsCount(0);
            lblInternationalDriverLicensesRecordsCount.SetRecordsCount(0);
        }

        #endregion
    }
}
