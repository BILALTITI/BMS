using business_Layer;
using DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Bank_Project
{
    public partial class frmLogin : Form
    {
        int _FailedCount = 0;
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            LbMessage.Visible = false;
             tbUserName.Focus();
            string UserName = "", Password = "";
            if (CLsGlobal.GetStoredCredential(ref UserName, ref Password))
            {

                tbUserName.Text = UserName;
                tbPassword.Text = clsUtil.Decrypt( Password, "0123456789abcdef");
                RBremmberMe.Checked = true;

            }
            else
            {
                RBremmberMe.Checked = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
 

        }
        public void Logs()
        {
            Logs _logs = new Logs();
            _logs.Action = "Login";
            _logs.LogDate = DateTime.Now;
            _logs.UserName = CLsGlobal.CurrentUser.UserName;
            _logs.Permetions = CLsGlobal.CurrentUser.Permetions;

           if (_logs.Save())
            {
                CLsGlobal.SaveToEventLog($"The User {CLsGlobal.CurrentUser.UserName}Login in date {DateTime.Now} ", EventLogEntryType.Warning, "Bank.App");

                //MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Error, Cant Save Logs ! ");
            }
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            User user = User.FindByUserNameAndPassword(tbUserName.Text.Trim(),  CLsGlobal.ComputeHash(  tbPassword.Text.Trim()) );

            if (user != null)
            {

                if (RBremmberMe.Checked)
                {
                    //store username and password
                    CLsGlobal.RememberUsernameAndPassword(tbUserName.Text.Trim(),clsUtil.Encrypt( tbPassword.Text.Trim(), "0123456789abcdef"));

                }
                else
                {
                    //store empty username and password
                    CLsGlobal.RememberUsernameAndPassword("", "");

                }

                //incase the user is not active
                if (!user.IsActive)
                {

                    tbUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            CLsGlobal.CurrentUser = user;
                this.Hide();

                Logs();
                 frmMain form = new frmMain(this);
                form.Show();



            }
            else
            {

                _FailedCount++;
                tbUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (_FailedCount >= 3)
                {
                    btnLogin.Visible = false;
                    LbMessage.Visible = true;
                    LbMessage.Text = "Sorry Can't Login Now  Please try After 1 Hours ";
                 

                    //CLsGlobal.SaveToEventLog("Failed More than 3 Times ", System.Diagnostics.EventLogEntryType.Error);
                    MessageBox.Show("Failed More than 3 Traield ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            tbUserName.Clear();
            tbPassword.Clear();
            tbUserName.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
