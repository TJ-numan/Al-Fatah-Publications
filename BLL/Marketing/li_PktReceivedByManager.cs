using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PktReceivedByManager
{
	public Li_PktReceivedByManager()
	{
	}

    public static List<Li_PktReceivedBy> GetAllLi_PktReceivedBies()
    {
        List<Li_PktReceivedBy> li_PktReceivedBies = new List<Li_PktReceivedBy>();
        SqlLi_PktReceivedByProvider sqlLi_PktReceivedByProvider = new SqlLi_PktReceivedByProvider();
        li_PktReceivedBies = sqlLi_PktReceivedByProvider.GetAllLi_PktReceivedBies();
        return li_PktReceivedBies;
    }


    public static Li_PktReceivedBy GetLi_PktReceivedByByID(int id)
    {
        Li_PktReceivedBy li_PktReceivedBy = new Li_PktReceivedBy();
        SqlLi_PktReceivedByProvider sqlLi_PktReceivedByProvider = new SqlLi_PktReceivedByProvider();
        li_PktReceivedBy = sqlLi_PktReceivedByProvider.GetLi_PktReceivedByByID(id);
        return li_PktReceivedBy;
    }


    public static int InsertLi_PktReceivedBy(Li_PktReceivedBy li_PktReceivedBy)
    {
        SqlLi_PktReceivedByProvider sqlLi_PktReceivedByProvider = new SqlLi_PktReceivedByProvider();
        return sqlLi_PktReceivedByProvider.InsertLi_PktReceivedBy(li_PktReceivedBy);
    }


    public static bool UpdateLi_PktReceivedBy(Li_PktReceivedBy li_PktReceivedBy)
    {
        SqlLi_PktReceivedByProvider sqlLi_PktReceivedByProvider = new SqlLi_PktReceivedByProvider();
        return sqlLi_PktReceivedByProvider.UpdateLi_PktReceivedBy(li_PktReceivedBy);
    }

    public static bool DeleteLi_PktReceivedBy(int li_PktReceivedByID)
    {
        SqlLi_PktReceivedByProvider sqlLi_PktReceivedByProvider = new SqlLi_PktReceivedByProvider();
        return sqlLi_PktReceivedByProvider.DeleteLi_PktReceivedBy(li_PktReceivedByID);
    }
}
