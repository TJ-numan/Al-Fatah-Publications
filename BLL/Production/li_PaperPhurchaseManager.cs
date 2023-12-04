using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperPhurchaseManager
{
	public Li_PaperPhurchaseManager()
	{
	}

    public static List<Li_PaperPhurchase> GetAllLi_PaperPhurchases()
    {
        List<Li_PaperPhurchase> li_PaperPhurchases = new List<Li_PaperPhurchase>();
        SqlLi_PaperPhurchaseProvider sqlLi_PaperPhurchaseProvider = new SqlLi_PaperPhurchaseProvider();
        li_PaperPhurchases = sqlLi_PaperPhurchaseProvider.GetAllLi_PaperPhurchases();
        return li_PaperPhurchases;
    }


    public static Li_PaperPhurchase GetLi_PaperPhurchaseByID(int id)
    {
        Li_PaperPhurchase li_PaperPhurchase = new Li_PaperPhurchase();
        SqlLi_PaperPhurchaseProvider sqlLi_PaperPhurchaseProvider = new SqlLi_PaperPhurchaseProvider();
        li_PaperPhurchase = sqlLi_PaperPhurchaseProvider.GetLi_PaperPhurchaseByID(id);
        return li_PaperPhurchase;
    }


    public static string  InsertLi_PaperPhurchase(Li_PaperPhurchase li_PaperPhurchase)
    {
        SqlLi_PaperPhurchaseProvider sqlLi_PaperPhurchaseProvider = new SqlLi_PaperPhurchaseProvider();
        return sqlLi_PaperPhurchaseProvider.InsertLi_PaperPhurchase(li_PaperPhurchase);
    }


    public static bool UpdateLi_PaperPhurchase(Li_PaperPhurchase li_PaperPhurchase)
    {
        SqlLi_PaperPhurchaseProvider sqlLi_PaperPhurchaseProvider = new SqlLi_PaperPhurchaseProvider();
        return sqlLi_PaperPhurchaseProvider.UpdateLi_PaperPhurchase(li_PaperPhurchase);
    }

    public static bool DeleteLi_PaperPhurchase(int li_PaperPhurchaseID)
    {
        SqlLi_PaperPhurchaseProvider sqlLi_PaperPhurchaseProvider = new SqlLi_PaperPhurchaseProvider();
        return sqlLi_PaperPhurchaseProvider.DeleteLi_PaperPhurchase(li_PaperPhurchaseID);
    }


    public static DataSet Get_UndeliveredPurchaseOrder(string PartyID)
    {
        DataSet ds = new DataSet();
        SqlLi_PaperPhurchaseProvider sqlLi_PaperPhurchaseProvider = new SqlLi_PaperPhurchaseProvider();
        ds = sqlLi_PaperPhurchaseProvider . Get_UndeliveredPurchaseOrder(PartyID);
        return ds;
    }

    public static DataSet Get_UndeliveredPurchaseItemByOrder(string OrderID)
    {
        DataSet ds = new DataSet();
        SqlLi_PaperPhurchaseProvider sqlLi_PaperPhurchaseProvider = new SqlLi_PaperPhurchaseProvider();
        ds = sqlLi_PaperPhurchaseProvider. Get_UndeliveredPurchaseItemByOrder( OrderID);
        return ds;
    }
    public static DataSet Get_UndeliveredPurchaseItemByOrderAndParty(string OrderID, string PartyID)
    {
        DataSet ds = new DataSet();
        SqlLi_PaperPhurchaseProvider sqlLi_PaperPhurchaseProvider = new SqlLi_PaperPhurchaseProvider();
        ds = sqlLi_PaperPhurchaseProvider. Get_UndeliveredPurchaseItemByOrderAndParty( OrderID,PartyID);
        return ds;
    }
}
