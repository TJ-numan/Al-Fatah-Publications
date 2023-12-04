using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Marketing
{
  public  class li_DonLetterPaymentProvider:DataAccessObject
    {
      public int InsertLi_DonLetterPayment(Li_DonLetterPayment liDonletterPayment)
      {
          using (SqlConnection connection = new SqlConnection(this.ConnectionString))
          {
              SqlCommand cmd = new SqlCommand("SMPM_li_Insert_Li_DonLetterPayment", connection);
              cmd.CommandType = CommandType.StoredProcedure;

              cmd.Parameters.Add("@PSId", SqlDbType.Int).Value = liDonletterPayment.PSId;
              cmd.Parameters.Add("@LetterNo", SqlDbType.VarChar).Value = liDonletterPayment.LetterNo;
              cmd.Parameters.Add("@PaymentMethod", SqlDbType.VarChar).Value = liDonletterPayment.PaymentMethod;
              cmd.Parameters.Add("@ChallanValue", SqlDbType.VarChar).Value = liDonletterPayment.ChallanValue;
              cmd.Parameters.Add("@PaymentDate", SqlDbType.VarChar).Value = liDonletterPayment.PaymentDate;
              cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = liDonletterPayment.CreatedBy;
              cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = liDonletterPayment.CreatedDate;
              connection.Open();

             int result= cmd.ExecuteNonQuery();
              return result;
          }
      }
    }
}
