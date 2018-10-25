using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Ayubo_Drive
{
    public partial class Admin : Form
    {
        SqlConnection m_con = new DatabaseConnection().getConnection();
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_driveDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.ayubo_driveDataSet.Job);

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Vehicle VALUES ("+textBox11.Text+",'"+textBox12.Text+"') ";
            SqlCommand cmd = new SqlCommand(sql, m_con);
            m_con.Open();
            m_con.Close();
        }
    }
}
