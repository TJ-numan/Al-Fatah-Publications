using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PaperAcUsedDetailManager
{
	public Li_PaperAcUsedDetailManager()
	{
	}

    public static List<Li_PaperAcUsedDetail> GetAllLi_PaperAcUsedDetails()
    {
        List<Li_PaperAcUsedDetail> li_PaperAcUsedDetails = new List<Li_PaperAcUsedDetail>();
        SqlLi_PaperAcUsedDetailProvider sqlLi_PaperAcUsedDetailProvider = new SqlLi_PaperAcUsedDetailProvider();
        li_PaperAcUsedDetails = sqlLi_PaperAcUsedDetailProvider.GetAllLi_PaperAcUsedDetails();
        return li_PaperAcUsedDetails;
    }


    public static Li_PaperAcUsedDetail GetLi_PaperAcUsedDetailByID(int id)
    {
        Li_PaperAcUsedDetail li_PaperAcUsedDetail = new Li_PaperAcUsedDetail();
        SqlLi_PaperAcUsedDetailProvider sqlLi_PaperAcUsedDetailProvider = new SqlLi_PaperAcUsedDetailProvider();
        li_PaperAcUsedDetail = sqlLi_PaperAcUsedDetailProvider.GetLi_PaperAcUsedDetailByID(id);
        return li_PaperAcUsedDetail;
    }


    public static int InsertLi_PaperAcUsedDetail(Li_PaperAcUsedDetail li_PaperAcUsedDetail)
    {
        SqlLi_PaperAcUsedDetailProvider sqlLi_PaperAcUsedDetailProvider = new SqlLi_PaperAcUsedDetailProvider();
        return sqlLi_PaperAcUsedDetailProvider.InsertLi_PaperAcUsedDetail(li_PaperAcUsedDetail);
    }


    public static bool UpdateLi_PaperAcUsedDetail(Li_PaperAcUsedDetail li_PaperAcUsedDetail)
    {
        SqlLi_PaperAcUsedDetailProvider sqlLi_PaperAcUsedDetailProvider = new SqlLi_PaperAcUsedDetailProvider();
        return sqlLi_PaperAcUsedDetailProvider.UpdateLi_PaperAcUsedDetail(li_PaperAcUsedDetail);
    }

    public static bool DeleteLi_PaperAcUsedDetail(int li_PaperAcUsedDetailID)
    {
        SqlLi_PaperAcUsedDetailProvider sqlLi_PaperAcUsedDetailProvider = new SqlLi_PaperAcUsedDetailProvider();
        return sqlLi_PaperAcUsedDetailProvider.DeleteLi_PaperAcUsedDetail(li_PaperAcUsedDetailID);
    }
}
