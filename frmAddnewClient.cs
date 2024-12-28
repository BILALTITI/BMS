using business_Layer;
using DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Bank_Project
{
    public partial class frmAddnewClient : Form
    {
        public delegate void DataBackEventHandler(object seder, int ClientID);
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        Person _Person;
        int _ClientID  =-1;
        Client _Client;
        
        public frmAddnewClient(int ClientID)
        {
            InitializeComponent();
             _ClientID = ClientID;
            
            _Mode =enMode.Update;
        }
        public frmAddnewClient(   )
        {
            InitializeComponent();
            _Mode=enMode.AddNew;
         }
        private void frmAddnewClient_Load(object sender, EventArgs e)
        {

            if (_Mode == enMode.AddNew)
            {
                CbAccountType.SelectedIndex = 2;
               tabControl1.SelectedIndex = 0;
                tabPage2.Enabled = false;
                cbIsActive.Checked = true;
 
               LBAddClient .Text = "Add New Client";
               _Client = new Client();
                return;
            }
           _Client = Client.Find(_ClientID);
            if (_Client == null)
            {
                MessageBox.Show("This Form Will be Close Becouse no Client Found ");
                this.Close();
                return;

            }
           LBAddClient.Text = "Edit Client ID =" + _ClientID;
            tabControl1 .SelectedIndex = 1;
            ctrlPersonWithFiltter1.FilterEnabled = false;
          ctrlPersonWithFiltter1.ShowCard(_Client.PersonID??0);
            lbClientID.Text = _Client.ClientID.ToString();
            lbPersonID2.Text = _Client.PersonID.ToString();
            tbBalanceAmoount.Text = _Client.Balance.ToString();
            tbBalanceAmoount.Enabled = false;
            CbAccountType.Text = _Client.AccountType.ToString();
           tbAccountNO.Text = _Client.AccountID;
            cbIsActive.Checked =_Client.IsActive?true:false;       
        
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {

                btnSave.Enabled = true;
                tabControl1.SelectedIndex = 1;
                tabPage2.Enabled = false;
                return;
            }

            //incase of add new mode.
            if (_Person.PersonID != -1)
            {

                if (Client.isClientExsist(_Person.PersonID ?? 0))
                {

                    MessageBox.Show("Selected Person already has a Client Account , choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                lbPersonID2.Text = _Person.PersonID.ToString(); 
                    btnSave.Enabled = true;
                    tabControl1.SelectedIndex = 1;
                    tbBalanceAmoount.Focus();
                    tabPage2.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonWithFiltter1.Focus();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            _Client.Balance =decimal.Parse(tbBalanceAmoount.Text);
           _Client.AccountType = CbAccountType.Text;
          
            _Client.IsActive = cbIsActive.Checked;
            _Client.OpenDate =DateTime.Now;
            _Client.PersonID = ctrlPersonWithFiltter1.PersoID2 ;
            _Client.AccountID = tbAccountNO.Text.Trim();
  
            if (_Client.Save())
            {


                 MessageBox.Show("Data  Save , Succseesfully");
               
 
                MessageBox.Show($"Client ID ={  _Client.ClientID}");
                this.Close();
            }

            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonWithFiltter1_OnPersonSelected(object sender, int e)
        {
            int SelectedPersonID = e;
            _Person = Person.Find(SelectedPersonID);
            if (SelectedPersonID == -1)
            {
                return;
            }
            
        }

        private void frmAddnewClient_Activated(object sender, EventArgs e)
        {
            ctrlPersonWithFiltter1._TBFoucs();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tbBalanceAmoount_TextChanged(object sender, EventArgs e)
        {

        }
    } 
    }

