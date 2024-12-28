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
    public partial class frmClientcsList : Form
    {
        DataTable dataTable = Client.GetAllClient();
        public frmClientcsList()
        {
            InitializeComponent();
        }
        public void _RefreshClient()
        {
            dataGridView1.DataSource = Client.GetAllClient();

        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmAddnewClientcs_Load(object sender, EventArgs e)
        {
           dataTable = Client.GetAllClient();
            dataGridView1.DataSource = dataTable;
            cbFilterUser.SelectedIndex = 0;

         }

        private void cbFilterUser_SelectedIndexChanged(object sender, EventArgs e)
        {
          
             
             

                if (cbFilterUser.Text == "None")
                {
                    tbFilter.Enabled = false;
                     //_dtAllUsers.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                    dataGridView1.DataSource = dataTable;

                }
                else
                    tbFilter.Enabled = true;
                dataGridView1.DataSource = dataTable;

                tbFilter.Text = "";
                tbFilter.Focus();
            }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            string query = $"{cbFilterUser.Text} = {tbFilter.Text} ";
            string query2 = $"{cbFilterUser.Text} Like '{tbFilter.Text}%' ";


            if (cbFilterUser.Text == "IsActive")
            {
                dataGridView1.DataSource = dataTable;

                 tbFilter.Visible = false;
            }

            if (tbFilter.Text == "")
            {

                dataGridView1.DataSource = dataTable;

                dataTable.DefaultView.RowFilter = "";

                return;
            }

            if (cbFilterUser.Text == "PersonID" || cbFilterUser.Text == "UserID")

            {
                dataGridView1.DataSource = dataTable;

                dataTable.DefaultView.RowFilter = query;

                return;
            }
            else
            {
                dataGridView1.DataSource = dataTable;

                dataTable.DefaultView.RowFilter = query2;

                return;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (ClsPermetion.PermissionChecker.CheckAccessPermission(ClsPermetion.enPermissions.pAddNewClient, CLsGlobal.CurrentUser.Permetions))
            {

                frmAddnewClient frmAddnew = new frmAddnewClient();
                frmAddnew.ShowDialog();
                _RefreshClient();

            }

            else
            {
                MessageBox.Show("Access Denied , Please Contact with your Admin ", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ClsPermetion.PermissionChecker.CheckAccessPermission(ClsPermetion.enPermissions.pDeleteClient, CLsGlobal.CurrentUser.Permetions))
            {


                if (MessageBox.Show("Are you sure you want to delete a Client Account [" + dataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    if (Client.DeletetClient((int)dataGridView1.CurrentRow.Cells[0].Value))
                    {
                        frmAddnewClientcs_Load(null, null);
                        MessageBox.Show("Client Account Deleted Successfully");
                      _RefreshClient() ;
                    }
                    else
                        MessageBox.Show("Access Denied , Please Contact with your Admin ", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

            else
            {
                MessageBox.Show(" Permetion Deniend ");
            }
        }

        private void clientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCLientInfo client = new ShowCLientInfo((int)dataGridView1.CurrentRow.Cells[1].Value);
            client.ShowDialog();    
        }

        private void editClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClsPermetion.PermissionChecker.CheckAccessPermission(ClsPermetion.enPermissions.pUpdateClients, CLsGlobal.CurrentUser.Permetions))
            {
                frmAddnewClient client = new frmAddnewClient((int)dataGridView1.CurrentRow.Cells[0].Value);
                client.ShowDialog();
                _RefreshClient();
            }

            else
            {
                MessageBox.Show("Access Denied , Please Contact with your Admin ", "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
