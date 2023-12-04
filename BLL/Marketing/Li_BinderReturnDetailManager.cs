using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;


public class Li_BinderReturnDetailManager
{
	public Li_BinderReturnDetailManager()
	{
	}

    public static List<Li_BinderReturnDetail> GetAllLi_BinderReturnDetails()
    {
        List<Li_BinderReturnDetail> li_BinderReturnDetails = new List<Li_BinderReturnDetail>();
        SqlLi_BinderReturnDetailProvider sqlLi_BinderReturnDetailProvider = new SqlLi_BinderReturnDetailProvider();
        li_BinderReturnDetails = sqlLi_BinderReturnDetailProvider.GetAllLi_BinderReturnDetails();
        return li_BinderReturnDetails;
    }


    public static Li_BinderReturnDetail GetLi_BinderReturnDetailByID(int id)
    {
        Li_BinderReturnDetail li_BinderReturnDetail = new Li_BinderReturnDetail();
        SqlLi_BinderReturnDetailProvider sqlLi_BinderReturnDetailProvider = new SqlLi_BinderReturnDetailProvider();
        li_BinderReturnDetail = sqlLi_BinderReturnDetailProvider.GetLi_BinderReturnDetailByID(id);
        return li_BinderReturnDetail;
    }


    public static int InsertLi_BinderReturnDetail(Li_BinderReturnDetail li_BinderReturnDetail)
    {
        SqlLi_BinderReturnDetailProvider sqlLi_BinderReturnDetailProvider = new SqlLi_BinderReturnDetailProvider();
        return sqlLi_BinderReturnDetailProvider.InsertLi_BinderReturnDetail(li_BinderReturnDetail);
    }


    public static bool UpdateLi_BinderReturnDetail(Li_BinderReturnDetail li_BinderReturnDetail)
    {
        SqlLi_BinderReturnDetailProvider sqlLi_BinderReturnDetailProvider = new SqlLi_BinderReturnDetailProvider();
        return sqlLi_BinderReturnDetailProvider.UpdateLi_BinderReturnDetail(li_BinderReturnDetail);
    }

    public static bool DeleteLi_BinderReturnDetail(int li_BinderReturnDetailID)
    {
        SqlLi_BinderReturnDetailProvider sqlLi_BinderReturnDetailProvider = new SqlLi_BinderReturnDetailProvider();
        return sqlLi_BinderReturnDetailProvider.DeleteLi_BinderReturnDetail(li_BinderReturnDetailID);
    }
}
