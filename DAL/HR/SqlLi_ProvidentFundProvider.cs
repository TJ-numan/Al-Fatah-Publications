using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_ProvidentFundProvider:DataAccessObject
{
	public SqlLi_ProvidentFundProvider()
    {
    }


    public bool DeleteLi_ProvidentFund(int li_ProvidentFundID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_ProvidentFund", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Li_ProvidentFundID", SqlDbType.Int).Value = li_ProvidentFundID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_ProvidentFund> GetAllLi_ProvidentFunds()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_ProvidentFunds", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_ProvidentFundsFromReader(reader);
        }
    }
    public List<Li_ProvidentFund> GetLi_ProvidentFundsFromReader(IDataReader reader)
    {
        List<Li_ProvidentFund> li_ProvidentFunds = new List<Li_ProvidentFund>();

        while (reader.Read())
        {
            li_ProvidentFunds.Add(GetLi_ProvidentFundFromReader(reader));
        }
        return li_ProvidentFunds;
    }

    public Li_ProvidentFund GetLi_ProvidentFundFromReader(IDataReader reader)
    {
        try
        {
            Li_ProvidentFund li_ProvidentFund = new Li_ProvidentFund
                (
                  
                    (int)reader["PFId"],
                    reader["PFTitle"].ToString(),
                    reader["PFYear"].ToString(),
                    reader["PFMonth"].ToString(),
                    (DateTime)reader["MonthLDate"],
                    (int)reader["SalaryId"],
                    (decimal)reader["TotalEPFAmt"],
                    (decimal)reader["TotalComAmt"],
                    (decimal)reader["TotalProfitAmt"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_ProvidentFund;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_ProvidentFund GetLi_ProvidentFundByID(int li_ProvidentFundID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_ProvidentFundByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PFId", SqlDbType.Int).Value = li_ProvidentFundID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_ProvidentFundFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_ProvidentFund(Li_ProvidentFund li_ProvidentFund)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_ProvidentFund", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@PFId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PFTitle", SqlDbType.VarChar).Value = li_ProvidentFund.PFTitle;
            cmd.Parameters.Add("@PFYear", SqlDbType.VarChar).Value = li_ProvidentFund.PFYear;
            cmd.Parameters.Add("@PFMonth", SqlDbType.VarChar).Value = li_ProvidentFund.PFMonth;
            cmd.Parameters.Add("@MonthLDate", SqlDbType.DateTime).Value = li_ProvidentFund.MonthLDate;
            cmd.Parameters.Add("@SalaryId", SqlDbType.Int).Value = li_ProvidentFund.SalaryId;
            cmd.Parameters.Add("@TotalEPFAmt", SqlDbType.Decimal).Value = li_ProvidentFund.TotalEPFAmt;
            cmd.Parameters.Add("@TotalComAmt", SqlDbType.Decimal).Value = li_ProvidentFund.TotalComAmt;
            cmd.Parameters.Add("@TotalProfitAmt", SqlDbType.Decimal).Value = li_ProvidentFund.TotalProfitAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ProvidentFund.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ProvidentFund.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ProvidentFund.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ProvidentFund.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ProvidentFund.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PFId"].Value;
        }
    }

    public bool UpdateLi_ProvidentFund(Li_ProvidentFund li_ProvidentFund)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_ProvidentFund", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@PFId", SqlDbType.Int).Value = li_ProvidentFund.PFId;
            cmd.Parameters.Add("@PFTitle", SqlDbType.VarChar).Value = li_ProvidentFund.PFTitle;
            cmd.Parameters.Add("@PFYear", SqlDbType.VarChar).Value = li_ProvidentFund.PFYear;
            cmd.Parameters.Add("@PFMonth", SqlDbType.VarChar).Value = li_ProvidentFund.PFMonth;
            cmd.Parameters.Add("@MonthLDate", SqlDbType.DateTime).Value = li_ProvidentFund.MonthLDate;
            cmd.Parameters.Add("@SalaryId", SqlDbType.Int).Value = li_ProvidentFund.SalaryId;
            cmd.Parameters.Add("@TotalEPFAmt", SqlDbType.Decimal).Value = li_ProvidentFund.TotalEPFAmt;
            cmd.Parameters.Add("@TotalComAmt", SqlDbType.Decimal).Value = li_ProvidentFund.TotalComAmt;
            cmd.Parameters.Add("@TotalProfitAmt", SqlDbType.Decimal).Value = li_ProvidentFund.TotalProfitAmt;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_ProvidentFund.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_ProvidentFund.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_ProvidentFund.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_ProvidentFund.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_ProvidentFund.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
