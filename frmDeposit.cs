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
    public partial class frmDeposit : Form
    {
        Client _Client;
        public frmDeposit()
        {
            InitializeComponent();
        }

         private void pictureBox1_Click(object sender, EventArgs e)
        {
            tbAccountNumber.Text = string.Empty;
        }
       
        private void tbAccountNumber_TextChanged(object sender, EventArgs e)
        {
            if (!Client.isClientExsistByAccountID(tbAccountNumber.Text))
            {
                errorProvider1.SetError(tbAccountNumber, "The AccountID IS Not Exsist");

            }
            else
            {
                errorProvider1.SetError(tbAccountNumber, null);
            }
        }

        private void tbDepoistAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

                MessageBox.Show("Error, Amount must be a number can't contain a Letter ");


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void tbClientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

                MessageBox.Show("Error, Amount must be a number can't contain a Letter ");


            }
        }

        private void tbDepoistAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tbDepoistAmount.Text = string.Empty;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tbnote.Text = string.Empty;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDeposit_Resize(object sender, EventArgs e)
        {
            int x = (this.Width - panel1.Height) / 2;
            int y = (this.Height - panel1.Height) / 2;
            panel1.Location = new Point(x, y);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (tbDepoistAmount.Text == "" && tbAccountNumber.Text == "")
                {
                    MessageBox.Show("The Text Boxes Must have a Value ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(tbAccountNumber, "The AccountID IS Not Exsist");

                    errorProvider1.SetError(tbDepoistAmount, "The Ammount IS Not Exsist");



                }
                else
                {
                    errorProvider1.SetError(tbAccountNumber, null);

                    errorProvider1.SetError(tbDepoistAmount, null);


                    MessageBox.Show($"Are you Sure Do you want Deposit  {tbDepoistAmount.Text}  ", "conformation", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    _Client = Client.FindByAccountID(tbAccountNumber.Text);
                    Transactions Deposit = new Transactions();
                    Deposit.TransactionDate = DateTime.Now;
                    Deposit.Describe = tbnote.Text;
                    Deposit.Amount = Convert.ToDecimal(tbDepoistAmount.Text);
                    Deposit.ClientID = _Client.ClientID ?? 0;
                    Deposit.TransactionType = "WithDraw";
                    errorProvider1.SetError(tbAccountNumber, null);

                    errorProvider1.SetError(tbDepoistAmount, null);
                    if (Deposit.Save())
                    {
                        Client._UpdateDepositClient(Convert.ToInt32(_Client.ClientID), Convert.ToDecimal(tbDepoistAmount.Text));
                        MessageBox.Show($"Deposit {tbDepoistAmount.Text} To CLient ID = {_Client.ClientID} Succsefully");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Cant Save  ");

                    }
                }
            }
        }
    }
}
