using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_SendForDamageProvider:DataAccessObject
{
	public SqlLi_SendForDamageProvider()
    {
    }


    public bool DeleteLi_SendForDamage(int li_SendForDamageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SendForDamage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SendForDamageID", SqlDbType.Int).Value = li_SendForDamageID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SendForDamage> GetAllLi_SendForDamages()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SendForDamages", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SendForDamagesFromReader(reader);
        }
    }
    public List<Li_SendForDamage> GetLi_SendForDamagesFromReader(IDataReader reader)
    {
        List<Li_SendForDamage> li_SendForDamages = new List<Li_SendForDamage>();

        while (reader.Read())
        {
            li_SendForDamages.Add(GetLi_SendForDamageFromReader(reader));
        }
        return li_SendForDamages;
    }

    public Li_SendForDamage GetLi_SendForDamageFromReader(IDataReader reader)
    {
        try
        {
            Li_SendForDamage li_SendForDamage = new Li_SendForDamage
                (
                    
                    reader["ID"].ToString(),
                    (int)reader["MemoNo"],
                    (decimal)reader["AmountTotal"],
                    (int)reader["Createdby"],
                    (DateTime)reader["TransferDate"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Status_D"],
                    reader["Delete_Cause"].ToString(),
                    (int)reader["DeleteBy"],
                    (DateTime)reader["DateOfDelete"] 

                );
             return li_SendForDamage;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SendForDamage GetLi_SendForDamageByID(int li_SendForDamageID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SendForDamageByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_SendForDamageID", SqlDbType.Int).Value = li_SendForDamageID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SendForDamageFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_SendForDamage(Li_SendForDamage li_SendForDamage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SendForDamage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_SendForDamage.MemoNo;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_SendForDamage.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_SendForDamage.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_SendForDamage.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SendForDamage.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_SendForDamage.Status_D;
            cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = DBNull.Value;// li_SendForDamage.Delete_Cause;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value =DBNull.Value;// li_SendForDamage.DeleteBy;
            cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value =DBNull.Value;// li_SendForDamage.DateOfDelete;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_SendForDamage(Li_SendForDamage li_SendForDamage)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SendForDamage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_SendForDamage.ID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_SendForDamage.MemoNo;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_SendForDamage.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_SendForDamage.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_SendForDamage.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SendForDamage.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_SendForDamage.Status_D;
            cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = li_SendForDamage.Delete_Cause;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_SendForDamage.DeleteBy;
            cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value = li_SendForDamage.DateOfDelete;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
