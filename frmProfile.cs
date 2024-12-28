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

namespace Bank_Project
{
    public partial class frmProfile : Form
    {
        User _User;
        private int _UserID;
        public frmProfile(int userID)
        {
            InitializeComponent();
            _UserID = userID;
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


            if (_User.Permetions ==Convert.ToSingle( pAddNewClient.Tag))
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
        private void frmProfile_Load(object sender, EventArgs e)
        {
            _User = User.Find(_UserID);
            ctrlPersoncard1.ShowCard(_User.PersonID ?? 0);
            GBPermetions.Enabled = false;
            //GBPermetions.=_User.Permetions.ToString();

            ChekedStatus();
        }

        private void LLChangeMyPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(CLsGlobal.CurrentUser.UserID??0);
            changePassword.ShowDialog();
        }

        private void GBPermetions_Enter(object sender, EventArgs e)
        {

        }
    }
}
