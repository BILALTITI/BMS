using business_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 

namespace business_Layer
{
    public class Transactions
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ?TransactionID { get; set; }
        public int? ClientID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Describe { get; set; }

        public Transactions()


        {
            this.TransactionID =null;
            this.Describe = "";
            this.ClientID=null;
            this.TransactionDate = DateTime.MinValue;
            this.Amount =0;
            this.TransactionType = "";
            Mode = enMode.AddNew;

        }

        private Transactions(int? TransactionID,   int? ClientID,   string TransactionType,   decimal Amount
       ,   DateTime TransactionDate,   string Describe)
        {
            this.TransactionID=TransactionID;
          this.ClientID= ClientID;
            this.TransactionType=TransactionType;
            this.Amount=Amount;
            this.Describe = Describe;
            this.TransactionDate=TransactionDate;
             Mode = enMode.Update;
        }
         private bool _AddNewTransaction()
        {
            //call DataAccess Layer 

            this.TransactionID = Transactionsdata.AddnewTransaction(this.ClientID,this.TransactionType,this.Amount,this.TransactionDate,this.Describe);

            return (TransactionID != -1);
        }
        private bool _UpdateTransactions()
        {
            //call DataAccess Layer 

            return Transactionsdata.UpdateTransaction(this.TransactionID,this.ClientID, this.TransactionType, this.Amount, this.TransactionDate, this.Describe);
        }
        public static Transactions Find(int ?TransactionID)
        {
            int? ClientID = null;
            string Describe = "";
            string TransactionType = "";
            decimal Amount = 0;
            DateTime TransactionDate = DateTime.MinValue;

            if (Transactionsdata.GetTransactionsbyTransactionID(TransactionID, ref ClientID, ref TransactionType, ref Amount
       , ref TransactionDate, ref Describe))

                return new Transactions(TransactionID, ClientID, TransactionType, Amount
       , TransactionDate, Describe);
            else
                return null;
        }
         

        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransaction())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTransactions();

            }




            return false;
        }
        public static DataTable GetAllTransactions()
        {
            return Transactionsdata.GetAllTransactions();

        }
        public static DataTable GetDeposit()
        {
            return Transactionsdata.GetAllDeposit();

        }

        public static bool DeletetTransactions(int ID)
        {
            return Transactionsdata.DeleteTransaction(ID);
        }

        public static bool isTransactionsExsist(int ID)
        {
            return Transactionsdata.IsTransactionExsist(ID);
        }
         
    }
}
