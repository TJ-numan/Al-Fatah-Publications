using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_ZoneManager
{
	public Li_ZoneManager()
	{
	}

    public static List<Li_Zone> GetAllLi_Zones()
    {
        List<Li_Zone> li_Zones = new List<Li_Zone>();
        SqlLi_ZoneProvider sqlLi_ZoneProvider = new SqlLi_ZoneProvider();
        li_Zones = sqlLi_ZoneProvider.GetAllLi_Zones();
        return li_Zones;
    }


    public static List< Li_Zone> GetLi_ZoneByID(int id)
    {
       List<  Li_Zone > li_Zone = new List<Li_Zone> ();
        SqlLi_ZoneProvider sqlLi_ZoneProvider = new SqlLi_ZoneProvider();
        li_Zone = sqlLi_ZoneProvider.GetLi_ZoneByID(id);
        return li_Zone;
    }


    public static int InsertLi_Zone(Li_Zone li_Zone)
    {
        SqlLi_ZoneProvider sqlLi_ZoneProvider = new SqlLi_ZoneProvider();
        return sqlLi_ZoneProvider.InsertLi_Zone(li_Zone);
    }


    public static bool UpdateLi_Zone(Li_Zone li_Zone)
    {
        SqlLi_ZoneProvider sqlLi_ZoneProvider = new SqlLi_ZoneProvider();
        return sqlLi_ZoneProvider.UpdateLi_Zone(li_Zone);
    }

    public static bool DeleteLi_Zone(int li_ZoneID)
    {
        SqlLi_ZoneProvider sqlLi_ZoneProvider = new SqlLi_ZoneProvider();
        return sqlLi_ZoneProvider.DeleteLi_Zone(li_ZoneID);
    }

    public static DataSet GetAll_ZoneWithZoneId(string ZonId)
    {
        SqlLi_ZoneProvider sqlLi_ZoneProvider = new SqlLi_ZoneProvider();
        return sqlLi_ZoneProvider.GetAll_ZoneWithZoneId(ZonId);
    }
}
