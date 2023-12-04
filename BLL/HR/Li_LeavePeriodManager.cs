using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LeavePeriodManager
{
	public Li_LeavePeriodManager()
	{
	}

    public static List<Li_LeavePeriod> GetAllLi_LeavePeriods()
    {
        List<Li_LeavePeriod> li_LeavePeriods = new List<Li_LeavePeriod>();
        SqlLi_LeavePeriodProvider sqlLi_LeavePeriodProvider = new SqlLi_LeavePeriodProvider();
        li_LeavePeriods = sqlLi_LeavePeriodProvider.GetAllLi_LeavePeriods();
        return li_LeavePeriods;
    }


    public static Li_LeavePeriod GetLi_LeavePeriodByID(int id)
    {
        Li_LeavePeriod li_LeavePeriod = new Li_LeavePeriod();
        SqlLi_LeavePeriodProvider sqlLi_LeavePeriodProvider = new SqlLi_LeavePeriodProvider();
        li_LeavePeriod = sqlLi_LeavePeriodProvider.GetLi_LeavePeriodByID(id);
        return li_LeavePeriod;
    }


    public static int InsertLi_LeavePeriod(Li_LeavePeriod li_LeavePeriod)
    {
        SqlLi_LeavePeriodProvider sqlLi_LeavePeriodProvider = new SqlLi_LeavePeriodProvider();
        return sqlLi_LeavePeriodProvider.InsertLi_LeavePeriod(li_LeavePeriod);
    }


    public static bool UpdateLi_LeavePeriod(Li_LeavePeriod li_LeavePeriod)
    {
        SqlLi_LeavePeriodProvider sqlLi_LeavePeriodProvider = new SqlLi_LeavePeriodProvider();
        return sqlLi_LeavePeriodProvider.UpdateLi_LeavePeriod(li_LeavePeriod);
    }

    public static bool DeleteLi_LeavePeriod(int li_LeavePeriodID)
    {
        SqlLi_LeavePeriodProvider sqlLi_LeavePeriodProvider = new SqlLi_LeavePeriodProvider();
        return sqlLi_LeavePeriodProvider.DeleteLi_LeavePeriod(li_LeavePeriodID);
    }
}
