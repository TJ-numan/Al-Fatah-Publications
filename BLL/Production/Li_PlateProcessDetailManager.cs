using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlateProcessDetailManager
{
	public Li_PlateProcessDetailManager()
	{
	}

    public static List<Li_PlateProcessDetail> GetAllLi_PlateProcessDetails()
    {
        List<Li_PlateProcessDetail> li_PlateProcessDetails = new List<Li_PlateProcessDetail>();
        SqlLi_PlateProcessDetailProvider sqlLi_PlateProcessDetailProvider = new SqlLi_PlateProcessDetailProvider();
        li_PlateProcessDetails = sqlLi_PlateProcessDetailProvider.GetAllLi_PlateProcessDetails();
        return li_PlateProcessDetails;
    }


    public static Li_PlateProcessDetail GetLi_PlateProcessDetailByID(int id)
    {
        Li_PlateProcessDetail li_PlateProcessDetail = new Li_PlateProcessDetail();
        SqlLi_PlateProcessDetailProvider sqlLi_PlateProcessDetailProvider = new SqlLi_PlateProcessDetailProvider();
        li_PlateProcessDetail = sqlLi_PlateProcessDetailProvider.GetLi_PlateProcessDetailByID(id);
        return li_PlateProcessDetail;
    }


    public static int InsertLi_PlateProcessDetail(Li_PlateProcessDetail li_PlateProcessDetail)
    {
        SqlLi_PlateProcessDetailProvider sqlLi_PlateProcessDetailProvider = new SqlLi_PlateProcessDetailProvider();
        return sqlLi_PlateProcessDetailProvider.InsertLi_PlateProcessDetail(li_PlateProcessDetail);
    }


    public static bool UpdateLi_PlateProcessDetail(Li_PlateProcessDetail li_PlateProcessDetail)
    {
        SqlLi_PlateProcessDetailProvider sqlLi_PlateProcessDetailProvider = new SqlLi_PlateProcessDetailProvider();
        return sqlLi_PlateProcessDetailProvider.UpdateLi_PlateProcessDetail(li_PlateProcessDetail);
    }

    public static bool DeleteLi_PlateProcessDetail(int li_PlateProcessDetailID)
    {
        SqlLi_PlateProcessDetailProvider sqlLi_PlateProcessDetailProvider = new SqlLi_PlateProcessDetailProvider();
        return sqlLi_PlateProcessDetailProvider.DeleteLi_PlateProcessDetail(li_PlateProcessDetailID);
    }
}
