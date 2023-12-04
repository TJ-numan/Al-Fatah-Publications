using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_RnDWorkDetailsManager
{
	public Li_RnDWorkDetailsManager()
	{
	}

    public static List<Li_RnDWorkDetails> GetAllLi_RnDWorkDetailss()
    {
        List<Li_RnDWorkDetails> li_RnDWorkDetailss = new List<Li_RnDWorkDetails>();
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        li_RnDWorkDetailss = sqlLi_RnDWorkDetailsProvider.GetAllLi_RnDWorkDetailss();
        return li_RnDWorkDetailss;
    }


    public static Li_RnDWorkDetails GetLi_RnDWorkDetailsByID(int id)
    {
        Li_RnDWorkDetails li_RnDWorkDetails = new Li_RnDWorkDetails();
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        li_RnDWorkDetails = sqlLi_RnDWorkDetailsProvider.GetLi_RnDWorkDetailsByID(id);
        return li_RnDWorkDetails;
    }


    public static int InsertLi_RnDWorkDetails(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.InsertLi_RnDWorkDetails(li_RnDWorkDetails);
    }


    public static bool UpdateLi_RnDWorkDetails(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.UpdateLi_RnDWorkDetails(li_RnDWorkDetails);
    }

    public static bool DeleteLi_RnDWorkDetails(int li_RnDWorkDetailsID)
    {
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.DeleteLi_RnDWorkDetails(li_RnDWorkDetailsID);
    }

    public static DataSet Get_DateWiseRnDWorkDetails(string fromDate, string toDate, string employeeID)
    {
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.Get_DateWiseRnDWorkDetails(fromDate, toDate, employeeID);

    }
    public static DataSet GetLi_RnDWorkDetailsByWorkID(int WorkDetailID)
    {
        Li_RnDWorkDetails li_RnDWorkDetails = new Li_RnDWorkDetails();
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.GetLi_RnDWorkDetailsByWorkID(WorkDetailID);
    }
    //--------------------------------------------rezaul Hossain------------------2021-06-01-----------
    public static int InsertLi_RnDWorkDetailsQawmi(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.InsertLi_RnDWorkDetailsQawmi(li_RnDWorkDetails);
    }
    public static DataSet Get_DateWiseRnDWorkDetailsQawmi(string fromDate, string toDate, string employeeID)
    {
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.Get_DateWiseRnDWorkDetailsQawmi(fromDate, toDate, employeeID);

    }
    public static DataSet GetLi_RnDWorkDetailsByWorkIDQawmi(int WorkDetailID)
    {
        Li_RnDWorkDetails li_RnDWorkDetails = new Li_RnDWorkDetails();
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.GetLi_RnDWorkDetailsByWorkIDQawmi(WorkDetailID);
    }
    public static bool UpdateLi_RnDWorkDetailsQawmi(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.UpdateLi_RnDWorkDetailsQawmi(li_RnDWorkDetails);
    }
    public static int Delete_Li_RnDWorkDetails(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.Delete_Li_RnDWorkDetails(li_RnDWorkDetails);
    }
    public static int Delete_Li_RnDWorkDetailsQawmi(Li_RnDWorkDetails li_RnDWorkDetails)
    {
        SqlLi_RnDWorkDetailsProvider sqlLi_RnDWorkDetailsProvider = new SqlLi_RnDWorkDetailsProvider();
        return sqlLi_RnDWorkDetailsProvider.Delete_Li_RnDWorkDetailsQawmi(li_RnDWorkDetails);
    }
}
