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
    }
}
