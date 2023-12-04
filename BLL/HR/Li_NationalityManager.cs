using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_NationalityManager
{
	public Li_NationalityManager()
	{
	}

    public static List<Li_Nationality> GetAllLi_Nationalities()
    {
        List<Li_Nationality> li_Nationalities = new List<Li_Nationality>();
        SqlLi_NationalityProvider sqlLi_NationalityProvider = new SqlLi_NationalityProvider();
        li_Nationalities = sqlLi_NationalityProvider.GetAllLi_Nationalities();
        return li_Nationalities;
    }


    public static Li_Nationality GetLi_NationalityByID(int id)
    {
        Li_Nationality li_Nationality = new Li_Nationality();
        SqlLi_NationalityProvider sqlLi_NationalityProvider = new SqlLi_NationalityProvider();
        li_Nationality = sqlLi_NationalityProvider.GetLi_NationalityByID(id);
        return li_Nationality;
    }


    public static int InsertLi_Nationality(Li_Nationality li_Nationality)
    {
        SqlLi_NationalityProvider sqlLi_NationalityProvider = new SqlLi_NationalityProvider();
        return sqlLi_NationalityProvider.InsertLi_Nationality(li_Nationality);
    }


    public static bool UpdateLi_Nationality(Li_Nationality li_Nationality)
    {
        SqlLi_NationalityProvider sqlLi_NationalityProvider = new SqlLi_NationalityProvider();
        return sqlLi_NationalityProvider.UpdateLi_Nationality(li_Nationality);
    }

    public static bool DeleteLi_Nationality(int li_NationalityID)
    {
        SqlLi_NationalityProvider sqlLi_NationalityProvider = new SqlLi_NationalityProvider();
        return sqlLi_NationalityProvider.DeleteLi_Nationality(li_NationalityID);
    }
}
