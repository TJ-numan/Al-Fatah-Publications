using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PayGradeManager
{
	public Li_PayGradeManager()
	{
	}

    public static List<Li_PayGrade> GetAllLi_PayGrades()
    {
        List<Li_PayGrade> li_PayGrades = new List<Li_PayGrade>();
        SqlLi_PayGradeProvider sqlLi_PayGradeProvider = new SqlLi_PayGradeProvider();
        li_PayGrades = sqlLi_PayGradeProvider.GetAllLi_PayGrades();
        return li_PayGrades;
    }


    public static Li_PayGrade GetLi_PayGradeByID(int id)
    {
        Li_PayGrade li_PayGrade = new Li_PayGrade();
        SqlLi_PayGradeProvider sqlLi_PayGradeProvider = new SqlLi_PayGradeProvider();
        li_PayGrade = sqlLi_PayGradeProvider.GetLi_PayGradeByID(id);
        return li_PayGrade;
    }


    public static int InsertLi_PayGrade(Li_PayGrade li_PayGrade)
    {
        SqlLi_PayGradeProvider sqlLi_PayGradeProvider = new SqlLi_PayGradeProvider();
        return sqlLi_PayGradeProvider.InsertLi_PayGrade(li_PayGrade);
    }


    public static bool UpdateLi_PayGrade(Li_PayGrade li_PayGrade)
    {
        SqlLi_PayGradeProvider sqlLi_PayGradeProvider = new SqlLi_PayGradeProvider();
        return sqlLi_PayGradeProvider.UpdateLi_PayGrade(li_PayGrade);
    }

    public static bool DeleteLi_PayGrade(int li_PayGradeID)
    {
        SqlLi_PayGradeProvider sqlLi_PayGradeProvider = new SqlLi_PayGradeProvider();
        return sqlLi_PayGradeProvider.DeleteLi_PayGrade(li_PayGradeID);
    }
}
