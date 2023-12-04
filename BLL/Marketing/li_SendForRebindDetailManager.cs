using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SendForRebindDetailManager
{
	public Li_SendForRebindDetailManager()
	{
	}

    public static List<Li_SendForRebindDetail> GetAllLi_SendForRebindDetails()
    {
        List<Li_SendForRebindDetail> li_SendForRebindDetails = new List<Li_SendForRebindDetail>();
        SqlLi_SendForRebindDetailProvider sqlLi_SendForRebindDetailProvider = new SqlLi_SendForRebindDetailProvider();
        li_SendForRebindDetails = sqlLi_SendForRebindDetailProvider.GetAllLi_SendForRebindDetails();
        return li_SendForRebindDetails;
    }


    public static Li_SendForRebindDetail GetLi_SendForRebindDetailByID(int id)
    {
        Li_SendForRebindDetail li_SendForRebindDetail = new Li_SendForRebindDetail();
        SqlLi_SendForRebindDetailProvider sqlLi_SendForRebindDetailProvider = new SqlLi_SendForRebindDetailProvider();
        li_SendForRebindDetail = sqlLi_SendForRebindDetailProvider.GetLi_SendForRebindDetailByID(id);
        return li_SendForRebindDetail;
    }


    public static int InsertLi_SendForRebindDetail(Li_SendForRebindDetail li_SendForRebindDetail)
    {
        SqlLi_SendForRebindDetailProvider sqlLi_SendForRebindDetailProvider = new SqlLi_SendForRebindDetailProvider();
        return sqlLi_SendForRebindDetailProvider.InsertLi_SendForRebindDetail(li_SendForRebindDetail);
    }


    public static bool UpdateLi_SendForRebindDetail(Li_SendForRebindDetail li_SendForRebindDetail)
    {
        SqlLi_SendForRebindDetailProvider sqlLi_SendForRebindDetailProvider = new SqlLi_SendForRebindDetailProvider();
        return sqlLi_SendForRebindDetailProvider.UpdateLi_SendForRebindDetail(li_SendForRebindDetail);
    }

    public static bool DeleteLi_SendForRebindDetail(int li_SendForRebindDetailID)
    {
        SqlLi_SendForRebindDetailProvider sqlLi_SendForRebindDetailProvider = new SqlLi_SendForRebindDetailProvider();
        return sqlLi_SendForRebindDetailProvider.DeleteLi_SendForRebindDetail(li_SendForRebindDetailID);
    }
}
