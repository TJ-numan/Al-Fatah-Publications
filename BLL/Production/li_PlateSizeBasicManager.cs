using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSizeBasicManager
{
	public Li_PlateSizeBasicManager()
	{
	}

    public static List<Li_PlateSizeBasic> GetAllLi_PlateSizeBasics()
    {
        List<Li_PlateSizeBasic> li_PlateSizeBasics = new List<Li_PlateSizeBasic>();
        SqlLi_PlateSizeBasicProvider sqlLi_PlateSizeBasicProvider = new SqlLi_PlateSizeBasicProvider();
        li_PlateSizeBasics = sqlLi_PlateSizeBasicProvider.GetAllLi_PlateSizeBasics();
        return li_PlateSizeBasics;
    }


    public static Li_PlateSizeBasic GetLi_PlateSizeBasicByID(int id)
    {
        Li_PlateSizeBasic li_PlateSizeBasic = new Li_PlateSizeBasic();
        SqlLi_PlateSizeBasicProvider sqlLi_PlateSizeBasicProvider = new SqlLi_PlateSizeBasicProvider();
        li_PlateSizeBasic = sqlLi_PlateSizeBasicProvider.GetLi_PlateSizeBasicByID(id);
        return li_PlateSizeBasic;
    }


    public static string  InsertLi_PlateSizeBasic(Li_PlateSizeBasic li_PlateSizeBasic)
    {
        SqlLi_PlateSizeBasicProvider sqlLi_PlateSizeBasicProvider = new SqlLi_PlateSizeBasicProvider();
        return sqlLi_PlateSizeBasicProvider.InsertLi_PlateSizeBasic(li_PlateSizeBasic);
    }


    public static bool UpdateLi_PlateSizeBasic(Li_PlateSizeBasic li_PlateSizeBasic)
    {
        SqlLi_PlateSizeBasicProvider sqlLi_PlateSizeBasicProvider = new SqlLi_PlateSizeBasicProvider();
        return sqlLi_PlateSizeBasicProvider.UpdateLi_PlateSizeBasic(li_PlateSizeBasic);
    }

    public static bool DeleteLi_PlateSizeBasic(int li_PlateSizeBasicID)
    {
        SqlLi_PlateSizeBasicProvider sqlLi_PlateSizeBasicProvider = new SqlLi_PlateSizeBasicProvider();
        return sqlLi_PlateSizeBasicProvider.DeleteLi_PlateSizeBasic(li_PlateSizeBasicID);
    }
}
