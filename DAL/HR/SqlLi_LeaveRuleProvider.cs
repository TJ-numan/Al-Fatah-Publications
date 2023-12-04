using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 
public class SqlLi_LeaveRuleProvider:DataAccessObject
{
	public SqlLi_LeaveRuleProvider()
    {
    }


    public bool DeleteLi_LeaveRule(int li_LeaveRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_LeaveRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeRuId", SqlDbType.Int).Value = li_LeaveRuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeaveRule> GetAllLi_LeaveRules()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_LeaveRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeaveRulesFromReader(reader);
        }
    }
    public List<Li_LeaveRule> GetLi_LeaveRulesFromReader(IDataReader reader)
    {
        List<Li_LeaveRule> li_LeaveRules = new List<Li_LeaveRule>();

        while (reader.Read())
        {
            li_LeaveRules.Add(GetLi_LeaveRuleFromReader(reader));
        }
        return li_LeaveRules;
    }

    public Li_LeaveRule GetLi_LeaveRuleFromReader(IDataReader reader)
    {
        try
        {
            Li_LeaveRule li_LeaveRule = new Li_LeaveRule
                (
                   
                    (int)reader["LeRuId"],
                    reader["LeRuName"].ToString(),
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_LeaveRule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LeaveRule GetLi_LeaveRuleByID(int li_LeaveRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_LeaveRuleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LeRuId", SqlDbType.Int).Value = li_LeaveRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeaveRuleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LeaveRule(Li_LeaveRule li_LeaveRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_LeaveRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@LeRuId", SqlDbType.Int). Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LeRuName", SqlDbType.VarChar).Value = li_LeaveRule.LeRuName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeaveRule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeaveRule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeaveRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeaveRule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeaveRule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LeRuId"].Value;
        }
    }

    public bool UpdateLi_LeaveRule(Li_LeaveRule li_LeaveRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_LeaveRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
         
            cmd.Parameters.Add("@LeRuId", SqlDbType.Int).Value = li_LeaveRule.LeRuId;
            cmd.Parameters.Add("@LeRuName", SqlDbType.VarChar).Value = li_LeaveRule.LeRuName;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeaveRule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeaveRule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeaveRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeaveRule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeaveRule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
