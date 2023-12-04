using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_BookSizeBasicProvider:DataAccessObject
{
	public SqlLi_BookSizeBasicProvider()
    {
    }


    public bool DeleteLi_BookSizeBasic(int li_BookSizeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_BookSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_BookSizeBasicID", SqlDbType.Int).Value = li_BookSizeBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_BookSizeBasic> GetAllLi_BookSizeBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_BookSizeBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_BookSizeBasicsFromReader(reader);
        }
    }
    public List<Li_BookSizeBasic> GetLi_BookSizeBasicsFromReader(IDataReader reader)
    {
        List<Li_BookSizeBasic> li_BookSizeBasics = new List<Li_BookSizeBasic>();

        while (reader.Read())
        {
            li_BookSizeBasics.Add(GetLi_BookSizeBasicFromReader(reader));
        }
        return li_BookSizeBasics;
    }

    public Li_BookSizeBasic GetLi_BookSizeBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_BookSizeBasic li_BookSizeBasic = new Li_BookSizeBasic
                (
                     
                    reader["BookSizeID"].ToString(),
                    reader["SizeType"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                );
             return li_BookSizeBasic;
        }
        catch(Exception )
        {
            return null;
        }
    }

    public Li_BookSizeBasic GetLi_BookSizeBasicByID(int li_BookSizeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_BookSizeBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_BookSizeBasicID", SqlDbType.Int).Value = li_BookSizeBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_BookSizeBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_BookSizeBasic(Li_BookSizeBasic li_BookSizeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_BookSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@BookSizeID", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SizeType", SqlDbType.VarChar).Value = li_BookSizeBasic.SizeType;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookSizeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookSizeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@BookSizeID"].Value .ToString ();
        }
    }

    public bool UpdateLi_BookSizeBasic(Li_BookSizeBasic li_BookSizeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_BookSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@BookSizeID", SqlDbType.VarChar).Value = li_BookSizeBasic.BookSizeID;
            cmd.Parameters.Add("@SizeType", SqlDbType.VarChar).Value = li_BookSizeBasic.SizeType;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_BookSizeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_BookSizeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
