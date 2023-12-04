using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonationDetailManager
{
	public Li_DonationDetailManager()
	{

	}

    public static List<Li_DonationDetail> GetAllLi_DonationDetails()
    {
        List<Li_DonationDetail> li_DonationDetails = new List<Li_DonationDetail>();
        SqlLi_DonationDetailProvider sqlLi_DonationDetailProvider = new SqlLi_DonationDetailProvider();
        li_DonationDetails = sqlLi_DonationDetailProvider.GetAllLi_DonationDetails();
        return li_DonationDetails;
    }


    public static Li_DonationDetail GetLi_DonationDetailByID(int id)
    {
        Li_DonationDetail li_DonationDetail = new Li_DonationDetail();
        SqlLi_DonationDetailProvider sqlLi_DonationDetailProvider = new SqlLi_DonationDetailProvider();
        li_DonationDetail = sqlLi_DonationDetailProvider.GetLi_DonationDetailByID(id);
        return li_DonationDetail;
    }


    public static int InsertLi_DonationDetail(Li_DonationDetail li_DonationDetail)
    {
        SqlLi_DonationDetailProvider sqlLi_DonationDetailProvider = new SqlLi_DonationDetailProvider();
        return sqlLi_DonationDetailProvider.InsertLi_DonationDetail(li_DonationDetail);
    }


    public static bool UpdateLi_DonationDetail(Li_DonationDetail li_DonationDetail)
    {
        SqlLi_DonationDetailProvider sqlLi_DonationDetailProvider = new SqlLi_DonationDetailProvider();
        return sqlLi_DonationDetailProvider.UpdateLi_DonationDetail(li_DonationDetail);
    }

    public static bool DeleteLi_DonationDetail(int li_DonationDetailID)
    {
        SqlLi_DonationDetailProvider sqlLi_DonationDetailProvider = new SqlLi_DonationDetailProvider();
        return sqlLi_DonationDetailProvider.DeleteLi_DonationDetail(li_DonationDetailID);
    }

    public static DataSet GetTeritoryWiseBudgetAmt(int ThanaId, int DoDesId ,string agrYear)
    {
        SqlLi_DonationDetailProvider sqlLi_DonationDetailProvider = new SqlLi_DonationDetailProvider();
        return sqlLi_DonationDetailProvider.GetTeritoryWiseBudgetAmt(ThanaId,DoDesId,agrYear);
    }
    public static DataSet GetTeritoryWiseBudgetAmtPaid(int ThanaId, int DoDesId,string agrYear)
    {
        SqlLi_DonationDetailProvider sqlLi_DonationDetailProvider = new SqlLi_DonationDetailProvider();
        return sqlLi_DonationDetailProvider.GetTeritoryWiseBudgetAmtPaid(ThanaId, DoDesId,agrYear );
    }
    public static DataSet GetTeritoryWiseBudgetAndPaid(int   ThanaId)
    {
        SqlLi_DonationDetailProvider sqlLi_DonationDetailProvider = new SqlLi_DonationDetailProvider();
        return sqlLi_DonationDetailProvider.GetTeritoryWiseBudgetAndPaid(ThanaId );
    }  
    public static DataSet GetTeritoryWiseBudgetAndPaidR2(string  agrYear ,string  TerritoryCode )
    {
        SqlLi_DonationDetailProvider sqlLi_DonationDetailProvider = new SqlLi_DonationDetailProvider();
        return sqlLi_DonationDetailProvider.GetTeritoryWiseBudgetAndPaidR2(agrYear, TerritoryCode);
    }
}
