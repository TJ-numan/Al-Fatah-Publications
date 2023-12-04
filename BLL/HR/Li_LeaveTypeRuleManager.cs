using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LeaveTypeRuleManager
{
	public Li_LeaveTypeRuleManager()
	{
	}

    public static List<Li_LeaveTypeRule> GetAllLi_LeaveTypeRules()
    {
        List<Li_LeaveTypeRule> li_LeaveTypeRules = new List<Li_LeaveTypeRule>();
        SqlLi_LeaveTypeRuleProvider sqlLi_LeaveTypeRuleProvider = new SqlLi_LeaveTypeRuleProvider();
        li_LeaveTypeRules = sqlLi_LeaveTypeRuleProvider.GetAllLi_LeaveTypeRules();
        return li_LeaveTypeRules;
    }


    public static Li_LeaveTypeRule GetLi_LeaveTypeRuleByID(int id)
    {
        Li_LeaveTypeRule li_LeaveTypeRule = new Li_LeaveTypeRule();
        SqlLi_LeaveTypeRuleProvider sqlLi_LeaveTypeRuleProvider = new SqlLi_LeaveTypeRuleProvider();
        li_LeaveTypeRule = sqlLi_LeaveTypeRuleProvider.GetLi_LeaveTypeRuleByID(id);
        return li_LeaveTypeRule;
    }


    public static int InsertLi_LeaveTypeRule(Li_LeaveTypeRule li_LeaveTypeRule)
    {
        SqlLi_LeaveTypeRuleProvider sqlLi_LeaveTypeRuleProvider = new SqlLi_LeaveTypeRuleProvider();
        return sqlLi_LeaveTypeRuleProvider.InsertLi_LeaveTypeRule(li_LeaveTypeRule);
    }


    public static bool UpdateLi_LeaveTypeRule(Li_LeaveTypeRule li_LeaveTypeRule)
    {
        SqlLi_LeaveTypeRuleProvider sqlLi_LeaveTypeRuleProvider = new SqlLi_LeaveTypeRuleProvider();
        return sqlLi_LeaveTypeRuleProvider.UpdateLi_LeaveTypeRule(li_LeaveTypeRule);
    }

    public static bool DeleteLi_LeaveTypeRule(int li_LeaveTypeRuleID)
    {
        SqlLi_LeaveTypeRuleProvider sqlLi_LeaveTypeRuleProvider = new SqlLi_LeaveTypeRuleProvider();
        return sqlLi_LeaveTypeRuleProvider.DeleteLi_LeaveTypeRule(li_LeaveTypeRuleID);
    }
}
