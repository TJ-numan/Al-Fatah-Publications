using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFProjectRuleManager
{
	public Li_PFProjectRuleManager()
	{
	}

    public static List<Li_PFProjectRule> GetAllLi_PFProjectRules()
    {
        List<Li_PFProjectRule> li_PFProjectRules = new List<Li_PFProjectRule>();
        SqlLi_PFProjectRuleProvider sqlLi_PFProjectRuleProvider = new SqlLi_PFProjectRuleProvider();
        li_PFProjectRules = sqlLi_PFProjectRuleProvider.GetAllLi_PFProjectRules();
        return li_PFProjectRules;
    }


    public static Li_PFProjectRule GetLi_PFProjectRuleByID(int id)
    {
        Li_PFProjectRule li_PFProjectRule = new Li_PFProjectRule();
        SqlLi_PFProjectRuleProvider sqlLi_PFProjectRuleProvider = new SqlLi_PFProjectRuleProvider();
        li_PFProjectRule = sqlLi_PFProjectRuleProvider.GetLi_PFProjectRuleByID(id);
        return li_PFProjectRule;
    }


    public static int InsertLi_PFProjectRule(Li_PFProjectRule li_PFProjectRule)
    {
        SqlLi_PFProjectRuleProvider sqlLi_PFProjectRuleProvider = new SqlLi_PFProjectRuleProvider();
        return sqlLi_PFProjectRuleProvider.InsertLi_PFProjectRule(li_PFProjectRule);
    }


    public static bool UpdateLi_PFProjectRule(Li_PFProjectRule li_PFProjectRule)
    {
        SqlLi_PFProjectRuleProvider sqlLi_PFProjectRuleProvider = new SqlLi_PFProjectRuleProvider();
        return sqlLi_PFProjectRuleProvider.UpdateLi_PFProjectRule(li_PFProjectRule);
    }

    public static bool DeleteLi_PFProjectRule(int li_PFProjectRuleID)
    {
        SqlLi_PFProjectRuleProvider sqlLi_PFProjectRuleProvider = new SqlLi_PFProjectRuleProvider();
        return sqlLi_PFProjectRuleProvider.DeleteLi_PFProjectRule(li_PFProjectRuleID);
    }
}
