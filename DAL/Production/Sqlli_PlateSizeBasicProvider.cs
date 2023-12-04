using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateSizeBasicProvider:DataAccessObject
{
	public SqlLi_PlateSizeBasicProvider()
    {
    }


    public bool DeleteLi_PlateSizeBasic(int li_PlateSizeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateSizeBasicID", SqlDbType.Int).Value = li_PlateSizeBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateSizeBasic> GetAllLi_PlateSizeBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateSizeBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateSizeBasicsFromReader(reader);
        }
    }
    public List<Li_PlateSizeBasic> GetLi_PlateSizeBasicsFromReader(IDataReader reader)
    {
        List<Li_PlateSizeBasic> li_PlateSizeBasics = new List<Li_PlateSizeBasic>();

        while (reader.Read())
        {
            li_PlateSizeBasics.Add(GetLi_PlateSizeBasicFromReader(reader));
        }
        return li_PlateSizeBasics;
    }

    public Li_PlateSizeBasic GetLi_PlateSizeBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateSizeBasic li_PlateSizeBasic = new Li_PlateSizeBasic
                (
                     
                    reader["ID"].ToString(),
                    reader["Size"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                     
                );
             return li_PlateSizeBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateSizeBasic GetLi_PlateSizeBasicByID(int li_PlateSizeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateSizeBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateSizeBasicID", SqlDbType.Int).Value = li_PlateSizeBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateSizeBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PlateSizeBasic(Li_PlateSizeBasic li_PlateSizeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = li_PlateSizeBasic.Size;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateSizeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateSizeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PlateSizeBasic(Li_PlateSizeBasic li_PlateSizeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateSizeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PlateSizeBasic.ID;
            cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = li_PlateSizeBasic.Size;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateSizeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateSizeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
