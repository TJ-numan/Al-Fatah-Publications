using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TeritoryManager
{
	public Li_TeritoryManager()
	{
	}

    public static List<Li_Teritory> GetAllLi_Teritories(string  ZonID)
    {
        List<Li_Teritory> li_Teritories = new List<Li_Teritory>();
        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        li_Teritories = sqlLi_TeritoryProvider.GetAllLi_Teritories( ZonID);
        return li_Teritories;
    }


    public static Li_Teritory GetLi_TeritoryByID( string  TeritoryCode)
    {
        Li_Teritory li_Teritory = new Li_Teritory();
        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        li_Teritory = sqlLi_TeritoryProvider.GetLi_TeritoryByID(TeritoryCode);
        return li_Teritory;
    }


    public static int InsertLi_Teritory(Li_Teritory li_Teritory)
    {
        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        return sqlLi_TeritoryProvider.InsertLi_Teritory(li_Teritory);
    }


    public static bool UpdateLi_Teritory(Li_Teritory li_Teritory)
    {
        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        return sqlLi_TeritoryProvider.UpdateLi_Teritory(li_Teritory);
    }

    public static bool DeleteLi_Teritory(int li_TeritoryID)
    {
        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        return sqlLi_TeritoryProvider.DeleteLi_Teritory(li_TeritoryID);
    }

    public static List<Li_Teritory> Get_TeritoryByZonID(int AreaID)
    {
        List<Li_Teritory> li_Areas = new List<Li_Teritory>();
        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        li_Areas =  sqlLi_TeritoryProvider.Get_TeritoryByZonID(AreaID);
        return li_Areas;
    }

    public static DataSet GetAll_TeritoriesWithRelation()
    {

        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        return sqlLi_TeritoryProvider.GetAll_TeritoriesWithRelation();

    }

    public static object GetAllLi_TeritoryByUserID(int UserID)
    {
        DataSet ds = new DataSet();
        SqlLi_TeritoryProvider Sql_li_TeritoryProvider = new SqlLi_TeritoryProvider();
        ds = Sql_li_TeritoryProvider.GetAllLi_TeritoryByUserID(UserID);
        return ds;
    }

    public static DataSet GetAll_TeritoriesWithTeritoryId(string TeritoryId)
    {

        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        return sqlLi_TeritoryProvider.GetAll_TeritoriesWithTeritoryId(TeritoryId);

    }


    public static DataSet GetAllLi_Teritories()
    {
        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        return sqlLi_TeritoryProvider.GetAllLi_Teritories();
    }

    public static DataSet GetAllLi_MadrashaByTeritoryCode(string TeeritoryCode)
    {
        SqlLi_TeritoryProvider sqlLi_TeritoryProvider = new SqlLi_TeritoryProvider();
        return sqlLi_TeritoryProvider.GetAllLi_MadrashaByTeritory(TeeritoryCode);
    }
}
