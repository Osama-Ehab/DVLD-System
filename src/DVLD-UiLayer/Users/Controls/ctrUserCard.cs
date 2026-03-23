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

namespace DVLD_UiLayer.UserControls
{
    public partial class ctrUserCard : UserControl
    {
        public ctrUserCard()
        {
            InitializeComponent();
        }

        private clsUser _User;

        public int UserID
        {
            get { return _User?.UserID ?? -1; }
        }
        private void _FillUserInfo()
        {
            PersonCard.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.Find(UserID);
            if (_User != null )
            {
                _FillUserInfo();
            }
            else
            {
                _ResetUserInfo();
                MessageBox.Show("No User with ID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void LoadUserInfo(clsUser User)
        {
            _User = User;
            if (_User != null)
            {
                _FillUserInfo();
            }
            else
            {
                _ResetUserInfo();
                MessageBox.Show("No User with ID = " + User.UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void _ResetUserInfo()
        {
            PersonCard.ResetDefaultData();
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
            lblIsActive.Text = "[???]";
        }
    }
}

