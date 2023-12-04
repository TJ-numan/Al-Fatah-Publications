using Common.Marketing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Marketing
{
   public class li_PrimaryObservationProvider:DataAccessObject
    {
       public int InsertLi_PrimaryObservation(li_DonPrimaryObservation li_PrimaryObs)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_InsertLi_DonPrimaryObservation", connection);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@PORId", SqlDbType.Int).Direction = ParameterDirection.Output;
               cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = li_PrimaryObs.AgrNo;
               cmd.Parameters.Add("@AgrYNo", SqlDbType.VarChar).Value = li_PrimaryObs.AgrYNo;
               cmd.Parameters.Add("@AgrYear", SqlDbType.VarChar).Value = li_PrimaryObs.AgrYear;
               cmd.Parameters.Add("@ThanaId", SqlDbType.Int).Value = li_PrimaryObs.ThanaId;
               cmd.Parameters.Add("@EIIN", SqlDbType.Int).Value = li_PrimaryObs.EIIN;
               cmd.Parameters.Add("@DoFId", SqlDbType.Int).Value = li_PrimaryObs.DoFId;
               cmd.Parameters.Add("@DoName", SqlDbType.VarChar).Value = li_PrimaryObs.DoName;
               cmd.Parameters.Add("@VillRoBaz", SqlDbType.VarChar).Value = li_PrimaryObs.VillRoBaz;
               cmd.Parameters.Add("@PostOff", SqlDbType.VarChar).Value = li_PrimaryObs.PostOff;
               cmd.Parameters.Add("@ContactNo", SqlDbType.VarChar).Value = li_PrimaryObs.ContactNo;
               cmd.Parameters.Add("@RecceivedInfo", SqlDbType.VarChar).Value = li_PrimaryObs.RecceivedInfo;
               cmd.Parameters.Add("@Problems", SqlDbType.VarChar).Value = li_PrimaryObs.Problems;
               cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PrimaryObs.CreatedBy;
               cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PrimaryObs.CreatedDate;
               cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PrimaryObs.ModifiedBy;
               cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PrimaryObs.ModifiedDate;
               connection.Open();

               int result = cmd.ExecuteNonQuery();
               return (int)cmd.Parameters["@PORId"].Value;
           }
       }

       public int InsertLi_DonInformarDetails(li_DonInformar li_DonInformar)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("SMPM_InsertLi_DonInformar", connection);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@RecInfId", SqlDbType.Int).Direction = ParameterDirection.Output;
               cmd.Parameters.Add("@PORId", SqlDbType.Int).Value = li_DonInformar.PORId;
               cmd.Parameters.Add("@InformarName", SqlDbType.VarChar).Value = li_DonInformar.InformarName;
               cmd.Parameters.Add("@Responsibility", SqlDbType.VarChar).Value = li_DonInformar.Responsibility;
               cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar).Value = li_DonInformar.MobileNo;
               cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonInformar.CreatedBy;
               cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonInformar.CreatedDate;
               cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_DonInformar.ModifiedBy;
               cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_DonInformar.ModifiedDate;
               connection.Open();

               int result = cmd.ExecuteNonQuery();
               return (int)cmd.Parameters["@RecInfId"].Value;
           }
       }

       public DataSet GetDonationExisting_POR(string AgrNo, int DoFId, string AgYear)
       {
           DataSet ds = new DataSet();
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("Get_li_DonAgreementExistPOR", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@AgrNo", SqlDbType.VarChar).Value = AgrNo;
               cmd.Parameters.Add("@DoFId", SqlDbType.Int).Value = DoFId;
               cmd.Parameters.Add("@AgYear", SqlDbType.VarChar).Value = AgYear;
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
