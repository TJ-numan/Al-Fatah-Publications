using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_ReceivePolithinManager
{
	public Li_ReceivePolithinManager()
	{
	}

    public static List<Li_ReceivePolithin> GetAllLi_ReceivePolithins()
    {
        List<Li_ReceivePolithin> li_ReceivePolithins = new List<Li_ReceivePolithin>();
        SqlLi_ReceivePolithinProvider sqlLi_ReceivePolithinProvider = new SqlLi_ReceivePolithinProvider();
        li_ReceivePolithins = sqlLi_ReceivePolithinProvider.GetAllLi_ReceivePolithins();
        return li_ReceivePolithins;
    }


    public static Li_ReceivePolithin GetLi_ReceivePolithinByID(int id)
    {
        Li_ReceivePolithin li_ReceivePolithin = new Li_ReceivePolithin();
        SqlLi_ReceivePolithinProvider sqlLi_ReceivePolithinProvider = new SqlLi_ReceivePolithinProvider();
        li_ReceivePolithin = sqlLi_ReceivePolithinProvider.GetLi_ReceivePolithinByID(id);
        return li_ReceivePolithin;
    }


    public static int InsertLi_ReceivePolithin(Li_ReceivePolithin li_ReceivePolithin)
    {
        SqlLi_ReceivePolithinProvider sqlLi_ReceivePolithinProvider = new SqlLi_ReceivePolithinProvider();
        return sqlLi_ReceivePolithinProvider.InsertLi_ReceivePolithin(li_ReceivePolithin);
    }


    public static bool UpdateLi_ReceivePolithin(Li_ReceivePolithin li_ReceivePolithin)
    {
        SqlLi_ReceivePolithinProvider sqlLi_ReceivePolithinProvider = new SqlLi_ReceivePolithinProvider();
        return sqlLi_ReceivePolithinProvider.UpdateLi_ReceivePolithin(li_ReceivePolithin);
    }

    public static bool DeleteLi_ReceivePolithin(int li_ReceivePolithinID)
    {
        SqlLi_ReceivePolithinProvider sqlLi_ReceivePolithinProvider = new SqlLi_ReceivePolithinProvider();
        return sqlLi_ReceivePolithinProvider.DeleteLi_ReceivePolithin(li_ReceivePolithinID);
    }
}
