using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_LemiSizeBasicManager
{
	public Li_LemiSizeBasicManager()
	{
	}

    public static List<Li_LemiSizeBasic> GetAllLi_LemiSizeBasics()
    {
        List<Li_LemiSizeBasic> li_LemiSizeBasics = new List<Li_LemiSizeBasic>();
        SqlLi_LemiSizeBasicProvider sqlLi_LemiSizeBasicProvider = new SqlLi_LemiSizeBasicProvider();
        li_LemiSizeBasics = sqlLi_LemiSizeBasicProvider.GetAllLi_LemiSizeBasics();
        return li_LemiSizeBasics;
    }


    public static Li_LemiSizeBasic GetLi_LemiSizeBasicByID(int id)
    {
        Li_LemiSizeBasic li_LemiSizeBasic = new Li_LemiSizeBasic();
        SqlLi_LemiSizeBasicProvider sqlLi_LemiSizeBasicProvider = new SqlLi_LemiSizeBasicProvider();
        li_LemiSizeBasic = sqlLi_LemiSizeBasicProvider.GetLi_LemiSizeBasicByID(id);
        return li_LemiSizeBasic;
    }


    public static string  InsertLi_LemiSizeBasic(Li_LemiSizeBasic li_LemiSizeBasic)
    {
        SqlLi_LemiSizeBasicProvider sqlLi_LemiSizeBasicProvider = new SqlLi_LemiSizeBasicProvider();
        return sqlLi_LemiSizeBasicProvider.InsertLi_LemiSizeBasic(li_LemiSizeBasic);
    }


    public static bool UpdateLi_LemiSizeBasic(Li_LemiSizeBasic li_LemiSizeBasic)
    {
        SqlLi_LemiSizeBasicProvider sqlLi_LemiSizeBasicProvider = new SqlLi_LemiSizeBasicProvider();
        return sqlLi_LemiSizeBasicProvider.UpdateLi_LemiSizeBasic(li_LemiSizeBasic);
    }

    public static bool DeleteLi_LemiSizeBasic(int li_LemiSizeBasicID)
    {
        SqlLi_LemiSizeBasicProvider sqlLi_LemiSizeBasicProvider = new SqlLi_LemiSizeBasicProvider();
        return sqlLi_LemiSizeBasicProvider.DeleteLi_LemiSizeBasic(li_LemiSizeBasicID);
    }
}
