using Common;
using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
   public class SqlLi_DonLetterProvider:DataAccessObject
    {

       public string InsertLi_DonBasicLetter(Li_DonBasicLetter donbasicletter)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_li_InsertDonLetter", connection);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@LetterNo", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
               cmd.Parameters.Add("@DoDesId", SqlDbType.Int).Value = donbasicletter.DoDesId;
               cmd.Parameters.Add("@LetterAmount", SqlDbType.Decimal).Value = donbasicletter.LetterAmount;
               cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = donbasicletter.CreatedBy;
               cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = donbasicletter.CreatedDate;
               connection.Open();

               cmd.ExecuteNonQuery();
               return cmd.Parameters["@LetterNo"].Value.ToString();
           }
       }
       public int InsertLi_DonLetterDetail(Li_DonLetter li_donletter)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_li_InsertDonationLetterDetail", connection);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@LetterNo", SqlDbType.VarChar).Value = li_donletter.LetterNo;
               cmd.Parameters.Add("@PSId", SqlDbType.Int).Value = li_donletter.PSId;
               cmd.Parameters.Add("@DonationAmnt", SqlDbType.Decimal).Value = li_donletter.DonationAmnt;
               cmd.Parameters.Add("@PrevPayment", SqlDbType.Decimal).Value = li_donletter.PrevPayment;
               cmd.Parameters.Add("@DemandAmnt", SqlDbType.Decimal).Value = li_donletter.DemandAmnt;
               cmd.Parameters.Add("@DueAmnt", SqlDbType.Decimal).Value = li_donletter.DueAmnt;
               cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_donletter.CreatedBy;
               cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_donletter.CreatedDate;
               connection.Open();

               int result = cmd.ExecuteNonQuery();
               return result;
           }
       }

    }
}
