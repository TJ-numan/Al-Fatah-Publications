using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_CourseManager
{
	public Li_CourseManager()
	{
	}

    public static List<Li_Course> GetAllLi_Courses()
    {
        List<Li_Course> li_Courses = new List<Li_Course>();
        SqlLi_CourseProvider sqlLi_CourseProvider = new SqlLi_CourseProvider();
        li_Courses = sqlLi_CourseProvider.GetAllLi_Courses();
        return li_Courses;
    }


    public static Li_Course GetLi_CourseByID(int id)
    {
        Li_Course li_Course = new Li_Course();
        SqlLi_CourseProvider sqlLi_CourseProvider = new SqlLi_CourseProvider();
        li_Course = sqlLi_CourseProvider.GetLi_CourseByID(id);
        return li_Course;
    }


    public static int InsertLi_Course(Li_Course li_Course)
    {
        SqlLi_CourseProvider sqlLi_CourseProvider = new SqlLi_CourseProvider();
        return sqlLi_CourseProvider.InsertLi_Course(li_Course);
    }


    public static bool UpdateLi_Course(Li_Course li_Course)
    {
        SqlLi_CourseProvider sqlLi_CourseProvider = new SqlLi_CourseProvider();
        return sqlLi_CourseProvider.UpdateLi_Course(li_Course);
    }

    public static bool DeleteLi_Course(int li_CourseID)
    {
        SqlLi_CourseProvider sqlLi_CourseProvider = new SqlLi_CourseProvider();
        return sqlLi_CourseProvider.DeleteLi_Course(li_CourseID);
    }
}
