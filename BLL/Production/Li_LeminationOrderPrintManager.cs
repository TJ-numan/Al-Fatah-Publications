using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LeminationOrderPrintManager
{
	public Li_LeminationOrderPrintManager()
	{
	}

    public static List<Li_LeminationOrderPrint> GetAllLi_LeminationOrderPrints()
    {
        List<Li_LeminationOrderPrint> li_LeminationOrderPrints = new List<Li_LeminationOrderPrint>();
        SqlLi_LeminationOrderPrintProvider sqlLi_LeminationOrderPrintProvider = new SqlLi_LeminationOrderPrintProvider();
        li_LeminationOrderPrints = sqlLi_LeminationOrderPrintProvider.GetAllLi_LeminationOrderPrints();
        return li_LeminationOrderPrints;
    }


    public static Li_LeminationOrderPrint GetLi_LeminationOrderPrintByID(int id)
    {
        Li_LeminationOrderPrint li_LeminationOrderPrint = new Li_LeminationOrderPrint();
        SqlLi_LeminationOrderPrintProvider sqlLi_LeminationOrderPrintProvider = new SqlLi_LeminationOrderPrintProvider();
        li_LeminationOrderPrint = sqlLi_LeminationOrderPrintProvider.GetLi_LeminationOrderPrintByID(id);
        return li_LeminationOrderPrint;
    }


    public static string  InsertLi_LeminationOrderPrint(Li_LeminationOrderPrint li_LeminationOrderPrint)
    {
        SqlLi_LeminationOrderPrintProvider sqlLi_LeminationOrderPrintProvider = new SqlLi_LeminationOrderPrintProvider();
        return sqlLi_LeminationOrderPrintProvider.InsertLi_LeminationOrderPrint(li_LeminationOrderPrint);
    }


    public static bool UpdateLi_LeminationOrderPrint(Li_LeminationOrderPrint li_LeminationOrderPrint)
    {
        SqlLi_LeminationOrderPrintProvider sqlLi_LeminationOrderPrintProvider = new SqlLi_LeminationOrderPrintProvider();
        return sqlLi_LeminationOrderPrintProvider.UpdateLi_LeminationOrderPrint(li_LeminationOrderPrint);
    }

    public static bool DeleteLi_LeminationOrderPrint(int li_LeminationOrderPrintID)
    {
        SqlLi_LeminationOrderPrintProvider sqlLi_LeminationOrderPrintProvider = new SqlLi_LeminationOrderPrintProvider();
        return sqlLi_LeminationOrderPrintProvider.DeleteLi_LeminationOrderPrint(li_LeminationOrderPrintID);
    }
}
