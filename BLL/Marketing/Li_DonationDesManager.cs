using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonationDesManager
{
	public Li_DonationDesManager()
	{
	}

    public static List<Li_DonationDes> GetAllLi_DonationDess()
    {
        List<Li_DonationDes> li_DonationDess = new List<Li_DonationDes>();
        SqlLi_DonationDesProvider sqlLi_DonationDesProvider = new SqlLi_DonationDesProvider();
        li_DonationDess = sqlLi_DonationDesProvider.GetAllLi_DonationDess();
        return li_DonationDess;
    }

    public static List<Li_DonationDes> GetAllLi_DonationDessWithBudget()
    {
        List<Li_DonationDes> li_DonationDess = new List<Li_DonationDes>();
        SqlLi_DonationDesProvider sqlLi_DonationDesProvider = new SqlLi_DonationDesProvider();
        li_DonationDess = sqlLi_DonationDesProvider.GetAllLi_DonationDessWithBudget();
        return li_DonationDess;
    }
    public static Li_DonationDes GetLi_DonationDesByID(int id)
    {
        Li_DonationDes li_DonationDes = new Li_DonationDes();
        SqlLi_DonationDesProvider sqlLi_DonationDesProvider = new SqlLi_DonationDesProvider();
        li_DonationDes = sqlLi_DonationDesProvider.GetLi_DonationDesByID(id);
        return li_DonationDes;
    }


    public static int InsertLi_DonationDes(Li_DonationDes li_DonationDes)
    {
        SqlLi_DonationDesProvider sqlLi_DonationDesProvider = new SqlLi_DonationDesProvider();
        return sqlLi_DonationDesProvider.InsertLi_DonationDes(li_DonationDes);
    }


    public static bool UpdateLi_DonationDes(Li_DonationDes li_DonationDes)
    {
        SqlLi_DonationDesProvider sqlLi_DonationDesProvider = new SqlLi_DonationDesProvider();
        return sqlLi_DonationDesProvider.UpdateLi_DonationDes(li_DonationDes);
    }

    public static bool DeleteLi_DonationDes(int li_DonationDesID)
    {
        SqlLi_DonationDesProvider sqlLi_DonationDesProvider = new SqlLi_DonationDesProvider();
        return sqlLi_DonationDesProvider.DeleteLi_DonationDes(li_DonationDesID);
    }
}
