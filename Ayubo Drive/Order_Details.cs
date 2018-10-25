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
    

    public partial class Order_Details : Form
    {
        SqlConnection m_con = new DatabaseConnection().getConnection();
        public static int WEEKLY_RENT = 10000;
        public static int V_Monthly_Rent = 40000;
        public int BaseCost = 0;
        public double waitingcharge = 0;
        public int extrakmcharge = 0;
        public int overnightstaycharge = 0;
        public double totalhirecost = 0;
        public int MaxKm = 0;
        public Driver d;
        public Vehicle v;
        public Package p;
        public Hire h;
        public Job j;
        public int days = 0;
        Common c = new Common();
        public Order_Details()
        {
            InitializeComponent();
            Console.WriteLine("----------------------->", Form_customer.lastJobId);
        }

        private void comboBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("----------------------->", Form_customer.lastJobId);
            if (comboBox2.SelectedValue != null)
            {
                string J_Id = comboBox2.SelectedValue.ToString();

                j = c.GetJobById(J_Id);

                label26.Text = j.C_Name;
                label28.Text = j.V_Type;
                label29.Text = j.Duration;
                label30.Text = j.D_Name;
                //label31.Text = j.Packagename;
                //label32.Text = j.extrakm
                //label33.Text = j.extrahour;
                label34.Text = j.Cost;

            }






        }

        private void Order_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_driveDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.ayubo_driveDataSet.Job);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_customer fc = new Form_customer();
            fc.Show();
            this.Hide();
       
        }
    }
}
