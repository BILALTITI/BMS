using Data_Accses_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_Layer
{
    public class Person
    {


        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? PersonID { set; get; }

        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string  ThirdName { set; get; }
        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }
        public string LastName { set; get; }
        public string NationalNo { set; get; }
        public int NationalityCountryID { set; get; }
        public byte Gender { set; get; }
        public string GetGendor()
        {
            return Gender == 1 ? "Male" : "Female";
        }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }

        public string ImagePath { set; get; }

        public Person()

        {
            this.PersonID = null;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.MinValue;
            //this.NationalityCountryID = -1;
            this.ImagePath = "";
            this.Gender = 99;
            Mode = enMode.AddNew;

        }

        private Person(int ?PersonID, string FirstName, string SecondName,
          string ThirdName, string LastName,
            string NationalNo, byte Gender,
            string Email, string Phone, string Address, DateTime DateOfBirth, string ImagePath)
        {

            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.LastName = LastName;

            this.ThirdName = ThirdName;
            this.PersonID = PersonID;
            this.Gender = Gender;
             this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }
        private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo,
                this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.Email,
                this.Phone, this.Gender, this.Address, this.DateOfBirth,
                this.ImagePath);

            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName
           , this.ThirdName, this.LastName, this.Email, this.Phone
           , this.Gender, this.Address, this.DateOfBirth, this.ImagePath);

        }
        public static Person Find(int? PersonID)
        {

            string FirstName ="";
            string SecondName ="";
            string ThirdName ="";
            byte Gender =99;

            string LastName ="";
            string Email ="";
            string Phone ="";
            string Address ="";
            DateTime DateOfBirth = DateTime.MinValue;
             string ImagePath ="";
            string NationalNo ="";

            bool isfound = clsPersonData.GetPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName
            , ref ThirdName, ref LastName, ref Email, ref Phone
            , ref Gender, ref Address, ref DateOfBirth, ref ImagePath);


            if (isfound)
                return new Person(PersonID, FirstName, SecondName,
             ThirdName, LastName,
              NationalNo, Gender,
              Email, Phone, Address, DateOfBirth, ImagePath);
            else
                return null;
        }
        public static Person Find(string NationalNo)
        {

            int? PersonalID = null;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            byte Gender = 99;
            string LastName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            DateTime DateOfBirth = DateTime.Now;
            //int nationalitycountryID = -1;
            string ImagePath = "";

            if (clsPersonData.GetPersonByNationalNo(NationalNo, ref PersonalID, ref FirstName, ref SecondName
            , ref ThirdName, ref LastName, ref Email, ref Phone
            , ref Gender, ref Address, ref DateOfBirth, ref ImagePath))

                return new Person(PersonalID, FirstName, SecondName,
              ThirdName, LastName,
             NationalNo, Gender,
              Email, Phone, Address, DateOfBirth, ImagePath);
            else
                return null;
        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }




            return false;
        }
        public static DataTable GetAllPerson()
        {
            return clsPersonData.GetAllPerson();

        }

        public static bool DeletetPerso(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool isPersonExsist(int ID)
        {
            return clsPersonData.IsPersonExsist(ID);
        }

        public static bool IsPersonExsist(string NationalNo)
        {


            return clsPersonData.IsPersonExsist(NationalNo);
        }
    }


}
