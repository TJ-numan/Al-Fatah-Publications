using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LeminationOrderDetailManager
{
	public Li_LeminationOrderDetailManager()
	{
	}

    public static List<Li_LeminationOrderDetail> GetAllLi_LeminationOrderDetails()
    {
        List<Li_LeminationOrderDetail> li_LeminationOrderDetails = new List<Li_LeminationOrderDetail>();
        SqlLi_LeminationOrderDetailProvider sqlLi_LeminationOrderDetailProvider = new SqlLi_LeminationOrderDetailProvider();
        li_LeminationOrderDetails = sqlLi_LeminationOrderDetailProvider.GetAllLi_LeminationOrderDetails();
        return li_LeminationOrderDetails;
    }


    public static Li_LeminationOrderDetail GetLi_LeminationOrderDetailByID(int id)
    {
        Li_LeminationOrderDetail li_LeminationOrderDetail = new Li_LeminationOrderDetail();
        SqlLi_LeminationOrderDetailProvider sqlLi_LeminationOrderDetailProvider = new SqlLi_LeminationOrderDetailProvider();
        li_LeminationOrderDetail = sqlLi_LeminationOrderDetailProvider.GetLi_LeminationOrderDetailByID(id);
        return li_LeminationOrderDetail;
    }


    public static int InsertLi_LeminationOrderDetail(Li_LeminationOrderDetail li_LeminationOrderDetail)
    {
        SqlLi_LeminationOrderDetailProvider sqlLi_LeminationOrderDetailProvider = new SqlLi_LeminationOrderDetailProvider();
        return sqlLi_LeminationOrderDetailProvider.InsertLi_LeminationOrderDetail(li_LeminationOrderDetail);
    }


    public static bool UpdateLi_LeminationOrderDetail(Li_LeminationOrderDetail li_LeminationOrderDetail)
    {
        SqlLi_LeminationOrderDetailProvider sqlLi_LeminationOrderDetailProvider = new SqlLi_LeminationOrderDetailProvider();
        return sqlLi_LeminationOrderDetailProvider.UpdateLi_LeminationOrderDetail(li_LeminationOrderDetail);
    }

    public static bool DeleteLi_LeminationOrderDetail(int li_LeminationOrderDetailID)
    {
        SqlLi_LeminationOrderDetailProvider sqlLi_LeminationOrderDetailProvider = new SqlLi_LeminationOrderDetailProvider();
        return sqlLi_LeminationOrderDetailProvider.DeleteLi_LeminationOrderDetail(li_LeminationOrderDetailID);
    }
}
