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

namespace DVLD_UiLayer.TestTypes
{
    public partial class frmManageTestTypes : frmBaseForm
    {
        private DataTable _TestTypesTable;
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshManageTestTypesList();
        }

        private void _RefreshManageTestTypesList()
        {
            _TestTypesTable = clsTestType.GetAllTestTypes();
            dgvManageTestTypes.DataSource = _TestTypesTable;
            lblRecordsCount.Text = dgvManageTestTypes.Rows.Count.ToString();
            if (dgvManageTestTypes.Rows.Count < 1) return;

            dgvManageTestTypes.Columns[0].Width = 70;
            dgvManageTestTypes.Columns[1].Width = 140;
            dgvManageTestTypes.Columns[2].Width = 320;
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsTestType.enTestType.TryParse(dgvManageTestTypes.CurrentRow.Cells[0].Value.ToString(), out clsTestType.enTestType TestTypeID))
            {
                frmEditTestType EditTestType = new frmEditTestType(TestTypeID);
                EditTestType.RefreshTestTypesData += frmManageTestTypes_Load;
                EditTestType.ShowDialog();
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
