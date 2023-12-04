using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_StockAdjustmentManager
{
	public Li_StockAdjustmentManager()
	{
	}

    public static List<Li_StockAdjustment> GetAllLi_StockAdjustments()
    {
        List<Li_StockAdjustment> li_StockAdjustments = new List<Li_StockAdjustment>();
        SqlLi_StockAdjustmentProvider sqlLi_StockAdjustmentProvider = new SqlLi_StockAdjustmentProvider();
        li_StockAdjustments = sqlLi_StockAdjustmentProvider.GetAllLi_StockAdjustments();
        return li_StockAdjustments;
    }


    public static Li_StockAdjustment GetLi_StockAdjustmentByID(int id)
    {
        Li_StockAdjustment li_StockAdjustment = new Li_StockAdjustment();
        SqlLi_StockAdjustmentProvider sqlLi_StockAdjustmentProvider = new SqlLi_StockAdjustmentProvider();
        li_StockAdjustment = sqlLi_StockAdjustmentProvider.GetLi_StockAdjustmentByID(id);
        return li_StockAdjustment;
    }


    public static int InsertLi_StockAdjustment(Li_StockAdjustment li_StockAdjustment)
    {
        SqlLi_StockAdjustmentProvider sqlLi_StockAdjustmentProvider = new SqlLi_StockAdjustmentProvider();
        return sqlLi_StockAdjustmentProvider.InsertLi_StockAdjustment(li_StockAdjustment);
    }


    public static bool UpdateLi_StockAdjustment(Li_StockAdjustment li_StockAdjustment)
    {
        SqlLi_StockAdjustmentProvider sqlLi_StockAdjustmentProvider = new SqlLi_StockAdjustmentProvider();
        return sqlLi_StockAdjustmentProvider.UpdateLi_StockAdjustment(li_StockAdjustment);
    }

    public static bool DeleteLi_StockAdjustment(int li_StockAdjustmentID)
    {
        SqlLi_StockAdjustmentProvider sqlLi_StockAdjustmentProvider = new SqlLi_StockAdjustmentProvider();
        return sqlLi_StockAdjustmentProvider.DeleteLi_StockAdjustment(li_StockAdjustmentID);
    }
}
