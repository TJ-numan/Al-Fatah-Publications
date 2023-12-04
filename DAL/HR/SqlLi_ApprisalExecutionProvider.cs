using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_ApprisalExecutionProvider:DataAccessObject
{
	public SqlLi_ApprisalExecutionProvider()
    {
    }


    public bool DeleteLi_ApprisalExecution(int li_ApprisalExecutionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_ApprisalExecution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AppExHId", SqlDbType.Int).Value = li_ApprisalExecutionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ApprisalExecution> GetAllLi_ApprisalExecutions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_ApprisalExecutions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ApprisalExecutionsFromReader(reader);
        }
    }
    public List<Li_ApprisalExecution> GetLi_ApprisalExecutionsFromReader(IDataReader reader)
    {
        List<Li_ApprisalExecution> li_ApprisalExecutions = new List<Li_ApprisalExecution>();

        while (reader.Read())
        {
            li_ApprisalExecutions.Add(GetLi_ApprisalExecutionFromReader(reader));
        }
        return li_ApprisalExecutions;
    }

    public Li_ApprisalExecution GetLi_ApprisalExecutionFromReader(IDataReader reader)
    {
        try
        {
            Li_ApprisalExecution li_ApprisalExecution = new Li_ApprisalExecution
                (
                    
                    (int)reader["AppExHId"],
                    reader["ExHName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_ApprisalExecution;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ApprisalExecution GetLi_ApprisalExecutionByID(int li_ApprisalExecutionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_ApprisalExecutionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AppExHId", SqlDbType.Int).Value = li_ApprisalExecutionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ApprisalExecutionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ApprisalExecution(Li_ApprisalExecution li_ApprisalExecution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_ApprisalExecution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@AppExHId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ExHName", SqlDbType.VarChar).Value = li_ApprisalExecution.ExHName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ApprisalExecution.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ApprisalExecution.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ApprisalExecution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ApprisalExecution.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ApprisalExecution.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AppExHId"].Value;
        }
    }

    public bool UpdateLi_ApprisalExecution(Li_ApprisalExecution li_ApprisalExecution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_ApprisalExecution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@AppExHId", SqlDbType.Int).Value = li_ApprisalExecution.AppExHId;
            cmd.Parameters.Add("@ExHName", SqlDbType.VarChar).Value = li_ApprisalExecution.ExHName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ApprisalExecution.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ApprisalExecution.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ApprisalExecution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ApprisalExecution.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ApprisalExecution.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
