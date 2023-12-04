using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFRuleManager
{
	public Li_PFRuleManager()
	{
	}

    public static List<Li_PFRule> GetAllLi_PFRules()
    {
        List<Li_PFRule> li_PFRules = new List<Li_PFRule>();
        SqlLi_PFRuleProvider sqlLi_PFRuleProvider = new SqlLi_PFRuleProvider();
        li_PFRules = sqlLi_PFRuleProvider.GetAllLi_PFRules();
        return li_PFRules;
    }


    public static Li_PFRule GetLi_PFRuleByID(int id)
    {
        Li_PFRule li_PFRule = new Li_PFRule();
        SqlLi_PFRuleProvider sqlLi_PFRuleProvider = new SqlLi_PFRuleProvider();
        li_PFRule = sqlLi_PFRuleProvider.GetLi_PFRuleByID(id);
        return li_PFRule;
    }


    public static int InsertLi_PFRule(Li_PFRule li_PFRule)
    {
        SqlLi_PFRuleProvider sqlLi_PFRuleProvider = new SqlLi_PFRuleProvider();
        return sqlLi_PFRuleProvider.InsertLi_PFRule(li_PFRule);
    }


    public static bool UpdateLi_PFRule(Li_PFRule li_PFRule)
    {
        SqlLi_PFRuleProvider sqlLi_PFRuleProvider = new SqlLi_PFRuleProvider();
        return sqlLi_PFRuleProvider.UpdateLi_PFRule(li_PFRule);
    }

    public static bool DeleteLi_PFRule(int li_PFRuleID)
    {
        SqlLi_PFRuleProvider sqlLi_PFRuleProvider = new SqlLi_PFRuleProvider();
        return sqlLi_PFRuleProvider.DeleteLi_PFRule(li_PFRuleID);
    }
}
