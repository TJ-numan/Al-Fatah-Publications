using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PayScaleDetailManager
{
	public Li_PayScaleDetailManager()
	{
	}

    public static List<Li_PayScaleDetail> GetAllLi_PayScaleDetails()
    {
        List<Li_PayScaleDetail> li_PayScaleDetails = new List<Li_PayScaleDetail>();
        SqlLi_PayScaleDetailProvider sqlLi_PayScaleDetailProvider = new SqlLi_PayScaleDetailProvider();
        li_PayScaleDetails = sqlLi_PayScaleDetailProvider.GetAllLi_PayScaleDetails();
        return li_PayScaleDetails;
    }


    public static Li_PayScaleDetail GetLi_PayScaleDetailByID(int id)
    {
        Li_PayScaleDetail li_PayScaleDetail = new Li_PayScaleDetail();
        SqlLi_PayScaleDetailProvider sqlLi_PayScaleDetailProvider = new SqlLi_PayScaleDetailProvider();
        li_PayScaleDetail = sqlLi_PayScaleDetailProvider.GetLi_PayScaleDetailByID(id);
        return li_PayScaleDetail;
    }


    public static int InsertLi_PayScaleDetail(Li_PayScaleDetail li_PayScaleDetail)
    {
        SqlLi_PayScaleDetailProvider sqlLi_PayScaleDetailProvider = new SqlLi_PayScaleDetailProvider();
        return sqlLi_PayScaleDetailProvider.InsertLi_PayScaleDetail(li_PayScaleDetail);
    }


    public static bool UpdateLi_PayScaleDetail(Li_PayScaleDetail li_PayScaleDetail)
    {
        SqlLi_PayScaleDetailProvider sqlLi_PayScaleDetailProvider = new SqlLi_PayScaleDetailProvider();
        return sqlLi_PayScaleDetailProvider.UpdateLi_PayScaleDetail(li_PayScaleDetail);
    }

    public static bool DeleteLi_PayScaleDetail(int li_PayScaleDetailID)
    {
        SqlLi_PayScaleDetailProvider sqlLi_PayScaleDetailProvider = new SqlLi_PayScaleDetailProvider();
        return sqlLi_PayScaleDetailProvider.DeleteLi_PayScaleDetail(li_PayScaleDetailID);
    }
    public static DataSet GetPayScale_ByPayGradeID(int PayGradeID)
    {
        SqlLi_PayScaleDetailProvider sqlLi_PayScaleByPGradeIDProvider = new SqlLi_PayScaleDetailProvider();
        return sqlLi_PayScaleByPGradeIDProvider.GetPayScale_ByPayGradeID(PayGradeID);
    }
}
