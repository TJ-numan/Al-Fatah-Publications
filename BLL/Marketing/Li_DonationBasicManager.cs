using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_DonationBasicManager
{
	public Li_DonationBasicManager()
	{
	}

    public static List<Li_DonationBasic> GetAllLi_DonationBasics()
    {
        List<Li_DonationBasic> li_DonationBasics = new List<Li_DonationBasic>();
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        li_DonationBasics = sqlLi_DonationBasicProvider.GetAllLi_DonationBasics();
        return li_DonationBasics;
    }


    public static Li_DonationBasic GetLi_DonationBasicByID(int id)
    {
        Li_DonationBasic li_DonationBasic = new Li_DonationBasic();
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        li_DonationBasic = sqlLi_DonationBasicProvider.GetLi_DonationBasicByID(id);
        return li_DonationBasic;
    }


    public static int InsertLi_DonationBasic(Li_DonationBasic li_DonationBasic)
    {
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        return sqlLi_DonationBasicProvider.InsertLi_DonationBasic(li_DonationBasic);
    }


    public static bool UpdateLi_DonationBasic(Li_DonationBasic li_DonationBasic)
    {
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        return sqlLi_DonationBasicProvider.UpdateLi_DonationBasic(li_DonationBasic);
    }

    public static bool DeleteLi_DonationBasic(int li_DonationBasicID)
    {
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        return sqlLi_DonationBasicProvider.DeleteLi_DonationBasic(li_DonationBasicID);
    }

    public static DataSet GetDonationExistingAgreement(string AgrNo, int DoFId)
    {
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        return sqlLi_DonationBasicProvider.GetDonationExistingAgreement(AgrNo,DoFId);
    }
    public static DataSet GetDonationExistingAgreementR2(string AgrNo, int DoFId, string AgYear )
    {
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        return sqlLi_DonationBasicProvider.GetDonationExistingAgreementR2(AgrNo,DoFId,AgYear);
    }
    public static DataSet GetMadrashaSomiteePersonInfo_ForEdit(string AgrNo, int DoFId, string AgrYear)
    {
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        return sqlLi_DonationBasicProvider.GetMadrashaSomiteePersonInfo_ForEdit(AgrNo, DoFId, AgrYear);
    }
    public static DataSet GetMadrashaSomiteePersonInfo_ForEditAmount(string AgrNo, int DoFId, string AgrYear)
    {
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        return sqlLi_DonationBasicProvider.GetMadrashaSomiteePersonInfo_ForEditAmount(AgrNo, DoFId, AgrYear);
    }

    public static DataSet GetScheduleAmountForDonationType(int DetId, int DoDesId)
    {
        SqlLi_DonationBasicProvider sqlLi_DonationBasicProvider = new SqlLi_DonationBasicProvider();
        return sqlLi_DonationBasicProvider.GetScheduleAmountForDonationType(DetId , DoDesId);
    }
}
