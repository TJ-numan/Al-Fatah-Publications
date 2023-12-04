using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LoanAdvanceManager
{
	public Li_LoanAdvanceManager()
	{
	}

    public static List<Li_LoanAdvance> GetAllLi_LoanAdvances()
    {
        List<Li_LoanAdvance> li_LoanAdvances = new List<Li_LoanAdvance>();
        SqlLi_LoanAdvanceProvider sqlLi_LoanAdvanceProvider = new SqlLi_LoanAdvanceProvider();
        li_LoanAdvances = sqlLi_LoanAdvanceProvider.GetAllLi_LoanAdvances();
        return li_LoanAdvances;
    }


    public static Li_LoanAdvance GetLi_LoanAdvanceByID(int id)
    {
        Li_LoanAdvance li_LoanAdvance = new Li_LoanAdvance();
        SqlLi_LoanAdvanceProvider sqlLi_LoanAdvanceProvider = new SqlLi_LoanAdvanceProvider();
        li_LoanAdvance = sqlLi_LoanAdvanceProvider.GetLi_LoanAdvanceByID(id);
        return li_LoanAdvance;
    }


    public static int InsertLi_LoanAdvance(Li_LoanAdvance li_LoanAdvance)
    {
        SqlLi_LoanAdvanceProvider sqlLi_LoanAdvanceProvider = new SqlLi_LoanAdvanceProvider();
        return sqlLi_LoanAdvanceProvider.InsertLi_LoanAdvance(li_LoanAdvance);
    }


    public static bool UpdateLi_LoanAdvance(Li_LoanAdvance li_LoanAdvance)
    {
        SqlLi_LoanAdvanceProvider sqlLi_LoanAdvanceProvider = new SqlLi_LoanAdvanceProvider();
        return sqlLi_LoanAdvanceProvider.UpdateLi_LoanAdvance(li_LoanAdvance);
    }

    public static bool DeleteLi_LoanAdvance(int li_LoanAdvanceID)
    {
        SqlLi_LoanAdvanceProvider sqlLi_LoanAdvanceProvider = new SqlLi_LoanAdvanceProvider();
        return sqlLi_LoanAdvanceProvider.DeleteLi_LoanAdvance(li_LoanAdvanceID);
    }
}
