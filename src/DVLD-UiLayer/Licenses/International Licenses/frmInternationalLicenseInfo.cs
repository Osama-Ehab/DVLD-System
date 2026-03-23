using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UiLayer.InternationalLicenses
{
    public partial class frmInternationalLicenseInfo : Form
    {
        private int _InternationalLicenseID  { get; set; }
        public int InternationalLicenseID { get { return _InternationalLicenseID; } }

        private int _ApplicationID { get; set; }
        public int ApplicationID { get { return _ApplicationID; } }

        private int _LocalDL_AppID { get; set; }
        public int LocalDL_AppID { get { return _LocalDL_AppID; } }

        public frmInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _ApplicationID = -1;
            _LocalDL_AppID = -1;
            _InternationalLicenseID = InternationalLicenseID;
        }
        public frmInternationalLicenseInfo(int ApplicationID,byte ByAppID  = 0)
        {
            InitializeComponent();
            _InternationalLicenseID = -1;
            _LocalDL_AppID  = -1;
            _ApplicationID = ApplicationID;
        }
        public frmInternationalLicenseInfo(int LocalDL_AppID,bool ByLocalDL_AppID = true)
        {
            InitializeComponent();
            _InternationalLicenseID = -1;
            _ApplicationID = -1;
            _LocalDL_AppID = LocalDL_AppID;
        }

        private void frmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            if (InternationalLicenseID != -1)
                DriverInternationalLicenseCard.LoadInternationalLicenseInfo(InternationalLicenseID);
            else if (LocalDL_AppID != -1)
                DriverInternationalLicenseCard.LoadInternationalLicenseInfoByInternationalDL_AppID(LocalDL_AppID);
            else
                DriverInternationalLicenseCard.LoadInternationalLicenseInfo(-1);
        }


        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DriverInternationalLicenseCard_Load(object sender, EventArgs e)
        {

        }
    }
}
