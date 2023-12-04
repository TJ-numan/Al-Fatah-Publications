using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_AgentQawmiMadrasahProvider:DataAccessObject
{
	public SqlLi_AgentQawmiMadrasahProvider()
    {
    }


    public bool DeleteLi_AgentQawmiMadrasah(int li_AgentQawmiMadrasahID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_AgentQawmiMadrasah", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_AgentQawmiMadrasahID", SqlDbType.Int).Value = li_AgentQawmiMadrasahID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_AgentQawmiMadrasah> GetAllLi_AgentQawmiMadrasahs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_AgentQawmiMadrasahs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AgentQawmiMadrasahsFromReader(reader);
        }
    }
    public List<Li_AgentQawmiMadrasah> GetLi_AgentQawmiMadrasahsFromReader(IDataReader reader)
    {
        List<Li_AgentQawmiMadrasah> li_AgentQawmiMadrasahs = new List<Li_AgentQawmiMadrasah>();

        while (reader.Read())
        {
            li_AgentQawmiMadrasahs.Add(GetLi_AgentQawmiMadrasahFromReader(reader));
        }
        return li_AgentQawmiMadrasahs;
    }

    public Li_AgentQawmiMadrasah GetLi_AgentQawmiMadrasahFromReader(IDataReader reader)
    {
        try
        {
            Li_AgentQawmiMadrasah li_AgentQawmiMadrasah = new Li_AgentQawmiMadrasah
                (
                  
                    (int)reader["AgentID"],
                    reader["AgentName"].ToString() 
                );
             return li_AgentQawmiMadrasah;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_AgentQawmiMadrasah GetLi_AgentQawmiMadrasahByID(int li_AgentQawmiMadrasahID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_AgentQawmiMadrasahByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_AgentQawmiMadrasahID", SqlDbType.Int).Value = li_AgentQawmiMadrasahID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AgentQawmiMadrasahFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_AgentQawmiMadrasah(Li_AgentQawmiMadrasah li_AgentQawmiMadrasah)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_AgentQawmiMadrasah", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@AgentID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AgentName", SqlDbType.VarChar).Value = li_AgentQawmiMadrasah.AgentName;
        
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AgentID"].Value;
        }
    }

    public bool UpdateLi_AgentQawmiMadrasah(Li_AgentQawmiMadrasah li_AgentQawmiMadrasah)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_AgentQawmiMadrasah", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@AgentID", SqlDbType.Int).Value = li_AgentQawmiMadrasah.AgentID;
            cmd.Parameters.Add("@AgentName", SqlDbType.VarChar).Value = li_AgentQawmiMadrasah.AgentName;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
