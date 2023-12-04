using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 
using System.Xml.Linq;
using DAL;

public class SqlLi_ChalanDeliveryProvider:DataAccessObject
{
	public SqlLi_ChalanDeliveryProvider()
    {
    }


    public bool DeleteLi_ChalanDelivery(int li_ChalanDeliveryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_ChalanDelivery", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ChalanDeliveryID", SqlDbType.Int).Value = li_ChalanDeliveryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ChalanDelivery> GetAllLi_ChalanDeliveries()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_ChalanDeliveries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ChalanDeliveriesFromReader(reader);
        }
    }
    public List<Li_ChalanDelivery> GetLi_ChalanDeliveriesFromReader(IDataReader reader)
    {
        List<Li_ChalanDelivery> li_ChalanDeliveries = new List<Li_ChalanDelivery>();

        while (reader.Read())
        {
            li_ChalanDeliveries.Add(GetLi_ChalanDeliveryFromReader(reader));
        }
        return li_ChalanDeliveries;
    }

    public Li_ChalanDelivery GetLi_ChalanDeliveryFromReader(IDataReader reader)
    {
        try
        {
            Li_ChalanDelivery li_ChalanDelivery = new Li_ChalanDelivery
                (
                     
                    (int)reader["MemoNo"],
                    (DateTime)reader["CreatedDate"],
                    (DateTime)reader["DeliveryDate"],
                    (int)reader["ProofBy"],
                    reader["Receivedby"].ToString(),
                    reader["PacketBy"].ToString(),
                    reader["Checkedby"].ToString(),
                    (decimal)reader["PacketNo"],
                    (decimal)reader["PacketCost"],
                    (DateTime)reader["PostedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"] 
                );
             return li_ChalanDelivery;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ChalanDelivery GetLi_ChalanDeliveryByID(int li_ChalanDeliveryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_ChalanDeliveryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_ChalanDeliveryID", SqlDbType.Int).Value = li_ChalanDeliveryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ChalanDeliveryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ChalanDelivery(Li_ChalanDelivery li_ChalanDelivery)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_ChalanDelivery", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_ChalanDelivery.MemoNo;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ChalanDelivery.CreatedDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_ChalanDelivery.DeliveryDate;
            cmd.Parameters.Add("@ProofBy", SqlDbType.Int).Value = li_ChalanDelivery.ProofBy;
            cmd.Parameters.Add("@Receivedby", SqlDbType.VarChar).Value = li_ChalanDelivery.Receivedby;
            cmd.Parameters.Add("@PacketBy", SqlDbType.VarChar).Value = li_ChalanDelivery.PacketBy;
            cmd.Parameters.Add("@Checkedby", SqlDbType.VarChar).Value = li_ChalanDelivery.Checkedby;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Decimal).Value = li_ChalanDelivery.PacketNo;
            cmd.Parameters.Add("@PacketCost", SqlDbType.Decimal).Value = li_ChalanDelivery.PacketCost;
            cmd.Parameters.Add("@PostedDate", SqlDbType.DateTime).Value = li_ChalanDelivery.PostedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ChalanDelivery.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ChalanDelivery.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  1;
        }
    }

    public bool UpdateLi_ChalanDelivery(Li_ChalanDelivery li_ChalanDelivery)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_ChalanDelivery", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_ChalanDelivery.MemoNo;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ChalanDelivery.CreatedDate;
            cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = li_ChalanDelivery.DeliveryDate;
            cmd.Parameters.Add("@ProofBy", SqlDbType.Int).Value = li_ChalanDelivery.ProofBy;
            cmd.Parameters.Add("@Receivedby", SqlDbType.VarChar).Value = li_ChalanDelivery.Receivedby;
            cmd.Parameters.Add("@PacketBy", SqlDbType.VarChar).Value = li_ChalanDelivery.PacketBy;
            cmd.Parameters.Add("@Checkedby", SqlDbType.VarChar).Value = li_ChalanDelivery.Checkedby;
            cmd.Parameters.Add("@PacketNo", SqlDbType.Decimal).Value = li_ChalanDelivery.PacketNo;
            cmd.Parameters.Add("@PacketCost", SqlDbType.Decimal).Value = li_ChalanDelivery.PacketCost;
            cmd.Parameters.Add("@PostedDate", SqlDbType.DateTime).Value = li_ChalanDelivery.PostedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ChalanDelivery.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ChalanDelivery.ModifiedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
