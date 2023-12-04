using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpSalaryDetailManager
{
	public Li_EmpSalaryDetailManager()
	{
	}

    public static List<Li_EmpSalaryDetail> GetAllLi_EmpSalaryDetails()
    {
        List<Li_EmpSalaryDetail> li_EmpSalaryDetails = new List<Li_EmpSalaryDetail>();
        SqlLi_EmpSalaryDetailProvider sqlLi_EmpSalaryDetailProvider = new SqlLi_EmpSalaryDetailProvider();
        li_EmpSalaryDetails = sqlLi_EmpSalaryDetailProvider.GetAllLi_EmpSalaryDetails();
        return li_EmpSalaryDetails;
    }


    public static Li_EmpSalaryDetail GetLi_EmpSalaryDetailByID(int id)
    {
        Li_EmpSalaryDetail li_EmpSalaryDetail = new Li_EmpSalaryDetail();
        SqlLi_EmpSalaryDetailProvider sqlLi_EmpSalaryDetailProvider = new SqlLi_EmpSalaryDetailProvider();
        li_EmpSalaryDetail = sqlLi_EmpSalaryDetailProvider.GetLi_EmpSalaryDetailByID(id);
        return li_EmpSalaryDetail;
    }


    public static int InsertLi_EmpSalaryDetail(Li_EmpSalaryDetail li_EmpSalaryDetail)
    {
        SqlLi_EmpSalaryDetailProvider sqlLi_EmpSalaryDetailProvider = new SqlLi_EmpSalaryDetailProvider();
        return sqlLi_EmpSalaryDetailProvider.InsertLi_EmpSalaryDetail(li_EmpSalaryDetail);
    }


    public static bool UpdateLi_EmpSalaryDetail(Li_EmpSalaryDetail li_EmpSalaryDetail)
    {
        SqlLi_EmpSalaryDetailProvider sqlLi_EmpSalaryDetailProvider = new SqlLi_EmpSalaryDetailProvider();
        return sqlLi_EmpSalaryDetailProvider.UpdateLi_EmpSalaryDetail(li_EmpSalaryDetail);
    }

    public static bool DeleteLi_EmpSalaryDetail(int li_EmpSalaryDetailID)
    {
        SqlLi_EmpSalaryDetailProvider sqlLi_EmpSalaryDetailProvider = new SqlLi_EmpSalaryDetailProvider();
        return sqlLi_EmpSalaryDetailProvider.DeleteLi_EmpSalaryDetail(li_EmpSalaryDetailID);
    }
}
