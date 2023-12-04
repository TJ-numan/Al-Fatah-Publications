using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq; 

public class SqlLi_LeaveTypeRuleProvider:DataAccessObject
{
	public SqlLi_LeaveTypeRuleProvider()
    {
    }


    public bool DeleteLi_LeaveTypeRule(int li_LeaveTypeRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.DeleteLi_LeaveTypeRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LeTyRuId", SqlDbType.Int).Value = li_LeaveTypeRuleID;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (result == 1);
        }
    }

    public List<Li_LeaveTypeRule> GetAllLi_LeaveTypeRules()
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetAllLi_LeaveTypeRules", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.Default);

            return GetLi_LeaveTypeRulesFromReader(reader);
        }
    }
    public List<Li_LeaveTypeRule> GetLi_LeaveTypeRulesFromReader(IDataReader reader)
    {
        List<Li_LeaveTypeRule> li_LeaveTypeRules = new List<Li_LeaveTypeRule>();

        while (reader.Read())
        {
            li_LeaveTypeRules.Add(GetLi_LeaveTypeRuleFromReader(reader));
        }
        return li_LeaveTypeRules;
    }

    public Li_LeaveTypeRule GetLi_LeaveTypeRuleFromReader(IDataReader reader)
    {
        try
        {
            Li_LeaveTypeRule li_LeaveTypeRule = new Li_LeaveTypeRule
                (
                    
                    (int)reader["LeTyRuId"],
                    (int)reader["LeTypId"],
                    (int)reader["LeRuId"],
                    (int)reader["CreatedBy"],
                    (DateTime)reader["CreatedDate"],
                    (int)reader["ModifiedBy"],
                    (DateTime)reader["ModifiedDate"],
                    (int)reader["InfStId"]
                );
             return li_LeaveTypeRule;
        }
        catch(Exception ex)
        {
            return null;
        }
    }

    public Li_LeaveTypeRule GetLi_LeaveTypeRuleByID(int li_LeaveTypeRuleID)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand command = new SqlCommand("HRM.GetLi_LeaveTypeRuleByID", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@LeTyRuId", SqlDbType.Int).Value = li_LeaveTypeRuleID;
            connection.Open();
            IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

            if (reader.Read())
            {
                return GetLi_LeaveTypeRuleFromReader(reader);
            }
            else
            {
                return null;
            }
        }
    }

    public int InsertLi_LeaveTypeRule(Li_LeaveTypeRule li_LeaveTypeRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.InsertLi_LeaveTypeRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.Add("@LeTyRuId", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LeTypId", SqlDbType.Int).Value = li_LeaveTypeRule.LeTypId;
            cmd.Parameters.Add("@LeRuId", SqlDbType.Int).Value = li_LeaveTypeRule.LeRuId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeaveTypeRule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeaveTypeRule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeaveTypeRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeaveTypeRule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeaveTypeRule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return (int)cmd.Parameters["@LeTyRuId"].Value;
        }
    }

    public bool UpdateLi_LeaveTypeRule(Li_LeaveTypeRule li_LeaveTypeRule)
    {
        using (SqlConnection connection = new SqlConnection(this.ConnectionString))
        {
            SqlCommand cmd = new SqlCommand("HRM.UpdateLi_LeaveTypeRule", connection);
            cmd.CommandType = CommandType.StoredProcedure;
      
            cmd.Parameters.Add("@LeTyRuId", SqlDbType.Int).Value = li_LeaveTypeRule.LeTyRuId;
            cmd.Parameters.Add("@LeTypId", SqlDbType.Int).Value = li_LeaveTypeRule.LeTypId;
            cmd.Parameters.Add("@LeRuId", SqlDbType.Int).Value = li_LeaveTypeRule.LeRuId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = li_LeaveTypeRule.CreatedBy;
            cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = li_LeaveTypeRule.CreatedDate;
            cmd.Parameters.Add("@ModifiedBy", SqlDbType.Int).Value = li_LeaveTypeRule.ModifiedBy;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = li_LeaveTypeRule.ModifiedDate;
            cmd.Parameters.Add("@InfStId", SqlDbType.Int).Value = li_LeaveTypeRule.InfStId;
            connection.Open();

            int result = cmd.ExecuteNonQuery();
            return result == 1;
        }
    }
}
