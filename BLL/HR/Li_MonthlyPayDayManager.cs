using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_MonthlyPayDayManager
{
	public Li_MonthlyPayDayManager()
	{
	}

    public static List<Li_MonthlyPayDay> GetAllLi_MonthlyPayDaies()
    {
        List<Li_MonthlyPayDay> li_MonthlyPayDaies = new List<Li_MonthlyPayDay>();
        SqlLi_MonthlyPayDayProvider sqlLi_MonthlyPayDayProvider = new SqlLi_MonthlyPayDayProvider();
        li_MonthlyPayDaies = sqlLi_MonthlyPayDayProvider.GetAllLi_MonthlyPayDaies();
        return li_MonthlyPayDaies;
    }


    public static Li_MonthlyPayDay GetLi_MonthlyPayDayByID(int id)
    {
        Li_MonthlyPayDay li_MonthlyPayDay = new Li_MonthlyPayDay();
        SqlLi_MonthlyPayDayProvider sqlLi_MonthlyPayDayProvider = new SqlLi_MonthlyPayDayProvider();
        li_MonthlyPayDay = sqlLi_MonthlyPayDayProvider.GetLi_MonthlyPayDayByID(id);
        return li_MonthlyPayDay;
    }


    public static int InsertLi_MonthlyPayDay(Li_MonthlyPayDay li_MonthlyPayDay)
    {
        SqlLi_MonthlyPayDayProvider sqlLi_MonthlyPayDayProvider = new SqlLi_MonthlyPayDayProvider();
        return sqlLi_MonthlyPayDayProvider.InsertLi_MonthlyPayDay(li_MonthlyPayDay);
    }


    public static bool UpdateLi_MonthlyPayDay(Li_MonthlyPayDay li_MonthlyPayDay)
    {
        SqlLi_MonthlyPayDayProvider sqlLi_MonthlyPayDayProvider = new SqlLi_MonthlyPayDayProvider();
        return sqlLi_MonthlyPayDayProvider.UpdateLi_MonthlyPayDay(li_MonthlyPayDay);
    }

    public static bool DeleteLi_MonthlyPayDay(int li_MonthlyPayDayID)
    {
        SqlLi_MonthlyPayDayProvider sqlLi_MonthlyPayDayProvider = new SqlLi_MonthlyPayDayProvider();
        return sqlLi_MonthlyPayDayProvider.DeleteLi_MonthlyPayDay(li_MonthlyPayDayID);
    }
}
