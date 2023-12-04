using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_VacancyAnounceManager
{
	public Li_VacancyAnounceManager()
	{
	}

    public static List<Li_VacancyAnounce> GetAllLi_VacancyAnounces()
    {
        List<Li_VacancyAnounce> li_VacancyAnounces = new List<Li_VacancyAnounce>();
        SqlLi_VacancyAnounceProvider sqlLi_VacancyAnounceProvider = new SqlLi_VacancyAnounceProvider();
        li_VacancyAnounces = sqlLi_VacancyAnounceProvider.GetAllLi_VacancyAnounces();
        return li_VacancyAnounces;
    }


    public static Li_VacancyAnounce GetLi_VacancyAnounceByID(int id)
    {
        Li_VacancyAnounce li_VacancyAnounce = new Li_VacancyAnounce();
        SqlLi_VacancyAnounceProvider sqlLi_VacancyAnounceProvider = new SqlLi_VacancyAnounceProvider();
        li_VacancyAnounce = sqlLi_VacancyAnounceProvider.GetLi_VacancyAnounceByID(id);
        return li_VacancyAnounce;
    }


    public static int InsertLi_VacancyAnounce(Li_VacancyAnounce li_VacancyAnounce)
    {
        SqlLi_VacancyAnounceProvider sqlLi_VacancyAnounceProvider = new SqlLi_VacancyAnounceProvider();
        return sqlLi_VacancyAnounceProvider.InsertLi_VacancyAnounce(li_VacancyAnounce);
    }


    public static bool UpdateLi_VacancyAnounce(Li_VacancyAnounce li_VacancyAnounce)
    {
        SqlLi_VacancyAnounceProvider sqlLi_VacancyAnounceProvider = new SqlLi_VacancyAnounceProvider();
        return sqlLi_VacancyAnounceProvider.UpdateLi_VacancyAnounce(li_VacancyAnounce);
    }

    public static bool DeleteLi_VacancyAnounce(int li_VacancyAnounceID)
    {
        SqlLi_VacancyAnounceProvider sqlLi_VacancyAnounceProvider = new SqlLi_VacancyAnounceProvider();
        return sqlLi_VacancyAnounceProvider.DeleteLi_VacancyAnounce(li_VacancyAnounceID);
    }
}
