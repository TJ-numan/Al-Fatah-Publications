using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_CourseOutlineManager
{
	public Li_CourseOutlineManager()
	{
	}

    public static List<Li_CourseOutline> GetAllLi_CourseOutlines()
    {
        List<Li_CourseOutline> li_CourseOutlines = new List<Li_CourseOutline>();
        SqlLi_CourseOutlineProvider sqlLi_CourseOutlineProvider = new SqlLi_CourseOutlineProvider();
        li_CourseOutlines = sqlLi_CourseOutlineProvider.GetAllLi_CourseOutlines();
        return li_CourseOutlines;
    }


    public static Li_CourseOutline GetLi_CourseOutlineByID(int id)
    {
        Li_CourseOutline li_CourseOutline = new Li_CourseOutline();
        SqlLi_CourseOutlineProvider sqlLi_CourseOutlineProvider = new SqlLi_CourseOutlineProvider();
        li_CourseOutline = sqlLi_CourseOutlineProvider.GetLi_CourseOutlineByID(id);
        return li_CourseOutline;
    }


    public static int InsertLi_CourseOutline(Li_CourseOutline li_CourseOutline)
    {
        SqlLi_CourseOutlineProvider sqlLi_CourseOutlineProvider = new SqlLi_CourseOutlineProvider();
        return sqlLi_CourseOutlineProvider.InsertLi_CourseOutline(li_CourseOutline);
    }


    public static bool UpdateLi_CourseOutline(Li_CourseOutline li_CourseOutline)
    {
        SqlLi_CourseOutlineProvider sqlLi_CourseOutlineProvider = new SqlLi_CourseOutlineProvider();
        return sqlLi_CourseOutlineProvider.UpdateLi_CourseOutline(li_CourseOutline);
    }

    public static bool DeleteLi_CourseOutline(int li_CourseOutlineID)
    {
        SqlLi_CourseOutlineProvider sqlLi_CourseOutlineProvider = new SqlLi_CourseOutlineProvider();
        return sqlLi_CourseOutlineProvider.DeleteLi_CourseOutline(li_CourseOutlineID);
    }
}
