using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Donations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["person"] != null)
        {
            int pk = (int)Session["Person"];
            GetDonation gd = new GetDonation();
            DataTable table = gd.GetDonations(pk);

            foreach (DataRow row in table.Rows)
            {
                lblHello.Text = "Welcome" + row["PersonFirstName"].ToString() + row["PersonLastName"].ToString();
            }
            grdDonations.DataSource = table;
            grdDonations.DataBind();

        }
        else
        {
            //Response.Redirect("Login.aspx");
        }

    }
    protected void btnDonateMore_Click(object sender, EventArgs e)
    {
        Response.Redirect("MakeDonation.aspx");
    }
}