using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_StockDetailsManager
{
	public li_StockDetailsManager()
	{
	}

    public static List<li_StockDetails> GetAll_StockDetailss()
    {
        List<li_StockDetails> li_StockDetailss = new List<li_StockDetails>();
        SqlStockDetailsProvider Sql_li_StockDetailsProvider = new SqlStockDetailsProvider();
        li_StockDetailss = Sql_li_StockDetailsProvider.GetAllStockDetailss();
        return li_StockDetailss;
    }


    public static li_StockDetails Get_StockDetailsByStockID(string StockID)
    {
        li_StockDetails li_StockDetails = new li_StockDetails();
        SqlStockDetailsProvider Sql_li_StockDetailsProvider = new SqlStockDetailsProvider();
        li_StockDetails = Sql_li_StockDetailsProvider.GetStockDetailsByStockID(StockID);
        return li_StockDetails;
    }


    public static void  Insert_StockDetails(li_StockDetails li_StockDetails)
    {
        SqlStockDetailsProvider Sql_li_StockDetailsProvider = new SqlStockDetailsProvider();
        Sql_li_StockDetailsProvider.InsertStockDetails(li_StockDetails);
    }


    public static bool Update_StockDetails(li_StockDetails li_StockDetails)
    {
        SqlStockDetailsProvider Sql_li_StockDetailsProvider = new SqlStockDetailsProvider();
        return Sql_li_StockDetailsProvider.UpdateStockDetails(li_StockDetails);
    }

    public static bool Delete_StockDetails(int li_StockDetailsID)
    {
        SqlStockDetailsProvider Sql_li_StockDetailsProvider = new SqlStockDetailsProvider();
        return Sql_li_StockDetailsProvider.DeleteStockDetails(li_StockDetailsID);
    }
}

