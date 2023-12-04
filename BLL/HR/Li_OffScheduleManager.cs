using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_OffScheduleManager
{
	public Li_OffScheduleManager()
	{
	}

    public static List<Li_OffSchedule> GetAllLi_OffSchedules()
    {
        List<Li_OffSchedule> li_OffSchedules = new List<Li_OffSchedule>();
        SqlLi_OffScheduleProvider sqlLi_OffScheduleProvider = new SqlLi_OffScheduleProvider();
        li_OffSchedules = sqlLi_OffScheduleProvider.GetAllLi_OffSchedules();
        return li_OffSchedules;
    }


    public static Li_OffSchedule GetLi_OffScheduleByID(int id)
    {
        Li_OffSchedule li_OffSchedule = new Li_OffSchedule();
        SqlLi_OffScheduleProvider sqlLi_OffScheduleProvider = new SqlLi_OffScheduleProvider();
        li_OffSchedule = sqlLi_OffScheduleProvider.GetLi_OffScheduleByID(id);
        return li_OffSchedule;
    }


    public static int InsertLi_OffSchedule(Li_OffSchedule li_OffSchedule)
    {
        SqlLi_OffScheduleProvider sqlLi_OffScheduleProvider = new SqlLi_OffScheduleProvider();
        return sqlLi_OffScheduleProvider.InsertLi_OffSchedule(li_OffSchedule);
    }


    public static bool UpdateLi_OffSchedule(Li_OffSchedule li_OffSchedule)
    {
        SqlLi_OffScheduleProvider sqlLi_OffScheduleProvider = new SqlLi_OffScheduleProvider();
        return sqlLi_OffScheduleProvider.UpdateLi_OffSchedule(li_OffSchedule);
    }

    public static bool DeleteLi_OffSchedule(int li_OffScheduleID)
    {
        SqlLi_OffScheduleProvider sqlLi_OffScheduleProvider = new SqlLi_OffScheduleProvider();
        return sqlLi_OffScheduleProvider.DeleteLi_OffSchedule(li_OffScheduleID);
    }
}
