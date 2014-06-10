using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        People p = new People();
        p.firstName = txtFirstName.Text;
        p.lastName = txtLastName.Text;
        p.email = txtEmail.Text;
        p.streetAddress = txtStreet.Text;
        p.city = txtCity.Text;
        p.state = txtState.Text;
        p.zip = txtZip.Text;
        p.phoneNumber = txtPhone.Text;
        p.PlainPassword = txtPassword.Text;

        ManagePeople mp = new ManagePeople();
        try
        {
            mp.WritePerson(p);
            lblError.Text = "You are now registered. Proceed to login";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }








    }
}