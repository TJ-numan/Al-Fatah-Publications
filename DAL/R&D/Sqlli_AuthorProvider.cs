using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_AuthorProvider:DataAccessObject
{
	public SqlLi_AuthorProvider()
    {
    }


    public bool DeleteLi_Author(int li_AuthorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Author", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_AuthorID", SqlDbType.Int).Value = li_AuthorID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Author> GetAllLi_Authors()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Authors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_AuthorsFromReader(reader);
        }
    }
    public List<Li_Author> GetLi_AuthorsFromReader(IDataReader reader)
    {
        List<Li_Author> li_Authors = new List<Li_Author>();

        while (reader.Read())
        {
            li_Authors.Add(GetLi_AuthorFromReader(reader));
        }
        return li_Authors;
    }

    public Li_Author GetLi_AuthorFromReader(IDataReader reader)
    {
        try
        {
            Li_Author li_Author = new Li_Author
                (
                     
                    reader["AuthorID"].ToString(),
                     reader["Au_Name"].ToString(),
                    reader["Au_Phone"].ToString(),
                    reader["Au_Address"].ToString(),
                    (bool)reader["IsOut"],
                    //(char)reader["Status_D"],
                    'C',
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"] 
                );
             return li_Author;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Author GetLi_AuthorByID(int li_AuthorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_AuthorByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_AuthorID", SqlDbType.Int).Value = li_AuthorID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_AuthorFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Author(Li_Author li_Author)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_AuthorModified", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@AuthorID", SqlDbType.VarChar).Direction=ParameterDirection.Output;
            cmd.Parameters.Add("@Au_Name", SqlDbType.VarChar).Value = li_Author.Au_Name;
            cmd.Parameters.Add("@Au_Phone", SqlDbType.VarChar).Value = li_Author.Au_Phone;
            cmd.Parameters.Add("@Au_Address", SqlDbType.VarChar).Value = li_Author.Au_Address;
            cmd.Parameters.Add("@IsOut", SqlDbType.Bit).Value = li_Author.IsOut;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Author.Status_D;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Author.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Author.CreatedBy;
     
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }

    public bool UpdateLi_Author(Li_Author li_Author)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Author", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@AuthorID", SqlDbType.VarChar).Value = li_Author.AuthorID;
            cmd.Parameters.Add("@Au_Name", SqlDbType.VarChar).Value = li_Author.Au_Name;
            cmd.Parameters.Add("@Au_Phone", SqlDbType.VarChar).Value = li_Author.Au_Phone;
            cmd.Parameters.Add("@Au_Address", SqlDbType.VarChar).Value = li_Author.Au_Address;
            cmd.Parameters.Add("@IsOut", SqlDbType.Bit).Value = li_Author.IsOut;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Author.Status_D;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Author.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Author.CreatedBy;
      
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
