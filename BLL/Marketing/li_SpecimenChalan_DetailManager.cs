using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SpecimenChalan_DetailManager
{
	public Li_SpecimenChalan_DetailManager()
	{
	}

    public static List<Li_SpecimenChalan_Detail> GetAllLi_SpecimenChalan_Details()
    {
        List<Li_SpecimenChalan_Detail> li_SpecimenChalan_Details = new List<Li_SpecimenChalan_Detail>();
        SqlLi_SpecimenChalan_DetailProvider sqlLi_SpecimenChalan_DetailProvider = new SqlLi_SpecimenChalan_DetailProvider();
        li_SpecimenChalan_Details = sqlLi_SpecimenChalan_DetailProvider.GetAllLi_SpecimenChalan_Details();
        return li_SpecimenChalan_Details;
    }


    public static Li_SpecimenChalan_Detail GetLi_SpecimenChalan_DetailByID(int id)
    {
        Li_SpecimenChalan_Detail li_SpecimenChalan_Detail = new Li_SpecimenChalan_Detail();
        SqlLi_SpecimenChalan_DetailProvider sqlLi_SpecimenChalan_DetailProvider = new SqlLi_SpecimenChalan_DetailProvider();
        li_SpecimenChalan_Detail = sqlLi_SpecimenChalan_DetailProvider.GetLi_SpecimenChalan_DetailByID(id);
        return li_SpecimenChalan_Detail;
    }


    public static int InsertLi_SpecimenChalan_Detail(Li_SpecimenChalan_Detail li_SpecimenChalan_Detail)
    {
        SqlLi_SpecimenChalan_DetailProvider sqlLi_SpecimenChalan_DetailProvider = new SqlLi_SpecimenChalan_DetailProvider();
        return sqlLi_SpecimenChalan_DetailProvider.InsertLi_SpecimenChalan_Detail(li_SpecimenChalan_Detail);
    }


    public static bool UpdateLi_SpecimenChalan_Detail(Li_SpecimenChalan_Detail li_SpecimenChalan_Detail)
    {
        SqlLi_SpecimenChalan_DetailProvider sqlLi_SpecimenChalan_DetailProvider = new SqlLi_SpecimenChalan_DetailProvider();
        return sqlLi_SpecimenChalan_DetailProvider.UpdateLi_SpecimenChalan_Detail(li_SpecimenChalan_Detail);
    }

    public static bool DeleteLi_SpecimenChalan_Detail(int li_SpecimenChalan_DetailID)
    {
        SqlLi_SpecimenChalan_DetailProvider sqlLi_SpecimenChalan_DetailProvider = new SqlLi_SpecimenChalan_DetailProvider();
        return sqlLi_SpecimenChalan_DetailProvider.DeleteLi_SpecimenChalan_Detail(li_SpecimenChalan_DetailID);
    }
}
