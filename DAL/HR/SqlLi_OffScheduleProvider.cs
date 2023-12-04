using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_OffScheduleProvider:DataAccessObject
{
	public SqlLi_OffScheduleProvider()
    {
    }


    public bool DeleteLi_OffSchedule(int li_OffScheduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_OffSchedule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_OffScheduleID", SqlDbType.Int).Value = li_OffScheduleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_OffSchedule> GetAllLi_OffSchedules()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_OffSchedules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_OffSchedulesFromReader(reader);
        }
    }
    public List<Li_OffSchedule> GetLi_OffSchedulesFromReader(IDataReader reader)
    {
        List<Li_OffSchedule> li_OffSchedules = new List<Li_OffSchedule>();

        while (reader.Read())
        {
            li_OffSchedules.Add(GetLi_OffScheduleFromReader(reader));
        }
        return li_OffSchedules;
    }

    public Li_OffSchedule GetLi_OffScheduleFromReader(IDataReader reader)
    {
        try
        {
            Li_OffSchedule li_OffSchedule = new Li_OffSchedule
                (
                  
                    (int)reader["SchId"],
                    reader["SchName"].ToString(),
                    reader["OfficeLocation"].ToString(),
                    reader["StartTime"].ToString(),
                    reader["EndTime"].ToString(),
                    (decimal)reader["MaxLateDay"],
                    (decimal)reader["NextLateDay"],
                    (decimal)reader["MaxOutH"],
                    reader["Comment"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_OffSchedule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_OffSchedule GetLi_OffScheduleByID(int li_OffScheduleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_OffScheduleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_OffScheduleID", SqlDbType.Int).Value = li_OffScheduleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_OffScheduleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_OffSchedule(Li_OffSchedule li_OffSchedule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_OffSchedule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SchId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SchName", SqlDbType.VarChar).Value = li_OffSchedule.SchName;
            cmd.Parameters.Add("@OfficeLocation", SqlDbType.VarChar).Value = li_OffSchedule.OfficeLocation;
            cmd.Parameters.Add("@StartTime", SqlDbType.VarChar).Value = li_OffSchedule.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.VarChar).Value = li_OffSchedule.EndTime;
            cmd.Parameters.Add("@MaxLateDay", SqlDbType.Decimal).Value = li_OffSchedule.MaxLateDay;
            cmd.Parameters.Add("@NextLateDay", SqlDbType.Decimal).Value = li_OffSchedule.NextLateDay;
            cmd.Parameters.Add("@MaxOutH", SqlDbType.Decimal).Value = li_OffSchedule.MaxOutH;
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = li_OffSchedule.Comment;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_OffSchedule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_OffSchedule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_OffSchedule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_OffSchedule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_OffSchedule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SchId"].Value;
        }
    }

    public bool UpdateLi_OffSchedule(Li_OffSchedule li_OffSchedule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_OffSchedule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@SchId", SqlDbType.Int).Value = li_OffSchedule.SchId;
            cmd.Parameters.Add("@SchName", SqlDbType.VarChar).Value = li_OffSchedule.SchName;
            cmd.Parameters.Add("@OfficeLocation", SqlDbType.VarChar).Value = li_OffSchedule.OfficeLocation;
            cmd.Parameters.Add("@StartTime", SqlDbType.VarChar).Value = li_OffSchedule.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.VarChar).Value = li_OffSchedule.EndTime;
            cmd.Parameters.Add("@MaxLateDay", SqlDbType.Decimal).Value = li_OffSchedule.MaxLateDay;
            cmd.Parameters.Add("@NextLateDay", SqlDbType.Decimal).Value = li_OffSchedule.NextLateDay;
            cmd.Parameters.Add("@MaxOutH", SqlDbType.Decimal).Value = li_OffSchedule.MaxOutH;
            cmd.Parameters.Add("@Comment", SqlDbType.VarChar).Value = li_OffSchedule.Comment;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_OffSchedule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_OffSchedule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_OffSchedule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_OffSchedule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_OffSchedule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
