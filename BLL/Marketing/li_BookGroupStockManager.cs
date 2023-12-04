using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookGroupStockManager
{
	public Li_BookGroupStockManager()
	{
	}

    public static List<Li_BookGroupStock> GetAllLi_BookGroupStocks()
    {
        List<Li_BookGroupStock> li_BookGroupStocks = new List<Li_BookGroupStock>();
        SqlLi_BookGroupStockProvider sqlLi_BookGroupStockProvider = new SqlLi_BookGroupStockProvider();
        li_BookGroupStocks = sqlLi_BookGroupStockProvider.GetAllLi_BookGroupStocks();
        return li_BookGroupStocks;
    }


    public static Li_BookGroupStock GetLi_BookGroupStockByID(int id)
    {
        Li_BookGroupStock li_BookGroupStock = new Li_BookGroupStock();
        SqlLi_BookGroupStockProvider sqlLi_BookGroupStockProvider = new SqlLi_BookGroupStockProvider();
        li_BookGroupStock = sqlLi_BookGroupStockProvider.GetLi_BookGroupStockByID(id);
        return li_BookGroupStock;
    }


    public static int InsertLi_BookGroupStock(Li_BookGroupStock li_BookGroupStock)
    {
        SqlLi_BookGroupStockProvider sqlLi_BookGroupStockProvider = new SqlLi_BookGroupStockProvider();
        return sqlLi_BookGroupStockProvider.InsertLi_BookGroupStock(li_BookGroupStock);
    }


    public static bool UpdateLi_BookGroupStock(Li_BookGroupStock li_BookGroupStock)
    {
        SqlLi_BookGroupStockProvider sqlLi_BookGroupStockProvider = new SqlLi_BookGroupStockProvider();
        return sqlLi_BookGroupStockProvider.UpdateLi_BookGroupStock(li_BookGroupStock);
    }

    public static bool DeleteLi_BookGroupStock(int li_BookGroupStockID)
    {
        SqlLi_BookGroupStockProvider sqlLi_BookGroupStockProvider = new SqlLi_BookGroupStockProvider();
        return sqlLi_BookGroupStockProvider.DeleteLi_BookGroupStock(li_BookGroupStockID);
    }
}
