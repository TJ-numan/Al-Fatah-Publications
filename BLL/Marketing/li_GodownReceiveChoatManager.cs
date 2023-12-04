using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_GodownReceiveChoatManager
{
	public Li_GodownReceiveChoatManager()
	{
	}

    public static List<Li_GodownReceiveChoat> GetAllLi_GodownReceiveChoats()
    {
        List<Li_GodownReceiveChoat> li_GodownReceiveChoats = new List<Li_GodownReceiveChoat>();
        SqlLi_GodownReceiveChoatProvider sqlLi_GodownReceiveChoatProvider = new SqlLi_GodownReceiveChoatProvider();
        li_GodownReceiveChoats = sqlLi_GodownReceiveChoatProvider.GetAllLi_GodownReceiveChoats();
        return li_GodownReceiveChoats;
    }


    public static Li_GodownReceiveChoat GetLi_GodownReceiveChoatByID(int id)
    {
        Li_GodownReceiveChoat li_GodownReceiveChoat = new Li_GodownReceiveChoat();
        SqlLi_GodownReceiveChoatProvider sqlLi_GodownReceiveChoatProvider = new SqlLi_GodownReceiveChoatProvider();
        li_GodownReceiveChoat = sqlLi_GodownReceiveChoatProvider.GetLi_GodownReceiveChoatByID(id);
        return li_GodownReceiveChoat;
    }


    public static int InsertLi_GodownReceiveChoat(Li_GodownReceiveChoat li_GodownReceiveChoat)
    {
        SqlLi_GodownReceiveChoatProvider sqlLi_GodownReceiveChoatProvider = new SqlLi_GodownReceiveChoatProvider();
        return sqlLi_GodownReceiveChoatProvider.InsertLi_GodownReceiveChoat(li_GodownReceiveChoat);
    }


    public static bool UpdateLi_GodownReceiveChoat(Li_GodownReceiveChoat li_GodownReceiveChoat)
    {
        SqlLi_GodownReceiveChoatProvider sqlLi_GodownReceiveChoatProvider = new SqlLi_GodownReceiveChoatProvider();
        return sqlLi_GodownReceiveChoatProvider.UpdateLi_GodownReceiveChoat(li_GodownReceiveChoat);
    }

    public static bool DeleteLi_GodownReceiveChoat(int li_GodownReceiveChoatID)
    {
        SqlLi_GodownReceiveChoatProvider sqlLi_GodownReceiveChoatProvider = new SqlLi_GodownReceiveChoatProvider();
        return sqlLi_GodownReceiveChoatProvider.DeleteLi_GodownReceiveChoat(li_GodownReceiveChoatID);
    }
}
