using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookDeliveryToBinderManager
{
	public Li_BookDeliveryToBinderManager()
	{
	}

    public static List<Li_BookDeliveryToBinder> GetAllLi_BookDeliveryToBinders()
    {
        List<Li_BookDeliveryToBinder> li_BookDeliveryToBinders = new List<Li_BookDeliveryToBinder>();
        SqlLi_BookDeliveryToBinderProvider sqlLi_BookDeliveryToBinderProvider = new SqlLi_BookDeliveryToBinderProvider();
        li_BookDeliveryToBinders = sqlLi_BookDeliveryToBinderProvider.GetAllLi_BookDeliveryToBinders();
        return li_BookDeliveryToBinders;
    }


    public static Li_BookDeliveryToBinder GetLi_BookDeliveryToBinderByID(int id)
    {
        Li_BookDeliveryToBinder li_BookDeliveryToBinder = new Li_BookDeliveryToBinder();
        SqlLi_BookDeliveryToBinderProvider sqlLi_BookDeliveryToBinderProvider = new SqlLi_BookDeliveryToBinderProvider();
        li_BookDeliveryToBinder = sqlLi_BookDeliveryToBinderProvider.GetLi_BookDeliveryToBinderByID(id);
        return li_BookDeliveryToBinder;
    }


    public static int InsertLi_BookDeliveryToBinder(Li_BookDeliveryToBinder li_BookDeliveryToBinder)
    {
        SqlLi_BookDeliveryToBinderProvider sqlLi_BookDeliveryToBinderProvider = new SqlLi_BookDeliveryToBinderProvider();
        return sqlLi_BookDeliveryToBinderProvider.InsertLi_BookDeliveryToBinder(li_BookDeliveryToBinder);
    }


    public static bool UpdateLi_BookDeliveryToBinder(Li_BookDeliveryToBinder li_BookDeliveryToBinder)
    {
        SqlLi_BookDeliveryToBinderProvider sqlLi_BookDeliveryToBinderProvider = new SqlLi_BookDeliveryToBinderProvider();
        return sqlLi_BookDeliveryToBinderProvider.UpdateLi_BookDeliveryToBinder(li_BookDeliveryToBinder);
    }

    public static bool DeleteLi_BookDeliveryToBinder(int li_BookDeliveryToBinderID)
    {
        SqlLi_BookDeliveryToBinderProvider sqlLi_BookDeliveryToBinderProvider = new SqlLi_BookDeliveryToBinderProvider();
        return sqlLi_BookDeliveryToBinderProvider.DeleteLi_BookDeliveryToBinder(li_BookDeliveryToBinderID);
    }
}
