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
    public partial class frmMain : Form
    {

        private Form ActiveForm;
     private   frmLogin _login;
     //   frmLogin login;
        public frmMain(frmLogin login)
        {
            InitializeComponent();
            _login = login;
        }


        public void TimeForm()
        {
            // Initialize the label to display time
            
           

            // Initialize the timer
             timer1.Interval = 1000; // 1000 milliseconds = 1 second
            timer1.Tick += new EventHandler(OnTimerTick);
            timer1.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            // Update the label with the current time
            lbtime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void OpenChildForm(Form ChildForm,  object btnSender =null)
        {
            if (ActiveForm != null) 
            
            
            { 

                ActiveForm.Close(); 
            } 
            ActiveForm=ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle=FormBorderStyle.None;
            ChildForm.Dock= DockStyle.Fill;
            this.pOpenForm.Controls.Add(ChildForm);
            this.pOpenForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TimeForm();
             lbCurrentUser.Text = CLsGlobal.CurrentUser.UserName.ToString();

        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {



         }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
           
                OpenChildForm(new frmDashBoard(), sender);

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClsPermetion.PermissionChecker.CheckAccessPermission(ClsPermetion.enPermissions.pManageUsers, CLsGlobal.CurrentUser.Permetions))
            {

                OpenChildForm(new frmUser(), sender);
            }

            else
            {
                MessageBox.Show("Access Denied , Please Contact with your Admin ", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ClsPermetion.PermissionChecker.CheckAccessPermission(ClsPermetion.enPermissions.PPeopleList, CLsGlobal.CurrentUser.Permetions))
            {

                OpenChildForm(new frmPeople(), sender);
            }

            else
            {
                MessageBox.Show("Access Denied , Please Contact with your Admin ", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            if (ClsPermetion.PermissionChecker.CheckAccessPermission(ClsPermetion.enPermissions.pListClients,
                CLsGlobal.CurrentUser.Permetions))
            OpenChildForm(new frmClientcsList(), sender);
            else
                MessageBox.Show("Access Denied , Please Contact with your Admin ", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button3_Click(object sender, EventArgs e)
        {
             if (ClsPermetion.PermissionChecker.CheckAccessPermission(ClsPermetion.enPermissions.pTransactions, CLsGlobal.CurrentUser.Permetions))
            {
                OpenChildForm(new frmTransaction(), sender);

            }

            else
            {
                MessageBox.Show("Access Denied , Please Contact with your Admin ", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            if (ClsPermetion.PermissionChecker.CheckAccessPermission(ClsPermetion.enPermissions.PLogs, CLsGlobal.CurrentUser.Permetions))
            {
                OpenChildForm(new FrmLoginLogs(), sender);

            }

            else
            {
                MessageBox.Show("Access Denied , Please Contact with your Admin ", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CLsGlobal.CurrentUser = null;
            _login.Show();
            this.Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmProfile(CLsGlobal.CurrentUser.UserID ?? 0), sender);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
