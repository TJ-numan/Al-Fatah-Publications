using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFProfitDistributionDetailManager
{
	public Li_PFProfitDistributionDetailManager()
	{
	}

    public static List<Li_PFProfitDistributionDetail> GetAllLi_PFProfitDistributionDetails()
    {
        List<Li_PFProfitDistributionDetail> li_PFProfitDistributionDetails = new List<Li_PFProfitDistributionDetail>();
        SqlLi_PFProfitDistributionDetailProvider sqlLi_PFProfitDistributionDetailProvider = new SqlLi_PFProfitDistributionDetailProvider();
        li_PFProfitDistributionDetails = sqlLi_PFProfitDistributionDetailProvider.GetAllLi_PFProfitDistributionDetails();
        return li_PFProfitDistributionDetails;
    }


    public static Li_PFProfitDistributionDetail GetLi_PFProfitDistributionDetailByID(int id)
    {
        Li_PFProfitDistributionDetail li_PFProfitDistributionDetail = new Li_PFProfitDistributionDetail();
        SqlLi_PFProfitDistributionDetailProvider sqlLi_PFProfitDistributionDetailProvider = new SqlLi_PFProfitDistributionDetailProvider();
        li_PFProfitDistributionDetail = sqlLi_PFProfitDistributionDetailProvider.GetLi_PFProfitDistributionDetailByID(id);
        return li_PFProfitDistributionDetail;
    }


    public static int InsertLi_PFProfitDistributionDetail(Li_PFProfitDistributionDetail li_PFProfitDistributionDetail)
    {
        SqlLi_PFProfitDistributionDetailProvider sqlLi_PFProfitDistributionDetailProvider = new SqlLi_PFProfitDistributionDetailProvider();
        return sqlLi_PFProfitDistributionDetailProvider.InsertLi_PFProfitDistributionDetail(li_PFProfitDistributionDetail);
    }


    public static bool UpdateLi_PFProfitDistributionDetail(Li_PFProfitDistributionDetail li_PFProfitDistributionDetail)
    {
        SqlLi_PFProfitDistributionDetailProvider sqlLi_PFProfitDistributionDetailProvider = new SqlLi_PFProfitDistributionDetailProvider();
        return sqlLi_PFProfitDistributionDetailProvider.UpdateLi_PFProfitDistributionDetail(li_PFProfitDistributionDetail);
    }

    public static bool DeleteLi_PFProfitDistributionDetail(int li_PFProfitDistributionDetailID)
    {
        SqlLi_PFProfitDistributionDetailProvider sqlLi_PFProfitDistributionDetailProvider = new SqlLi_PFProfitDistributionDetailProvider();
        return sqlLi_PFProfitDistributionDetailProvider.DeleteLi_PFProfitDistributionDetail(li_PFProfitDistributionDetailID);
    }
}
