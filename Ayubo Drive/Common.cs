using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ayubo_Drive
{
    public class Driver
    {
        //store driver details temporarily to use in line 47...
        public string D_ID;
        public string D_NAME;
        public int D_Rate_Per_Hr;
        public int D_Daily_Rate;
    }

    public class Vehicle
    {//store vehicle details to use in 87...
        public string V_Type_Id;
        public string V_Type_Name;
        public int V_Rate;
        public int V_Weekly_Rate;
    }
    public class Customer
    {//store vehicle details to use in 87...
        public string C_Id;
        public string C_Name;
        public string C_Address;
        public string C_Email;
        public string C_Contact_No;
        public string C_Password;
    }
    public class Package
    {
        public string P_Id;
        public string P_Name;
        public string Max_Km;
        public string Max_Hr;
        public string Extra_Km_Rate;
        public string Extra_Hr_Rate;
        public string Cost;
        public string Vehicle_Night_Park_Rate_Per_Night;
        public string Driver_Overnight_Rate_Per_Night;
    }

    public class Hire
    {
        public string Hire_Id;
        public string D_Id;
        public string C_Id;
        public string V_Id;
        public string V_Type_Id;
        public string P_Id;
        public string Base_Cost;
    
    }

    public class Job
    {
        public string J_Id;
        public string C_Id;
        public string C_Name;
        public string Hire_Or_Rent;
        public string Cost;
        public string V_Type;
        public string D_Id;
        public string D_Name;
        public string Duration;

    }



    class Common
    {
        // Get connection for the database
        SqlConnection m_con = new DatabaseConnection().getConnection();

        public Driver GetDriverRowById(String D_ID)
        {

            try
            {

                string sql = "select * from Driver where D_ID ='" + D_ID + "' ";
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                SqlDataReader dreader = cmd.ExecuteReader();

                // We are going to store driver data in this variable (Driver)
                Driver d = new Driver();

                if (dreader.Read())
                {
                   
                    d.D_NAME = dreader[1].ToString();
                    d.D_ID = dreader[0].ToString();
                    d.D_Rate_Per_Hr = Int32.Parse(dreader[2].ToString());
                    d.D_Daily_Rate = Int32.Parse(dreader[4].ToString());

                    dreader.Close();
                    return d;

                } else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                m_con.Close();
            }
        }

        public Job GetLastJob()
        {
            try
            {

                string sql = "SELECT TOP 1 * FROM Job ORDER BY J_Id DESC";
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                SqlDataReader dreader = cmd.ExecuteReader();

                // We are going to store driver data in this variable (Driver)
                Job j = new Job();

                if (dreader.Read())
                {


                    j.J_Id = dreader[0].ToString();
                    j.C_Id = dreader[1].ToString();
                    j.C_Name = dreader[2].ToString();
                    j.Hire_Or_Rent = dreader[3].ToString();
                    j.Cost = dreader[4].ToString();
                    j.V_Type = dreader[5].ToString();
                    j.D_Id = dreader[6].ToString();
                    j.D_Name = dreader[7].ToString();
                    j.Duration = dreader[8].ToString();
       
                    dreader.Close();
                    return j;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                m_con.Close();
            }
        }

        public Customer GetCustomerById(String C_ID)
        {

            try
            {

                string sql = "select * from Customer where C_Id ='" + C_ID + "' ";
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                SqlDataReader dreader = cmd.ExecuteReader();

                // We are going to store driver data in this variable (Driver)
                Customer c = new Customer();

                if (dreader.Read())
                {



                    c.C_Id = dreader[0].ToString();
                    c.C_Name = dreader[1].ToString();
                    c.C_Address = dreader[2].ToString();
                    c.C_Email = dreader[3].ToString();
                    c.C_Contact_No = dreader[4].ToString();
                    c.C_Password = dreader[5].ToString();


                    dreader.Close();
                    return c;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                m_con.Close();
            }
        }


        public Vehicle GetVehicleTypeById(String V_ID)
        {

            try
            {

                string sql = "select * from VehicleType where V_Type_Id ='" + V_ID + "' ";
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                SqlDataReader dreader = cmd.ExecuteReader();

                // We are going to store vehicle data in this variable (Driver)
                Vehicle v = new Vehicle();

                if (dreader.Read())
                {

                    v.V_Type_Id = dreader[0].ToString();
                    v.V_Rate = Int32.Parse(dreader[2].ToString());
                    v.V_Weekly_Rate = Int32.Parse(dreader[3].ToString());
                    v.V_Type_Name = dreader[1].ToString();
                    dreader.Close();
                    return v;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                m_con.Close();
            }
        }
        public Package GetPackageById(String P_ID)
        {

            try
            {

                string sql = "select * from Package where P_Id ='" + P_ID + "' ";
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                SqlDataReader dreader = cmd.ExecuteReader();

                // We are going to store vehicle data in this variable (Driver)
                Package p = new Package();

                if (dreader.Read())
                {              
            
             
                    p.P_Id = dreader[0].ToString();
                    p.P_Name = dreader[1].ToString();
                    p.Max_Km = dreader[2].ToString();
                    p.Max_Hr = dreader[3].ToString();
                    p.Extra_Km_Rate = dreader[4].ToString();
                    p.Extra_Hr_Rate = dreader[5].ToString();
                    p.Cost = dreader[6].ToString();
                    p.Vehicle_Night_Park_Rate_Per_Night = dreader[7].ToString();
                    p.Driver_Overnight_Rate_Per_Night = dreader[8].ToString();

                    dreader.Close();
                    return p;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                m_con.Close();
            }
        }


        public Hire GetHireById(String Hire_ID)
        {

            try
            {

                string sql = "select * from Hire where Hire_Id ='" + Hire_ID + "' ";
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                SqlDataReader dreader = cmd.ExecuteReader();

                // We are going to store vehicle data in this variable (Driver)
                Hire h = new Hire();

                if (dreader.Read())
                {
                    h.Hire_Id = dreader[0].ToString();
                    h.D_Id = dreader[1].ToString();
                    h.C_Id = dreader[2].ToString();
                    h.V_Id = dreader[3].ToString();
                    h.V_Type_Id = dreader[4].ToString();
                    h.P_Id = dreader[5].ToString();
                    h.Base_Cost = dreader[6].ToString();
                 

                    dreader.Close();
                    return h;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                m_con.Close();
            }
        }

        public Job GetJobById(String J_Id)
        {

            try
            {

                string sql = "select * from Job where J_Id ='" + J_Id + "' ";
                SqlCommand cmd = new SqlCommand(sql, m_con);
                m_con.Open();
                SqlDataReader dreader = cmd.ExecuteReader();

                // We are going to store vehicle data in this variable (Driver)
                Job j = new Job();

                if (dreader.Read())
                {
                    j.J_Id = dreader[0].ToString();
                    j.C_Id = dreader[1].ToString();
                    j.C_Name = dreader[2].ToString();
                    j.Hire_Or_Rent = dreader[3].ToString();
                    j.Cost = dreader[4].ToString();
                    j.V_Type = dreader[5].ToString();
                    j.D_Id = dreader[6].ToString();
                    j.D_Name = dreader[7].ToString();
                    j.Duration = dreader[8].ToString();
                    
                    dreader.Close();
                    return j;

                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                m_con.Close();
            }
        }



    }
}
