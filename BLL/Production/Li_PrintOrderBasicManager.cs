using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintOrderBasicManager
{
	public Li_PrintOrderBasicManager()
	{
	}

    public static List<Li_PrintOrderBasic> GetAllLi_PrintOrderBasics()
    {
        List<Li_PrintOrderBasic> li_PrintOrderBasics = new List<Li_PrintOrderBasic>();
        SqlLi_PrintOrderBasicProvider sqlLi_PrintOrderBasicProvider = new SqlLi_PrintOrderBasicProvider();
        li_PrintOrderBasics = sqlLi_PrintOrderBasicProvider.GetAllLi_PrintOrderBasics();
        return li_PrintOrderBasics;
    }


    public static Li_PrintOrderBasic GetLi_PrintOrderBasicByID(int id)
    {
        Li_PrintOrderBasic li_PrintOrderBasic = new Li_PrintOrderBasic();
        SqlLi_PrintOrderBasicProvider sqlLi_PrintOrderBasicProvider = new SqlLi_PrintOrderBasicProvider();
        li_PrintOrderBasic = sqlLi_PrintOrderBasicProvider.GetLi_PrintOrderBasicByID(id);
        return li_PrintOrderBasic;
    }


    public static int InsertLi_PrintOrderBasic(Li_PrintOrderBasic li_PrintOrderBasic)
    {
        SqlLi_PrintOrderBasicProvider sqlLi_PrintOrderBasicProvider = new SqlLi_PrintOrderBasicProvider();
        return sqlLi_PrintOrderBasicProvider.InsertLi_PrintOrderBasic(li_PrintOrderBasic);
    }


    public static bool UpdateLi_PrintOrderBasic(Li_PrintOrderBasic li_PrintOrderBasic)
    {
        SqlLi_PrintOrderBasicProvider sqlLi_PrintOrderBasicProvider = new SqlLi_PrintOrderBasicProvider();
        return sqlLi_PrintOrderBasicProvider.UpdateLi_PrintOrderBasic(li_PrintOrderBasic);
    }

    public static bool DeleteLi_PrintOrderBasic(int li_PrintOrderBasicID)
    {
        SqlLi_PrintOrderBasicProvider sqlLi_PrintOrderBasicProvider = new SqlLi_PrintOrderBasicProvider();
        return sqlLi_PrintOrderBasicProvider.DeleteLi_PrintOrderBasic(li_PrintOrderBasicID);
    }
}
