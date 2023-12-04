using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateTypeBasicProvider:DataAccessObject
{
	public SqlLi_PlateTypeBasicProvider()
    {
    }


    public bool DeleteLi_PlateTypeBasic(int li_PlateTypeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateTypeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateTypeBasicID", SqlDbType.Int).Value = li_PlateTypeBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateTypeBasic> GetAllLi_PlateTypeBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateTypeBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateTypeBasicsFromReader(reader);
        }
    }
    public List<Li_PlateTypeBasic> GetLi_PlateTypeBasicsFromReader(IDataReader reader)
    {
        List<Li_PlateTypeBasic> li_PlateTypeBasics = new List<Li_PlateTypeBasic>();

        while (reader.Read())
        {
            li_PlateTypeBasics.Add(GetLi_PlateTypeBasicFromReader(reader));
        }
        return li_PlateTypeBasics;
    }

    public Li_PlateTypeBasic GetLi_PlateTypeBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateTypeBasic li_PlateTypeBasic = new Li_PlateTypeBasic
                (
                     
                    reader["ID"].ToString(),
                    reader["Type"].ToString(),
                    (DateTime )reader["CreatedDate"] ,
                    (int)reader["CreatedBy"] 
                    
                );
             return li_PlateTypeBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateTypeBasic GetLi_PlateTypeBasicByID(int li_PlateTypeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateTypeBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateTypeBasicID", SqlDbType.Int).Value = li_PlateTypeBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateTypeBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PlateTypeBasic(Li_PlateTypeBasic li_PlateTypeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateTypeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
                                                                                                                                                                                                                                        
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50)  .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = li_PlateTypeBasic.Type;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateTypeBasic.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateTypeBasic.CreatedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PlateTypeBasic(Li_PlateTypeBasic li_PlateTypeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateTypeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PlateTypeBasic.ID;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = li_PlateTypeBasic.Type;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateTypeBasic.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateTypeBasic.CreatedBy;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
