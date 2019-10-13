using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace jQuery_kudvenkat
{
    public partial class _055_GetHelpText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divResult.InnerText = GetHelpTextByKey(Request["HelpTextKey"]);
        }

        private string GetHelpTextByKey(string key)
        {
            string helpText = string.Empty;

            //string cs = @"Data Source=MEHRAN-PC\MSSQLSERVER2014; User Id=sa; Password=123; Initial Catalog = OnlineMal;";

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("054_spGetHelpTextByKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@HelpTextKey", key);
                cmd.Parameters.Add(parameter);
                con.Open();
                helpText = cmd.ExecuteScalar().ToString();
            }

            return helpText;
        }
    }
}