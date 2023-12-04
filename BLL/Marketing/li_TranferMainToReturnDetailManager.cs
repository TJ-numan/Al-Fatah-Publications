using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TranferMainToReturnDetailManager
{
	public Li_TranferMainToReturnDetailManager()
	{
	}

    public static List<Li_TranferMainToReturnDetail> GetAllLi_TranferMainToReturnDetails()
    {
        List<Li_TranferMainToReturnDetail> li_TranferMainToReturnDetails = new List<Li_TranferMainToReturnDetail>();
        SqlLi_TranferMainToReturnDetailProvider sqlLi_TranferMainToReturnDetailProvider = new SqlLi_TranferMainToReturnDetailProvider();
        li_TranferMainToReturnDetails = sqlLi_TranferMainToReturnDetailProvider.GetAllLi_TranferMainToReturnDetails();
        return li_TranferMainToReturnDetails;
    }


    public static Li_TranferMainToReturnDetail GetLi_TranferMainToReturnDetailByID(int id)
    {
        Li_TranferMainToReturnDetail li_TranferMainToReturnDetail = new Li_TranferMainToReturnDetail();
        SqlLi_TranferMainToReturnDetailProvider sqlLi_TranferMainToReturnDetailProvider = new SqlLi_TranferMainToReturnDetailProvider();
        li_TranferMainToReturnDetail = sqlLi_TranferMainToReturnDetailProvider.GetLi_TranferMainToReturnDetailByID(id);
        return li_TranferMainToReturnDetail;
    }


    public static int InsertLi_TranferMainToReturnDetail(Li_TranferMainToReturnDetail li_TranferMainToReturnDetail)
    {
        SqlLi_TranferMainToReturnDetailProvider sqlLi_TranferMainToReturnDetailProvider = new SqlLi_TranferMainToReturnDetailProvider();
        return sqlLi_TranferMainToReturnDetailProvider.InsertLi_TranferMainToReturnDetail(li_TranferMainToReturnDetail);
    }


    public static bool UpdateLi_TranferMainToReturnDetail(Li_TranferMainToReturnDetail li_TranferMainToReturnDetail)
    {
        SqlLi_TranferMainToReturnDetailProvider sqlLi_TranferMainToReturnDetailProvider = new SqlLi_TranferMainToReturnDetailProvider();
        return sqlLi_TranferMainToReturnDetailProvider.UpdateLi_TranferMainToReturnDetail(li_TranferMainToReturnDetail);
    }

    public static bool DeleteLi_TranferMainToReturnDetail(int li_TranferMainToReturnDetailID)
    {
        SqlLi_TranferMainToReturnDetailProvider sqlLi_TranferMainToReturnDetailProvider = new SqlLi_TranferMainToReturnDetailProvider();
        return sqlLi_TranferMainToReturnDetailProvider.DeleteLi_TranferMainToReturnDetail(li_TranferMainToReturnDetailID);
    }
}
