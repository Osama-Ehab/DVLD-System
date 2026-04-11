using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.HelperClasses;
using DVLD_UiLayer.Licenses;
using DVLD_UiLayer.TestAppointments;
using static DVLD_BusinessLayer.clsTestType;

namespace DVLD_UiLayer
{
    public partial class frmManageLocalDL_Apps : Form
    {
        private enum enFilterBy
        {
            None,
            LocalDL_AppID,
            NationalNo,
            FullName,
            Status
        };

        private enum enStatusFilterBy
        {
            All,
            New,
            Cancelled,
            Completed
        }

        private enStatusFilterBy _StatusFilterBy;
        private enFilterBy _FilterBy;
        private DataTable _LocalDL_AppsTable;
        private DataView _ManageLocalDL_AppsView;

        public frmManageLocalDL_Apps()
        {
            InitializeComponent();
            
            tsmScheduleVisionTest.Tag = clsTestType.enTestType.VisionTest;
            tsmScheduleWrittenTest.Tag = clsTestType.enTestType.WrittenTest;
            tsmScheduleStreetTest.Tag = clsTestType.enTestType.StreetTest;
        }

        private void frmManageLocalDL_Apps_Load(object sender, EventArgs e)
        {
            ReloadManageLocalDL_AppsList();
        }

        private void ReloadManageLocalDL_AppsList()
        {
            _LocalDL_AppsTable = clsLocalDL_App.GetAllAsDataTable();
            _ManageLocalDL_AppsView = _LocalDL_AppsTable.DefaultView;

            dgvManageLocalDL_Apps.DataSource = _LocalDL_AppsTable;
            lblRecordsCount.Text = dgvManageLocalDL_Apps.Rows.Count.ToString();

            // 🛡️ Guard clause: no data
            if (dgvManageLocalDL_Apps.Rows.Count == 0)
                return;

            dgvManageLocalDL_Apps.Columns[1].Width = 300;
            dgvManageLocalDL_Apps.Columns[3].Width = 270;
            dgvManageLocalDL_Apps.Columns[4].Width = 140;
            dgvManageLocalDL_Apps.Columns[6].Width = 100;

            cbFindBy.SelectedIndex = 0;
            _RefreshDataWithFilter();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (clsMessageService.Confirm("Are you sure you want to close this window?", "Confirm Close"))
            {
                this.Close();
            }
        }

        private void _RefreshTxtFilterFormat()
        {
            if (_FilterBy == enFilterBy.None)
                txtFilterSearch.Visible = cbStatusFilter.Visible = false;
            else
                txtFilterSearch.Visible = !(cbStatusFilter.Visible = _FilterBy == enFilterBy.Status);
 
            if (txtFilterSearch.Visible)
            {
                txtFilterSearch.Text = string.Empty;
                txtFilterSearch.Focus();
            }
            else
            {
                cbStatusFilter.SelectedIndex = 0;
                cbStatusFilter.Focus();
            }

            _ManageLocalDL_AppsView.RowFilter = string.Empty;
            lblRecordsCount.Text = dgvManageLocalDL_Apps.Rows.Count.ToString();
        }

