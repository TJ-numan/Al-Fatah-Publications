using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_ApprisalCycleManager
{
	public Li_ApprisalCycleManager()
	{
	}

    public static List<Li_ApprisalCycle> GetAllLi_ApprisalCycles()
    {
        List<Li_ApprisalCycle> li_ApprisalCycles = new List<Li_ApprisalCycle>();
        SqlLi_ApprisalCycleProvider sqlLi_ApprisalCycleProvider = new SqlLi_ApprisalCycleProvider();
        li_ApprisalCycles = sqlLi_ApprisalCycleProvider.GetAllLi_ApprisalCycles();
        return li_ApprisalCycles;
    }


    public static Li_ApprisalCycle GetLi_ApprisalCycleByID(int id)
    {
        Li_ApprisalCycle li_ApprisalCycle = new Li_ApprisalCycle();
        SqlLi_ApprisalCycleProvider sqlLi_ApprisalCycleProvider = new SqlLi_ApprisalCycleProvider();
        li_ApprisalCycle = sqlLi_ApprisalCycleProvider.GetLi_ApprisalCycleByID(id);
        return li_ApprisalCycle;
    }


    public static int InsertLi_ApprisalCycle(Li_ApprisalCycle li_ApprisalCycle)
    {
        SqlLi_ApprisalCycleProvider sqlLi_ApprisalCycleProvider = new SqlLi_ApprisalCycleProvider();
        return sqlLi_ApprisalCycleProvider.InsertLi_ApprisalCycle(li_ApprisalCycle);
    }


    public static bool UpdateLi_ApprisalCycle(Li_ApprisalCycle li_ApprisalCycle)
    {
        SqlLi_ApprisalCycleProvider sqlLi_ApprisalCycleProvider = new SqlLi_ApprisalCycleProvider();
        return sqlLi_ApprisalCycleProvider.UpdateLi_ApprisalCycle(li_ApprisalCycle);
    }

    public static bool DeleteLi_ApprisalCycle(int li_ApprisalCycleID)
    {
        SqlLi_ApprisalCycleProvider sqlLi_ApprisalCycleProvider = new SqlLi_ApprisalCycleProvider();
        return sqlLi_ApprisalCycleProvider.DeleteLi_ApprisalCycle(li_ApprisalCycleID);
    }
}
