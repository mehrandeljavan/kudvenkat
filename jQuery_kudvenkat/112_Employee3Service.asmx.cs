﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace jQuery_kudvenkat
{
    /// <summary>
    /// Summary description for _112_Employee3Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class _112_Employee3Service : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetEmployees(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
        {
            int displayLength = iDisplayLength;
            int displayStart = iDisplayStart;
            int sortCol = iSortCol_0;
            string sortDir = sSortDir_0;
            string search = sSearch;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Employee3> listEmployees = new List<Employee3>();
            int filteredCount = 0;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("109_spGetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramDisplayLength = new SqlParameter()
                {
                    ParameterName = "@DisplayLength",
                    Value = displayLength
                };
                cmd.Parameters.Add(paramDisplayLength);

                SqlParameter paramDisplayStart = new SqlParameter()
                {
                    ParameterName = "@DisplayStart",
                    Value = displayStart
                };
                cmd.Parameters.Add(paramDisplayStart);

                SqlParameter paramSortCol = new SqlParameter()
                {
                    ParameterName = "@SortCol",
                    Value = sortCol
                };
                cmd.Parameters.Add(paramSortCol);

                SqlParameter paramSortDir = new SqlParameter()
                {
                    ParameterName = "@SortDir",
                    Value = sortDir
                };
                cmd.Parameters.Add(paramSortDir);

                SqlParameter paramSearchString = new SqlParameter()
                {
                    ParameterName = "@Search",
                    Value = string.IsNullOrEmpty(search) ? null : search
                };
                cmd.Parameters.Add(paramSearchString);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee3 employee = new Employee3();
                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    filteredCount = Convert.ToInt32(rdr["TotalCount"]);
                    employee.FirstName = rdr["FirstName"].ToString();
                    employee.LastName = rdr["LastName"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.JobTitle = rdr["JobTitle"].ToString();
                    listEmployees.Add(employee);
                }
            }

            var result = new
            {
                iTotalRecords = GetEmployeeTotalCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = listEmployees
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetEmployeeTotalCount()
        {
            int totalEmployeeCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new
                    SqlCommand("select count(*) from tblEmployees3", con);
                con.Open();
                totalEmployeeCount = (int)cmd.ExecuteScalar();
            }
            return totalEmployeeCount;
        }
    }
}
