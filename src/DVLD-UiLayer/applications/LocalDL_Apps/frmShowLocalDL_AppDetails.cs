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

namespace DVLD_UiLayer
{
    public partial class frmShowLocalDL_AppDetails : Form
    {
        private int _LocalDL_AppID {  get; set; }
        public frmShowLocalDL_AppDetails(int LocalDL_AppID)
        {
            InitializeComponent();
            _LocalDL_AppID = LocalDL_AppID;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLocalDL_AppDetails_Load(object sender, EventArgs e)
        {
            LocalDL_AppCard.LoadLocalDL_AppInfo(_LocalDL_AppID);
        }
    }
}
