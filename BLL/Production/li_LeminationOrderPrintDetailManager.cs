using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LeminationOrderPrintDetailManager
{
	public Li_LeminationOrderPrintDetailManager()
	{
	}

    public static List<Li_LeminationOrderPrintDetail> GetAllLi_LeminationOrderPrintDetails()
    {
        List<Li_LeminationOrderPrintDetail> li_LeminationOrderPrintDetails = new List<Li_LeminationOrderPrintDetail>();
        SqlLi_LeminationOrderPrintDetailProvider sqlLi_LeminationOrderPrintDetailProvider = new SqlLi_LeminationOrderPrintDetailProvider();
        li_LeminationOrderPrintDetails = sqlLi_LeminationOrderPrintDetailProvider.GetAllLi_LeminationOrderPrintDetails();
        return li_LeminationOrderPrintDetails;
    }


    public static Li_LeminationOrderPrintDetail GetLi_LeminationOrderPrintDetailByID(int id)
    {
        Li_LeminationOrderPrintDetail li_LeminationOrderPrintDetail = new Li_LeminationOrderPrintDetail();
        SqlLi_LeminationOrderPrintDetailProvider sqlLi_LeminationOrderPrintDetailProvider = new SqlLi_LeminationOrderPrintDetailProvider();
        li_LeminationOrderPrintDetail = sqlLi_LeminationOrderPrintDetailProvider.GetLi_LeminationOrderPrintDetailByID(id);
        return li_LeminationOrderPrintDetail;
    }


    public static int InsertLi_LeminationOrderPrintDetail(Li_LeminationOrderPrintDetail li_LeminationOrderPrintDetail)
    {
        SqlLi_LeminationOrderPrintDetailProvider sqlLi_LeminationOrderPrintDetailProvider = new SqlLi_LeminationOrderPrintDetailProvider();
        return sqlLi_LeminationOrderPrintDetailProvider.InsertLi_LeminationOrderPrintDetail(li_LeminationOrderPrintDetail);
    }


    public static bool UpdateLi_LeminationOrderPrintDetail(Li_LeminationOrderPrintDetail li_LeminationOrderPrintDetail)
    {
        SqlLi_LeminationOrderPrintDetailProvider sqlLi_LeminationOrderPrintDetailProvider = new SqlLi_LeminationOrderPrintDetailProvider();
        return sqlLi_LeminationOrderPrintDetailProvider.UpdateLi_LeminationOrderPrintDetail(li_LeminationOrderPrintDetail);
    }

    public static bool DeleteLi_LeminationOrderPrintDetail(int li_LeminationOrderPrintDetailID)
    {
        SqlLi_LeminationOrderPrintDetailProvider sqlLi_LeminationOrderPrintDetailProvider = new SqlLi_LeminationOrderPrintDetailProvider();
        return sqlLi_LeminationOrderPrintDetailProvider.DeleteLi_LeminationOrderPrintDetail(li_LeminationOrderPrintDetailID);
    }
}
