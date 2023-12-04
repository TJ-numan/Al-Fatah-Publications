using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ProvidentFundDetailManager
{
	public Li_ProvidentFundDetailManager()
	{
	}

    public static List<Li_ProvidentFundDetail> GetAllLi_ProvidentFundDetails()
    {
        List<Li_ProvidentFundDetail> li_ProvidentFundDetails = new List<Li_ProvidentFundDetail>();
        SqlLi_ProvidentFundDetailProvider sqlLi_ProvidentFundDetailProvider = new SqlLi_ProvidentFundDetailProvider();
        li_ProvidentFundDetails = sqlLi_ProvidentFundDetailProvider.GetAllLi_ProvidentFundDetails();
        return li_ProvidentFundDetails;
    }


    public static Li_ProvidentFundDetail GetLi_ProvidentFundDetailByID(int id)
    {
        Li_ProvidentFundDetail li_ProvidentFundDetail = new Li_ProvidentFundDetail();
        SqlLi_ProvidentFundDetailProvider sqlLi_ProvidentFundDetailProvider = new SqlLi_ProvidentFundDetailProvider();
        li_ProvidentFundDetail = sqlLi_ProvidentFundDetailProvider.GetLi_ProvidentFundDetailByID(id);
        return li_ProvidentFundDetail;
    }


    public static int InsertLi_ProvidentFundDetail(Li_ProvidentFundDetail li_ProvidentFundDetail)
    {
        SqlLi_ProvidentFundDetailProvider sqlLi_ProvidentFundDetailProvider = new SqlLi_ProvidentFundDetailProvider();
        return sqlLi_ProvidentFundDetailProvider.InsertLi_ProvidentFundDetail(li_ProvidentFundDetail);
    }


    public static bool UpdateLi_ProvidentFundDetail(Li_ProvidentFundDetail li_ProvidentFundDetail)
    {
        SqlLi_ProvidentFundDetailProvider sqlLi_ProvidentFundDetailProvider = new SqlLi_ProvidentFundDetailProvider();
        return sqlLi_ProvidentFundDetailProvider.UpdateLi_ProvidentFundDetail(li_ProvidentFundDetail);
    }

    public static bool DeleteLi_ProvidentFundDetail(int li_ProvidentFundDetailID)
    {
        SqlLi_ProvidentFundDetailProvider sqlLi_ProvidentFundDetailProvider = new SqlLi_ProvidentFundDetailProvider();
        return sqlLi_ProvidentFundDetailProvider.DeleteLi_ProvidentFundDetail(li_ProvidentFundDetailID);
    }


    public static DataSet GetAll_EmployeeProvidentFundByCompany(string CompanyId)
    {
        SqlLi_ProvidentFundDetailProvider sqlLi_ProvidentFundDetailProvider = new SqlLi_ProvidentFundDetailProvider();
        return sqlLi_ProvidentFundDetailProvider.GetAll_EmployeeProvidentFundByCompany(CompanyId);

    }
}
