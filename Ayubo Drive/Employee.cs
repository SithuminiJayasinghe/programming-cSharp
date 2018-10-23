using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_Drive
{
    public partial class Form_employee : Form
    {
        Common c = new Common();
        public Form_employee()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form_employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_driveDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.ayubo_driveDataSet.Job);
            Driver d = c.GetDriverRowById(Form_sign_in.CUSTOMER_ID);
            lblId.Text = d.D_ID;
            lblName.Text = d.D_NAME;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
