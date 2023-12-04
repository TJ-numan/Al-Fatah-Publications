using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_SpecimenAdjLetterDetailManager
{
	public Li_SpecimenAdjLetterDetailManager()
	{
	}

    public static List<Li_SpecimenAdjLetterDetail> GetAllLi_SpecimenAdjLetterDetails()
    {
        List<Li_SpecimenAdjLetterDetail> li_SpecimenAdjLetterDetails = new List<Li_SpecimenAdjLetterDetail>();
        SqlLi_SpecimenAdjLetterDetailProvider sqlLi_SpecimenAdjLetterDetailProvider = new SqlLi_SpecimenAdjLetterDetailProvider();
        li_SpecimenAdjLetterDetails = sqlLi_SpecimenAdjLetterDetailProvider.GetAllLi_SpecimenAdjLetterDetails();
        return li_SpecimenAdjLetterDetails;
    }


    public static Li_SpecimenAdjLetterDetail GetLi_SpecimenAdjLetterDetailByID(int id)
    {
        Li_SpecimenAdjLetterDetail li_SpecimenAdjLetterDetail = new Li_SpecimenAdjLetterDetail();
        SqlLi_SpecimenAdjLetterDetailProvider sqlLi_SpecimenAdjLetterDetailProvider = new SqlLi_SpecimenAdjLetterDetailProvider();
        li_SpecimenAdjLetterDetail = sqlLi_SpecimenAdjLetterDetailProvider.GetLi_SpecimenAdjLetterDetailByID(id);
        return li_SpecimenAdjLetterDetail;
    }


    public static int InsertLi_SpecimenAdjLetterDetail(Li_SpecimenAdjLetterDetail li_SpecimenAdjLetterDetail)
    {
        SqlLi_SpecimenAdjLetterDetailProvider sqlLi_SpecimenAdjLetterDetailProvider = new SqlLi_SpecimenAdjLetterDetailProvider();
        return sqlLi_SpecimenAdjLetterDetailProvider.InsertLi_SpecimenAdjLetterDetail(li_SpecimenAdjLetterDetail);
    }


    public static bool UpdateLi_SpecimenAdjLetterDetail(Li_SpecimenAdjLetterDetail li_SpecimenAdjLetterDetail)
    {
        SqlLi_SpecimenAdjLetterDetailProvider sqlLi_SpecimenAdjLetterDetailProvider = new SqlLi_SpecimenAdjLetterDetailProvider();
        return sqlLi_SpecimenAdjLetterDetailProvider.UpdateLi_SpecimenAdjLetterDetail(li_SpecimenAdjLetterDetail);
    }

    public static bool DeleteLi_SpecimenAdjLetterDetail(int li_SpecimenAdjLetterDetailID)
    {
        SqlLi_SpecimenAdjLetterDetailProvider sqlLi_SpecimenAdjLetterDetailProvider = new SqlLi_SpecimenAdjLetterDetailProvider();
        return sqlLi_SpecimenAdjLetterDetailProvider.DeleteLi_SpecimenAdjLetterDetail(li_SpecimenAdjLetterDetailID);
    }
}
