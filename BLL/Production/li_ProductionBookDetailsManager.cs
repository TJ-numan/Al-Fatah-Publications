using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_ProductionBookDetailsManager
{
	public Li_ProductionBookDetailsManager()
	{
	}

    public static List<Li_ProductionBookDetails> GetAllLi_ProductionBookDetailss()
    {
        List<Li_ProductionBookDetails> li_ProductionBookDetailss = new List<Li_ProductionBookDetails>();
        SqlLi_ProductionBookDetailsProvider sqlLi_ProductionBookDetailsProvider = new SqlLi_ProductionBookDetailsProvider();
        li_ProductionBookDetailss = sqlLi_ProductionBookDetailsProvider.GetAllLi_ProductionBookDetailss();
        return li_ProductionBookDetailss;
    }


    public static Li_ProductionBookDetails GetLi_ProductionBookDetailsByID(int id)
    {
        Li_ProductionBookDetails li_ProductionBookDetails = new Li_ProductionBookDetails();
        SqlLi_ProductionBookDetailsProvider sqlLi_ProductionBookDetailsProvider = new SqlLi_ProductionBookDetailsProvider();
        li_ProductionBookDetails = sqlLi_ProductionBookDetailsProvider.GetLi_ProductionBookDetailsByID(id);
        return li_ProductionBookDetails;
    }


    public static int InsertLi_ProductionBookDetails(Li_ProductionBookDetails li_ProductionBookDetails)
    {
        SqlLi_ProductionBookDetailsProvider sqlLi_ProductionBookDetailsProvider = new SqlLi_ProductionBookDetailsProvider();
        return sqlLi_ProductionBookDetailsProvider.InsertLi_ProductionBookDetails(li_ProductionBookDetails);
    }


    public static bool UpdateLi_ProductionBookDetails(Li_ProductionBookDetails li_ProductionBookDetails)
    {
        SqlLi_ProductionBookDetailsProvider sqlLi_ProductionBookDetailsProvider = new SqlLi_ProductionBookDetailsProvider();
        return sqlLi_ProductionBookDetailsProvider.UpdateLi_ProductionBookDetails(li_ProductionBookDetails);
    }

    public static bool DeleteLi_ProductionBookDetails(int li_ProductionBookDetailsID)
    {
        SqlLi_ProductionBookDetailsProvider sqlLi_ProductionBookDetailsProvider = new SqlLi_ProductionBookDetailsProvider();
        return sqlLi_ProductionBookDetailsProvider.DeleteLi_ProductionBookDetails(li_ProductionBookDetailsID);
    }

   
}
