using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlatePurchaseManager
{
	public Li_PlatePurchaseManager()
	{
	}

    public static List<Li_PlatePurchase> GetAllLi_PlatePurchases()
    {
        List<Li_PlatePurchase> li_PlatePurchases = new List<Li_PlatePurchase>();
        SqlLi_PlatePurchaseProvider sqlLi_PlatePurchaseProvider = new SqlLi_PlatePurchaseProvider();
        li_PlatePurchases = sqlLi_PlatePurchaseProvider.GetAllLi_PlatePurchases();
        return li_PlatePurchases;
    }


    public static Li_PlatePurchase GetLi_PlatePurchaseByID(int id)
    {
        Li_PlatePurchase li_PlatePurchase = new Li_PlatePurchase();
        SqlLi_PlatePurchaseProvider sqlLi_PlatePurchaseProvider = new SqlLi_PlatePurchaseProvider();
        li_PlatePurchase = sqlLi_PlatePurchaseProvider.GetLi_PlatePurchaseByID(id);
        return li_PlatePurchase;
    }


    public static string  InsertLi_PlatePurchase(Li_PlatePurchase li_PlatePurchase)
    {
        SqlLi_PlatePurchaseProvider sqlLi_PlatePurchaseProvider = new SqlLi_PlatePurchaseProvider();
        return sqlLi_PlatePurchaseProvider.InsertLi_PlatePurchase(li_PlatePurchase);
    }


    public static bool UpdateLi_PlatePurchase(Li_PlatePurchase li_PlatePurchase)
    {
        SqlLi_PlatePurchaseProvider sqlLi_PlatePurchaseProvider = new SqlLi_PlatePurchaseProvider();
        return sqlLi_PlatePurchaseProvider.UpdateLi_PlatePurchase(li_PlatePurchase);
    }

    public static bool DeleteLi_PlatePurchase(int li_PlatePurchaseID)
    {
        SqlLi_PlatePurchaseProvider sqlLi_PlatePurchaseProvider = new SqlLi_PlatePurchaseProvider();
        return sqlLi_PlatePurchaseProvider.DeleteLi_PlatePurchase(li_PlatePurchaseID);
    }

   

}
