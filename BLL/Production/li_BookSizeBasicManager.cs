using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookSizeBasicManager
{
	public Li_BookSizeBasicManager()
	{
	}

    public static List<Li_BookSizeBasic> GetAllLi_BookSizeBasics()
    {
        List<Li_BookSizeBasic> li_BookSizeBasics = new List<Li_BookSizeBasic>();
        SqlLi_BookSizeBasicProvider sqlLi_BookSizeBasicProvider = new SqlLi_BookSizeBasicProvider();
        li_BookSizeBasics = sqlLi_BookSizeBasicProvider.GetAllLi_BookSizeBasics();
        return li_BookSizeBasics;
    }


    public static Li_BookSizeBasic GetLi_BookSizeBasicByID(int id)
    {
        Li_BookSizeBasic li_BookSizeBasic = new Li_BookSizeBasic();
        SqlLi_BookSizeBasicProvider sqlLi_BookSizeBasicProvider = new SqlLi_BookSizeBasicProvider();
        li_BookSizeBasic = sqlLi_BookSizeBasicProvider.GetLi_BookSizeBasicByID(id);
        return li_BookSizeBasic;
    }


    public static string  InsertLi_BookSizeBasic(Li_BookSizeBasic li_BookSizeBasic)
    {
        SqlLi_BookSizeBasicProvider sqlLi_BookSizeBasicProvider = new SqlLi_BookSizeBasicProvider();
        return sqlLi_BookSizeBasicProvider.InsertLi_BookSizeBasic(li_BookSizeBasic);
    }


    public static bool UpdateLi_BookSizeBasic(Li_BookSizeBasic li_BookSizeBasic)
    {
        SqlLi_BookSizeBasicProvider sqlLi_BookSizeBasicProvider = new SqlLi_BookSizeBasicProvider();
        return sqlLi_BookSizeBasicProvider.UpdateLi_BookSizeBasic(li_BookSizeBasic);
    }

    public static bool DeleteLi_BookSizeBasic(int li_BookSizeBasicID)
    {
        SqlLi_BookSizeBasicProvider sqlLi_BookSizeBasicProvider = new SqlLi_BookSizeBasicProvider();
        return sqlLi_BookSizeBasicProvider.DeleteLi_BookSizeBasic(li_BookSizeBasicID);
    }
}
