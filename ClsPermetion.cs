using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static Bank_Project.ClsPermetion;
using static business_Layer.User;

namespace Bank_Project
{
    public static class ClsPermetion
    {


        public enum enPermissions
        {
            eAll = -1,
            pListClients = 1,
            pAddNewClient = 2,
            pDeleteClient = 4,
            pUpdateClients = 8,
            PPeopleList = 16,
            pTransactions = 32,
            pManageUsers = 64,
              PLogs=128
        }
        public class PermissionChecker
        {
            private  enPermissions  _permissions;

            public enPermissions Permissions
            {
                get { return _permissions; }
                set { _permissions = value; }
            }

            public  PermissionChecker(enPermissions permissions)
            {
                _permissions = permissions;
            }

            //// The method to check access permissions
            public  static  bool CheckAccessPermission(enPermissions permission, int _permissions  )
            {
                if((enPermissions)_permissions==enPermissions.eAll)
                    return true;
                return (_permissions &(int) permission) == (int)permission;
            }
            
        }
        



    }
}
