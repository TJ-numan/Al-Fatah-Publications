using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BinderReturnDetailProvider:DataAccessObject
{
	public SqlLi_BinderReturnDetailProvider()
    {
    }


    public bool DeleteLi_BinderReturnDetail(int li_BinderReturnDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BinderReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BinderReturnDetailID", SqlDbType.Int).Value = li_BinderReturnDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BinderReturnDetail> GetAllLi_BinderReturnDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BinderReturnDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BinderReturnDetailsFromReader(reader);
        }
    }
    public List<Li_BinderReturnDetail> GetLi_BinderReturnDetailsFromReader(IDataReader reader)
    {
        List<Li_BinderReturnDetail> li_BinderReturnDetails = new List<Li_BinderReturnDetail>();

        while (reader.Read())
        {
            li_BinderReturnDetails.Add(GetLi_BinderReturnDetailFromReader(reader));
        }
        return li_BinderReturnDetails;
    }

    public Li_BinderReturnDetail GetLi_BinderReturnDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_BinderReturnDetail li_BinderReturnDetail = new Li_BinderReturnDetail
                (
                     
                    (int)reader["SerialNo"],
                    reader["ReceiveID"].ToString(),
                    reader["BookCode"].ToString(),
                    (int)reader["ReceiveItemType"],
                    (decimal)reader["Qty"] 
                );
             return li_BinderReturnDetail;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_BinderReturnDetail GetLi_BinderReturnDetailByID(int li_BinderReturnDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BinderReturnDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BinderReturnDetailID", SqlDbType.Int).Value = li_BinderReturnDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BinderReturnDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BinderReturnDetail(Li_BinderReturnDetail li_BinderReturnDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BinderReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_BinderReturnDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BinderReturnDetail.BookCode;
            cmd.Parameters.Add("@ReceiveItemType", SqlDbType.Int).Value = li_BinderReturnDetail.ReceiveItemType;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BinderReturnDetail.Qty;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@SerialNo"].Value;
        }
    }

    public bool UpdateLi_BinderReturnDetail(Li_BinderReturnDetail li_BinderReturnDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BinderReturnDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_BinderReturnDetail.SerialNo;
            cmd.Parameters.Add("@ReceiveID", SqlDbType.VarChar).Value = li_BinderReturnDetail.ReceiveID;
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_BinderReturnDetail.BookCode;
            cmd.Parameters.Add("@ReceiveItemType", SqlDbType.Int).Value = li_BinderReturnDetail.ReceiveItemType;
            cmd.Parameters.Add("@Qty", SqlDbType.Decimal).Value = li_BinderReturnDetail.Qty;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
