using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_VacancyForManager
{
	public Li_VacancyForManager()
	{
	}

    public static List<Li_VacancyFor> GetAllLi_VacancyFors()
    {
        List<Li_VacancyFor> li_VacancyFors = new List<Li_VacancyFor>();
        SqlLi_VacancyForProvider sqlLi_VacancyForProvider = new SqlLi_VacancyForProvider();
        li_VacancyFors = sqlLi_VacancyForProvider.GetAllLi_VacancyFors();
        return li_VacancyFors;
    }


    public static Li_VacancyFor GetLi_VacancyForByID(int id)
    {
        Li_VacancyFor li_VacancyFor = new Li_VacancyFor();
        SqlLi_VacancyForProvider sqlLi_VacancyForProvider = new SqlLi_VacancyForProvider();
        li_VacancyFor = sqlLi_VacancyForProvider.GetLi_VacancyForByID(id);
        return li_VacancyFor;
    }


    public static int InsertLi_VacancyFor(Li_VacancyFor li_VacancyFor)
    {
        SqlLi_VacancyForProvider sqlLi_VacancyForProvider = new SqlLi_VacancyForProvider();
        return sqlLi_VacancyForProvider.InsertLi_VacancyFor(li_VacancyFor);
    }


    public static bool UpdateLi_VacancyFor(Li_VacancyFor li_VacancyFor)
    {
        SqlLi_VacancyForProvider sqlLi_VacancyForProvider = new SqlLi_VacancyForProvider();
        return sqlLi_VacancyForProvider.UpdateLi_VacancyFor(li_VacancyFor);
    }

    public static bool DeleteLi_VacancyFor(int li_VacancyForID)
    {
        SqlLi_VacancyForProvider sqlLi_VacancyForProvider = new SqlLi_VacancyForProvider();
        return sqlLi_VacancyForProvider.DeleteLi_VacancyFor(li_VacancyForID);
    }
}
