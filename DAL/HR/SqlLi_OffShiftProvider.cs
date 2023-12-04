using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_OffShiftProvider:DataAccessObject
{
	public SqlLi_OffShiftProvider()
    {
    }


    public bool DeleteLi_OffShift(int li_OffShiftID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_OffShift", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_OffShiftID", SqlDbType.Int).Value = li_OffShiftID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_OffShift> GetAllLi_OffShifts()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_OffShifts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_OffShiftsFromReader(reader);
        }
    }
    public List<Li_OffShift> GetLi_OffShiftsFromReader(IDataReader reader)
    {
        List<Li_OffShift> li_OffShifts = new List<Li_OffShift>();

        while (reader.Read())
        {
            li_OffShifts.Add(GetLi_OffShiftFromReader(reader));
        }
        return li_OffShifts;
    }

    public Li_OffShift GetLi_OffShiftFromReader(IDataReader reader)
    {
        try
        {
            Li_OffShift li_OffShift = new Li_OffShift
                (
                     
                    (int)reader["SchId"],
                    reader["StartTime"].ToString(),
                    reader["EndTime"].ToString(),
                    (decimal)reader["MinLateDay"],
                    (decimal)reader["NextLateDay"],
                    (decimal)reader["MaxOutHr"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_OffShift;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_OffShift GetLi_OffShiftByID(int li_OffShiftID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_OffShiftByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_OffShiftID", SqlDbType.Int).Value = li_OffShiftID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_OffShiftFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_OffShift(Li_OffShift li_OffShift)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_OffShift", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@SchId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StartTime", SqlDbType.VarChar).Value = li_OffShift.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.VarChar).Value = li_OffShift.EndTime;
            cmd.Parameters.Add("@MinLateDay", SqlDbType.Decimal).Value = li_OffShift.MinLateDay;
            cmd.Parameters.Add("@NextLateDay", SqlDbType.Decimal).Value = li_OffShift.NextLateDay;
            cmd.Parameters.Add("@MaxOutHr", SqlDbType.Decimal).Value = li_OffShift.MaxOutHr;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_OffShift.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_OffShift.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_OffShift.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_OffShift.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_OffShift.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SchId"].Value;
        }
    }

    public bool UpdateLi_OffShift(Li_OffShift li_OffShift)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_OffShift", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@SchId", SqlDbType.Int).Value = li_OffShift.SchId;
            cmd.Parameters.Add("@StartTime", SqlDbType.VarChar).Value = li_OffShift.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.VarChar).Value = li_OffShift.EndTime;
            cmd.Parameters.Add("@MinLateDay", SqlDbType.Decimal).Value = li_OffShift.MinLateDay;
            cmd.Parameters.Add("@NextLateDay", SqlDbType.Decimal).Value = li_OffShift.NextLateDay;
            cmd.Parameters.Add("@MaxOutHr", SqlDbType.Decimal).Value = li_OffShift.MaxOutHr;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_OffShift.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_OffShift.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_OffShift.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_OffShift.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_OffShift.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
