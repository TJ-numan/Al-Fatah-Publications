using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Marketing
{
   public class SqlLi_DonPaymentReturnProvider :DataAccessObject
    {
       public int InsertLi_DonPaymentReturn(li_DonPaymentReturn li_donPaymentReturn)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_li_InsertDonPaymentReturn", connection);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@Ret_ID", SqlDbType.Int).Direction = ParameterDirection.Output;
               cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = li_donPaymentReturn.DetId;
               cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = li_donPaymentReturn.DoDesId;
               cmd.Parameters.Add("@ReturnAmt", SqlDbType.Decimal).Value = li_donPaymentReturn.ReturnAmt;
               cmd.Parameters.Add("@CauseOfReturn", SqlDbType.VarChar).Value = li_donPaymentReturn.CauseOfReturn;
               connection.Open();

               int result = cmd.ExecuteNonQuery();
               return 1;
           }
       }

       public DataSet GetDonationPaymentReturn(int DetId, int DoDesId)
       {
           DataSet ds = new DataSet();
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_li_Get_DonationPaymentReturn", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@DetId", SqlDbType.Int).Value = DetId;
               cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = DoDesId;
               connection.Open();
               SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
               myadapter.Fill(ds);
               myadapter.Dispose();
               connection.Close();
               return ds;
           }

       }
    }
}
