using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_LaminationTypeBasicProvider:DataAccessObject
{
	public SqlLi_LaminationTypeBasicProvider()
    {
    }


    public bool DeleteLi_LaminationTypeBasic(int li_LaminationTypeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_LaminationTypeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_LaminationTypeBasicID", SqlDbType.Int).Value = li_LaminationTypeBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LaminationTypeBasic> GetAllLi_LaminationTypeBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_LaminationTypeBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LaminationTypeBasicsFromReader(reader);
        }
    }
    public List<Li_LaminationTypeBasic> GetLi_LaminationTypeBasicsFromReader(IDataReader reader)
    {
        List<Li_LaminationTypeBasic> li_LaminationTypeBasics = new List<Li_LaminationTypeBasic>();

        while (reader.Read())
        {
            li_LaminationTypeBasics.Add(GetLi_LaminationTypeBasicFromReader(reader));
        }
        return li_LaminationTypeBasics;
    }

    public Li_LaminationTypeBasic GetLi_LaminationTypeBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_LaminationTypeBasic li_LaminationTypeBasic = new Li_LaminationTypeBasic
                (
                     
                    reader["ID"].ToString(),
                    reader["Type"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                     
                );
             return li_LaminationTypeBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LaminationTypeBasic GetLi_LaminationTypeBasicByID(int li_LaminationTypeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_LaminationTypeBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_LaminationTypeBasicID", SqlDbType.Int).Value = li_LaminationTypeBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LaminationTypeBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_LaminationTypeBasic(Li_LaminationTypeBasic li_LaminationTypeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_LaminationTypeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50)  .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = li_LaminationTypeBasic.Type;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LaminationTypeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LaminationTypeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_LaminationTypeBasic(Li_LaminationTypeBasic li_LaminationTypeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_LaminationTypeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_LaminationTypeBasic.ID;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = li_LaminationTypeBasic.Type;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LaminationTypeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LaminationTypeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
