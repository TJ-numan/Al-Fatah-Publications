using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_HRAnnounceManager
{
	public Li_HRAnnounceManager()
	{
	}

    public static List<Li_HRAnnounce> GetAllLi_HRAnnounces()
    {
        List<Li_HRAnnounce> li_HRAnnounces = new List<Li_HRAnnounce>();
        SqlLi_HRAnnounceProvider sqlLi_HRAnnounceProvider = new SqlLi_HRAnnounceProvider();
        li_HRAnnounces = sqlLi_HRAnnounceProvider.GetAllLi_HRAnnounces();
        return li_HRAnnounces;
    }


    public static Li_HRAnnounce GetLi_HRAnnounceByID(int id)
    {
        Li_HRAnnounce li_HRAnnounce = new Li_HRAnnounce();
        SqlLi_HRAnnounceProvider sqlLi_HRAnnounceProvider = new SqlLi_HRAnnounceProvider();
        li_HRAnnounce = sqlLi_HRAnnounceProvider.GetLi_HRAnnounceByID(id);
        return li_HRAnnounce;
    }


    public static int InsertLi_HRAnnounce(Li_HRAnnounce li_HRAnnounce)
    {
        SqlLi_HRAnnounceProvider sqlLi_HRAnnounceProvider = new SqlLi_HRAnnounceProvider();
        return sqlLi_HRAnnounceProvider.InsertLi_HRAnnounce(li_HRAnnounce);
    }


    public static bool UpdateLi_HRAnnounce(Li_HRAnnounce li_HRAnnounce)
    {
        SqlLi_HRAnnounceProvider sqlLi_HRAnnounceProvider = new SqlLi_HRAnnounceProvider();
        return sqlLi_HRAnnounceProvider.UpdateLi_HRAnnounce(li_HRAnnounce);
    }

    public static bool DeleteLi_HRAnnounce(int li_HRAnnounceID)
    {
        SqlLi_HRAnnounceProvider sqlLi_HRAnnounceProvider = new SqlLi_HRAnnounceProvider();
        return sqlLi_HRAnnounceProvider.DeleteLi_HRAnnounce(li_HRAnnounceID);
    }
}
