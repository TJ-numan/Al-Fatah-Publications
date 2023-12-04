using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonPaymentSheduleManager
{
	public Li_DonPaymentSheduleManager()
	{
	}

    public static List<Li_DonPaymentShedule> GetAllLi_DonPaymentShedules()
    {
        List<Li_DonPaymentShedule> li_DonPaymentShedules = new List<Li_DonPaymentShedule>();
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        li_DonPaymentShedules = sqlLi_DonPaymentSheduleProvider.GetAllLi_DonPaymentShedules();
        return li_DonPaymentShedules;
    }


    public static Li_DonPaymentShedule GetLi_DonPaymentSheduleByID(int id)
    {
        Li_DonPaymentShedule li_DonPaymentShedule = new Li_DonPaymentShedule();
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        li_DonPaymentShedule = sqlLi_DonPaymentSheduleProvider.GetLi_DonPaymentSheduleByID(id);
        return li_DonPaymentShedule;
    }


    public static int InsertLi_DonPaymentShedule(Li_DonPaymentShedule li_DonPaymentShedule)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.InsertLi_DonPaymentShedule(li_DonPaymentShedule);
    }


    public static bool UpdateLi_DonPaymentShedule(Li_DonPaymentShedule li_DonPaymentShedule)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.UpdateLi_DonPaymentShedule(li_DonPaymentShedule);
    }

    public static bool DeleteLi_DonPaymentShedule(int li_DonPaymentSheduleID)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.DeleteLi_DonPaymentShedule(li_DonPaymentSheduleID);
    }

    public static DataSet GetAgreementAmount(string AgrNo,int DetId)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.GetAgreementAmount(AgrNo, DetId);
    }
    public static DataSet GetAgreementAmountR2(string AgrNo,int DetId, string AgrYear)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.GetAgreementAmountR2(AgrNo, DetId,AgrYear);
    }    public static DataSet GetAgreementAmountByMadSomiPerson(int DetId)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.GetAgreementAmountByMadSomiPerson(DetId);
    }

    public static DataSet GetDonationName(string AgrNo)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.GetDonationName(AgrNo);
    }

    public static DataSet GetDonationNameR2(string AgrNo , string AgrYear)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.GetDonationNameR2(AgrNo,AgrYear);
    }




    public static DataSet GetDonationBasicAmntByAgreement(string AgrNo, int DetId)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.GetDonationBasicAmntByAgreement(AgrNo,DetId);
    }

    public static DataSet GetDonationBasicAmntByAgreementR2(string AgrNo, int DetId, string AgrYear)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.GetDonationBasicAmntByAgreementR2(AgrNo,DetId,AgrYear);
    }
    public static DataSet GetAmntSheduleBy_DonFor(int DetId)
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.GetAmntSheduleBy_DonFor(DetId);
    }  
    public static decimal  GetDonationPreviousPaid(int DetId,int DoDesID )
    {
        SqlLi_DonPaymentSheduleProvider sqlLi_DonPaymentSheduleProvider = new SqlLi_DonPaymentSheduleProvider();
        return sqlLi_DonPaymentSheduleProvider.GetDonationPreviousPaid(DetId, DoDesID);
    }
}
