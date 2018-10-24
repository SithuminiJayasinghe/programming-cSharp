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
    public partial class Form_sign_up : Form
    {
        public Color EmptyTbxBackColor { get; private set; }

        public Form_sign_up()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_sign_up_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //step 1 - create the sql connection
            SqlConnection con = new SqlConnection();

            //step 2 - rightclick on database - properties - connection string (address of the database the path)
            con.ConnectionString = "Data Source=DESKTOP-MHS4TMT\\SQLEXPRESS;Initial Catalog=Ayubo_drive;Integrated Security=True";

            //step 3 - Open the sql connection
            con.Open();

            //step 4 - Define the sql command
            SqlCommand cmd = new SqlCommand();

            //step 5 - set the sql connection object to the sql command
            cmd.Connection = con;

            //step 6 - Define the sql query type in the sql command
            cmd.CommandType = CommandType.Text;

            //step 7 - set the sql query to the sql command
            cmd.CommandText = "Insert Into customer(C_Name,C_Address,C_Email,C_Contact_No,C_Password)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Focus();
                textBox1.BackColor = System.Drawing.Color.LightPink;



            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Focus();
                textBox2.BackColor = System.Drawing.Color.LightPink;



            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Focus();
                textBox3.BackColor = System.Drawing.Color.LightPink;



            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Focus();
                textBox4.BackColor = System.Drawing.Color.LightPink;



            }

            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {

                textBox5.Focus();
                textBox5.BackColor = System.Drawing.Color.LightPink;


            } else
            {
                //step 10 - Display a successfull message 
              
                MessageBox.Show("Successfully inserted values");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();




                Form_customer fc = new Form_customer();
                fc.Show();

                this.Hide();






            }
            //step 8 - execute the sql command
            cmd.ExecuteReader();
            
           

            //step 9 - close the sql connection
            con.Close();
           


        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
