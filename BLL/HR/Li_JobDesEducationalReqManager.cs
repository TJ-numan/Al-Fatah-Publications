using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesEducationalReqManager
{
	public Li_JobDesEducationalReqManager()
	{
	}

    public static List<Li_JobDesEducationalReq> GetAllLi_JobDesEducationalReqs()
    {
        List<Li_JobDesEducationalReq> li_JobDesEducationalReqs = new List<Li_JobDesEducationalReq>();
        SqlLi_JobDesEducationalReqProvider sqlLi_JobDesEducationalReqProvider = new SqlLi_JobDesEducationalReqProvider();
        li_JobDesEducationalReqs = sqlLi_JobDesEducationalReqProvider.GetAllLi_JobDesEducationalReqs();
        return li_JobDesEducationalReqs;
    }


    public static Li_JobDesEducationalReq GetLi_JobDesEducationalReqByID(int id)
    {
        Li_JobDesEducationalReq li_JobDesEducationalReq = new Li_JobDesEducationalReq();
        SqlLi_JobDesEducationalReqProvider sqlLi_JobDesEducationalReqProvider = new SqlLi_JobDesEducationalReqProvider();
        li_JobDesEducationalReq = sqlLi_JobDesEducationalReqProvider.GetLi_JobDesEducationalReqByID(id);
        return li_JobDesEducationalReq;
    }


    public static int InsertLi_JobDesEducationalReq(Li_JobDesEducationalReq li_JobDesEducationalReq)
    {
        SqlLi_JobDesEducationalReqProvider sqlLi_JobDesEducationalReqProvider = new SqlLi_JobDesEducationalReqProvider();
        return sqlLi_JobDesEducationalReqProvider.InsertLi_JobDesEducationalReq(li_JobDesEducationalReq);
    }


    public static bool UpdateLi_JobDesEducationalReq(Li_JobDesEducationalReq li_JobDesEducationalReq)
    {
        SqlLi_JobDesEducationalReqProvider sqlLi_JobDesEducationalReqProvider = new SqlLi_JobDesEducationalReqProvider();
        return sqlLi_JobDesEducationalReqProvider.UpdateLi_JobDesEducationalReq(li_JobDesEducationalReq);
    }

    public static bool DeleteLi_JobDesEducationalReq(int li_JobDesEducationalReqID)
    {
        SqlLi_JobDesEducationalReqProvider sqlLi_JobDesEducationalReqProvider = new SqlLi_JobDesEducationalReqProvider();
        return sqlLi_JobDesEducationalReqProvider.DeleteLi_JobDesEducationalReq(li_JobDesEducationalReqID);
    }
}
