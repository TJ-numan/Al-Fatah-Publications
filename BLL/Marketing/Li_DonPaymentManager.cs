using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonPaymentManager
{
	public Li_DonPaymentManager()
	{
	}

    public static List<Li_DonPayment> GetAllLi_DonPayments()
    {
        List<Li_DonPayment> li_DonPayments = new List<Li_DonPayment>();
        SqlLi_DonPaymentProvider sqlLi_DonPaymentProvider = new SqlLi_DonPaymentProvider();
        li_DonPayments = sqlLi_DonPaymentProvider.GetAllLi_DonPayments();
        return li_DonPayments;
    }


    public static Li_DonPayment GetLi_DonPaymentByID(int PSId)
    {
        Li_DonPayment li_DonPayment = new Li_DonPayment();
        SqlLi_DonPaymentProvider sqlLi_DonPaymentProvider = new SqlLi_DonPaymentProvider();
        li_DonPayment = sqlLi_DonPaymentProvider.GetLi_DonPaymentByID(PSId);
        return li_DonPayment;
    }


    public static int InsertLi_DonPayment(Li_DonPayment li_DonPayment)
    {
        SqlLi_DonPaymentProvider sqlLi_DonPaymentProvider = new SqlLi_DonPaymentProvider();
        return sqlLi_DonPaymentProvider.InsertLi_DonPayment(li_DonPayment);
    }


    public static bool UpdateLi_DonPayment(Li_DonPayment li_DonPayment)
    {
        SqlLi_DonPaymentProvider sqlLi_DonPaymentProvider = new SqlLi_DonPaymentProvider();
        return sqlLi_DonPaymentProvider.UpdateLi_DonPayment(li_DonPayment);
    }

    public static bool DeleteLi_DonPayment(int li_DonPaymentID)
    {
        SqlLi_DonPaymentProvider sqlLi_DonPaymentProvider = new SqlLi_DonPaymentProvider();
        return sqlLi_DonPaymentProvider.DeleteLi_DonPayment(li_DonPaymentID);
    }

    public static DataSet GetDonPaymentInfoBySheID(int PSID)
    {
        SqlLi_DonPaymentProvider sqlLi_DonPaymentProvider = new SqlLi_DonPaymentProvider();
        return sqlLi_DonPaymentProvider.GetLi_DonPaymentBySheID(PSID);
    }
    public static DataSet GetLi_DonOneShedTotalAmtSheID(int PSID)
    {
        SqlLi_DonPaymentProvider sqlLi_DonPaymentProvider = new SqlLi_DonPaymentProvider();
        return sqlLi_DonPaymentProvider.GetLi_DonOneShedTotalAmtSheID(PSID);
    }
    public static DataSet GetLi_DonLetterInfoByLetterNO(string LetterNo)
    {
        SqlLi_DonPaymentProvider sqlLi_DonPaymentProvider = new SqlLi_DonPaymentProvider();
        return sqlLi_DonPaymentProvider.GetLi_DonLetterInfoByLetterNO(LetterNo);
    }
}
