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
    public partial class frmDashBoard : Form
    {

        DataTable dtUser =business_Layer.User.GetAllUser();   
        DataTable dtClient= Client.GetAllClient();
        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            lbCOuntUser.Text = dtUser.Rows.Count.ToString();
            lbClientCount.Text = dtClient.Rows.Count.ToString();
    

        }

        private void lbCOuntUser_Click(object sender, EventArgs e)
        {

        }
    }
}
