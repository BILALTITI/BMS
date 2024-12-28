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
    public partial class ctrlPersonWithFiltter : UserControl
    {
        private bool _ShoeAddPerson = true;
        public delegate void DataBackEventHandler(object seder, int PersonID);
        public event DataBackEventHandler DataBack;
        public event EventHandler< int>OnPersonSelected;
        private bool ShoeAddPerson
        {
            get
            {
                return _ShoeAddPerson;


            }
            set
            {
                _ShoeAddPerson = value;
                PBAddnewPerson.Visible = _ShoeAddPerson;

            }
        }
        public bool _FilterEnabled;
        public bool FilterEnabled

        {
            get { return _FilterEnabled; }
            set { _FilterEnabled = value; groupBox1.Enabled = _FilterEnabled; }
        }  
         
        public string txtSearchValue { set { tbFilter.Text = value; } }
        public int SelectIndexCombox { set { CBFilter.SelectedIndex = value; } }
        public int _PersonID { set; get; }
        public int PersoID2
        {
            get { return ctrlPersoncard1.PersonID; }

        }
        public ctrlPersonWithFiltter(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        public ctrlPersonWithFiltter()
        {
            InitializeComponent();
        }
        public void ShowCard(int PersonID)
        {
            ctrlPersoncard1.ShowCard(PersonID);
        }
       public void _TBFoucs()
        {
            tbFilter.Focus();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (tbFilter.Text == "")
            {



                MessageBox.Show("Message box Must contain A value");

                return;
            }
            if (CBFilter.Text == "PersonID")
            {
           int PersonID = int.Parse(tbFilter.Text);
                DataBack?.Invoke(this, PersonID);
                ctrlPersoncard1.ShowCard(PersonID);
                if (OnPersonSelected != null) OnPersonSelected(this, PersonID);
               

            }
            else
            {
                string NationalNo = tbFilter.Text;

                ctrlPersoncard1.ShowCard(NationalNo);


            }
        }

        private void ctrlPersonWithFiltter_Load(object sender, EventArgs e)
        {
            CBFilter.SelectedIndex = 0;
          }

        private void ctrlPersoncard1_Load(object sender, EventArgs e)
        {

        }

        private void PBAddnewPerson_Click(object sender, EventArgs e)
        {
            frmAddnewPerson frm = new frmAddnewPerson(-1);
            frm.DataBack += Form2_DataBack;
            frm.ShowDialog();
            ctrlPersonWithFiltter_Load(null, null);

        }
        private void Form2_DataBack(object sender,int PersonID)
        {
            tbFilter.Text = PersonID.ToString();
            ctrlPersoncard1.ShowCard(PersonID);
          
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
 
    }
    }
}
