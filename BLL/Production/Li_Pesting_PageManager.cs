using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Pesting_PageManager
{
	public Li_Pesting_PageManager()
	{
	}

    public static List<Li_Pesting_Page> GetAllLi_Pesting_Pages()
    {
        List<Li_Pesting_Page> li_Pesting_Pages = new List<Li_Pesting_Page>();
        SqlLi_Pesting_PageProvider sqlLi_Pesting_PageProvider = new SqlLi_Pesting_PageProvider();
        li_Pesting_Pages = sqlLi_Pesting_PageProvider.GetAllLi_Pesting_Pages();
        return li_Pesting_Pages;
    }


    public static Li_Pesting_Page GetLi_Pesting_PageByID(int id)
    {
        Li_Pesting_Page li_Pesting_Page = new Li_Pesting_Page();
        SqlLi_Pesting_PageProvider sqlLi_Pesting_PageProvider = new SqlLi_Pesting_PageProvider();
        li_Pesting_Page = sqlLi_Pesting_PageProvider.GetLi_Pesting_PageByID(id);
        return li_Pesting_Page;
    }


    public static int InsertLi_Pesting_Page(Li_Pesting_Page li_Pesting_Page)
    {
        SqlLi_Pesting_PageProvider sqlLi_Pesting_PageProvider = new SqlLi_Pesting_PageProvider();
        return sqlLi_Pesting_PageProvider.InsertLi_Pesting_Page(li_Pesting_Page);
    }


    public static bool UpdateLi_Pesting_Page(Li_Pesting_Page li_Pesting_Page)
    {
        SqlLi_Pesting_PageProvider sqlLi_Pesting_PageProvider = new SqlLi_Pesting_PageProvider();
        return sqlLi_Pesting_PageProvider.UpdateLi_Pesting_Page(li_Pesting_Page);
    }

    public static bool DeleteLi_Pesting_Page(int li_Pesting_PageID)
    {
        SqlLi_Pesting_PageProvider sqlLi_Pesting_PageProvider = new SqlLi_Pesting_PageProvider();
        return sqlLi_Pesting_PageProvider.DeleteLi_Pesting_Page(li_Pesting_PageID);
    }
}
