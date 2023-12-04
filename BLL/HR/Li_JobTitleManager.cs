using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobTitleManager
{
	public Li_JobTitleManager()
	{
	}

    public static List<Li_JobTitle> GetAllLi_JobTitles()
    {
        List<Li_JobTitle> li_JobTitles = new List<Li_JobTitle>();
        SqlLi_JobTitleProvider sqlLi_JobTitleProvider = new SqlLi_JobTitleProvider();
        li_JobTitles = sqlLi_JobTitleProvider.GetAllLi_JobTitles();
        return li_JobTitles;
    }


    public static Li_JobTitle GetLi_JobTitleByID(int id)
    {
        Li_JobTitle li_JobTitle = new Li_JobTitle();
        SqlLi_JobTitleProvider sqlLi_JobTitleProvider = new SqlLi_JobTitleProvider();
        li_JobTitle = sqlLi_JobTitleProvider.GetLi_JobTitleByID(id);
        return li_JobTitle;
    }


    public static int InsertLi_JobTitle(Li_JobTitle li_JobTitle)
    {
        SqlLi_JobTitleProvider sqlLi_JobTitleProvider = new SqlLi_JobTitleProvider();
        return sqlLi_JobTitleProvider.InsertLi_JobTitle(li_JobTitle);
    }


    public static bool UpdateLi_JobTitle(Li_JobTitle li_JobTitle)
    {
        SqlLi_JobTitleProvider sqlLi_JobTitleProvider = new SqlLi_JobTitleProvider();
        return sqlLi_JobTitleProvider.UpdateLi_JobTitle(li_JobTitle);
    }

    public static bool DeleteLi_JobTitle(int li_JobTitleID)
    {
        SqlLi_JobTitleProvider sqlLi_JobTitleProvider = new SqlLi_JobTitleProvider();
        return sqlLi_JobTitleProvider.DeleteLi_JobTitle(li_JobTitleID);
    }
}
