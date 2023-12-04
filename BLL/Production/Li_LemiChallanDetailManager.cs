using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_LemiChallanDetailManager
{
	public Li_LemiChallanDetailManager()
	{
	}

    public static List<Li_LemiChallanDetail> GetAllLi_LemiChallanDetails()
    {
        List<Li_LemiChallanDetail> li_LemiChallanDetails = new List<Li_LemiChallanDetail>();
        SqlLi_LemiChallanDetailProvider sqlLi_LemiChallanDetailProvider = new SqlLi_LemiChallanDetailProvider();
        li_LemiChallanDetails = sqlLi_LemiChallanDetailProvider.GetAllLi_LemiChallanDetails();
        return li_LemiChallanDetails;
    }


    public static Li_LemiChallanDetail GetLi_LemiChallanDetailByID(int id)
    {
        Li_LemiChallanDetail li_LemiChallanDetail = new Li_LemiChallanDetail();
        SqlLi_LemiChallanDetailProvider sqlLi_LemiChallanDetailProvider = new SqlLi_LemiChallanDetailProvider();
        li_LemiChallanDetail = sqlLi_LemiChallanDetailProvider.GetLi_LemiChallanDetailByID(id);
        return li_LemiChallanDetail;
    }


    public static int InsertLi_LemiChallanDetail(Li_LemiChallanDetail li_LemiChallanDetail)
    {
        SqlLi_LemiChallanDetailProvider sqlLi_LemiChallanDetailProvider = new SqlLi_LemiChallanDetailProvider();
        return sqlLi_LemiChallanDetailProvider.InsertLi_LemiChallanDetail(li_LemiChallanDetail);
    }


    public static bool UpdateLi_LemiChallanDetail(Li_LemiChallanDetail li_LemiChallanDetail)
    {
        SqlLi_LemiChallanDetailProvider sqlLi_LemiChallanDetailProvider = new SqlLi_LemiChallanDetailProvider();
        return sqlLi_LemiChallanDetailProvider.UpdateLi_LemiChallanDetail(li_LemiChallanDetail);
    }

    public static bool DeleteLi_LemiChallanDetail(int li_LemiChallanDetailID)
    {
        SqlLi_LemiChallanDetailProvider sqlLi_LemiChallanDetailProvider = new SqlLi_LemiChallanDetailProvider();
        return sqlLi_LemiChallanDetailProvider.DeleteLi_LemiChallanDetail(li_LemiChallanDetailID);
    }
}
