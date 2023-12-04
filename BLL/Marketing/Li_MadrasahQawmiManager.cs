using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_MadrasahQawmiManager
{
	public Li_MadrasahQawmiManager()
	{
	}

    public static List<Li_MadrasahQawmi> GetAllLi_MadrasahQawmis()
    {
        List<Li_MadrasahQawmi> li_MadrasahQawmis = new List<Li_MadrasahQawmi>();
        SqlLi_MadrasahQawmiProvider sqlLi_MadrasahQawmiProvider = new SqlLi_MadrasahQawmiProvider();
        li_MadrasahQawmis = sqlLi_MadrasahQawmiProvider.GetAllLi_MadrasahQawmis();
        return li_MadrasahQawmis;
    }


    public static Li_MadrasahQawmi GetLi_MadrasahQawmiByID(int id)
    {
        Li_MadrasahQawmi li_MadrasahQawmi = new Li_MadrasahQawmi();
        SqlLi_MadrasahQawmiProvider sqlLi_MadrasahQawmiProvider = new SqlLi_MadrasahQawmiProvider();
        li_MadrasahQawmi = sqlLi_MadrasahQawmiProvider.GetLi_MadrasahQawmiByID(id);
        return li_MadrasahQawmi;
    }


    public static int InsertLi_MadrasahQawmi(Li_MadrasahQawmi li_MadrasahQawmi)
    {
        SqlLi_MadrasahQawmiProvider sqlLi_MadrasahQawmiProvider = new SqlLi_MadrasahQawmiProvider();
        return sqlLi_MadrasahQawmiProvider.InsertLi_MadrasahQawmi(li_MadrasahQawmi);
    }


    public static bool UpdateLi_MadrasahQawmi(Li_MadrasahQawmi li_MadrasahQawmi)
    {
        SqlLi_MadrasahQawmiProvider sqlLi_MadrasahQawmiProvider = new SqlLi_MadrasahQawmiProvider();
        return sqlLi_MadrasahQawmiProvider.UpdateLi_MadrasahQawmi(li_MadrasahQawmi);
    }

    public static bool DeleteLi_MadrasahQawmi(int li_MadrasahQawmiID)
    {
        SqlLi_MadrasahQawmiProvider sqlLi_MadrasahQawmiProvider = new SqlLi_MadrasahQawmiProvider();
        return sqlLi_MadrasahQawmiProvider.DeleteLi_MadrasahQawmi(li_MadrasahQawmiID);
    }
}
