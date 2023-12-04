using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PrintReqAppliedManager
{
	public Li_PrintReqAppliedManager()
	{
	}

    public static List<Li_PrintReqApplied> GetAllLi_PrintReqApplieds()
    {
        List<Li_PrintReqApplied> li_PrintReqApplieds = new List<Li_PrintReqApplied>();
        SqlLi_PrintReqAppliedProvider sqlLi_PrintReqAppliedProvider = new SqlLi_PrintReqAppliedProvider();
        li_PrintReqApplieds = sqlLi_PrintReqAppliedProvider.GetAllLi_PrintReqApplieds();
        return li_PrintReqApplieds;
    }


    public static Li_PrintReqApplied GetLi_PrintReqAppliedByID(int id)
    {
        Li_PrintReqApplied li_PrintReqApplied = new Li_PrintReqApplied();
        SqlLi_PrintReqAppliedProvider sqlLi_PrintReqAppliedProvider = new SqlLi_PrintReqAppliedProvider();
        li_PrintReqApplied = sqlLi_PrintReqAppliedProvider.GetLi_PrintReqAppliedByID(id);
        return li_PrintReqApplied;
    }


    public static int InsertLi_PrintReqApplied(Li_PrintReqApplied li_PrintReqApplied)
    {
        SqlLi_PrintReqAppliedProvider sqlLi_PrintReqAppliedProvider = new SqlLi_PrintReqAppliedProvider();
        return sqlLi_PrintReqAppliedProvider.InsertLi_PrintReqApplied(li_PrintReqApplied);
    }


    public static bool UpdateLi_PrintReqApplied(Li_PrintReqApplied li_PrintReqApplied)
    {
        SqlLi_PrintReqAppliedProvider sqlLi_PrintReqAppliedProvider = new SqlLi_PrintReqAppliedProvider();
        return sqlLi_PrintReqAppliedProvider.UpdateLi_PrintReqApplied(li_PrintReqApplied);
    }

    public static bool DeleteLi_PrintReqApplied(int li_PrintReqAppliedID)
    {
        SqlLi_PrintReqAppliedProvider sqlLi_PrintReqAppliedProvider = new SqlLi_PrintReqAppliedProvider();
        return sqlLi_PrintReqAppliedProvider.DeleteLi_PrintReqApplied(li_PrintReqAppliedID);
    }
}
