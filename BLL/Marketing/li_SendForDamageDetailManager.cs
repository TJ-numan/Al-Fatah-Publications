using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SendForDamageDetailManager
{
	public Li_SendForDamageDetailManager()
	{
	}

    public static List<Li_SendForDamageDetail> GetAllLi_SendForDamageDetails()
    {
        List<Li_SendForDamageDetail> li_SendForDamageDetails = new List<Li_SendForDamageDetail>();
        SqlLi_SendForDamageDetailProvider sqlLi_SendForDamageDetailProvider = new SqlLi_SendForDamageDetailProvider();
        li_SendForDamageDetails = sqlLi_SendForDamageDetailProvider.GetAllLi_SendForDamageDetails();
        return li_SendForDamageDetails;
    }


    public static Li_SendForDamageDetail GetLi_SendForDamageDetailByID(int id)
    {
        Li_SendForDamageDetail li_SendForDamageDetail = new Li_SendForDamageDetail();
        SqlLi_SendForDamageDetailProvider sqlLi_SendForDamageDetailProvider = new SqlLi_SendForDamageDetailProvider();
        li_SendForDamageDetail = sqlLi_SendForDamageDetailProvider.GetLi_SendForDamageDetailByID(id);
        return li_SendForDamageDetail;
    }


    public static int InsertLi_SendForDamageDetail(Li_SendForDamageDetail li_SendForDamageDetail)
    {
        SqlLi_SendForDamageDetailProvider sqlLi_SendForDamageDetailProvider = new SqlLi_SendForDamageDetailProvider();
        return sqlLi_SendForDamageDetailProvider.InsertLi_SendForDamageDetail(li_SendForDamageDetail);
    }


    public static bool UpdateLi_SendForDamageDetail(Li_SendForDamageDetail li_SendForDamageDetail)
    {
        SqlLi_SendForDamageDetailProvider sqlLi_SendForDamageDetailProvider = new SqlLi_SendForDamageDetailProvider();
        return sqlLi_SendForDamageDetailProvider.UpdateLi_SendForDamageDetail(li_SendForDamageDetail);
    }

    public static bool DeleteLi_SendForDamageDetail(int li_SendForDamageDetailID)
    {
        SqlLi_SendForDamageDetailProvider sqlLi_SendForDamageDetailProvider = new SqlLi_SendForDamageDetailProvider();
        return sqlLi_SendForDamageDetailProvider.DeleteLi_SendForDamageDetail(li_SendForDamageDetailID);
    }
}
