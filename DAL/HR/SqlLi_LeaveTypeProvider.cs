using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_LeaveTypeProvider:DataAccessObject
{
	public SqlLi_LeaveTypeProvider()
    {
    }


    public bool DeleteLi_LeaveType(int li_LeaveTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_LeaveType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeTypId", SqlDbType.Int).Value = li_LeaveTypeID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeaveType> GetAllLi_LeaveTypes()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_LeaveTypes", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeaveTypesFromReader(reader);
        }
    }
    public List<Li_LeaveType> GetLi_LeaveTypesFromReader(IDataReader reader)
    {
        List<Li_LeaveType> li_LeaveTypes = new List<Li_LeaveType>();

        while (reader.Read())
        {
            li_LeaveTypes.Add(GetLi_LeaveTypeFromReader(reader));
        }
        return li_LeaveTypes;
    }

    public Li_LeaveType GetLi_LeaveTypeFromReader(IDataReader reader)
    {
        try
        {
            Li_LeaveType li_LeaveType = new Li_LeaveType
                (
                   
                    (int)reader["LeTypId"],
                    reader["LeTyName"].ToString(),
                    (decimal)reader["DayCount"],
                    (bool)reader["BalForword"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_LeaveType;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LeaveType GetLi_LeaveTypeByID(int li_LeaveTypeID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_LeaveTypeByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LeTypId", SqlDbType.Int).Value = li_LeaveTypeID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeaveTypeFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LeaveType(Li_LeaveType li_LeaveType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_LeaveType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@LeTypId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LeTyName", SqlDbType.VarChar).Value = li_LeaveType.LeTyName;
            cmd.Parameters.Add("@DayCount", SqlDbType.Decimal).Value = li_LeaveType.DayCount;
            cmd.Parameters.Add("@BalForword", SqlDbType.Bit).Value = li_LeaveType.BalForword;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeaveType.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeaveType.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeaveType.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeaveType.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeaveType.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LeTypId"].Value;
        }
    }

    public bool UpdateLi_LeaveType(Li_LeaveType li_LeaveType)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_LeaveType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@LeTypId", SqlDbType.Int).Value = li_LeaveType.LeTypId;
            cmd.Parameters.Add("@LeTyName", SqlDbType.VarChar).Value = li_LeaveType.LeTyName;
            cmd.Parameters.Add("@DayCount", SqlDbType.Decimal).Value = li_LeaveType.DayCount;
            cmd.Parameters.Add("@BalForword", SqlDbType.Bit).Value = li_LeaveType.BalForword;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeaveType.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeaveType.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeaveType.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeaveType.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeaveType.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
