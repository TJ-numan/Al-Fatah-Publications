using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_DescriptiveTestDetailManager
{
	public Li_DescriptiveTestDetailManager()
	{
	}

    public static List<Li_DescriptiveTestDetail> GetAllLi_DescriptiveTestDetails()
    {
        List<Li_DescriptiveTestDetail> li_DescriptiveTestDetails = new List<Li_DescriptiveTestDetail>();
        SqlLi_DescriptiveTestDetailProvider sqlLi_DescriptiveTestDetailProvider = new SqlLi_DescriptiveTestDetailProvider();
        li_DescriptiveTestDetails = sqlLi_DescriptiveTestDetailProvider.GetAllLi_DescriptiveTestDetails();
        return li_DescriptiveTestDetails;
    }


    public static Li_DescriptiveTestDetail GetLi_DescriptiveTestDetailByID(int id)
    {
        Li_DescriptiveTestDetail li_DescriptiveTestDetail = new Li_DescriptiveTestDetail();
        SqlLi_DescriptiveTestDetailProvider sqlLi_DescriptiveTestDetailProvider = new SqlLi_DescriptiveTestDetailProvider();
        li_DescriptiveTestDetail = sqlLi_DescriptiveTestDetailProvider.GetLi_DescriptiveTestDetailByID(id);
        return li_DescriptiveTestDetail;
    }


    public static int InsertLi_DescriptiveTestDetail(Li_DescriptiveTestDetail li_DescriptiveTestDetail)
    {
        SqlLi_DescriptiveTestDetailProvider sqlLi_DescriptiveTestDetailProvider = new SqlLi_DescriptiveTestDetailProvider();
        return sqlLi_DescriptiveTestDetailProvider.InsertLi_DescriptiveTestDetail(li_DescriptiveTestDetail);
    }


    public static bool UpdateLi_DescriptiveTestDetail(Li_DescriptiveTestDetail li_DescriptiveTestDetail)
    {
        SqlLi_DescriptiveTestDetailProvider sqlLi_DescriptiveTestDetailProvider = new SqlLi_DescriptiveTestDetailProvider();
        return sqlLi_DescriptiveTestDetailProvider.UpdateLi_DescriptiveTestDetail(li_DescriptiveTestDetail);
    }

    public static bool DeleteLi_DescriptiveTestDetail(int li_DescriptiveTestDetailID)
    {
        SqlLi_DescriptiveTestDetailProvider sqlLi_DescriptiveTestDetailProvider = new SqlLi_DescriptiveTestDetailProvider();
        return sqlLi_DescriptiveTestDetailProvider.DeleteLi_DescriptiveTestDetail(li_DescriptiveTestDetailID);
    }
}
