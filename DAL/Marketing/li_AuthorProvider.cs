using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

public class Sql_li_AuthorProvider:DataAccessObject
{
	public Sql_li_AuthorProvider()
    {
    }


    public List<li_Author> GetAll_Authors()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetAll_Authors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_AuthorsFromReader(reader);
        }
    }
    public List<li_Author> GetAll_ComboSourceData_Authors()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_GetComboSourceData_Authors", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return Get_AuthorsFromReader(reader);
        }
    }
    public List<li_Author> Get_AuthorsFromReader(IDataReader reader)
    {
        List<li_Author> li_Authors = new List<li_Author>();

        while (reader.Read())
        {
            li_Authors.Add(Get_AuthorFromReader(reader));
        }
        return li_Authors;
    }

    public li_Author Get_AuthorFromReader(IDataReader reader)
    {
        try
        {
            li_Author li_Author = new li_Author
                (

                    (int)reader["AuthorID"],
                    reader["AuthorName"].ToString(),
                    reader["AuthorPhone"].ToString(),
                    reader["AuthorAddress"].ToString()
                );
             return li_Author;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public li_Author Get_AuthorByAuthorID(int  authorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_li_Get_AuthorByAuthorID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AuthorID", SqlDbType.Int).Value = authorID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return Get_AuthorFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int Insert_Author(li_Author li_Author)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Insert_Author", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@AuthorName", SqlDbType.VarChar).Value = li_Author.AuthorName;
            cmd.Parameters.Add("@AuthorPhone", SqlDbType.VarChar).Value = li_Author.AuthorPhone;
            cmd.Parameters.Add("@AuthorAddress", SqlDbType.VarChar).Value = li_Author.AuthorAddress;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AuthorID"].Value;
        }
    }

    public bool Update_Author(li_Author li_Author)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Update_Author", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Value = li_Author.AuthorID;
            cmd.Parameters.Add("@AuthorName", SqlDbType.VarChar).Value = li_Author.AuthorName;
            cmd.Parameters.Add("@AuthorPhone", SqlDbType.VarChar).Value = li_Author.AuthorPhone;
            cmd.Parameters.Add("@AuthorAddress", SqlDbType.VarChar).Value = li_Author.AuthorAddress;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }

    public bool Delete_Author(int authorID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_li_Delete_Author", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Value = authorID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }
}

