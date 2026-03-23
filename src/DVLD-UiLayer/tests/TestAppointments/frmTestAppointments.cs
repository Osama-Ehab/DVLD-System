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
using DVLD_UiLayer.Tests.TestAppointments;

namespace DVLD_UiLayer.TestAppointments
{
    public partial class FrmTestAppointments : Form
    {
        public delegate void ReloadLocalDL_AppsData();
        public event ReloadLocalDL_AppsData ReloadData;
        private clsLocalDL_App _LocalDL_App;
        private int _LocalDL_AppID { get; set; }
        private clsTestType.enTestType _TestTypeID { get; set; }

        public FrmTestAppointments(int LocalDL_AppID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _LocalDL_AppID = LocalDL_AppID;
            _TestTypeID = TestTypeID;
        }

        protected void frmTestAppointments_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            LoadTestMode();

            _LocalDL_App = clsLocalDL_App.Find(_LocalDL_AppID);

            // ✅ Guard clause
            if (_LocalDL_App == null)
            {
                clsMessageService.ShowError("Failed to load Local Driving License Application data.");
                return;
            }

            LocalDL_AppCard.LoadLocalDL_AppInfo(_LocalDL_AppID);
            dgvManageAppointments.DataSource = clsTestAppointment.GetByLocalDLAppIDAsDataTable(_LocalDL_AppID, _TestTypeID);
            lblRecordsCount.SetRecordsCount(dgvManageAppointments.RowCount);
            if (dgvManageAppointments.RowCount <= 0) return;

            dgvManageAppointments.Columns[0].Width = 150;
            dgvManageAppointments.Columns[1].Width = 200;
            dgvManageAppointments.Columns[2].Width = 100;
            dgvManageAppointments.Columns[3].Width = 100;
        }

        private void LoadTestMode()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    this.Text = lblTestType.Text = "Vision Test Appointments";
                    pbTestType.Image = ImageResources.Vision_512;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    this.Text = lblTestType.Text = "Written Test Appointments";
                    pbTestType.Image = ImageResources.Written_Test_512;
                    break;

                case clsTestType.enTestType.StreetTest:
                    this.Text = lblTestType.Text = "Street Test Appointments";
                    pbTestType.Image = ImageResources.driving_test_512;
                    break;

                default:
                    this.Text = lblTestType.Text = "Test Appointments";
                    pbTestType.Image = null;
                    break;
            }
        }

        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {
            // ✅ Guard clause: Ensure app data exists
            if (_LocalDL_App == null)
            {
                clsMessageService.ShowError("Local DL application not found.");
                return;
            }

            // ✅ Guard clause: Passed test already
            if (_LocalDL_App.DoesPassTestType(_TestTypeID))
            {
                clsMessageService.ShowError("This Person already passed this test before. You can only retake failed tests.");
                return;
            }

            // ✅ Guard clause: Active appointment
            if (_LocalDL_App.HasActiveAppointment(_TestTypeID))
            {
                clsMessageService.ShowError("This Person already has an active appointment for this test. You cannot add a new one.");
                return;
            }

            // ✅ Proceed safely
            var scheduleTest = new frmScheduleTest(_LocalDL_AppID, _TestTypeID);
            scheduleTest.ReloadData += LoadData;
            scheduleTest.ShowDialog();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            // ✅ Use centralized confirmation method
            if (!clsMessageService.Confirm("Are you sure you want to close the form and ignore any changes?", "Confirm Close"))
                return;

            ReloadData.Invoke();
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dgvManageAppointments.CurrentRow?.Cells[0].Value?.ToString(), out int TestAppointmentID))
            {
                clsMessageService.ShowError("Invalid appointment selection.");
                return;
            }

            var scheduleTest = new frmScheduleTest(_LocalDL_AppID, _TestTypeID, TestAppointmentID);
            scheduleTest.ReloadData += LoadData;
            scheduleTest.ShowDialog();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(dgvManageAppointments.CurrentRow?.Cells[0].Value?.ToString(), out int TestAppointmentID))
            {
                clsMessageService.ShowError("Invalid test selection.");
                return;
            }

            var takeTest = new frmTakeTest(TestAppointmentID, _TestTypeID);
            takeTest.ReloadData += LoadData;
            takeTest.ShowDialog();
        }

        private void cmsManageAppointment_Apps_Opening(object sender, CancelEventArgs e)
        {
            if (dgvManageAppointments.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }

            bool isLocked = bool.Parse(dgvManageAppointments.CurrentRow.Cells["Is Locked"].Value.ToString());
            DateTime appointmentDate = DateTime.Parse(dgvManageAppointments.CurrentRow.Cells["Appointment Date"].Value.ToString());

            // ✅ Guard clause simplifies logic
            takeTestToolStripMenuItem.Enabled = !(isLocked || appointmentDate > DateTime.Now);
        }
    }
}
