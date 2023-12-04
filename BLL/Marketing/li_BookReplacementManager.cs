using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookReplacementManager
{
	public Li_BookReplacementManager()
	{
	}

    public static List<Li_BookReplacement> GetAllLi_BookReplacements()
    {
        List<Li_BookReplacement> li_BookReplacements = new List<Li_BookReplacement>();
        SqlLi_BookReplacementProvider sqlLi_BookReplacementProvider = new SqlLi_BookReplacementProvider();
        li_BookReplacements = sqlLi_BookReplacementProvider.GetAllLi_BookReplacements();
        return li_BookReplacements;
    }


    public static Li_BookReplacement GetLi_BookReplacementByID(int id)
    {
        Li_BookReplacement li_BookReplacement = new Li_BookReplacement();
        SqlLi_BookReplacementProvider sqlLi_BookReplacementProvider = new SqlLi_BookReplacementProvider();
        li_BookReplacement = sqlLi_BookReplacementProvider.GetLi_BookReplacementByID(id);
        return li_BookReplacement;
    }


    public static string  InsertLi_BookReplacement(Li_BookReplacement li_BookReplacement)
    {
        SqlLi_BookReplacementProvider sqlLi_BookReplacementProvider = new SqlLi_BookReplacementProvider();
        return sqlLi_BookReplacementProvider.InsertLi_BookReplacement(li_BookReplacement);
    }


    public static bool UpdateLi_BookReplacement(Li_BookReplacement li_BookReplacement)
    {
        SqlLi_BookReplacementProvider sqlLi_BookReplacementProvider = new SqlLi_BookReplacementProvider();
        return sqlLi_BookReplacementProvider.UpdateLi_BookReplacement(li_BookReplacement);
    }

    public static bool DeleteLi_BookReplacement(int li_BookReplacementID)
    {
        SqlLi_BookReplacementProvider sqlLi_BookReplacementProvider = new SqlLi_BookReplacementProvider();
        return sqlLi_BookReplacementProvider.DeleteLi_BookReplacement(li_BookReplacementID);
    }
}
