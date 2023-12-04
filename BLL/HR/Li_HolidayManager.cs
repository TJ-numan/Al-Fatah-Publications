using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_HolidayManager
{
	public Li_HolidayManager()
	{
	}

    public static List<Li_Holiday> GetAllLi_Holidaies()
    {
        List<Li_Holiday> li_Holidaies = new List<Li_Holiday>();
        SqlLi_HolidayProvider sqlLi_HolidayProvider = new SqlLi_HolidayProvider();
        li_Holidaies = sqlLi_HolidayProvider.GetAllLi_Holidaies();
        return li_Holidaies;
    }


    public static Li_Holiday GetLi_HolidayByID(int id)
    {
        Li_Holiday li_Holiday = new Li_Holiday();
        SqlLi_HolidayProvider sqlLi_HolidayProvider = new SqlLi_HolidayProvider();
        li_Holiday = sqlLi_HolidayProvider.GetLi_HolidayByID(id);
        return li_Holiday;
    }


    public static int InsertLi_Holiday(Li_Holiday li_Holiday)
    {
        SqlLi_HolidayProvider sqlLi_HolidayProvider = new SqlLi_HolidayProvider();
        return sqlLi_HolidayProvider.InsertLi_Holiday(li_Holiday);
    }


    public static bool UpdateLi_Holiday(Li_Holiday li_Holiday)
    {
        SqlLi_HolidayProvider sqlLi_HolidayProvider = new SqlLi_HolidayProvider();
        return sqlLi_HolidayProvider.UpdateLi_Holiday(li_Holiday);
    }

    public static bool DeleteLi_Holiday(int li_HolidayID)
    {
        SqlLi_HolidayProvider sqlLi_HolidayProvider = new SqlLi_HolidayProvider();
        return sqlLi_HolidayProvider.DeleteLi_Holiday(li_HolidayID);
    }
}
