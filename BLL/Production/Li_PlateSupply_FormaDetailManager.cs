using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSupply_FormaDetailManager
{
	public Li_PlateSupply_FormaDetailManager()
	{
	}

    public static List<Li_PlateSupply_FormaDetail> GetAllLi_PlateSupply_FormaDetails()
    {
        List<Li_PlateSupply_FormaDetail> li_PlateSupply_FormaDetails = new List<Li_PlateSupply_FormaDetail>();
        SqlLi_PlateSupply_FormaDetailProvider sqlLi_PlateSupply_FormaDetailProvider = new SqlLi_PlateSupply_FormaDetailProvider();
        li_PlateSupply_FormaDetails = sqlLi_PlateSupply_FormaDetailProvider.GetAllLi_PlateSupply_FormaDetails();
        return li_PlateSupply_FormaDetails;
    }


    public static Li_PlateSupply_FormaDetail GetLi_PlateSupply_FormaDetailByID(int id)
    {
        Li_PlateSupply_FormaDetail li_PlateSupply_FormaDetail = new Li_PlateSupply_FormaDetail();
        SqlLi_PlateSupply_FormaDetailProvider sqlLi_PlateSupply_FormaDetailProvider = new SqlLi_PlateSupply_FormaDetailProvider();
        li_PlateSupply_FormaDetail = sqlLi_PlateSupply_FormaDetailProvider.GetLi_PlateSupply_FormaDetailByID(id);
        return li_PlateSupply_FormaDetail;
    }


    public static int InsertLi_PlateSupply_FormaDetail(Li_PlateSupply_FormaDetail li_PlateSupply_FormaDetail)
    {
        SqlLi_PlateSupply_FormaDetailProvider sqlLi_PlateSupply_FormaDetailProvider = new SqlLi_PlateSupply_FormaDetailProvider();
        return sqlLi_PlateSupply_FormaDetailProvider.InsertLi_PlateSupply_FormaDetail(li_PlateSupply_FormaDetail);
    }


    public static bool UpdateLi_PlateSupply_FormaDetail(Li_PlateSupply_FormaDetail li_PlateSupply_FormaDetail)
    {
        SqlLi_PlateSupply_FormaDetailProvider sqlLi_PlateSupply_FormaDetailProvider = new SqlLi_PlateSupply_FormaDetailProvider();
        return sqlLi_PlateSupply_FormaDetailProvider.UpdateLi_PlateSupply_FormaDetail(li_PlateSupply_FormaDetail);
    }

    public static bool DeleteLi_PlateSupply_FormaDetail(int li_PlateSupply_FormaDetailID)
    {
        SqlLi_PlateSupply_FormaDetailProvider sqlLi_PlateSupply_FormaDetailProvider = new SqlLi_PlateSupply_FormaDetailProvider();
        return sqlLi_PlateSupply_FormaDetailProvider.DeleteLi_PlateSupply_FormaDetail(li_PlateSupply_FormaDetailID);
    }
}
