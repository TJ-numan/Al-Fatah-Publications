using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookPricingManager
{
	public Li_BookPricingManager()
	{
	}

    public static List<Li_BookPricing> GetAllLi_BookPricings()
    {
        List<Li_BookPricing> li_BookPricings = new List<Li_BookPricing>();
        SqlLi_BookPricingProvider sqlLi_BookPricingProvider = new SqlLi_BookPricingProvider();
        li_BookPricings = sqlLi_BookPricingProvider.GetAllLi_BookPricings();
        return li_BookPricings;
    }


    public static Li_BookPricing GetLi_BookPricingByID(int id)
    {
        Li_BookPricing li_BookPricing = new Li_BookPricing();
        SqlLi_BookPricingProvider sqlLi_BookPricingProvider = new SqlLi_BookPricingProvider();
        li_BookPricing = sqlLi_BookPricingProvider.GetLi_BookPricingByID(id);
        return li_BookPricing;
    }


    public static int InsertLi_BookPricing(Li_BookPricing li_BookPricing)
    {
        SqlLi_BookPricingProvider sqlLi_BookPricingProvider = new SqlLi_BookPricingProvider();
        return sqlLi_BookPricingProvider.InsertLi_BookPricing(li_BookPricing);
    }


    public static bool UpdateLi_BookPricing(Li_BookPricing li_BookPricing)
    {
        SqlLi_BookPricingProvider sqlLi_BookPricingProvider = new SqlLi_BookPricingProvider();
        return sqlLi_BookPricingProvider.UpdateLi_BookPricing(li_BookPricing);
    }

    public static bool DeleteLi_BookPricing(int li_BookPricingID)
    {
        SqlLi_BookPricingProvider sqlLi_BookPricingProvider = new SqlLi_BookPricingProvider();
        return sqlLi_BookPricingProvider.DeleteLi_BookPricing(li_BookPricingID);
    }
}
