using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_ChalanDeliveryManager
{
	public Li_ChalanDeliveryManager()
	{
	}

    public static List<Li_ChalanDelivery> GetAllLi_ChalanDeliveries()
    {
        List<Li_ChalanDelivery> li_ChalanDeliveries = new List<Li_ChalanDelivery>();
        SqlLi_ChalanDeliveryProvider sqlLi_ChalanDeliveryProvider = new SqlLi_ChalanDeliveryProvider();
        li_ChalanDeliveries = sqlLi_ChalanDeliveryProvider.GetAllLi_ChalanDeliveries();
        return li_ChalanDeliveries;
    }


    public static Li_ChalanDelivery GetLi_ChalanDeliveryByID(int id)
    {
        Li_ChalanDelivery li_ChalanDelivery = new Li_ChalanDelivery();
        SqlLi_ChalanDeliveryProvider sqlLi_ChalanDeliveryProvider = new SqlLi_ChalanDeliveryProvider();
        li_ChalanDelivery = sqlLi_ChalanDeliveryProvider.GetLi_ChalanDeliveryByID(id);
        return li_ChalanDelivery;
    }


    public static int InsertLi_ChalanDelivery(Li_ChalanDelivery li_ChalanDelivery)
    {
        SqlLi_ChalanDeliveryProvider sqlLi_ChalanDeliveryProvider = new SqlLi_ChalanDeliveryProvider();
        return sqlLi_ChalanDeliveryProvider.InsertLi_ChalanDelivery(li_ChalanDelivery);
    }


    public static bool UpdateLi_ChalanDelivery(Li_ChalanDelivery li_ChalanDelivery)
    {
        SqlLi_ChalanDeliveryProvider sqlLi_ChalanDeliveryProvider = new SqlLi_ChalanDeliveryProvider();
        return sqlLi_ChalanDeliveryProvider.UpdateLi_ChalanDelivery(li_ChalanDelivery);
    }

    public static bool DeleteLi_ChalanDelivery(int li_ChalanDeliveryID)
    {
        SqlLi_ChalanDeliveryProvider sqlLi_ChalanDeliveryProvider = new SqlLi_ChalanDeliveryProvider();
        return sqlLi_ChalanDeliveryProvider.DeleteLi_ChalanDelivery(li_ChalanDeliveryID);
    }
}
