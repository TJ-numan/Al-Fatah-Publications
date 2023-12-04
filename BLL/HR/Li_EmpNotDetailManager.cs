using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpNotDetailManager
{
	public Li_EmpNotDetailManager()
	{
	}

    public static List<Li_EmpNotDetail> GetAllLi_EmpNotDetails()
    {
        List<Li_EmpNotDetail> li_EmpNotDetails = new List<Li_EmpNotDetail>();
        SqlLi_EmpNotDetailProvider sqlLi_EmpNotDetailProvider = new SqlLi_EmpNotDetailProvider();
        li_EmpNotDetails = sqlLi_EmpNotDetailProvider.GetAllLi_EmpNotDetails();
        return li_EmpNotDetails;
    }


    public static Li_EmpNotDetail GetLi_EmpNotDetailByID(int id)
    {
        Li_EmpNotDetail li_EmpNotDetail = new Li_EmpNotDetail();
        SqlLi_EmpNotDetailProvider sqlLi_EmpNotDetailProvider = new SqlLi_EmpNotDetailProvider();
        li_EmpNotDetail = sqlLi_EmpNotDetailProvider.GetLi_EmpNotDetailByID(id);
        return li_EmpNotDetail;
    }


    public static int InsertLi_EmpNotDetail(Li_EmpNotDetail li_EmpNotDetail)
    {
        SqlLi_EmpNotDetailProvider sqlLi_EmpNotDetailProvider = new SqlLi_EmpNotDetailProvider();
        return sqlLi_EmpNotDetailProvider.InsertLi_EmpNotDetail(li_EmpNotDetail);
    }


    public static bool UpdateLi_EmpNotDetail(Li_EmpNotDetail li_EmpNotDetail)
    {
        SqlLi_EmpNotDetailProvider sqlLi_EmpNotDetailProvider = new SqlLi_EmpNotDetailProvider();
        return sqlLi_EmpNotDetailProvider.UpdateLi_EmpNotDetail(li_EmpNotDetail);
    }

    public static bool DeleteLi_EmpNotDetail(int li_EmpNotDetailID)
    {
        SqlLi_EmpNotDetailProvider sqlLi_EmpNotDetailProvider = new SqlLi_EmpNotDetailProvider();
        return sqlLi_EmpNotDetailProvider.DeleteLi_EmpNotDetail(li_EmpNotDetailID);
    }
}
