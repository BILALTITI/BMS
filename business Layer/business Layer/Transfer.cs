using DataAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_Layer
{
    public class Transfer
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int ?ClientID { get; set; }

        public int ?TransferID { get; set; }
        public DateTime TransferDate { get; set; }
        public string TransferFrom { get; set; }
        public decimal Amount { get; set; }
        public string Describe { get; set; }
        public string TransferTo { get; set; }
        public Transfer()


        {
            this.TransferTo = "";
            this.ClientID = null;
            this.Describe = "";
            this.TransferID = null;
            this.TransferDate = DateTime.MinValue;
            this.Amount = 0;
            this.TransferFrom = "";
            Mode = enMode.AddNew;

        }

        private Transfer(int? TransferID,   string TransferFrom,   string TransferTo,   decimal Amount
   , ref DateTime TransferDate,   int? ClientID,   string Describe)
        {
            this.ClientID = ClientID;
            this.TransferID = TransferID;
            this.TransferFrom = TransferFrom;
            this.Amount = Amount;
            this.Describe = Describe;
            this.TransferDate = TransferDate;
            this.TransferTo= TransferTo;
            Mode = enMode.Update;
        }
        private bool _AddNewTransfer()
        {
            //call DataAccess Layer 

            this.TransferID = clsTransfer.AddnewTransfer(this. TransferFrom, this.TransferTo, this.Amount
   , this.TransferDate, this.ClientID, this.Describe);

            return (TransferID != -1);
        }
        private bool _UpdateTransfer()
        {
            //call DataAccess Layer 

            return clsTransfer.UpdateTransfer(this.TransferID,this.TransferFrom, this.TransferTo, this.Amount
   , this.TransferDate, this.ClientID, this.Describe);
        }
        public static Transfer Find(int? TransferID)
        {
             string Describe = "";
            string TransferFrom = "";
            string TransferTo = "";
            decimal Amount = 0;
            DateTime TransferDate = DateTime.MinValue;
            int? ClientID = null;
 
            if (clsTransfer.GetTransferByTransferID(  TransferID, ref   TransferFrom, ref   TransferTo, ref   Amount
   , ref   TransferDate, ref ClientID, ref   Describe))

                return new Transfer(  TransferID,   TransferFrom,   TransferTo,   Amount
   , ref   TransferDate, ClientID,   Describe);
            else
                return null;
        }


        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransfer())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTransfer();

            }




            return false;
        }
        public static DataTable GetAllTransfer()
        {
            return clsTransfer.GetAllTransfer();

        }

        public static bool DeletetTransfer(int ID)
        {
            return clsTransfer.DeleteTransfer(ID);
        }

        public static bool isTransferExsist(int ID)
        {
            return clsTransfer.IsTransferExsist(ID);
        }

    }
}

