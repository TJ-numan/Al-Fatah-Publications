using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_AdjustChalanManager
{
	public Li_AdjustChalanManager()
	{
	}

    public static List<Li_AdjustChalan> GetAllLi_AdjustChalans()
    {
        List<Li_AdjustChalan> li_AdjustChalans = new List<Li_AdjustChalan>();
        SqlLi_AdjustChalanProvider sqlLi_AdjustChalanProvider = new SqlLi_AdjustChalanProvider();
        li_AdjustChalans = sqlLi_AdjustChalanProvider.GetAllLi_AdjustChalans();
        return li_AdjustChalans;
    }


    public static Li_AdjustChalan GetLi_AdjustChalanByID(int id)
    {
        Li_AdjustChalan li_AdjustChalan = new Li_AdjustChalan();
        SqlLi_AdjustChalanProvider sqlLi_AdjustChalanProvider = new SqlLi_AdjustChalanProvider();
        li_AdjustChalan = sqlLi_AdjustChalanProvider.GetLi_AdjustChalanByID(id);
        return li_AdjustChalan;
    }


    public static string  InsertLi_AdjustChalan(Li_AdjustChalan li_AdjustChalan)
    {
        SqlLi_AdjustChalanProvider sqlLi_AdjustChalanProvider = new SqlLi_AdjustChalanProvider();
        return sqlLi_AdjustChalanProvider.InsertLi_AdjustChalan(li_AdjustChalan);
    }


    public static bool UpdateLi_AdjustChalan(Li_AdjustChalan li_AdjustChalan)
    {
        SqlLi_AdjustChalanProvider sqlLi_AdjustChalanProvider = new SqlLi_AdjustChalanProvider();
        return sqlLi_AdjustChalanProvider.UpdateLi_AdjustChalan(li_AdjustChalan);
    }

    public static bool DeleteLi_AdjustChalan(int li_AdjustChalanID)
    {
        SqlLi_AdjustChalanProvider sqlLi_AdjustChalanProvider = new SqlLi_AdjustChalanProvider();
        return sqlLi_AdjustChalanProvider.DeleteLi_AdjustChalan(li_AdjustChalanID);
    }
}
