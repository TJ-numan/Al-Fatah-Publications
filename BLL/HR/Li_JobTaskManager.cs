using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobTaskManager
{
	public Li_JobTaskManager()
	{
	}

    public static List<Li_JobTask> GetAllLi_JobTasks()
    {
        List<Li_JobTask> li_JobTasks = new List<Li_JobTask>();
        SqlLi_JobTaskProvider sqlLi_JobTaskProvider = new SqlLi_JobTaskProvider();
        li_JobTasks = sqlLi_JobTaskProvider.GetAllLi_JobTasks();
        return li_JobTasks;
    }


    public static Li_JobTask GetLi_JobTaskByID(int id)
    {
        Li_JobTask li_JobTask = new Li_JobTask();
        SqlLi_JobTaskProvider sqlLi_JobTaskProvider = new SqlLi_JobTaskProvider();
        li_JobTask = sqlLi_JobTaskProvider.GetLi_JobTaskByID(id);
        return li_JobTask;
    }


    public static int InsertLi_JobTask(Li_JobTask li_JobTask)
    {
        SqlLi_JobTaskProvider sqlLi_JobTaskProvider = new SqlLi_JobTaskProvider();
        return sqlLi_JobTaskProvider.InsertLi_JobTask(li_JobTask);
    }


    public static bool UpdateLi_JobTask(Li_JobTask li_JobTask)
    {
        SqlLi_JobTaskProvider sqlLi_JobTaskProvider = new SqlLi_JobTaskProvider();
        return sqlLi_JobTaskProvider.UpdateLi_JobTask(li_JobTask);
    }

    public static bool DeleteLi_JobTask(int li_JobTaskID)
    {
        SqlLi_JobTaskProvider sqlLi_JobTaskProvider = new SqlLi_JobTaskProvider();
        return sqlLi_JobTaskProvider.DeleteLi_JobTask(li_JobTaskID);
    }
}
