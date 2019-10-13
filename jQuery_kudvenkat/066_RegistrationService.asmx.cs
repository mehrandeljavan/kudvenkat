using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace jQuery_kudvenkat
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    [System.Web.Script.Services.ScriptService]
    public class _066_RegistrationService : System.Web.Services.WebService
    {
        public bool UserNameExists(string userName)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("065_spUserNameExists", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@UserName",
                    Value = userName
                });

                con.Open();
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }

        [WebMethod]
        public void GetAvailableUserName(string userName)
        {
            Registration regsitration = new Registration();
            regsitration.UserNameInUse = false;

            while (UserNameExists(userName))
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 100);
                userName = userName + randomNumber.ToString();
                regsitration.UserNameInUse = true;
            }

            regsitration.UserName = userName;
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(regsitration));
        }
    }
}
