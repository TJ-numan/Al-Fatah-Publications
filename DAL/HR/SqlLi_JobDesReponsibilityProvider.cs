using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_JobDesReponsibilityProvider:DataAccessObject
{
	public SqlLi_JobDesReponsibilityProvider()
    {
    }


    public bool DeleteLi_JobDesReponsibility(int li_JobDesReponsibilityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_JobDesReponsibility", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@JobResId", SqlDbType.Int).Value = li_JobDesReponsibilityID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_JobDesReponsibility> GetAllLi_JobDesReponsibilities()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_JobDesReponsibilities", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_JobDesReponsibilitiesFromReader(reader);
        }
    }
    public List<Li_JobDesReponsibility> GetLi_JobDesReponsibilitiesFromReader(IDataReader reader)
    {
        List<Li_JobDesReponsibility> li_JobDesReponsibilities = new List<Li_JobDesReponsibility>();

        while (reader.Read())
        {
            li_JobDesReponsibilities.Add(GetLi_JobDesReponsibilityFromReader(reader));
        }
        return li_JobDesReponsibilities;
    }

    public Li_JobDesReponsibility GetLi_JobDesReponsibilityFromReader(IDataReader reader)
    {
        try
        {
            Li_JobDesReponsibility li_JobDesReponsibility = new Li_JobDesReponsibility
                (
                   
                    (int)reader["JobResId"],
                    reader["JobRes"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_JobDesReponsibility;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_JobDesReponsibility GetLi_JobDesReponsibilityByID(int li_JobDesReponsibilityID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_JobDesReponsibilityByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@JobResId", SqlDbType.Int).Value = li_JobDesReponsibilityID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_JobDesReponsibilityFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_JobDesReponsibility(Li_JobDesReponsibility li_JobDesReponsibility)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_JobDesReponsibility", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@JobResId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@JobRes", SqlDbType.VarChar).Value = li_JobDesReponsibility.JobRes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesReponsibility.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesReponsibility.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesReponsibility.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesReponsibility.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesReponsibility.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@JobResId"].Value;
        }
    }

    public bool UpdateLi_JobDesReponsibility(Li_JobDesReponsibility li_JobDesReponsibility)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_JobDesReponsibility", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@JobResId", SqlDbType.Int).Value = li_JobDesReponsibility.JobResId;
            cmd.Parameters.Add("@JobRes", SqlDbType.VarChar).Value = li_JobDesReponsibility.JobRes;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_JobDesReponsibility.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_JobDesReponsibility.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_JobDesReponsibility.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_JobDesReponsibility.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_JobDesReponsibility.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
