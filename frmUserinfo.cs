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

namespace Bank_Project
{
    public partial class frmUserinfo : Form
    {
        private int _UserID;
        User _User;
        public frmUserinfo(int UserID)
        {
            InitializeComponent();
        _UserID = UserID;
        }
        public frmUserinfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserinfo_Load(object sender, EventArgs e)
        {
            _User = User.Find(_UserID);
            ctrlUserInfo1.LoadUserInfo(_UserID);
//            ctrlUserInfo1._FillPersonInfo(_User.PersonID);
        }
    }
}
