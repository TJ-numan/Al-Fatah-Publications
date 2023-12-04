using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Marketing
{
   public  class SqlLi_PaymentProvider: DataAccessObject
    {
       public int InsertLi_Payments(li_Payment li_Payment)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_Payment", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@PaySl", SqlDbType.Int).Direction = ParameterDirection.Output;
               cmd.Parameters.Add("@PayDate", SqlDbType.DateTime).Value = li_Payment.PayDate;
               cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Payment.LibraryID;
               cmd.Parameters.Add("@PayforID", SqlDbType.Int).Value = li_Payment.PayforID;
               cmd.Parameters.Add("@BankID", SqlDbType.VarChar).Value = li_Payment.BankID;
               cmd.Parameters.Add("@AcNo", SqlDbType.VarChar).Value = li_Payment.AcNo;
               cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = li_Payment.TransactionID;
               cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = li_Payment.Branch;
               cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_Payment.Amount;
               cmd.Parameters.Add("@CreateBy", SqlDbType.Int).Value = li_Payment.CreateBy;
               cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Payment.CreatedDate;
               cmd.Parameters.Add("@Statud_d", SqlDbType.Char).Value = li_Payment.Statud_d;
               cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_Payment.CauseOfDel;
               cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_Payment.DelBy;
               connection.Open();
               int affectedRows= cmd.ExecuteNonQuery();
               return affectedRows;
              

               //return cmd.Parameters["@PaySl"].Value.ToString();
           }
       }
       public int InsertLi_CashPayments(li_Payment li_Payment)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("web_SMPM_InsertLi_CashPayment", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@PaySl", SqlDbType.Int).Direction = ParameterDirection.Output;
               cmd.Parameters.Add("@PayDate", SqlDbType.DateTime).Value = li_Payment.PayDate;
               cmd.Parameters.Add("@LibraryID", SqlDbType.VarChar).Value = li_Payment.LibraryID;
               cmd.Parameters.Add("@PayforID", SqlDbType.Int).Value = li_Payment.PayforID;
               cmd.Parameters.Add("@BankID", SqlDbType.VarChar).Value = li_Payment.BankID;
               cmd.Parameters.Add("@AcNo", SqlDbType.VarChar).Value = li_Payment.AcNo;
               cmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = li_Payment.TransactionID;
               cmd.Parameters.Add("@Branch", SqlDbType.VarChar).Value = li_Payment.Branch;
               cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_Payment.Amount;
               cmd.Parameters.Add("@CreateBy", SqlDbType.Int).Value = li_Payment.CreateBy;
               cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Payment.CreatedDate;
               cmd.Parameters.Add("@Statud_d", SqlDbType.Char).Value = li_Payment.Statud_d;
               cmd.Parameters.Add("@CauseOfDel", SqlDbType.VarChar).Value = li_Payment.CauseOfDel;
               cmd.Parameters.Add("@DelBy", SqlDbType.Int).Value = li_Payment.DelBy;
               connection.Open();
               int affectedRows = cmd.ExecuteNonQuery();
               return affectedRows;


               //return cmd.Parameters["@PaySl"].Value.ToString();
           }
       }

      
    }
}
