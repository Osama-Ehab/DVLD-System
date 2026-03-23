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
using DVLD_UiLayer;
using DVLD_UiLayer.HelperClasses;
namespace DVLD_UiLayer.TestTypes
{
    public partial class frmEditTestType : Form
    {
        public event EventHandler RefreshTestTypesData;
        private clsTestType _TestType;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }


        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType == null)
            {
                clsMessageService.ShowError("Could not find Test Type with id = " + _TestTypeID.ToString());
                this.Close();
                return;

            }

            lblTestTypeID.Text = _TestType.ID.ToString();
            txtTitle.Text = _TestType.Title;
            txtDescription.Text = _TestType.Description;
            txtFees.Text = _TestType.Fees.ToString();
        }
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            
            if (!clsMessageService.Confirm("Are you sure that you want to close form And ignore changes?"))return;
            

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!clsMessageService.Confirm("Are you sure that you want to save Updates?"))return;

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                clsMessageService.ShowValidationError("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro");
                return;

            }
            _SaveUpdate();
        }

        private void _SaveUpdate()
        {
            _TestType.Title = txtTitle.Text;
            _TestType.Description = txtDescription.Text;
            _TestType.Fees = Convert.ToDecimal(txtFees.Text);

            if(!_TestType.Save())
                clsMessageService.ShowError("Error: Data Is not Saved Successfully.");

            RefreshTestTypesData?.Invoke(this, new EventArgs());
            clsMessageService.ShowSuccess("Data Saved Successfully.", "Saved");
        }

        private void txtNumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            TextBox Txt = (TextBox)sender;
            if (string.IsNullOrEmpty(Txt.Text))
            {
                errorProvider1.SetError(Txt, "This field is Required!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(Txt, string.Empty); // Clear the error
            }
        }
    }
}
