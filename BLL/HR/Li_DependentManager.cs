using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_DependentManager
{
	public Li_DependentManager()
	{
	}

    public static List<Li_Dependent> GetAllLi_Dependents()
    {
        List<Li_Dependent> li_Dependents = new List<Li_Dependent>();
        SqlLi_DependentProvider sqlLi_DependentProvider = new SqlLi_DependentProvider();
        li_Dependents = sqlLi_DependentProvider.GetAllLi_Dependents();
        return li_Dependents;
    }


    public static Li_Dependent GetLi_DependentByID(int id)
    {
        Li_Dependent li_Dependent = new Li_Dependent();
        SqlLi_DependentProvider sqlLi_DependentProvider = new SqlLi_DependentProvider();
        li_Dependent = sqlLi_DependentProvider.GetLi_DependentByID(id);
        return li_Dependent;
    }


    public static int InsertLi_Dependent(Li_Dependent li_Dependent)
    {
        SqlLi_DependentProvider sqlLi_DependentProvider = new SqlLi_DependentProvider();
        return sqlLi_DependentProvider.InsertLi_Dependent(li_Dependent);
    }


    public static bool UpdateLi_Dependent(Li_Dependent li_Dependent)
    {
        SqlLi_DependentProvider sqlLi_DependentProvider = new SqlLi_DependentProvider();
        return sqlLi_DependentProvider.UpdateLi_Dependent(li_Dependent);
    }

    public static bool DeleteLi_Dependent(int li_DependentID)
    {
        SqlLi_DependentProvider sqlLi_DependentProvider = new SqlLi_DependentProvider();
        return sqlLi_DependentProvider.DeleteLi_Dependent(li_DependentID);
    }

    public static DataTable  LoadGvDependents()
    {
        SqlLi_DependentProvider sqlLi_DependentProvider = new SqlLi_DependentProvider();
        return sqlLi_DependentProvider. LoadGvDependents();
    }
}
