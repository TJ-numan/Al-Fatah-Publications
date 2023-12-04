using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EduResultManager
{
	public Li_EduResultManager()
	{
	}

    public static List<Li_EduResult> GetAllLi_EduResults()
    {
        List<Li_EduResult> li_EduResults = new List<Li_EduResult>();
        SqlLi_EduResultProvider sqlLi_EduResultProvider = new SqlLi_EduResultProvider();
        li_EduResults = sqlLi_EduResultProvider.GetAllLi_EduResults();
        return li_EduResults;
    }


    public static Li_EduResult GetLi_EduResultByID(int id)
    {
        Li_EduResult li_EduResult = new Li_EduResult();
        SqlLi_EduResultProvider sqlLi_EduResultProvider = new SqlLi_EduResultProvider();
        li_EduResult = sqlLi_EduResultProvider.GetLi_EduResultByID(id);
        return li_EduResult;
    }


    public static int InsertLi_EduResult(Li_EduResult li_EduResult)
    {
        SqlLi_EduResultProvider sqlLi_EduResultProvider = new SqlLi_EduResultProvider();
        return sqlLi_EduResultProvider.InsertLi_EduResult(li_EduResult);
    }


    public static bool UpdateLi_EduResult(Li_EduResult li_EduResult)
    {
        SqlLi_EduResultProvider sqlLi_EduResultProvider = new SqlLi_EduResultProvider();
        return sqlLi_EduResultProvider.UpdateLi_EduResult(li_EduResult);
    }

    public static bool DeleteLi_EduResult(int li_EduResultID)
    {
        SqlLi_EduResultProvider sqlLi_EduResultProvider = new SqlLi_EduResultProvider();
        return sqlLi_EduResultProvider.DeleteLi_EduResult(li_EduResultID);
    }
}
