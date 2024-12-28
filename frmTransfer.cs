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
    public partial class frmTransfer : Form
    {
        int _TransactionID = -1;
        Client _Client1;
        Client _Client;

        public frmTransfer()
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
            T.ClientID=int.Parse( tbfrom.Text.Trim());
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


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbTOAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

                MessageBox.Show("Error, Account  must be a number can't contain a Letter ");


            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

                MessageBox.Show("Error, Account must be a number can't contain a Letter ");


            }
        }

        private void tbTransferAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

                MessageBox.Show("Error, Amount must be a number can't contain a Letter ");


            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tbfrom.Text = string.Empty;

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            tbto.Text = string.Empty;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tbTransferAmount.Text = string.Empty;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            tbNote.Text = string.Empty;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void tbfrom_TextChanged_1(object sender, EventArgs e)
        {
            if (!Client.isClientExsistByAccountID(tbfrom.Text))
            {
                errorProvider1.SetError(tbfrom, "The AccountID IS Not Exsist");

            }
            else
            {
                errorProvider1.SetError(tbfrom, null);
            }
        }

        private void tbto_TextChanged(object sender, EventArgs e)
        {
            if (!Client.isClientExsistByAccountID(tbto.Text))
            {
                errorProvider1.SetError(tbto, "The AccountID IS Not Exsist");

            }
            else
            {
                errorProvider1.SetError(tbto, null);
            }
        }

        private void frmTransfer_Resize(object sender, EventArgs e)
        {
            int x = (this.Width - panel1.Height) / 2;
            int y = (this.Height - panel1.Height) / 2;
            panel1.Location= new Point(x, y);   
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (tbfrom.Text == "" && tbto.Text == "" && tbTransferAmount.Text == "")
                {
                    MessageBox.Show("The Text Boxes Must have a Value ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(tbfrom, "The AccountID From IS Not Exsist");
                    errorProvider1.SetError(tbto, "The AccountID To  IS Not Exsist");

                    errorProvider1.SetError(tbTransferAmount, "The Ammount IS Not Exsist");



                }
                else
                {
                    errorProvider1.SetError(tbto, null);
                    errorProvider1.SetError(tbfrom, null);

                    if (_Client.Balance < Convert.ToDecimal(tbTransferAmount.Text))
                    {
                        MessageBox.Show($"Your Balance Is Lower Than WithDraw Amount , Your Balance Is = {_Client.Balance} , Try Again ");
                        return;

                    }

                    MessageBox.Show($"Are you Sure Do you want Transfer  {tbTransferAmount.Text} To Account Number {tbto.Text} ", "conformation", MessageBoxButtons.OK, MessageBoxIcon.Question);


                    _Client = Client.FindByAccountID(tbfrom.Text);
                    Transfer transfer = new Transfer();
                    transfer.TransferDate = DateTime.Now;
                    transfer.Describe = tbNote.Text;
                    transfer.Amount = Convert.ToDecimal(tbTransferAmount.Text);
                    transfer.TransferFrom = tbfrom.Text.Trim();
                    transfer.TransferTo = tbto.Text.Trim();
                    transfer.ClientID = _Client.ClientID ?? 0;
                    if (_Client.Balance < Convert.ToDecimal(tbTransferAmount.Text))
                    {
                        MessageBox.Show("Your Balance Is Lower Than Transfer Amount , Try Again ");
                        return;

                    }
                    if (transfer.Save())
                    {
                        Client._UpdateDepositClientByAccountID(tbto.Text, Convert.ToDecimal(tbTransferAmount.Text));
                        Client._UpdateWithdraeClientByAccountID(tbfrom.Text, Convert.ToDecimal(tbTransferAmount.Text));
                        ////Client._UpdateDepositClient(Convert.ToInt32(_Client.ClientID), Convert.ToDecimal(tbDepoistAmount.Text));
                        MessageBox.Show("Save Succsefully");
                        MessageBox.Show($"Transfer {tbTransferAmount.Text} To CLient ID {_Client.ClientID} Succsefully");
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
