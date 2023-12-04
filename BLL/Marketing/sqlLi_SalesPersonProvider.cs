using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace BLL.Marketing
{
    class sqlLi_SalesPersonProvider
    {
        internal static System.Data.DataSet Get_AllSalesTargetInfoByTerCodeMonthYear(string terCode, int monthNo, int year, int CompanyID)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConnectionString))

            {
                SqlCommand command = new SqlCommand("SMPM_li_SalesTargetInfoByTerCodeMonthYear", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@TerCode", SqlDbType.VarChar).Value = TerCode;
                command.Parameters.Add("@CompanyId", SqlDbType.VarChar).Value = CompanyId;
                command.Parameters.Add("@MonthNo", SqlDbType.VarChar).Value = MonthNo;
                command.Parameters.Add("@Year", SqlDbType.VarChar).Value = Year;
                connection.Open();
                SqlDataAdapter myadapter = new SqlDataAdapter(command);
                myadapter.Fill(ds);
                myadapter.Dispose();
                connection.Close();

                return ds;
            }
        }

        public static object MonthNo { get; set; }

        public static object TerCode { get; set; }

        public static object CompanyId { get; set; }

        public static object Year { get; set; }


        public static string ConnectionString { get; set; }

    }
}
