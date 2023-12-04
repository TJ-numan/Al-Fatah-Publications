using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_SendForRebindProvider:DataAccessObject
{
	public SqlLi_SendForRebindProvider()
    {
    }


    public bool DeleteLi_SendForRebind(int li_SendForRebindID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_SendForRebind", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_SendForRebindID", SqlDbType.Int).Value = li_SendForRebindID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_SendForRebind> GetAllLi_SendForRebinds()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_SendForRebinds", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SendForRebindsFromReader(reader);
        }
    }
    public List<Li_SendForRebind> GetLi_SendForRebindsFromReader(IDataReader reader)
    {
        List<Li_SendForRebind> li_SendForRebinds = new List<Li_SendForRebind>();

        while (reader.Read())
        {
            li_SendForRebinds.Add(GetLi_SendForRebindFromReader(reader));
        }
        return li_SendForRebinds;
    }

    public Li_SendForRebind GetLi_SendForRebindFromReader(IDataReader reader)
    {
        try
        {
            Li_SendForRebind li_SendForRebind = new Li_SendForRebind
                (
                    
                    reader["ID"].ToString(),
                    (int)reader["MemoNo"],
                    reader["BinderID"].ToString(),
                    (decimal)reader["AmountTotal"],
                    (int)reader["Createdby"],
                    (DateTime)reader["TransferDate"],
                    (DateTime)reader["CreatedDate"],
                    (char)reader["Status_D"],
                    reader["Delete_Cause"].ToString(),
                    (int)reader["DeleteBy"],
                    (DateTime)reader["DateOfDelete"] 
                );
             return li_SendForRebind;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_SendForRebind GetLi_SendForRebindByID(int li_SendForRebindID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_SendForRebindByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_SendForRebindID", SqlDbType.Int).Value = li_SendForRebindID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SendForRebindFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_SendForRebind(Li_SendForRebind li_SendForRebind)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_SendForRebind", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_SendForRebind.MemoNo;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_SendForRebind.BinderID;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_SendForRebind.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_SendForRebind.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_SendForRebind.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value =  li_SendForRebind.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = 'C' ;// li_SendForRebind.Status_D;
            cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = DBNull .Value ;// li_SendForRebind.Delete_Cause;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = DBNull .Value ;// li_SendForRebind.DeleteBy;
            cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value = DBNull .Value ;//li_SendForRebind.DateOfDelete;

            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return cmd.Parameters["@ID"].Value.ToString(); 
        }
    }

    public bool UpdateLi_SendForRebind(Li_SendForRebind li_SendForRebind)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_SendForRebind", connection);
            cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_SendForRebind.ID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_SendForRebind.MemoNo;
            cmd.Parameters.Add("@BinderID", SqlDbType.VarChar).Value = li_SendForRebind.BinderID;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_SendForRebind.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_SendForRebind.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_SendForRebind.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_SendForRebind.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_SendForRebind.Status_D;
            cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = li_SendForRebind.Delete_Cause;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_SendForRebind.DeleteBy;
            cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value = li_SendForRebind.DateOfDelete;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
