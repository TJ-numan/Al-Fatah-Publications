using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 
public class Li_DonYearManager
{
	public Li_DonYearManager()
	{
	}

    public static List<Li_DonYear> GetAllLi_DonYears()
    {
        List<Li_DonYear> li_DonYears = new List<Li_DonYear>();
        SqlLi_DonYearProvider sqlLi_DonYearProvider = new SqlLi_DonYearProvider();
        li_DonYears = sqlLi_DonYearProvider.GetAllLi_DonYears();
        return li_DonYears;
    }


    public static Li_DonYear GetLi_DonYearByID(int id)
    {
        Li_DonYear li_DonYear = new Li_DonYear();
        SqlLi_DonYearProvider sqlLi_DonYearProvider = new SqlLi_DonYearProvider();
        li_DonYear = sqlLi_DonYearProvider.GetLi_DonYearByID(id);
        return li_DonYear;
    }


    public static int InsertLi_DonYear(Li_DonYear li_DonYear)
    {
        SqlLi_DonYearProvider sqlLi_DonYearProvider = new SqlLi_DonYearProvider();
        return sqlLi_DonYearProvider.InsertLi_DonYear(li_DonYear);
    }


    public static bool UpdateLi_DonYear(Li_DonYear li_DonYear)
    {
        SqlLi_DonYearProvider sqlLi_DonYearProvider = new SqlLi_DonYearProvider();
        return sqlLi_DonYearProvider.UpdateLi_DonYear(li_DonYear);
    }

    public static bool DeleteLi_DonYear(int li_DonYearID)
    {
        SqlLi_DonYearProvider sqlLi_DonYearProvider = new SqlLi_DonYearProvider();
        return sqlLi_DonYearProvider.DeleteLi_DonYear(li_DonYearID);
    }
}
