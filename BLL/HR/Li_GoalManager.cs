using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_GoalManager
{
	public Li_GoalManager()
	{
	}

    public static List<Li_Goal> GetAllLi_Goals()
    {
        List<Li_Goal> li_Goals = new List<Li_Goal>();
        SqlLi_GoalProvider sqlLi_GoalProvider = new SqlLi_GoalProvider();
        li_Goals = sqlLi_GoalProvider.GetAllLi_Goals();
        return li_Goals;
    }


    public static Li_Goal GetLi_GoalByID(int id)
    {
        Li_Goal li_Goal = new Li_Goal();
        SqlLi_GoalProvider sqlLi_GoalProvider = new SqlLi_GoalProvider();
        li_Goal = sqlLi_GoalProvider.GetLi_GoalByID(id);
        return li_Goal;
    }


    public static int InsertLi_Goal(Li_Goal li_Goal)
    {
        SqlLi_GoalProvider sqlLi_GoalProvider = new SqlLi_GoalProvider();
        return sqlLi_GoalProvider.InsertLi_Goal(li_Goal);
    }


    public static bool UpdateLi_Goal(Li_Goal li_Goal)
    {
        SqlLi_GoalProvider sqlLi_GoalProvider = new SqlLi_GoalProvider();
        return sqlLi_GoalProvider.UpdateLi_Goal(li_Goal);
    }

    public static bool DeleteLi_Goal(int li_GoalID)
    {
        SqlLi_GoalProvider sqlLi_GoalProvider = new SqlLi_GoalProvider();
        return sqlLi_GoalProvider.DeleteLi_Goal(li_GoalID);
    }
}
