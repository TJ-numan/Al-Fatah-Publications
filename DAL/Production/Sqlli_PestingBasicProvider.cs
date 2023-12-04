using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PestingBasicProvider:DataAccessObject
{
	public SqlLi_PestingBasicProvider()
    {
    }


    public bool DeleteLi_PestingBasic(int li_PestingBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PestingBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PestingBasicID", SqlDbType.Int).Value = li_PestingBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PestingBasic> GetAllLi_PestingBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PestingBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PestingBasicsFromReader(reader);
        }
    }
    public List<Li_PestingBasic> GetLi_PestingBasicsFromReader(IDataReader reader)
    {
        List<Li_PestingBasic> li_PestingBasics = new List<Li_PestingBasic>();

        while (reader.Read())
        {
            li_PestingBasics.Add(GetLi_PestingBasicFromReader(reader));
        }
        return li_PestingBasics;
    }

    public Li_PestingBasic GetLi_PestingBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PestingBasic li_PestingBasic = new Li_PestingBasic
                (
                    
                    reader["ID"].ToString(),
                    reader["Type"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                    
                );
             return li_PestingBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PestingBasic GetLi_PestingBasicByID(int li_PestingBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PestingBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PestingBasicID", SqlDbType.Int).Value = li_PestingBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PestingBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PestingBasic(Li_PestingBasic li_PestingBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PestingBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = li_PestingBasic.Type;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PestingBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PestingBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PestingBasic(Li_PestingBasic li_PestingBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PestingBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PestingBasic.ID;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = li_PestingBasic.Type;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PestingBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PestingBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
