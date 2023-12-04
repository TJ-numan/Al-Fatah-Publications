using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_MonthlyPayDayProvider:DataAccessObject
{
	public SqlLi_MonthlyPayDayProvider()
    {
    }


    public bool DeleteLi_MonthlyPayDay(int li_MonthlyPayDayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_MonthlyPayDay", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PayMSl", SqlDbType.Int).Value = li_MonthlyPayDayID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_MonthlyPayDay> GetAllLi_MonthlyPayDaies()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_MonthlyPayDaies", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_MonthlyPayDaiesFromReader(reader);
        }
    }
    public List<Li_MonthlyPayDay> GetLi_MonthlyPayDaiesFromReader(IDataReader reader)
    {
        List<Li_MonthlyPayDay> li_MonthlyPayDaies = new List<Li_MonthlyPayDay>();

        while (reader.Read())
        {
            li_MonthlyPayDaies.Add(GetLi_MonthlyPayDayFromReader(reader));
        }
        return li_MonthlyPayDaies;
    }

    public Li_MonthlyPayDay GetLi_MonthlyPayDayFromReader(IDataReader reader)
    {
        try
        {
            Li_MonthlyPayDay li_MonthlyPayDay = new Li_MonthlyPayDay
                (
           
                    (int)reader["PayMSl"],
                    reader["PayMonth"].ToString(),
                    (int)reader["EmpSl"],
                    (decimal)reader["PresentDay"],
                    (decimal)reader["LeaveDay"],
                    (decimal)reader["LeaveWithOutPay"],
                    (decimal)reader["Weekend"],
                    (decimal)reader["Holiday"],
                    (decimal)reader["PayDay"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_MonthlyPayDay;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_MonthlyPayDay GetLi_MonthlyPayDayByID(int li_MonthlyPayDayID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_MonthlyPayDayByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PayMSl", SqlDbType.Int).Value = li_MonthlyPayDayID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_MonthlyPayDayFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_MonthlyPayDay(Li_MonthlyPayDay li_MonthlyPayDay)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_MonthlyPayDay", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@PayMSl", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PayMonth", SqlDbType.VarChar).Value = li_MonthlyPayDay.PayMonth;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_MonthlyPayDay.EmpSl;
            cmd.Parameters.Add("@PresentDay", SqlDbType.Decimal).Value = li_MonthlyPayDay.PresentDay;
            cmd.Parameters.Add("@LeaveDay", SqlDbType.Decimal).Value = li_MonthlyPayDay.LeaveDay;
            cmd.Parameters.Add("@LeaveWithOutPay", SqlDbType.Decimal).Value = li_MonthlyPayDay.LeaveWithOutPay;
            cmd.Parameters.Add("@Weekend", SqlDbType.Decimal).Value = li_MonthlyPayDay.Weekend;
            cmd.Parameters.Add("@Holiday", SqlDbType.Decimal).Value = li_MonthlyPayDay.Holiday;
            cmd.Parameters.Add("@PayDay", SqlDbType.Decimal).Value = li_MonthlyPayDay.PayDay;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MonthlyPayDay.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MonthlyPayDay.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MonthlyPayDay.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MonthlyPayDay.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_MonthlyPayDay.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PayMSl"].Value;
        }
    }

    public bool UpdateLi_MonthlyPayDay(Li_MonthlyPayDay li_MonthlyPayDay)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_MonthlyPayDay", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PayMSl", SqlDbType.Int).Value = li_MonthlyPayDay.PayMSl;
            cmd.Parameters.Add("@PayMonth", SqlDbType.VarChar).Value = li_MonthlyPayDay.PayMonth;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_MonthlyPayDay.EmpSl;
            cmd.Parameters.Add("@PresentDay", SqlDbType.Decimal).Value = li_MonthlyPayDay.PresentDay;
            cmd.Parameters.Add("@LeaveDay", SqlDbType.Decimal).Value = li_MonthlyPayDay.LeaveDay;
            cmd.Parameters.Add("@LeaveWithOutPay", SqlDbType.Decimal).Value = li_MonthlyPayDay.LeaveWithOutPay;
            cmd.Parameters.Add("@Weekend", SqlDbType.Decimal).Value = li_MonthlyPayDay.Weekend;
            cmd.Parameters.Add("@Holiday", SqlDbType.Decimal).Value = li_MonthlyPayDay.Holiday;
            cmd.Parameters.Add("@PayDay", SqlDbType.Decimal).Value = li_MonthlyPayDay.PayDay;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_MonthlyPayDay.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_MonthlyPayDay.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_MonthlyPayDay.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_MonthlyPayDay.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_MonthlyPayDay.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
