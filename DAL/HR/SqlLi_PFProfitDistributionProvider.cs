using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_PFProfitDistributionProvider:DataAccessObject
{
	public SqlLi_PFProfitDistributionProvider()
    {
    }


    public bool DeleteLi_PFProfitDistribution(int li_PFProfitDistributionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PFProfitDistribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PDisId", SqlDbType.Int).Value = li_PFProfitDistributionID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PFProfitDistribution> GetAllLi_PFProfitDistributions()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PFProfitDistributions", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PFProfitDistributionsFromReader(reader);
        }
    }
    public List<Li_PFProfitDistribution> GetLi_PFProfitDistributionsFromReader(IDataReader reader)
    {
        List<Li_PFProfitDistribution> li_PFProfitDistributions = new List<Li_PFProfitDistribution>();

        while (reader.Read())
        {
            li_PFProfitDistributions.Add(GetLi_PFProfitDistributionFromReader(reader));
        }
        return li_PFProfitDistributions;
    }

    public Li_PFProfitDistribution GetLi_PFProfitDistributionFromReader(IDataReader reader)
    {
        try
        {
            Li_PFProfitDistribution li_PFProfitDistribution = new Li_PFProfitDistribution
                (
                 
                    (int)reader["PDisId"],
                    reader["RefNo"].ToString(),
                    reader["DisTitle"].ToString(),
                    (int)reader["ProjectId"],
                    (decimal)reader["DistriAmount"],
                    (decimal)reader["DistriPercent"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PFProfitDistribution;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PFProfitDistribution GetLi_PFProfitDistributionByID(int li_PFProfitDistributionID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PFProfitDistributionByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PDisId", SqlDbType.Int).Value = li_PFProfitDistributionID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PFProfitDistributionFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PFProfitDistribution(Li_PFProfitDistribution li_PFProfitDistribution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PFProfitDistribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@PDisId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_PFProfitDistribution.RefNo;
            cmd.Parameters.Add("@DisTitle", SqlDbType.VarChar).Value = li_PFProfitDistribution.DisTitle;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = li_PFProfitDistribution.ProjectId;
            cmd.Parameters.Add("@DistriAmount", SqlDbType.Decimal).Value = li_PFProfitDistribution.DistriAmount;
            cmd.Parameters.Add("@DistriPercent", SqlDbType.Decimal).Value = li_PFProfitDistribution.DistriPercent;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFProfitDistribution.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFProfitDistribution.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFProfitDistribution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFProfitDistribution.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFProfitDistribution.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PDisId"].Value;
        }
    }

    public bool UpdateLi_PFProfitDistribution(Li_PFProfitDistribution li_PFProfitDistribution)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PFProfitDistribution", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.Add("@PDisId", SqlDbType.Int).Value = li_PFProfitDistribution.PDisId;
            cmd.Parameters.Add("@RefNo", SqlDbType.VarChar).Value = li_PFProfitDistribution.RefNo;
            cmd.Parameters.Add("@DisTitle", SqlDbType.VarChar).Value = li_PFProfitDistribution.DisTitle;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = li_PFProfitDistribution.ProjectId;
            cmd.Parameters.Add("@DistriAmount", SqlDbType.Decimal).Value = li_PFProfitDistribution.DistriAmount;
            cmd.Parameters.Add("@DistriPercent", SqlDbType.Decimal).Value = li_PFProfitDistribution.DistriPercent;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFProfitDistribution.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFProfitDistribution.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFProfitDistribution.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFProfitDistribution.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFProfitDistribution.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
