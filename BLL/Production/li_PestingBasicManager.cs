using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PestingBasicManager
{
	public Li_PestingBasicManager()
	{
	}

    public static List<Li_PestingBasic> GetAllLi_PestingBasics()
    {
        List<Li_PestingBasic> li_PestingBasics = new List<Li_PestingBasic>();
        SqlLi_PestingBasicProvider sqlLi_PestingBasicProvider = new SqlLi_PestingBasicProvider();
        li_PestingBasics = sqlLi_PestingBasicProvider.GetAllLi_PestingBasics();
        return li_PestingBasics;
    }


    public static Li_PestingBasic GetLi_PestingBasicByID(int id)
    {
        Li_PestingBasic li_PestingBasic = new Li_PestingBasic();
        SqlLi_PestingBasicProvider sqlLi_PestingBasicProvider = new SqlLi_PestingBasicProvider();
        li_PestingBasic = sqlLi_PestingBasicProvider.GetLi_PestingBasicByID(id);
        return li_PestingBasic;
    }


    public static string  InsertLi_PestingBasic(Li_PestingBasic li_PestingBasic)
    {
        SqlLi_PestingBasicProvider sqlLi_PestingBasicProvider = new SqlLi_PestingBasicProvider();
        return sqlLi_PestingBasicProvider.InsertLi_PestingBasic(li_PestingBasic);
    }


    public static bool UpdateLi_PestingBasic(Li_PestingBasic li_PestingBasic)
    {
        SqlLi_PestingBasicProvider sqlLi_PestingBasicProvider = new SqlLi_PestingBasicProvider();
        return sqlLi_PestingBasicProvider.UpdateLi_PestingBasic(li_PestingBasic);
    }

    public static bool DeleteLi_PestingBasic(int li_PestingBasicID)
    {
        SqlLi_PestingBasicProvider sqlLi_PestingBasicProvider = new SqlLi_PestingBasicProvider();
        return sqlLi_PestingBasicProvider.DeleteLi_PestingBasic(li_PestingBasicID);
    }
}
