using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LoanAdvanceDetailManager
{
	public Li_LoanAdvanceDetailManager()
	{
	}

    public static List<Li_LoanAdvanceDetail> GetAllLi_LoanAdvanceDetails()
    {
        List<Li_LoanAdvanceDetail> li_LoanAdvanceDetails = new List<Li_LoanAdvanceDetail>();
        SqlLi_LoanAdvanceDetailProvider sqlLi_LoanAdvanceDetailProvider = new SqlLi_LoanAdvanceDetailProvider();
        li_LoanAdvanceDetails = sqlLi_LoanAdvanceDetailProvider.GetAllLi_LoanAdvanceDetails();
        return li_LoanAdvanceDetails;
    }


    public static Li_LoanAdvanceDetail GetLi_LoanAdvanceDetailByID(int id)
    {
        Li_LoanAdvanceDetail li_LoanAdvanceDetail = new Li_LoanAdvanceDetail();
        SqlLi_LoanAdvanceDetailProvider sqlLi_LoanAdvanceDetailProvider = new SqlLi_LoanAdvanceDetailProvider();
        li_LoanAdvanceDetail = sqlLi_LoanAdvanceDetailProvider.GetLi_LoanAdvanceDetailByID(id);
        return li_LoanAdvanceDetail;
    }


    public static int InsertLi_LoanAdvanceDetail(Li_LoanAdvanceDetail li_LoanAdvanceDetail)
    {
        SqlLi_LoanAdvanceDetailProvider sqlLi_LoanAdvanceDetailProvider = new SqlLi_LoanAdvanceDetailProvider();
        return sqlLi_LoanAdvanceDetailProvider.InsertLi_LoanAdvanceDetail(li_LoanAdvanceDetail);
    }


    public static bool UpdateLi_LoanAdvanceDetail(Li_LoanAdvanceDetail li_LoanAdvanceDetail)
    {
        SqlLi_LoanAdvanceDetailProvider sqlLi_LoanAdvanceDetailProvider = new SqlLi_LoanAdvanceDetailProvider();
        return sqlLi_LoanAdvanceDetailProvider.UpdateLi_LoanAdvanceDetail(li_LoanAdvanceDetail);
    }

    public static bool DeleteLi_LoanAdvanceDetail(int li_LoanAdvanceDetailID)
    {
        SqlLi_LoanAdvanceDetailProvider sqlLi_LoanAdvanceDetailProvider = new SqlLi_LoanAdvanceDetailProvider();
        return sqlLi_LoanAdvanceDetailProvider.DeleteLi_LoanAdvanceDetail(li_LoanAdvanceDetailID);
    }
}
