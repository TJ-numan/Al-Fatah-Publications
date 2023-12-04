using Common.HR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HR
{
   public class SqlLi_AssetTransferProvider:DataAccessObject
    {
       public int InsertLi_AssetTransfer(li_AssetTransfer li_assetTransfer)
       {
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("HRM.InsertLi_AssetTransfer", connection);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.Add("@AssTId", SqlDbType.Int).Direction = ParameterDirection.Output;
               cmd.Parameters.Add("@AssetId", SqlDbType.Int).Value = li_assetTransfer.AssetId ;
               cmd.Parameters.Add("@FromDepId", SqlDbType.Int).Value = li_assetTransfer.FromDepId;
               cmd.Parameters.Add("@FromEmpId", SqlDbType. Int).Value =li_assetTransfer.FromEmpId  ;
               cmd.Parameters.Add("@ToDepId", SqlDbType. Int).Value = li_assetTransfer.ToDepId ;
               cmd.Parameters.Add("@ToEmpId", SqlDbType.Int).Value = li_assetTransfer.ToEmpId ;
               cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime ).Value =  li_assetTransfer.TransferDate;
               cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_assetTransfer.CreatedBy ;
               cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value =li_assetTransfer .CreatedDate;
               connection.Open();

               int result = cmd.ExecuteNonQuery();
               return (int)cmd.Parameters["@AssTId"].Value;
           }
       }


       public DataTable GetAssetInfoForTransferByAssetCode(string AssetCode)
       {
           DataTable dt = new DataTable();
           using (SqlConnection connection = new SqlConnection(this.ConnectionString))
           {
               SqlCommand cmd = new SqlCommand("HRM.SMPM_li_GetAssetInfoForTransferByAssetCode", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@AssetCode", SqlDbType.VarChar).Value = AssetCode;
               connection.Open();
               SqlDataAdapter myadapter = new SqlDataAdapter(cmd);
               myadapter.Fill(dt);
               myadapter.Dispose();
               connection.Close();
               return dt;
           }
       }
    }
}
