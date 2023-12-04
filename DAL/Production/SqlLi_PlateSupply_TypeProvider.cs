using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_PlateSupply_TypeProvider:DataAccessObject
{
	public SqlLi_PlateSupply_TypeProvider()
    {
    }


    public bool DeleteLi_PlateSupply_Type(int li_PlateSupply_TypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_PlateSupply_Type", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_PlateSupply_TypeID", SqlDbType.Int).Value = li_PlateSupply_TypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PlateSupply_Type> GetAllLi_PlateSupply_Types()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_PlateSupply_Types", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PlateSupply_TypesFromReader(reader);
        }
    }
    public List<Li_PlateSupply_Type> GetLi_PlateSupply_TypesFromReader(IDataReader reader)
    {
        List<Li_PlateSupply_Type> li_PlateSupply_Types = new List<Li_PlateSupply_Type>();

        while (reader.Read())
        {
            li_PlateSupply_Types.Add(GetLi_PlateSupply_TypeFromReader(reader));
        }
        return li_PlateSupply_Types;
    }

    public Li_PlateSupply_Type GetLi_PlateSupply_TypeFromReader(IDataReader reader)
    {
        try
        {
            Li_PlateSupply_Type li_PlateSupply_Type = new Li_PlateSupply_Type
                (
                    
                    (int)reader["ID"],
                    reader["Sup_Type"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"] 
                     
                );
             return li_PlateSupply_Type;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PlateSupply_Type GetLi_PlateSupply_TypeByID(int li_PlateSupply_TypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_PlateSupply_TypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_PlateSupply_TypeID", SqlDbType.Int).Value = li_PlateSupply_TypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PlateSupply_TypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PlateSupply_Type(Li_PlateSupply_Type li_PlateSupply_Type)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_PlateSupply_Type", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_PlateSupply_Type.ID;
            cmd.Parameters.Add("@Sup_Type", SqlDbType.VarChar).Value = li_PlateSupply_Type.Sup_Type;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateSupply_Type.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateSupply_Type.CreatedDate;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@Li_PlateSupply_TypeID"].Value;
        }
    }

    public bool UpdateLi_PlateSupply_Type(Li_PlateSupply_Type li_PlateSupply_Type)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_PlateSupply_Type", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = li_PlateSupply_Type.ID;
            cmd.Parameters.Add("@Sup_Type", SqlDbType.VarChar).Value = li_PlateSupply_Type.Sup_Type;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PlateSupply_Type.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PlateSupply_Type.CreatedDate;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
