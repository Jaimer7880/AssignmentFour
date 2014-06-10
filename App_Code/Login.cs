using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for Login
/// </summary>
public class Login
{
    SqlConnection connect;
	public Login()
	{
        connect = new SqlConnection
        (ConfigurationManager.ConnectionStrings["CommunityAssistConnectionString"].ConnectionString);
		
	}

    public int ValidateLogin(string user, string pass)
    {
        int result = 0;
        PasswordHash ph = new PasswordHash();

        string sql = "Select PersonKey, Personpasskey, PersonUserPassword " +
            "From Person Where PersonUsername= @User";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.Add("@User", user);

        SqlDataReader reader;
        int passCode = 0;
        byte[] originalPassword = null;
        int personKey = 0;

        connect.Open();
        reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                passCode = (int)reader["PersonPassKey"];
                originalPassword = (byte[])reader["PersonUserPassword"];
                personKey = (int)reader["PersonKey"];
            }

            byte[] newhash = ph.HashIt(pass, passCode.ToString());

            if (newhash.SequenceEqual(originalPassword))
            {
                result = personKey;
            }


        }
        connect.Close();
        return result;
    }
}