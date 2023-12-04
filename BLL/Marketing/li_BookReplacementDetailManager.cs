using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookReplacementDetailManager
{
	public Li_BookReplacementDetailManager()
	{
	}

    public static List<Li_BookReplacementDetail> GetAllLi_BookReplacementDetails()
    {
        List<Li_BookReplacementDetail> li_BookReplacementDetails = new List<Li_BookReplacementDetail>();
        SqlLi_BookReplacementDetailProvider sqlLi_BookReplacementDetailProvider = new SqlLi_BookReplacementDetailProvider();
        li_BookReplacementDetails = sqlLi_BookReplacementDetailProvider.GetAllLi_BookReplacementDetails();
        return li_BookReplacementDetails;
    }


    public static Li_BookReplacementDetail GetLi_BookReplacementDetailByID(int id)
    {
        Li_BookReplacementDetail li_BookReplacementDetail = new Li_BookReplacementDetail();
        SqlLi_BookReplacementDetailProvider sqlLi_BookReplacementDetailProvider = new SqlLi_BookReplacementDetailProvider();
        li_BookReplacementDetail = sqlLi_BookReplacementDetailProvider.GetLi_BookReplacementDetailByID(id);
        return li_BookReplacementDetail;
    }


    public static int InsertLi_BookReplacementDetail(Li_BookReplacementDetail li_BookReplacementDetail)
    {
        SqlLi_BookReplacementDetailProvider sqlLi_BookReplacementDetailProvider = new SqlLi_BookReplacementDetailProvider();
        return sqlLi_BookReplacementDetailProvider.InsertLi_BookReplacementDetail(li_BookReplacementDetail);
    }


    public static bool UpdateLi_BookReplacementDetail(Li_BookReplacementDetail li_BookReplacementDetail)
    {
        SqlLi_BookReplacementDetailProvider sqlLi_BookReplacementDetailProvider = new SqlLi_BookReplacementDetailProvider();
        return sqlLi_BookReplacementDetailProvider.UpdateLi_BookReplacementDetail(li_BookReplacementDetail);
    }

    public static bool DeleteLi_BookReplacementDetail(int li_BookReplacementDetailID)
    {
        SqlLi_BookReplacementDetailProvider sqlLi_BookReplacementDetailProvider = new SqlLi_BookReplacementDetailProvider();
        return sqlLi_BookReplacementDetailProvider.DeleteLi_BookReplacementDetail(li_BookReplacementDetailID);
    }
}
