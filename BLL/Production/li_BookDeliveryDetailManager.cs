using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookDeliveryDetailManager
{
	public Li_BookDeliveryDetailManager()
	{
	}

    public static List<Li_BookDeliveryDetail> GetAllLi_BookDeliveryDetails()
    {
        List<Li_BookDeliveryDetail> li_BookDeliveryDetails = new List<Li_BookDeliveryDetail>();
        SqlLi_BookDeliveryDetailProvider sqlLi_BookDeliveryDetailProvider = new SqlLi_BookDeliveryDetailProvider();
        li_BookDeliveryDetails = sqlLi_BookDeliveryDetailProvider.GetAllLi_BookDeliveryDetails();
        return li_BookDeliveryDetails;
    }


    public static Li_BookDeliveryDetail GetLi_BookDeliveryDetailByID(int id)
    {
        Li_BookDeliveryDetail li_BookDeliveryDetail = new Li_BookDeliveryDetail();
        SqlLi_BookDeliveryDetailProvider sqlLi_BookDeliveryDetailProvider = new SqlLi_BookDeliveryDetailProvider();
        li_BookDeliveryDetail = sqlLi_BookDeliveryDetailProvider.GetLi_BookDeliveryDetailByID(id);
        return li_BookDeliveryDetail;
    }


    public static int InsertLi_BookDeliveryDetail(Li_BookDeliveryDetail li_BookDeliveryDetail)
    {
        SqlLi_BookDeliveryDetailProvider sqlLi_BookDeliveryDetailProvider = new SqlLi_BookDeliveryDetailProvider();
        return sqlLi_BookDeliveryDetailProvider.InsertLi_BookDeliveryDetail(li_BookDeliveryDetail);
    }


    public static bool UpdateLi_BookDeliveryDetail(Li_BookDeliveryDetail li_BookDeliveryDetail)
    {
        SqlLi_BookDeliveryDetailProvider sqlLi_BookDeliveryDetailProvider = new SqlLi_BookDeliveryDetailProvider();
        return sqlLi_BookDeliveryDetailProvider.UpdateLi_BookDeliveryDetail(li_BookDeliveryDetail);
    }

    public static bool DeleteLi_BookDeliveryDetail(int li_BookDeliveryDetailID)
    {
        SqlLi_BookDeliveryDetailProvider sqlLi_BookDeliveryDetailProvider = new SqlLi_BookDeliveryDetailProvider();
        return sqlLi_BookDeliveryDetailProvider.DeleteLi_BookDeliveryDetail(li_BookDeliveryDetailID);
    }
}
