using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PestingManager
{
	public Li_PestingManager()
	{
	}

    public static List<Li_Pesting> GetAllLi_Pestings()
    {
        List<Li_Pesting> li_Pestings = new List<Li_Pesting>();
        SqlLi_PestingProvider sqlLi_PestingProvider = new SqlLi_PestingProvider();
        li_Pestings = sqlLi_PestingProvider.GetAllLi_Pestings();
        return li_Pestings;
    }


    public static Li_Pesting GetLi_PestingByID(int id)
    {
        Li_Pesting li_Pesting = new Li_Pesting();
        SqlLi_PestingProvider sqlLi_PestingProvider = new SqlLi_PestingProvider();
        li_Pesting = sqlLi_PestingProvider.GetLi_PestingByID(id);
        return li_Pesting;
    }


    public static string  InsertLi_Pesting(Li_Pesting li_Pesting)
    {
        SqlLi_PestingProvider sqlLi_PestingProvider = new SqlLi_PestingProvider();
        return sqlLi_PestingProvider.InsertLi_Pesting(li_Pesting);
    }


    public static bool UpdateLi_Pesting(Li_Pesting li_Pesting)
    {
        SqlLi_PestingProvider sqlLi_PestingProvider = new SqlLi_PestingProvider();
        return sqlLi_PestingProvider.UpdateLi_Pesting(li_Pesting);
    }

    public static bool DeleteLi_Pesting(int li_PestingID)
    {
        SqlLi_PestingProvider sqlLi_PestingProvider = new SqlLi_PestingProvider();
        return sqlLi_PestingProvider.DeleteLi_Pesting(li_PestingID);
    }


    public static DataSet getPestingOrderInfoByBookID(string BookID)
    {

        SqlLi_PestingProvider sqlLi_PestingProvider = new SqlLi_PestingProvider(); 
        return  sqlLi_PestingProvider.getPestingOrderInfoByBookID (BookID );

    }


    public static DataSet getPestingOrderInfoByBookIDEditionOrder(string BookID, string Edition, string OrderNo,char PrintFor)
    {

        SqlLi_PestingProvider sqlLi_PestingProvider = new SqlLi_PestingProvider();
        return sqlLi_PestingProvider.getPestingOrderInfoByBookIDEditionOrder(BookID,Edition ,OrderNo,PrintFor );

    }
}
