using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TermReasonManager
{
	public Li_TermReasonManager()
	{
	}

    public static List<Li_TermReason> GetAllLi_TermReasons()
    {
        List<Li_TermReason> li_TermReasons = new List<Li_TermReason>();
        SqlLi_TermReasonProvider sqlLi_TermReasonProvider = new SqlLi_TermReasonProvider();
        li_TermReasons = sqlLi_TermReasonProvider.GetAllLi_TermReasons();
        return li_TermReasons;
    }


    public static Li_TermReason GetLi_TermReasonByID(int id)
    {
        Li_TermReason li_TermReason = new Li_TermReason();
        SqlLi_TermReasonProvider sqlLi_TermReasonProvider = new SqlLi_TermReasonProvider();
        li_TermReason = sqlLi_TermReasonProvider.GetLi_TermReasonByID(id);
        return li_TermReason;
    }


    public static int InsertLi_TermReason(Li_TermReason li_TermReason)
    {
        SqlLi_TermReasonProvider sqlLi_TermReasonProvider = new SqlLi_TermReasonProvider();
        return sqlLi_TermReasonProvider.InsertLi_TermReason(li_TermReason);
    }


    public static bool UpdateLi_TermReason(Li_TermReason li_TermReason)
    {
        SqlLi_TermReasonProvider sqlLi_TermReasonProvider = new SqlLi_TermReasonProvider();
        return sqlLi_TermReasonProvider.UpdateLi_TermReason(li_TermReason);
    }

    public static bool DeleteLi_TermReason(int li_TermReasonID)
    {
        SqlLi_TermReasonProvider sqlLi_TermReasonProvider = new SqlLi_TermReasonProvider();
        return sqlLi_TermReasonProvider.DeleteLi_TermReason(li_TermReasonID);
    }
}
