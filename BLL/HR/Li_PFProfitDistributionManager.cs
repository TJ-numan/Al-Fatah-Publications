using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFProfitDistributionManager
{
	public Li_PFProfitDistributionManager()
	{
	}

    public static List<Li_PFProfitDistribution> GetAllLi_PFProfitDistributions()
    {
        List<Li_PFProfitDistribution> li_PFProfitDistributions = new List<Li_PFProfitDistribution>();
        SqlLi_PFProfitDistributionProvider sqlLi_PFProfitDistributionProvider = new SqlLi_PFProfitDistributionProvider();
        li_PFProfitDistributions = sqlLi_PFProfitDistributionProvider.GetAllLi_PFProfitDistributions();
        return li_PFProfitDistributions;
    }


    public static Li_PFProfitDistribution GetLi_PFProfitDistributionByID(int id)
    {
        Li_PFProfitDistribution li_PFProfitDistribution = new Li_PFProfitDistribution();
        SqlLi_PFProfitDistributionProvider sqlLi_PFProfitDistributionProvider = new SqlLi_PFProfitDistributionProvider();
        li_PFProfitDistribution = sqlLi_PFProfitDistributionProvider.GetLi_PFProfitDistributionByID(id);
        return li_PFProfitDistribution;
    }


    public static int InsertLi_PFProfitDistribution(Li_PFProfitDistribution li_PFProfitDistribution)
    {
        SqlLi_PFProfitDistributionProvider sqlLi_PFProfitDistributionProvider = new SqlLi_PFProfitDistributionProvider();
        return sqlLi_PFProfitDistributionProvider.InsertLi_PFProfitDistribution(li_PFProfitDistribution);
    }


    public static bool UpdateLi_PFProfitDistribution(Li_PFProfitDistribution li_PFProfitDistribution)
    {
        SqlLi_PFProfitDistributionProvider sqlLi_PFProfitDistributionProvider = new SqlLi_PFProfitDistributionProvider();
        return sqlLi_PFProfitDistributionProvider.UpdateLi_PFProfitDistribution(li_PFProfitDistribution);
    }

    public static bool DeleteLi_PFProfitDistribution(int li_PFProfitDistributionID)
    {
        SqlLi_PFProfitDistributionProvider sqlLi_PFProfitDistributionProvider = new SqlLi_PFProfitDistributionProvider();
        return sqlLi_PFProfitDistributionProvider.DeleteLi_PFProfitDistribution(li_PFProfitDistributionID);
    }
}
