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

            try
            {
                string sql = "INSERT INTO Vehicle VALUES (" + textBox11.Text + ",'" + textBox12.Text + "') ";

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully added new vehicle");


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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("vId", textBox11.Text.ToString());
            textBox12.Clear();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("vtypeId", textBox12.Text.ToString());
        }

        private void button16_Click(object sender, EventArgs e)
        {

            try
            {
                string sql = "INSERT INTO VehicleType VALUES (" + textBox14.Text + ",'" + textBox13.Text + "'," + textBox2.Text + "," + textBox1.Text + ") ";

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully added new vehicle");


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

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("vtypeId", textBox14.Text.ToString());

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("vtypename", textBox13.Text.ToString());

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("vdailu rate", textBox2.Text.ToString());

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("vweekly rate", textBox1.Text.ToString());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT into Driver VALUES ('" + textBox23.Text + "'," + textBox22.Text + "," + textBox20.Text + "," + textBox21.Text + ") ";

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully added new vehicle");


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

        private void button12_Click(object sender, EventArgs e)
        {

            try
            {
                string sql = "INSERT INTO Package VALUES ('" + textBox29.Text + "','" + textBox28.Text + "','" + textBox27.Text + "','" + textBox26.Text + "','" + textBox25.Text + "','" + textBox19.Text + "','" + textBox18.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox15.Text + "') ";

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully added new vehicle");


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

        private void textBox15_TextChanged(object sender, EventArgs e)
        {



        }

        private void button13_Click(object sender, EventArgs e)
        {
            {
                m_con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = m_con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Vehicle where V_Id='" + textBox11.Text + "'";


                SqlDataReader sdr = cmd.ExecuteReader();

                string V_Id = "";
                string V_Type_Id = "";

                while (sdr.Read())
                {


                    V_Id = sdr["V_Id"].ToString();
                    V_Type_Id = sdr["V_Type_Id"].ToString();


                }
                textBox11.Text = V_Id;
                textBox12.Text = V_Type_Id;



                m_con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {




            try
            {

                string sql = "DELETE from Vehicle where V_Id='" + textBox11.Text + "'";

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully deleted vehicle");


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

            textBox11.Clear();
            textBox12.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {

                string sql = "DELETE from VehicleType where V_Type_Id='" + textBox14.Text + "'";

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully deleted vehicle");


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

            textBox14.Clear();
            textBox13.Clear();
            textBox2.Clear();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = "DELETE from Driver where D_Name='" + textBox23.Text + "'";

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully deleted vehicle");


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

            textBox23.Clear();
            textBox22.Clear();
            textBox21.Clear();
            textBox20.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            {
                m_con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = m_con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from VehicleType where V_Type_Id='" + textBox14.Text + "'";


                SqlDataReader sdr = cmd.ExecuteReader();

                string V_Type_Id = "";
                string V_Type_Name = "";
                string V_Rate = "";
                string V_Weekly_Rate = "";

                while (sdr.Read())
                {


                    V_Type_Id = sdr["V_Type_Id"].ToString();
                    V_Type_Name = sdr["V_Type_Name"].ToString();
                    V_Rate = sdr["V_Rate"].ToString();
                    V_Weekly_Rate = sdr["V_Weekly_Rate"].ToString();


                }
                textBox14.Text = V_Type_Id;
                textBox13.Text = V_Type_Name;
                textBox2.Text = V_Rate;
                textBox1.Text = V_Weekly_Rate;


                m_con.Close();
            }

          
            }

        private void button15_Click(object sender, EventArgs e)
        {
            
                m_con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = m_con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Driver where D_Name='" + textBox23.Text + "'";


                SqlDataReader sdr = cmd.ExecuteReader();

                string D_Name = "";
                string D_Rate_Per_Hr = "";
                string D_Password = "";
                string D_Daily_Rate = "";

                while (sdr.Read())
                {


                D_Name = sdr["D_Name"].ToString();
                D_Rate_Per_Hr = sdr["D_Rate_Per_Hr"].ToString();
                D_Password = sdr["D_Password"].ToString();
                D_Daily_Rate = sdr["D_Daily_Rate"].ToString();


                }
                textBox23.Text = D_Name;
                textBox22.Text = D_Rate_Per_Hr;
                textBox21.Text = D_Daily_Rate;
                textBox20.Text = D_Password;


                m_con.Close();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = "Update Vehicle set V_Type_Id='" + textBox12.Text + "' where V_Id='"+textBox11.Text+"'";
                Console.WriteLine(sql);

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated vehicle");


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

            textBox11.Clear();
            textBox12.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = "Update VehicleType set V_Type_Name='" + textBox13.Text + "',V_Rate='"+textBox2.Text+"',V_Weekly_Rate='"+textBox1.Text+"' where V_Type_Id='" + textBox14.Text + "'";
                Console.WriteLine(sql);

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated vehicle");


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

            textBox14.Clear();
            textBox13.Clear();
            textBox2.Clear();
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                
                string sql = "Update Driver set D_Rate_Per_Hr='" + textBox22.Text + "',D_Password='" + textBox20.Text + "',D_Daily_Rate='" + textBox21.Text + "' where D_Name='" + textBox23.Text + "'";
                Console.WriteLine(sql);

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated vehicle");


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

            textBox14.Clear();
            textBox13.Clear();
            textBox2.Clear();
            textBox1.Clear();
        }

        private void button17_Click(object sender, EventArgs e)
        {

            m_con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = m_con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Package where P_Id='" + textBox29.Text + "'";


            SqlDataReader sdr = cmd.ExecuteReader();

            string P_Id = "";
            string P_Name = "";
            string Max_Km = "";
            string Max_Hr = "";
            string Extra_Km_Rate = "";
            string Extra_Hr_Rate = "";
            string Cost = "";
            string Vehicle_Night_Park_Rate_Per_Night = "";
            string Driver_Overnight_Rate_Per_Night = "";
            string V_Type_Id = "";


            while (sdr.Read())
            {


                P_Id = sdr["P_Id"].ToString();
                P_Name = sdr["P_Name"].ToString();
                Max_Km = sdr["Max_Km"].ToString();
                Max_Hr = sdr["Max_Hr"].ToString();
                Extra_Km_Rate = sdr["Extra_Km_Rate"].ToString();
                Extra_Hr_Rate = sdr["Extra_Hr_Rate"].ToString();
                Cost = sdr["Cost"].ToString();
                Vehicle_Night_Park_Rate_Per_Night = sdr["Vehicle_Night_Park_Rate_Per_Night"].ToString();
                Driver_Overnight_Rate_Per_Night = sdr["Driver_Overnight_Rate_Per_Night"].ToString();
                V_Type_Id = sdr["V_Type_Id"].ToString();

            }
            textBox29.Text = P_Id;
            textBox28.Text = P_Name;
            textBox27.Text = Max_Km;
            textBox26.Text = Max_Hr;
            textBox25.Text = Extra_Km_Rate;
            textBox19.Text = Extra_Hr_Rate;
            textBox18.Text = Cost;
            textBox17.Text = Vehicle_Night_Park_Rate_Per_Night;
            textBox16.Text = Driver_Overnight_Rate_Per_Night;
            textBox15.Text = V_Type_Id;

            m_con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = "Update Package set P_Name='" + textBox28.Text + "',Max_Km='" + textBox27.Text + "',Max_Hr='" + textBox26.Text + "',Extra_Km_Rate='" + textBox25.Text + "', Extra_Hr_Rate='" + textBox19.Text + "', Cost='" + textBox18.Text + "', Vehicle_Night_Park_Rate_Per_Night='" + textBox17.Text + "', Driver_Overnight_Rate_Per_Night='" + textBox16.Text + "', V_Type_Id='" + textBox15.Text + "' where P_Id='" + textBox29.Text + "'";
                Console.WriteLine(sql);

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully updated vehicle");


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

            textBox14.Clear();
            textBox13.Clear();
            textBox2.Clear();
            textBox1.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                string sql = "DELETE from Package where P_Id='" + textBox29.Text + "'";

                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                MessageBox.Show("Successfully deleted vehicle");


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

            textBox23.Clear();
            textBox22.Clear();
            textBox21.Clear();
            textBox20.Clear();
        }
    }
    }
        