        private void _RefreshDataWithFilter()
        {
            // 🛡️ Guard clause: empty search or no filter
            if (string.IsNullOrWhiteSpace(txtFilterSearch.Text) || _FilterBy == enFilterBy.None)
            {
                _ManageLocalDL_AppsView.RowFilter = string.Empty;
                lblRecordsCount.Text = dgvManageLocalDL_Apps.Rows.Count.ToString();
                return;
            }

            if (_FilterBy == enFilterBy.Status)
            {
                switch (_StatusFilterBy)
                {
                    case enStatusFilterBy.New:
                        _ManageLocalDL_AppsView.RowFilter = "Status = 'New'";
                        break;
                    case enStatusFilterBy.Cancelled:
                        _ManageLocalDL_AppsView.RowFilter = "Status = 'Cancelled'";
                        break;
                    case enStatusFilterBy.Completed:
                        _ManageLocalDL_AppsView.RowFilter = "Status = 'Completed'";
                        break;
                    default:
                        _ManageLocalDL_AppsView.RowFilter = string.Empty;
                        break;
                }

                lblRecordsCount.Text = dgvManageLocalDL_Apps.Rows.Count.ToString();
                return;
            }

            string txtFilterSearchSecured = txtFilterSearch.Text.Trim().Replace("'", "''");

            switch (_FilterBy)
            {
                case enFilterBy.LocalDL_AppID:
                    if (!int.TryParse(txtFilterSearch.Text, out int LocalDL_AppId))
                    {
                        _ManageLocalDL_AppsView.RowFilter = "1 = 0";
                        lblRecordsCount.Text = dgvManageLocalDL_Apps.Rows.Count.ToString();
                        return;
                    }
                    _ManageLocalDL_AppsView.RowFilter = $"[L.D.L.AppID] = {LocalDL_AppId}";
                    break;

                case enFilterBy.NationalNo:
                    _ManageLocalDL_AppsView.RowFilter = $"[National No.] LIKE '{txtFilterSearchSecured}%'";
                    break;

                case enFilterBy.FullName:
                    _ManageLocalDL_AppsView.RowFilter = $"[Full ClassName] LIKE '{txtFilterSearchSecured}%'";
                    break;

                default:
                    _ManageLocalDL_AppsView.RowFilter = string.Empty;
                    break;
            }

            lblRecordsCount.Text = dgvManageLocalDL_Apps.Rows.Count.ToString();
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
            if (_FilterBy == enFilterBy.LocalDL_AppID && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _StatusFilterBy = (enStatusFilterBy)cbStatusFilter.SelectedIndex;
            _RefreshDataWithFilter();
        }

        private void AddNewLocalDL_App_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDL_App addNewForm = new frmAddEditLocalDL_App();
            addNewForm.RefreshManageLocalDL_AppsList += ReloadManageLocalDL_AppsList;
            addNewForm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageLocalDL_Apps.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageLocalDL_Apps.CurrentRow.Cells[0].Value.ToString(), out int localDL_AppID))
                return;

