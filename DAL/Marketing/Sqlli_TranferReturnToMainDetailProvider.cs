using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_TranferReturnToMainDetailProvider:DataAccessObject
{
	public SqlLi_TranferReturnToMainDetailProvider()
    {
    }


    public bool DeleteLi_TranferReturnToMainDetail(int li_TranferReturnToMainDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_TranferReturnToMainDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TranferReturnToMainDetailID", SqlDbType.Int).Value = li_TranferReturnToMainDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TranferReturnToMainDetail> GetAllLi_TranferReturnToMainDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TranferReturnToMainDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TranferReturnToMainDetailsFromReader(reader);
        }
    }
    public List<Li_TranferReturnToMainDetail> GetLi_TranferReturnToMainDetailsFromReader(IDataReader reader)
    {
        List<Li_TranferReturnToMainDetail> li_TranferReturnToMainDetails = new List<Li_TranferReturnToMainDetail>();

        while (reader.Read())
        {
            li_TranferReturnToMainDetails.Add(GetLi_TranferReturnToMainDetailFromReader(reader));
        }
        return li_TranferReturnToMainDetails;
    }

    public Li_TranferReturnToMainDetail GetLi_TranferReturnToMainDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_TranferReturnToMainDetail li_TranferReturnToMainDetail = new Li_TranferReturnToMainDetail
                (
 
                    reader["ReceiveID"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["Qty"],
                    (decimal)reader["Price"],
                    (char)reader["Status_D"] ,
                     reader ["Edition"].ToString ()
                );
             return li_TranferReturnToMainDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TranferReturnToMainDetail GetLi_TranferReturnToMainDetailByID(int li_TranferReturnToMainDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TranferReturnToMainDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TranferReturnToMainDetailID", SqlDbType.Int).Value = li_TranferReturnToMainDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TranferReturnToMainDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TranferReturnToMainDetail(Li_TranferReturnToMainDetail li_TranferReturnToMainDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_TranferReturnToMainDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_TranferReturnToMainDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_TranferReturnToMainDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_TranferReturnToMainDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_TranferReturnToMainDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TranferReturnToMainDetail.Status_D;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_TranferReturnToMainDetail.Edition ;            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;//(int)cmd.Parameters["@Li_TranferReturnToMainDetailID"].Value;
        }
    }

    public bool UpdateLi_TranferReturnToMainDetail(Li_TranferReturnToMainDetail li_TranferReturnToMainDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_TranferReturnToMainDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_TranferReturnToMainDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_TranferReturnToMainDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_TranferReturnToMainDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_TranferReturnToMainDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TranferReturnToMainDetail.Status_D;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
