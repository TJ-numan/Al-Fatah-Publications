using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web; 
using System.Xml.Linq;
using DAL;

public class SqlLi_TranferReturnToMainProvider:DataAccessObject
{
	public SqlLi_TranferReturnToMainProvider()
    {
    }


    public bool DeleteLi_TranferReturnToMain(int li_TranferReturnToMainID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_DeleteLi_TranferReturnToMain", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_TranferReturnToMainID", SqlDbType.Int).Value = li_TranferReturnToMainID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_TranferReturnToMain> GetAllLi_TranferReturnToMains()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetAllLi_TranferReturnToMains", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_TranferReturnToMainsFromReader(reader);
        }
    }
    public List<Li_TranferReturnToMain> GetLi_TranferReturnToMainsFromReader(IDataReader reader)
    {
        List<Li_TranferReturnToMain> li_TranferReturnToMains = new List<Li_TranferReturnToMain>();

        while (reader.Read())
        {
            li_TranferReturnToMains.Add(GetLi_TranferReturnToMainFromReader(reader));
        }
        return li_TranferReturnToMains;
    }

    public Li_TranferReturnToMain GetLi_TranferReturnToMainFromReader(IDataReader reader)
    {
        try
        {
            Li_TranferReturnToMain li_TranferReturnToMain = new Li_TranferReturnToMain
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
             return li_TranferReturnToMain;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_TranferReturnToMain GetLi_TranferReturnToMainByID(int li_TranferReturnToMainID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("SMPM_GetLi_TranferReturnToMainByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_TranferReturnToMainID", SqlDbType.Int).Value = li_TranferReturnToMainID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_TranferReturnToMainFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public string  InsertLi_TranferReturnToMain(Li_TranferReturnToMain li_TranferReturnToMain)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_InsertLi_TranferReturnToMain", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@ID", SqlDbType.VarChar,50).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_TranferReturnToMain.MemoNo;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_TranferReturnToMain.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_TranferReturnToMain.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_TranferReturnToMain.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TranferReturnToMain.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TranferReturnToMain.Status_D;
            cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = li_TranferReturnToMain.Delete_Cause;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_TranferReturnToMain.DeleteBy;
            cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value = li_TranferReturnToMain.DateOfDelete;
 
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (string )cmd.Parameters["@ID"].Value;
        }
    }

    public bool UpdateLi_TranferReturnToMain(Li_TranferReturnToMain li_TranferReturnToMain)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("SMPM_UpdateLi_TranferReturnToMain", connection);
            cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = li_TranferReturnToMain.ID;
            cmd.Parameters.Add("@MemoNo", SqlDbType.Int).Value = li_TranferReturnToMain.MemoNo;
            cmd.Parameters.Add("@AmountTotal", SqlDbType.Decimal).Value = li_TranferReturnToMain.AmountTotal;
            cmd.Parameters.Add("@Createdby", SqlDbType.Int).Value = li_TranferReturnToMain.Createdby;
            cmd.Parameters.Add("@TransferDate", SqlDbType.DateTime).Value = li_TranferReturnToMain.TransferDate;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_TranferReturnToMain.CreatedDate;
            cmd.Parameters.Add("@Status_D", SqlDbType.Char).Value = li_TranferReturnToMain.Status_D;
            cmd.Parameters.Add("@Delete_Cause", SqlDbType.VarChar).Value = li_TranferReturnToMain.Delete_Cause;
            cmd.Parameters.Add("@DeleteBy", SqlDbType.Int).Value = li_TranferReturnToMain.DeleteBy;
            cmd.Parameters.Add("@DateOfDelete", SqlDbType.DateTime).Value = li_TranferReturnToMain.DateOfDelete;
             connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
