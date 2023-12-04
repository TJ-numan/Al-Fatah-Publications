using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlateProcessManager
{
	public Li_PlateProcessManager()
	{
	}

    public static List<Li_PlateProcess> GetAllLi_PlateProcesss()
    {
        List<Li_PlateProcess> li_PlateProcesss = new List<Li_PlateProcess>();
        SqlLi_PlateProcessProvider sqlLi_PlateProcessProvider = new SqlLi_PlateProcessProvider();
        li_PlateProcesss = sqlLi_PlateProcessProvider.GetAllLi_PlateProcesss();
        return li_PlateProcesss;
    }


    public static Li_PlateProcess GetLi_PlateProcessByID(int id)
    {
        Li_PlateProcess li_PlateProcess = new Li_PlateProcess();
        SqlLi_PlateProcessProvider sqlLi_PlateProcessProvider = new SqlLi_PlateProcessProvider();
        li_PlateProcess = sqlLi_PlateProcessProvider.GetLi_PlateProcessByID(id);
        return li_PlateProcess;
    }


    public static string  InsertLi_PlateProcess(Li_PlateProcess li_PlateProcess)
    {
        SqlLi_PlateProcessProvider sqlLi_PlateProcessProvider = new SqlLi_PlateProcessProvider();
        return sqlLi_PlateProcessProvider.InsertLi_PlateProcess(li_PlateProcess);
    }


    public static bool UpdateLi_PlateProcess(Li_PlateProcess li_PlateProcess)
    {
        SqlLi_PlateProcessProvider sqlLi_PlateProcessProvider = new SqlLi_PlateProcessProvider();
        return sqlLi_PlateProcessProvider.UpdateLi_PlateProcess(li_PlateProcess);
    }

    public static bool DeleteLi_PlateProcess(int li_PlateProcessID)
    {
        SqlLi_PlateProcessProvider sqlLi_PlateProcessProvider = new SqlLi_PlateProcessProvider();
        return sqlLi_PlateProcessProvider.DeleteLi_PlateProcess(li_PlateProcessID);
    }


    public static DataSet Get_PlatePurchaseOrderByReceiveID(string ReceiveID, string fromDate, string toDate)
    {
        DataSet ds = new DataSet();
        SqlLi_PlateProcessProvider sqlLi_PlateProcessProvider = new SqlLi_PlateProcessProvider();
        ds = sqlLi_PlateProcessProvider.Get_PlatePurchaseOrderByReceiveID(ReceiveID, fromDate, toDate);
        return ds;
    }

    public static DataSet GetProcessOrderInforByDistinctPress(string OrderNo)
    {
        SqlLi_PlateProcessProvider sqlLi_PlateProcessProvider = new SqlLi_PlateProcessProvider();
        return sqlLi_PlateProcessProvider.GetProcessOrderInforByDistinctPress(OrderNo);

    }

    public static DataSet getGodownPlateQty(string fromDate, string toDate)
    {
        SqlLi_PlateProcessProvider sqlLi_PlateProcessProvider = new SqlLi_PlateProcessProvider();
        return sqlLi_PlateProcessProvider.getGodownPlateQty(fromDate, toDate);

    }
}
