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
    public partial class Form_sign_in : Form
    {
        public static string CUSTOMER_ID = "";
        SqlConnection m_con = new DatabaseConnection().getConnection();
        public Form_sign_in()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label_username_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button_sign_in_Click(object sender, EventArgs e)
        {
           

            try
            {
                
                string sql = "select * from Customer where C_Name ='" + textBox1.Text + "' ";
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                SqlDataReader dreader = cmd.ExecuteReader();

                if (dreader.Read())
                {
                    if (dreader[5].ToString().Equals(textBox2.Text))
                    {
                        Form_customer fc = new Form_customer();
                       CUSTOMER_ID = dreader[0].ToString();
                        fc.Show();
                        this.Hide();
                    }

                }

                dreader.Close();


            }

            catch (Exception ex)
            {

                MessageBox.Show("Error");
            }
            finally
            {
                m_con.Close();
            }


            try
            {
                string sql2 = "select * from Driver where D_Name ='" + textBox1.Text + "' ";
                SqlCommand cmd2 = new SqlCommand(sql2, m_con);
                m_con.Open();
                SqlDataReader dreader2 = cmd2.ExecuteReader();

                if (dreader2.Read())
                {
                    if (dreader2[3].ToString().Equals(textBox2.Text))
                    {
                        Form_employee fe = new Form_employee();
                        CUSTOMER_ID = dreader2[0].ToString();
                        fe.Show();
                        this.Hide();
                    }
                   

                }

              
                dreader2.Close();
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

        private void button_sign_up_Click(object sender, EventArgs e)
        {
            Form_sign_up fsu = new Form_sign_up();
            fsu.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
