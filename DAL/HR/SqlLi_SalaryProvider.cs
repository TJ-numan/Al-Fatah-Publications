using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_SalaryProvider:DataAccessObject
{
	public SqlLi_SalaryProvider()
    {
    }


    public bool DeleteLi_Salary(int li_SalaryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_Salary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SalaryId", SqlDbType.Int).Value = li_SalaryID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_Salary> GetAllLi_Salaries()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_Salaries", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_SalariesFromReader(reader);
        }
    }
    public List<Li_Salary> GetLi_SalariesFromReader(IDataReader reader)
    {
        List<Li_Salary> li_Salaries = new List<Li_Salary>();

        while (reader.Read())
        {
            li_Salaries.Add(GetLi_SalaryFromReader(reader));
        }
        return li_Salaries;
    }

    public Li_Salary GetLi_SalaryFromReader(IDataReader reader)
    {
        try
        {
            Li_Salary li_Salary = new Li_Salary
                (
                 
                    (int)reader["SalaryId"],
                    reader["SalTitle"].ToString(),
                    reader["SalYear"].ToString(),
                    reader["SalMonth"].ToString(),
                    (decimal)reader["BasicSalAmt"],
                    (decimal)reader["AlowanceAmt"],
                    (decimal)reader["BonusAmt"],
                    (decimal)reader["PFDeductedAmt"],
                    (decimal)reader["AttnDeductedAmt"],
                    (decimal)reader["OthDeductAmt"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_Salary;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_Salary GetLi_SalaryByID(int li_SalaryID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_SalaryByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SalaryId", SqlDbType.Int).Value = li_SalaryID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_SalaryFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_Salary(Li_Salary li_Salary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_Salary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@SalaryId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SalTitle", SqlDbType.VarChar).Value = li_Salary.SalTitle;
            cmd.Parameters.Add("@SalYear", SqlDbType.VarChar).Value = li_Salary.SalYear;
            cmd.Parameters.Add("@SalMonth", SqlDbType.VarChar).Value = li_Salary.SalMonth;
            cmd.Parameters.Add("@BasicSalAmt", SqlDbType.Decimal).Value = li_Salary.BasicSalAmt;
            cmd.Parameters.Add("@AlowanceAmt", SqlDbType.Decimal).Value = li_Salary.AlowanceAmt;
            cmd.Parameters.Add("@BonusAmt", SqlDbType.Decimal).Value = li_Salary.BonusAmt;
            cmd.Parameters.Add("@PFDeductedAmt", SqlDbType.Decimal).Value = li_Salary.PFDeductedAmt;
            cmd.Parameters.Add("@AttnDeductedAmt", SqlDbType.Decimal).Value = li_Salary.AttnDeductedAmt;
            cmd.Parameters.Add("@OthDeductAmt", SqlDbType.Decimal).Value = li_Salary.OthDeductAmt;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_Salary.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Salary.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Salary.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Salary.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Salary.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Salary.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@SalaryId"].Value;
        }
    }

    public bool UpdateLi_Salary(Li_Salary li_Salary)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_Salary", connection);
            cmd.CommandType = CommandType.StoredProcedure;
             
            cmd.Parameters.Add("@SalaryId", SqlDbType.Int).Value = li_Salary.SalaryId;
            cmd.Parameters.Add("@SalTitle", SqlDbType.VarChar).Value = li_Salary.SalTitle;
            cmd.Parameters.Add("@SalYear", SqlDbType.VarChar).Value = li_Salary.SalYear;
            cmd.Parameters.Add("@SalMonth", SqlDbType.VarChar).Value = li_Salary.SalMonth;
            cmd.Parameters.Add("@BasicSalAmt", SqlDbType.Decimal).Value = li_Salary.BasicSalAmt;
            cmd.Parameters.Add("@AlowanceAmt", SqlDbType.Decimal).Value = li_Salary.AlowanceAmt;
            cmd.Parameters.Add("@BonusAmt", SqlDbType.Decimal).Value = li_Salary.BonusAmt;
            cmd.Parameters.Add("@PFDeductedAmt", SqlDbType.Decimal).Value = li_Salary.PFDeductedAmt;
            cmd.Parameters.Add("@AttnDeductedAmt", SqlDbType.Decimal).Value = li_Salary.AttnDeductedAmt;
            cmd.Parameters.Add("@OthDeductAmt", SqlDbType.Decimal).Value = li_Salary.OthDeductAmt;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_Salary.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_Salary.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_Salary.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_Salary.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_Salary.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_Salary.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
