using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ApprisalDetailManager
{
	public Li_ApprisalDetailManager()
	{
	}

    public static List<Li_ApprisalDetail> GetAllLi_ApprisalDetails()
    {
        List<Li_ApprisalDetail> li_ApprisalDetails = new List<Li_ApprisalDetail>();
        SqlLi_ApprisalDetailProvider sqlLi_ApprisalDetailProvider = new SqlLi_ApprisalDetailProvider();
        li_ApprisalDetails = sqlLi_ApprisalDetailProvider.GetAllLi_ApprisalDetails();
        return li_ApprisalDetails;
    }


    public static Li_ApprisalDetail GetLi_ApprisalDetailByID(int id)
    {
        Li_ApprisalDetail li_ApprisalDetail = new Li_ApprisalDetail();
        SqlLi_ApprisalDetailProvider sqlLi_ApprisalDetailProvider = new SqlLi_ApprisalDetailProvider();
        li_ApprisalDetail = sqlLi_ApprisalDetailProvider.GetLi_ApprisalDetailByID(id);
        return li_ApprisalDetail;
    }


    public static int InsertLi_ApprisalDetail(Li_ApprisalDetail li_ApprisalDetail)
    {
        SqlLi_ApprisalDetailProvider sqlLi_ApprisalDetailProvider = new SqlLi_ApprisalDetailProvider();
        return sqlLi_ApprisalDetailProvider.InsertLi_ApprisalDetail(li_ApprisalDetail);
    }


    public static bool UpdateLi_ApprisalDetail(Li_ApprisalDetail li_ApprisalDetail)
    {
        SqlLi_ApprisalDetailProvider sqlLi_ApprisalDetailProvider = new SqlLi_ApprisalDetailProvider();
        return sqlLi_ApprisalDetailProvider.UpdateLi_ApprisalDetail(li_ApprisalDetail);
    }

    public static bool DeleteLi_ApprisalDetail(int li_ApprisalDetailID)
    {
        SqlLi_ApprisalDetailProvider sqlLi_ApprisalDetailProvider = new SqlLi_ApprisalDetailProvider();
        return sqlLi_ApprisalDetailProvider.DeleteLi_ApprisalDetail(li_ApprisalDetailID);
    }
}
