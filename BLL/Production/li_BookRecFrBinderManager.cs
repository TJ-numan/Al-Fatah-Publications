using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookRecFrBinderManager
{
	public Li_BookRecFrBinderManager()
	{
	}

    public static List<Li_BookRecFrBinder> GetAllLi_BookRecFrBinders()
    {
        List<Li_BookRecFrBinder> li_BookRecFrBinders = new List<Li_BookRecFrBinder>();
        SqlLi_BookRecFrBinderProvider sqlLi_BookRecFrBinderProvider = new SqlLi_BookRecFrBinderProvider();
        li_BookRecFrBinders = sqlLi_BookRecFrBinderProvider.GetAllLi_BookRecFrBinders();
        return li_BookRecFrBinders;
    }


    public static Li_BookRecFrBinder GetLi_BookRecFrBinderByID(int id)
    {
        Li_BookRecFrBinder li_BookRecFrBinder = new Li_BookRecFrBinder();
        SqlLi_BookRecFrBinderProvider sqlLi_BookRecFrBinderProvider = new SqlLi_BookRecFrBinderProvider();
        li_BookRecFrBinder = sqlLi_BookRecFrBinderProvider.GetLi_BookRecFrBinderByID(id);
        return li_BookRecFrBinder;
    }


    public static int InsertLi_BookRecFrBinder(Li_BookRecFrBinder li_BookRecFrBinder)
    {
        SqlLi_BookRecFrBinderProvider sqlLi_BookRecFrBinderProvider = new SqlLi_BookRecFrBinderProvider();
        return sqlLi_BookRecFrBinderProvider.InsertLi_BookRecFrBinder(li_BookRecFrBinder);
    }


    public static bool UpdateLi_BookRecFrBinder(Li_BookRecFrBinder li_BookRecFrBinder)
    {
        SqlLi_BookRecFrBinderProvider sqlLi_BookRecFrBinderProvider = new SqlLi_BookRecFrBinderProvider();
        return sqlLi_BookRecFrBinderProvider.UpdateLi_BookRecFrBinder(li_BookRecFrBinder);
    }

    public static bool DeleteLi_BookRecFrBinder(int li_BookRecFrBinderID)
    {
        SqlLi_BookRecFrBinderProvider sqlLi_BookRecFrBinderProvider = new SqlLi_BookRecFrBinderProvider();
        return sqlLi_BookRecFrBinderProvider.DeleteLi_BookRecFrBinder(li_BookRecFrBinderID);
    }
}
