using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PressInfoManager
{
	public Li_PressInfoManager()
	{
	}

    public static List<Li_PressInfo> GetAllLi_PressInfos()
    {
        List<Li_PressInfo> li_PressInfos = new List<Li_PressInfo>();
        SqlLi_PressInfoProvider sqlLi_PressInfoProvider = new SqlLi_PressInfoProvider();
        li_PressInfos = sqlLi_PressInfoProvider.GetAllLi_PressInfos();
        return li_PressInfos;
    }


    public static Li_PressInfo GetLi_PressInfoByID(string  id)
    {
        Li_PressInfo li_PressInfo = new Li_PressInfo();
        SqlLi_PressInfoProvider sqlLi_PressInfoProvider = new SqlLi_PressInfoProvider();
        li_PressInfo = sqlLi_PressInfoProvider.GetLi_PressInfoByID(id);
        return li_PressInfo;
    }


    public static string  InsertLi_PressInfo(Li_PressInfo li_PressInfo)
    {
        SqlLi_PressInfoProvider sqlLi_PressInfoProvider = new SqlLi_PressInfoProvider();
        return sqlLi_PressInfoProvider.InsertLi_PressInfo(li_PressInfo);
    }


    public static bool UpdateLi_PressInfo(Li_PressInfo li_PressInfo)
    {
        SqlLi_PressInfoProvider sqlLi_PressInfoProvider = new SqlLi_PressInfoProvider();
        return sqlLi_PressInfoProvider.UpdateLi_PressInfo(li_PressInfo);
    }

    public static bool DeleteLi_PressInfo(int li_PressInfoID)
    {
        SqlLi_PressInfoProvider sqlLi_PressInfoProvider = new SqlLi_PressInfoProvider();
        return sqlLi_PressInfoProvider.DeleteLi_PressInfo(li_PressInfoID);
    }

    public static DataSet GetLi_PressPartyInfoByID(string id)
    {
        SqlLi_PressInfoProvider sqlLi_PressPartyInfoProvider = new SqlLi_PressInfoProvider();
        return sqlLi_PressPartyInfoProvider.GetLi_PressPartyInfoByID(id);

    }
}
