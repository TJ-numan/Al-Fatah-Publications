using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateBrandBasicManager
{
	public Li_PlateBrandBasicManager()
	{
	}

    public static List<Li_PlateBrandBasic> GetAllLi_PlateBrandBasics()
    {
        List<Li_PlateBrandBasic> li_PlateBrandBasics = new List<Li_PlateBrandBasic>();
        SqlLi_PlateBrandBasicProvider sqlLi_PlateBrandBasicProvider = new SqlLi_PlateBrandBasicProvider();
        li_PlateBrandBasics = sqlLi_PlateBrandBasicProvider.GetAllLi_PlateBrandBasics();
        return li_PlateBrandBasics;
    }


    public static Li_PlateBrandBasic GetLi_PlateBrandBasicByID(int id)
    {
        Li_PlateBrandBasic li_PlateBrandBasic = new Li_PlateBrandBasic();
        SqlLi_PlateBrandBasicProvider sqlLi_PlateBrandBasicProvider = new SqlLi_PlateBrandBasicProvider();
        li_PlateBrandBasic = sqlLi_PlateBrandBasicProvider.GetLi_PlateBrandBasicByID(id);
        return li_PlateBrandBasic;
    }


    public static string  InsertLi_PlateBrandBasic(Li_PlateBrandBasic li_PlateBrandBasic)
    {
        SqlLi_PlateBrandBasicProvider sqlLi_PlateBrandBasicProvider = new SqlLi_PlateBrandBasicProvider();
        return sqlLi_PlateBrandBasicProvider.InsertLi_PlateBrandBasic(li_PlateBrandBasic);
    }


    public static bool UpdateLi_PlateBrandBasic(Li_PlateBrandBasic li_PlateBrandBasic)
    {
        SqlLi_PlateBrandBasicProvider sqlLi_PlateBrandBasicProvider = new SqlLi_PlateBrandBasicProvider();
        return sqlLi_PlateBrandBasicProvider.UpdateLi_PlateBrandBasic(li_PlateBrandBasic);
    }

    public static bool DeleteLi_PlateBrandBasic(int li_PlateBrandBasicID)
    {
        SqlLi_PlateBrandBasicProvider sqlLi_PlateBrandBasicProvider = new SqlLi_PlateBrandBasicProvider();
        return sqlLi_PlateBrandBasicProvider.DeleteLi_PlateBrandBasic(li_PlateBrandBasicID);
    }
}
