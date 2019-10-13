using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace jQuery_kudvenkat
{
    /// <summary>
    /// Summary description for _106_Employee2Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class _106_Employee2Service : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetEmployees()
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Employee2> employees = new List<Employee2>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("106_spGetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee2 employee = new Employee2();
                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.LastName = rdr["LastName"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.JobTitle = rdr["JobTitle"].ToString();
                    employee.WebSite = rdr["WebSite"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.HireDate = Convert.ToDateTime(rdr["HireDate"]);
                    employees.Add(employee);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(employees));
        }
    }
}
