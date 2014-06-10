using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Login login = new Login();
        int personKey = login.ValidateLogin(txtUserName.Text, txtUserPassword.Text);
        if (personKey != 0)
        {
            lblError.Text = "welcome";
            Session["person"] = personKey;
            Response.Redirect("Donations.aspx");
        }
        else
        {
            lblError.Text = "Invalid Login";
        }
    }
}