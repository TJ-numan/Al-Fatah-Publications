using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpPayDayManager
{
	public Li_EmpPayDayManager()
	{
	}

    public static List<Li_EmpPayDay> GetAllLi_EmpPayDaies()
    {
        List<Li_EmpPayDay> li_EmpPayDaies = new List<Li_EmpPayDay>();
        SqlLi_EmpPayDayProvider sqlLi_EmpPayDayProvider = new SqlLi_EmpPayDayProvider();
        li_EmpPayDaies = sqlLi_EmpPayDayProvider.GetAllLi_EmpPayDaies();
        return li_EmpPayDaies;
    }


    public static Li_EmpPayDay GetLi_EmpPayDayByID(int id)
    {
        Li_EmpPayDay li_EmpPayDay = new Li_EmpPayDay();
        SqlLi_EmpPayDayProvider sqlLi_EmpPayDayProvider = new SqlLi_EmpPayDayProvider();
        li_EmpPayDay = sqlLi_EmpPayDayProvider.GetLi_EmpPayDayByID(id);
        return li_EmpPayDay;
    }


    public static int InsertLi_EmpPayDay(Li_EmpPayDay li_EmpPayDay)
    {
        SqlLi_EmpPayDayProvider sqlLi_EmpPayDayProvider = new SqlLi_EmpPayDayProvider();
        return sqlLi_EmpPayDayProvider.InsertLi_EmpPayDay(li_EmpPayDay);
    }


    public static bool UpdateLi_EmpPayDay(Li_EmpPayDay li_EmpPayDay)
    {
        SqlLi_EmpPayDayProvider sqlLi_EmpPayDayProvider = new SqlLi_EmpPayDayProvider();
        return sqlLi_EmpPayDayProvider.UpdateLi_EmpPayDay(li_EmpPayDay);
    }

    public static bool DeleteLi_EmpPayDay(int li_EmpPayDayID)
    {
        SqlLi_EmpPayDayProvider sqlLi_EmpPayDayProvider = new SqlLi_EmpPayDayProvider();
        return sqlLi_EmpPayDayProvider.DeleteLi_EmpPayDay(li_EmpPayDayID);
    }
}
