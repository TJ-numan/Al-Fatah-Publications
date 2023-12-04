using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFContributionManager
{
	public Li_PFContributionManager()
	{
	}

    public static List<Li_PFContribution> GetAllLi_PFContributions()
    {
        List<Li_PFContribution> li_PFContributions = new List<Li_PFContribution>();
        SqlLi_PFContributionProvider sqlLi_PFContributionProvider = new SqlLi_PFContributionProvider();
        li_PFContributions = sqlLi_PFContributionProvider.GetAllLi_PFContributions();
        return li_PFContributions;
    }


    public static Li_PFContribution GetLi_PFContributionByID(int id)
    {
        Li_PFContribution li_PFContribution = new Li_PFContribution();
        SqlLi_PFContributionProvider sqlLi_PFContributionProvider = new SqlLi_PFContributionProvider();
        li_PFContribution = sqlLi_PFContributionProvider.GetLi_PFContributionByID(id);
        return li_PFContribution;
    }


    public static int InsertLi_PFContribution(Li_PFContribution li_PFContribution)
    {
        SqlLi_PFContributionProvider sqlLi_PFContributionProvider = new SqlLi_PFContributionProvider();
        return sqlLi_PFContributionProvider.InsertLi_PFContribution(li_PFContribution);
    }


    public static bool UpdateLi_PFContribution(Li_PFContribution li_PFContribution)
    {
        SqlLi_PFContributionProvider sqlLi_PFContributionProvider = new SqlLi_PFContributionProvider();
        return sqlLi_PFContributionProvider.UpdateLi_PFContribution(li_PFContribution);
    }

    public static bool DeleteLi_PFContribution(int li_PFContributionID)
    {
        SqlLi_PFContributionProvider sqlLi_PFContributionProvider = new SqlLi_PFContributionProvider();
        return sqlLi_PFContributionProvider.DeleteLi_PFContribution(li_PFContributionID);
    }
}
