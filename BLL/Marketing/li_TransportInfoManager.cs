using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TransportInfoManager
{
	public Li_TransportInfoManager()
	{
	}

    public static List<Li_TransportInfo> GetAllLi_TransportInfos()
    {
        List<Li_TransportInfo> li_TransportInfos = new List<Li_TransportInfo>();
        SqlLi_TransportInfoProvider sqlLi_TransportInfoProvider = new SqlLi_TransportInfoProvider();
        li_TransportInfos = sqlLi_TransportInfoProvider.GetAllLi_TransportInfos();
        return li_TransportInfos;
    }


    public static Li_TransportInfo GetLi_TransportInfoByID(int id)
    {
        Li_TransportInfo li_TransportInfo = new Li_TransportInfo();
        SqlLi_TransportInfoProvider sqlLi_TransportInfoProvider = new SqlLi_TransportInfoProvider();
        li_TransportInfo = sqlLi_TransportInfoProvider.GetLi_TransportInfoByID(id);
        return li_TransportInfo;
    }


    public static string  InsertLi_TransportInfo(Li_TransportInfo li_TransportInfo)
    {
        SqlLi_TransportInfoProvider sqlLi_TransportInfoProvider = new SqlLi_TransportInfoProvider();
        return sqlLi_TransportInfoProvider.InsertLi_TransportInfo(li_TransportInfo);
    }


    public static bool UpdateLi_TransportInfo(Li_TransportInfo li_TransportInfo)
    {
        SqlLi_TransportInfoProvider sqlLi_TransportInfoProvider = new SqlLi_TransportInfoProvider();
        return sqlLi_TransportInfoProvider.UpdateLi_TransportInfo(li_TransportInfo);
    }

    public static bool DeleteLi_TransportInfo(int li_TransportInfoID)
    {
        SqlLi_TransportInfoProvider sqlLi_TransportInfoProvider = new SqlLi_TransportInfoProvider();
        return sqlLi_TransportInfoProvider.DeleteLi_TransportInfo(li_TransportInfoID);
    }
}
