using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



using Common.Marketing;

public class li_StockManager
{
	public li_StockManager()
	{
	}

    public static List<li_Stock> GetAll_Stocks()
    {
        List<li_Stock> li_Stocks = new List<li_Stock>();
        Sql_li_StockProvider Sql_li_StockProvider = new Sql_li_StockProvider();
        li_Stocks = Sql_li_StockProvider.GetAll_Stocks();
        return li_Stocks;
    }

    public static DataSet GetAllStocks(string BookGroup, string BookName, string Class, string Edition, string price)
    {

        Sql_li_StockProvider Sql_li_StockProvider = new Sql_li_StockProvider();
        return Sql_li_StockProvider.GetAllStocks(BookGroup,BookName, Class, Edition, price);

    }

    public static DataSet GetCurrentYearSalesStatus(string BookCode)
    {

        Sql_li_StockProvider Sql_li_StockProvider = new Sql_li_StockProvider();
        return Sql_li_StockProvider.GetCurrentYearSalesStatus (BookCode);

    }

    public static DataSet GetLastYearSalesStatus(string BookCode)
    {

        Sql_li_StockProvider Sql_li_StockProvider = new Sql_li_StockProvider();
        return Sql_li_StockProvider.GetLastYearSalesStatus(BookCode);

    }

    public static li_Stock Get_StockByBookAcCode(string BookAcCode)
    {
        li_Stock li_Stock = new li_Stock();
        Sql_li_StockProvider Sql_li_StockProvider = new Sql_li_StockProvider();
        li_Stock = Sql_li_StockProvider.Get_StockByBookAcCode(BookAcCode);
        return li_Stock;
    }


    public static int Insert_Stock(li_Stock li_Stock)
    {
        Sql_li_StockProvider Sql_li_StockProvider = new Sql_li_StockProvider();
        return Sql_li_StockProvider.Insert_Stock(li_Stock);
    }


    public static bool Update_Stock(li_Stock li_Stock,bool IsCentralStore)
    {
        Sql_li_StockProvider Sql_li_StockProvider = new Sql_li_StockProvider();
        return Sql_li_StockProvider.Update_Stock(li_Stock,IsCentralStore);
    }

    public static bool Delete_Stock(int li_StockID)
    {
        Sql_li_StockProvider Sql_li_StockProvider = new Sql_li_StockProvider();
        return Sql_li_StockProvider.Delete_Stock(li_StockID);
    }

    public static List<BookVersionInfo> GetAllStocksInformations()
    {
        Sql_li_StockProvider Sql_li_StockProvider = new Sql_li_StockProvider();
         return Sql_li_StockProvider.GetAllStockInformations();
    }
}

