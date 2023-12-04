using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpPayDayDetailManager
{
	public Li_EmpPayDayDetailManager()
	{
	}

    public static List<Li_EmpPayDayDetail> GetAllLi_EmpPayDayDetails()
    {
        List<Li_EmpPayDayDetail> li_EmpPayDayDetails = new List<Li_EmpPayDayDetail>();
        SqlLi_EmpPayDayDetailProvider sqlLi_EmpPayDayDetailProvider = new SqlLi_EmpPayDayDetailProvider();
        li_EmpPayDayDetails = sqlLi_EmpPayDayDetailProvider.GetAllLi_EmpPayDayDetails();
        return li_EmpPayDayDetails;
    }


    public static Li_EmpPayDayDetail GetLi_EmpPayDayDetailByID(int id)
    {
        Li_EmpPayDayDetail li_EmpPayDayDetail = new Li_EmpPayDayDetail();
        SqlLi_EmpPayDayDetailProvider sqlLi_EmpPayDayDetailProvider = new SqlLi_EmpPayDayDetailProvider();
        li_EmpPayDayDetail = sqlLi_EmpPayDayDetailProvider.GetLi_EmpPayDayDetailByID(id);
        return li_EmpPayDayDetail;
    }


    public static int InsertLi_EmpPayDayDetail(Li_EmpPayDayDetail li_EmpPayDayDetail)
    {
        SqlLi_EmpPayDayDetailProvider sqlLi_EmpPayDayDetailProvider = new SqlLi_EmpPayDayDetailProvider();
        return sqlLi_EmpPayDayDetailProvider.InsertLi_EmpPayDayDetail(li_EmpPayDayDetail);
    }


    public static bool UpdateLi_EmpPayDayDetail(Li_EmpPayDayDetail li_EmpPayDayDetail)
    {
        SqlLi_EmpPayDayDetailProvider sqlLi_EmpPayDayDetailProvider = new SqlLi_EmpPayDayDetailProvider();
        return sqlLi_EmpPayDayDetailProvider.UpdateLi_EmpPayDayDetail(li_EmpPayDayDetail);
    }

    public static bool DeleteLi_EmpPayDayDetail(int li_EmpPayDayDetailID)
    {
        SqlLi_EmpPayDayDetailProvider sqlLi_EmpPayDayDetailProvider = new SqlLi_EmpPayDayDetailProvider();
        return sqlLi_EmpPayDayDetailProvider.DeleteLi_EmpPayDayDetail(li_EmpPayDayDetailID);
    }
}
