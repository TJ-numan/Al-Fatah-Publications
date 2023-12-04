using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobTaskMapManager
{
	public Li_JobTaskMapManager()
	{
	}

    public static List<Li_JobTaskMap> GetAllLi_JobTaskMaps()
    {
        List<Li_JobTaskMap> li_JobTaskMaps = new List<Li_JobTaskMap>();
        SqlLi_JobTaskMapProvider sqlLi_JobTaskMapProvider = new SqlLi_JobTaskMapProvider();
        li_JobTaskMaps = sqlLi_JobTaskMapProvider.GetAllLi_JobTaskMaps();
        return li_JobTaskMaps;
    }


    public static Li_JobTaskMap GetLi_JobTaskMapByID(int id)
    {
        Li_JobTaskMap li_JobTaskMap = new Li_JobTaskMap();
        SqlLi_JobTaskMapProvider sqlLi_JobTaskMapProvider = new SqlLi_JobTaskMapProvider();
        li_JobTaskMap = sqlLi_JobTaskMapProvider.GetLi_JobTaskMapByID(id);
        return li_JobTaskMap;
    }


    public static int InsertLi_JobTaskMap(Li_JobTaskMap li_JobTaskMap)
    {
        SqlLi_JobTaskMapProvider sqlLi_JobTaskMapProvider = new SqlLi_JobTaskMapProvider();
        return sqlLi_JobTaskMapProvider.InsertLi_JobTaskMap(li_JobTaskMap);
    }


    public static bool UpdateLi_JobTaskMap(Li_JobTaskMap li_JobTaskMap)
    {
        SqlLi_JobTaskMapProvider sqlLi_JobTaskMapProvider = new SqlLi_JobTaskMapProvider();
        return sqlLi_JobTaskMapProvider.UpdateLi_JobTaskMap(li_JobTaskMap);
    }

    public static bool DeleteLi_JobTaskMap(int li_JobTaskMapID)
    {
        SqlLi_JobTaskMapProvider sqlLi_JobTaskMapProvider = new SqlLi_JobTaskMapProvider();
        return sqlLi_JobTaskMapProvider.DeleteLi_JobTaskMap(li_JobTaskMapID);
    }
}
