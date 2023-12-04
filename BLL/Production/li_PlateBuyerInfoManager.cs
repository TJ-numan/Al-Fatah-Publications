using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateBuyerInfoManager
{
	public Li_PlateBuyerInfoManager()
	{
	}

    public static List<Li_PlateBuyerInfo> GetAllLi_PlateBuyerInfos()
    {
        List<Li_PlateBuyerInfo> li_PlateBuyerInfos = new List<Li_PlateBuyerInfo>();
        SqlLi_PlateBuyerInfoProvider sqlLi_PlateBuyerInfoProvider = new SqlLi_PlateBuyerInfoProvider();
        li_PlateBuyerInfos = sqlLi_PlateBuyerInfoProvider.GetAllLi_PlateBuyerInfos();
        return li_PlateBuyerInfos;
    }


    public static Li_PlateBuyerInfo GetLi_PlateBuyerInfoByID(int id)
    {
        Li_PlateBuyerInfo li_PlateBuyerInfo = new Li_PlateBuyerInfo();
        SqlLi_PlateBuyerInfoProvider sqlLi_PlateBuyerInfoProvider = new SqlLi_PlateBuyerInfoProvider();
        li_PlateBuyerInfo = sqlLi_PlateBuyerInfoProvider.GetLi_PlateBuyerInfoByID(id);
        return li_PlateBuyerInfo;
    }


    public static string  InsertLi_PlateBuyerInfo(Li_PlateBuyerInfo li_PlateBuyerInfo)
    {
        SqlLi_PlateBuyerInfoProvider sqlLi_PlateBuyerInfoProvider = new SqlLi_PlateBuyerInfoProvider();
        return sqlLi_PlateBuyerInfoProvider.InsertLi_PlateBuyerInfo(li_PlateBuyerInfo);
    }


    public static bool UpdateLi_PlateBuyerInfo(Li_PlateBuyerInfo li_PlateBuyerInfo)
    {
        SqlLi_PlateBuyerInfoProvider sqlLi_PlateBuyerInfoProvider = new SqlLi_PlateBuyerInfoProvider();
        return sqlLi_PlateBuyerInfoProvider.UpdateLi_PlateBuyerInfo(li_PlateBuyerInfo);
    }

    public static bool DeleteLi_PlateBuyerInfo(int li_PlateBuyerInfoID)
    {
        SqlLi_PlateBuyerInfoProvider sqlLi_PlateBuyerInfoProvider = new SqlLi_PlateBuyerInfoProvider();
        return sqlLi_PlateBuyerInfoProvider.DeleteLi_PlateBuyerInfo(li_PlateBuyerInfoID);
    }
}
