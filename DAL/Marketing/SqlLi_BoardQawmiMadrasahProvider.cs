using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BoardQawmiMadrasahProvider:DataAccessObject
{
	public SqlLi_BoardQawmiMadrasahProvider()
    {
    }


    public bool DeleteLi_BoardQawmiMadrasah(int li_BoardQawmiMadrasahID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BoardQawmiMadrasah", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BoardQawmiMadrasahID", SqlDbType.Int).Value = li_BoardQawmiMadrasahID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BoardQawmiMadrasah> GetAllLi_BoardQawmiMadrasahs()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BoardQawmiMadrasahs", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BoardQawmiMadrasahsFromReader(reader);
        }
    }
    public List<Li_BoardQawmiMadrasah> GetLi_BoardQawmiMadrasahsFromReader(IDataReader reader)
    {
        List<Li_BoardQawmiMadrasah> li_BoardQawmiMadrasahs = new List<Li_BoardQawmiMadrasah>();

        while (reader.Read())
        {
            li_BoardQawmiMadrasahs.Add(GetLi_BoardQawmiMadrasahFromReader(reader));
        }
        return li_BoardQawmiMadrasahs;
    }

    public Li_BoardQawmiMadrasah GetLi_BoardQawmiMadrasahFromReader(IDataReader reader)
    {
        try
        {
            Li_BoardQawmiMadrasah li_BoardQawmiMadrasah = new Li_BoardQawmiMadrasah
                (
                     
                    (int)reader["BoardID"],
                    reader["BoardName"].ToString()  
                );
             return li_BoardQawmiMadrasah;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public Li_BoardQawmiMadrasah GetLi_BoardQawmiMadrasahByID(int li_BoardQawmiMadrasahID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BoardQawmiMadrasahByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BoardQawmiMadrasahID", SqlDbType.Int).Value = li_BoardQawmiMadrasahID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BoardQawmiMadrasahFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_BoardQawmiMadrasah(Li_BoardQawmiMadrasah li_BoardQawmiMadrasah)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BoardQawmiMadrasah", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@BoardID", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BoardName", SqlDbType.VarChar).Value = li_BoardQawmiMadrasah.BoardName;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@BoardID"].Value;
        }
    }

    public bool UpdateLi_BoardQawmiMadrasah(Li_BoardQawmiMadrasah li_BoardQawmiMadrasah)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BoardQawmiMadrasah", connection);
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BoardID", SqlDbType.Int).Value = li_BoardQawmiMadrasah.BoardID;
             cmd.Parameters.Add("@BoardName", SqlDbType.VarChar).Value = li_BoardQawmiMadrasah.BoardName;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
