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
    public partial class frmTransactionList : Form
    { 
        DataTable dtDeposit = Transactions.GetAllTransactions();
        Client _Client;
        public frmTransactionList()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTransactionList_Load(object sender, EventArgs e)
        {
             DGVDepoist.DataSource = dtDeposit;

            if (DGVDepoist.Rows.Count > 0)
            {

                DGVDepoist.Columns[0].HeaderText = "Transaction ID";
                DGVDepoist.Columns[0].Width = 110;

                DGVDepoist.Columns[1].HeaderText = "Client No ";
                DGVDepoist.Columns[1].Width = 120;


                DGVDepoist.Columns[2].HeaderText = "Transaction Type  ";
                DGVDepoist.Columns[2].Width = 120;

                DGVDepoist.Columns[3].HeaderText = "Amount ";
                DGVDepoist.Columns[3].Width = 140;


                DGVDepoist.Columns[4].HeaderText = "Transaction Date";
                DGVDepoist.Columns[4].Width = 120;

                DGVDepoist.Columns[5].HeaderText = "Note";
                DGVDepoist.Columns[5].Width = 120;

             
 
                 
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTransactionList_Resize(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void cLientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ClientID = (int)DGVDepoist.CurrentRow.Cells[1].Value;
           _Client = Client.Find(ClientID);
            ShowCLientInfo showCLientInfo = new ShowCLientInfo(_Client.Personinfo.PersonID ?? 0);
            showCLientInfo.ShowDialog();
        }
    }
}
