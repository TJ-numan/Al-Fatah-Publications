using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;


public class Li_PlateDamageDetailManager
{
    public Li_PlateDamageDetailManager()
    {

    }

    public static List<Li_PlateDamageDetail> GetAllLi_PlatePurchaseDetails()
    {
        List<Li_PlateDamageDetail> li_PlateDamageDetails = new List<Li_PlateDamageDetail>();
        SqlLi_PlateDamageDetailProvider sqlLi_PlateDamageDetailProvider = new SqlLi_PlateDamageDetailProvider();
        li_PlateDamageDetails = sqlLi_PlateDamageDetailProvider.GetAllLi_PlateDamageDetails();
        return li_PlateDamageDetails;
    }


    public static Li_PlateDamageDetail GetLi_PlateDamageDetailByID(int id)
    {
        Li_PlateDamageDetail li_PlateDamageDetail = new Li_PlateDamageDetail();
        SqlLi_PlateDamageDetailProvider sqlLi_PlateDamageDetailProvider = new SqlLi_PlateDamageDetailProvider();
        li_PlateDamageDetail = sqlLi_PlateDamageDetailProvider.GetLi_PlateDamageDetailByID(id);
        return li_PlateDamageDetail;
    }


    public static int InsertLi_PlateDamageDetail(Li_PlateDamageDetail li_PlateDamageDetail)
    {
        SqlLi_PlateDamageDetailProvider sqlLi_PlateDamageDetailProvider = new SqlLi_PlateDamageDetailProvider();
        return sqlLi_PlateDamageDetailProvider.InsertLi_PlateDamageDetail(li_PlateDamageDetail);
    }


    public static bool UpdateLi_PlateDamageDetail(Li_PlateDamageDetail li_PlateDamageDetail)
    {
        SqlLi_PlateDamageDetailProvider sqlLi_PlateDamageDetailProvider = new SqlLi_PlateDamageDetailProvider();
        return sqlLi_PlateDamageDetailProvider.UpdateLi_PlateDamageDetail(li_PlateDamageDetail);
    }

    public static bool DeleteLi_PlateDamageDetail(int li_PlateDamageDetailID)
    {
        SqlLi_PlateDamageDetailProvider sqlLi_PlateDamageDetailProvider = new SqlLi_PlateDamageDetailProvider();
        return sqlLi_PlateDamageDetailProvider.DeleteLi_PlateDamageDetail(li_PlateDamageDetailID);
    }
    public static int InsertLi_PlateDamageStockDetail(Li_PlateDamageDetail li_PlateDamageDetail)
    {
        SqlLi_PlateDamageDetailProvider sqlLi_PlateDamageDetailProvider = new SqlLi_PlateDamageDetailProvider();
        return sqlLi_PlateDamageDetailProvider.InsertLi_PlateDamageStockDetail(li_PlateDamageDetail);
    }
}


