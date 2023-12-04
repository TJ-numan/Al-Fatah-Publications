using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_HolidayProvider:DataAccessObject
{
	public SqlLi_HolidayProvider()
    {
    }


    public bool DeleteLi_Holiday(int li_HolidayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Holiday", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HoliId", SqlDbType.Int).Value = li_HolidayID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Holiday> GetAllLi_Holidaies()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Holidaies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_HolidaiesFromReader(reader);
        }
    }
    public List<Li_Holiday> GetLi_HolidaiesFromReader(IDataReader reader)
    {
        List<Li_Holiday> li_Holidaies = new List<Li_Holiday>();

        while (reader.Read())
        {
            li_Holidaies.Add(GetLi_HolidayFromReader(reader));
        }
        return li_Holidaies;
    }

    public Li_Holiday GetLi_HolidayFromReader(IDataReader reader)
    {
        try
        {
            Li_Holiday li_Holiday = new Li_Holiday
                (
                     
                    (int)reader["HoliId"],
                    (int)reader["LocId"],
                    reader["HoliDayTitle"].ToString(),
                    (DateTime)reader["StDate"],
                    (DateTime)reader["EnDate"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Holiday;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Holiday GetLi_HolidayByID(int li_HolidayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_HolidayByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@HoliId", SqlDbType.Int).Value = li_HolidayID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_HolidayFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Holiday(Li_Holiday li_Holiday)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Holiday", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@HoliId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LocId", SqlDbType.Int).Value = li_Holiday.LocId;
            cmd.Parameters.Add("@HoliDayTitle", SqlDbType.VarChar).Value = li_Holiday.HoliDayTitle;
            cmd.Parameters.Add("@StDate", SqlDbType.DateTime).Value = li_Holiday.StDate;
            cmd.Parameters.Add("@EnDate", SqlDbType.DateTime).Value = li_Holiday.EnDate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_Holiday.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Holiday.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Holiday.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Holiday.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Holiday.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Holiday.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@HoliId"].Value;
        }
    }

    public bool UpdateLi_Holiday(Li_Holiday li_Holiday)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Holiday", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@HoliId", SqlDbType.Int).Value = li_Holiday.HoliId;
            cmd.Parameters.Add("@LocId", SqlDbType.Int).Value = li_Holiday.LocId;
            cmd.Parameters.Add("@HoliDayTitle", SqlDbType.VarChar).Value = li_Holiday.HoliDayTitle;
            cmd.Parameters.Add("@StDate", SqlDbType.DateTime).Value = li_Holiday.StDate;
            cmd.Parameters.Add("@EnDate", SqlDbType.DateTime).Value = li_Holiday.EnDate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_Holiday.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Holiday.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Holiday.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Holiday.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Holiday.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Holiday.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
