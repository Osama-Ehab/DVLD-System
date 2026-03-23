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
    public partial class frmPersonDetails : Form
    {
        private readonly int _PersonID;
        private readonly string _NationalNo;
        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
            _NationalNo = "";
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            _NationalNo = NationalNo;
            _PersonID = -1;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadPersonData(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                PersonCard.LoadPersonInfo(_PersonID);
            }
            else if (!string.IsNullOrEmpty(_NationalNo))
                PersonCard.LoadPersonInfo(_NationalNo);
            else
                PersonCard.LoadPersonInfo(-1);

        }

     
    }
}
