using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_EduResultProvider:DataAccessObject
{
	public SqlLi_EduResultProvider()
    {
    }


    public bool DeleteLi_EduResult(int li_EduResultID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EduResult", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EduReId", SqlDbType.Int).Value = li_EduResultID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EduResult> GetAllLi_EduResults()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EduResults", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EduResultsFromReader(reader);
        }
    }
    public List<Li_EduResult> GetLi_EduResultsFromReader(IDataReader reader)
    {
        List<Li_EduResult> li_EduResults = new List<Li_EduResult>();

        while (reader.Read())
        {
            li_EduResults.Add(GetLi_EduResultFromReader(reader));
        }
        return li_EduResults;
    }

    public Li_EduResult GetLi_EduResultFromReader(IDataReader reader)
    {
        try
        {
            Li_EduResult li_EduResult = new Li_EduResult
                (
                  
                    (int)reader["EduReId"],
                    reader["EduReName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EduResult;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EduResult GetLi_EduResultByID(int li_EduResultID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EduResultByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EduReId", SqlDbType.Int).Value = li_EduResultID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EduResultFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EduResult(Li_EduResult li_EduResult)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EduResult", connection);
            cmd.CommandType = CommandType.StoredProcedure;
          
            cmd.Parameters.Add("@EduReId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EduReName", SqlDbType.VarChar).Value = li_EduResult.EduReName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EduResult.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EduResult.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EduResult.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EduResult.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EduResult.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EduReId"].Value;
        }
    }

    public bool UpdateLi_EduResult(Li_EduResult li_EduResult)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EduResult", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@EduReId", SqlDbType.Int).Value = li_EduResult.EduReId;
            cmd.Parameters.Add("@EduReName", SqlDbType.VarChar).Value = li_EduResult.EduReName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EduResult.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EduResult.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EduResult.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
