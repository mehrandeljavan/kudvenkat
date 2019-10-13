using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNet_kudvenkat
{
    public partial class _062_WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
                lblName.Text = Session["Name"].ToString();
            else
                lblName.Text = "null";

            if (Session["Email"] != null)
                lblEmail.Text = Session["Email"].ToString();
            else
                lblEmail.Text = "null";
        }
    }
}