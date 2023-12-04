using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BindOrderManager
{
	public Li_BindOrderManager()
	{
	}

    public static List<Li_BindOrder> GetAllLi_BindOrders()
    {
        List<Li_BindOrder> li_BindOrders = new List<Li_BindOrder>();
        SqlLi_BindOrderProvider sqlLi_BindOrderProvider = new SqlLi_BindOrderProvider();
        li_BindOrders = sqlLi_BindOrderProvider.GetAllLi_BindOrders();
        return li_BindOrders;
    }


    public static Li_BindOrder GetLi_BindOrderByID(int id)
    {
        Li_BindOrder li_BindOrder = new Li_BindOrder();
        SqlLi_BindOrderProvider sqlLi_BindOrderProvider = new SqlLi_BindOrderProvider();
        li_BindOrder = sqlLi_BindOrderProvider.GetLi_BindOrderByID(id);
        return li_BindOrder;
    }


    public static string  InsertLi_BindOrder(Li_BindOrder li_BindOrder)
    {
        SqlLi_BindOrderProvider sqlLi_BindOrderProvider = new SqlLi_BindOrderProvider();
        return sqlLi_BindOrderProvider.InsertLi_BindOrder(li_BindOrder);
    }


    public static bool UpdateLi_BindOrder(Li_BindOrder li_BindOrder)
    {
        SqlLi_BindOrderProvider sqlLi_BindOrderProvider = new SqlLi_BindOrderProvider();
        return sqlLi_BindOrderProvider.UpdateLi_BindOrder(li_BindOrder);
    }

    public static bool DeleteLi_BindOrder(int li_BindOrderID)
    {
        SqlLi_BindOrderProvider sqlLi_BindOrderProvider = new SqlLi_BindOrderProvider();
        return sqlLi_BindOrderProvider.DeleteLi_BindOrder(li_BindOrderID);
    }

    public static DataSet GetAll_BindOrder(string BID, string CID, string Type, string edition, string BiderID, string PressID, Boolean? Cov, Boolean? Inn, Boolean? Forma)
    {
        DataSet ds = new DataSet();
        SqlLi_BindOrderProvider sqlLi_BindOrderProvider = new SqlLi_BindOrderProvider();
        ds = sqlLi_BindOrderProvider.GetAll_BindOrder(BID, CID, Type, edition, BiderID, PressID, Cov, Inn, Forma);
        return ds;
    }
}
