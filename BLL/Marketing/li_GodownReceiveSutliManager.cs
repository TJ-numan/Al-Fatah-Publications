using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_GodownReceiveSutliManager
{
	public Li_GodownReceiveSutliManager()
	{
	}

    public static List<Li_GodownReceiveSutli> GetAllLi_GodownReceiveSutlis()
    {
        List<Li_GodownReceiveSutli> li_GodownReceiveSutlis = new List<Li_GodownReceiveSutli>();
        SqlLi_GodownReceiveSutliProvider sqlLi_GodownReceiveSutliProvider = new SqlLi_GodownReceiveSutliProvider();
        li_GodownReceiveSutlis = sqlLi_GodownReceiveSutliProvider.GetAllLi_GodownReceiveSutlis();
        return li_GodownReceiveSutlis;
    }


    public static Li_GodownReceiveSutli GetLi_GodownReceiveSutliByID(int id)
    {
        Li_GodownReceiveSutli li_GodownReceiveSutli = new Li_GodownReceiveSutli();
        SqlLi_GodownReceiveSutliProvider sqlLi_GodownReceiveSutliProvider = new SqlLi_GodownReceiveSutliProvider();
        li_GodownReceiveSutli = sqlLi_GodownReceiveSutliProvider.GetLi_GodownReceiveSutliByID(id);
        return li_GodownReceiveSutli;
    }


    public static int InsertLi_GodownReceiveSutli(Li_GodownReceiveSutli li_GodownReceiveSutli)
    {
        SqlLi_GodownReceiveSutliProvider sqlLi_GodownReceiveSutliProvider = new SqlLi_GodownReceiveSutliProvider();
        return sqlLi_GodownReceiveSutliProvider.InsertLi_GodownReceiveSutli(li_GodownReceiveSutli);
    }


    public static bool UpdateLi_GodownReceiveSutli(Li_GodownReceiveSutli li_GodownReceiveSutli)
    {
        SqlLi_GodownReceiveSutliProvider sqlLi_GodownReceiveSutliProvider = new SqlLi_GodownReceiveSutliProvider();
        return sqlLi_GodownReceiveSutliProvider.UpdateLi_GodownReceiveSutli(li_GodownReceiveSutli);
    }

    public static bool DeleteLi_GodownReceiveSutli(int li_GodownReceiveSutliID)
    {
        SqlLi_GodownReceiveSutliProvider sqlLi_GodownReceiveSutliProvider = new SqlLi_GodownReceiveSutliProvider();
        return sqlLi_GodownReceiveSutliProvider.DeleteLi_GodownReceiveSutli(li_GodownReceiveSutliID);
    }
}
