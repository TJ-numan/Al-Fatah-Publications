using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_PFDistributionProvider:DataAccessObject
{
	public SqlLi_PFDistributionProvider()
    {
    }


    public bool DeleteLi_PFDistribution(int li_PFDistributionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PFDistribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DisId", SqlDbType.Int).Value = li_PFDistributionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PFDistribution> GetAllLi_PFDistributions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PFDistributions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PFDistributionsFromReader(reader);
        }
    }
    public List<Li_PFDistribution> GetLi_PFDistributionsFromReader(IDataReader reader)
    {
        List<Li_PFDistribution> li_PFDistributions = new List<Li_PFDistribution>();

        while (reader.Read())
        {
            li_PFDistributions.Add(GetLi_PFDistributionFromReader(reader));
        }
        return li_PFDistributions;
    }

    public Li_PFDistribution GetLi_PFDistributionFromReader(IDataReader reader)
    {
        try
        {
            Li_PFDistribution li_PFDistribution = new Li_PFDistribution
                (
                  
                    (int)reader["DisId"],
                    (int)reader["EmpSl"],
                    reader["RefNo"].ToString(),
                    reader["PFAcNo"].ToString(),
                    reader["TranPurpose"].ToString(),
                    (DateTime)reader["TranDate"],
                    (decimal)reader["Amount"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PFDistribution;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PFDistribution GetLi_PFDistributionByID(int li_PFDistributionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PFDistributionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@DisId", SqlDbType.Int).Value = li_PFDistributionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PFDistributionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PFDistribution(Li_PFDistribution li_PFDistribution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PFDistribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.Add("@DisId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_PFDistribution.EmpSl;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_PFDistribution.RefNo;
            cmd.Parameters.Add("@PFAcNo", SqlDbType.VarChar).Value = li_PFDistribution.PFAcNo;
            cmd.Parameters.Add("@TranPurpose", SqlDbType.VarChar).Value = li_PFDistribution.TranPurpose;
            cmd.Parameters.Add("@TranDate", SqlDbType.DateTime).Value = li_PFDistribution.TranDate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_PFDistribution.Amount;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFDistribution.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFDistribution.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFDistribution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFDistribution.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFDistribution.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@DisId"].Value;
        }
    }

    public bool UpdateLi_PFDistribution(Li_PFDistribution li_PFDistribution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PFDistribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
       
            cmd.Parameters.Add("@DisId", SqlDbType.Int).Value = li_PFDistribution.DisId;
            cmd.Parameters.Add("@EmpSl", SqlDbType.Int).Value = li_PFDistribution.EmpSl;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_PFDistribution.RefNo;
            cmd.Parameters.Add("@PFAcNo", SqlDbType.VarChar).Value = li_PFDistribution.PFAcNo;
            cmd.Parameters.Add("@TranPurpose", SqlDbType.VarChar).Value = li_PFDistribution.TranPurpose;
            cmd.Parameters.Add("@TranDate", SqlDbType.DateTime).Value = li_PFDistribution.TranDate;
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = li_PFDistribution.Amount;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFDistribution.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFDistribution.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFDistribution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFDistribution.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFDistribution.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
