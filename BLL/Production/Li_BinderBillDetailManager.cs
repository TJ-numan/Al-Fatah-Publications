using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BinderBillDetailManager
{
	public Li_BinderBillDetailManager()
	{
	}

    public static List<Li_BinderBillDetail> GetAllLi_BinderBillDetails()
    {
        List<Li_BinderBillDetail> li_BinderBillDetails = new List<Li_BinderBillDetail>();
        SqlLi_BinderBillDetailProvider sqlLi_BinderBillDetailProvider = new SqlLi_BinderBillDetailProvider();
        li_BinderBillDetails = sqlLi_BinderBillDetailProvider.GetAllLi_BinderBillDetails();
        return li_BinderBillDetails;
    }


    public static Li_BinderBillDetail GetLi_BinderBillDetailByID(int id)
    {
        Li_BinderBillDetail li_BinderBillDetail = new Li_BinderBillDetail();
        SqlLi_BinderBillDetailProvider sqlLi_BinderBillDetailProvider = new SqlLi_BinderBillDetailProvider();
        li_BinderBillDetail = sqlLi_BinderBillDetailProvider.GetLi_BinderBillDetailByID(id);
        return li_BinderBillDetail;
    }


    public static int InsertLi_BinderBillDetail(Li_BinderBillDetail li_BinderBillDetail)
    {
        SqlLi_BinderBillDetailProvider sqlLi_BinderBillDetailProvider = new SqlLi_BinderBillDetailProvider();
        return sqlLi_BinderBillDetailProvider.InsertLi_BinderBillDetail(li_BinderBillDetail);
    }


    public static bool UpdateLi_BinderBillDetail(Li_BinderBillDetail li_BinderBillDetail)
    {
        SqlLi_BinderBillDetailProvider sqlLi_BinderBillDetailProvider = new SqlLi_BinderBillDetailProvider();
        return sqlLi_BinderBillDetailProvider.UpdateLi_BinderBillDetail(li_BinderBillDetail);
    }

    public static bool DeleteLi_BinderBillDetail(int li_BinderBillDetailID)
    {
        SqlLi_BinderBillDetailProvider sqlLi_BinderBillDetailProvider = new SqlLi_BinderBillDetailProvider();
        return sqlLi_BinderBillDetailProvider.DeleteLi_BinderBillDetail(li_BinderBillDetailID);
    }
}
