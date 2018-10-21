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
        public Form_customer()
        {
            InitializeComponent();
        }

        private void PrintConsole(String title, String message)
        {
            Console.WriteLine(title + " = " + message);
        }

        private void doCalulation()
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
                int days = Convert.ToInt32(dDays);
                PrintConsole("Number of days ", days.ToString());

                Common c = new Common();
                Driver d = c.GetDriverRowById(driverId);
                Vehicle v = c.GetVehicleTypeById(vTypeID);
    
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
                m_con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = m_con;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select V_Rate from VehicleType where V_Type_Id ='" + comboBox1.Text + "' ";

                int sql = 0;
                int intsql2 = 0;
                int intsql3 = 0;
                using (SqlDataReader sql1 = cmd.ExecuteReader())
                {
                    if (sql1.Read())
                    {
                        sql = Convert.ToInt32(String.Format("{0}", sql1["V_Rate"]));

                    }

                }

                m_con.Close();
                m_con.Open();
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = m_con;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select D_Rate_Per_Hr from Driver where D_Name ='" + comboBox7.Text + "' ";
                using (SqlDataReader sql3 = cmd1.ExecuteReader())
                {

                    if (sql3.Read())
                    {
                        intsql3 = Convert.ToInt32(String.Format("{0}", sql3["D_Rate_Per_Hr"]));
                    }
                }
                DateTime d1 = dateTimePicker1.Value;
                DateTime d2 = dateTimePicker2.Value;

                TimeSpan t = d2 - d1;
                double dDays = t.TotalDays;
                int days = Convert.ToInt32(dDays);
                //label7.Text = days.ToString() + "Days";

                int order = sql + intsql3 + days;
                lblCost.Text = Convert.ToString(order);



            }

            catch (Exception ex)
            {
                MessageBox.Show("Error");
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
