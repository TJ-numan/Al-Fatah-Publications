using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmploymentStatusProvider:DataAccessObject
{
	public SqlLi_EmploymentStatusProvider()
    {
    }


    public bool DeleteLi_EmploymentStatus(int li_EmploymentStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmploymentStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_EmploymentStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmploymentStatus> GetAllLi_EmploymentStatuss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmploymentStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmploymentStatussFromReader(reader);
        }
    }
    public List<Li_EmploymentStatus> GetLi_EmploymentStatussFromReader(IDataReader reader)
    {
        List<Li_EmploymentStatus> li_EmploymentStatuss = new List<Li_EmploymentStatus>();

        while (reader.Read())
        {
            li_EmploymentStatuss.Add(GetLi_EmploymentStatusFromReader(reader));
        }
        return li_EmploymentStatuss;
    }

    public Li_EmploymentStatus GetLi_EmploymentStatusFromReader(IDataReader reader)
    {
        try
        {
            Li_EmploymentStatus li_EmploymentStatus = new Li_EmploymentStatus
                (
                  
                    (int)reader["EmploymentStId"],
                    reader["EmploymentStName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmploymentStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmploymentStatus GetLi_EmploymentStatusByID(int li_EmploymentStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmploymentStatusByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_EmploymentStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmploymentStatusFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmploymentStatus(Li_EmploymentStatus li_EmploymentStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmploymentStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmploymentStName", SqlDbType.VarChar).Value = li_EmploymentStatus.EmploymentStName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmploymentStatus.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmploymentStatus.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmploymentStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmploymentStatus.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmploymentStatus.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmploymentStId"].Value;
        }
    }

    public bool UpdateLi_EmploymentStatus(Li_EmploymentStatus li_EmploymentStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmploymentStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@EmploymentStId", SqlDbType.Int).Value = li_EmploymentStatus.EmploymentStId;
            cmd.Parameters.Add("@EmploymentStName", SqlDbType.VarChar).Value = li_EmploymentStatus.EmploymentStName; 
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmploymentStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmploymentStatus.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmploymentStatus.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
