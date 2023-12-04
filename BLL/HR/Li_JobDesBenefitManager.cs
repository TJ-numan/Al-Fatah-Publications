using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesBenefitManager
{
	public Li_JobDesBenefitManager()
	{
	}

    public static List<Li_JobDesBenefit> GetAllLi_JobDesBenefits()
    {
        List<Li_JobDesBenefit> li_JobDesBenefits = new List<Li_JobDesBenefit>();
        SqlLi_JobDesBenefitProvider sqlLi_JobDesBenefitProvider = new SqlLi_JobDesBenefitProvider();
        li_JobDesBenefits = sqlLi_JobDesBenefitProvider.GetAllLi_JobDesBenefits();
        return li_JobDesBenefits;
    }


    public static Li_JobDesBenefit GetLi_JobDesBenefitByID(int id)
    {
        Li_JobDesBenefit li_JobDesBenefit = new Li_JobDesBenefit();
        SqlLi_JobDesBenefitProvider sqlLi_JobDesBenefitProvider = new SqlLi_JobDesBenefitProvider();
        li_JobDesBenefit = sqlLi_JobDesBenefitProvider.GetLi_JobDesBenefitByID(id);
        return li_JobDesBenefit;
    }


    public static int InsertLi_JobDesBenefit(Li_JobDesBenefit li_JobDesBenefit)
    {
        SqlLi_JobDesBenefitProvider sqlLi_JobDesBenefitProvider = new SqlLi_JobDesBenefitProvider();
        return sqlLi_JobDesBenefitProvider.InsertLi_JobDesBenefit(li_JobDesBenefit);
    }


    public static bool UpdateLi_JobDesBenefit(Li_JobDesBenefit li_JobDesBenefit)
    {
        SqlLi_JobDesBenefitProvider sqlLi_JobDesBenefitProvider = new SqlLi_JobDesBenefitProvider();
        return sqlLi_JobDesBenefitProvider.UpdateLi_JobDesBenefit(li_JobDesBenefit);
    }

    public static bool DeleteLi_JobDesBenefit(int li_JobDesBenefitID)
    {
        SqlLi_JobDesBenefitProvider sqlLi_JobDesBenefitProvider = new SqlLi_JobDesBenefitProvider();
        return sqlLi_JobDesBenefitProvider.DeleteLi_JobDesBenefit(li_JobDesBenefitID);
    }
}
