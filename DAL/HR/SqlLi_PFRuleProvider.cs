using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_PFRuleProvider:DataAccessObject
{
	public SqlLi_PFRuleProvider()
    {
    }


    public bool DeleteLi_PFRule(int li_PFRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PFRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PFRuId", SqlDbType.Int).Value = li_PFRuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PFRule> GetAllLi_PFRules()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PFRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PFRulesFromReader(reader);
        }
    }
    public List<Li_PFRule> GetLi_PFRulesFromReader(IDataReader reader)
    {
        List<Li_PFRule> li_PFRules = new List<Li_PFRule>();

        while (reader.Read())
        {
            li_PFRules.Add(GetLi_PFRuleFromReader(reader));
        }
        return li_PFRules;
    }

    public Li_PFRule GetLi_PFRuleFromReader(IDataReader reader)
    {
        try
        {
            Li_PFRule li_PFRule = new Li_PFRule
                (
                     
                    (int)reader["PFRuId"],
                    reader["PFRuName"].ToString(),
                    (decimal)reader["PFRate"],
                    (decimal)reader["JobYerF"],
                    (decimal)reader["JobYerT"],
                    (decimal)reader["BenefitRate"],
                    reader["Comments"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PFRule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PFRule GetLi_PFRuleByID(int li_PFRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PFRuleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@PFRuId", SqlDbType.Int).Value = li_PFRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PFRuleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PFRule(Li_PFRule li_PFRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PFRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.Add("@PFRuId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@PFRuName", SqlDbType.VarChar).Value = li_PFRule.PFRuName;
            cmd.Parameters.Add("@PFRate", SqlDbType.Decimal).Value = li_PFRule.PFRate;
            cmd.Parameters.Add("@JobYerF", SqlDbType.Decimal).Value = li_PFRule.JobYerF;
            cmd.Parameters.Add("@JobYerT", SqlDbType.Decimal).Value = li_PFRule.JobYerT;
            cmd.Parameters.Add("@BenefitRate", SqlDbType.Decimal).Value = li_PFRule.BenefitRate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_PFRule.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFRule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFRule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFRule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFRule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@PFRuId"].Value;
        }
    }

    public bool UpdateLi_PFRule(Li_PFRule li_PFRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PFRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
 
            cmd.Parameters.Add("@PFRuId", SqlDbType.Int).Value = li_PFRule.PFRuId;
            cmd.Parameters.Add("@PFRuName", SqlDbType.VarChar).Value = li_PFRule.PFRuName;
            cmd.Parameters.Add("@PFRate", SqlDbType.Decimal).Value = li_PFRule.PFRate;
            cmd.Parameters.Add("@JobYerF", SqlDbType.Decimal).Value = li_PFRule.JobYerF;
            cmd.Parameters.Add("@JobYerT", SqlDbType.Decimal).Value = li_PFRule.JobYerT;
            cmd.Parameters.Add("@BenefitRate", SqlDbType.Decimal).Value = li_PFRule.BenefitRate;
            cmd.Parameters.Add("@Comments", SqlDbType.VarChar).Value = li_PFRule.Comments;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFRule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFRule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFRule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFRule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
