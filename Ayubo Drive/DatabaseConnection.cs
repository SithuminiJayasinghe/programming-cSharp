using System;
using System.Data.SqlClient;
public class DatabaseConnection
{
    static string constring = "Data Source=DESKTOP-MHS4TMT\\SQLEXPRESS;Initial Catalog=Ayubo_drive;Integrated Security=True";
    SqlConnection m_con = new SqlConnection(constring);

    public DatabaseConnection()
	{

	}

    public SqlConnection getConnection()
    {
        return m_con;
    }
}
