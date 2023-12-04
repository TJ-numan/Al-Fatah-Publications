using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_InnerFormaPrintingManager
{
	public Li_InnerFormaPrintingManager()
	{
	}

    public static List<Li_InnerFormaPrinting> GetAllLi_InnerFormaPrintings()
    {
        List<Li_InnerFormaPrinting> li_InnerFormaPrintings = new List<Li_InnerFormaPrinting>();
        SqlLi_InnerFormaPrintingProvider sqlLi_InnerFormaPrintingProvider = new SqlLi_InnerFormaPrintingProvider();
        li_InnerFormaPrintings = sqlLi_InnerFormaPrintingProvider.GetAllLi_InnerFormaPrintings();
        return li_InnerFormaPrintings;
    }


    public static Li_InnerFormaPrinting GetLi_InnerFormaPrintingByID(int id)
    {
        Li_InnerFormaPrinting li_InnerFormaPrinting = new Li_InnerFormaPrinting();
        SqlLi_InnerFormaPrintingProvider sqlLi_InnerFormaPrintingProvider = new SqlLi_InnerFormaPrintingProvider();
        li_InnerFormaPrinting = sqlLi_InnerFormaPrintingProvider.GetLi_InnerFormaPrintingByID(id);
        return li_InnerFormaPrinting;
    }


    public static string  InsertLi_InnerFormaPrinting(Li_InnerFormaPrinting li_InnerFormaPrinting)
    {
        SqlLi_InnerFormaPrintingProvider sqlLi_InnerFormaPrintingProvider = new SqlLi_InnerFormaPrintingProvider();
        return sqlLi_InnerFormaPrintingProvider.InsertLi_InnerFormaPrinting(li_InnerFormaPrinting);
    }


    public static bool UpdateLi_InnerFormaPrinting(Li_InnerFormaPrinting li_InnerFormaPrinting)
    {
        SqlLi_InnerFormaPrintingProvider sqlLi_InnerFormaPrintingProvider = new SqlLi_InnerFormaPrintingProvider();
        return sqlLi_InnerFormaPrintingProvider.UpdateLi_InnerFormaPrinting(li_InnerFormaPrinting);
    }

    public static bool DeleteLi_InnerFormaPrinting(int li_InnerFormaPrintingID)
    {
        SqlLi_InnerFormaPrintingProvider sqlLi_InnerFormaPrintingProvider = new SqlLi_InnerFormaPrintingProvider();
        return sqlLi_InnerFormaPrintingProvider.DeleteLi_InnerFormaPrinting(li_InnerFormaPrintingID);
    }
}
