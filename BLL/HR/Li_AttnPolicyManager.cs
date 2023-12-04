using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AttnPolicyManager
{
	public Li_AttnPolicyManager()
	{
	}

    public static List<Li_AttnPolicy> GetAllLi_AttnPolicies()
    {
        List<Li_AttnPolicy> li_AttnPolicies = new List<Li_AttnPolicy>();
        SqlLi_AttnPolicyProvider sqlLi_AttnPolicyProvider = new SqlLi_AttnPolicyProvider();
        li_AttnPolicies = sqlLi_AttnPolicyProvider.GetAllLi_AttnPolicies();
        return li_AttnPolicies;
    }


    public static Li_AttnPolicy GetLi_AttnPolicyByID(int id)
    {
        Li_AttnPolicy li_AttnPolicy = new Li_AttnPolicy();
        SqlLi_AttnPolicyProvider sqlLi_AttnPolicyProvider = new SqlLi_AttnPolicyProvider();
        li_AttnPolicy = sqlLi_AttnPolicyProvider.GetLi_AttnPolicyByID(id);
        return li_AttnPolicy;
    }


    public static int InsertLi_AttnPolicy(Li_AttnPolicy li_AttnPolicy)
    {
        SqlLi_AttnPolicyProvider sqlLi_AttnPolicyProvider = new SqlLi_AttnPolicyProvider();
        return sqlLi_AttnPolicyProvider.InsertLi_AttnPolicy(li_AttnPolicy);
    }


    public static bool UpdateLi_AttnPolicy(Li_AttnPolicy li_AttnPolicy)
    {
        SqlLi_AttnPolicyProvider sqlLi_AttnPolicyProvider = new SqlLi_AttnPolicyProvider();
        return sqlLi_AttnPolicyProvider.UpdateLi_AttnPolicy(li_AttnPolicy);
    }

    public static bool DeleteLi_AttnPolicy(int li_AttnPolicyID)
    {
        SqlLi_AttnPolicyProvider sqlLi_AttnPolicyProvider = new SqlLi_AttnPolicyProvider();
        return sqlLi_AttnPolicyProvider.DeleteLi_AttnPolicy(li_AttnPolicyID);
    }
}
