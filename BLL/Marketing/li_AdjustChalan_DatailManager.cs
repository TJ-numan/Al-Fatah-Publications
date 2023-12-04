using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_AdjustChalan_DatailManager
{
	public Li_AdjustChalan_DatailManager()
	{
	}

    public static List<Li_AdjustChalan_Datail> GetAllLi_AdjustChalan_Datails()
    {
        List<Li_AdjustChalan_Datail> li_AdjustChalan_Datails = new List<Li_AdjustChalan_Datail>();
        SqlLi_AdjustChalan_DatailProvider sqlLi_AdjustChalan_DatailProvider = new SqlLi_AdjustChalan_DatailProvider();
        li_AdjustChalan_Datails = sqlLi_AdjustChalan_DatailProvider.GetAllLi_AdjustChalan_Datails();
        return li_AdjustChalan_Datails;
    }


    public static Li_AdjustChalan_Datail GetLi_AdjustChalan_DatailByID(int id)
    {
        Li_AdjustChalan_Datail li_AdjustChalan_Datail = new Li_AdjustChalan_Datail();
        SqlLi_AdjustChalan_DatailProvider sqlLi_AdjustChalan_DatailProvider = new SqlLi_AdjustChalan_DatailProvider();
        li_AdjustChalan_Datail = sqlLi_AdjustChalan_DatailProvider.GetLi_AdjustChalan_DatailByID(id);
        return li_AdjustChalan_Datail;
    }


    public static int InsertLi_AdjustChalan_Datail(Li_AdjustChalan_Datail li_AdjustChalan_Datail)
    {
        SqlLi_AdjustChalan_DatailProvider sqlLi_AdjustChalan_DatailProvider = new SqlLi_AdjustChalan_DatailProvider();
        return sqlLi_AdjustChalan_DatailProvider.InsertLi_AdjustChalan_Datail(li_AdjustChalan_Datail);
    }


    public static bool UpdateLi_AdjustChalan_Datail(Li_AdjustChalan_Datail li_AdjustChalan_Datail)
    {
        SqlLi_AdjustChalan_DatailProvider sqlLi_AdjustChalan_DatailProvider = new SqlLi_AdjustChalan_DatailProvider();
        return sqlLi_AdjustChalan_DatailProvider.UpdateLi_AdjustChalan_Datail(li_AdjustChalan_Datail);
    }

    public static bool DeleteLi_AdjustChalan_Datail(int li_AdjustChalan_DatailID)
    {
        SqlLi_AdjustChalan_DatailProvider sqlLi_AdjustChalan_DatailProvider = new SqlLi_AdjustChalan_DatailProvider();
        return sqlLi_AdjustChalan_DatailProvider.DeleteLi_AdjustChalan_Datail(li_AdjustChalan_DatailID);
    }
}
