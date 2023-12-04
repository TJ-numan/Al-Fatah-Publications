using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
 
using System.Xml.Linq;
using DAL;

public class SqlLi_Book_PartProvider:DataAccessObject
{
	public SqlLi_Book_PartProvider()
    {
    }


    public bool DeleteLi_Book_Part(int li_Book_PartID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Book_Part", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Book_PartID", SqlDbType.Int).Value = li_Book_PartID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Book_Part> GetAllLi_Book_Parts()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Book_Parts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Book_PartsFromReader(reader);
        }
    }
    public List<Li_Book_Part> GetLi_Book_PartsFromReader(IDataReader reader)
    {
        List<Li_Book_Part> li_Book_Parts = new List<Li_Book_Part>();

        while (reader.Read())
        {
            li_Book_Parts.Add(GetLi_Book_PartFromReader(reader));
        }
        return li_Book_Parts;
    }

    public Li_Book_Part GetLi_Book_PartFromReader(IDataReader reader)
    {
        try
        {
            Li_Book_Part li_Book_Part = new Li_Book_Part
                (
                    
                    (int)reader["ID"],
                    reader["Pa_Nm"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                );
             return li_Book_Part;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_Book_Part GetLi_Book_PartByID(int li_Book_PartID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Book_PartByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Book_PartID", SqlDbType.Int).Value = li_Book_PartID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Book_PartFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Book_Part(Li_Book_Part li_Book_Part)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Book_Part", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_Book_Part.ID;
            cmd.Parameters.Add("@Pa_Nm", SqlDbType.NChar).Value = li_Book_Part.Pa_Nm;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Book_Part.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Book_Part.CreatedDate;
     
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_Book_PartID"].Value;
        }
    }

    public bool UpdateLi_Book_Part(Li_Book_Part li_Book_Part)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Book_Part", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_Book_Part.ID;
            cmd.Parameters.Add("@Pa_Nm", SqlDbType.NChar).Value = li_Book_Part.Pa_Nm;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Book_Part.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Book_Part.CreatedDate;
       
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
