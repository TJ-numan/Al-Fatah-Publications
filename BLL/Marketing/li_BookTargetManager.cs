using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookTargetManager
{
	public Li_BookTargetManager()
	{
	}

    public static List<Li_BookTarget> GetAllLi_BookTargets()
    {
        List<Li_BookTarget> li_BookTargets = new List<Li_BookTarget>();
        SqlLi_BookTargetProvider sqlLi_BookTargetProvider = new SqlLi_BookTargetProvider();
        li_BookTargets = sqlLi_BookTargetProvider.GetAllLi_BookTargets();
        return li_BookTargets;
    }


    public static Li_BookTarget GetLi_BookTargetByID(int id)
    {
        Li_BookTarget li_BookTarget = new Li_BookTarget();
        SqlLi_BookTargetProvider sqlLi_BookTargetProvider = new SqlLi_BookTargetProvider();
        li_BookTarget = sqlLi_BookTargetProvider.GetLi_BookTargetByID(id);
        return li_BookTarget;
    }


    public static int InsertLi_BookTarget(Li_BookTarget li_BookTarget)
    {
        SqlLi_BookTargetProvider sqlLi_BookTargetProvider = new SqlLi_BookTargetProvider();
        return sqlLi_BookTargetProvider.InsertLi_BookTarget(li_BookTarget);
    }


    public static bool UpdateLi_BookTarget(Li_BookTarget li_BookTarget)
    {
        SqlLi_BookTargetProvider sqlLi_BookTargetProvider = new SqlLi_BookTargetProvider();
        return sqlLi_BookTargetProvider.UpdateLi_BookTarget(li_BookTarget);
    }

    public static bool DeleteLi_BookTarget(int li_BookTargetID)
    {
        SqlLi_BookTargetProvider sqlLi_BookTargetProvider = new SqlLi_BookTargetProvider();
        return sqlLi_BookTargetProvider.DeleteLi_BookTarget(li_BookTargetID);
    }


    public static DataSet GetBookTergetQty(string TerritoryCode, string BookCode, string Edition)
    {
        DataSet ds = new DataSet();
        SqlLi_BookTargetProvider sqlLi_BookTargetProvider = new SqlLi_BookTargetProvider();
        ds =  sqlLi_BookTargetProvider.GetBookTergetQty(  TerritoryCode,   BookCode,   Edition) ;
        return ds;
    }

    public static DataSet GetSalesTargetBase( )
    {
        DataSet ds = new DataSet();
        SqlLi_BookTargetProvider sqlLi_BookTargetProvider = new SqlLi_BookTargetProvider();
        ds = sqlLi_BookTargetProvider.GetSalesTarget();
        return ds;
    }

}
