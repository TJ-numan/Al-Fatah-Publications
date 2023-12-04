using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Print_Order_FormaManager
{
	public Li_Print_Order_FormaManager()
	{
	}

    public static List<Li_Print_Order_Forma> GetAllLi_Print_Order_Formas()
    {
        List<Li_Print_Order_Forma> li_Print_Order_Formas = new List<Li_Print_Order_Forma>();
        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        li_Print_Order_Formas = sqlLi_Print_Order_FormaProvider.GetAllLi_Print_Order_Formas();
        return li_Print_Order_Formas;
    }


    public static Li_Print_Order_Forma GetLi_Print_Order_FormaByID(int id)
    {
        Li_Print_Order_Forma li_Print_Order_Forma = new Li_Print_Order_Forma();
        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        li_Print_Order_Forma = sqlLi_Print_Order_FormaProvider.GetLi_Print_Order_FormaByID(id);
        return li_Print_Order_Forma;
    }


    public static string  InsertLi_Print_Order_Forma(Li_Print_Order_Forma li_Print_Order_Forma)
    {
        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        return sqlLi_Print_Order_FormaProvider.InsertLi_Print_Order_Forma(li_Print_Order_Forma);
    }


    public static bool UpdateLi_Print_Order_Forma(Li_Print_Order_Forma li_Print_Order_Forma)
    {
        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        return sqlLi_Print_Order_FormaProvider.UpdateLi_Print_Order_Forma(li_Print_Order_Forma);
    }

    public static bool DeleteLi_Print_Order_Forma(int li_Print_Order_FormaID)
    {
        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        return sqlLi_Print_Order_FormaProvider.DeleteLi_Print_Order_Forma(li_Print_Order_FormaID);
    }

  
    public static DataSet GetPrintOrderInforByOrderNo(string OrderNo)
    {

        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        return  sqlLi_Print_Order_FormaProvider.GetPrintOrderInforByOrderNo(   OrderNo);

    }

    public static DataSet GetPrintOrderInforByOrderNoAndPress(string OrderNo, string PressID, string OrderFor, bool ExtraPlate,bool ForBill)
    {

        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        return sqlLi_Print_Order_FormaProvider.GetPrintOrderInforByOrderNoAndPress(OrderNo, PressID, OrderFor, ExtraPlate,ForBill);

    }

    public static DataSet GetPrintOrderInforByDistinctPress(string OrderNo, string OrderFor) 
    {

        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        return sqlLi_Print_Order_FormaProvider.GetPrintOrderInforByDistinctPress(OrderNo, OrderFor);

    }


    public static DataSet getPrintOrderFormaInfoByBookID(string BookID)
    {

        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        return  sqlLi_Print_Order_FormaProvider.getPrintOrderFormaInfoByBookID(BookID);

    }



    public static DataSet getPrintOrderFormaOderNoInfoByBookIDEdition(string BookID, string Edition)
    {

        SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
        return  sqlLi_Print_Order_FormaProvider.getPrintOrderFormaOderNoInfoByBookIDEdition (BookID,Edition );

    }



    public static DataSet getPrintingOrderInfoDetailByBookIDEditionOrder(string BookID, string Edition, string OrderNo)
    {

         SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
         return  sqlLi_Print_Order_FormaProvider.getPrintingOrderInfoDetailByBookIDEditionOrder(BookID, Edition, OrderNo);

    }

    public static  DataSet getPrintingQtyAndPrintSl(string BookCode, char  PrintFor)
    {

         SqlLi_Print_Order_FormaProvider sqlLi_Print_Order_FormaProvider = new SqlLi_Print_Order_FormaProvider();
         return  sqlLi_Print_Order_FormaProvider.getPrintingQtyAndPrintSl(  BookCode,   PrintFor);

    }
}
