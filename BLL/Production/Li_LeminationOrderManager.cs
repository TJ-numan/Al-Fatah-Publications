using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LeminationOrderManager
{
	public Li_LeminationOrderManager()
	{
	}

    public static List<Li_LeminationOrder> GetAllLi_LeminationOrders()
    {
        List<Li_LeminationOrder> li_LeminationOrders = new List<Li_LeminationOrder>();
        SqlLi_LeminationOrderProvider sqlLi_LeminationOrderProvider = new SqlLi_LeminationOrderProvider();
        li_LeminationOrders = sqlLi_LeminationOrderProvider.GetAllLi_LeminationOrders();
        return li_LeminationOrders;
    }


    public static Li_LeminationOrder GetLi_LeminationOrderByID(int id)
    {
        Li_LeminationOrder li_LeminationOrder = new Li_LeminationOrder();
        SqlLi_LeminationOrderProvider sqlLi_LeminationOrderProvider = new SqlLi_LeminationOrderProvider();
        li_LeminationOrder = sqlLi_LeminationOrderProvider.GetLi_LeminationOrderByID(id);
        return li_LeminationOrder;
    }


    public static string  InsertLi_LeminationOrder(Li_LeminationOrder li_LeminationOrder)
    {
        SqlLi_LeminationOrderProvider sqlLi_LeminationOrderProvider = new SqlLi_LeminationOrderProvider();
        return sqlLi_LeminationOrderProvider.InsertLi_LeminationOrder(li_LeminationOrder);
    }


    public static bool UpdateLi_LeminationOrder(Li_LeminationOrder li_LeminationOrder)
    {
        SqlLi_LeminationOrderProvider sqlLi_LeminationOrderProvider = new SqlLi_LeminationOrderProvider();
        return sqlLi_LeminationOrderProvider.UpdateLi_LeminationOrder(li_LeminationOrder);
    }

    public static bool DeleteLi_LeminationOrder(int li_LeminationOrderID)
    {
        SqlLi_LeminationOrderProvider sqlLi_LeminationOrderProvider = new SqlLi_LeminationOrderProvider();
        return sqlLi_LeminationOrderProvider.DeleteLi_LeminationOrder(li_LeminationOrderID);
    }

    public static DataSet GetLeminationOrderForPrint(string LemiParty, string FromDate, string EndDate)
    {
         DataSet ds = new DataSet();     
         SqlLi_LeminationOrderProvider sqlLi_LeminationOrderProvider = new SqlLi_LeminationOrderProvider();
         ds = sqlLi_LeminationOrderProvider.GetLeminationOrderForPrint(LemiParty, FromDate, EndDate);
         return ds;
    }
}
