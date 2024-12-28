using Data_Accses_Layer;
using DataAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_Layer
{
    public class User
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
    

  public  enum enPermissions
        {
            eAll = -1, pListClients = 1, pAddNewClient = 2, pDeleteClient = 4,
            pUpdateClients = 8, pFindClient = 16, pTranactions = 32, pManageUsers = 64
        };


        public int ?UserID { get; set; }
        public Person Personinfo { get; set; }
        public int ?PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Permetions { get; set; }

        public User()


        {
            this.UserID = null;
            this.UserName = "";
            this.Password = "";
            this.PersonID = null;
            this.IsActive = false;
            this.Permetions = 0;
            Mode = enMode.AddNew;

        }

        private User(int? uerID, string userName, string password, bool isActive, int? PersonalID,int Permetions)
        {

            UserID = uerID;
            UserName = userName;
            Password = password;
            this.Permetions= Permetions;
            IsActive = isActive;
            
            this.PersonID = PersonalID;
            this.Personinfo =Person.Find(PersonalID);
             Mode = enMode.Update;
        }
        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsUserData.AddNewUser(this.UserName, this.Password, this.IsActive, this.PersonID,this.Permetions);

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUserData.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive, this.PersonID,this.Permetions);
        }
        public static User Find(int? UserID)
        {

            //UserID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;
            int? PersonID = null;
            int Permetions = 0;
            if (clsUserData.GetUserByID(UserID, ref UserName, ref Password, ref IsActive, ref PersonID,ref Permetions))

                return new User(UserID, UserName, Password, IsActive, PersonID, Permetions);
            else
                return null;
        }
        public static User FindUserName(string UserName)
        {
            int? UserID = null;
            //UserID = -1;
             string Password = "";
            bool IsActive = false;
            int? PersonID = null;
            int Permetions = 0;
            if (clsUserData.GetUserByUserName(UserName, ref UserID , ref Password, ref IsActive, ref PersonID, ref Permetions))

                return new User(UserID, UserName, Password, IsActive, PersonID, Permetions);
            else
                return null;
        }
        public static User FindByUserNameAndPassword(string UserName,
        string Password)
        {

            int? UserID = null;
            bool IsActive = false;
            int?     PersonID = null;
            int Permetions =0;
            if (clsUserData.GetUserInfoByUsernameAndPassword(UserName, Password,
      ref UserID, ref PersonID, ref IsActive,ref Permetions))

                return new User(UserID, UserName, Password, IsActive, PersonID, Permetions);
            else
                return null;
        }
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }




            return false;
        }
        public static DataTable GetAllUser()
        {
            return clsUserData.GetAllUser();

        }

        public static bool DeletetUser(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }

        public static bool isUserExsist(int ID)
        {
            return clsUserData.IsUserExsist(ID);
        }
        public static bool isUserExsistByUsername(string UserName)
        {
            return clsUserData.IsUserExsistbyUserNAme(UserName);
        }
        public static bool isUserExsistbyPersonID(int PersonID)
        {
            return clsUserData.IsUserExsistbyPersonID(PersonID);
        }
    
}
}
