using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_RND_Plan_DetailManager
{
	public Li_RND_Plan_DetailManager()
	{
	}

    public static List<Li_RND_Plan_Detail> GetAllLi_RND_Plan_Details()
    {
        List<Li_RND_Plan_Detail> li_RND_Plan_Details = new List<Li_RND_Plan_Detail>();
        SqlLi_RND_Plan_DetailProvider sqlLi_RND_Plan_DetailProvider = new SqlLi_RND_Plan_DetailProvider();
        li_RND_Plan_Details = sqlLi_RND_Plan_DetailProvider.GetAllLi_RND_Plan_Details();
        return li_RND_Plan_Details;
    }


    public static Li_RND_Plan_Detail GetLi_RND_Plan_DetailByID(int id)
    {
        Li_RND_Plan_Detail li_RND_Plan_Detail = new Li_RND_Plan_Detail();
        SqlLi_RND_Plan_DetailProvider sqlLi_RND_Plan_DetailProvider = new SqlLi_RND_Plan_DetailProvider();
        li_RND_Plan_Detail = sqlLi_RND_Plan_DetailProvider.GetLi_RND_Plan_DetailByID(id);
        return li_RND_Plan_Detail;
    }


    public static int InsertLi_RND_Plan_Detail(Li_RND_Plan_Detail li_RND_Plan_Detail)
    {
        SqlLi_RND_Plan_DetailProvider sqlLi_RND_Plan_DetailProvider = new SqlLi_RND_Plan_DetailProvider();
        return sqlLi_RND_Plan_DetailProvider.InsertLi_RND_Plan_Detail(li_RND_Plan_Detail);
    }


    public static bool UpdateLi_RND_Plan_Detail(Li_RND_Plan_Detail li_RND_Plan_Detail)
    {
        SqlLi_RND_Plan_DetailProvider sqlLi_RND_Plan_DetailProvider = new SqlLi_RND_Plan_DetailProvider();
        return sqlLi_RND_Plan_DetailProvider.UpdateLi_RND_Plan_Detail(li_RND_Plan_Detail);
    }

    public static bool DeleteLi_RND_Plan_Detail(int li_RND_Plan_DetailID)
    {
        SqlLi_RND_Plan_DetailProvider sqlLi_RND_Plan_DetailProvider = new SqlLi_RND_Plan_DetailProvider();
        return sqlLi_RND_Plan_DetailProvider.DeleteLi_RND_Plan_Detail(li_RND_Plan_DetailID);
    }
}
