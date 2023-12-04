using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpShiftMapManager
{
	public Li_EmpShiftMapManager()
	{
	}

    public static List<Li_EmpShiftMap> GetAllLi_EmpShiftMaps()
    {
        List<Li_EmpShiftMap> li_EmpShiftMaps = new List<Li_EmpShiftMap>();
        SqlLi_EmpShiftMapProvider sqlLi_EmpShiftMapProvider = new SqlLi_EmpShiftMapProvider();
        li_EmpShiftMaps = sqlLi_EmpShiftMapProvider.GetAllLi_EmpShiftMaps();
        return li_EmpShiftMaps;
    }


    public static Li_EmpShiftMap GetLi_EmpShiftMapByID(int id)
    {
        Li_EmpShiftMap li_EmpShiftMap = new Li_EmpShiftMap();
        SqlLi_EmpShiftMapProvider sqlLi_EmpShiftMapProvider = new SqlLi_EmpShiftMapProvider();
        li_EmpShiftMap = sqlLi_EmpShiftMapProvider.GetLi_EmpShiftMapByID(id);
        return li_EmpShiftMap;
    }


    public static int InsertLi_EmpShiftMap(Li_EmpShiftMap li_EmpShiftMap)
    {
        SqlLi_EmpShiftMapProvider sqlLi_EmpShiftMapProvider = new SqlLi_EmpShiftMapProvider();
        return sqlLi_EmpShiftMapProvider.InsertLi_EmpShiftMap(li_EmpShiftMap);
    }


    public static bool UpdateLi_EmpShiftMap(Li_EmpShiftMap li_EmpShiftMap)
    {
        SqlLi_EmpShiftMapProvider sqlLi_EmpShiftMapProvider = new SqlLi_EmpShiftMapProvider();
        return sqlLi_EmpShiftMapProvider.UpdateLi_EmpShiftMap(li_EmpShiftMap);
    }

    public static bool DeleteLi_EmpShiftMap(int li_EmpShiftMapID)
    {
        SqlLi_EmpShiftMapProvider sqlLi_EmpShiftMapProvider = new SqlLi_EmpShiftMapProvider();
        return sqlLi_EmpShiftMapProvider.DeleteLi_EmpShiftMap(li_EmpShiftMapID);
    }
}
