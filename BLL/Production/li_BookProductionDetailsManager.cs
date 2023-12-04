using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookProductionDetailsManager
{
	public Li_BookProductionDetailsManager()
	{
	}

    public static List<Li_BookProductionDetails> GetAllLi_BookProductionDetailss()
    {
        List<Li_BookProductionDetails> li_BookProductionDetailss = new List<Li_BookProductionDetails>();
        SqlLi_BookProductionDetailsProvider sqlLi_BookProductionDetailsProvider = new SqlLi_BookProductionDetailsProvider();
        li_BookProductionDetailss = sqlLi_BookProductionDetailsProvider.GetAllLi_BookProductionDetailss();
        return li_BookProductionDetailss;
    }


    public static Li_BookProductionDetails GetLi_BookProductionDetailsByID(int id)
    {
        Li_BookProductionDetails li_BookProductionDetails = new Li_BookProductionDetails();
        SqlLi_BookProductionDetailsProvider sqlLi_BookProductionDetailsProvider = new SqlLi_BookProductionDetailsProvider();
        li_BookProductionDetails = sqlLi_BookProductionDetailsProvider.GetLi_BookProductionDetailsByID(id);
        return li_BookProductionDetails;
    }


    public static int InsertLi_BookProductionDetails(Li_BookProductionDetails li_BookProductionDetails)
    {
        SqlLi_BookProductionDetailsProvider sqlLi_BookProductionDetailsProvider = new SqlLi_BookProductionDetailsProvider();
        return sqlLi_BookProductionDetailsProvider.InsertLi_BookProductionDetails(li_BookProductionDetails);
    }


    public static bool UpdateLi_BookProductionDetails(Li_BookProductionDetails li_BookProductionDetails)
    {
        SqlLi_BookProductionDetailsProvider sqlLi_BookProductionDetailsProvider = new SqlLi_BookProductionDetailsProvider();
        return sqlLi_BookProductionDetailsProvider.UpdateLi_BookProductionDetails(li_BookProductionDetails);
    }

    public static bool DeleteLi_BookProductionDetails(int li_BookProductionDetailsID)
    {
        SqlLi_BookProductionDetailsProvider sqlLi_BookProductionDetailsProvider = new SqlLi_BookProductionDetailsProvider();
        return sqlLi_BookProductionDetailsProvider.DeleteLi_BookProductionDetails(li_BookProductionDetailsID);
    }

    public static DataSet GetProductionDetailInfoByBookCode(string BookCode)
    {
        DataSet ds = new DataSet();
        SqlLi_BookProductionDetailsProvider sqlLi_BookProductionDetailsProvider = new SqlLi_BookProductionDetailsProvider();
        ds = sqlLi_BookProductionDetailsProvider.GetProductionDetailInfoByBookCode(  BookCode) ;
        return ds;
    }
}
