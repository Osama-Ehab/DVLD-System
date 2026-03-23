using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_UiLayer
{
    public partial class frmBaseForm : Form
    {
        public frmBaseForm()
        {
            InitializeComponent();
        }

        public  ErrorProvider errorProvider1 = new ErrorProvider();
        public  void txt_Validating(object sender, CancelEventArgs e)
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

        public void txtNumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void frmBaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
