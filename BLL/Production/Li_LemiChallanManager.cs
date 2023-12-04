using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_LemiChallanManager
{
	public Li_LemiChallanManager()
	{
	}

    public static List<Li_LemiChallan> GetAllLi_LemiChallans()
    {
        List<Li_LemiChallan> li_LemiChallans = new List<Li_LemiChallan>();
        SqlLi_LemiChallanProvider sqlLi_LemiChallanProvider = new SqlLi_LemiChallanProvider();
        li_LemiChallans = sqlLi_LemiChallanProvider.GetAllLi_LemiChallans();
        return li_LemiChallans;
    }


    public static Li_LemiChallan GetLi_LemiChallanByID(int id)
    {
        Li_LemiChallan li_LemiChallan = new Li_LemiChallan();
        SqlLi_LemiChallanProvider sqlLi_LemiChallanProvider = new SqlLi_LemiChallanProvider();
        li_LemiChallan = sqlLi_LemiChallanProvider.GetLi_LemiChallanByID(id);
        return li_LemiChallan;
    }


    public static string  InsertLi_LemiChallan(Li_LemiChallan li_LemiChallan)
    {
        SqlLi_LemiChallanProvider sqlLi_LemiChallanProvider = new SqlLi_LemiChallanProvider();
        return sqlLi_LemiChallanProvider.InsertLi_LemiChallan(li_LemiChallan);
    }


    public static bool UpdateLi_LemiChallan(Li_LemiChallan li_LemiChallan)
    {
        SqlLi_LemiChallanProvider sqlLi_LemiChallanProvider = new SqlLi_LemiChallanProvider();
        return sqlLi_LemiChallanProvider.UpdateLi_LemiChallan(li_LemiChallan);
    }

    public static bool DeleteLi_LemiChallan(int li_LemiChallanID)
    {
        SqlLi_LemiChallanProvider sqlLi_LemiChallanProvider = new SqlLi_LemiChallanProvider();
        return sqlLi_LemiChallanProvider.DeleteLi_LemiChallan(li_LemiChallanID);
    }
}
