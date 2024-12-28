using Data_Accses_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccsesLayer;

namespace business_Layer
{
    public class Client
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public Nullable <int>   ClientID { set; get; }
     public   Person Personinfo { set; get; }
        public int? PersonID { set; get; }
     public string AccountID { set; get; }


        public string AccountType { set; get; }
        public decimal Balance { set; get; }
        public DateTime OpenDate { set; get; }


        public bool IsActive {  set; get; }          

      
        public Client()

        {
            this.ClientID = null;
            this.PersonID = null;
            this.AccountID = "";
            this.AccountType = "";
            this.Balance = 0;
             this.OpenDate = DateTime.MinValue;
            this.IsActive = false;
            Mode = enMode.AddNew;

        }

        private Client(Nullable< int> ClientID,Nullable <int> PersonID, string AccountID, string AccountType,decimal Balance,DateTime OpenDate,bool IsActive)
        {
             this.ClientID= ClientID??0;
            this.AccountID= AccountID;
            this.PersonID= PersonID??0;
            this.Personinfo = Person.Find(PersonID ?? 0);
            this.AccountType = AccountType;
            this.Balance = Balance;
            this.OpenDate = OpenDate;
            this.IsActive=IsActive;

            Mode = enMode.Update;
        }
        private bool _AddNewClient()
        {
            //call DataAccess Layer 

            this.ClientID = ClsClientData.AddNewClient(this.AccountID,this.PersonID ?? 0,this.AccountType,this.Balance,this.OpenDate,this.IsActive);

            return (this.ClientID != -1);
        }
        private bool _UpdateClient()
        {
            //call DataAccess Layer 

            return ClsClientData.UpdateCLient(this.ClientID??0, this.AccountID, this.PersonID ?? 0, this.AccountType, this.Balance, this.OpenDate,this.IsActive);

        }
        public static Client Find(int ?ClientID)
        {
            string AccountID = "";


         int ? PersonID = null;
            string AccountType = "";
            decimal Balance = 0;
            bool IsActive = false;
            DateTime OpenDate = DateTime.MinValue;
            bool isfound = ClsClientData.GetClientByClientID(ClientID??0, ref AccountID, ref PersonID    , ref AccountType 
            , ref Balance, ref OpenDate,ref IsActive);


            if (isfound)
                return new Client(ClientID ?? 0, PersonID , AccountID,AccountType,Balance,OpenDate, IsActive);
            else
                return null;
        }
        public static Client FindByAccountID(string AccountID)
        {
            int ?ClientID = null;


            int? PersonID = null;
            string AccountType = "";
            decimal Balance = 0;
            bool IsActive = false;
            DateTime OpenDate = DateTime.MinValue;
            bool isfound = ClsClientData.GetClientByAccountID(AccountID,ref ClientID  , ref PersonID
            , ref AccountType
            , ref Balance, ref OpenDate, ref IsActive);


            if (isfound)
                return new Client(ClientID, PersonID, AccountID, AccountType, Balance, OpenDate, IsActive);
            else
                return null;
        }

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewClient())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateClient();

            }




            return false;
        }
        public static DataTable GetAllClient()
        {
            return ClsClientData.GetAllCLient();

        }

        public static bool DeletetClient(int ID)
        {
            return ClsClientData.DeleteClient( ID);
        }

        public static bool isClientExsist(int ID)
        {
            return ClsClientData.IsClientExsist(ID);
        }
        public static bool isClientExsistByAccountID(string AccountID)
        {
            return ClsClientData.IsClientExsistbyAccountID(AccountID);
        }
        public static bool _UpdateDepositClient(int ClientID ,decimal Balance)
        {
            //call DataAccess Layer 

            return ClsClientData.UpdateDepositCLient(ClientID,   Balance );

        }
        public static bool _UpdateWithdraeClient(int ClientID, decimal Balance)
        {
            //call DataAccess Layer 

            return ClsClientData.UpdateWithSrawCLient(ClientID, Balance);

        }
        public static bool _UpdateDepositClientByAccountID(string AccountID, decimal Balance)
        {
            //call DataAccess Layer 

            return ClsClientData.UpdateDepositCLientByAccountID(AccountID, Balance);

        }
        public static bool _UpdateWithdraeClientByAccountID(string AccountID, decimal Balance)
        {
            //call DataAccess Layer 

            return ClsClientData.UpdateWithSrawCLientByAccountID(AccountID, Balance);

        }
    }
}
