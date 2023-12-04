using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_ReceiveSutliManager
{
	public Li_ReceiveSutliManager()
	{
	}

    public static List<Li_ReceiveSutli> GetAllLi_ReceiveSutlis()
    {
        List<Li_ReceiveSutli> li_ReceiveSutlis = new List<Li_ReceiveSutli>();
        SqlLi_ReceiveSutliProvider sqlLi_ReceiveSutliProvider = new SqlLi_ReceiveSutliProvider();
        li_ReceiveSutlis = sqlLi_ReceiveSutliProvider.GetAllLi_ReceiveSutlis();
        return li_ReceiveSutlis;
    }


    public static Li_ReceiveSutli GetLi_ReceiveSutliByID(int id)
    {
        Li_ReceiveSutli li_ReceiveSutli = new Li_ReceiveSutli();
        SqlLi_ReceiveSutliProvider sqlLi_ReceiveSutliProvider = new SqlLi_ReceiveSutliProvider();
        li_ReceiveSutli = sqlLi_ReceiveSutliProvider.GetLi_ReceiveSutliByID(id);
        return li_ReceiveSutli;
    }


    public static int InsertLi_ReceiveSutli(Li_ReceiveSutli li_ReceiveSutli)
    {
        SqlLi_ReceiveSutliProvider sqlLi_ReceiveSutliProvider = new SqlLi_ReceiveSutliProvider();
        return sqlLi_ReceiveSutliProvider.InsertLi_ReceiveSutli(li_ReceiveSutli);
    }


    public static bool UpdateLi_ReceiveSutli(Li_ReceiveSutli li_ReceiveSutli)
    {
        SqlLi_ReceiveSutliProvider sqlLi_ReceiveSutliProvider = new SqlLi_ReceiveSutliProvider();
        return sqlLi_ReceiveSutliProvider.UpdateLi_ReceiveSutli(li_ReceiveSutli);
    }

    public static bool DeleteLi_ReceiveSutli(int li_ReceiveSutliID)
    {
        SqlLi_ReceiveSutliProvider sqlLi_ReceiveSutliProvider = new SqlLi_ReceiveSutliProvider();
        return sqlLi_ReceiveSutliProvider.DeleteLi_ReceiveSutli(li_ReceiveSutliID);
    }
}
