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
                string sql = "INSERT Driver VALUES ('" + textBox23.Text + "'," + textBox22.Text + "," + textBox20.Text + "," + textBox21.Text + ") ";

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
                string sql = "INSERT Packages VALUES ("+textBox29.Text+".'" + textBox28.Text + "'," + textBox27.Text + "," + textBox26.Text + "," + textBox25.Text + "," + textBox19.Text + "," + textBox18.Text + "," + textBox17.Text + "," + textBox16.Text + "," + textBox15.Text + ") ";

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
    }
}
