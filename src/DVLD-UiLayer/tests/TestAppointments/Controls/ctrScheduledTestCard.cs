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
using System.IO;
using static DVLD_BusinessLayer.clsTestType;
using DVLD_UiLayer.ExtensionsClasses;
using System.Resources;

namespace DVLD_UiLayer.Tests.TestAppointments.Controls
{
    public partial class ctrScheduledTestCard : UserControl
    {
        public ctrScheduledTestCard()
        {
            InitializeComponent();
        }

        private int _TestAppointmentID;
        public int TestAppointmentID { get { return _TestAppointmentID; } }
        private clsTestAppointment _TestAppointment;

        private clsLocalDL_App _LocalDL_App;
        private int _LocalDL_AppID { get; set; }
        public int LocalDL_AppID { get { return _LocalDL_AppID; } }

        private int _TestID = -1;
        public int TestID { get { return _TestID; } }

        private clsTestType.enTestType _TestTypeID { get; set; }
        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        gbTestType.Text = "Vision Test";
                        lblTitle.Text = "Scheduled Vision Test";
                        pbTestType.Image = ImageResources.Vision_512;
                        break;
                    case clsTestType.enTestType.WrittenTest:
                        gbTestType.Text = "Written Test";
                        lblTitle.Text = "Scheduled Written Test";
                        pbTestType.Image = ImageResources.Written_Test_512;
                        break;
                    case clsTestType.enTestType.StreetTest:
                        gbTestType.Text = "Street Test";
                        lblTitle.Text = "Scheduled Street Test";
                        pbTestType.Image = ImageResources.driving_test_512;
                        break;
                    default:
                        break;
                }
            }
        }

        private byte _Trial;

        public void LoadInfo(int TestAppointmentID)
        {
            _TestAppointment = clsTestAppointment.Find(TestAppointmentID);
            if (_TestAppointment != null)
            {
                _TestAppointmentID = TestAppointmentID;
                _TestTypeID = _TestAppointment.TestTypeID;
                _TestID = _TestAppointment.TestID;

                _LocalDL_AppID = _TestAppointment.LocalDrivingLicenseApplicationID;
                this._LocalDL_App = clsLocalDL_App.Find(_LocalDL_AppID);
                if (this._LocalDL_App != null)
                {
                    _LoadLocalDL_AppInfoAfterFind();
                }
                else
                {
                    ResetDefaultData();
                }
            }

        }

        private void _LoadLocalDL_AppInfoAfterFind()
        {
            if (this._LocalDL_App != null)
            {
                _Trial = _LocalDL_App.TotalTrialsPerTest(_TestTypeID);
                _LocalDL_AppID = this._LocalDL_App.LocalDLAppID;
                lblLocalDL_AppID.Text = _LocalDL_App.LocalDLAppID.ToString();
                lblLicenseClass.Text = _LocalDL_App.LicenseClassInfo.ClassName;
                lblApplicantName.Text = _LocalDL_App.ApplicationInfo.ApplicantFullName;
                lblTrial.Text = _Trial.ToString();
                lblAppointmentDate.Text = _TestAppointment.AppointmentDate.DateToShort();
                lblTestFees.Text = _TestAppointment.PaidFees.ToString();
            }
        }


        private void ResetDefaultData()
        {
            lblLocalDL_AppID.Text = "[????]";
            lblLicenseClass.Text = "[????]";
            lblApplicantName.Text = "[????]";
            lblTrial.Text = "[????]";
            lblAppointmentDate.Text = "[????]";
            lblTestFees.Text = "[????]";
            lblTestID.Text = "[????]";
        }

    
    }
}
