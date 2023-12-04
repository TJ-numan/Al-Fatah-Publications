using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_EmpPayDayProvider:DataAccessObject
{
	public SqlLi_EmpPayDayProvider()
    {
    }


    public bool DeleteLi_EmpPayDay(int li_EmpPayDayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_EmpPayDay", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PDayCId", SqlDbType.Int).Value = li_EmpPayDayID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_EmpPayDay> GetAllLi_EmpPayDaies()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_EmpPayDaies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_EmpPayDaiesFromReader(reader);
        }
    }
    public List<Li_EmpPayDay> GetLi_EmpPayDaiesFromReader(IDataReader reader)
    {
        List<Li_EmpPayDay> li_EmpPayDaies = new List<Li_EmpPayDay>();

        while (reader.Read())
        {
            li_EmpPayDaies.Add(GetLi_EmpPayDayFromReader(reader));
        }
        return li_EmpPayDaies;
    }

    public Li_EmpPayDay GetLi_EmpPayDayFromReader(IDataReader reader)
    {
        try
        {
            Li_EmpPayDay li_EmpPayDay = new Li_EmpPayDay
                (
                    
                    (int)reader["PDayCId"],
                    reader["PayTitle"].ToString(),
                    (int)reader["TotalEmpNo"],
                    reader["PayYear"].ToString(),
                    reader["PayMonth"].ToString(),
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_EmpPayDay;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_EmpPayDay GetLi_EmpPayDayByID(int li_EmpPayDayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_EmpPayDayByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PDayCId", SqlDbType.Int).Value = li_EmpPayDayID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_EmpPayDayFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_EmpPayDay(Li_EmpPayDay li_EmpPayDay)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_EmpPayDay", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@PDayCId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PayTitle", SqlDbType.VarChar).Value = li_EmpPayDay.PayTitle;
            cmd.Parameters.Add("@TotalEmpNo", SqlDbType.Int).Value = li_EmpPayDay.TotalEmpNo;
            cmd.Parameters.Add("@PayYear", SqlDbType.VarChar).Value = li_EmpPayDay.PayYear;
            cmd.Parameters.Add("@PayMonth", SqlDbType.VarChar).Value = li_EmpPayDay.PayMonth;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpPayDay.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpPayDay.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpPayDay.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpPayDay.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpPayDay.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpPayDay.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PDayCId"].Value;
        }
    }

    public bool UpdateLi_EmpPayDay(Li_EmpPayDay li_EmpPayDay)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_EmpPayDay", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@PDayCId", SqlDbType.Int).Value = li_EmpPayDay.PDayCId;
            cmd.Parameters.Add("@PayTitle", SqlDbType.VarChar).Value = li_EmpPayDay.PayTitle;
            cmd.Parameters.Add("@TotalEmpNo", SqlDbType.Int).Value = li_EmpPayDay.TotalEmpNo;
            cmd.Parameters.Add("@PayYear", SqlDbType.VarChar).Value = li_EmpPayDay.PayYear;
            cmd.Parameters.Add("@PayMonth", SqlDbType.VarChar).Value = li_EmpPayDay.PayMonth;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_EmpPayDay.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_EmpPayDay.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_EmpPayDay.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_EmpPayDay.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_EmpPayDay.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_EmpPayDay.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
