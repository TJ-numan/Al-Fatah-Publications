using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesReponsibilityManager
{
	public Li_JobDesReponsibilityManager()
	{
	}

    public static List<Li_JobDesReponsibility> GetAllLi_JobDesReponsibilities()
    {
        List<Li_JobDesReponsibility> li_JobDesReponsibilities = new List<Li_JobDesReponsibility>();
        SqlLi_JobDesReponsibilityProvider sqlLi_JobDesReponsibilityProvider = new SqlLi_JobDesReponsibilityProvider();
        li_JobDesReponsibilities = sqlLi_JobDesReponsibilityProvider.GetAllLi_JobDesReponsibilities();
        return li_JobDesReponsibilities;
    }


    public static Li_JobDesReponsibility GetLi_JobDesReponsibilityByID(int id)
    {
        Li_JobDesReponsibility li_JobDesReponsibility = new Li_JobDesReponsibility();
        SqlLi_JobDesReponsibilityProvider sqlLi_JobDesReponsibilityProvider = new SqlLi_JobDesReponsibilityProvider();
        li_JobDesReponsibility = sqlLi_JobDesReponsibilityProvider.GetLi_JobDesReponsibilityByID(id);
        return li_JobDesReponsibility;
    }


    public static int InsertLi_JobDesReponsibility(Li_JobDesReponsibility li_JobDesReponsibility)
    {
        SqlLi_JobDesReponsibilityProvider sqlLi_JobDesReponsibilityProvider = new SqlLi_JobDesReponsibilityProvider();
        return sqlLi_JobDesReponsibilityProvider.InsertLi_JobDesReponsibility(li_JobDesReponsibility);
    }


    public static bool UpdateLi_JobDesReponsibility(Li_JobDesReponsibility li_JobDesReponsibility)
    {
        SqlLi_JobDesReponsibilityProvider sqlLi_JobDesReponsibilityProvider = new SqlLi_JobDesReponsibilityProvider();
        return sqlLi_JobDesReponsibilityProvider.UpdateLi_JobDesReponsibility(li_JobDesReponsibility);
    }

    public static bool DeleteLi_JobDesReponsibility(int li_JobDesReponsibilityID)
    {
        SqlLi_JobDesReponsibilityProvider sqlLi_JobDesReponsibilityProvider = new SqlLi_JobDesReponsibilityProvider();
        return sqlLi_JobDesReponsibilityProvider.DeleteLi_JobDesReponsibility(li_JobDesReponsibilityID);
    }
}
