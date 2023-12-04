using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_GoalDetailManager
{
	public Li_GoalDetailManager()
	{
	}

    public static List<Li_GoalDetail> GetAllLi_GoalDetails()
    {
        List<Li_GoalDetail> li_GoalDetails = new List<Li_GoalDetail>();
        SqlLi_GoalDetailProvider sqlLi_GoalDetailProvider = new SqlLi_GoalDetailProvider();
        li_GoalDetails = sqlLi_GoalDetailProvider.GetAllLi_GoalDetails();
        return li_GoalDetails;
    }


    public static Li_GoalDetail GetLi_GoalDetailByID(int id)
    {
        Li_GoalDetail li_GoalDetail = new Li_GoalDetail();
        SqlLi_GoalDetailProvider sqlLi_GoalDetailProvider = new SqlLi_GoalDetailProvider();
        li_GoalDetail = sqlLi_GoalDetailProvider.GetLi_GoalDetailByID(id);
        return li_GoalDetail;
    }


    public static int InsertLi_GoalDetail(Li_GoalDetail li_GoalDetail)
    {
        SqlLi_GoalDetailProvider sqlLi_GoalDetailProvider = new SqlLi_GoalDetailProvider();
        return sqlLi_GoalDetailProvider.InsertLi_GoalDetail(li_GoalDetail);
    }


    public static bool UpdateLi_GoalDetail(Li_GoalDetail li_GoalDetail)
    {
        SqlLi_GoalDetailProvider sqlLi_GoalDetailProvider = new SqlLi_GoalDetailProvider();
        return sqlLi_GoalDetailProvider.UpdateLi_GoalDetail(li_GoalDetail);
    }

    public static bool DeleteLi_GoalDetail(int li_GoalDetailID)
    {
        SqlLi_GoalDetailProvider sqlLi_GoalDetailProvider = new SqlLi_GoalDetailProvider();
        return sqlLi_GoalDetailProvider.DeleteLi_GoalDetail(li_GoalDetailID);
    }
}
