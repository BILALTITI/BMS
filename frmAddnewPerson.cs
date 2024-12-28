using Bank_Project.Properties;
using business_Layer;
using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bank_Project
{
    public partial class frmAddnewPerson : Form
    {
        public delegate void DataBackEventHandler(object seder, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 }; private enMode _Mode;

        int _PersonID;
        Person _Person;
        public frmAddnewPerson _Sender;
        public frmAddnewPerson(int PersonID)
        {
             ;
            InitializeComponent();
            _PersonID = PersonID;
            if (_PersonID == -1)
               
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }
        public frmAddnewPerson()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {
            tbFirst.Focus();
            if (_Mode == enMode.AddNew)
            {
                RBmale.Checked = true;
                lbPersonMode.Text = "Add New Person";
                _Person = new Person();
                return;
            }
            _Person = Person.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("This Form Will be Close Becouse no Person Found ");
                this.Close();
                return;

            }
            lbPersonMode.Text = "Edit Person ID =" + _PersonID;
            LBPersonID.Text = _PersonID.ToString();
            tbFirst.Text = _Person.FirstName;
            tbNationalNO.Text = _Person.NationalNo;
            tbSecond.Text = _Person.SecondName;
            tbThird.Text = _Person.ThirdName;
            tbLast.Text = _Person.LastName;
            tbEmail.Text = _Person.Email;
            tbphone.Text = _Person.Phone;
            tbAddress.Text = _Person.Address;
            DTM.Value = _Person.DateOfBirth;

            if (_Person.ImagePath != "")
            {
                PBIMage.Load(_Person.ImagePath);
            }
            if (_Person.Gender == 0)
            {
                RBFemale.Checked = false;
                RBmale.Checked = true;
            }
            else
            {
                RBFemale.Checked = true;
                RBmale.Checked = false;
            }


            LLRemove.Visible = (_Person.ImagePath != "");


            if (_Person.Gender == 99)
            {
                RBFemale.Checked = false;
                RBmale.Checked = false;
            }

            //CBCountry.SelectedIndex = CBCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);

        }
        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != PBIMage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (PBIMage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = PBIMage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        PBIMage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        public static void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (tbFirst.Text == "" || tbSecond.Text == "" || tbLast.Text == "" || tbNationalNO.Text == "" || tbEmail.Text == "")
            {
                MessageBox.Show("The Text Boxes Must have a Value ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                if (!_HandlePersonImage())
                    return;
                //int CountryID = clsCountry.Find(CBCountry.Text).CountryID;

                _Person.FirstName = tbFirst.Text.Trim();
                _Person.SecondName = tbSecond.Text.Trim();
                _Person.ThirdName = tbThird.Text.Trim();
                _Person.LastName = tbLast.Text.Trim();
                _Person.NationalNo = tbNationalNO.Text.Trim();
                _Person.Email = tbEmail.Text.Trim();
                _Person.Phone = tbphone.Text.Trim();
                _Person.Address = tbAddress.Text.Trim();
                _Person.DateOfBirth = DTM.Value;
                //_Person.NationalityCountryID = CountryID;

                if (PBIMage.ImageLocation != null)
                    _Person.ImagePath = PBIMage.ImageLocation;
                else
                    _Person.ImagePath = "";

                if (RBmale.Checked)
                {
                    _Person.Gender = 0;
                }
                else
                {
                    _Person.Gender = 1;
                }
                if (_Person.Save())

                {
                    MessageBox.Show("Data Saved Successfully.");

                    //int    PersonID = int.Parse(LBPersonID.Text);
                    DataBack?.Invoke(this, _Person.PersonID ?? 0);
                    this.Close();
                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.");

                _Mode = enMode.Update;
                lbPersonMode.Text = "Edit Person ID = " + _Person.PersonID;
                LBPersonID.Text = _Person.PersonID.ToString();
            }
        }

        private void LLSETImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                PBIMage.ImageLocation = (selectedFilePath);
            }
            LLRemove.Visible = true;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            tbFirst.Focus();


            DTM.MaxDate = DateTime.Now.AddYears(-18);
            DTM.Value = DTM.MaxDate;

            _LoadData();
        }

        private void RBFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (RBFemale.Checked && PBIMage.ImageLocation == null)
            {
                PBIMage.Image = Resources.Female_512;
            }
        }

        private void RBmale_CheckedChanged(object sender, EventArgs e)
        {
            if (RBmale.Checked && PBIMage.ImageLocation == null)
            {
                PBIMage.Image = Resources.Male_512;

            }
        }

        private void LLRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PBIMage.ImageLocation = null;



            if (RBmale.Checked)
                PBIMage.Image = Resources.Male_512;
            else
                PBIMage.Image = Resources.Female_512;

            LLRemove.Visible = false;
        }

        private void frmAddnewPerson_Load(object sender, EventArgs e)
        {
            tbFirst.Focus();


            DTM.MaxDate = DateTime.Now.AddYears(-18);
            DTM.Value = DTM.MaxDate;

            _LoadData();
        }

        private void tbFirst_Validated(object sender, EventArgs e)
        {

        }

        private void tbFirst_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNationalNO.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNO, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbNationalNO, null);
            }

            //Make sure the national number is not used by another person
            if (tbNationalNO.Text.Trim() != _Person.NationalNo && Person.IsPersonExsist(tbNationalNO.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNO, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(tbNationalNO, null);
            }
        }

        private void tbNationalNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbNationalNO_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNationalNO.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNO, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbNationalNO, null);
            }

            //Make sure the national number is not used by another person
            if (tbNationalNO.Text.Trim() != _Person.NationalNo && Person.IsPersonExsist(tbNationalNO.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbNationalNO, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(tbNationalNO, null);
            }
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty.
            if (tbEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidatoin.ValidateEmail(tbEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(tbEmail, null);
            };

        }

        private void tbSecond_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
