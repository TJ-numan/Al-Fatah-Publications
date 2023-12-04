using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_CompetencyMapManager
{
	public Li_CompetencyMapManager()
	{
	}

    public static List<Li_CompetencyMap> GetAllLi_CompetencyMaps()
    {
        List<Li_CompetencyMap> li_CompetencyMaps = new List<Li_CompetencyMap>();
        SqlLi_CompetencyMapProvider sqlLi_CompetencyMapProvider = new SqlLi_CompetencyMapProvider();
        li_CompetencyMaps = sqlLi_CompetencyMapProvider.GetAllLi_CompetencyMaps();
        return li_CompetencyMaps;
    }


    public static Li_CompetencyMap GetLi_CompetencyMapByID(int id)
    {
        Li_CompetencyMap li_CompetencyMap = new Li_CompetencyMap();
        SqlLi_CompetencyMapProvider sqlLi_CompetencyMapProvider = new SqlLi_CompetencyMapProvider();
        li_CompetencyMap = sqlLi_CompetencyMapProvider.GetLi_CompetencyMapByID(id);
        return li_CompetencyMap;
    }


    public static int InsertLi_CompetencyMap(Li_CompetencyMap li_CompetencyMap)
    {
        SqlLi_CompetencyMapProvider sqlLi_CompetencyMapProvider = new SqlLi_CompetencyMapProvider();
        return sqlLi_CompetencyMapProvider.InsertLi_CompetencyMap(li_CompetencyMap);
    }


    public static bool UpdateLi_CompetencyMap(Li_CompetencyMap li_CompetencyMap)
    {
        SqlLi_CompetencyMapProvider sqlLi_CompetencyMapProvider = new SqlLi_CompetencyMapProvider();
        return sqlLi_CompetencyMapProvider.UpdateLi_CompetencyMap(li_CompetencyMap);
    }

    public static bool DeleteLi_CompetencyMap(int li_CompetencyMapID)
    {
        SqlLi_CompetencyMapProvider sqlLi_CompetencyMapProvider = new SqlLi_CompetencyMapProvider();
        return sqlLi_CompetencyMapProvider.DeleteLi_CompetencyMap(li_CompetencyMapID);
    }
}
