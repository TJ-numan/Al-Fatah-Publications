using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateTypeBasicManager
{
	public Li_PlateTypeBasicManager()
	{
	}

    public static List<Li_PlateTypeBasic> GetAllLi_PlateTypeBasics()
    {
        List<Li_PlateTypeBasic> li_PlateTypeBasics = new List<Li_PlateTypeBasic>();
        SqlLi_PlateTypeBasicProvider sqlLi_PlateTypeBasicProvider = new SqlLi_PlateTypeBasicProvider();
        li_PlateTypeBasics = sqlLi_PlateTypeBasicProvider.GetAllLi_PlateTypeBasics();
        return li_PlateTypeBasics;
    }


    public static Li_PlateTypeBasic GetLi_PlateTypeBasicByID(int id)
    {
        Li_PlateTypeBasic li_PlateTypeBasic = new Li_PlateTypeBasic();
        SqlLi_PlateTypeBasicProvider sqlLi_PlateTypeBasicProvider = new SqlLi_PlateTypeBasicProvider();
        li_PlateTypeBasic = sqlLi_PlateTypeBasicProvider.GetLi_PlateTypeBasicByID(id);
        return li_PlateTypeBasic;
    }


    public static string  InsertLi_PlateTypeBasic(Li_PlateTypeBasic li_PlateTypeBasic)
    {
        SqlLi_PlateTypeBasicProvider sqlLi_PlateTypeBasicProvider = new SqlLi_PlateTypeBasicProvider();
        return sqlLi_PlateTypeBasicProvider.InsertLi_PlateTypeBasic(li_PlateTypeBasic);
    }


    public static bool UpdateLi_PlateTypeBasic(Li_PlateTypeBasic li_PlateTypeBasic)
    {
        SqlLi_PlateTypeBasicProvider sqlLi_PlateTypeBasicProvider = new SqlLi_PlateTypeBasicProvider();
        return sqlLi_PlateTypeBasicProvider.UpdateLi_PlateTypeBasic(li_PlateTypeBasic);
    }

    public static bool DeleteLi_PlateTypeBasic(int li_PlateTypeBasicID)
    {
        SqlLi_PlateTypeBasicProvider sqlLi_PlateTypeBasicProvider = new SqlLi_PlateTypeBasicProvider();
        return sqlLi_PlateTypeBasicProvider.DeleteLi_PlateTypeBasic(li_PlateTypeBasicID);
    }
}
