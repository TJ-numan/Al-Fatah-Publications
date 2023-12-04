using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesExperienceReqManager
{
	public Li_JobDesExperienceReqManager()
	{
	}

    public static List<Li_JobDesExperienceReq> GetAllLi_JobDesExperienceReqs()
    {
        List<Li_JobDesExperienceReq> li_JobDesExperienceReqs = new List<Li_JobDesExperienceReq>();
        SqlLi_JobDesExperienceReqProvider sqlLi_JobDesExperienceReqProvider = new SqlLi_JobDesExperienceReqProvider();
        li_JobDesExperienceReqs = sqlLi_JobDesExperienceReqProvider.GetAllLi_JobDesExperienceReqs();
        return li_JobDesExperienceReqs;
    }


    public static Li_JobDesExperienceReq GetLi_JobDesExperienceReqByID(int id)
    {
        Li_JobDesExperienceReq li_JobDesExperienceReq = new Li_JobDesExperienceReq();
        SqlLi_JobDesExperienceReqProvider sqlLi_JobDesExperienceReqProvider = new SqlLi_JobDesExperienceReqProvider();
        li_JobDesExperienceReq = sqlLi_JobDesExperienceReqProvider.GetLi_JobDesExperienceReqByID(id);
        return li_JobDesExperienceReq;
    }


    public static int InsertLi_JobDesExperienceReq(Li_JobDesExperienceReq li_JobDesExperienceReq)
    {
        SqlLi_JobDesExperienceReqProvider sqlLi_JobDesExperienceReqProvider = new SqlLi_JobDesExperienceReqProvider();
        return sqlLi_JobDesExperienceReqProvider.InsertLi_JobDesExperienceReq(li_JobDesExperienceReq);
    }


    public static bool UpdateLi_JobDesExperienceReq(Li_JobDesExperienceReq li_JobDesExperienceReq)
    {
        SqlLi_JobDesExperienceReqProvider sqlLi_JobDesExperienceReqProvider = new SqlLi_JobDesExperienceReqProvider();
        return sqlLi_JobDesExperienceReqProvider.UpdateLi_JobDesExperienceReq(li_JobDesExperienceReq);
    }

    public static bool DeleteLi_JobDesExperienceReq(int li_JobDesExperienceReqID)
    {
        SqlLi_JobDesExperienceReqProvider sqlLi_JobDesExperienceReqProvider = new SqlLi_JobDesExperienceReqProvider();
        return sqlLi_JobDesExperienceReqProvider.DeleteLi_JobDesExperienceReq(li_JobDesExperienceReqID);
    }
}
