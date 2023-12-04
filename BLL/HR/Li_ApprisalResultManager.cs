using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ApprisalResultManager
{
	public Li_ApprisalResultManager()
	{
	}

    public static List<Li_ApprisalResult> GetAllLi_ApprisalResults()
    {
        List<Li_ApprisalResult> li_ApprisalResults = new List<Li_ApprisalResult>();
        SqlLi_ApprisalResultProvider sqlLi_ApprisalResultProvider = new SqlLi_ApprisalResultProvider();
        li_ApprisalResults = sqlLi_ApprisalResultProvider.GetAllLi_ApprisalResults();
        return li_ApprisalResults;
    }


    public static Li_ApprisalResult GetLi_ApprisalResultByID(int id)
    {
        Li_ApprisalResult li_ApprisalResult = new Li_ApprisalResult();
        SqlLi_ApprisalResultProvider sqlLi_ApprisalResultProvider = new SqlLi_ApprisalResultProvider();
        li_ApprisalResult = sqlLi_ApprisalResultProvider.GetLi_ApprisalResultByID(id);
        return li_ApprisalResult;
    }


    public static int InsertLi_ApprisalResult(Li_ApprisalResult li_ApprisalResult)
    {
        SqlLi_ApprisalResultProvider sqlLi_ApprisalResultProvider = new SqlLi_ApprisalResultProvider();
        return sqlLi_ApprisalResultProvider.InsertLi_ApprisalResult(li_ApprisalResult);
    }


    public static bool UpdateLi_ApprisalResult(Li_ApprisalResult li_ApprisalResult)
    {
        SqlLi_ApprisalResultProvider sqlLi_ApprisalResultProvider = new SqlLi_ApprisalResultProvider();
        return sqlLi_ApprisalResultProvider.UpdateLi_ApprisalResult(li_ApprisalResult);
    }

    public static bool DeleteLi_ApprisalResult(int li_ApprisalResultID)
    {
        SqlLi_ApprisalResultProvider sqlLi_ApprisalResultProvider = new SqlLi_ApprisalResultProvider();
        return sqlLi_ApprisalResultProvider.DeleteLi_ApprisalResult(li_ApprisalResultID);
    }
}
