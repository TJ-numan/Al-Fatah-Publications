using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpLeaveStatusProvider:DataAccessObject
{
	public SqlLi_EmpLeaveStatusProvider()
    {
    }


    public bool DeleteLi_EmpLeaveStatus(int li_EmpLeaveStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpLeaveStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpLeEnId", SqlDbType.Int).Value = li_EmpLeaveStatusID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpLeaveStatus> GetAllLi_EmpLeaveStatuss()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpLeaveStatuss", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpLeaveStatussFromReader(reader);
        }
    }
    public List<Li_EmpLeaveStatus> GetLi_EmpLeaveStatussFromReader(IDataReader reader)
    {
        List<Li_EmpLeaveStatus> li_EmpLeaveStatuss = new List<Li_EmpLeaveStatus>();

        while (reader.Read())
        {
            li_EmpLeaveStatuss.Add(GetLi_EmpLeaveStatusFromReader(reader));
        }
        return li_EmpLeaveStatuss;
    }

    public Li_EmpLeaveStatus GetLi_EmpLeaveStatusFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpLeaveStatus li_EmpLeaveStatus = new Li_EmpLeaveStatus
                (
                    
                    (int)reader["EmpLeEnId"],
                    (int)reader["EmpSl"],
                    (int)reader["PerId"],
                    (int)reader["LeTypId"],
                    (decimal)reader["Alotment"],
                    (decimal)reader["LeaveTaken"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpLeaveStatus;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpLeaveStatus GetLi_EmpLeaveStatusByID(int li_EmpLeaveStatusID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpLeaveStatusByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EmpLeEnId", SqlDbType.Int).Value = li_EmpLeaveStatusID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpLeaveStatusFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpLeaveStatus(Li_EmpLeaveStatus li_EmpLeaveStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpLeaveStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@EmpLeEnId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpLeaveStatus.EmpSl;
            cmd.Parameters.Add("@PerId", SqlDbType.Int).Value = li_EmpLeaveStatus.PerId;
            cmd.Parameters.Add("@LeTypId", SqlDbType.Int).Value = li_EmpLeaveStatus.LeTypId;
            cmd.Parameters.Add("@Alotment", SqlDbType.Decimal).Value = li_EmpLeaveStatus.Alotment;
            cmd.Parameters.Add("@LeaveTaken", SqlDbType.Decimal).Value = li_EmpLeaveStatus.LeaveTaken;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpLeaveStatus.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpLeaveStatus.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpLeaveStatus.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpLeaveStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpLeaveStatus.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpLeaveStatus.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@EmpLeEnId"].Value;
        }
    }

    public bool UpdateLi_EmpLeaveStatus(Li_EmpLeaveStatus li_EmpLeaveStatus)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpLeaveStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@EmpLeEnId", SqlDbType.Int).Value = li_EmpLeaveStatus.EmpLeEnId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_EmpLeaveStatus.EmpSl;
            cmd.Parameters.Add("@PerId", SqlDbType.Int).Value = li_EmpLeaveStatus.PerId;
            cmd.Parameters.Add("@LeTypId", SqlDbType.Int).Value = li_EmpLeaveStatus.LeTypId;
            cmd.Parameters.Add("@Alotment", SqlDbType.Decimal).Value = li_EmpLeaveStatus.Alotment;
            cmd.Parameters.Add("@LeaveTaken", SqlDbType.Decimal).Value = li_EmpLeaveStatus.LeaveTaken;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpLeaveStatus.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpLeaveStatus.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpLeaveStatus.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpLeaveStatus.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpLeaveStatus.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpLeaveStatus.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
