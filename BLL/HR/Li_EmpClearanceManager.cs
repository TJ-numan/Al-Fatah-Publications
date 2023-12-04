using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpClearanceManager
{
	public Li_EmpClearanceManager()
	{
	}

    public static List<Li_EmpClearance> GetAllLi_EmpClearances()
    {
        List<Li_EmpClearance> li_EmpClearances = new List<Li_EmpClearance>();
        SqlLi_EmpClearanceProvider sqlLi_EmpClearanceProvider = new SqlLi_EmpClearanceProvider();
        li_EmpClearances = sqlLi_EmpClearanceProvider.GetAllLi_EmpClearances();
        return li_EmpClearances;
    }


    public static Li_EmpClearance GetLi_EmpClearanceByID(int id)
    {
        Li_EmpClearance li_EmpClearance = new Li_EmpClearance();
        SqlLi_EmpClearanceProvider sqlLi_EmpClearanceProvider = new SqlLi_EmpClearanceProvider();
        li_EmpClearance = sqlLi_EmpClearanceProvider.GetLi_EmpClearanceByID(id);
        return li_EmpClearance;
    }


    public static int InsertLi_EmpClearance(Li_EmpClearance li_EmpClearance)
    {
        SqlLi_EmpClearanceProvider sqlLi_EmpClearanceProvider = new SqlLi_EmpClearanceProvider();
        return sqlLi_EmpClearanceProvider.InsertLi_EmpClearance(li_EmpClearance);
    }


    public static bool UpdateLi_EmpClearance(Li_EmpClearance li_EmpClearance)
    {
        SqlLi_EmpClearanceProvider sqlLi_EmpClearanceProvider = new SqlLi_EmpClearanceProvider();
        return sqlLi_EmpClearanceProvider.UpdateLi_EmpClearance(li_EmpClearance);
    }

    public static bool DeleteLi_EmpClearance(int li_EmpClearanceID)
    {
        SqlLi_EmpClearanceProvider sqlLi_EmpClearanceProvider = new SqlLi_EmpClearanceProvider();
        return sqlLi_EmpClearanceProvider.DeleteLi_EmpClearance(li_EmpClearanceID);
    }
}
