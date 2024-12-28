using DataAccsesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business_Layer
{
    public class Logs
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public string UserName { get; set; }
        public int ?LogID { get; set; }
        public DateTime LogDate { get; set; }
        public string Action { get; set; }
        public int Permetions { get; set; }

        public Logs()


        {
            this.Permetions = 0;
             this.Action = "";
            this.LogID = null;
            this.UserName = "";
            this.LogDate = DateTime.MinValue;    
            Mode = enMode.AddNew;

        }

        private Logs(int? LogID, string UserName , DateTime LogDate,   string Action,int Permetions)
        {

            this.Action = Action;
          this.UserName = UserName;
            this.LogID = LogID ;
             this.LogDate=LogDate;
            this.Permetions= Permetions;
            Mode = enMode.Update;
        }
        private bool _AddNewLog()
        {
            //call DataAccess Layer 

            this.LogID = ClsLogs.AddNewLogs(this.UserName,this.LogDate,this.Action,this.Permetions);

            return (this.LogID != -1);
        }
        private bool _UpdateLogs()
        {
            //call DataAccess Layer 

            return ClsLogs.UpdateLogs(this.LogID,this.UserName, this.LogDate, this.Action,this.Permetions);
        }
        public static Logs Find(int LogID)
        {

           int Permetions = 0;
            string UserName = "";
            DateTime LogDate = DateTime.MinValue;
            string Action = "";

            if (ClsLogs.GetLogsByLogID( LogID, ref UserName,ref  LogDate, ref  Action ,ref Permetions))

                return new Logs(LogID, UserName,  LogDate,  Action , Permetions);
            else
                return null;
        }

  
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLog())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLogs();

            }




            return false;
        }
        public static DataTable GetAllLogs()
        {
            return ClsLogs.GetAllLogs();

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
