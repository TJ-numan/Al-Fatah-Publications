using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
  


public class Li_Specimen_ReturnDetailManager
{
	public Li_Specimen_ReturnDetailManager()
	{
	}

    public static List<Li_Specimen_ReturnDetail> GetAllLi_Specimen_ReturnDetails()
    {
        List<Li_Specimen_ReturnDetail> li_Specimen_ReturnDetails = new List<Li_Specimen_ReturnDetail>();
        SqlLi_Specimen_ReturnDetailProvider sqlLi_Specimen_ReturnDetailProvider = new SqlLi_Specimen_ReturnDetailProvider();
        li_Specimen_ReturnDetails = sqlLi_Specimen_ReturnDetailProvider.GetAllLi_Specimen_ReturnDetails();
        return li_Specimen_ReturnDetails;
    }


    public static Li_Specimen_ReturnDetail GetLi_Specimen_ReturnDetailByID(int id)
    {
        Li_Specimen_ReturnDetail li_Specimen_ReturnDetail = new Li_Specimen_ReturnDetail();
        SqlLi_Specimen_ReturnDetailProvider sqlLi_Specimen_ReturnDetailProvider = new SqlLi_Specimen_ReturnDetailProvider();
        li_Specimen_ReturnDetail = sqlLi_Specimen_ReturnDetailProvider.GetLi_Specimen_ReturnDetailByID(id);
        return li_Specimen_ReturnDetail;
    }


    public static int InsertLi_Specimen_ReturnDetail(Li_Specimen_ReturnDetail li_Specimen_ReturnDetail)
    {
        SqlLi_Specimen_ReturnDetailProvider sqlLi_Specimen_ReturnDetailProvider = new SqlLi_Specimen_ReturnDetailProvider();
        return sqlLi_Specimen_ReturnDetailProvider.InsertLi_Specimen_ReturnDetail(li_Specimen_ReturnDetail);
    }


    public static bool UpdateLi_Specimen_ReturnDetail(Li_Specimen_ReturnDetail li_Specimen_ReturnDetail)
    {
        SqlLi_Specimen_ReturnDetailProvider sqlLi_Specimen_ReturnDetailProvider = new SqlLi_Specimen_ReturnDetailProvider();
        return sqlLi_Specimen_ReturnDetailProvider.UpdateLi_Specimen_ReturnDetail(li_Specimen_ReturnDetail);
    }

    public static bool DeleteLi_Specimen_ReturnDetail(int li_Specimen_ReturnDetailID)
    {
        SqlLi_Specimen_ReturnDetailProvider sqlLi_Specimen_ReturnDetailProvider = new SqlLi_Specimen_ReturnDetailProvider();
        return sqlLi_Specimen_ReturnDetailProvider.DeleteLi_Specimen_ReturnDetail(li_Specimen_ReturnDetailID);
    }
}
