using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_PFProjectRuleProvider:DataAccessObject
{
	public SqlLi_PFProjectRuleProvider()
    {
    }


    public bool DeleteLi_PFProjectRule(int li_PFProjectRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_PFProjectRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProRulId", SqlDbType.Int).Value = li_PFProjectRuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_PFProjectRule> GetAllLi_PFProjectRules()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_PFProjectRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_PFProjectRulesFromReader(reader);
        }
    }
    public List<Li_PFProjectRule> GetLi_PFProjectRulesFromReader(IDataReader reader)
    {
        List<Li_PFProjectRule> li_PFProjectRules = new List<Li_PFProjectRule>();

        while (reader.Read())
        {
            li_PFProjectRules.Add(GetLi_PFProjectRuleFromReader(reader));
        }
        return li_PFProjectRules;
    }

    public Li_PFProjectRule GetLi_PFProjectRuleFromReader(IDataReader reader)
    {
        try
        {
            Li_PFProjectRule li_PFProjectRule = new Li_PFProjectRule
                (
                
                    (int)reader["ProRulId"],
                    (int)reader["ProjectId"],
                    reader["ProRuleName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_PFProjectRule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_PFProjectRule GetLi_PFProjectRuleByID(int li_PFProjectRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_PFProjectRuleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProRulId", SqlDbType.Int).Value = li_PFProjectRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_PFProjectRuleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_PFProjectRule(Li_PFProjectRule li_PFProjectRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_PFProjectRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
   
            cmd.Parameters.Add("@ProRulId", SqlDbType.Int) .Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = li_PFProjectRule.ProjectId;
            cmd.Parameters.Add("@ProRuleName", SqlDbType.VarChar).Value = li_PFProjectRule.ProRuleName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFProjectRule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFProjectRule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFProjectRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFProjectRule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFProjectRule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@ProRulId"].Value;
        }
    }

    public bool UpdateLi_PFProjectRule(Li_PFProjectRule li_PFProjectRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_PFProjectRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.Parameters.Add("@ProRulId", SqlDbType.Int).Value = li_PFProjectRule.ProRulId;
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int).Value = li_PFProjectRule.ProjectId;
            cmd.Parameters.Add("@ProRuleName", SqlDbType.VarChar).Value = li_PFProjectRule.ProRuleName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_PFProjectRule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_PFProjectRule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_PFProjectRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_PFProjectRule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_PFProjectRule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
