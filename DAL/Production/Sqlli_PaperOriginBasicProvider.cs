using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperOriginBasicProvider:DataAccessObject
{
	public SqlLi_PaperOriginBasicProvider()
    {
    }


    public bool DeleteLi_PaperOriginBasic(int li_PaperOriginBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperOriginBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperOriginBasicID", SqlDbType.Int).Value = li_PaperOriginBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperOriginBasic> GetAllLi_PaperOriginBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperOriginBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperOriginBasicsFromReader(reader);
        }
    }
    public List<Li_PaperOriginBasic> GetLi_PaperOriginBasicsFromReader(IDataReader reader)
    {
        List<Li_PaperOriginBasic> li_PaperOriginBasics = new List<Li_PaperOriginBasic>();

        while (reader.Read())
        {
            li_PaperOriginBasics.Add(GetLi_PaperOriginBasicFromReader(reader));
        }
        return li_PaperOriginBasics;
    }

    public Li_PaperOriginBasic GetLi_PaperOriginBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperOriginBasic li_PaperOriginBasic = new Li_PaperOriginBasic
                (
                     
                    reader["ID"].ToString(),
                    reader["Origin"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                     
                );
             return li_PaperOriginBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperOriginBasic GetLi_PaperOriginBasicByID(int li_PaperOriginBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperOriginBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperOriginBasicID", SqlDbType.Int).Value = li_PaperOriginBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperOriginBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PaperOriginBasic(Li_PaperOriginBasic li_PaperOriginBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperOriginBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Origin", SqlDbType.VarChar).Value = li_PaperOriginBasic.Origin;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperOriginBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperOriginBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PaperOriginBasic(Li_PaperOriginBasic li_PaperOriginBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperOriginBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PaperOriginBasic.ID;
            cmd.Parameters.Add("@Origin", SqlDbType.VarChar).Value = li_PaperOriginBasic.Origin;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperOriginBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperOriginBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
