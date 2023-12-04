using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;
using DAL;


  public  class TaskDetailProvider : DataAccessObject
    {
        public TaskDetailProvider()
        {

        }

        public string InsertTaskDetail(string workPlanID, string employeeID, DateTime updatedDate, string selectedTaskStatus)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SMPM_li_InsertEmployeTaskStatus", connection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@workPlanID", SqlDbType.VarChar).Value = workPlanID;
                cmd.Parameters.Add("@employeeID", SqlDbType.VarChar).Value = employeeID;

                cmd.Parameters.Add("@taskStatus", SqlDbType.VarChar).Value = selectedTaskStatus;
                cmd.Parameters.Add("@updatedDate", SqlDbType.DateTime).Value = updatedDate;
                connection.Open();

                cmd.ExecuteNonQuery();

                return null;
            }
        }
      




      public string SearchEmployeeInTaskforStartingDate(string employeeID)
{
    string result =null;

    using (SqlConnection connection = new SqlConnection(this.ConnectionString))
    {
        SqlCommand cmd = new SqlCommand("SMPM_li_SearchEmployeeForTask", connection); 
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar).Value = employeeID;

        connection.Open();

        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                int taskAmount = reader.GetInt32(reader.GetOrdinal("TaskAmount"));

             
                result = taskAmount.ToString();
            }
        }
    }

    return result;
}


}

