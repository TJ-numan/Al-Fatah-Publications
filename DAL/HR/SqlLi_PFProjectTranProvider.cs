using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_PFProjectTranProvider:DataAccessObject
{
	public SqlLi_PFProjectTranProvider()
    {
    }


    public bool DeleteLi_PFProjectTran(int li_PFProjectTranID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PFProjectTran", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProjectInvestId", SqlDbType.Int).Value = li_PFProjectTranID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PFProjectTran> GetAllLi_PFProjectTrans()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PFProjectTrans", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PFProjectTransFromReader(reader);
        }
    }
    public List<Li_PFProjectTran> GetLi_PFProjectTransFromReader(IDataReader reader)
    {
        List<Li_PFProjectTran> li_PFProjectTrans = new List<Li_PFProjectTran>();

        while (reader.Read())
        {
            li_PFProjectTrans.Add(GetLi_PFProjectTranFromReader(reader));
        }
        return li_PFProjectTrans;
    }

    public Li_PFProjectTran GetLi_PFProjectTranFromReader(IDataReader reader)
    {
        try
        {
            Li_PFProjectTran li_PFProjectTran = new Li_PFProjectTran
                (
                 
                    (int)reader["ProjectInvestId"],
                    (int)reader["ProjectId"],
                    (DateTime)reader["TranDate"],
                    (decimal)reader["InvAmt"],
                    (decimal)reader["RetAmt"],
                    (decimal)reader["ProfitAmt"],
                    reader["BankName"].ToString(),
                    reader["BankAdd"].ToString(),
                    reader["BankAcNo"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PFProjectTran;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PFProjectTran GetLi_PFProjectTranByID(int li_PFProjectTranID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PFProjectTranByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProjectInvestId", SqlDbType.Int).Value = li_PFProjectTranID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PFProjectTranFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PFProjectTran(Li_PFProjectTran li_PFProjectTran)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PFProjectTran", connection);
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.Add("@ProjectInvestId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = li_PFProjectTran.ProjectId;
            cmd.Parameters.Add("@TranDate", SqlDbType.DateTime).Value = li_PFProjectTran.TranDate;
            cmd.Parameters.Add("@InvAmt", SqlDbType.Decimal).Value = li_PFProjectTran.InvAmt;
            cmd.Parameters.Add("@RetAmt", SqlDbType.Decimal).Value = li_PFProjectTran.RetAmt;
            cmd.Parameters.Add("@ProfitAmt", SqlDbType.Decimal).Value = li_PFProjectTran.ProfitAmt;
            cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = li_PFProjectTran.BankName;
            cmd.Parameters.Add("@BankAdd", SqlDbType.VarChar).Value = li_PFProjectTran.BankAdd;
            cmd.Parameters.Add("@BankAcNo", SqlDbType.VarChar).Value = li_PFProjectTran.BankAcNo;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFProjectTran.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFProjectTran.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFProjectTran.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFProjectTran.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFProjectTran.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProjectInvestId"].Value;
        }
    }

    public bool UpdateLi_PFProjectTran(Li_PFProjectTran li_PFProjectTran)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PFProjectTran", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@ProjectInvestId", SqlDbType.Int).Value = li_PFProjectTran.ProjectInvestId;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = li_PFProjectTran.ProjectId;
            cmd.Parameters.Add("@TranDate", SqlDbType.DateTime).Value = li_PFProjectTran.TranDate;
            cmd.Parameters.Add("@InvAmt", SqlDbType.Decimal).Value = li_PFProjectTran.InvAmt;
            cmd.Parameters.Add("@RetAmt", SqlDbType.Decimal).Value = li_PFProjectTran.RetAmt;
            cmd.Parameters.Add("@ProfitAmt", SqlDbType.Decimal).Value = li_PFProjectTran.ProfitAmt;
            cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = li_PFProjectTran.BankName;
            cmd.Parameters.Add("@BankAdd", SqlDbType.VarChar).Value = li_PFProjectTran.BankAdd;
            cmd.Parameters.Add("@BankAcNo", SqlDbType.VarChar).Value = li_PFProjectTran.BankAcNo;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFProjectTran.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFProjectTran.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFProjectTran.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFProjectTran.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFProjectTran.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
