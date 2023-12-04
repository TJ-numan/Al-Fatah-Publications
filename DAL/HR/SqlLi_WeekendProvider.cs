using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_WeekendProvider:DataAccessObject
{
	public SqlLi_WeekendProvider()
    {
    }


    public bool DeleteLi_Weekend(int li_WeekendID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Weekend", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@WekDayId", SqlDbType.Int).Value = li_WeekendID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Weekend> GetAllLi_Weekends()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Weekends", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_WeekendsFromReader(reader);
        }
    }
    public List<Li_Weekend> GetLi_WeekendsFromReader(IDataReader reader)
    {
        List<Li_Weekend> li_Weekends = new List<Li_Weekend>();

        while (reader.Read())
        {
            li_Weekends.Add(GetLi_WeekendFromReader(reader));
        }
        return li_Weekends;
    }

    public Li_Weekend GetLi_WeekendFromReader(IDataReader reader)
    {
        try
        {
            Li_Weekend li_Weekend = new Li_Weekend
                (
                     
                    (int)reader["WekDayId"],
                    (int)reader["LocId"],
                    reader["DayName"].ToString(),
                    (bool)reader["IsWorkingDay"],
                    (bool)reader["IsHalfDay"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Weekend;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Weekend GetLi_WeekendByID(int li_WeekendID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_WeekendByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@WekDayId", SqlDbType.Int).Value = li_WeekendID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_WeekendFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Weekend(Li_Weekend li_Weekend)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Weekend", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@WekDayId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LocId", SqlDbType.Int).Value = li_Weekend.LocId;
            cmd.Parameters.Add("@DayName", SqlDbType.VarChar).Value = li_Weekend.DayName;
            cmd.Parameters.Add("@IsWorkingDay", SqlDbType.Bit).Value = li_Weekend.IsWorkingDay;
            cmd.Parameters.Add("@IsHalfDay", SqlDbType.Bit).Value = li_Weekend.IsHalfDay;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Weekend.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Weekend.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Weekend.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Weekend.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Weekend.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@WekDayId"].Value;
        }
    }

    public bool UpdateLi_Weekend(Li_Weekend li_Weekend)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Weekend", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@WekDayId", SqlDbType.Int).Value = li_Weekend.WekDayId;
            cmd.Parameters.Add("@LocId", SqlDbType.Int).Value = li_Weekend.LocId;
            cmd.Parameters.Add("@DayName", SqlDbType.VarChar).Value = li_Weekend.DayName;
            cmd.Parameters.Add("@IsWorkingDay", SqlDbType.Bit).Value = li_Weekend.IsWorkingDay;
            cmd.Parameters.Add("@IsHalfDay", SqlDbType.Bit).Value = li_Weekend.IsHalfDay;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Weekend.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Weekend.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Weekend.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Weekend.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Weekend.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
