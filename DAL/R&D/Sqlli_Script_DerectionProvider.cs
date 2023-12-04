using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
using System.Xml.Linq;
using DAL;

public class SqlLi_Script_DerectionProvider:DataAccessObject
{
	public SqlLi_Script_DerectionProvider()
    {
    }


    public bool DeleteLi_Script_Derection(int li_Script_DerectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_Script_Derection", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_Script_DerectionID", SqlDbType.Int).Value = li_Script_DerectionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Script_Derection> GetAllLi_Script_Derections()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_Script_Derections", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_Script_DerectionsFromReader(reader);
        }
    }
    public List<Li_Script_Derection> GetLi_Script_DerectionsFromReader(IDataReader reader)
    {
        List<Li_Script_Derection> li_Script_Derections = new List<Li_Script_Derection>();

        while (reader.Read())
        {
            li_Script_Derections.Add(GetLi_Script_DerectionFromReader(reader));
        }
        return li_Script_Derections;
    }

    public Li_Script_Derection GetLi_Script_DerectionFromReader(IDataReader reader)
    {
        try
        {
            Li_Script_Derection li_Script_Derection = new Li_Script_Derection
                (
                    (int)reader["SerialNo"],
                    reader["BookCode"].ToString(),
                    reader["Edition"].ToString(),
                    (int)reader["SlNo"],
                    reader["Dir_Text"].ToString(),
                    (DateTime)reader["CreatedDate"],
                    (int)reader["CreatedBy"],
                    (char)reader["Status_D"] 
                );
             return li_Script_Derection;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Script_Derection GetLi_Script_DerectionByID(int li_Script_DerectionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_Script_DerectionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_Script_DerectionID", SqlDbType.Int).Value = li_Script_DerectionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_Script_DerectionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Script_Derection(Li_Script_Derection li_Script_Derection)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_Script_Derection", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = li_Script_Derection.SerialNo;      

            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_Script_Derection.SlNo;
            cmd.Parameters.Add("@Dir_Text", SqlDbType.VarChar).Value = li_Script_Derection.Dir_Text;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Script_Derection.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Script_Derection.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Script_Derection.Status_D;
        
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return 1;// (int)cmd.Parameters["@Li_Script_DerectionID"].Value;
        }
    }

    public bool UpdateLi_Script_Derection(Li_Script_Derection li_Script_Derection)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_Script_Derection", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@BookCode", SqlDbType.VarChar).Value = li_Script_Derection.BookCode;
            cmd.Parameters.Add("@Edition", SqlDbType.VarChar).Value = li_Script_Derection.Edition;
            cmd.Parameters.Add("@SlNo", SqlDbType.Int).Value = li_Script_Derection.SlNo;
            cmd.Parameters.Add("@Dir_Text", SqlDbType.VarChar).Value = li_Script_Derection.Dir_Text;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Script_Derection.CreatedDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Script_Derection.CreatedBy;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_Script_Derection.Status_D;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
