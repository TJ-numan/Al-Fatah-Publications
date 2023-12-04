using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlatePurchaseDetailManager
{
	public Li_PlatePurchaseDetailManager()
	{
	}

    public static List<Li_PlatePurchaseDetail> GetAllLi_PlatePurchaseDetails()
    {
        List<Li_PlatePurchaseDetail> li_PlatePurchaseDetails = new List<Li_PlatePurchaseDetail>();
        SqlLi_PlatePurchaseDetailProvider sqlLi_PlatePurchaseDetailProvider = new SqlLi_PlatePurchaseDetailProvider();
        li_PlatePurchaseDetails = sqlLi_PlatePurchaseDetailProvider.GetAllLi_PlatePurchaseDetails();
        return li_PlatePurchaseDetails;
    }


    public static Li_PlatePurchaseDetail GetLi_PlatePurchaseDetailByID(int id)
    {
        Li_PlatePurchaseDetail li_PlatePurchaseDetail = new Li_PlatePurchaseDetail();
        SqlLi_PlatePurchaseDetailProvider sqlLi_PlatePurchaseDetailProvider = new SqlLi_PlatePurchaseDetailProvider();
        li_PlatePurchaseDetail = sqlLi_PlatePurchaseDetailProvider.GetLi_PlatePurchaseDetailByID(id);
        return li_PlatePurchaseDetail;
    }


    public static int InsertLi_PlatePurchaseDetail(Li_PlatePurchaseDetail li_PlatePurchaseDetail)
    {
        SqlLi_PlatePurchaseDetailProvider sqlLi_PlatePurchaseDetailProvider = new SqlLi_PlatePurchaseDetailProvider();
        return sqlLi_PlatePurchaseDetailProvider.InsertLi_PlatePurchaseDetail(li_PlatePurchaseDetail);
    }


    public static bool UpdateLi_PlatePurchaseDetail(Li_PlatePurchaseDetail li_PlatePurchaseDetail)
    {
        SqlLi_PlatePurchaseDetailProvider sqlLi_PlatePurchaseDetailProvider = new SqlLi_PlatePurchaseDetailProvider();
        return sqlLi_PlatePurchaseDetailProvider.UpdateLi_PlatePurchaseDetail(li_PlatePurchaseDetail);
    }

    public static bool DeleteLi_PlatePurchaseDetail(int li_PlatePurchaseDetailID)
    {
        SqlLi_PlatePurchaseDetailProvider sqlLi_PlatePurchaseDetailProvider = new SqlLi_PlatePurchaseDetailProvider();
        return sqlLi_PlatePurchaseDetailProvider.DeleteLi_PlatePurchaseDetail(li_PlatePurchaseDetailID);
    }
}
