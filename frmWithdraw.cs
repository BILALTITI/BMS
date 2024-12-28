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

    public partial class frmWithdraw : Form
    {
        Client _Client;
        public frmWithdraw()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
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

        private void tbAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

                MessageBox.Show("Error, Amount must be a number can't contain a Letter ");


            }
        }

        private void tbClientID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbWirhDrawAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbClientID_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void tbWirhDrawAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))

            {

                e.Handled = true;

                MessageBox.Show("Error, Amount must be a number can't contain a Letter ");


            }
        }

        private void frmWithdraw_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tbAccountNumber.Text=string.Empty;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //tbWirhDrawAmount.Text = d;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            tbDescribe.Text = string.Empty;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmWithdraw_Resize(object sender, EventArgs e)
        {
            int x = (this.Width - panel1.Height) / 2;
            int y = (this.Height - panel1.Height) / 2;
            panel1.Location = new Point(x, y);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (tbWirhDrawAmount.Text == "" && tbAccountNumber.Text == "")
                {
                    MessageBox.Show("The Text Boxes Must have a Value ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider1.SetError(tbAccountNumber, "The AccountID IS Not Exsist");

                    errorProvider1.SetError(tbWirhDrawAmount, "The Ammount IS Not Exsist");



                }
                else
                {


                    _Client = Client.FindByAccountID(tbAccountNumber.Text);
                    if (_Client.Balance < Convert.ToDecimal(tbWirhDrawAmount.Text))
                    {
                        MessageBox.Show($"Your Balance Is Lower Than WithDraw Amount , Your Balance Is = {_Client.Balance} , Try Again ");
                        return;

                    }
                    MessageBox.Show($"Are you Sure Do you want WithDraw  {tbWirhDrawAmount.Text}  ", "conformation", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    Transactions WithDraw = new Transactions();
                    WithDraw.TransactionDate = DateTime.Now;
                    WithDraw.Describe = tbDescribe.Text.Trim();
                    WithDraw.Amount = Convert.ToDecimal(tbWirhDrawAmount.Text);
                    WithDraw.ClientID = _Client.ClientID ?? 0;
                    WithDraw.TransactionType = "WithDraw";
                    errorProvider1.SetError(tbAccountNumber, null);

                    errorProvider1.SetError(tbWirhDrawAmount, null);

                    if (WithDraw.Save())
                    {
                        Client._UpdateWithdraeClient(Convert.ToInt32(_Client.ClientID), Convert.ToDecimal(tbWirhDrawAmount.Text));
                        MessageBox.Show($"WithDraw {tbWirhDrawAmount.Text} To CLient ID ={_Client.ClientID} Succsefully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cant Save  ");

                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill The Text Boxes");
            }
        }
    }
}
