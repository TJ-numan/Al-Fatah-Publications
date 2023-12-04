using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlateBillDetailManager
{
	public Li_PlateBillDetailManager()
	{
	}

    public static List<Li_PlateBillDetail> GetAllLi_PlateBillDetails()
    {
        List<Li_PlateBillDetail> li_PlateBillDetails = new List<Li_PlateBillDetail>();
        SqlLi_PlateBillDetailProvider sqlLi_PlateBillDetailProvider = new SqlLi_PlateBillDetailProvider();
        li_PlateBillDetails = sqlLi_PlateBillDetailProvider.GetAllLi_PlateBillDetails();
        return li_PlateBillDetails;
    }


    public static Li_PlateBillDetail GetLi_PlateBillDetailByID(int id)
    {
        Li_PlateBillDetail li_PlateBillDetail = new Li_PlateBillDetail();
        SqlLi_PlateBillDetailProvider sqlLi_PlateBillDetailProvider = new SqlLi_PlateBillDetailProvider();
        li_PlateBillDetail = sqlLi_PlateBillDetailProvider.GetLi_PlateBillDetailByID(id);
        return li_PlateBillDetail;
    }


    public static int InsertLi_PlateBillDetail(Li_PlateBillDetail li_PlateBillDetail)
    {
        SqlLi_PlateBillDetailProvider sqlLi_PlateBillDetailProvider = new SqlLi_PlateBillDetailProvider();
        return sqlLi_PlateBillDetailProvider.InsertLi_PlateBillDetail(li_PlateBillDetail);
    }


    public static bool UpdateLi_PlateBillDetail(Li_PlateBillDetail li_PlateBillDetail)
    {
        SqlLi_PlateBillDetailProvider sqlLi_PlateBillDetailProvider = new SqlLi_PlateBillDetailProvider();
        return sqlLi_PlateBillDetailProvider.UpdateLi_PlateBillDetail(li_PlateBillDetail);
    }

    public static bool DeleteLi_PlateBillDetail(int li_PlateBillDetailID)
    {
        SqlLi_PlateBillDetailProvider sqlLi_PlateBillDetailProvider = new SqlLi_PlateBillDetailProvider();
        return sqlLi_PlateBillDetailProvider.DeleteLi_PlateBillDetail(li_PlateBillDetailID);
    }
 
}
