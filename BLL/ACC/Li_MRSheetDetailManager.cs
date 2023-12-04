using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_MRSheetDetailManager
{
	public Li_MRSheetDetailManager()
	{
	}

    public static List<Li_MRSheetDetail> GetAllLi_MRSheetDetails()
    {
        List<Li_MRSheetDetail> li_MRSheetDetails = new List<Li_MRSheetDetail>();
        SqlLi_MRSheetDetailProvider sqlLi_MRSheetDetailProvider = new SqlLi_MRSheetDetailProvider();
        li_MRSheetDetails = sqlLi_MRSheetDetailProvider.GetAllLi_MRSheetDetails();
        return li_MRSheetDetails;
    }


    public static Li_MRSheetDetail GetLi_MRSheetDetailByID(int id)
    {
        Li_MRSheetDetail li_MRSheetDetail = new Li_MRSheetDetail();
        SqlLi_MRSheetDetailProvider sqlLi_MRSheetDetailProvider = new SqlLi_MRSheetDetailProvider();
        li_MRSheetDetail = sqlLi_MRSheetDetailProvider.GetLi_MRSheetDetailByID(id);
        return li_MRSheetDetail;
    }


    public static int InsertLi_MRSheetDetail(Li_MRSheetDetail li_MRSheetDetail)
    {
        SqlLi_MRSheetDetailProvider sqlLi_MRSheetDetailProvider = new SqlLi_MRSheetDetailProvider();
        return sqlLi_MRSheetDetailProvider.InsertLi_MRSheetDetail(li_MRSheetDetail);
    }


    public static bool UpdateLi_MRSheetDetail(Li_MRSheetDetail li_MRSheetDetail)
    {
        SqlLi_MRSheetDetailProvider sqlLi_MRSheetDetailProvider = new SqlLi_MRSheetDetailProvider();
        return sqlLi_MRSheetDetailProvider.UpdateLi_MRSheetDetail(li_MRSheetDetail);
    }

    public static bool DeleteLi_MRSheetDetail(Li_MRSheetDetail li_MRSheetDetail)
    {
        SqlLi_MRSheetDetailProvider sqlLi_MRSheetDetailProvider = new SqlLi_MRSheetDetailProvider();
        return sqlLi_MRSheetDetailProvider.DeleteLi_MRSheetDetail(li_MRSheetDetail);
    }
    public static bool HeldUpLi_MRSheetDetail(Li_MRSheetDetail li_MRSheetDetail)
    {
        SqlLi_MRSheetDetailProvider sqlLi_MRSheetDetailProvider = new SqlLi_MRSheetDetailProvider();
        return sqlLi_MRSheetDetailProvider.HeldUpLi_MRSheetDetail(li_MRSheetDetail);
    }

    public static DataTable Get_MRSheetDetails(int MRDetId)
    {
        SqlLi_MRSheetDetailProvider sqlLi_MRSheetDetailProvider = new SqlLi_MRSheetDetailProvider();
        return sqlLi_MRSheetDetailProvider.Get_MRSheetDetails(MRDetId);

    }


}
