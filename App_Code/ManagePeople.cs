using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for ManagePeople
/// </summary>
public class ManagePeople
{
    SqlConnection connect;
    People p;

	public ManagePeople()
	{
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityAssistConnectionString"].ConnectionString);
	}
    /*   Cannot insert explicit value for identity column in table 'Person' when IDENTITY_INSERT is set to OFF.   */
    private SqlCommand WritePerson()
    {
        PasscodeGenerator pg = new PasscodeGenerator();
        PasswordHash ph = new PasswordHash();
        int passcode = pg.GetPasscode();

        string sqlPerson = "Insert into Person ( PersonLastName, PersonFirstName, PersonUsername,Personpasskey, PersonUserPassword) Values (@LastName, @FirstName, @passcode, @password, @hashedpass)";
        SqlCommand personCmd = new SqlCommand(sqlPerson, connect);
        personCmd.Parameters.AddWithValue("@LastName", p.lastName);
        personCmd.Parameters.AddWithValue("@FirstName", p.firstName);
        personCmd.Parameters.AddWithValue("@Email", p.email);
           personCmd.Parameters.AddWithValue("@Passcode", passcode.ToString());
           personCmd.Parameters.AddWithValue("@password", p.passWord.ToString());
           personCmd.Parameters.AddWithValue("@hashedPass", ph.HashIt(p.PlainPassword, passcode.ToString()));
         /*Cannot insert explicit value for identity column in table 'Person' when IDENTITY_INSERT is set to OFF. */
       
        return personCmd;
    }

    private SqlCommand WriteAddress()
    {
        string sqlAddress = "Insert into PersonAddress(Street, City,State,Zip,PersonKey) " +
           "Values(@Street, @City, @State, @Zip, ident_Current('Person'))";
        SqlCommand addressCmd = new SqlCommand(sqlAddress, connect);
        addressCmd.Parameters.AddWithValue("@Street", p.streetAddress);
        addressCmd.Parameters.AddWithValue("@State", p.state);
        addressCmd.Parameters.AddWithValue("@City", p.city);
        addressCmd.Parameters.AddWithValue("@Zip", p.zip);
        
        return addressCmd;
       /* Invalid object name 'PersonAddress'.*/
    }

    public SqlCommand MakeDonations()
    {
        string sqlMakeDonations = "Insert into Donation(DonationAmount, DonationDate, PersonKey) Values (@Donation, @Date,@Person)";
        SqlCommand makeDonationsCmd = new SqlCommand(sqlMakeDonations, connect);
        makeDonationsCmd.Parameters.AddWithValue("@Donation", p.Donation);
        makeDonationsCmd.Parameters.AddWithValue("@Date", DateTime.Now);
        makeDonationsCmd.Parameters.AddWithValue("@Person", p.personKey);

        return makeDonationsCmd;
    }
    public void MakeDonation(People p)
    {
        this.p = p;
        SqlTransaction tran = null;

        SqlCommand mCmd = MakeDonations();

        connect.Open();

        try
        {
            tran = connect.BeginTransaction();
            mCmd.Transaction = tran;
            mCmd.ExecuteNonQuery();

            tran.Commit();
        }
        catch (Exception ex)
        {
            tran.Rollback();
            throw ex;
        }
        finally
        {
            connect.Close();
        }
    }
    public void WritePerson(People p)
    {
        this.p = p;

        SqlTransaction tran = null;

        SqlCommand pCmd = WritePerson();
        SqlCommand aCmd = WriteAddress();
      


        connect.Open();
        try
        {
            tran = connect.BeginTransaction();
            pCmd.Transaction = tran;
            aCmd.Transaction = tran;
            pCmd.ExecuteNonQuery();
            aCmd.ExecuteNonQuery();
           
            tran.Commit();
        }
        catch (Exception ex)
        {
            tran.Rollback();
            throw ex;
        }
        finally
        {
            connect.Close();
        }

    }

}