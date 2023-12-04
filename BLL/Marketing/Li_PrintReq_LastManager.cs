using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintReq_LastManager
{
	public Li_PrintReq_LastManager()
	{
	}

    public static List<Li_PrintReq_Last> GetAllLi_PrintReq_Lasts()
    {
        List<Li_PrintReq_Last> li_PrintReq_Lasts = new List<Li_PrintReq_Last>();
        SqlLi_PrintReq_LastProvider sqlLi_PrintReq_LastProvider = new SqlLi_PrintReq_LastProvider();
        li_PrintReq_Lasts = sqlLi_PrintReq_LastProvider.GetAllLi_PrintReq_Lasts();
        return li_PrintReq_Lasts;
    }


    public static Li_PrintReq_Last GetLi_PrintReq_LastByID(int id)
    {
        Li_PrintReq_Last li_PrintReq_Last = new Li_PrintReq_Last();
        SqlLi_PrintReq_LastProvider sqlLi_PrintReq_LastProvider = new SqlLi_PrintReq_LastProvider();
        li_PrintReq_Last = sqlLi_PrintReq_LastProvider.GetLi_PrintReq_LastByID(id);
        return li_PrintReq_Last;
    }


    public static int InsertLi_PrintReq_Last(Li_PrintReq_Last li_PrintReq_Last)
    {
        SqlLi_PrintReq_LastProvider sqlLi_PrintReq_LastProvider = new SqlLi_PrintReq_LastProvider();
        return sqlLi_PrintReq_LastProvider.InsertLi_PrintReq_Last(li_PrintReq_Last);
    }


    public static bool UpdateLi_PrintReq_Last(Li_PrintReq_Last li_PrintReq_Last)
    {
        SqlLi_PrintReq_LastProvider sqlLi_PrintReq_LastProvider = new SqlLi_PrintReq_LastProvider();
        return sqlLi_PrintReq_LastProvider.UpdateLi_PrintReq_Last(li_PrintReq_Last);
    }

    public static bool DeleteLi_PrintReq_Last(int li_PrintReq_LastID)
    {
        SqlLi_PrintReq_LastProvider sqlLi_PrintReq_LastProvider = new SqlLi_PrintReq_LastProvider();
        return sqlLi_PrintReq_LastProvider.DeleteLi_PrintReq_Last(li_PrintReq_LastID);
    }
}
