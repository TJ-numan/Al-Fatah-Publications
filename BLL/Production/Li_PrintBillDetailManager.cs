using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintBillDetailManager
{
	public Li_PrintBillDetailManager()
	{
	}

    public static List<Li_PrintBillDetail> GetAllLi_PrintBillDetails()
    {
        List<Li_PrintBillDetail> li_PrintBillDetails = new List<Li_PrintBillDetail>();
        SqlLi_PrintBillDetailProvider sqlLi_PrintBillDetailProvider = new SqlLi_PrintBillDetailProvider();
        li_PrintBillDetails = sqlLi_PrintBillDetailProvider.GetAllLi_PrintBillDetails();
        return li_PrintBillDetails;
    }


    public static Li_PrintBillDetail GetLi_PrintBillDetailByID(int id)
    {
        Li_PrintBillDetail li_PrintBillDetail = new Li_PrintBillDetail();
        SqlLi_PrintBillDetailProvider sqlLi_PrintBillDetailProvider = new SqlLi_PrintBillDetailProvider();
        li_PrintBillDetail = sqlLi_PrintBillDetailProvider.GetLi_PrintBillDetailByID(id);
        return li_PrintBillDetail;
    }


    public static int InsertLi_PrintBillDetail(Li_PrintBillDetail li_PrintBillDetail)
    {
        SqlLi_PrintBillDetailProvider sqlLi_PrintBillDetailProvider = new SqlLi_PrintBillDetailProvider();
        return sqlLi_PrintBillDetailProvider.InsertLi_PrintBillDetail(li_PrintBillDetail);
    }


    public static bool UpdateLi_PrintBillDetail(Li_PrintBillDetail li_PrintBillDetail)
    {
        SqlLi_PrintBillDetailProvider sqlLi_PrintBillDetailProvider = new SqlLi_PrintBillDetailProvider();
        return sqlLi_PrintBillDetailProvider.UpdateLi_PrintBillDetail(li_PrintBillDetail);
    }

    public static bool DeleteLi_PrintBillDetail(int li_PrintBillDetailID)
    {
        SqlLi_PrintBillDetailProvider sqlLi_PrintBillDetailProvider = new SqlLi_PrintBillDetailProvider();
        return sqlLi_PrintBillDetailProvider.DeleteLi_PrintBillDetail(li_PrintBillDetailID);
    }
}
