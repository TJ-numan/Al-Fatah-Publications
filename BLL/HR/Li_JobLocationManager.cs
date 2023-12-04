using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobLocationManager
{
	public Li_JobLocationManager()
	{
	}

    public static List<Li_JobLocation> GetAllLi_JobLocations()
    {
        List<Li_JobLocation> li_JobLocations = new List<Li_JobLocation>();
        SqlLi_JobLocationProvider sqlLi_JobLocationProvider = new SqlLi_JobLocationProvider();
        li_JobLocations = sqlLi_JobLocationProvider.GetAllLi_JobLocations();
        return li_JobLocations;
    }


    public static Li_JobLocation GetLi_JobLocationByID(int id)
    {
        Li_JobLocation li_JobLocation = new Li_JobLocation();
        SqlLi_JobLocationProvider sqlLi_JobLocationProvider = new SqlLi_JobLocationProvider();
        li_JobLocation = sqlLi_JobLocationProvider.GetLi_JobLocationByID(id);
        return li_JobLocation;
    }


    public static int InsertLi_JobLocation(Li_JobLocation li_JobLocation)
    {
        SqlLi_JobLocationProvider sqlLi_JobLocationProvider = new SqlLi_JobLocationProvider();
        return sqlLi_JobLocationProvider.InsertLi_JobLocation(li_JobLocation);
    }


    public static bool UpdateLi_JobLocation(Li_JobLocation li_JobLocation)
    {
        SqlLi_JobLocationProvider sqlLi_JobLocationProvider = new SqlLi_JobLocationProvider();
        return sqlLi_JobLocationProvider.UpdateLi_JobLocation(li_JobLocation);
    }

    public static bool DeleteLi_JobLocation(int li_JobLocationID)
    {
        SqlLi_JobLocationProvider sqlLi_JobLocationProvider = new SqlLi_JobLocationProvider();
        return sqlLi_JobLocationProvider.DeleteLi_JobLocation(li_JobLocationID);
    }
}
