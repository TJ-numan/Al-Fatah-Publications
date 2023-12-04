using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Xml.Linq;


public class SqlLi_ManagementSummaryManager:DataAccessObject
{
    public SqlLi_ManagementSummaryManager()
    {
    }
    public DataSet GetLi_ManagementDatewiseSummaryDetails(String Fromdate, String Todate)
    {
        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("web_SMPM_rpt_DailySummaryReportForManagementForGrid", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@fromDate", SqlDbType.VarChar).Value = Fromdate;
            command.Parameters.Add("@toDate", SqlDbType.VarChar).Value = Todate;
            connection.Open();
            SqlDataAdapter myadapter = new SqlDataAdapter(command);
            myadapter.Fill(ds);
            myadapter.Dispose();
            connection.Close();

            return ds;
        }
    }
}

