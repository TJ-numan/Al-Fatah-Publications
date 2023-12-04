using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_HRAnnounceDetailManager
{
	public Li_HRAnnounceDetailManager()
	{
	}

    public static List<Li_HRAnnounceDetail> GetAllLi_HRAnnounceDetails()
    {
        List<Li_HRAnnounceDetail> li_HRAnnounceDetails = new List<Li_HRAnnounceDetail>();
        SqlLi_HRAnnounceDetailProvider sqlLi_HRAnnounceDetailProvider = new SqlLi_HRAnnounceDetailProvider();
        li_HRAnnounceDetails = sqlLi_HRAnnounceDetailProvider.GetAllLi_HRAnnounceDetails();
        return li_HRAnnounceDetails;
    }


    public static Li_HRAnnounceDetail GetLi_HRAnnounceDetailByID(int id)
    {
        Li_HRAnnounceDetail li_HRAnnounceDetail = new Li_HRAnnounceDetail();
        SqlLi_HRAnnounceDetailProvider sqlLi_HRAnnounceDetailProvider = new SqlLi_HRAnnounceDetailProvider();
        li_HRAnnounceDetail = sqlLi_HRAnnounceDetailProvider.GetLi_HRAnnounceDetailByID(id);
        return li_HRAnnounceDetail;
    }


    public static int InsertLi_HRAnnounceDetail(Li_HRAnnounceDetail li_HRAnnounceDetail)
    {
        SqlLi_HRAnnounceDetailProvider sqlLi_HRAnnounceDetailProvider = new SqlLi_HRAnnounceDetailProvider();
        return sqlLi_HRAnnounceDetailProvider.InsertLi_HRAnnounceDetail(li_HRAnnounceDetail);
    }


    public static bool UpdateLi_HRAnnounceDetail(Li_HRAnnounceDetail li_HRAnnounceDetail)
    {
        SqlLi_HRAnnounceDetailProvider sqlLi_HRAnnounceDetailProvider = new SqlLi_HRAnnounceDetailProvider();
        return sqlLi_HRAnnounceDetailProvider.UpdateLi_HRAnnounceDetail(li_HRAnnounceDetail);
    }

    public static bool DeleteLi_HRAnnounceDetail(int li_HRAnnounceDetailID)
    {
        SqlLi_HRAnnounceDetailProvider sqlLi_HRAnnounceDetailProvider = new SqlLi_HRAnnounceDetailProvider();
        return sqlLi_HRAnnounceDetailProvider.DeleteLi_HRAnnounceDetail(li_HRAnnounceDetailID);
    }
}
