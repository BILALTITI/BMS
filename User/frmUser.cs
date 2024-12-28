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
using business_Layer;

namespace Bank_Project
{
    public partial class frmUser : Form
    {
        DataTable dtUSer = business_Layer.User.GetAllUser();

        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            DGVUser.DataSource = business_Layer.User.GetAllUser();

            DGVUser.DataSource=dtUSer;
            cbFilterUser.SelectedIndex = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmAddnewUser frmAddnew = new frmAddnewUser();
            frmAddnew.ShowDialog();
            frmUser_Load(null,null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterUser.Text == "IsActive")
            {
                tbFilter.Visible = false;
                cbISactive.Visible = true;
                cbISactive.Enabled = true;
                cbISactive.Focus();
                cbISactive.SelectedIndex = 0;
                DGVUser.DataSource = dtUSer;
                     

            }

            else

            {

                tbFilter.Visible = (cbFilterUser.Text != "None");
                cbISactive.Visible = false;

                if (cbFilterUser.Text == "None")
                {
                    tbFilter.Enabled = false;
                    cbISactive.Enabled = false;
                    //_dtAllUsers.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                    DGVUser.DataSource = dtUSer;

                }
                else
                    tbFilter.Enabled = true;
                DGVUser.DataSource = dtUSer;

                tbFilter.Text = "";
                tbFilter.Focus();
            }

        }

        private void cbISactive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = "";

            switch (cbISactive.Text.Trim())
            {
                case "All":
                    FilterValue = "All";
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }
            if (FilterValue == "All")

                DGVUser.DataSource = dtUSer;


            else


              
                dtUSer  .DefaultView.RowFilter = string.Format("{0} = {1}", cbFilterUser.Text, FilterValue);
            DGVUser.DataSource = dtUSer;

        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            string query = $"{cbFilterUser.Text} = {tbFilter.Text} ";
            string query2 = $"{cbFilterUser.Text} Like '{tbFilter.Text}%' ";


            if (cbFilterUser.Text == "IsActive")
            {
                DGVUser.DataSource = dtUSer;

                cbISactive.Visible = true;
                tbFilter.Visible = false;
            }

            if (tbFilter.Text == "")
            {

                DGVUser.DataSource = dtUSer;

                dtUSer.DefaultView.RowFilter = "";

                return;
            }

            if (cbFilterUser.Text == "PersonID" || cbFilterUser.Text == "UserID")

            {
                DGVUser.DataSource = dtUSer;

                dtUSer.DefaultView.RowFilter = query;

                return;
            }
            else
            {
                DGVUser.DataSource =        dtUSer;

                dtUSer.DefaultView.RowFilter = query2;

                return;
            }

        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + DGVUser.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if ( business_Layer.User.DeletetUser((int)DGVUser.CurrentRow.Cells[0].Value))
                {
                    frmUser_Load(null, null);
                    MessageBox.Show("User Deleted Successfully");
                }
                else
                    MessageBox.Show("User  Is not Deleted");
            }
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddnewUser addnewUser = new frmAddnewUser((int)DGVUser.CurrentRow.Cells[0].Value);
            frmUser_Load(null, null);
            addnewUser.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddnewUser frmAddnew = new frmAddnewUser();
            frmUser_Load(null, null);
            frmAddnew.ShowDialog();
        }

        private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserinfo frmUserinfo = new frmUserinfo((int)DGVUser.CurrentRow.Cells[0].Value);
            frmUserinfo.ShowDialog();
        }
    }
}
