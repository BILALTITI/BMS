using business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Project
{
   
    public partial class ctrlUserInfo : UserControl
    {

        int _UserID = -1;
   User _User;

         public ctrlUserInfo()
        {
            
            InitializeComponent();
        }
        private void _ResetPersonInfo()
        {

            ctrlPersoncard1.RestDefaultData();
            lbUserID2.Text = "[???]";
            lbUserName2.Text = "[???]";
            lbIsActive2.Text = "[???]";
        }
        public void _FillUserInfo()
        {

            ctrlPersoncard1.ShowCard(_User.PersonID ?? 0);
            lbUserID2.Text = _User.UserID.ToString();
            lbUserName2.Text = _User.UserName.ToString();

            if (_User.IsActive)
                lbIsActive2.Text = "Yes";
            else
                lbIsActive2.Text = "No";

        }
        public void _FillPersonInfo(int PersonID)
        {

            ctrlPersoncard1.ShowCard(PersonID);
            
        }
        public void LoadUserInfo(int UserID)
        {
            _User =  User.Find(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }
        private void ctrlUserInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
