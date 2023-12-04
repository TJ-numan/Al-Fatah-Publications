using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_TransectionTypeProvider:DataAccessObject
{
	public SqlLi_TransectionTypeProvider()
    {
    }


    public bool DeleteLi_TransectionType(int li_TransectionTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_TransectionType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TransectionTypeID", SqlDbType.Int).Value = li_TransectionTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TransectionType> GetAllLi_TransectionTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TransectionTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TransectionTypesFromReader(reader);
        }
    }
    public List<Li_TransectionType> GetLi_TransectionTypesFromReader(IDataReader reader)
    {
        List<Li_TransectionType> li_TransectionTypes = new List<Li_TransectionType>();

        while (reader.Read())
        {
            li_TransectionTypes.Add(GetLi_TransectionTypeFromReader(reader));
        }
        return li_TransectionTypes;
    }

    public Li_TransectionType GetLi_TransectionTypeFromReader(IDataReader reader)
    {
        try
        {
            Li_TransectionType li_TransectionType = new Li_TransectionType
                (
                    
                    (int)reader["TannID"],
                    reader["TranbType"].ToString() 
                    
                );
             return li_TransectionType;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public Li_TransectionType GetLi_TransectionTypeByID(int li_TransectionTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TransectionTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TransectionTypeID", SqlDbType.Int).Value = li_TransectionTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TransectionTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_TransectionType(Li_TransectionType li_TransectionType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_TransectionType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@TannID", SqlDbType.Int).Value = li_TransectionType.TannID;
            cmd.Parameters.Add("@TranbType", SqlDbType.VarChar).Value = li_TransectionType.TranbType;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_TransectionTypeID"].Value;
        }
    }

    public bool UpdateLi_TransectionType(Li_TransectionType li_TransectionType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_TransectionType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@TannID", SqlDbType.Int).Value = li_TransectionType.TannID;
            cmd.Parameters.Add("@TranbType", SqlDbType.VarChar).Value = li_TransectionType.TranbType;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
