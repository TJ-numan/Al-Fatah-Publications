using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using Common.Marketing; 


public class Li_MadrasahInfoManager
{
	public Li_MadrasahInfoManager()
	{
	}

    public static List<Li_MadrasahInfo> GetAllLi_MadrasahInfos()
    {
        List<Li_MadrasahInfo> li_MadrasahInfos = new List<Li_MadrasahInfo>();
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        li_MadrasahInfos = sqlLi_MadrasahInfoProvider.GetAllLi_MadrasahInfos();
        return li_MadrasahInfos;
    }


    public static Li_MadrasahInfo GetLi_MadrasahInfoByID(int id)
    {
        Li_MadrasahInfo li_MadrasahInfo = new Li_MadrasahInfo();
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        li_MadrasahInfo = sqlLi_MadrasahInfoProvider.GetLi_MadrasahInfoByID(id);
        return li_MadrasahInfo;
    }


    public static string InsertLi_MadrasahInfo(Li_MadrasahInfo li_MadrasahInfo)
    {
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        return sqlLi_MadrasahInfoProvider.InsertLi_MadrasahInfo(li_MadrasahInfo);
    }


    public static bool UpdateLi_MadrasahInfo(Li_MadrasahInfo li_MadrasahInfo)
    {
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        return sqlLi_MadrasahInfoProvider.UpdateLi_MadrasahInfo(li_MadrasahInfo);
    }

    public static bool DeleteLi_MadrasahInfo(int li_MadrasahInfoID)
    {
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        return sqlLi_MadrasahInfoProvider.DeleteLi_MadrasahInfo(li_MadrasahInfoID);
    }

    public static DataSet GetLi_MadrasahInfoBy_AgrNo(string AgrNo, string AgYear)
    { 
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        return sqlLi_MadrasahInfoProvider.GetLi_MadrasahInfoBy_AgrNo(AgrNo,AgYear);        
    }
    //------------------------------Rezaul 2021----------------------------------------------------------------------
    public static DataSet GetAllLi_MadrasahInfoForTeacherInfo()
    {
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        return sqlLi_MadrasahInfoProvider.GetAllLi_MadrasahInfoForTeacherInfo();
    }
    public static DataSet GetTeacherInformationByMadrasahAndterritory(string TerID, string MadID, string ClassID, string BookID)
    {
        DataSet ds = new DataSet();
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        ds = sqlLi_MadrasahInfoProvider.GetTeacherInformationByMadrasahAndterritory(TerID, MadID, ClassID, BookID);
        return ds;
    }

    public static int InsertLi_MadrasahInfoAdvanced(Li_MadrasahInfoAdvanced li_MadrasahInfo)
    {
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        return sqlLi_MadrasahInfoProvider.InsertLi_MadrasahInfoAdvanced(li_MadrasahInfo);
    }

    public static int UpdateLi_MadrasahInfoAdvanced(Li_MadrasahInfoAdvanced li_MadrasahInfo)
    {
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        return sqlLi_MadrasahInfoProvider.UpdateLi_MadrasahInfoAdvanced(li_MadrasahInfo);
    }
    public static DataSet GetLi_MadrasahEIIN_ForExistingEIIN( string eiin)
    {
        DataSet ds = new DataSet();
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        ds = sqlLi_MadrasahInfoProvider.GetLi_MadrasahEIIN_ForExistingEIIN(eiin);
        return ds;
    }

    public static DataSet GetLi_MadrasahInfo_ForExistingEIIN_ForUpdate(string eiin)
    {
        DataSet ds = new DataSet();
        SqlLi_MadrasahInfoProvider sqlLi_MadrasahInfoProvider = new SqlLi_MadrasahInfoProvider();
        ds = sqlLi_MadrasahInfoProvider.GetLi_MadrasahInfo_ForExistingEIIN_ForUpdate(eiin);
        return ds;
    }

}
