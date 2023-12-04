using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TrainingBenefitManager
{
	public Li_TrainingBenefitManager()
	{
	}

    public static List<Li_TrainingBenefit> GetAllLi_TrainingBenefits()
    {
        List<Li_TrainingBenefit> li_TrainingBenefits = new List<Li_TrainingBenefit>();
        SqlLi_TrainingBenefitProvider sqlLi_TrainingBenefitProvider = new SqlLi_TrainingBenefitProvider();
        li_TrainingBenefits = sqlLi_TrainingBenefitProvider.GetAllLi_TrainingBenefits();
        return li_TrainingBenefits;
    }


    public static Li_TrainingBenefit GetLi_TrainingBenefitByID(int id)
    {
        Li_TrainingBenefit li_TrainingBenefit = new Li_TrainingBenefit();
        SqlLi_TrainingBenefitProvider sqlLi_TrainingBenefitProvider = new SqlLi_TrainingBenefitProvider();
        li_TrainingBenefit = sqlLi_TrainingBenefitProvider.GetLi_TrainingBenefitByID(id);
        return li_TrainingBenefit;
    }


    public static int InsertLi_TrainingBenefit(Li_TrainingBenefit li_TrainingBenefit)
    {
        SqlLi_TrainingBenefitProvider sqlLi_TrainingBenefitProvider = new SqlLi_TrainingBenefitProvider();
        return sqlLi_TrainingBenefitProvider.InsertLi_TrainingBenefit(li_TrainingBenefit);
    }


    public static bool UpdateLi_TrainingBenefit(Li_TrainingBenefit li_TrainingBenefit)
    {
        SqlLi_TrainingBenefitProvider sqlLi_TrainingBenefitProvider = new SqlLi_TrainingBenefitProvider();
        return sqlLi_TrainingBenefitProvider.UpdateLi_TrainingBenefit(li_TrainingBenefit);
    }

    public static bool DeleteLi_TrainingBenefit(int li_TrainingBenefitID)
    {
        SqlLi_TrainingBenefitProvider sqlLi_TrainingBenefitProvider = new SqlLi_TrainingBenefitProvider();
        return sqlLi_TrainingBenefitProvider.DeleteLi_TrainingBenefit(li_TrainingBenefitID);
    }
}
