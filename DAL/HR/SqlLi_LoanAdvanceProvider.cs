using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_LoanAdvanceProvider:DataAccessObject
{
	public SqlLi_LoanAdvanceProvider()
    {
    }


    public bool DeleteLi_LoanAdvance(int li_LoanAdvanceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_LoanAdvance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoAdId", SqlDbType.Int).Value = li_LoanAdvanceID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LoanAdvance> GetAllLi_LoanAdvances()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_LoanAdvances", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LoanAdvancesFromReader(reader);
        }
    }
    public List<Li_LoanAdvance> GetLi_LoanAdvancesFromReader(IDataReader reader)
    {
        List<Li_LoanAdvance> li_LoanAdvances = new List<Li_LoanAdvance>();

        while (reader.Read())
        {
            li_LoanAdvances.Add(GetLi_LoanAdvanceFromReader(reader));
        }
        return li_LoanAdvances;
    }

    public Li_LoanAdvance GetLi_LoanAdvanceFromReader(IDataReader reader)
    {
        try
        {
            Li_LoanAdvance li_LoanAdvance = new Li_LoanAdvance
                (
                    
                    (int)reader["LoAdId"],
                    (int)reader["EmpSl"],
                    reader["LoAdFor"].ToString(),
                    reader["LoAdForDes"].ToString(),
                    (bool)reader["IsAdvance"],
                    (decimal)reader["IsAdjusted"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_LoanAdvance;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LoanAdvance GetLi_LoanAdvanceByID(int li_LoanAdvanceID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_LoanAdvanceByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LoAdId", SqlDbType.Int).Value = li_LoanAdvanceID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LoanAdvanceFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LoanAdvance(Li_LoanAdvance li_LoanAdvance)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_LoanAdvance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@LoAdId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_LoanAdvance.EmpSl;
            cmd.Parameters.Add("@LoAdFor", SqlDbType.VarChar).Value = li_LoanAdvance.LoAdFor;
            cmd.Parameters.Add("@LoAdForDes", SqlDbType.VarChar).Value = li_LoanAdvance.LoAdForDes;
            cmd.Parameters.Add("@IsAdvance", SqlDbType.Bit).Value = li_LoanAdvance.IsAdvance;
            cmd.Parameters.Add("@IsAdjusted", SqlDbType.Decimal).Value = li_LoanAdvance.IsAdjusted;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LoanAdvance.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LoanAdvance.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LoanAdvance.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LoanAdvance.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LoanAdvance.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LoAdId"].Value;
        }
    }

    public bool UpdateLi_LoanAdvance(Li_LoanAdvance li_LoanAdvance)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_LoanAdvance", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@LoAdId", SqlDbType.Int).Value = li_LoanAdvance.LoAdId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_LoanAdvance.EmpSl;
            cmd.Parameters.Add("@LoAdFor", SqlDbType.VarChar).Value = li_LoanAdvance.LoAdFor;
            cmd.Parameters.Add("@LoAdForDes", SqlDbType.VarChar).Value = li_LoanAdvance.LoAdForDes;
            cmd.Parameters.Add("@IsAdvance", SqlDbType.Bit).Value = li_LoanAdvance.IsAdvance;
            cmd.Parameters.Add("@IsAdjusted", SqlDbType.Decimal).Value = li_LoanAdvance.IsAdjusted;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LoanAdvance.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LoanAdvance.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LoanAdvance.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LoanAdvance.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LoanAdvance.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
