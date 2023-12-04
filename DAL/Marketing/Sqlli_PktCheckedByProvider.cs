using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PktCheckedByProvider:DataAccessObject
{
	public SqlLi_PktCheckedByProvider()
    {
    }


    public bool DeleteLi_PktCheckedBy(int li_PktCheckedByID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PktCheckedBy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PktCheckedByID", SqlDbType.Int).Value = li_PktCheckedByID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PktCheckedBy> GetAllLi_PktCheckedBies()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PktCheckedBies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PktCheckedBiesFromReader(reader);
        }
    }
    public List<Li_PktCheckedBy> GetLi_PktCheckedBiesFromReader(IDataReader reader)
    {
        List<Li_PktCheckedBy> li_PktCheckedBies = new List<Li_PktCheckedBy>();

        while (reader.Read())
        {
            li_PktCheckedBies.Add(GetLi_PktCheckedByFromReader(reader));
        }
        return li_PktCheckedBies;
    }

    public Li_PktCheckedBy GetLi_PktCheckedByFromReader(IDataReader reader)
    {
        try
        {
            Li_PktCheckedBy li_PktCheckedBy = new Li_PktCheckedBy
                (
                    
                    (int)reader["ID"],
                    reader["CheckedBy"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["ModifiedBy"] 
                );
             return li_PktCheckedBy;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PktCheckedBy GetLi_PktCheckedByByID(int li_PktCheckedByID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PktCheckedByByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PktCheckedByID", SqlDbType.Int).Value = li_PktCheckedByID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PktCheckedByFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PktCheckedBy(Li_PktCheckedBy li_PktCheckedBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PktCheckedBy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@ID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@CheckedBy", SqlDbType.VarChar).Value = li_PktCheckedBy.CheckedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PktCheckedBy.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PktCheckedBy.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PktCheckedBy.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PktCheckedBy.ModifiedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1 ;
        }
    }

    public bool UpdateLi_PktCheckedBy(Li_PktCheckedBy li_PktCheckedBy)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PktCheckedBy", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_PktCheckedBy.ID;
            cmd.Parameters.Add("@CheckedBy", SqlDbType.VarChar).Value = li_PktCheckedBy.CheckedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PktCheckedBy.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PktCheckedBy.CreatedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PktCheckedBy.ModifiedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PktCheckedBy.ModifiedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
