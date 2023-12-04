using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Print_Order_FormaDetailsManager
{
	public Li_Print_Order_FormaDetailsManager()
	{
	}

    public static List<Li_Print_Order_FormaDetails> GetAllLi_Print_Order_FormaDetailss()
    {
        List<Li_Print_Order_FormaDetails> li_Print_Order_FormaDetailss = new List<Li_Print_Order_FormaDetails>();
        SqlLi_Print_Order_FormaDetailsProvider sqlLi_Print_Order_FormaDetailsProvider = new SqlLi_Print_Order_FormaDetailsProvider();
        li_Print_Order_FormaDetailss = sqlLi_Print_Order_FormaDetailsProvider.GetAllLi_Print_Order_FormaDetailss();
        return li_Print_Order_FormaDetailss;
    }


    public static Li_Print_Order_FormaDetails GetLi_Print_Order_FormaDetailsByID(int id)
    {
        Li_Print_Order_FormaDetails li_Print_Order_FormaDetails = new Li_Print_Order_FormaDetails();
        SqlLi_Print_Order_FormaDetailsProvider sqlLi_Print_Order_FormaDetailsProvider = new SqlLi_Print_Order_FormaDetailsProvider();
        li_Print_Order_FormaDetails = sqlLi_Print_Order_FormaDetailsProvider.GetLi_Print_Order_FormaDetailsByID(id);
        return li_Print_Order_FormaDetails;
    }


    public static int InsertLi_Print_Order_FormaDetails(Li_Print_Order_FormaDetails li_Print_Order_FormaDetails)
    {
        SqlLi_Print_Order_FormaDetailsProvider sqlLi_Print_Order_FormaDetailsProvider = new SqlLi_Print_Order_FormaDetailsProvider();
        return sqlLi_Print_Order_FormaDetailsProvider.InsertLi_Print_Order_FormaDetails(li_Print_Order_FormaDetails);
    }


    public static bool UpdateLi_Print_Order_FormaDetails(Li_Print_Order_FormaDetails li_Print_Order_FormaDetails)
    {
        SqlLi_Print_Order_FormaDetailsProvider sqlLi_Print_Order_FormaDetailsProvider = new SqlLi_Print_Order_FormaDetailsProvider();
        return sqlLi_Print_Order_FormaDetailsProvider.UpdateLi_Print_Order_FormaDetails(li_Print_Order_FormaDetails);
    }

    public static bool DeleteLi_Print_Order_FormaDetails(int li_Print_Order_FormaDetailsID)
    {
        SqlLi_Print_Order_FormaDetailsProvider sqlLi_Print_Order_FormaDetailsProvider = new SqlLi_Print_Order_FormaDetailsProvider();
        return sqlLi_Print_Order_FormaDetailsProvider.DeleteLi_Print_Order_FormaDetails(li_Print_Order_FormaDetailsID);
    }
}
