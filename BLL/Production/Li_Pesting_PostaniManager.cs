using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Pesting_PostaniManager
{
	public Li_Pesting_PostaniManager()
	{
	}

    public static List<Li_Pesting_Postani> GetAllLi_Pesting_Postanis()
    {
        List<Li_Pesting_Postani> li_Pesting_Postanis = new List<Li_Pesting_Postani>();
        SqlLi_Pesting_PostaniProvider sqlLi_Pesting_PostaniProvider = new SqlLi_Pesting_PostaniProvider();
        li_Pesting_Postanis = sqlLi_Pesting_PostaniProvider.GetAllLi_Pesting_Postanis();
        return li_Pesting_Postanis;
    }


    public static Li_Pesting_Postani GetLi_Pesting_PostaniByID(int id)
    {
        Li_Pesting_Postani li_Pesting_Postani = new Li_Pesting_Postani();
        SqlLi_Pesting_PostaniProvider sqlLi_Pesting_PostaniProvider = new SqlLi_Pesting_PostaniProvider();
        li_Pesting_Postani = sqlLi_Pesting_PostaniProvider.GetLi_Pesting_PostaniByID(id);
        return li_Pesting_Postani;
    }


    public static int InsertLi_Pesting_Postani(Li_Pesting_Postani li_Pesting_Postani)
    {
        SqlLi_Pesting_PostaniProvider sqlLi_Pesting_PostaniProvider = new SqlLi_Pesting_PostaniProvider();
        return sqlLi_Pesting_PostaniProvider.InsertLi_Pesting_Postani(li_Pesting_Postani);
    }


    public static bool UpdateLi_Pesting_Postani(Li_Pesting_Postani li_Pesting_Postani)
    {
        SqlLi_Pesting_PostaniProvider sqlLi_Pesting_PostaniProvider = new SqlLi_Pesting_PostaniProvider();
        return sqlLi_Pesting_PostaniProvider.UpdateLi_Pesting_Postani(li_Pesting_Postani);
    }

    public static bool DeleteLi_Pesting_Postani(int li_Pesting_PostaniID)
    {
        SqlLi_Pesting_PostaniProvider sqlLi_Pesting_PostaniProvider = new SqlLi_Pesting_PostaniProvider();
        return sqlLi_Pesting_PostaniProvider.DeleteLi_Pesting_Postani(li_Pesting_PostaniID);
    }

    public static DataSet getPestingPostaniDetailByOrder(string OrderNo)
    {
          SqlLi_Pesting_PostaniProvider sqlLi_Pesting_PostaniProvider = new SqlLi_Pesting_PostaniProvider();
         return  sqlLi_Pesting_PostaniProvider.getPestingPostaniDetailByOrder(OrderNo);

    }
}
