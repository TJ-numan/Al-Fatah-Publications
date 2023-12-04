using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_LeminationOrderDetailProvider:DataAccessObject
{
	public SqlLi_LeminationOrderDetailProvider()
    {
    }


    public bool DeleteLi_LeminationOrderDetail(int li_LeminationOrderDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LeminationOrderDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LeminationOrderDetailID", SqlDbType.Int).Value = li_LeminationOrderDetailID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeminationOrderDetail> GetAllLi_LeminationOrderDetails()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_LeminationOrderDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeminationOrderDetailsFromReader(reader);
        }
    }
    public List<Li_LeminationOrderDetail> GetLi_LeminationOrderDetailsFromReader(IDataReader reader)
    {
        List<Li_LeminationOrderDetail> li_LeminationOrderDetails = new List<Li_LeminationOrderDetail>();

        while (reader.Read())
        {
            li_LeminationOrderDetails.Add(GetLi_LeminationOrderDetailFromReader(reader));
        }
        return li_LeminationOrderDetails;
    }

    public Li_LeminationOrderDetail GetLi_LeminationOrderDetailFromReader(IDataReader reader)
    {
        try
        {
            Li_LeminationOrderDetail li_LeminationOrderDetail = new Li_LeminationOrderDetail
                (
                    
                    (int)reader["SerialNo"],
                    reader["OrderID"].ToString(),
                    reader["LemiPartyID"].ToString(),
                    reader["LemiTypeID"].ToString(),
                    (int)reader["Qty"] 
                );
             return li_LeminationOrderDetail;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LeminationOrderDetail GetLi_LeminationOrderDetailByID(int li_LeminationOrderDetailID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LeminationOrderDetailByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LeminationOrderDetailID", SqlDbType.Int).Value = li_LeminationOrderDetailID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeminationOrderDetailFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LeminationOrderDetail(Li_LeminationOrderDetail li_LeminationOrderDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_LeminationOrderDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
    
            cmd.Parameters.Add("@OrderID", SqlDbType.VarChar).Value = li_LeminationOrderDetail.OrderID;
            cmd.Parameters.Add("@LemiPartyID", SqlDbType.VarChar).Value = li_LeminationOrderDetail.LemiPartyID;
            cmd.Parameters.Add("@LemiTypeID", SqlDbType.VarChar).Value = li_LeminationOrderDetail.LemiTypeID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_LeminationOrderDetail.Qty;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_LeminationOrderDetail(Li_LeminationOrderDetail li_LeminationOrderDetail)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_LeminationOrderDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_LeminationOrderDetail.SerialNo;
            cmd.Parameters.Add("@OrderID", SqlDbType.VarChar).Value = li_LeminationOrderDetail.OrderID;
            cmd.Parameters.Add("@LemiPartyID", SqlDbType.VarChar).Value = li_LeminationOrderDetail.LemiPartyID;
            cmd.Parameters.Add("@LemiTypeID", SqlDbType.VarChar).Value = li_LeminationOrderDetail.LemiTypeID;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = li_LeminationOrderDetail.Qty;
         
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
