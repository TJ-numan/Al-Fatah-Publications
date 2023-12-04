using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;


public class Li_BinderReturnManager
{
	public Li_BinderReturnManager()
	{
	}

    public static List<Li_BinderReturn> GetAllLi_BinderReturns()
    {
        List<Li_BinderReturn> li_BinderReturns = new List<Li_BinderReturn>();
        SqlLi_BinderReturnProvider sqlLi_BinderReturnProvider = new SqlLi_BinderReturnProvider();
        li_BinderReturns = sqlLi_BinderReturnProvider.GetAllLi_BinderReturns();
        return li_BinderReturns;
    }


    public static Li_BinderReturn GetLi_BinderReturnByID(int id)
    {
        Li_BinderReturn li_BinderReturn = new Li_BinderReturn();
        SqlLi_BinderReturnProvider sqlLi_BinderReturnProvider = new SqlLi_BinderReturnProvider();
        li_BinderReturn = sqlLi_BinderReturnProvider.GetLi_BinderReturnByID(id);
        return li_BinderReturn;
    }


    public static string  InsertLi_BinderReturn(Li_BinderReturn li_BinderReturn)
    {
        SqlLi_BinderReturnProvider sqlLi_BinderReturnProvider = new SqlLi_BinderReturnProvider();
        return sqlLi_BinderReturnProvider.InsertLi_BinderReturn(li_BinderReturn);
    }


    public static bool UpdateLi_BinderReturn(Li_BinderReturn li_BinderReturn)
    {
        SqlLi_BinderReturnProvider sqlLi_BinderReturnProvider = new SqlLi_BinderReturnProvider();
        return sqlLi_BinderReturnProvider.UpdateLi_BinderReturn(li_BinderReturn);
    }

    public static bool DeleteLi_BinderReturn(int li_BinderReturnID)
    {
        SqlLi_BinderReturnProvider sqlLi_BinderReturnProvider = new SqlLi_BinderReturnProvider();
        return sqlLi_BinderReturnProvider.DeleteLi_BinderReturn(li_BinderReturnID);
    }
}
