using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_WeekendManager
{
	public Li_WeekendManager()
	{
	}

    public static List<Li_Weekend> GetAllLi_Weekends()
    {
        List<Li_Weekend> li_Weekends = new List<Li_Weekend>();
        SqlLi_WeekendProvider sqlLi_WeekendProvider = new SqlLi_WeekendProvider();
        li_Weekends = sqlLi_WeekendProvider.GetAllLi_Weekends();
        return li_Weekends;
    }


    public static Li_Weekend GetLi_WeekendByID(int id)
    {
        Li_Weekend li_Weekend = new Li_Weekend();
        SqlLi_WeekendProvider sqlLi_WeekendProvider = new SqlLi_WeekendProvider();
        li_Weekend = sqlLi_WeekendProvider.GetLi_WeekendByID(id);
        return li_Weekend;
    }


    public static int InsertLi_Weekend(Li_Weekend li_Weekend)
    {
        SqlLi_WeekendProvider sqlLi_WeekendProvider = new SqlLi_WeekendProvider();
        return sqlLi_WeekendProvider.InsertLi_Weekend(li_Weekend);
    }


    public static bool UpdateLi_Weekend(Li_Weekend li_Weekend)
    {
        SqlLi_WeekendProvider sqlLi_WeekendProvider = new SqlLi_WeekendProvider();
        return sqlLi_WeekendProvider.UpdateLi_Weekend(li_Weekend);
    }

    public static bool DeleteLi_Weekend(int li_WeekendID)
    {
        SqlLi_WeekendProvider sqlLi_WeekendProvider = new SqlLi_WeekendProvider();
        return sqlLi_WeekendProvider.DeleteLi_Weekend(li_WeekendID);
    }
}
