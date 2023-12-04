using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using DAL;

public class SqlLi_PrintOrderBasicProvider:DataAccessObject
{
	public SqlLi_PrintOrderBasicProvider()
    {
    }


    public bool DeleteLi_PrintOrderBasic(int li_PrintOrderBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PrintOrderBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PrintOrderBasicID", SqlDbType.Int).Value = li_PrintOrderBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PrintOrderBasic> GetAllLi_PrintOrderBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PrintOrderBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PrintOrderBasicsFromReader(reader);
        }
    }
    public List<Li_PrintOrderBasic> GetLi_PrintOrderBasicsFromReader(IDataReader reader)
    {
        List<Li_PrintOrderBasic> li_PrintOrderBasics = new List<Li_PrintOrderBasic>();

        while (reader.Read())
        {
            li_PrintOrderBasics.Add(GetLi_PrintOrderBasicFromReader(reader));
        }
        return li_PrintOrderBasics;
    }

    public Li_PrintOrderBasic GetLi_PrintOrderBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PrintOrderBasic li_PrintOrderBasic = new Li_PrintOrderBasic
                (
                   
                    (int)reader["Print_Sl"],
                    reader["Print_N"].ToString()
                );
             return li_PrintOrderBasic;
        }
        catch(Exception)
        {
            return null;
        }
    }

    public Li_PrintOrderBasic GetLi_PrintOrderBasicByID(int li_PrintOrderBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PrintOrderBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PrintOrderBasicID", SqlDbType.Int).Value = li_PrintOrderBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PrintOrderBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PrintOrderBasic(Li_PrintOrderBasic li_PrintOrderBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PrintOrderBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@Print_Sl", SqlDbType.Int).Value = li_PrintOrderBasic.Print_Sl;
            cmd.Parameters.Add("@Print_N", SqlDbType.VarChar).Value = li_PrintOrderBasic.Print_N;
           
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_PrintOrderBasicID"].Value;
        }
    }

    public bool UpdateLi_PrintOrderBasic(Li_PrintOrderBasic li_PrintOrderBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PrintOrderBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@Print_Sl", SqlDbType.Int).Value = li_PrintOrderBasic.Print_Sl;
            cmd.Parameters.Add("@Print_N", SqlDbType.VarChar).Value = li_PrintOrderBasic.Print_N;
            
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
