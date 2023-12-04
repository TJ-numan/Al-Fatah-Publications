using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_SalaryPayDetailManager
{
	public Li_SalaryPayDetailManager()
	{
	}

    public static List<Li_SalaryPayDetail> GetAllLi_SalaryPayDetails()
    {
        List<Li_SalaryPayDetail> li_SalaryPayDetails = new List<Li_SalaryPayDetail>();
        SqlLi_SalaryPayDetailProvider sqlLi_SalaryPayDetailProvider = new SqlLi_SalaryPayDetailProvider();
        li_SalaryPayDetails = sqlLi_SalaryPayDetailProvider.GetAllLi_SalaryPayDetails();
        return li_SalaryPayDetails;
    }


    public static Li_SalaryPayDetail GetLi_SalaryPayDetailByID(int id)
    {
        Li_SalaryPayDetail li_SalaryPayDetail = new Li_SalaryPayDetail();
        SqlLi_SalaryPayDetailProvider sqlLi_SalaryPayDetailProvider = new SqlLi_SalaryPayDetailProvider();
        li_SalaryPayDetail = sqlLi_SalaryPayDetailProvider.GetLi_SalaryPayDetailByID(id);
        return li_SalaryPayDetail;
    }


    public static int InsertLi_SalaryPayDetail(Li_SalaryPayDetail li_SalaryPayDetail)
    {
        SqlLi_SalaryPayDetailProvider sqlLi_SalaryPayDetailProvider = new SqlLi_SalaryPayDetailProvider();
        return sqlLi_SalaryPayDetailProvider.InsertLi_SalaryPayDetail(li_SalaryPayDetail);
    }


    public static bool UpdateLi_SalaryPayDetail(Li_SalaryPayDetail li_SalaryPayDetail)
    {
        SqlLi_SalaryPayDetailProvider sqlLi_SalaryPayDetailProvider = new SqlLi_SalaryPayDetailProvider();
        return sqlLi_SalaryPayDetailProvider.UpdateLi_SalaryPayDetail(li_SalaryPayDetail);
    }

    public static bool DeleteLi_SalaryPayDetail(int li_SalaryPayDetailID)
    {
        SqlLi_SalaryPayDetailProvider sqlLi_SalaryPayDetailProvider = new SqlLi_SalaryPayDetailProvider();
        return sqlLi_SalaryPayDetailProvider.DeleteLi_SalaryPayDetail(li_SalaryPayDetailID);
    }
}
