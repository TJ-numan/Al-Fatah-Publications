using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TempPricingBookPrintManager
{
	public Li_TempPricingBookPrintManager()
	{
	}

    public static List<Li_TempPricingBookPrint> GetAllLi_TempPricingBookPrints()
    {
        List<Li_TempPricingBookPrint> li_TempPricingBookPrints = new List<Li_TempPricingBookPrint>();
        SqlLi_TempPricingBookPrintProvider sqlLi_TempPricingBookPrintProvider = new SqlLi_TempPricingBookPrintProvider();
        li_TempPricingBookPrints = sqlLi_TempPricingBookPrintProvider.GetAllLi_TempPricingBookPrints();
        return li_TempPricingBookPrints;
    }


    public static Li_TempPricingBookPrint GetLi_TempPricingBookPrintByID(int id)
    {
        Li_TempPricingBookPrint li_TempPricingBookPrint = new Li_TempPricingBookPrint();
        SqlLi_TempPricingBookPrintProvider sqlLi_TempPricingBookPrintProvider = new SqlLi_TempPricingBookPrintProvider();
        li_TempPricingBookPrint = sqlLi_TempPricingBookPrintProvider.GetLi_TempPricingBookPrintByID(id);
        return li_TempPricingBookPrint;
    }


    public static int InsertLi_TempPricingBookPrint(Li_TempPricingBookPrint li_TempPricingBookPrint)
    {
        SqlLi_TempPricingBookPrintProvider sqlLi_TempPricingBookPrintProvider = new SqlLi_TempPricingBookPrintProvider();
        return sqlLi_TempPricingBookPrintProvider.InsertLi_TempPricingBookPrint(li_TempPricingBookPrint);
    }


    public static bool UpdateLi_TempPricingBookPrint(Li_TempPricingBookPrint li_TempPricingBookPrint)
    {
        SqlLi_TempPricingBookPrintProvider sqlLi_TempPricingBookPrintProvider = new SqlLi_TempPricingBookPrintProvider();
        return sqlLi_TempPricingBookPrintProvider.UpdateLi_TempPricingBookPrint(li_TempPricingBookPrint);
    }

    public static bool DeleteLi_TempPricingBookPrint()
    {
        SqlLi_TempPricingBookPrintProvider sqlLi_TempPricingBookPrintProvider = new SqlLi_TempPricingBookPrintProvider();
        return sqlLi_TempPricingBookPrintProvider.DeleteLi_TempPricingBookPrint();
    }
}
