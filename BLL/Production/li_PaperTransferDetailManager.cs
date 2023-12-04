using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperTransferDetailManager
{
	public Li_PaperTransferDetailManager()
	{
	}

    public static List<Li_PaperTransferDetail> GetAllLi_PaperTransferDetails()
    {
        List<Li_PaperTransferDetail> li_PaperTransferDetails = new List<Li_PaperTransferDetail>();
        SqlLi_PaperTransferDetailProvider sqlLi_PaperTransferDetailProvider = new SqlLi_PaperTransferDetailProvider();
        li_PaperTransferDetails = sqlLi_PaperTransferDetailProvider.GetAllLi_PaperTransferDetails();
        return li_PaperTransferDetails;
    }


    public static Li_PaperTransferDetail GetLi_PaperTransferDetailByID(int id)
    {
        Li_PaperTransferDetail li_PaperTransferDetail = new Li_PaperTransferDetail();
        SqlLi_PaperTransferDetailProvider sqlLi_PaperTransferDetailProvider = new SqlLi_PaperTransferDetailProvider();
        li_PaperTransferDetail = sqlLi_PaperTransferDetailProvider.GetLi_PaperTransferDetailByID(id);
        return li_PaperTransferDetail;
    }


    public static int InsertLi_PaperTransferDetail(Li_PaperTransferDetail li_PaperTransferDetail)
    {
        SqlLi_PaperTransferDetailProvider sqlLi_PaperTransferDetailProvider = new SqlLi_PaperTransferDetailProvider();
        return sqlLi_PaperTransferDetailProvider.InsertLi_PaperTransferDetail(li_PaperTransferDetail);
    }


    public static bool UpdateLi_PaperTransferDetail(Li_PaperTransferDetail li_PaperTransferDetail)
    {
        SqlLi_PaperTransferDetailProvider sqlLi_PaperTransferDetailProvider = new SqlLi_PaperTransferDetailProvider();
        return sqlLi_PaperTransferDetailProvider.UpdateLi_PaperTransferDetail(li_PaperTransferDetail);
    }

    public static bool DeleteLi_PaperTransferDetail(int li_PaperTransferDetailID)
    {
        SqlLi_PaperTransferDetailProvider sqlLi_PaperTransferDetailProvider = new SqlLi_PaperTransferDetailProvider();
        return sqlLi_PaperTransferDetailProvider.DeleteLi_PaperTransferDetail(li_PaperTransferDetailID);
    }
}
