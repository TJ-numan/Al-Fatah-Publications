using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PromotionalItemBasicProvider:DataAccessObject
{
	public SqlLi_PromotionalItemBasicProvider()
    {
    }


    public bool DeleteLi_PromotionalItemBasic(int li_PromotionalItemBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PromotionalItemBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PromotionalItemBasicID", SqlDbType.Int).Value = li_PromotionalItemBasicID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PromotionalItemBasic> GetAllLi_PromotionalItemBasics()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PromotionalItemBasics", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PromotionalItemBasicsFromReader(reader);
        }
    }
    public List<Li_PromotionalItemBasic> GetLi_PromotionalItemBasicsFromReader(IDataReader reader)
    {
        List<Li_PromotionalItemBasic> li_PromotionalItemBasics = new List<Li_PromotionalItemBasic>();

        while (reader.Read())
        {
            li_PromotionalItemBasics.Add(GetLi_PromotionalItemBasicFromReader(reader));
        }
        return li_PromotionalItemBasics;
    }

    public Li_PromotionalItemBasic GetLi_PromotionalItemBasicFromReader(IDataReader reader)
    {
        try
        {
            Li_PromotionalItemBasic li_PromotionalItemBasic = new Li_PromotionalItemBasic
                (
                    
                    reader["ID"].ToString(),
                    reader["Name"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]  
                    
                );
             return li_PromotionalItemBasic;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PromotionalItemBasic GetLi_PromotionalItemBasicByID(int li_PromotionalItemBasicID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PromotionalItemBasicByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PromotionalItemBasicID", SqlDbType.Int).Value = li_PromotionalItemBasicID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PromotionalItemBasicFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_PromotionalItemBasic(Li_PromotionalItemBasic li_PromotionalItemBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PromotionalItemBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
           // cmd.Parameters.Add("@ID", SqlDbType.VarChar,50). Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@ID", SqlDbType.VarChar ).Value  =  "PC001";
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PromotionalItemBasic.Name;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PromotionalItemBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PromotionalItemBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_PromotionalItemBasic(Li_PromotionalItemBasic li_PromotionalItemBasic)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PromotionalItemBasic", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_PromotionalItemBasic.ID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = li_PromotionalItemBasic.Name;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PromotionalItemBasic.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PromotionalItemBasic.CreatedDate;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
