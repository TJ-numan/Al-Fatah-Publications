using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_WorkShiftProvider:DataAccessObject
{
	public SqlLi_WorkShiftProvider()
    {
    }


    public bool DeleteLi_WorkShift(int li_WorkShiftID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_WorkShift", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_WorkShiftID", SqlDbType.Int).Value = li_WorkShiftID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_WorkShift> GetAllLi_WorkShifts()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_WorkShifts", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_WorkShiftsFromReader(reader);
        }
    }
    public List<Li_WorkShift> GetLi_WorkShiftsFromReader(IDataReader reader)
    {
        List<Li_WorkShift> li_WorkShifts = new List<Li_WorkShift>();

        while (reader.Read())
        {
            li_WorkShifts.Add(GetLi_WorkShiftFromReader(reader));
        }
        return li_WorkShifts;
    }

    public Li_WorkShift GetLi_WorkShiftFromReader(IDataReader reader)
    {
        try
        {
            Li_WorkShift li_WorkShift = new Li_WorkShift
                (
                    
                    (int)reader["WkShfId"],
                    (int)reader["SchedId"],
                    reader["WkShfStartT"].ToString(),
                    reader["WkShfEndT"].ToString(),
                    reader["WkShfDes"].ToString(),
                    (int)reader["GraceMinute"],
                    (decimal)reader["MinStayHour"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_WorkShift;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_WorkShift GetLi_WorkShiftByID(int li_WorkShiftID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_WorkShiftByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_WorkShiftID", SqlDbType.Int).Value = li_WorkShiftID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_WorkShiftFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_WorkShift(Li_WorkShift li_WorkShift)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_WorkShift", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@WkShfId", SqlDbType.Int)  .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SchedId", SqlDbType.Int).Value = li_WorkShift.SchedId;
            cmd.Parameters.Add("@WkShfStartT", SqlDbType.VarChar).Value = li_WorkShift.WkShfStartT;
            cmd.Parameters.Add("@WkShfEndT", SqlDbType.VarChar).Value = li_WorkShift.WkShfEndT;
            cmd.Parameters.Add("@WkShfDes", SqlDbType.VarChar).Value = li_WorkShift.WkShfDes;
            cmd.Parameters.Add("@GraceMinute", SqlDbType.Int).Value = li_WorkShift.GraceMinute;
            cmd.Parameters.Add("@MinStayHour", SqlDbType.Decimal).Value = li_WorkShift.MinStayHour;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_WorkShift.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_WorkShift.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_WorkShift.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_WorkShift.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_WorkShift.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@WkShfId"].Value;
        }
    }

    public bool UpdateLi_WorkShift(Li_WorkShift li_WorkShift)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_WorkShift", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@WkShfId", SqlDbType.Int).Value = li_WorkShift.WkShfId;
            cmd.Parameters.Add("@SchedId", SqlDbType.Int).Value = li_WorkShift.SchedId;
            cmd.Parameters.Add("@WkShfStartT", SqlDbType.VarChar).Value = li_WorkShift.WkShfStartT;
            cmd.Parameters.Add("@WkShfEndT", SqlDbType.VarChar).Value = li_WorkShift.WkShfEndT;
            cmd.Parameters.Add("@WkShfDes", SqlDbType.VarChar).Value = li_WorkShift.WkShfDes;
            cmd.Parameters.Add("@GraceMinute", SqlDbType.Int).Value = li_WorkShift.GraceMinute;
            cmd.Parameters.Add("@MinStayHour", SqlDbType.Decimal).Value = li_WorkShift.MinStayHour;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_WorkShift.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_WorkShift.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_WorkShift.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_WorkShift.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_WorkShift.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
