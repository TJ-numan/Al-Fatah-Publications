using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LeaveRuleManager
{
	public Li_LeaveRuleManager()
	{
	}

    public static List<Li_LeaveRule> GetAllLi_LeaveRules()
    {
        List<Li_LeaveRule> li_LeaveRules = new List<Li_LeaveRule>();
        SqlLi_LeaveRuleProvider sqlLi_LeaveRuleProvider = new SqlLi_LeaveRuleProvider();
        li_LeaveRules = sqlLi_LeaveRuleProvider.GetAllLi_LeaveRules();
        return li_LeaveRules;
    }


    public static Li_LeaveRule GetLi_LeaveRuleByID(int id)
    {
        Li_LeaveRule li_LeaveRule = new Li_LeaveRule();
        SqlLi_LeaveRuleProvider sqlLi_LeaveRuleProvider = new SqlLi_LeaveRuleProvider();
        li_LeaveRule = sqlLi_LeaveRuleProvider.GetLi_LeaveRuleByID(id);
        return li_LeaveRule;
    }


    public static int InsertLi_LeaveRule(Li_LeaveRule li_LeaveRule)
    {
        SqlLi_LeaveRuleProvider sqlLi_LeaveRuleProvider = new SqlLi_LeaveRuleProvider();
        return sqlLi_LeaveRuleProvider.InsertLi_LeaveRule(li_LeaveRule);
    }


    public static bool UpdateLi_LeaveRule(Li_LeaveRule li_LeaveRule)
    {
        SqlLi_LeaveRuleProvider sqlLi_LeaveRuleProvider = new SqlLi_LeaveRuleProvider();
        return sqlLi_LeaveRuleProvider.UpdateLi_LeaveRule(li_LeaveRule);
    }

    public static bool DeleteLi_LeaveRule(int li_LeaveRuleID)
    {
        SqlLi_LeaveRuleProvider sqlLi_LeaveRuleProvider = new SqlLi_LeaveRuleProvider();
        return sqlLi_LeaveRuleProvider.DeleteLi_LeaveRule(li_LeaveRuleID);
    }
}
