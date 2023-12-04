using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LeminatioPartyInfoManager
{
	public Li_LeminatioPartyInfoManager()
	{
	}

    public static List<Li_LeminatioPartyInfo> GetAllLi_LeminatioPartyInfos()
    {
        List<Li_LeminatioPartyInfo> li_LeminatioPartyInfos = new List<Li_LeminatioPartyInfo>();
        SqlLi_LeminatioPartyInfoProvider sqlLi_LeminatioPartyInfoProvider = new SqlLi_LeminatioPartyInfoProvider();
        li_LeminatioPartyInfos = sqlLi_LeminatioPartyInfoProvider.GetAllLi_LeminatioPartyInfos();
        return li_LeminatioPartyInfos;
    }


    public static Li_LeminatioPartyInfo GetLi_LeminatioPartyInfoByID(int id)
    {
        Li_LeminatioPartyInfo li_LeminatioPartyInfo = new Li_LeminatioPartyInfo();
        SqlLi_LeminatioPartyInfoProvider sqlLi_LeminatioPartyInfoProvider = new SqlLi_LeminatioPartyInfoProvider();
        li_LeminatioPartyInfo = sqlLi_LeminatioPartyInfoProvider.GetLi_LeminatioPartyInfoByID(id);
        return li_LeminatioPartyInfo;
    }


    public static string  InsertLi_LeminatioPartyInfo(Li_LeminatioPartyInfo li_LeminatioPartyInfo)
    {
        SqlLi_LeminatioPartyInfoProvider sqlLi_LeminatioPartyInfoProvider = new SqlLi_LeminatioPartyInfoProvider();
        return sqlLi_LeminatioPartyInfoProvider.InsertLi_LeminatioPartyInfo(li_LeminatioPartyInfo);
    }


    public static bool UpdateLi_LeminatioPartyInfo(Li_LeminatioPartyInfo li_LeminatioPartyInfo)
    {
        SqlLi_LeminatioPartyInfoProvider sqlLi_LeminatioPartyInfoProvider = new SqlLi_LeminatioPartyInfoProvider();
        return sqlLi_LeminatioPartyInfoProvider.UpdateLi_LeminatioPartyInfo(li_LeminatioPartyInfo);
    }

    public static bool DeleteLi_LeminatioPartyInfo(int li_LeminatioPartyInfoID)
    {
        SqlLi_LeminatioPartyInfoProvider sqlLi_LeminatioPartyInfoProvider = new SqlLi_LeminatioPartyInfoProvider();
        return sqlLi_LeminatioPartyInfoProvider.DeleteLi_LeminatioPartyInfo(li_LeminatioPartyInfoID);
    }

    public static DataSet GetLi_LeminatioPartyInfosByID(string id)
    {
        SqlLi_LeminatioPartyInfoProvider sqlLi_LeminatioPartyInfoProvider = new SqlLi_LeminatioPartyInfoProvider();
        return sqlLi_LeminatioPartyInfoProvider.GetAllLi_LeminatioPartyInfosByID(id);

    }
}
