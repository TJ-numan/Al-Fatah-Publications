using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonationForManager
{
	public Li_DonationForManager()
	{
	}

    public static List<Li_DonationFor> GetAllLi_DonationFors()
    {
        List<Li_DonationFor> li_DonationFors = new List<Li_DonationFor>();
        SqlLi_DonationForProvider sqlLi_DonationForProvider = new SqlLi_DonationForProvider();
        li_DonationFors = sqlLi_DonationForProvider.GetAllLi_DonationFors();
        return li_DonationFors;
    }


    public static Li_DonationFor GetLi_DonationForByID(int id)
    {
        Li_DonationFor li_DonationFor = new Li_DonationFor();
        SqlLi_DonationForProvider sqlLi_DonationForProvider = new SqlLi_DonationForProvider();
        li_DonationFor = sqlLi_DonationForProvider.GetLi_DonationForByID(id);
        return li_DonationFor;
    }


    public static int InsertLi_DonationFor(Li_DonationFor li_DonationFor)
    {
        SqlLi_DonationForProvider sqlLi_DonationForProvider = new SqlLi_DonationForProvider();
        return sqlLi_DonationForProvider.InsertLi_DonationFor(li_DonationFor);
    }


    public static bool UpdateLi_DonationFor(Li_DonationFor li_DonationFor)
    {
        SqlLi_DonationForProvider sqlLi_DonationForProvider = new SqlLi_DonationForProvider();
        return sqlLi_DonationForProvider.UpdateLi_DonationFor(li_DonationFor);
    }

    public static bool DeleteLi_DonationFor(int li_DonationForID)
    {
        SqlLi_DonationForProvider sqlLi_DonationForProvider = new SqlLi_DonationForProvider();
        return sqlLi_DonationForProvider.DeleteLi_DonationFor(li_DonationForID);
    }
}
