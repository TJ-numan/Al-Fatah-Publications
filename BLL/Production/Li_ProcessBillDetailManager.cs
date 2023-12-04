using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_ProcessBillDetailManager
{
	public Li_ProcessBillDetailManager()
	{
	}

    public static List<Li_ProcessBillDetail> GetAllLi_ProcessBillDetails()
    {
        List<Li_ProcessBillDetail> li_ProcessBillDetails = new List<Li_ProcessBillDetail>();
        SqlLi_ProcessBillDetailProvider sqlLi_ProcessBillDetailProvider = new SqlLi_ProcessBillDetailProvider();
        li_ProcessBillDetails = sqlLi_ProcessBillDetailProvider.GetAllLi_ProcessBillDetails();
        return li_ProcessBillDetails;
    }


    public static Li_ProcessBillDetail GetLi_ProcessBillDetailByID(int id)
    {
        Li_ProcessBillDetail li_ProcessBillDetail = new Li_ProcessBillDetail();
        SqlLi_ProcessBillDetailProvider sqlLi_ProcessBillDetailProvider = new SqlLi_ProcessBillDetailProvider();
        li_ProcessBillDetail = sqlLi_ProcessBillDetailProvider.GetLi_ProcessBillDetailByID(id);
        return li_ProcessBillDetail;
    }


    public static int InsertLi_ProcessBillDetail(Li_ProcessBillDetail li_ProcessBillDetail)
    {
        SqlLi_ProcessBillDetailProvider sqlLi_ProcessBillDetailProvider = new SqlLi_ProcessBillDetailProvider();
        return sqlLi_ProcessBillDetailProvider.InsertLi_ProcessBillDetail(li_ProcessBillDetail);
    }


    public static bool UpdateLi_ProcessBillDetail(Li_ProcessBillDetail li_ProcessBillDetail)
    {
        SqlLi_ProcessBillDetailProvider sqlLi_ProcessBillDetailProvider = new SqlLi_ProcessBillDetailProvider();
        return sqlLi_ProcessBillDetailProvider.UpdateLi_ProcessBillDetail(li_ProcessBillDetail);
    }

    public static bool DeleteLi_ProcessBillDetail(int li_ProcessBillDetailID)
    {
        SqlLi_ProcessBillDetailProvider sqlLi_ProcessBillDetailProvider = new SqlLi_ProcessBillDetailProvider();
        return sqlLi_ProcessBillDetailProvider.DeleteLi_ProcessBillDetail(li_ProcessBillDetailID);
    }
}
