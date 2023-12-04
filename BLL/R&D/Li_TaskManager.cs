using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TaskManager
{
	public Li_TaskManager()
	{
	}

    public static List<Li_Task> GetAllLi_Tasks()
    {
        List<Li_Task> li_Tasks = new List<Li_Task>();
        SqlLi_TaskProvider sqlLi_TaskProvider = new SqlLi_TaskProvider();
        li_Tasks = sqlLi_TaskProvider.GetAllLi_Tasks();
        return li_Tasks;
    }


    public static Li_Task GetLi_TaskByID(int id)
    {
        Li_Task li_Task = new Li_Task();
        SqlLi_TaskProvider sqlLi_TaskProvider = new SqlLi_TaskProvider();
        li_Task = sqlLi_TaskProvider.GetLi_TaskByID(id);
        return li_Task;
    }


    public static int InsertLi_Task(Li_Task li_Task)
    {
        SqlLi_TaskProvider sqlLi_TaskProvider = new SqlLi_TaskProvider();
        return sqlLi_TaskProvider.InsertLi_Task(li_Task);
    }


    public static bool UpdateLi_Task(Li_Task li_Task)
    {
        SqlLi_TaskProvider sqlLi_TaskProvider = new SqlLi_TaskProvider();
        return sqlLi_TaskProvider.UpdateLi_Task(li_Task);
    }

    public static bool DeleteLi_Task(int li_TaskID)
    {
        SqlLi_TaskProvider sqlLi_TaskProvider = new SqlLi_TaskProvider();
        return sqlLi_TaskProvider.DeleteLi_Task(li_TaskID);
    }
    //-------------Rezaul Hoosain-------2021-06-01---------------
    public static List<Li_Task> GetAllLi_TasksQawmi()
    {
        List<Li_Task> li_Tasks = new List<Li_Task>();
        SqlLi_TaskProvider sqlLi_TaskProvider = new SqlLi_TaskProvider();
        li_Tasks = sqlLi_TaskProvider.GetAllLi_TasksQawmi();
        return li_Tasks;
    }
    public static List<Li_Task> GetAllLi_TasksGraphics()
    {
        List<Li_Task> li_Tasks = new List<Li_Task>();
        SqlLi_TaskProvider sqlLi_TaskProvider = new SqlLi_TaskProvider();
        li_Tasks = sqlLi_TaskProvider.GetAllLi_TasksGraphics();
        return li_Tasks;
    }
}
