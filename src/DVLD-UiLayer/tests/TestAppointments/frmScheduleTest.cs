using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_UiLayer.HelperClasses;

namespace DVLD_UiLayer.TestAppointments
{
    public partial class frmScheduleTest : Form
    {

        public delegate void ReloadLocalDL_AppsData();
        public event ReloadLocalDL_AppsData ReloadData;
        private int _TestAppointmentID = -1;
        private int _LocalDL_AppID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LocalDL_AppID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;

        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (!clsMessageService.Confirm("Are you sure that you want to close form And ignore changes?")) return;

            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ScheduleTestCard.ReloadData += () => ReloadData.Invoke();
            ScheduleTestCard.TestTypeID = _TestTypeID;
            ScheduleTestCard.LoadInfo(_LocalDL_AppID, _TestAppointmentID);
        }

    
    }
}
