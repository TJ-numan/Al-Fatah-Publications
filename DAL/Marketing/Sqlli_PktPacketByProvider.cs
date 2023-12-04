using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PktPacketByProvider:DataAccessObject
{
	public SqlLi_PktPacketByProvider()
    {
    }


    public bool DeleteLi_PktPacketBy(int li_PktPacketByID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PktPacketBy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PktPacketByID", SqlDbType.Int).Value = li_PktPacketByID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PktPacketBy> GetAllLi_PktPacketBies()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PktPacketBies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PktPacketBiesFromReader(reader);
        }
    }
    public List<Li_PktPacketBy> GetLi_PktPacketBiesFromReader(IDataReader reader)
    {
        List<Li_PktPacketBy> li_PktPacketBies = new List<Li_PktPacketBy>();

        while (reader.Read())
        {
            li_PktPacketBies.Add(GetLi_PktPacketByFromReader(reader));
        }
        return li_PktPacketBies;
    }

    public Li_PktPacketBy GetLi_PktPacketByFromReader(IDataReader reader)
    {
        try
        {
            Li_PktPacketBy li_PktPacketBy = new Li_PktPacketBy
                (
                     
                    (int)reader["ID"],
                    reader["PackedBy"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["ModifiedBy"] 
                );
             return li_PktPacketBy;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PktPacketBy GetLi_PktPacketByByID(int li_PktPacketByID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PktPacketByByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PktPacketByID", SqlDbType.Int).Value = li_PktPacketByID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PktPacketByFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PktPacketBy(Li_PktPacketBy li_PktPacketBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PktPacketBy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@ID", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PackedBy", SqlDbType.VarChar).Value = li_PktPacketBy.PackedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PktPacketBy.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PktPacketBy.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PktPacketBy.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PktPacketBy.ModifiedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;
        }
    }

    public bool UpdateLi_PktPacketBy(Li_PktPacketBy li_PktPacketBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PktPacketBy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_PktPacketBy.ID;
            cmd.Parameters.Add("@PackedBy", SqlDbType.VarChar).Value = li_PktPacketBy.PackedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PktPacketBy.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PktPacketBy.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PktPacketBy.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PktPacketBy.ModifiedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
