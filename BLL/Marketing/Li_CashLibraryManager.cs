using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_CashLibraryManager
{
	public Li_CashLibraryManager()
	{
	}

    public static List<Li_CashLibrary> GetAllLi_CashLibraries()
    {
        List<Li_CashLibrary> li_CashLibraries = new List<Li_CashLibrary>();
        SqlLi_CashLibraryProvider sqlLi_CashLibraryProvider = new SqlLi_CashLibraryProvider();
        li_CashLibraries = sqlLi_CashLibraryProvider.GetAllLi_CashLibraries();
        return li_CashLibraries;
    }


    public static Li_CashLibrary GetLi_CashLibraryByID(int id)
    {
        Li_CashLibrary li_CashLibrary = new Li_CashLibrary();
        SqlLi_CashLibraryProvider sqlLi_CashLibraryProvider = new SqlLi_CashLibraryProvider();
        li_CashLibrary = sqlLi_CashLibraryProvider.GetLi_CashLibraryByID(id);
        return li_CashLibrary;
    }


    public static string  InsertLi_CashLibrary(Li_CashLibrary li_CashLibrary)
    {
        SqlLi_CashLibraryProvider sqlLi_CashLibraryProvider = new SqlLi_CashLibraryProvider();
        return sqlLi_CashLibraryProvider.InsertLi_CashLibrary(li_CashLibrary);
    }


    public static bool UpdateLi_CashLibrary(Li_CashLibrary li_CashLibrary)
    {
        SqlLi_CashLibraryProvider sqlLi_CashLibraryProvider = new SqlLi_CashLibraryProvider();
        return sqlLi_CashLibraryProvider.UpdateLi_CashLibrary(li_CashLibrary);
    }

    public static bool DeleteLi_CashLibrary(int li_CashLibraryID)
    {
        SqlLi_CashLibraryProvider sqlLi_CashLibraryProvider = new SqlLi_CashLibraryProvider();
        return sqlLi_CashLibraryProvider.DeleteLi_CashLibrary(li_CashLibraryID);
    }
}
