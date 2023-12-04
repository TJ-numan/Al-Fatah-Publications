using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_OverheadManager
{
	public Li_OverheadManager()
	{
	}

    public static List<Li_Overhead> GetAllLi_Overheads()
    {
        List<Li_Overhead> li_Overheads = new List<Li_Overhead>();
        SqlLi_OverheadProvider sqlLi_OverheadProvider = new SqlLi_OverheadProvider();
        li_Overheads = sqlLi_OverheadProvider.GetAllLi_Overheads();
        return li_Overheads;
    }


    public static Li_Overhead GetLi_OverheadByID(string  id)
    {
        Li_Overhead li_Overhead = new Li_Overhead();
        SqlLi_OverheadProvider sqlLi_OverheadProvider = new SqlLi_OverheadProvider();
        li_Overhead = sqlLi_OverheadProvider.GetLi_OverheadByID(id);
        return li_Overhead;
    }


    public static int InsertLi_Overhead(Li_Overhead li_Overhead)
    {
        SqlLi_OverheadProvider sqlLi_OverheadProvider = new SqlLi_OverheadProvider();
        return sqlLi_OverheadProvider.InsertLi_Overhead(li_Overhead);
    }


    public static bool UpdateLi_Overhead(Li_Overhead li_Overhead)
    {
        SqlLi_OverheadProvider sqlLi_OverheadProvider = new SqlLi_OverheadProvider();
        return sqlLi_OverheadProvider.UpdateLi_Overhead(li_Overhead);
    }

    public static bool DeleteLi_Overhead(int li_OverheadID)
    {
        SqlLi_OverheadProvider sqlLi_OverheadProvider = new SqlLi_OverheadProvider();
        return sqlLi_OverheadProvider.DeleteLi_Overhead(li_OverheadID);
    }
}
