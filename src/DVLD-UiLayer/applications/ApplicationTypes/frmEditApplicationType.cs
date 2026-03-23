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
    public partial class frmEditApplicationTypes : frmBaseForm
    {
        public event EventHandler RefreshApplicationTypesData;
        private clsApplicationType _ApplicationType;
        private byte _ApplicationTypeID;
        public frmEditApplicationTypes(byte ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }


        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);
            if(_ApplicationType != null)
            {
                lblApplicationTypeID.Text = _ApplicationType.ID.ToString();
                txtTitle.Text = _ApplicationType.Title;
                txtFees.Text = _ApplicationType.Fees.ToString();
            }
        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to close form And ignore changes?", "Confirmed", MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to save Updates?", "Confirmed", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (!this.ValidateChildren())
                {
                    MessageBox.Show("Data not Saved Successfully,Couse there is field(s) Empty or Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _SaveUpdate();
                
            }
        }

        private void _SaveUpdate()
        {
            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = Convert.ToDecimal(txtFees.Text);

            if(_ApplicationType.Save())
            {
                RefreshApplicationTypesData?.Invoke(this, new EventArgs());
                MessageBox.Show("Data Saved Successfully.", "Saved");
            }
        }

        private new void txtNumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.txtNumbersOnly_KeyPress(sender, e);
        }

        
        private new void txt_Validating(object sender, CancelEventArgs e)
        {
            base.txt_Validating(sender, e);
        }
    }
}
