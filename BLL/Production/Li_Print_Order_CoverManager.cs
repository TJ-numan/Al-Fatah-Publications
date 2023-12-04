using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Print_Order_CoverManager
{
	public Li_Print_Order_CoverManager()
	{
	}

    public static List<Li_Print_Order_Cover> GetAllLi_Print_Order_Covers()
    {
        List<Li_Print_Order_Cover> li_Print_Order_Covers = new List<Li_Print_Order_Cover>();
        SqlLi_Print_Order_CoverProvider sqlLi_Print_Order_CoverProvider = new SqlLi_Print_Order_CoverProvider();
        li_Print_Order_Covers = sqlLi_Print_Order_CoverProvider.GetAllLi_Print_Order_Covers();
        return li_Print_Order_Covers;
    }


    public static Li_Print_Order_Cover GetLi_Print_Order_CoverByID(int id)
    {
        Li_Print_Order_Cover li_Print_Order_Cover = new Li_Print_Order_Cover();
        SqlLi_Print_Order_CoverProvider sqlLi_Print_Order_CoverProvider = new SqlLi_Print_Order_CoverProvider();
        li_Print_Order_Cover = sqlLi_Print_Order_CoverProvider.GetLi_Print_Order_CoverByID(id);
        return li_Print_Order_Cover;
    }


    public static string  InsertLi_Print_Order_Cover(Li_Print_Order_Cover li_Print_Order_Cover)
    {
        SqlLi_Print_Order_CoverProvider sqlLi_Print_Order_CoverProvider = new SqlLi_Print_Order_CoverProvider();
        return sqlLi_Print_Order_CoverProvider.InsertLi_Print_Order_Cover(li_Print_Order_Cover);
    }


    public static bool UpdateLi_Print_Order_Cover(Li_Print_Order_Cover li_Print_Order_Cover)
    {
        SqlLi_Print_Order_CoverProvider sqlLi_Print_Order_CoverProvider = new SqlLi_Print_Order_CoverProvider();
        return sqlLi_Print_Order_CoverProvider.UpdateLi_Print_Order_Cover(li_Print_Order_Cover);
    }

    public static bool DeleteLi_Print_Order_Cover(int li_Print_Order_CoverID)
    {
        SqlLi_Print_Order_CoverProvider sqlLi_Print_Order_CoverProvider = new SqlLi_Print_Order_CoverProvider();
        return sqlLi_Print_Order_CoverProvider.DeleteLi_Print_Order_Cover(li_Print_Order_CoverID);
    }
}
