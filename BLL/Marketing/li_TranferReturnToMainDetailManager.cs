using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TranferReturnToMainDetailManager
{
	public Li_TranferReturnToMainDetailManager()
	{
	}

    public static List<Li_TranferReturnToMainDetail> GetAllLi_TranferReturnToMainDetails()
    {
        List<Li_TranferReturnToMainDetail> li_TranferReturnToMainDetails = new List<Li_TranferReturnToMainDetail>();
        SqlLi_TranferReturnToMainDetailProvider sqlLi_TranferReturnToMainDetailProvider = new SqlLi_TranferReturnToMainDetailProvider();
        li_TranferReturnToMainDetails = sqlLi_TranferReturnToMainDetailProvider.GetAllLi_TranferReturnToMainDetails();
        return li_TranferReturnToMainDetails;
    }


    public static Li_TranferReturnToMainDetail GetLi_TranferReturnToMainDetailByID(int id)
    {
        Li_TranferReturnToMainDetail li_TranferReturnToMainDetail = new Li_TranferReturnToMainDetail();
        SqlLi_TranferReturnToMainDetailProvider sqlLi_TranferReturnToMainDetailProvider = new SqlLi_TranferReturnToMainDetailProvider();
        li_TranferReturnToMainDetail = sqlLi_TranferReturnToMainDetailProvider.GetLi_TranferReturnToMainDetailByID(id);
        return li_TranferReturnToMainDetail;
    }


    public static int InsertLi_TranferReturnToMainDetail(Li_TranferReturnToMainDetail li_TranferReturnToMainDetail)
    {
        SqlLi_TranferReturnToMainDetailProvider sqlLi_TranferReturnToMainDetailProvider = new SqlLi_TranferReturnToMainDetailProvider();
        return sqlLi_TranferReturnToMainDetailProvider.InsertLi_TranferReturnToMainDetail(li_TranferReturnToMainDetail);
    }


    public static bool UpdateLi_TranferReturnToMainDetail(Li_TranferReturnToMainDetail li_TranferReturnToMainDetail)
    {
        SqlLi_TranferReturnToMainDetailProvider sqlLi_TranferReturnToMainDetailProvider = new SqlLi_TranferReturnToMainDetailProvider();
        return sqlLi_TranferReturnToMainDetailProvider.UpdateLi_TranferReturnToMainDetail(li_TranferReturnToMainDetail);
    }

    public static bool DeleteLi_TranferReturnToMainDetail(int li_TranferReturnToMainDetailID)
    {
        SqlLi_TranferReturnToMainDetailProvider sqlLi_TranferReturnToMainDetailProvider = new SqlLi_TranferReturnToMainDetailProvider();
        return sqlLi_TranferReturnToMainDetailProvider.DeleteLi_TranferReturnToMainDetail(li_TranferReturnToMainDetailID);
    }
}
