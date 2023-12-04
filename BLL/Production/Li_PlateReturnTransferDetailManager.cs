using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_PlateReturnTransferDetailManager
{
	public Li_PlateReturnTransferDetailManager()
	{
	}

    public static List<Li_PlateReturnTransferDetail> GetAllLi_PlateReturnTransferDetails()
    {
        List<Li_PlateReturnTransferDetail> li_PlateReturnTransferDetails = new List<Li_PlateReturnTransferDetail>();
        SqlLi_PlateReturnTransferDetailProvider sqlLi_PlateReturnTransferDetailProvider = new SqlLi_PlateReturnTransferDetailProvider();
        li_PlateReturnTransferDetails = sqlLi_PlateReturnTransferDetailProvider.GetAllLi_PlateReturnTransferDetails();
        return li_PlateReturnTransferDetails;
    }


    public static Li_PlateReturnTransferDetail GetLi_PlateReturnTransferDetailByID(int id)
    {
        Li_PlateReturnTransferDetail li_PlateReturnTransferDetail = new Li_PlateReturnTransferDetail();
        SqlLi_PlateReturnTransferDetailProvider sqlLi_PlateReturnTransferDetailProvider = new SqlLi_PlateReturnTransferDetailProvider();
        li_PlateReturnTransferDetail = sqlLi_PlateReturnTransferDetailProvider.GetLi_PlateReturnTransferDetailByID(id);
        return li_PlateReturnTransferDetail;
    }


    public static int InsertLi_PlateReturnTransferDetail(Li_PlateReturnTransferDetail li_PlateReturnTransferDetail)
    {
        SqlLi_PlateReturnTransferDetailProvider sqlLi_PlateReturnTransferDetailProvider = new SqlLi_PlateReturnTransferDetailProvider();
        return sqlLi_PlateReturnTransferDetailProvider.InsertLi_PlateReturnTransferDetail(li_PlateReturnTransferDetail);
    }


    public static bool UpdateLi_PlateReturnTransferDetail(Li_PlateReturnTransferDetail li_PlateReturnTransferDetail)
    {
        SqlLi_PlateReturnTransferDetailProvider sqlLi_PlateReturnTransferDetailProvider = new SqlLi_PlateReturnTransferDetailProvider();
        return sqlLi_PlateReturnTransferDetailProvider.UpdateLi_PlateReturnTransferDetail(li_PlateReturnTransferDetail);
    }

    public static bool DeleteLi_PlateReturnTransferDetail(int li_PlateReturnTransferDetailID)
    {
        SqlLi_PlateReturnTransferDetailProvider sqlLi_PlateReturnTransferDetailProvider = new SqlLi_PlateReturnTransferDetailProvider();
        return sqlLi_PlateReturnTransferDetailProvider.DeleteLi_PlateReturnTransferDetail(li_PlateReturnTransferDetailID);
    }
}
