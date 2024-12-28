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
    public partial class frmTransactionForm : Form
    {
        int _TransactionID = -1;
        Transactions _Transaction;
       
        public frmTransactionForm()
        {
            InitializeComponent();
        }
       
        private void tbFrom_TextChanged(object sender, EventArgs e)
        {
         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Transactions T=new Transactions();
            T.ClientID=int.Parse( tbTOAccount.Text.Trim());
            T.TransactionType = comboBox1.Text.ToString();
            T.TransactionDate = DateTime.Now;
            T.Describe=tbNote.Text.ToString();
            T.Amount=decimal.Parse(tbTransferAmount.Text.ToString());  
            if (T.Save())
            {
            
                MessageBox.Show($"Saved sucssesfully with ID {T.TransactionID}");
            }else
            {
                MessageBox.Show("Cant Save ");

            }
        }

        private void frmTransactionForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
           _Transaction = Transactions.Find(_TransactionID);

        }
    }
}
