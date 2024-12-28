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
    public partial class frmPeople : Form
    {
        DataTable dt =Person.GetAllPerson();
        public frmPeople()
        {
            InitializeComponent();
        }
        private void _RefreshPeople()
        {
            dataGridView1.DataSource= Person.GetAllPerson();
        }
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
          
        }

        private void frmPeople_Load(object sender, EventArgs e)
        {
            dt = Person.GetAllPerson();
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmAddnewPerson frmAddnewPerson = new frmAddnewPerson(-1);    
            frmAddnewPerson.ShowDialog();
_RefreshPeople();

        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person [" + dataGridView1.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (Person.DeletetPerso((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully");
                  _RefreshPeople();
                }
                else
                    MessageBox.Show("Person  Is not Deleted");
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddnewPerson frmEditORADD = new frmAddnewPerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmEditORADD.ShowDialog();
            _RefreshPeople();        
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmShowInfo frm = new frmShowInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }
    }
}
