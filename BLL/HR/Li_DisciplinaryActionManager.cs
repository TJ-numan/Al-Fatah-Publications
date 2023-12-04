using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_DisciplinaryActionManager
{
	public Li_DisciplinaryActionManager()
	{
	}

    public static List<Li_DisciplinaryAction> GetAllLi_DisciplinaryActions()
    {
        List<Li_DisciplinaryAction> li_DisciplinaryActions = new List<Li_DisciplinaryAction>();
        SqlLi_DisciplinaryActionProvider sqlLi_DisciplinaryActionProvider = new SqlLi_DisciplinaryActionProvider();
        li_DisciplinaryActions = sqlLi_DisciplinaryActionProvider.GetAllLi_DisciplinaryActions();
        return li_DisciplinaryActions;
    }


    public static Li_DisciplinaryAction GetLi_DisciplinaryActionByID(int id)
    {
        Li_DisciplinaryAction li_DisciplinaryAction = new Li_DisciplinaryAction();
        SqlLi_DisciplinaryActionProvider sqlLi_DisciplinaryActionProvider = new SqlLi_DisciplinaryActionProvider();
        li_DisciplinaryAction = sqlLi_DisciplinaryActionProvider.GetLi_DisciplinaryActionByID(id);
        return li_DisciplinaryAction;
    }


    public static int InsertLi_DisciplinaryAction(Li_DisciplinaryAction li_DisciplinaryAction)
    {
        SqlLi_DisciplinaryActionProvider sqlLi_DisciplinaryActionProvider = new SqlLi_DisciplinaryActionProvider();
        return sqlLi_DisciplinaryActionProvider.InsertLi_DisciplinaryAction(li_DisciplinaryAction);
    }


    public static bool UpdateLi_DisciplinaryAction(Li_DisciplinaryAction li_DisciplinaryAction)
    {
        SqlLi_DisciplinaryActionProvider sqlLi_DisciplinaryActionProvider = new SqlLi_DisciplinaryActionProvider();
        return sqlLi_DisciplinaryActionProvider.UpdateLi_DisciplinaryAction(li_DisciplinaryAction);
    }

    public static bool DeleteLi_DisciplinaryAction(int li_DisciplinaryActionID)
    {
        SqlLi_DisciplinaryActionProvider sqlLi_DisciplinaryActionProvider = new SqlLi_DisciplinaryActionProvider();
        return sqlLi_DisciplinaryActionProvider.DeleteLi_DisciplinaryAction(li_DisciplinaryActionID);
    }
}
