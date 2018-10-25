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
        public static string lastJobId = null;
       
        SqlConnection m_con = new DatabaseConnection().getConnection();
        public static int WEEKLY_RENT = 10000;
        public static int V_Monthly_Rent = 40000;
        public int BaseCost=0;
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

                string packageId = comboBox9.Text;
                PrintConsole("on Changed combo1 packageId ", packageId);


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

                     //lets find the no of months
                int numberofMonths = days / 30;
                PrintConsole("numberofMonths", numberofMonths.ToString());

                // lets find the no of weeks
             
               
                    int numberOfWeeks = (days%30) / 7;
                    PrintConsole("numberOfWeeks ", numberOfWeeks.ToString());
               
                // lets find no of remaining days
    
               
                    int remainingDays = (days%30) % 7;
                    PrintConsole("remainingDays ", remainingDays.ToString());



                int totalValue = V_Monthly_Rent * numberofMonths + v.V_Weekly_Rate * numberOfWeeks + v.V_Rate * remainingDays;
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

        private double doCalculation_Hire()
        {
            if (comboBox8.SelectedValue != null && comboBox9.SelectedValue != null)
            {
                string vTypeName = comboBox8.Text;
                string vTypeID = comboBox8.SelectedValue.ToString();
                PrintConsole("on Changed combo1 vTypeName ", vTypeName);
                PrintConsole("on Changed combo1 vTypeID ", vTypeID);

                string packageName = comboBox9.Text;
                string packageId = comboBox9.SelectedValue.ToString();
                PrintConsole("on Changed combo1 driverName ", packageName);
                PrintConsole("on Changed combo1 driverId ", packageId);


              

                string startKm = textBox4.Text;
                PrintConsole("Start km ", startKm.ToString());

                string endKm = textBox5.Text;
                PrintConsole("End km ", endKm.ToString());

                int sk = Convert.ToInt32(startKm);
                int ek = Convert.ToInt32(endKm);

                int distance = ek - sk;
                PrintConsole("Distance ", distance.ToString());

                p=c.GetPackageById(packageId);
                PrintConsole("MaxKm ", p.Max_Km.ToString());
                int Max_Km = Convert.ToInt32(p.Max_Km);
                int Extra_Km_Rate = Convert.ToInt32(p.Extra_Km_Rate);
                int packagecost = Convert.ToInt32(p.Cost);


                if (Max_Km < distance)
                {
                    extrakmcharge = (distance - Max_Km) * Extra_Km_Rate;
                    PrintConsole("extrakmcharge ", extrakmcharge.ToString());
                    if (radioButton1.Checked == true)
                    {
                        label44.Text = extrakmcharge.ToString();
                        label47.Text = "...".ToString();


                    }
                    if (radioButton2.Checked == true)
                    {
                        label47.Text = extrakmcharge.ToString();
                        label44.Text = "...".ToString();

                    }
                }
                else
                {
                    label44.Text = "...".ToString();
                    label47.Text = "...".ToString();

                }




                
                DateTime starttime = dateTimePicker5.Value;
                DateTime endtime = dateTimePicker6.Value;
                PrintConsole("starttime ", starttime.ToString());
                PrintConsole("endtime ", endtime.ToString());

                TimeSpan timedifference = endtime - starttime;
                PrintConsole("timedifference ", timedifference.ToString());

                double tdf = timedifference.TotalHours;
                PrintConsole("tdf ", tdf.ToString());

            
                p = c.GetPackageById(packageId);

                int Extra_Hr_Rate = Convert.ToInt32(p.Extra_Hr_Rate);
                PrintConsole("Extra hr rate ", p.Extra_Hr_Rate.ToString());
                int Max_Hr = Convert.ToInt32(p.Max_Hr);

                if (tdf > Max_Hr)
                {
                    waitingcharge = (tdf - Max_Hr) * Extra_Hr_Rate;
                    PrintConsole("waitingcharge ", waitingcharge.ToString());


                    if (radioButton1.Checked == true)
                    {
                        label43.Text = Math.Round(waitingcharge,2).ToString();

                    }
                    if (radioButton2.Checked == true)
                    {
                        label43.Text = "...".ToString();

                    }

                }

                



                DateTime d3 = dateTimePicker3.Value;
                DateTime d4 = dateTimePicker4.Value;
                TimeSpan t = d4 - d3;
                double dDays = t.TotalDays;
                days = Convert.ToInt32(dDays);
                PrintConsole("Number of days ", days.ToString());
                
                v = c.GetVehicleTypeById(vTypeID);
                p = c.GetPackageById(packageId);
                h = c.GetHireById(vTypeID);
                int vehicle_night_park_rate = Convert.ToInt32(p.Vehicle_Night_Park_Rate_Per_Night);
                int driver_overnight_rate = Convert.ToInt32(p.Driver_Overnight_Rate_Per_Night);
                if (days>=2)
                {
                    overnightstaycharge = (days * vehicle_night_park_rate) + (days * driver_overnight_rate);
                    PrintConsole("overnightstaycharge ", overnightstaycharge.ToString());

                    if(radioButton2.Checked==true)
                    {
                        label46.Text = overnightstaycharge.ToString();
                    }
                    if(radioButton1.Checked==true)
                    {
                        label46.Text = "...".ToString();
                    }
                }

               



                h = c.GetHireById(vTypeID);
                string sql_1 = "select * from Hire where V_Type_Id ='" + comboBox8.SelectedValue + "' ";
                SqlCommand cmd_1 = new SqlCommand(sql_1, m_con);
                m_con.Open();
                SqlDataReader dreader_1 = cmd_1.ExecuteReader();

                if (dreader_1.Read())
                {
                    PrintConsole("Sithumini", dreader_1[5].ToString());
                    PrintConsole("Sithumini_s", comboBox9.SelectedValue.ToString());

                    if (dreader_1[5].ToString().Equals(comboBox9.SelectedValue.ToString()))
                    {
                        PrintConsole("Base_Cost ", dreader_1[6].ToString());
                        BaseCost = Convert.ToInt32(dreader_1[6].ToString());


                        //hireBaseCost = Convert.ToInt32(dreader[6].ToString());
                        if (radioButton1.Checked == true)
                        {
                            lblbasehirecharge.Text = BaseCost.ToString();
                            label45.Text = "...".ToString();

                        }
                        if (radioButton2.Checked == true)
                        {
                            label45.Text = BaseCost.ToString();
                            lblbasehirecharge.Text = "...".ToString();

                        }

                        
                    }
                        dreader_1.Close();
                        m_con.Close();
                 
                }
             



                if (radioButton1.Checked == true)
                {
                    totalhirecost = BaseCost + waitingcharge + extrakmcharge;
                    PrintConsole("Day total", totalhirecost.ToString());
                    label27.Text = totalhirecost.ToString();
                    label50.Text = "...".ToString();
                    //int totalhirecost = Convert.ToInt32(totalhire);
                }

                if (radioButton2.Checked == true)
                {
                    totalhirecost = BaseCost + overnightstaycharge + extrakmcharge;
                    PrintConsole("long tour", totalhirecost.ToString());
                    label50.Text = totalhirecost.ToString();
                    label27.Text = "...".ToString();
                    //it totalhirecost = Convert.ToInt32(totalhire);
                }

                 return totalhirecost;

            }
            else
            { return 0;}
                    
               
                


        }
               



        


        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_driveDataSet1.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.ayubo_driveDataSet1.Job);
            // TODO: This line of code loads data into the 'ayubo_driveDataSet.Job' table. You can move, or remove it, as needed.
            this.jobTableAdapter.Fill(this.ayubo_driveDataSet.Job);
            // TODO: This line of code loads data into the 'ayubo_driveDataSet.Package' table. You can move, or remove it, as needed.
            this.packageTableAdapter.Fill(this.ayubo_driveDataSet.Package);
            // TODO: This line of code loads data into the 'ayubo_driveDataSet.Rent' table. You can move, or remove it, as needed.
            this.rentTableAdapter.Fill(this.ayubo_driveDataSet.Rent);
            // TODO: This line of code loads data into the 'ayubo_driveDataSet.Hire' table. You can move, or remove it, as needed.
            this.hireTableAdapter.Fill(this.ayubo_driveDataSet.Hire);
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
                if (radioButton_with_a_driver.Checked == true)
                {
                    Customer customer = c.GetCustomerById(Form_sign_in.USER_ID);
                    int total = doCalulation();
                    string sql = "INSERT INTO job VALUES(" + customer.C_Id + ",'" + customer.C_Name + "','Rent'," + total + ",'" + v.V_Type_Name + "'," + d.D_ID + ",'" + d.D_NAME + "','" + days + "');";
                    PrintConsole("withdriver customer Id", customer.C_Id.ToString());
                    PrintConsole("withdriver customer", customer.C_Name.ToString());
                    PrintConsole("withdriver total", total.ToString());
                    PrintConsole("withdriver driver", d.D_ID.ToString());
                    PrintConsole("withdriver driver", d.D_NAME.ToString());
                    PrintConsole("withdriver days", days.ToString());



                    
                    SqlCommand cmd = new SqlCommand(sql, m_con);
                    m_con.Open();
                    cmd.ExecuteReader();

                    MessageBox.Show("Successfully added new order");



                }
                if (radioButton_without_a_driver.Checked == true)
                {
                    Customer customer = c.GetCustomerById(Form_sign_in.USER_ID);
                    int total = doCalulation();
                    string sql = "INSERT INTO job (C_Id,C_Name,Hire_Or_Rent,Cost,V_Type,Duration) VALUES(" + customer.C_Id + ",'" + customer.C_Name + "','Rent'," + total + ",'" + v.V_Type_Name + "','" + days + "');";
                    PrintConsole("withoutdriver customer Id", customer.C_Id.ToString());
                    PrintConsole("withoutdriver customer", customer.C_Name.ToString());
                    PrintConsole("withoutdriver total", total.ToString());
                    PrintConsole("withoutdriver driver", v.V_Type_Name.ToString());
                    PrintConsole("withoutdriver days", days.ToString());


                    SqlCommand cmd = new SqlCommand(sql, m_con);
                    m_con.Open();
                    cmd.ExecuteReader();

                    MessageBox.Show("Successfully added new order");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Something went wrong. PLease check your inputs");
            }
            finally
            {
                m_con.Close();
                m_con.Close();
                Order_Details od = new Order_Details();
                od.Show();
                this.Hide();

            }



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            doCalulation();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();
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

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            doCalculation_Hire();





        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();
        }

        private void label42_Click(object sender, EventArgs e)
        {
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();
            
        }

        private void lblNoOfDays_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();

        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();
        }

        private void label43_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            doCalculation_Hire();
          

        }

        private void dateTimePicker3_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            doCalculation_Hire();
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {   
                string vTypeID = comboBox8.SelectedValue.ToString();
                PrintConsole("on Changed combo1 vTypeID ", vTypeID);

        
                String driverId = comboBox3.SelectedValue.ToString();
                PrintConsole("on Changed combo1 driverId ", driverId);

                d = c.GetDriverRowById(driverId);
                v = c.GetVehicleTypeById(vTypeID);

                Customer customer = c.GetCustomerById(Form_sign_in.USER_ID);
                double totalhire = doCalculation_Hire();
                Console.WriteLine("before query");
                if(customer == null)
                {
                    Console.WriteLine("customer not found");
                    MessageBox.Show("customer not found");

                    return;
                }
                if (v == null)
                {
                    Console.WriteLine("vehicle not found");
                    MessageBox.Show("vehicle not found");
                    return;
                }

                if (d == null)
                {
                    Console.WriteLine("driver not found");
                    MessageBox.Show("driver not found");
                    return;
                }
                string sql = "INSERT INTO job VALUES(" + customer.C_Id + ",'" + customer.C_Name + "','Hire'," + totalhirecost + ",'" + v.V_Type_Name + "'," + d.D_ID + ",'" + d.D_NAME + "','" + days + "');";

                Console.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                cmd.ExecuteReader();
                Job lastJob = c.GetLastJob();
                Console.WriteLine("----------------------------------id" + lastJob.J_Id);
                MessageBox.Show("Successfully added new order");
                lastJobId = lastJob.J_Id;
                Order_Details od = new Order_Details();
                od.Show();
                this.Hide();

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
        
        private void label27_Click(object sender, EventArgs e)
        {
            
        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            string J_Id = comboBox2.SelectedValue.ToString();

            j = c.GetJobById(J_Id);


        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.jobTableAdapter.FillBy2(this.ayubo_driveDataSet.Job);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy3ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.jobTableAdapter.FillBy3(this.ayubo_driveDataSet.Job);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy4ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.jobTableAdapter.FillBy4(this.ayubo_driveDataSet.Job);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy5ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.jobTableAdapter.FillBy5(this.ayubo_driveDataSet.Job);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy5ToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.jobTableAdapter.FillBy5(this.ayubo_driveDataSet.Job);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.jobTableAdapter.New(this.ayubo_driveDataSet.Job);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void reddaToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.jobTableAdapter.redda(this.ayubo_driveDataSet1.Job);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
