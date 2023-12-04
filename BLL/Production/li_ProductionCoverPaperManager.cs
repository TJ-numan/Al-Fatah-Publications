using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_ProductionCoverPaperManager
{
	public Li_ProductionCoverPaperManager()
	{
	}

    public static List<Li_ProductionCoverPaper> GetAllLi_ProductionCoverPapers()
    {
        List<Li_ProductionCoverPaper> li_ProductionCoverPapers = new List<Li_ProductionCoverPaper>();
        SqlLi_ProductionCoverPaperProvider sqlLi_ProductionCoverPaperProvider = new SqlLi_ProductionCoverPaperProvider();
        li_ProductionCoverPapers = sqlLi_ProductionCoverPaperProvider.GetAllLi_ProductionCoverPapers();
        return li_ProductionCoverPapers;
    }


    public static Li_ProductionCoverPaper GetLi_ProductionCoverPaperByID(int id)
    {
        Li_ProductionCoverPaper li_ProductionCoverPaper = new Li_ProductionCoverPaper();
        SqlLi_ProductionCoverPaperProvider sqlLi_ProductionCoverPaperProvider = new SqlLi_ProductionCoverPaperProvider();
        li_ProductionCoverPaper = sqlLi_ProductionCoverPaperProvider.GetLi_ProductionCoverPaperByID(id);
        return li_ProductionCoverPaper;
    }


    public static int InsertLi_ProductionCoverPaper(Li_ProductionCoverPaper li_ProductionCoverPaper)
    {
        SqlLi_ProductionCoverPaperProvider sqlLi_ProductionCoverPaperProvider = new SqlLi_ProductionCoverPaperProvider();
        return sqlLi_ProductionCoverPaperProvider.InsertLi_ProductionCoverPaper(li_ProductionCoverPaper);
    }


    public static bool UpdateLi_ProductionCoverPaper(Li_ProductionCoverPaper li_ProductionCoverPaper)
    {
        SqlLi_ProductionCoverPaperProvider sqlLi_ProductionCoverPaperProvider = new SqlLi_ProductionCoverPaperProvider();
        return sqlLi_ProductionCoverPaperProvider.UpdateLi_ProductionCoverPaper(li_ProductionCoverPaper);
    }

    public static bool DeleteLi_ProductionCoverPaper(int li_ProductionCoverPaperID)
    {
        SqlLi_ProductionCoverPaperProvider sqlLi_ProductionCoverPaperProvider = new SqlLi_ProductionCoverPaperProvider();
        return sqlLi_ProductionCoverPaperProvider.DeleteLi_ProductionCoverPaper(li_ProductionCoverPaperID);
    }
}
