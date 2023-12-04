using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_ProductionInnerPaperManager
{
	public Li_ProductionInnerPaperManager()
	{
	}

    public static List<Li_ProductionInnerPaper> GetAllLi_ProductionInnerPapers()
    {
        List<Li_ProductionInnerPaper> li_ProductionInnerPapers = new List<Li_ProductionInnerPaper>();
        SqlLi_ProductionInnerPaperProvider sqlLi_ProductionInnerPaperProvider = new SqlLi_ProductionInnerPaperProvider();
        li_ProductionInnerPapers = sqlLi_ProductionInnerPaperProvider.GetAllLi_ProductionInnerPapers();
        return li_ProductionInnerPapers;
    }


    public static Li_ProductionInnerPaper GetLi_ProductionInnerPaperByID(int id)
    {
        Li_ProductionInnerPaper li_ProductionInnerPaper = new Li_ProductionInnerPaper();
        SqlLi_ProductionInnerPaperProvider sqlLi_ProductionInnerPaperProvider = new SqlLi_ProductionInnerPaperProvider();
        li_ProductionInnerPaper = sqlLi_ProductionInnerPaperProvider.GetLi_ProductionInnerPaperByID(id);
        return li_ProductionInnerPaper;
    }


    public static int InsertLi_ProductionInnerPaper(Li_ProductionInnerPaper li_ProductionInnerPaper)
    {
        SqlLi_ProductionInnerPaperProvider sqlLi_ProductionInnerPaperProvider = new SqlLi_ProductionInnerPaperProvider();
        return sqlLi_ProductionInnerPaperProvider.InsertLi_ProductionInnerPaper(li_ProductionInnerPaper);
    }


    public static bool UpdateLi_ProductionInnerPaper(Li_ProductionInnerPaper li_ProductionInnerPaper)
    {
        SqlLi_ProductionInnerPaperProvider sqlLi_ProductionInnerPaperProvider = new SqlLi_ProductionInnerPaperProvider();
        return sqlLi_ProductionInnerPaperProvider.UpdateLi_ProductionInnerPaper(li_ProductionInnerPaper);
    }

    public static bool DeleteLi_ProductionInnerPaper(int li_ProductionInnerPaperID)
    {
        SqlLi_ProductionInnerPaperProvider sqlLi_ProductionInnerPaperProvider = new SqlLi_ProductionInnerPaperProvider();
        return sqlLi_ProductionInnerPaperProvider.DeleteLi_ProductionInnerPaper(li_ProductionInnerPaperID);
    }
}
