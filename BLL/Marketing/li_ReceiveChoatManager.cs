using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_ReceiveChoatManager
{
	public Li_ReceiveChoatManager()
	{
	}

    public static List<Li_ReceiveChoat> GetAllLi_ReceiveChoats()
    {
        List<Li_ReceiveChoat> li_ReceiveChoats = new List<Li_ReceiveChoat>();
        SqlLi_ReceiveChoatProvider sqlLi_ReceiveChoatProvider = new SqlLi_ReceiveChoatProvider();
        li_ReceiveChoats = sqlLi_ReceiveChoatProvider.GetAllLi_ReceiveChoats();
        return li_ReceiveChoats;
    }


    public static Li_ReceiveChoat GetLi_ReceiveChoatByID(int id)
    {
        Li_ReceiveChoat li_ReceiveChoat = new Li_ReceiveChoat();
        SqlLi_ReceiveChoatProvider sqlLi_ReceiveChoatProvider = new SqlLi_ReceiveChoatProvider();
        li_ReceiveChoat = sqlLi_ReceiveChoatProvider.GetLi_ReceiveChoatByID(id);
        return li_ReceiveChoat;
    }


    public static int InsertLi_ReceiveChoat(Li_ReceiveChoat li_ReceiveChoat)
    {
        SqlLi_ReceiveChoatProvider sqlLi_ReceiveChoatProvider = new SqlLi_ReceiveChoatProvider();
        return sqlLi_ReceiveChoatProvider.InsertLi_ReceiveChoat(li_ReceiveChoat);
    }


    public static bool UpdateLi_ReceiveChoat(Li_ReceiveChoat li_ReceiveChoat)
    {
        SqlLi_ReceiveChoatProvider sqlLi_ReceiveChoatProvider = new SqlLi_ReceiveChoatProvider();
        return sqlLi_ReceiveChoatProvider.UpdateLi_ReceiveChoat(li_ReceiveChoat);
    }

    public static bool DeleteLi_ReceiveChoat(int li_ReceiveChoatID)
    {
        SqlLi_ReceiveChoatProvider sqlLi_ReceiveChoatProvider = new SqlLi_ReceiveChoatProvider();
        return sqlLi_ReceiveChoatProvider.DeleteLi_ReceiveChoat(li_ReceiveChoatID);
    }
}
