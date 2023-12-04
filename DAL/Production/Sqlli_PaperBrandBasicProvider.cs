using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperBrandBasicProvider:DataAccessObject
{
	public SqlLi_PaperBrandBasicProvider()
    {
    }


    public bool DeleteLi_PaperBrandBasic(int li_PaperBrandBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperBrandBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperBrandBasicID", SqlDbType.Int).Value = li_PaperBrandBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperBrandBasic> GetAllLi_PaperBrandBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperBrandBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperBrandBasicsFromReader(reader);
        }
    }
    public List<Li_PaperBrandBasic> GetLi_PaperBrandBasicsFromReader(IDataReader reader)
    {
        List<Li_PaperBrandBasic> li_PaperBrandBasics = new List<Li_PaperBrandBasic>();

        while (reader.Read())
        {
            li_PaperBrandBasics.Add(GetLi_PaperBrandBasicFromReader(reader));
        }
        return li_PaperBrandBasics;
    }

    public Li_PaperBrandBasic GetLi_PaperBrandBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperBrandBasic li_PaperBrandBasic = new Li_PaperBrandBasic
                (
                    
                    reader["ID"].ToString(),
                    reader["Brand"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                    
                );
             return li_PaperBrandBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperBrandBasic GetLi_PaperBrandBasicByID(int li_PaperBrandBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperBrandBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperBrandBasicID", SqlDbType.Int).Value = li_PaperBrandBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperBrandBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public  string  InsertLi_PaperBrandBasic(Li_PaperBrandBasic li_PaperBrandBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperBrandBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50  ).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Brand", SqlDbType.VarChar).Value = li_PaperBrandBasic.Brand;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperBrandBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperBrandBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PaperBrandBasic(Li_PaperBrandBasic li_PaperBrandBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperBrandBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PaperBrandBasic.ID;
            cmd.Parameters.Add("@Brand", SqlDbType.VarChar).Value = li_PaperBrandBasic.Brand;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperBrandBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperBrandBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
