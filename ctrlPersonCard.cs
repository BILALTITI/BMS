using Bank_Project.Properties;
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
using System.IO;

namespace Bank_Project
{
    public partial class ctrlPersoncard : UserControl
    {
        int _PersonID;
        Person _Person;
        business_Layer.User _User;
         public ctrlPersoncard(int PersonID)
        {
            InitializeComponent();
            _PersonID= PersonID;
        }
        public ctrlPersoncard()
        {
            InitializeComponent();
         }
        public int userID { get; set; }
        public int PersonID { get; set; }
        public void RestDefaultData()
        {
            this.PersonID = -1;
           fullname.Text = "???";
          NationalNo2.Text = "???";
           email.Text = "???";
           phone.Text = "???";
          Address.Text = "???";
           birth.Text = "???";
           Gendor.Text = "???";
            
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gender == 0)
                PBIMage2.Image = Resources.Female_512;
            else
                PBIMage2.Image = Resources.Male_512;
            string ImagePath = _Person.ImagePath;
            if (File.Exists(ImagePath))
                PBIMage2.ImageLocation = ImagePath;
            else
                return;
            //    MessageBox.Show("Error Cant Load Photo");

        }
        public void ShowCard(string NationalNo)
        {
           _Person  = Person.Find(NationalNo);
            if (_Person == null)
            {
                PersonID = -1;
                RestDefaultData();
                return;

            }

            Personid.Text = NationalNo.ToString();
            this.PersonID = _Person.PersonID??0;
            fullname.Text = _Person.FullName();
            NationalNo2.Text = _Person.NationalNo;
            email.Text = _Person.Email;
          phone.Text = _Person.Phone;
            Address.Text = _Person.Address;
            birth.Text = _Person.DateOfBirth.ToString();
            Gendor.Text = _Person.GetGendor();
             
            _LoadPersonImage();

        }
        public void ShowCard(int PersonID)
        {
            _Person = Person.Find(PersonID);
            if (_Person == null)
            {
                RestDefaultData();
                PersonID = -1;
                MessageBox.Show($"PersonID = -1 ");
                return;

            }
            else
            {



                Personid.Text = PersonID.ToString();
                this.PersonID = _Person.PersonID??0;

                fullname.Text = _Person.FullName();
              NationalNo2.Text = _Person.NationalNo;
                email.Text = _Person.Email;
               phone.Text = _Person.Phone;
               Address. Text = _Person.Address;
                birth.Text = _Person.DateOfBirth.ToString();
              Gendor.Text = _Person.GetGendor();
                 _LoadPersonImage();
            }
        }
        private void ctrlPersoncard_Load(object sender, EventArgs e)
        {

        }

        private void LLEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddnewPerson frmEditORADD = new frmAddnewPerson(PersonID);
            frmEditORADD.ShowDialog();
            ShowCard(PersonID);
        }
    }
}
