using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_ApprisalResultProvider:DataAccessObject
{
	public SqlLi_ApprisalResultProvider()
    {
    }


    public bool DeleteLi_ApprisalResult(int li_ApprisalResultID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_ApprisalResult", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AppExId", SqlDbType.Int).Value = li_ApprisalResultID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ApprisalResult> GetAllLi_ApprisalResults()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_ApprisalResults", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ApprisalResultsFromReader(reader);
        }
    }
    public List<Li_ApprisalResult> GetLi_ApprisalResultsFromReader(IDataReader reader)
    {
        List<Li_ApprisalResult> li_ApprisalResults = new List<Li_ApprisalResult>();

        while (reader.Read())
        {
            li_ApprisalResults.Add(GetLi_ApprisalResultFromReader(reader));
        }
        return li_ApprisalResults;
    }

    public Li_ApprisalResult GetLi_ApprisalResultFromReader(IDataReader reader)
    {
        try
        {
            Li_ApprisalResult li_ApprisalResult = new Li_ApprisalResult
                (
               
                    (int)reader["AppExId"],
                    (int)reader["EmpSl"],
                    (int)reader["AppId"],
                    (int)reader["AppExHId"],
                    (bool)reader["IsApproved"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_ApprisalResult;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ApprisalResult GetLi_ApprisalResultByID(int li_ApprisalResultID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_ApprisalResultByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@AppExId", SqlDbType.Int).Value = li_ApprisalResultID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ApprisalResultFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ApprisalResult(Li_ApprisalResult li_ApprisalResult)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_ApprisalResult", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@AppExId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_ApprisalResult.EmpSl;
            cmd.Parameters.Add("@AppId", SqlDbType.Int).Value = li_ApprisalResult.AppId;
            cmd.Parameters.Add("@AppExHId", SqlDbType.Int).Value = li_ApprisalResult.AppExHId;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = li_ApprisalResult.IsApproved;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_ApprisalResult.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ApprisalResult.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ApprisalResult.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ApprisalResult.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ApprisalResult.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ApprisalResult.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@AppExId"].Value;
        }
    }

    public bool UpdateLi_ApprisalResult(Li_ApprisalResult li_ApprisalResult)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_ApprisalResult", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@AppExId", SqlDbType.Int).Value = li_ApprisalResult.AppExId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_ApprisalResult.EmpSl;
            cmd.Parameters.Add("@AppId", SqlDbType.Int).Value = li_ApprisalResult.AppId;
            cmd.Parameters.Add("@AppExHId", SqlDbType.Int).Value = li_ApprisalResult.AppExHId;
            cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = li_ApprisalResult.IsApproved;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_ApprisalResult.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ApprisalResult.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ApprisalResult.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ApprisalResult.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ApprisalResult.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ApprisalResult.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
