using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System .Data;

/// <summary>
/// Summary description for GetDonation
/// </summary>
public class GetDonation
{
    SqlConnection connect;
	public GetDonation()
	{
		connect = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityAssistconnectionString"].ConnectionString);
	}
    public DataTable GetDonations(int personKey)
    {
        string sql = "Select PersonFirstName, PersonLastName, DonationAmount From Donation inner Join Person on person.PersonKey=Donation.Personkey where Donation.personkey=@personKey";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@personKey",personKey);

        SqlDataReader reader = null;
        DataTable table = new DataTable();

        connect.Open();
        reader = cmd.ExecuteReader();
        table.Load(reader);
        reader.Dispose();
        connect.Close();

        return table;
    }
}