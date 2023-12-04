using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 
public class Li_TeacherInfoManager
{
	public Li_TeacherInfoManager()
	{
	}

    public static List<Li_TeacherInfo> GetAllLi_TeacherInfos()
    {
        List<Li_TeacherInfo> li_TeacherInfos = new List<Li_TeacherInfo>();
        SqlLi_TeacherInfoProvider sqlLi_TeacherInfoProvider = new SqlLi_TeacherInfoProvider();
        li_TeacherInfos = sqlLi_TeacherInfoProvider.GetAllLi_TeacherInfos();
        return li_TeacherInfos;
    }


    public static Li_TeacherInfo GetLi_TeacherInfoByID(int id)
    {
        Li_TeacherInfo li_TeacherInfo = new Li_TeacherInfo();
        SqlLi_TeacherInfoProvider sqlLi_TeacherInfoProvider = new SqlLi_TeacherInfoProvider();
        li_TeacherInfo = sqlLi_TeacherInfoProvider.GetLi_TeacherInfoByID(id);
        return li_TeacherInfo;
    }


    public static int InsertLi_TeacherInfo(Li_TeacherInfo li_TeacherInfo)
    {
        SqlLi_TeacherInfoProvider sqlLi_TeacherInfoProvider = new SqlLi_TeacherInfoProvider();
        return sqlLi_TeacherInfoProvider.InsertLi_TeacherInfo(li_TeacherInfo);
    }


    public static bool UpdateLi_TeacherInfo(Li_TeacherInfo li_TeacherInfo)
    {
        SqlLi_TeacherInfoProvider sqlLi_TeacherInfoProvider = new SqlLi_TeacherInfoProvider();
        return sqlLi_TeacherInfoProvider.UpdateLi_TeacherInfo(li_TeacherInfo);
    }

    public static bool DeleteLi_TeacherInfo(int li_TeacherInfoID)
    {
        SqlLi_TeacherInfoProvider sqlLi_TeacherInfoProvider = new SqlLi_TeacherInfoProvider();
        return sqlLi_TeacherInfoProvider.DeleteLi_TeacherInfo(li_TeacherInfoID);
    }
    public static string InsertLi_QawmiTeacherInfoByMad(Li_TeacherInfo li_QawmiTeacherInfo)
    {
        SqlLi_TeacherInfoProvider sqlLi_TeacherInfoProvider = new SqlLi_TeacherInfoProvider();
        return sqlLi_TeacherInfoProvider.InsertLi_QawmiTeacherInfoByMad(li_QawmiTeacherInfo);
    }
    public static int InsertLi_QawmiTeacherInfoByMadDetails(Li_TeacherInfo li_QawmiTeacherInfoDetails)
    {
        SqlLi_TeacherInfoProvider sqlLi_TeacherInfoProvider = new SqlLi_TeacherInfoProvider();
        return sqlLi_TeacherInfoProvider.InsertLi_QawmiTeacherInfoByMadDetails(li_QawmiTeacherInfoDetails);
    }

}
