using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Paper_Delivery_DetailManager
{
	public Li_Paper_Delivery_DetailManager()
	{
	}

    public static List<Li_Paper_Delivery_Detail> GetAllLi_Paper_Delivery_Details()
    {
        List<Li_Paper_Delivery_Detail> li_Paper_Delivery_Details = new List<Li_Paper_Delivery_Detail>();
        SqlLi_Paper_Delivery_DetailProvider sqlLi_Paper_Delivery_DetailProvider = new SqlLi_Paper_Delivery_DetailProvider();
        li_Paper_Delivery_Details = sqlLi_Paper_Delivery_DetailProvider.GetAllLi_Paper_Delivery_Details();
        return li_Paper_Delivery_Details;
    }


    public static Li_Paper_Delivery_Detail GetLi_Paper_Delivery_DetailByID(int id)
    {
        Li_Paper_Delivery_Detail li_Paper_Delivery_Detail = new Li_Paper_Delivery_Detail();
        SqlLi_Paper_Delivery_DetailProvider sqlLi_Paper_Delivery_DetailProvider = new SqlLi_Paper_Delivery_DetailProvider();
        li_Paper_Delivery_Detail = sqlLi_Paper_Delivery_DetailProvider.GetLi_Paper_Delivery_DetailByID(id);
        return li_Paper_Delivery_Detail;
    }


    public static int InsertLi_Paper_Delivery_Detail(Li_Paper_Delivery_Detail li_Paper_Delivery_Detail)
    {
        SqlLi_Paper_Delivery_DetailProvider sqlLi_Paper_Delivery_DetailProvider = new SqlLi_Paper_Delivery_DetailProvider();
        return sqlLi_Paper_Delivery_DetailProvider.InsertLi_Paper_Delivery_Detail(li_Paper_Delivery_Detail);
    }


    public static bool UpdateLi_Paper_Delivery_Detail(Li_Paper_Delivery_Detail li_Paper_Delivery_Detail)
    {
        SqlLi_Paper_Delivery_DetailProvider sqlLi_Paper_Delivery_DetailProvider = new SqlLi_Paper_Delivery_DetailProvider();
        return sqlLi_Paper_Delivery_DetailProvider.UpdateLi_Paper_Delivery_Detail(li_Paper_Delivery_Detail);
    }

    public static bool DeleteLi_Paper_Delivery_Detail(int li_Paper_Delivery_DetailID)
    {
        SqlLi_Paper_Delivery_DetailProvider sqlLi_Paper_Delivery_DetailProvider = new SqlLi_Paper_Delivery_DetailProvider();
        return sqlLi_Paper_Delivery_DetailProvider.DeleteLi_Paper_Delivery_Detail(li_Paper_Delivery_DetailID);
    }


    public static DataTable GetQtyAndReceiptByPaperCode(string paperTypeId, string paperSizeId, string paperGsmId)
    {
        SqlLi_Paper_Delivery_DetailProvider sqlLi_Paper_Delivery_DetailProvider = new SqlLi_Paper_Delivery_DetailProvider();
        return sqlLi_Paper_Delivery_DetailProvider.GetQtyAndReceiptByPaperCode(     paperTypeId,   paperSizeId,   paperGsmId);
    }

}
