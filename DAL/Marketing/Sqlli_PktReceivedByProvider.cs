using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PktReceivedByProvider:DataAccessObject
{
	public SqlLi_PktReceivedByProvider()
    {
    }


    public bool DeleteLi_PktReceivedBy(int li_PktReceivedByID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PktReceivedBy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PktReceivedByID", SqlDbType.Int).Value = li_PktReceivedByID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PktReceivedBy> GetAllLi_PktReceivedBies()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PktReceivedBies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PktReceivedBiesFromReader(reader);
        }
    }
    public List<Li_PktReceivedBy> GetLi_PktReceivedBiesFromReader(IDataReader reader)
    {
        List<Li_PktReceivedBy> li_PktReceivedBies = new List<Li_PktReceivedBy>();

        while (reader.Read())
        {
            li_PktReceivedBies.Add(GetLi_PktReceivedByFromReader(reader));
        }
        return li_PktReceivedBies;
    }

    public Li_PktReceivedBy GetLi_PktReceivedByFromReader(IDataReader reader)
    {
        try
        {
            Li_PktReceivedBy li_PktReceivedBy = new Li_PktReceivedBy
                (
                    
                    (int)reader["ID"],
                    reader["ReceivedBy"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["ModifiedBy"] 
                );
             return li_PktReceivedBy;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PktReceivedBy GetLi_PktReceivedByByID(int li_PktReceivedByID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PktReceivedByByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PktReceivedByID", SqlDbType.Int).Value = li_PktReceivedByID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PktReceivedByFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PktReceivedBy(Li_PktReceivedBy li_PktReceivedBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PktReceivedBy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@ID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ReceivedBy", SqlDbType.VarChar).Value = li_PktReceivedBy.ReceivedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PktReceivedBy.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PktReceivedBy.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PktReceivedBy.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PktReceivedBy.ModifiedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_PktReceivedBy(Li_PktReceivedBy li_PktReceivedBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PktReceivedBy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_PktReceivedBy.ID;
            cmd.Parameters.Add("@ReceivedBy", SqlDbType.VarChar).Value = li_PktReceivedBy.ReceivedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PktReceivedBy.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PktReceivedBy.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PktReceivedBy.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PktReceivedBy.ModifiedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
