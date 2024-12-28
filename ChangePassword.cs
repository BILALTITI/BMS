using business_Layer;
using DVLD;
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
    public partial class ChangePassword : Form
    {
        User _User;
    int    _USerID=-1;
        public ChangePassword(int USerID)
        {
            InitializeComponent();
            _USerID = USerID;
            _User = User.Find(_USerID);

        }
        public ChangePassword()
        {
            InitializeComponent();
        }
        public void _RestDefaaultValues()
        {
            tbNewPassword.Text = "";
            tbCurrentPassword.Text = "";
            tbConfirmPassword.Text = "";
            tbCurrentPassword.Focus();
        }
        private void AddnewClient_Load(object sender, EventArgs e)
        {

            _RestDefaaultValues();
            //Here we dont continue becuase the form is not valid
            if (_User == null)
            {
                MessageBox.Show("Could not Find User with id = " +_USerID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close  ();

                return;
            }
            ctrlUserInfo1.LoadUserInfo(_USerID);
            tbCurrentPassword.Focus ();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = CLsGlobal.ComputeHash(tbNewPassword.Text.Trim());

            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RestDefaaultValues();
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbCurrentPassword.Text != CLsGlobal.CurrentUser.Password)
            {
                errorProvider1.SetError(tbCurrentPassword, "The Password is Incorrext");

            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, null);
            }
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbConfirmPassword == tbNewPassword)
            {

                errorProvider1.SetError(tbConfirmPassword, "The Confirm Password dose Not Match New Password");

            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
            }
        }

        private void tbNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbNewPassword.Text == tbCurrentPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "The New Password  dose Not Equal  old Password");

            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close  ();
        }
    }
    
}
