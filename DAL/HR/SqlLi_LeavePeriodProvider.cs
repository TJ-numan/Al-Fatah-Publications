using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_LeavePeriodProvider:DataAccessObject
{
	public SqlLi_LeavePeriodProvider()
    {
    }


    public bool DeleteLi_LeavePeriod(int li_LeavePeriodID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_LeavePeriod", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PerId", SqlDbType.Int).Value = li_LeavePeriodID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeavePeriod> GetAllLi_LeavePeriods()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_LeavePeriods", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeavePeriodsFromReader(reader);
        }
    }
    public List<Li_LeavePeriod> GetLi_LeavePeriodsFromReader(IDataReader reader)
    {
        List<Li_LeavePeriod> li_LeavePeriods = new List<Li_LeavePeriod>();

        while (reader.Read())
        {
            li_LeavePeriods.Add(GetLi_LeavePeriodFromReader(reader));
        }
        return li_LeavePeriods;
    }

    public Li_LeavePeriod GetLi_LeavePeriodFromReader(IDataReader reader)
    {
        try
        {
            Li_LeavePeriod li_LeavePeriod = new Li_LeavePeriod
                (
                
                    (int)reader["PerId"],
                    reader["PerName"].ToString(),
                    (DateTime)reader["PerStDate"],
                    (DateTime)reader["PerEnDate"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_LeavePeriod;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LeavePeriod GetLi_LeavePeriodByID(int li_LeavePeriodID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_LeavePeriodByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PerId", SqlDbType.Int).Value = li_LeavePeriodID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeavePeriodFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LeavePeriod(Li_LeavePeriod li_LeavePeriod)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_LeavePeriod", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PerId", SqlDbType.Int)  .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PerName", SqlDbType.VarChar).Value = li_LeavePeriod.PerName;
            cmd.Parameters.Add("@PerStDate", SqlDbType.DateTime).Value = li_LeavePeriod.PerStDate;
            cmd.Parameters.Add("@PerEnDate", SqlDbType.DateTime).Value = li_LeavePeriod.PerEnDate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_LeavePeriod.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeavePeriod.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeavePeriod.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeavePeriod.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeavePeriod.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeavePeriod.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PerId"].Value;
        }
    }

    public bool UpdateLi_LeavePeriod(Li_LeavePeriod li_LeavePeriod)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_LeavePeriod", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PerId", SqlDbType.Int).Value = li_LeavePeriod.PerId;
            cmd.Parameters.Add("@PerName", SqlDbType.VarChar).Value = li_LeavePeriod.PerName;
            cmd.Parameters.Add("@PerStDate", SqlDbType.DateTime).Value = li_LeavePeriod.PerStDate;
            cmd.Parameters.Add("@PerEnDate", SqlDbType.DateTime).Value = li_LeavePeriod.PerEnDate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_LeavePeriod.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeavePeriod.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeavePeriod.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeavePeriod.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeavePeriod.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeavePeriod.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
