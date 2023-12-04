using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_CatWiseChalanManager
{
	public Li_CatWiseChalanManager()
	{
	}

    public static List<Li_CatWiseChalan> GetAllLi_CatWiseChalans()
    {
        List<Li_CatWiseChalan> li_CatWiseChalans = new List<Li_CatWiseChalan>();
        SqlLi_CatWiseChalanProvider sqlLi_CatWiseChalanProvider = new SqlLi_CatWiseChalanProvider();
        li_CatWiseChalans = sqlLi_CatWiseChalanProvider.GetAllLi_CatWiseChalans();
        return li_CatWiseChalans;
    }


    public static Li_CatWiseChalan GetLi_CatWiseChalanByID(int id)
    {
        Li_CatWiseChalan li_CatWiseChalan = new Li_CatWiseChalan();
        SqlLi_CatWiseChalanProvider sqlLi_CatWiseChalanProvider = new SqlLi_CatWiseChalanProvider();
        li_CatWiseChalan = sqlLi_CatWiseChalanProvider.GetLi_CatWiseChalanByID(id);
        return li_CatWiseChalan;
    }


    public static int InsertLi_CatWiseChalan(Li_CatWiseChalan li_CatWiseChalan)
    {
        SqlLi_CatWiseChalanProvider sqlLi_CatWiseChalanProvider = new SqlLi_CatWiseChalanProvider();
        return sqlLi_CatWiseChalanProvider.InsertLi_CatWiseChalan(li_CatWiseChalan);
    }


    public static bool UpdateLi_CatWiseChalan(Li_CatWiseChalan li_CatWiseChalan)
    {
        SqlLi_CatWiseChalanProvider sqlLi_CatWiseChalanProvider = new SqlLi_CatWiseChalanProvider();
        return sqlLi_CatWiseChalanProvider.UpdateLi_CatWiseChalan(li_CatWiseChalan);
    }

    public static bool DeleteLi_CatWiseChalan(int li_CatWiseChalanID)
    {
        SqlLi_CatWiseChalanProvider sqlLi_CatWiseChalanProvider = new SqlLi_CatWiseChalanProvider();
        return sqlLi_CatWiseChalanProvider.DeleteLi_CatWiseChalan(li_CatWiseChalanID);
    }
}
