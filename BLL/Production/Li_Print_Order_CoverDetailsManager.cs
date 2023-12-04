using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Print_Order_CoverDetailsManager
{
	public Li_Print_Order_CoverDetailsManager()
	{
	}

    public static List<Li_Print_Order_CoverDetails> GetAllLi_Print_Order_CoverDetailss()
    {
        List<Li_Print_Order_CoverDetails> li_Print_Order_CoverDetailss = new List<Li_Print_Order_CoverDetails>();
        SqlLi_Print_Order_CoverDetailsProvider sqlLi_Print_Order_CoverDetailsProvider = new SqlLi_Print_Order_CoverDetailsProvider();
        li_Print_Order_CoverDetailss = sqlLi_Print_Order_CoverDetailsProvider.GetAllLi_Print_Order_CoverDetailss();
        return li_Print_Order_CoverDetailss;
    }


    public static Li_Print_Order_CoverDetails GetLi_Print_Order_CoverDetailsByID(int id)
    {
        Li_Print_Order_CoverDetails li_Print_Order_CoverDetails = new Li_Print_Order_CoverDetails();
        SqlLi_Print_Order_CoverDetailsProvider sqlLi_Print_Order_CoverDetailsProvider = new SqlLi_Print_Order_CoverDetailsProvider();
        li_Print_Order_CoverDetails = sqlLi_Print_Order_CoverDetailsProvider.GetLi_Print_Order_CoverDetailsByID(id);
        return li_Print_Order_CoverDetails;
    }


    public static int InsertLi_Print_Order_CoverDetails(Li_Print_Order_CoverDetails li_Print_Order_CoverDetails)
    {
        SqlLi_Print_Order_CoverDetailsProvider sqlLi_Print_Order_CoverDetailsProvider = new SqlLi_Print_Order_CoverDetailsProvider();
        return sqlLi_Print_Order_CoverDetailsProvider.InsertLi_Print_Order_CoverDetails(li_Print_Order_CoverDetails);
    }


    public static bool UpdateLi_Print_Order_CoverDetails(Li_Print_Order_CoverDetails li_Print_Order_CoverDetails)
    {
        SqlLi_Print_Order_CoverDetailsProvider sqlLi_Print_Order_CoverDetailsProvider = new SqlLi_Print_Order_CoverDetailsProvider();
        return sqlLi_Print_Order_CoverDetailsProvider.UpdateLi_Print_Order_CoverDetails(li_Print_Order_CoverDetails);
    }

    public static bool DeleteLi_Print_Order_CoverDetails(int li_Print_Order_CoverDetailsID)
    {
        SqlLi_Print_Order_CoverDetailsProvider sqlLi_Print_Order_CoverDetailsProvider = new SqlLi_Print_Order_CoverDetailsProvider();
        return sqlLi_Print_Order_CoverDetailsProvider.DeleteLi_Print_Order_CoverDetails(li_Print_Order_CoverDetailsID);
    }
}
