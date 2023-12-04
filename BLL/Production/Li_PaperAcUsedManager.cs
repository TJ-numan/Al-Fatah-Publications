using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PaperAcUsedManager
{
	public Li_PaperAcUsedManager()
	{
	}

    public static List<Li_PaperAcUsed> GetAllLi_PaperAcUseds()
    {
        List<Li_PaperAcUsed> li_PaperAcUseds = new List<Li_PaperAcUsed>();
        SqlLi_PaperAcUsedProvider sqlLi_PaperAcUsedProvider = new SqlLi_PaperAcUsedProvider();
        li_PaperAcUseds = sqlLi_PaperAcUsedProvider.GetAllLi_PaperAcUseds();
        return li_PaperAcUseds;
    }


    public static Li_PaperAcUsed GetLi_PaperAcUsedByID(int id)
    {
        Li_PaperAcUsed li_PaperAcUsed = new Li_PaperAcUsed();
        SqlLi_PaperAcUsedProvider sqlLi_PaperAcUsedProvider = new SqlLi_PaperAcUsedProvider();
        li_PaperAcUsed = sqlLi_PaperAcUsedProvider.GetLi_PaperAcUsedByID(id);
        return li_PaperAcUsed;
    }


    public static int InsertLi_PaperAcUsed(Li_PaperAcUsed li_PaperAcUsed)
    {
        SqlLi_PaperAcUsedProvider sqlLi_PaperAcUsedProvider = new SqlLi_PaperAcUsedProvider();
        return sqlLi_PaperAcUsedProvider.InsertLi_PaperAcUsed(li_PaperAcUsed);
    }


    public static bool UpdateLi_PaperAcUsed(Li_PaperAcUsed li_PaperAcUsed)
    {
        SqlLi_PaperAcUsedProvider sqlLi_PaperAcUsedProvider = new SqlLi_PaperAcUsedProvider();
        return sqlLi_PaperAcUsedProvider.UpdateLi_PaperAcUsed(li_PaperAcUsed);
    }

    public static bool DeleteLi_PaperAcUsed(int li_PaperAcUsedID)
    {
        SqlLi_PaperAcUsedProvider sqlLi_PaperAcUsedProvider = new SqlLi_PaperAcUsedProvider();
        return sqlLi_PaperAcUsedProvider.DeleteLi_PaperAcUsed(li_PaperAcUsedID);
    }
}
