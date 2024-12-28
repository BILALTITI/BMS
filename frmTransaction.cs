using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Bank_Project
{
    
    public partial class frmTransaction : Form
    {
        private Form ActiveForm;
        private void OpenChildForm(Form ChildForm, object btnSender = null)
        {
            if (ActiveForm != null)


            {

                ActiveForm.Close();
            }
            ActiveForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(ChildForm);
            this.panel1.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        

        public frmTransaction()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDeposit(), sender);
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmWithdraw(), sender);
           
        }

        private void transferToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTransfer(), sender);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {

        }

        private void frmTransaction_Resize(object sender, EventArgs e)
        { 
        }

        private void transactionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTransactionList(), sender);

        }
    }
}
