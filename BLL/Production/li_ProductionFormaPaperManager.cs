using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_ProductionFormaPaperManager
{
	public Li_ProductionFormaPaperManager()
	{
	}

    public static List<Li_ProductionFormaPaper> GetAllLi_ProductionFormaPapers()
    {
        List<Li_ProductionFormaPaper> li_ProductionFormaPapers = new List<Li_ProductionFormaPaper>();
        SqlLi_ProductionFormaPaperProvider sqlLi_ProductionFormaPaperProvider = new SqlLi_ProductionFormaPaperProvider();
        li_ProductionFormaPapers = sqlLi_ProductionFormaPaperProvider.GetAllLi_ProductionFormaPapers();
        return li_ProductionFormaPapers;
    }


    public static Li_ProductionFormaPaper GetLi_ProductionFormaPaperByID(int id)
    {
        Li_ProductionFormaPaper li_ProductionFormaPaper = new Li_ProductionFormaPaper();
        SqlLi_ProductionFormaPaperProvider sqlLi_ProductionFormaPaperProvider = new SqlLi_ProductionFormaPaperProvider();
        li_ProductionFormaPaper = sqlLi_ProductionFormaPaperProvider.GetLi_ProductionFormaPaperByID(id);
        return li_ProductionFormaPaper;
    }


    public static int InsertLi_ProductionFormaPaper(Li_ProductionFormaPaper li_ProductionFormaPaper)
    {
        SqlLi_ProductionFormaPaperProvider sqlLi_ProductionFormaPaperProvider = new SqlLi_ProductionFormaPaperProvider();
        return sqlLi_ProductionFormaPaperProvider.InsertLi_ProductionFormaPaper(li_ProductionFormaPaper);
    }


    public static bool UpdateLi_ProductionFormaPaper(Li_ProductionFormaPaper li_ProductionFormaPaper)
    {
        SqlLi_ProductionFormaPaperProvider sqlLi_ProductionFormaPaperProvider = new SqlLi_ProductionFormaPaperProvider();
        return sqlLi_ProductionFormaPaperProvider.UpdateLi_ProductionFormaPaper(li_ProductionFormaPaper);
    }

    public static bool DeleteLi_ProductionFormaPaper(int li_ProductionFormaPaperID)
    {
        SqlLi_ProductionFormaPaperProvider sqlLi_ProductionFormaPaperProvider = new SqlLi_ProductionFormaPaperProvider();
        return sqlLi_ProductionFormaPaperProvider.DeleteLi_ProductionFormaPaper(li_ProductionFormaPaperID);
    }
}
