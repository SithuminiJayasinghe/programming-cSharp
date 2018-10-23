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
    public partial class Form_customer : Form
    {

        SqlConnection m_con = new DatabaseConnection().getConnection();
        public static int WEEKLY_RENT = 10000;
        public Driver d;
        public Vehicle v;
        public int days = 0;
        Common c = new Common();
        public Form_customer()
        {
            InitializeComponent();
        }

        private void PrintConsole(String title, String message)
        {
            Console.WriteLine(title + " = " + message);
        }

        private int doCalulation()
        {
            if(comboBox1.SelectedValue != null && comboBox7.SelectedValue != null)
            {
                string vTypeName = comboBox1.Text;
                string vTypeID = comboBox1.SelectedValue.ToString();
                PrintConsole("on Changed combo1 vTypeName ", vTypeName);
                PrintConsole("on Changed combo1 vTypeID ", vTypeID);

                String driverName = comboBox7.Text;
                String driverId = comboBox7.SelectedValue.ToString();
                PrintConsole("on Changed combo1 driverName ", driverName);
                PrintConsole("on Changed combo1 driverId ", driverId);


                DateTime d1 = dateTimePicker1.Value;
                DateTime d2 = dateTimePicker2.Value;

                TimeSpan t = d2 - d1;
                double dDays = t.TotalDays;
                days = Convert.ToInt32(dDays);
                PrintConsole("Number of days ", days.ToString());

               
                d = c.GetDriverRowById(driverId);
                v = c.GetVehicleTypeById(vTypeID);
    
                PrintConsole("Driver Rate ", d.D_Rate_Per_Hr.ToString());
                PrintConsole("Driver D_Daily_Rate ", d.D_Daily_Rate.ToString());
                PrintConsole("Vehicle V_Rate ", v.V_Rate.ToString());
                PrintConsole("Vehicle V_Weekly_Rate ", v.V_Weekly_Rate.ToString());

                // lets find the no of weeks
                int numberOfWeeks = days / 7;
                PrintConsole("numberOfWeeks ", numberOfWeeks.ToString());


                // lets find no of remaining days
                int remainingDays = days % 7;
                PrintConsole("remainingDays ", remainingDays.ToString());


                int totalValue = v.V_Weekly_Rate * numberOfWeeks + v.V_Rate * remainingDays; 
                if (radioButton_without_a_driver.Checked == true)
                {
                     
                    PrintConsole("totalValue without driver ", totalValue.ToString());

                }
                else
                {
                    // This is with driver. So we have to add driver rate.
                    totalValue = totalValue + d.D_Daily_Rate * days;
                    PrintConsole("totalValue with driver ", totalValue.ToString());
                }
                lblCost.Text = totalValue.ToString();
                lblNoOfDays.Text = days.ToString();
                label5.Text = v.V_Rate.ToString();
                label49.Text = v.V_Weekly_Rate.ToString();
                return totalValue;
            } else
            {
                return 0;
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_driveDataSet.Driver' table. You can move, or remove it, as needed.
            this.driverTableAdapter.Fill(this.ayubo_driveDataSet.Driver);
            // TODO: This line of code loads data into the 'ayubo_driveDataSet.VehicleType' table. You can move, or remove it, as needed.
            this.vehicleTypeTableAdapter.Fill(this.ayubo_driveDataSet.VehicleType);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_sign_in fsi = new Form_sign_in();
            fsi.Show();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_sign_in fsi = new Form_sign_in();
            fsi.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doCalulation();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = c.GetCustomerById(Form_sign_in.USER_ID);
                int total = doCalulation();
                string sql = "INSERT INTO job VALUES(" + customer.C_Id + ",'"+customer.C_Name+"','Rent'," + total + ",'" + v.V_Type_Name + "'," + d.D_ID + ",'"+d.D_NAME+"','"+days+"');";

                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();

                MessageBox.Show("Successfully added new order");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Something went wrong. PLease check your inputs");
            }
            finally
            {
                m_con.Close();
            }



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            doCalulation();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            doCalulation();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            doCalulation();
        }

        private void radioButton_with_a_driver_CheckedChanged(object sender, EventArgs e)
        {
            doCalulation();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