            frmAddEditLocalDL_App editForm = new frmAddEditLocalDL_App(localDL_AppID);
            editForm.RefreshManageLocalDL_AppsList += ReloadManageLocalDL_AppsList;
            editForm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageLocalDL_Apps.CurrentRow == null)
                return;

            if (!clsMessageService.Confirm("Are you sure that you want to delete this LocalDL_App?"))
                return;

            if (!int.TryParse(dgvManageLocalDL_Apps.CurrentRow.Cells[0].Value.ToString(), out int localDL_AppID))
                return;

            if (clsLocalDL_App.Delete(localDL_AppID))
            {
                clsMessageService.ShowSuccess("LocalDL_App deleted successfully.");
                ReloadManageLocalDL_AppsList();
                return;
            }

            clsMessageService.ShowError("LocalDL_App could not be deleted because related data exists.");
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageLocalDL_Apps.CurrentRow == null)
                return;

            if (!clsMessageService.Confirm("Are you sure that you want to cancel this LocalDL_App?"))
                return;

            if (!int.TryParse(dgvManageLocalDL_Apps.CurrentRow.Cells[0].Value.ToString(), out int localDL_AppId))
                return;

            if (!clsLocalDL_App.Cancel(localDL_AppId))
            {
                clsMessageService.ShowError("Local Driving License Application could not be cancelled.");
                return;
            }

            clsMessageService.ShowSuccess("Local Driving License Application cancelled successfully.");
            ReloadManageLocalDL_AppsList();
        }

        private void ScheduleTest_Click(object sender, EventArgs e)
        {
            if (dgvManageLocalDL_Apps.CurrentRow == null)
                return;

            if (!(sender is ToolStripMenuItem tm))
                return;

            if (!int.TryParse(dgvManageLocalDL_Apps.CurrentRow.Cells[0].Value.ToString(), out int localDL_AppId))
                return;

            var testType = (clsTestType.enTestType)tm.Tag;

            FrmTestAppointments scheduleForm = new FrmTestAppointments(localDL_AppId, testType);
            scheduleForm.ReloadData += ReloadManageLocalDL_AppsList;
            scheduleForm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageLocalDL_Apps.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageLocalDL_Apps.CurrentRow.Cells[0].Value.ToString(), out int localDL_AppId))
                return;

            frmLicenseInfo licenseInfo = new frmLicenseInfo(new DTOs.LicenseInfoParameters { LocalDLAppId = localDL_AppId });
            licenseInfo.ShowDialog();
        }

        private void showPersonLiceseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageLocalDL_Apps.CurrentRow == null)
                return;

            string nationalNo = dgvManageLocalDL_Apps.CurrentRow.Cells["National No."].Value?.ToString();
            if (string.IsNullOrEmpty(nationalNo))
                return;

            frmShowPersonLicenseHistory historyForm = new frmShowPersonLicenseHistory(nationalNo);
            historyForm.RefereshLocalDL_AppsData += frmManageLocalDL_Apps_Load;
            historyForm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageLocalDL_Apps.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageLocalDL_Apps.CurrentRow.Cells[0].Value.ToString(), out int localDL_AppId))
                return;

            frmShowLocalDL_AppDetails detailsForm = new frmShowLocalDL_AppDetails(localDL_AppId);
            detailsForm.ShowDialog();
        }

        private void cmsManageLocalDL_Apps_Opening(object sender, CancelEventArgs e)
        {
            if (dgvManageLocalDL_Apps.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }

            if (!int.TryParse(dgvManageLocalDL_Apps.CurrentRow.Cells[0].Value.ToString(), out int appId))
            {
                e.Cancel = true;
                return;
            }

            clsLocalDL_App localApp = clsLocalDL_App.Find(appId);
            if (localApp == null)
            {
                e.Cancel = true;
                return;
            }

            byte totalPassedTests = byte.Parse(dgvManageLocalDL_Apps.CurrentRow.Cells["Passed Tests"].Value.ToString());
            bool licenseExists = localApp.IsLicenseIssued();

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (totalPassedTests == 3) && !licenseExists;
            showLicenseToolStripMenuItem.Enabled = licenseExists;

            bool IsNewStatus = localApp.ApplicationInfo.ApplicationStatus == clsApplication.enApplicationStatus.New;

            editToolStripMenuItem.Enabled = !licenseExists && IsNewStatus;
            cancelApplicationToolStripMenuItem.Enabled = IsNewStatus;
            deleteToolStripMenuItem.Enabled = !localApp.RelatedWithAppointmentsInSystem();

            bool PassedVisionTest = localApp.DoesPassTestType(clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = localApp.DoesPassTestType(clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = localApp.DoesPassTestType(clsTestType.enTestType.StreetTest);

            scheduleTestsMenue.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && IsNewStatus;
            if (!scheduleTestsMenue.Enabled)
                return;

            tsmScheduleVisionTest.Enabled = !PassedVisionTest;
            tsmScheduleWrittenTest.Enabled = PassedVisionTest && !PassedWrittenTest;
            tsmScheduleStreetTest.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvManageLocalDL_Apps.CurrentRow == null)
                return;

            if (!int.TryParse(dgvManageLocalDL_Apps.CurrentRow.Cells[0].Value.ToString(), out int localDL_AppID))
                return;

            frmIssueDriverLicenseForTheFirstTime issueForm = new frmIssueDriverLicenseForTheFirstTime(localDL_AppID);
            issueForm.RefreshManageLocalDL_AppsList += frmManageLocalDL_Apps_Load;
            issueForm.ShowDialog();
        }
    }
}
