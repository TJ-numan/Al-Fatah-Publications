using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpClearanceDetailManager
{
	public Li_EmpClearanceDetailManager()
	{
	}

    public static List<Li_EmpClearanceDetail> GetAllLi_EmpClearanceDetails()
    {
        List<Li_EmpClearanceDetail> li_EmpClearanceDetails = new List<Li_EmpClearanceDetail>();
        SqlLi_EmpClearanceDetailProvider sqlLi_EmpClearanceDetailProvider = new SqlLi_EmpClearanceDetailProvider();
        li_EmpClearanceDetails = sqlLi_EmpClearanceDetailProvider.GetAllLi_EmpClearanceDetails();
        return li_EmpClearanceDetails;
    }


    public static Li_EmpClearanceDetail GetLi_EmpClearanceDetailByID(int id)
    {
        Li_EmpClearanceDetail li_EmpClearanceDetail = new Li_EmpClearanceDetail();
        SqlLi_EmpClearanceDetailProvider sqlLi_EmpClearanceDetailProvider = new SqlLi_EmpClearanceDetailProvider();
        li_EmpClearanceDetail = sqlLi_EmpClearanceDetailProvider.GetLi_EmpClearanceDetailByID(id);
        return li_EmpClearanceDetail;
    }


    public static int InsertLi_EmpClearanceDetail(Li_EmpClearanceDetail li_EmpClearanceDetail)
    {
        SqlLi_EmpClearanceDetailProvider sqlLi_EmpClearanceDetailProvider = new SqlLi_EmpClearanceDetailProvider();
        return sqlLi_EmpClearanceDetailProvider.InsertLi_EmpClearanceDetail(li_EmpClearanceDetail);
    }


    public static bool UpdateLi_EmpClearanceDetail(Li_EmpClearanceDetail li_EmpClearanceDetail)
    {
        SqlLi_EmpClearanceDetailProvider sqlLi_EmpClearanceDetailProvider = new SqlLi_EmpClearanceDetailProvider();
        return sqlLi_EmpClearanceDetailProvider.UpdateLi_EmpClearanceDetail(li_EmpClearanceDetail);
    }

    public static bool DeleteLi_EmpClearanceDetail(int li_EmpClearanceDetailID)
    {
        SqlLi_EmpClearanceDetailProvider sqlLi_EmpClearanceDetailProvider = new SqlLi_EmpClearanceDetailProvider();
        return sqlLi_EmpClearanceDetailProvider.DeleteLi_EmpClearanceDetail(li_EmpClearanceDetailID);
    }
}
