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
    public partial class FrmLoginLogs : Form
    {
        User _User;
       DataTable DataTable=Logs.GetAllLogs();
        public FrmLoginLogs()
        {
            InitializeComponent();
        }

        private void FrmLoginLogs_Load(object sender, EventArgs e)
        {
         DataTable=Logs.GetAllLogs();   
            dataGridView1.DataSource=DataTable;

        }

        private void showLogsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string LogsID = (string)dataGridView1.CurrentRow.Cells[1].Value;
            _User= User.FindUserName(LogsID);
            frmUserinfo frmUserinfo = new frmUserinfo(_User.UserID ?? 0);
            frmUserinfo.ShowDialog();
        }
    }
}
