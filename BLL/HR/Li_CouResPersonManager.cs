using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_CouResPersonManager
{
	public Li_CouResPersonManager()
	{
	}

    public static List<Li_CouResPerson> GetAllLi_CouResPersons()
    {
        List<Li_CouResPerson> li_CouResPersons = new List<Li_CouResPerson>();
        SqlLi_CouResPersonProvider sqlLi_CouResPersonProvider = new SqlLi_CouResPersonProvider();
        li_CouResPersons = sqlLi_CouResPersonProvider.GetAllLi_CouResPersons();
        return li_CouResPersons;
    }


    public static Li_CouResPerson GetLi_CouResPersonByID(int id)
    {
        Li_CouResPerson li_CouResPerson = new Li_CouResPerson();
        SqlLi_CouResPersonProvider sqlLi_CouResPersonProvider = new SqlLi_CouResPersonProvider();
        li_CouResPerson = sqlLi_CouResPersonProvider.GetLi_CouResPersonByID(id);
        return li_CouResPerson;
    }


    public static int InsertLi_CouResPerson(Li_CouResPerson li_CouResPerson)
    {
        SqlLi_CouResPersonProvider sqlLi_CouResPersonProvider = new SqlLi_CouResPersonProvider();
        return sqlLi_CouResPersonProvider.InsertLi_CouResPerson(li_CouResPerson);
    }


    public static bool UpdateLi_CouResPerson(Li_CouResPerson li_CouResPerson)
    {
        SqlLi_CouResPersonProvider sqlLi_CouResPersonProvider = new SqlLi_CouResPersonProvider();
        return sqlLi_CouResPersonProvider.UpdateLi_CouResPerson(li_CouResPerson);
    }

    public static bool DeleteLi_CouResPerson(int li_CouResPersonID)
    {
        SqlLi_CouResPersonProvider sqlLi_CouResPersonProvider = new SqlLi_CouResPersonProvider();
        return sqlLi_CouResPersonProvider.DeleteLi_CouResPerson(li_CouResPersonID);
    }
}
