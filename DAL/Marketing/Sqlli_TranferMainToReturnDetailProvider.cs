using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_TranferMainToReturnDetailProvider:DataAccessObject
{
	public SqlLi_TranferMainToReturnDetailProvider()
    {
    }


    public bool DeleteLi_TranferMainToReturnDetail(int li_TranferMainToReturnDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_TranferMainToReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TranferMainToReturnDetailID", SqlDbType.Int).Value = li_TranferMainToReturnDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TranferMainToReturnDetail> GetAllLi_TranferMainToReturnDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TranferMainToReturnDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TranferMainToReturnDetailsFromReader(reader);
        }
    }
    public List<Li_TranferMainToReturnDetail> GetLi_TranferMainToReturnDetailsFromReader(IDataReader reader)
    {
        List<Li_TranferMainToReturnDetail> li_TranferMainToReturnDetails = new List<Li_TranferMainToReturnDetail>();

        while (reader.Read())
        {
            li_TranferMainToReturnDetails.Add(GetLi_TranferMainToReturnDetailFromReader(reader));
        }
        return li_TranferMainToReturnDetails;
    }

    public Li_TranferMainToReturnDetail GetLi_TranferMainToReturnDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_TranferMainToReturnDetail li_TranferMainToReturnDetail = new Li_TranferMainToReturnDetail
                (
 
                    reader["ReceiveID"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["Qty"],
                    (decimal)reader["Price"],
                    (char)reader["Status_D"],
                     reader["Edition"].ToString()
                );
             return li_TranferMainToReturnDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TranferMainToReturnDetail GetLi_TranferMainToReturnDetailByID(int li_TranferMainToReturnDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TranferMainToReturnDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TranferMainToReturnDetailID", SqlDbType.Int).Value = li_TranferMainToReturnDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TranferMainToReturnDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TranferMainToReturnDetail(Li_TranferMainToReturnDetail li_TranferMainToReturnDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_TranferMainToReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_TranferMainToReturnDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_TranferMainToReturnDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_TranferMainToReturnDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_TranferMainToReturnDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TranferMainToReturnDetail.Status_D;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value =li_TranferMainToReturnDetail  .Edition; 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_TranferMainToReturnDetailID"].Value;
        }
    }

    public bool UpdateLi_TranferMainToReturnDetail(Li_TranferMainToReturnDetail li_TranferMainToReturnDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_TranferMainToReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_TranferMainToReturnDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_TranferMainToReturnDetail.BookCode;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_TranferMainToReturnDetail.Qty;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = li_TranferMainToReturnDetail.Price;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TranferMainToReturnDetail.Status_D;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
