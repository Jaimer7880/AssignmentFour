using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MakeDonation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDonateSubmit_Click(object sender, EventArgs e)
    {
        int pk = (int)Session["person"];
        People p = new People();
        p.personKey = pk;
        p.Donation = txtMakeDonation.Text;
        ManagePeople mp = new ManagePeople();

        try
        {
            mp.MakeDonation(p);
            Response.Redirect("Donations.aspx");

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}