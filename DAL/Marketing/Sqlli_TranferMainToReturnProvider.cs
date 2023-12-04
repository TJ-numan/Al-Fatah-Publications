using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_TranferMainToReturnProvider:DataAccessObject
{
	public SqlLi_TranferMainToReturnProvider()
    {
    }


    public bool DeleteLi_TranferMainToReturn(int li_TranferMainToReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_TranferMainToReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TranferMainToReturnID", SqlDbType.Int).Value = li_TranferMainToReturnID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TranferMainToReturn> GetAllLi_TranferMainToReturns()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TranferMainToReturns", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TranferMainToReturnsFromReader(reader);
        }
    }
    public List<Li_TranferMainToReturn> GetLi_TranferMainToReturnsFromReader(IDataReader reader)
    {
        List<Li_TranferMainToReturn> li_TranferMainToReturns = new List<Li_TranferMainToReturn>();

        while (reader.Read())
        {
            li_TranferMainToReturns.Add(GetLi_TranferMainToReturnFromReader(reader));
        }
        return li_TranferMainToReturns;
    }

    public Li_TranferMainToReturn GetLi_TranferMainToReturnFromReader(IDataReader reader)
    {
        try
        {
            Li_TranferMainToReturn li_TranferMainToReturn = new Li_TranferMainToReturn
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
             return li_TranferMainToReturn;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TranferMainToReturn GetLi_TranferMainToReturnByID(int li_TranferMainToReturnID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TranferMainToReturnByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TranferMainToReturnID", SqlDbType.Int).Value = li_TranferMainToReturnID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TranferMainToReturnFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_TranferMainToReturn(Li_TranferMainToReturn li_TranferMainToReturn)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_TranferMainToReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_TranferMainToReturn.MemoNo;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_TranferMainToReturn.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_TranferMainToReturn.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_TranferMainToReturn.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TranferMainToReturn.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TranferMainToReturn.Status_D;
            cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = DBNull.Value;// li_TranferMainToReturn.Delete_Cause;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value =DBNull.Value;// li_TranferMainToReturn.DeleteBy;
            cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value = DBNull.Value;//li_TranferMainToReturn.DateOfDelete;
             connection.Open();

            int result = cmd.ExecuteNonQuery();

            return  cmd.Parameters["@ID"].Value.ToString ();
        }
    }

    public bool UpdateLi_TranferMainToReturn(Li_TranferMainToReturn li_TranferMainToReturn)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_TranferMainToReturn", connection);
            cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_TranferMainToReturn.ID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_TranferMainToReturn.MemoNo;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_TranferMainToReturn.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_TranferMainToReturn.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_TranferMainToReturn.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TranferMainToReturn.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TranferMainToReturn.Status_D;
            cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = li_TranferMainToReturn.Delete_Cause;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_TranferMainToReturn.DeleteBy;
            cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value = li_TranferMainToReturn.DateOfDelete;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
