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
    public partial class frmShowInternationalDL_AppDetails : Form
    {
        private int _InternationalDL_AppID {  get; set; }
        public frmShowInternationalDL_AppDetails(int InternationalDL_AppID)
        {
            InitializeComponent();
            _InternationalDL_AppID = InternationalDL_AppID;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void LoadInternationalDL_AppData(object sender, EventArgs e)
        {
            InternationalDL_AppCard.LoadInternationalDL_AppInfo(_InternationalDL_AppID);
        }


     
    }
}
