using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_MCQTestDetailManager
{
	public Li_MCQTestDetailManager()
	{
	}

    public static List<Li_MCQTestDetail> GetAllLi_MCQTestDetails()
    {
        List<Li_MCQTestDetail> li_MCQTestDetails = new List<Li_MCQTestDetail>();
        SqlLi_MCQTestDetailProvider sqlLi_MCQTestDetailProvider = new SqlLi_MCQTestDetailProvider();
        li_MCQTestDetails = sqlLi_MCQTestDetailProvider.GetAllLi_MCQTestDetails();
        return li_MCQTestDetails;
    }


    public static Li_MCQTestDetail GetLi_MCQTestDetailByID(int id)
    {
        Li_MCQTestDetail li_MCQTestDetail = new Li_MCQTestDetail();
        SqlLi_MCQTestDetailProvider sqlLi_MCQTestDetailProvider = new SqlLi_MCQTestDetailProvider();
        li_MCQTestDetail = sqlLi_MCQTestDetailProvider.GetLi_MCQTestDetailByID(id);
        return li_MCQTestDetail;
    }


    public static int InsertLi_MCQTestDetail(Li_MCQTestDetail li_MCQTestDetail)
    {
        SqlLi_MCQTestDetailProvider sqlLi_MCQTestDetailProvider = new SqlLi_MCQTestDetailProvider();
        return sqlLi_MCQTestDetailProvider.InsertLi_MCQTestDetail(li_MCQTestDetail);
    }


    public static bool UpdateLi_MCQTestDetail(Li_MCQTestDetail li_MCQTestDetail)
    {
        SqlLi_MCQTestDetailProvider sqlLi_MCQTestDetailProvider = new SqlLi_MCQTestDetailProvider();
        return sqlLi_MCQTestDetailProvider.UpdateLi_MCQTestDetail(li_MCQTestDetail);
    }

    public static bool DeleteLi_MCQTestDetail(int li_MCQTestDetailID)
    {
        SqlLi_MCQTestDetailProvider sqlLi_MCQTestDetailProvider = new SqlLi_MCQTestDetailProvider();
        return sqlLi_MCQTestDetailProvider.DeleteLi_MCQTestDetail(li_MCQTestDetailID);
    }
}
