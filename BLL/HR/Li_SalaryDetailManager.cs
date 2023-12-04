using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_SalaryDetailManager
{
	public Li_SalaryDetailManager()
	{
	}

    public static List<Li_SalaryDetail> GetAllLi_SalaryDetails()
    {
        List<Li_SalaryDetail> li_SalaryDetails = new List<Li_SalaryDetail>();
        SqlLi_SalaryDetailProvider sqlLi_SalaryDetailProvider = new SqlLi_SalaryDetailProvider();
        li_SalaryDetails = sqlLi_SalaryDetailProvider.GetAllLi_SalaryDetails();
        return li_SalaryDetails;
    }


    public static Li_SalaryDetail GetLi_SalaryDetailByID(int id)
    {
        Li_SalaryDetail li_SalaryDetail = new Li_SalaryDetail();
        SqlLi_SalaryDetailProvider sqlLi_SalaryDetailProvider = new SqlLi_SalaryDetailProvider();
        li_SalaryDetail = sqlLi_SalaryDetailProvider.GetLi_SalaryDetailByID(id);
        return li_SalaryDetail;
    }


    public static int InsertLi_SalaryDetail(Li_SalaryDetail li_SalaryDetail)
    {
        SqlLi_SalaryDetailProvider sqlLi_SalaryDetailProvider = new SqlLi_SalaryDetailProvider();
        return sqlLi_SalaryDetailProvider.InsertLi_SalaryDetail(li_SalaryDetail);
    }


    public static bool UpdateLi_SalaryDetail(Li_SalaryDetail li_SalaryDetail)
    {
        SqlLi_SalaryDetailProvider sqlLi_SalaryDetailProvider = new SqlLi_SalaryDetailProvider();
        return sqlLi_SalaryDetailProvider.UpdateLi_SalaryDetail(li_SalaryDetail);
    }

    public static bool DeleteLi_SalaryDetail(int li_SalaryDetailID)
    {
        SqlLi_SalaryDetailProvider sqlLi_SalaryDetailProvider = new SqlLi_SalaryDetailProvider();
        return sqlLi_SalaryDetailProvider.DeleteLi_SalaryDetail(li_SalaryDetailID);
    }
}
