using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SendForRebindManager
{
	public Li_SendForRebindManager()
	{
	}

    public static List<Li_SendForRebind> GetAllLi_SendForRebinds()
    {
        List<Li_SendForRebind> li_SendForRebinds = new List<Li_SendForRebind>();
        SqlLi_SendForRebindProvider sqlLi_SendForRebindProvider = new SqlLi_SendForRebindProvider();
        li_SendForRebinds = sqlLi_SendForRebindProvider.GetAllLi_SendForRebinds();
        return li_SendForRebinds;
    }


    public static Li_SendForRebind GetLi_SendForRebindByID(int id)
    {
        Li_SendForRebind li_SendForRebind = new Li_SendForRebind();
        SqlLi_SendForRebindProvider sqlLi_SendForRebindProvider = new SqlLi_SendForRebindProvider();
        li_SendForRebind = sqlLi_SendForRebindProvider.GetLi_SendForRebindByID(id);
        return li_SendForRebind;
    }


    public static string  InsertLi_SendForRebind(Li_SendForRebind li_SendForRebind)
    {
        SqlLi_SendForRebindProvider sqlLi_SendForRebindProvider = new SqlLi_SendForRebindProvider();
        return sqlLi_SendForRebindProvider.InsertLi_SendForRebind(li_SendForRebind);
    }


    public static bool UpdateLi_SendForRebind(Li_SendForRebind li_SendForRebind)
    {
        SqlLi_SendForRebindProvider sqlLi_SendForRebindProvider = new SqlLi_SendForRebindProvider();
        return sqlLi_SendForRebindProvider.UpdateLi_SendForRebind(li_SendForRebind);
    }

    public static bool DeleteLi_SendForRebind(int li_SendForRebindID)
    {
        SqlLi_SendForRebindProvider sqlLi_SendForRebindProvider = new SqlLi_SendForRebindProvider();
        return sqlLi_SendForRebindProvider.DeleteLi_SendForRebind(li_SendForRebindID);
    }
}
