using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PestingPartyInfoManager
{
	public Li_PestingPartyInfoManager()
	{
	}

    public static List<Li_PestingPartyInfo> GetAllLi_PestingPartyInfos()
    {
        List<Li_PestingPartyInfo> li_PestingPartyInfos = new List<Li_PestingPartyInfo>();
        SqlLi_PestingPartyInfoProvider sqlLi_PestingPartyInfoProvider = new SqlLi_PestingPartyInfoProvider();
        li_PestingPartyInfos = sqlLi_PestingPartyInfoProvider.GetAllLi_PestingPartyInfos();
        return li_PestingPartyInfos;
    }


    public static DataSet GetLi_PestingPartyInfoByID(string id)
    {
        SqlLi_PestingPartyInfoProvider sqlLi_PestingPartyInfoProvider = new SqlLi_PestingPartyInfoProvider();
        return sqlLi_PestingPartyInfoProvider.GetLi_PestingPartyInfoByID(id);
        
    }


    public static string  InsertLi_PestingPartyInfo(Li_PestingPartyInfo li_PestingPartyInfo)
    {
        SqlLi_PestingPartyInfoProvider sqlLi_PestingPartyInfoProvider = new SqlLi_PestingPartyInfoProvider();
        return sqlLi_PestingPartyInfoProvider.InsertLi_PestingPartyInfo(li_PestingPartyInfo);
    }


    public static bool UpdateLi_PestingPartyInfo(Li_PestingPartyInfo li_PestingPartyInfo)
    {
        SqlLi_PestingPartyInfoProvider sqlLi_PestingPartyInfoProvider = new SqlLi_PestingPartyInfoProvider();
        return sqlLi_PestingPartyInfoProvider.UpdateLi_PestingPartyInfo(li_PestingPartyInfo);
    }

    public static bool DeleteLi_PestingPartyInfo(int li_PestingPartyInfoID)
    {
        SqlLi_PestingPartyInfoProvider sqlLi_PestingPartyInfoProvider = new SqlLi_PestingPartyInfoProvider();
        return sqlLi_PestingPartyInfoProvider.DeleteLi_PestingPartyInfo(li_PestingPartyInfoID);
    }
}
