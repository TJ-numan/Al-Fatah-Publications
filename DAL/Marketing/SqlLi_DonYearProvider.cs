using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_DonYearProvider:DataAccessObject
{
	public SqlLi_DonYearProvider()
    {
    }


    public bool DeleteLi_DonYear(int li_DonYearID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("DeleteLi_DonYear", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_DonYearID", SqlDbType.Int).Value = li_DonYearID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_DonYear> GetAllLi_DonYears()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetAllLi_DonYears", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_DonYearsFromReader(reader);
        }
    }
    public List<Li_DonYear> GetLi_DonYearsFromReader(IDataReader reader)
    {
        List<Li_DonYear> li_DonYears = new List<Li_DonYear>();

        while (reader.Read())
        {
            li_DonYears.Add(GetLi_DonYearFromReader(reader));
        }
        return li_DonYears;
    }

    public Li_DonYear GetLi_DonYearFromReader(IDataReader reader)
    {
        try
        {
            Li_DonYear li_DonYear = new Li_DonYear
                (
                   
                    reader["DonYear"].ToString(),
                    (DateTime)reader["StatingDate"],
                    (DateTime)reader["EndDate"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"]
                );
             return li_DonYear;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_DonYear GetLi_DonYearByID(int li_DonYearID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("GetLi_DonYearByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Li_DonYearID", SqlDbType.Int).Value = li_DonYearID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_DonYearFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_DonYear(Li_DonYear li_DonYear)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("InsertLi_DonYear", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@DonYear", SqlDbType.VarChar). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@StatingDate", SqlDbType.DateTime).Value = li_DonYear.StatingDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = li_DonYear.EndDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonYear.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonYear.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DonYear"].Value;
        }
    }

    public bool UpdateLi_DonYear(Li_DonYear li_DonYear)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("UpdateLi_DonYear", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@DonYear", SqlDbType.VarChar).Value = li_DonYear.DonYear;
            cmd.Parameters.Add("@StatingDate", SqlDbType.DateTime).Value = li_DonYear.StatingDate;
            cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = li_DonYear.EndDate;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_DonYear.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_DonYear.CreatedDate;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
