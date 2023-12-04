using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PaperTypeBasicProvider:DataAccessObject
{
	public SqlLi_PaperTypeBasicProvider()
    {
    }


    public bool DeleteLi_PaperTypeBasic(int li_PaperTypeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PaperTypeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PaperTypeBasicID", SqlDbType.Int).Value = li_PaperTypeBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PaperTypeBasic> GetAllLi_PaperTypeBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PaperTypeBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PaperTypeBasicsFromReader(reader);
        }
    }
    public List<Li_PaperTypeBasic> GetAllLi_PaperTypeBasics_ForInnerForma(bool IsCover)
    {
        SqlCommand command = null; IDataReader reader = null;
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            if (IsCover == true)
            {
                command = new SqlCommand("SMPM_GetAllLi_PaperTypeBasics_ForCover", connection);
            }
            else
            {
                command   = new SqlCommand("SMPM_GetAllLi_PaperTypeBasics_ForInnerForma", connection);
            } 

            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            reader = command.ExecuteReader(CommandBehavior.Default);
            return GetLi_PaperTypeBasicsFromReader(reader);
        }
    }   
    
    public List<Li_PaperTypeBasic> GetLi_PaperTypeBasicsFromReader(IDataReader reader)
    {
        List<Li_PaperTypeBasic> li_PaperTypeBasics = new List<Li_PaperTypeBasic>();

        while (reader.Read())
        {
            li_PaperTypeBasics.Add(GetLi_PaperTypeBasicFromReader(reader));
        }
        return li_PaperTypeBasics;
    }

    public Li_PaperTypeBasic GetLi_PaperTypeBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PaperTypeBasic li_PaperTypeBasic = new Li_PaperTypeBasic
                (
                     
                    reader["ID"].ToString(),
                    reader["Type"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                    
                );
             return li_PaperTypeBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PaperTypeBasic GetLi_PaperTypeBasicByID(int li_PaperTypeBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PaperTypeBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PaperTypeBasicID", SqlDbType.Int).Value = li_PaperTypeBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PaperTypeBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PaperTypeBasic(Li_PaperTypeBasic li_PaperTypeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PaperTypeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = li_PaperTypeBasic.Type;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperTypeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperTypeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PaperTypeBasic(Li_PaperTypeBasic li_PaperTypeBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PaperTypeBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PaperTypeBasic.ID;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = li_PaperTypeBasic.Type;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PaperTypeBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PaperTypeBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
