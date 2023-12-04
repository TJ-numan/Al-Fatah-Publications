using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ExamTitleManager
{
	public Li_ExamTitleManager()
	{
	}

    public static List<Li_ExamTitle> GetAllLi_ExamTitles()
    {
        List<Li_ExamTitle> li_ExamTitles = new List<Li_ExamTitle>();
        SqlLi_ExamTitleProvider sqlLi_ExamTitleProvider = new SqlLi_ExamTitleProvider();
        li_ExamTitles = sqlLi_ExamTitleProvider.GetAllLi_ExamTitles();
        return li_ExamTitles;
    }


    public static Li_ExamTitle GetLi_ExamTitleByID(int id)
    {
        Li_ExamTitle li_ExamTitle = new Li_ExamTitle();
        SqlLi_ExamTitleProvider sqlLi_ExamTitleProvider = new SqlLi_ExamTitleProvider();
        li_ExamTitle = sqlLi_ExamTitleProvider.GetLi_ExamTitleByID(id);
        return li_ExamTitle;
    }


    public static int InsertLi_ExamTitle(Li_ExamTitle li_ExamTitle)
    {
        SqlLi_ExamTitleProvider sqlLi_ExamTitleProvider = new SqlLi_ExamTitleProvider();
        return sqlLi_ExamTitleProvider.InsertLi_ExamTitle(li_ExamTitle);
    }


    public static bool UpdateLi_ExamTitle(Li_ExamTitle li_ExamTitle)
    {
        SqlLi_ExamTitleProvider sqlLi_ExamTitleProvider = new SqlLi_ExamTitleProvider();
        return sqlLi_ExamTitleProvider.UpdateLi_ExamTitle(li_ExamTitle);
    }

    public static bool DeleteLi_ExamTitle(int li_ExamTitleID)
    {
        SqlLi_ExamTitleProvider sqlLi_ExamTitleProvider = new SqlLi_ExamTitleProvider();
        return sqlLi_ExamTitleProvider.DeleteLi_ExamTitle(li_ExamTitleID);
    }
}
