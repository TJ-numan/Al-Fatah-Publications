using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetDeliveryManager
{
	public Li_AssetDeliveryManager()
	{
	}

    public static List<Li_AssetDelivery> GetAllLi_AssetDeliveries()
    {
        List<Li_AssetDelivery> li_AssetDeliveries = new List<Li_AssetDelivery>();
        SqlLi_AssetDeliveryProvider sqlLi_AssetDeliveryProvider = new SqlLi_AssetDeliveryProvider();
        li_AssetDeliveries = sqlLi_AssetDeliveryProvider.GetAllLi_AssetDeliveries();
        return li_AssetDeliveries;
    }


    public static Li_AssetDelivery GetLi_AssetDeliveryByID(int id)
    {
        Li_AssetDelivery li_AssetDelivery = new Li_AssetDelivery();
        SqlLi_AssetDeliveryProvider sqlLi_AssetDeliveryProvider = new SqlLi_AssetDeliveryProvider();
        li_AssetDelivery = sqlLi_AssetDeliveryProvider.GetLi_AssetDeliveryByID(id);
        return li_AssetDelivery;
    }


    public static int InsertLi_AssetDelivery(Li_AssetDelivery li_AssetDelivery)
    {
        SqlLi_AssetDeliveryProvider sqlLi_AssetDeliveryProvider = new SqlLi_AssetDeliveryProvider();
        return sqlLi_AssetDeliveryProvider.InsertLi_AssetDelivery(li_AssetDelivery);
    }


    public static bool UpdateLi_AssetDelivery(Li_AssetDelivery li_AssetDelivery)
    {
        SqlLi_AssetDeliveryProvider sqlLi_AssetDeliveryProvider = new SqlLi_AssetDeliveryProvider();
        return sqlLi_AssetDeliveryProvider.UpdateLi_AssetDelivery(li_AssetDelivery);
    }

    public static bool DeleteLi_AssetDelivery(int li_AssetDeliveryID)
    {
        SqlLi_AssetDeliveryProvider sqlLi_AssetDeliveryProvider = new SqlLi_AssetDeliveryProvider();
        return sqlLi_AssetDeliveryProvider.DeleteLi_AssetDelivery(li_AssetDeliveryID);
    }
}
