using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ApprisalExecutionManager
{
	public Li_ApprisalExecutionManager()
	{
	}

    public static List<Li_ApprisalExecution> GetAllLi_ApprisalExecutions()
    {
        List<Li_ApprisalExecution> li_ApprisalExecutions = new List<Li_ApprisalExecution>();
        SqlLi_ApprisalExecutionProvider sqlLi_ApprisalExecutionProvider = new SqlLi_ApprisalExecutionProvider();
        li_ApprisalExecutions = sqlLi_ApprisalExecutionProvider.GetAllLi_ApprisalExecutions();
        return li_ApprisalExecutions;
    }


    public static Li_ApprisalExecution GetLi_ApprisalExecutionByID(int id)
    {
        Li_ApprisalExecution li_ApprisalExecution = new Li_ApprisalExecution();
        SqlLi_ApprisalExecutionProvider sqlLi_ApprisalExecutionProvider = new SqlLi_ApprisalExecutionProvider();
        li_ApprisalExecution = sqlLi_ApprisalExecutionProvider.GetLi_ApprisalExecutionByID(id);
        return li_ApprisalExecution;
    }


    public static int InsertLi_ApprisalExecution(Li_ApprisalExecution li_ApprisalExecution)
    {
        SqlLi_ApprisalExecutionProvider sqlLi_ApprisalExecutionProvider = new SqlLi_ApprisalExecutionProvider();
        return sqlLi_ApprisalExecutionProvider.InsertLi_ApprisalExecution(li_ApprisalExecution);
    }


    public static bool UpdateLi_ApprisalExecution(Li_ApprisalExecution li_ApprisalExecution)
    {
        SqlLi_ApprisalExecutionProvider sqlLi_ApprisalExecutionProvider = new SqlLi_ApprisalExecutionProvider();
        return sqlLi_ApprisalExecutionProvider.UpdateLi_ApprisalExecution(li_ApprisalExecution);
    }

    public static bool DeleteLi_ApprisalExecution(int li_ApprisalExecutionID)
    {
        SqlLi_ApprisalExecutionProvider sqlLi_ApprisalExecutionProvider = new SqlLi_ApprisalExecutionProvider();
        return sqlLi_ApprisalExecutionProvider.DeleteLi_ApprisalExecution(li_ApprisalExecutionID);
    }
}
