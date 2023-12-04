using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_CoverBillDetailManager
{
	public Li_CoverBillDetailManager()
	{
	}

    public static List<Li_CoverBillDetail> GetAllLi_CoverBillDetails()
    {
        List<Li_CoverBillDetail> li_CoverBillDetails = new List<Li_CoverBillDetail>();
        SqlLi_CoverBillDetailProvider sqlLi_CoverBillDetailProvider = new SqlLi_CoverBillDetailProvider();
        li_CoverBillDetails = sqlLi_CoverBillDetailProvider.GetAllLi_CoverBillDetails();
        return li_CoverBillDetails;
    }


    public static Li_CoverBillDetail GetLi_CoverBillDetailByID(int id)
    {
        Li_CoverBillDetail li_CoverBillDetail = new Li_CoverBillDetail();
        SqlLi_CoverBillDetailProvider sqlLi_CoverBillDetailProvider = new SqlLi_CoverBillDetailProvider();
        li_CoverBillDetail = sqlLi_CoverBillDetailProvider.GetLi_CoverBillDetailByID(id);
        return li_CoverBillDetail;
    }


    public static int InsertLi_CoverBillDetail(Li_CoverBillDetail li_CoverBillDetail)
    {
        SqlLi_CoverBillDetailProvider sqlLi_CoverBillDetailProvider = new SqlLi_CoverBillDetailProvider();
        return sqlLi_CoverBillDetailProvider.InsertLi_CoverBillDetail(li_CoverBillDetail);
    }


    public static bool UpdateLi_CoverBillDetail(Li_CoverBillDetail li_CoverBillDetail)
    {
        SqlLi_CoverBillDetailProvider sqlLi_CoverBillDetailProvider = new SqlLi_CoverBillDetailProvider();
        return sqlLi_CoverBillDetailProvider.UpdateLi_CoverBillDetail(li_CoverBillDetail);
    }

    public static bool DeleteLi_CoverBillDetail(int li_CoverBillDetailID)
    {
        SqlLi_CoverBillDetailProvider sqlLi_CoverBillDetailProvider = new SqlLi_CoverBillDetailProvider();
        return sqlLi_CoverBillDetailProvider.DeleteLi_CoverBillDetail(li_CoverBillDetailID);
    }
}
