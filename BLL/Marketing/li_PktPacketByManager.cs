using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PktPacketByManager
{
	public Li_PktPacketByManager()
	{
	}

    public static List<Li_PktPacketBy> GetAllLi_PktPacketBies()
    {
        List<Li_PktPacketBy> li_PktPacketBies = new List<Li_PktPacketBy>();
        SqlLi_PktPacketByProvider sqlLi_PktPacketByProvider = new SqlLi_PktPacketByProvider();
        li_PktPacketBies = sqlLi_PktPacketByProvider.GetAllLi_PktPacketBies();
        return li_PktPacketBies;
    }


    public static Li_PktPacketBy GetLi_PktPacketByByID(int id)
    {
        Li_PktPacketBy li_PktPacketBy = new Li_PktPacketBy();
        SqlLi_PktPacketByProvider sqlLi_PktPacketByProvider = new SqlLi_PktPacketByProvider();
        li_PktPacketBy = sqlLi_PktPacketByProvider.GetLi_PktPacketByByID(id);
        return li_PktPacketBy;
    }


    public static int InsertLi_PktPacketBy(Li_PktPacketBy li_PktPacketBy)
    {
        SqlLi_PktPacketByProvider sqlLi_PktPacketByProvider = new SqlLi_PktPacketByProvider();
        return sqlLi_PktPacketByProvider.InsertLi_PktPacketBy(li_PktPacketBy);
    }


    public static bool UpdateLi_PktPacketBy(Li_PktPacketBy li_PktPacketBy)
    {
        SqlLi_PktPacketByProvider sqlLi_PktPacketByProvider = new SqlLi_PktPacketByProvider();
        return sqlLi_PktPacketByProvider.UpdateLi_PktPacketBy(li_PktPacketBy);
    }

    public static bool DeleteLi_PktPacketBy(int li_PktPacketByID)
    {
        SqlLi_PktPacketByProvider sqlLi_PktPacketByProvider = new SqlLi_PktPacketByProvider();
        return sqlLi_PktPacketByProvider.DeleteLi_PktPacketBy(li_PktPacketByID);
    }
}
