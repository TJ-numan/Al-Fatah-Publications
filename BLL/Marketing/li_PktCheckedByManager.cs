using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PktCheckedByManager
{
	public Li_PktCheckedByManager()
	{
	}

    public static List<Li_PktCheckedBy> GetAllLi_PktCheckedBies()
    {
        List<Li_PktCheckedBy> li_PktCheckedBies = new List<Li_PktCheckedBy>();
        SqlLi_PktCheckedByProvider sqlLi_PktCheckedByProvider = new SqlLi_PktCheckedByProvider();
        li_PktCheckedBies = sqlLi_PktCheckedByProvider.GetAllLi_PktCheckedBies();
        return li_PktCheckedBies;
    }


    public static Li_PktCheckedBy GetLi_PktCheckedByByID(int id)
    {
        Li_PktCheckedBy li_PktCheckedBy = new Li_PktCheckedBy();
        SqlLi_PktCheckedByProvider sqlLi_PktCheckedByProvider = new SqlLi_PktCheckedByProvider();
        li_PktCheckedBy = sqlLi_PktCheckedByProvider.GetLi_PktCheckedByByID(id);
        return li_PktCheckedBy;
    }


    public static int InsertLi_PktCheckedBy(Li_PktCheckedBy li_PktCheckedBy)
    {
        SqlLi_PktCheckedByProvider sqlLi_PktCheckedByProvider = new SqlLi_PktCheckedByProvider();
        return sqlLi_PktCheckedByProvider.InsertLi_PktCheckedBy(li_PktCheckedBy);
    }


    public static bool UpdateLi_PktCheckedBy(Li_PktCheckedBy li_PktCheckedBy)
    {
        SqlLi_PktCheckedByProvider sqlLi_PktCheckedByProvider = new SqlLi_PktCheckedByProvider();
        return sqlLi_PktCheckedByProvider.UpdateLi_PktCheckedBy(li_PktCheckedBy);
    }

    public static bool DeleteLi_PktCheckedBy(int li_PktCheckedByID)
    {
        SqlLi_PktCheckedByProvider sqlLi_PktCheckedByProvider = new SqlLi_PktCheckedByProvider();
        return sqlLi_PktCheckedByProvider.DeleteLi_PktCheckedBy(li_PktCheckedByID);
    }
}
