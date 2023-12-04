using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TranferMainToReturnManager
{
	public Li_TranferMainToReturnManager()
	{
	}

    public static List<Li_TranferMainToReturn> GetAllLi_TranferMainToReturns()
    {
        List<Li_TranferMainToReturn> li_TranferMainToReturns = new List<Li_TranferMainToReturn>();
        SqlLi_TranferMainToReturnProvider sqlLi_TranferMainToReturnProvider = new SqlLi_TranferMainToReturnProvider();
        li_TranferMainToReturns = sqlLi_TranferMainToReturnProvider.GetAllLi_TranferMainToReturns();
        return li_TranferMainToReturns;
    }


    public static Li_TranferMainToReturn GetLi_TranferMainToReturnByID(int id)
    {
        Li_TranferMainToReturn li_TranferMainToReturn = new Li_TranferMainToReturn();
        SqlLi_TranferMainToReturnProvider sqlLi_TranferMainToReturnProvider = new SqlLi_TranferMainToReturnProvider();
        li_TranferMainToReturn = sqlLi_TranferMainToReturnProvider.GetLi_TranferMainToReturnByID(id);
        return li_TranferMainToReturn;
    }


    public static string  InsertLi_TranferMainToReturn(Li_TranferMainToReturn li_TranferMainToReturn)
    {
        SqlLi_TranferMainToReturnProvider sqlLi_TranferMainToReturnProvider = new SqlLi_TranferMainToReturnProvider();
        return sqlLi_TranferMainToReturnProvider.InsertLi_TranferMainToReturn(li_TranferMainToReturn);
    }


    public static bool UpdateLi_TranferMainToReturn(Li_TranferMainToReturn li_TranferMainToReturn)
    {
        SqlLi_TranferMainToReturnProvider sqlLi_TranferMainToReturnProvider = new SqlLi_TranferMainToReturnProvider();
        return sqlLi_TranferMainToReturnProvider.UpdateLi_TranferMainToReturn(li_TranferMainToReturn);
    }

    public static bool DeleteLi_TranferMainToReturn(int li_TranferMainToReturnID)
    {
        SqlLi_TranferMainToReturnProvider sqlLi_TranferMainToReturnProvider = new SqlLi_TranferMainToReturnProvider();
        return sqlLi_TranferMainToReturnProvider.DeleteLi_TranferMainToReturn(li_TranferMainToReturnID);
    }
}
