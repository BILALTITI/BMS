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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Bank_Project
{
    public partial class frmAddnewUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        Person _Person;
        private int _UserID = -1;
        business_Layer.User _User;
        public frmAddnewUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }
        public frmAddnewUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public void CheckAllPermetaion()
        {
            eAll.Checked = true;
            pUpdateClients.Checked = true;
            pTransactions.Checked = true;
            pPeopleList.Checked = true;
            pManageUsers.Checked = true;
            pListClients.Checked = true;
            pAddNewClient.Checked = true;
            PLogs.Checked = true;
            PDeleteClient.Checked = true;
        }
        private void ChekedStatus()
        {


            if (_User.Permetions == Convert.ToSingle(pAddNewClient.Tag))
            {
                pAddNewClient.Checked = true;
            }
            if (_User.Permetions == Convert.ToSingle(PDeleteClient.Tag))
            {
                PDeleteClient.Checked = true;
            }
            if (_User.Permetions == Convert.ToSingle(PLogs.Tag))
            {
                PLogs.Checked = true;
            }
            if (_User.Permetions == Convert.ToSingle(pListClients.Tag))
            {
                pListClients.Checked = true;
            }
            if (_User.Permetions == Convert.ToSingle(pManageUsers.Tag))
            {
                pManageUsers.Checked = true;
            }
            if (_User.Permetions == Convert.ToSingle(pPeopleList.Tag))
            {
                pPeopleList.Checked = true;
            }
            if (_User.Permetions == Convert.ToSingle(pTransactions.Tag))
            {
                pTransactions.Checked = true;
            }
            if (_User.Permetions == Convert.ToSingle(pUpdateClients.Tag))
            {
                pUpdateClients.Checked = true;
            }
            if (_User.Permetions == Convert.ToSingle(eAll.Tag))
            {
                CheckAllPermetaion();





            }
        }
        private void _LoadData()
        {
            _User = business_Layer.User.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("This Form Will be Close Becouse no User Found ");
                this.Close();
                return;

            }
            else
            {
                lbAddnewUser.Text = "Edit User ID =" + _UserID;
                ctrlPersonWithFiltter1.FilterEnabled = false;
                ctrlPersonWithFiltter1.ShowCard(_User.PersonID ?? 0);
                LbUserID2.Text = _UserID.ToString();
                tbUserName.Text =  _User.UserName;
                tbPassword.Text = "";
                tbConfirmPassword.Text = "";
                tbPassword.Focus();
                GBPermetions.Enabled=true;
                ChekedStatus();


                CHKIsActive.Checked = true;
            }
        }
          float CalculateTotalPermetion()
        {
            float TotalPermetion = 0;
            if (eAll.Checked)
            {
                TotalPermetion += Convert.ToSingle(eAll.Tag);
            }

            if (pTransactions.Checked)
            {
                TotalPermetion += Convert.ToSingle(pTransactions.Tag);
            }
            if (pUpdateClients.Checked)
            {
                TotalPermetion += Convert.ToSingle(pUpdateClients.Tag);
            }
            if (pAddNewClient.Checked)
            {
                TotalPermetion += Convert.ToSingle(pAddNewClient.Tag);
            }
            if (pPeopleList.Checked)
            {
                TotalPermetion += Convert.ToSingle(pPeopleList.Tag);
            }
            if (pListClients.Checked)
            {
                TotalPermetion += Convert.ToSingle(pListClients.Tag);
            }
            if (pManageUsers.Checked)
            {
                TotalPermetion += Convert.ToSingle(pManageUsers.Tag);
            }
            if (PLogs.Checked)
            {
                TotalPermetion += Convert.ToSingle(PLogs.Tag);
            }
            if (PDeleteClient.Checked)
            {
                TotalPermetion += Convert.ToSingle(PDeleteClient.Tag);
            }
            return TotalPermetion;  
        }
        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == enMode.AddNew)
            {
                lbAddnewUser.Text = "Add New User";
                this.Text = "Add New User";
                _User = new User();

              tabPage2.Enabled = false;

                ctrlPersonWithFiltter1.FilterEnabled=true;
            }
            else
            {
                lbAddnewUser.Text = "Update User";
                this.Text = "Update User";

               tabPage2.Enabled = true;
                btnSave.Enabled = true;


            }

            tbUserName.Text = "";
           tbPassword.Text = "";
            tbConfirmPassword.Text = "";
            CHKIsActive.Checked = true;


        }

     
        private void frmAddnewUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Update)
            {
                _LoadData();
                ChekedStatus();
                tabControl1.SelectedIndex = 1;
            }
            else
            {
                ctrlPersonWithFiltter1.FilterEnabled = true;

            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tabControl1.SelectedIndex = 1;
                tabPage2.Enabled = true;
                return;
            }

            //incase of add new mode.
            if (ctrlPersonWithFiltter1.PersoID2 != -1)
            {

                if (business_Layer. User.isUserExsistbyPersonID(ctrlPersonWithFiltter1.PersoID2 ))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    btnSave.Enabled = true;
                    tabControl1.SelectedIndex = 1;
                    tabPage2.Enabled = true;
                }
            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
             

            }
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

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool ChecUserValidate()
        {

            if (tbConfirmPassword.Text != tbPassword.Text)
            {
                errorProvider1.SetError(tbConfirmPassword, "The Password Is incorrect");
                return false;

            }
            if (tbUserName.Text == "" && tbPassword.Text == "" && tbConfirmPassword.Text == "")
            {
                MessageBox.Show("The Text Boxes Must have a Value");
                return false;
            }

            return true;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            //business_Layer. User _User = new business_Layer.User();


            //if (ChecUserValidate() == true)
            //{

            //    _User.UserName = tbUserName.Text;
            //    _User.Password = CLsGlobal.ComputeHash(tbPassword.Text.Trim());

            //    _User.IsActive = CHKIsActive.Checked;
            //    _User.PersonID = ctrlPersonWithFiltter1.PersoID2;
            //    _User.Permetions =Convert.ToInt32( CalculateTotalPermetion());
            //    if (tbConfirmPassword.Text != tbPassword.Text)
            //    {

            //        errorProvider1.SetError(tbConfirmPassword, "The Password Is incorrect");
            //        return;
            //    }
            //    if (_User.Save())
            //    {
            //        MessageBox.Show("Data Saved Successfully.");
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error: Data Is not Saved Successfully.");

            //        LbUserID2.Text = _User.UserID.ToString();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Error: Data Is not Saved Successfully.");

            //}

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (tbPassword.Text == "" || tbConfirmPassword.Text == "")
            {
                MessageBox.Show( "The Text Boxes must have a value ",
                   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User.PersonID = ctrlPersonWithFiltter1.PersoID2;
            _User.UserName = tbUserName.Text.Trim();
            _User.Password =CLsGlobal.ComputeHash( tbPassword.Text.Trim());
            _User.IsActive = CHKIsActive.Checked;
            _User.Permetions= Convert.ToInt32( CalculateTotalPermetion());

            if (_User.Save())
            {
                LbUserID2.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
               lbAddnewUser.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonWithFiltter1_Load(object sender, EventArgs e)
        {

        }

        private void tbConfirmPassword_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void eAll_CheckedChanged(object sender, EventArgs e)
        {
            if (eAll.Checked)
            {
                CheckAllPermetaion();
            }

        }
    }
}
