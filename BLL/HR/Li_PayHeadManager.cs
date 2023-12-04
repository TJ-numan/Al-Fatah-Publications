using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PayHeadManager
{
	public Li_PayHeadManager()
	{
	}

    public static List<Li_PayHead> GetAllLi_PayHeads()
    {
        List<Li_PayHead> li_PayHeads = new List<Li_PayHead>();
        SqlLi_PayHeadProvider sqlLi_PayHeadProvider = new SqlLi_PayHeadProvider();
        li_PayHeads = sqlLi_PayHeadProvider.GetAllLi_PayHeads();
        return li_PayHeads;
    }


    public static Li_PayHead GetLi_PayHeadByID(int id)
    {
        Li_PayHead li_PayHead = new Li_PayHead();
        SqlLi_PayHeadProvider sqlLi_PayHeadProvider = new SqlLi_PayHeadProvider();
        li_PayHead = sqlLi_PayHeadProvider.GetLi_PayHeadByID(id);
        return li_PayHead;
    }


    public static int InsertLi_PayHead(Li_PayHead li_PayHead)
    {
        SqlLi_PayHeadProvider sqlLi_PayHeadProvider = new SqlLi_PayHeadProvider();
        return sqlLi_PayHeadProvider.InsertLi_PayHead(li_PayHead);
    }


    public static bool UpdateLi_PayHead(Li_PayHead li_PayHead)
    {
        SqlLi_PayHeadProvider sqlLi_PayHeadProvider = new SqlLi_PayHeadProvider();
        return sqlLi_PayHeadProvider.UpdateLi_PayHead(li_PayHead);
    }

    public static bool DeleteLi_PayHead(int li_PayHeadID)
    {
        SqlLi_PayHeadProvider sqlLi_PayHeadProvider = new SqlLi_PayHeadProvider();
        return sqlLi_PayHeadProvider.DeleteLi_PayHead(li_PayHeadID);
    }
}
