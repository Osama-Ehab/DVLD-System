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

namespace DVLD_UiLayer.ApplicationTypes
{
    public partial class frmManageApplicationTypes : Form
    {
        private DataTable _ApplicationTypesTable;
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshManageApplicationTypesList();
        }

        private void _RefreshManageApplicationTypesList()
        {
            _ApplicationTypesTable = clsApplicationType.GetAllApplicationTypes();
            dgvManageApplicationTypes.DataSource = _ApplicationTypesTable;
            lblRecordsCount.Text = dgvManageApplicationTypes.Rows.Count.ToString();
            if (dgvManageApplicationTypes.Rows.Count < 1) return;
            dgvManageApplicationTypes.Columns[1].Width = 300;
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (byte.TryParse(dgvManageApplicationTypes.CurrentRow.Cells[0].Value.ToString(), out byte ApplicationTypeID))
            {
                frmEditApplicationTypes EditApplicationType = new frmEditApplicationTypes(ApplicationTypeID);
                EditApplicationType.RefreshApplicationTypesData += frmManageApplicationTypes_Load;
                EditApplicationType.ShowDialog();
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
