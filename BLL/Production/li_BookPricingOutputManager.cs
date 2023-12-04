using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookPricingOutputManager
{
	public Li_BookPricingOutputManager()
	{
	}

    public static List<Li_BookPricingOutput> GetAllLi_BookPricingOutputs()
    {
        List<Li_BookPricingOutput> li_BookPricingOutputs = new List<Li_BookPricingOutput>();
        SqlLi_BookPricingOutputProvider sqlLi_BookPricingOutputProvider = new SqlLi_BookPricingOutputProvider();
        li_BookPricingOutputs = sqlLi_BookPricingOutputProvider.GetAllLi_BookPricingOutputs();
        return li_BookPricingOutputs;
    }


    public static Li_BookPricingOutput GetLi_BookPricingOutputByID(string  id)
    {
        Li_BookPricingOutput li_BookPricingOutput = new Li_BookPricingOutput();
        SqlLi_BookPricingOutputProvider sqlLi_BookPricingOutputProvider = new SqlLi_BookPricingOutputProvider();
        li_BookPricingOutput = sqlLi_BookPricingOutputProvider.GetLi_BookPricingOutputByID(id);
        return li_BookPricingOutput;
    }


    public static int InsertLi_BookPricingOutput(Li_BookPricingOutput li_BookPricingOutput)
    {
        SqlLi_BookPricingOutputProvider sqlLi_BookPricingOutputProvider = new SqlLi_BookPricingOutputProvider();
        return sqlLi_BookPricingOutputProvider.InsertLi_BookPricingOutput(li_BookPricingOutput);
    }


    public static bool UpdateLi_BookPricingOutput(Li_BookPricingOutput li_BookPricingOutput)
    {
        SqlLi_BookPricingOutputProvider sqlLi_BookPricingOutputProvider = new SqlLi_BookPricingOutputProvider();
        return sqlLi_BookPricingOutputProvider.UpdateLi_BookPricingOutput(li_BookPricingOutput);
    }

    public static bool DeleteLi_BookPricingOutput(int li_BookPricingOutputID)
    {
        SqlLi_BookPricingOutputProvider sqlLi_BookPricingOutputProvider = new SqlLi_BookPricingOutputProvider();
        return sqlLi_BookPricingOutputProvider.DeleteLi_BookPricingOutput(li_BookPricingOutputID);
    }
}
