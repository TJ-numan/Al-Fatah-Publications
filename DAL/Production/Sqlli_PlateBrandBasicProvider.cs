using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateBrandBasicProvider:DataAccessObject
{
	public SqlLi_PlateBrandBasicProvider()
    {
    }


    public bool DeleteLi_PlateBrandBasic(int li_PlateBrandBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateBrandBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateBrandBasicID", SqlDbType.Int).Value = li_PlateBrandBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateBrandBasic> GetAllLi_PlateBrandBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateBrandBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateBrandBasicsFromReader(reader);
        }
    }
    public List<Li_PlateBrandBasic> GetLi_PlateBrandBasicsFromReader(IDataReader reader)
    {
        List<Li_PlateBrandBasic> li_PlateBrandBasics = new List<Li_PlateBrandBasic>();

        while (reader.Read())
        {
            li_PlateBrandBasics.Add(GetLi_PlateBrandBasicFromReader(reader));
        }
        return li_PlateBrandBasics;
    }

    public Li_PlateBrandBasic GetLi_PlateBrandBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateBrandBasic li_PlateBrandBasic = new Li_PlateBrandBasic
                (
                    
                    reader["ID"].ToString(),
                    reader["BrandName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] ,
                    reader["PlateSizeType"] .ToString ()
                     
                );
             return li_PlateBrandBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateBrandBasic GetLi_PlateBrandBasicByID(int li_PlateBrandBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateBrandBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateBrandBasicID", SqlDbType.Int).Value = li_PlateBrandBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateBrandBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PlateBrandBasic(Li_PlateBrandBasic li_PlateBrandBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateBrandBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@BrandName", SqlDbType.VarChar).Value = li_PlateBrandBasic.BrandName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateBrandBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateBrandBasic.CreatedDate;
            cmd.Parameters.Add("@PlateSizeType", SqlDbType.VarChar ).Value = li_PlateBrandBasic.PlateSizeType;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PlateBrandBasic(Li_PlateBrandBasic li_PlateBrandBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateBrandBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PlateBrandBasic.ID;
            cmd.Parameters.Add("@BrandName", SqlDbType.VarChar).Value = li_PlateBrandBasic.BrandName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateBrandBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateBrandBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
