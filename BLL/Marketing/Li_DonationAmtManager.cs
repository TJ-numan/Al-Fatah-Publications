using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonationAmtManager
{
	public Li_DonationAmtManager()
	{
	}

    public static List<Li_DonationAmt> GetAllLi_DonationAmts()
    {
        List<Li_DonationAmt> li_DonationAmts = new List<Li_DonationAmt>();
        SqlLi_DonationAmtProvider sqlLi_DonationAmtProvider = new SqlLi_DonationAmtProvider();
        li_DonationAmts = sqlLi_DonationAmtProvider.GetAllLi_DonationAmts();
        return li_DonationAmts;
    }


    public static Li_DonationAmt GetLi_DonationAmtByID(int id)
    {
        Li_DonationAmt li_DonationAmt = new Li_DonationAmt();
        SqlLi_DonationAmtProvider sqlLi_DonationAmtProvider = new SqlLi_DonationAmtProvider();
        li_DonationAmt = sqlLi_DonationAmtProvider.GetLi_DonationAmtByID(id);
        return li_DonationAmt;
    }


    public static int InsertLi_DonationAmt(Li_DonationAmt li_DonationAmt)
    {
        SqlLi_DonationAmtProvider sqlLi_DonationAmtProvider = new SqlLi_DonationAmtProvider();
        return sqlLi_DonationAmtProvider.InsertLi_DonationAmt(li_DonationAmt);
    }


    public static bool UpdateLi_DonationAmt(Li_DonationAmt li_DonationAmt)
    {
        SqlLi_DonationAmtProvider sqlLi_DonationAmtProvider = new SqlLi_DonationAmtProvider();
        return sqlLi_DonationAmtProvider.UpdateLi_DonationAmt(li_DonationAmt);
    }

    public static bool DeleteLi_DonationAmt(int li_DonationAmtID)
    {
        SqlLi_DonationAmtProvider sqlLi_DonationAmtProvider = new SqlLi_DonationAmtProvider();
        return sqlLi_DonationAmtProvider.DeleteLi_DonationAmt(li_DonationAmtID);
    }

}
