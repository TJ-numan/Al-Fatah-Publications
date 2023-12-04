using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFDistributionManager
{
	public Li_PFDistributionManager()
	{
	}

    public static List<Li_PFDistribution> GetAllLi_PFDistributions()
    {
        List<Li_PFDistribution> li_PFDistributions = new List<Li_PFDistribution>();
        SqlLi_PFDistributionProvider sqlLi_PFDistributionProvider = new SqlLi_PFDistributionProvider();
        li_PFDistributions = sqlLi_PFDistributionProvider.GetAllLi_PFDistributions();
        return li_PFDistributions;
    }


    public static Li_PFDistribution GetLi_PFDistributionByID(int id)
    {
        Li_PFDistribution li_PFDistribution = new Li_PFDistribution();
        SqlLi_PFDistributionProvider sqlLi_PFDistributionProvider = new SqlLi_PFDistributionProvider();
        li_PFDistribution = sqlLi_PFDistributionProvider.GetLi_PFDistributionByID(id);
        return li_PFDistribution;
    }


    public static int InsertLi_PFDistribution(Li_PFDistribution li_PFDistribution)
    {
        SqlLi_PFDistributionProvider sqlLi_PFDistributionProvider = new SqlLi_PFDistributionProvider();
        return sqlLi_PFDistributionProvider.InsertLi_PFDistribution(li_PFDistribution);
    }


    public static bool UpdateLi_PFDistribution(Li_PFDistribution li_PFDistribution)
    {
        SqlLi_PFDistributionProvider sqlLi_PFDistributionProvider = new SqlLi_PFDistributionProvider();
        return sqlLi_PFDistributionProvider.UpdateLi_PFDistribution(li_PFDistribution);
    }

    public static bool DeleteLi_PFDistribution(int li_PFDistributionID)
    {
        SqlLi_PFDistributionProvider sqlLi_PFDistributionProvider = new SqlLi_PFDistributionProvider();
        return sqlLi_PFDistributionProvider.DeleteLi_PFDistribution(li_PFDistributionID);
    }
}
