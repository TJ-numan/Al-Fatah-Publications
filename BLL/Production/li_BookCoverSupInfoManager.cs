using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookCoverSupInfoManager
{
	public Li_BookCoverSupInfoManager()
	{
	}

    public static List<Li_BookCoverSupInfo> GetAllLi_BookCoverSupInfos()
    {
        List<Li_BookCoverSupInfo> li_BookCoverSupInfos = new List<Li_BookCoverSupInfo>();
        SqlLi_BookCoverSupInfoProvider sqlLi_BookCoverSupInfoProvider = new SqlLi_BookCoverSupInfoProvider();
        li_BookCoverSupInfos = sqlLi_BookCoverSupInfoProvider.GetAllLi_BookCoverSupInfos();
        return li_BookCoverSupInfos;
    }


    public static Li_BookCoverSupInfo GetLi_BookCoverSupInfoByID(int id)
    {
        Li_BookCoverSupInfo li_BookCoverSupInfo = new Li_BookCoverSupInfo();
        SqlLi_BookCoverSupInfoProvider sqlLi_BookCoverSupInfoProvider = new SqlLi_BookCoverSupInfoProvider();
        li_BookCoverSupInfo = sqlLi_BookCoverSupInfoProvider.GetLi_BookCoverSupInfoByID(id);
        return li_BookCoverSupInfo;
    }


    public static string  InsertLi_BookCoverSupInfo(Li_BookCoverSupInfo li_BookCoverSupInfo)
    {
        SqlLi_BookCoverSupInfoProvider sqlLi_BookCoverSupInfoProvider = new SqlLi_BookCoverSupInfoProvider();
        return sqlLi_BookCoverSupInfoProvider.InsertLi_BookCoverSupInfo(li_BookCoverSupInfo);
    }


    public static bool UpdateLi_BookCoverSupInfo(Li_BookCoverSupInfo li_BookCoverSupInfo)
    {
        SqlLi_BookCoverSupInfoProvider sqlLi_BookCoverSupInfoProvider = new SqlLi_BookCoverSupInfoProvider();
        return sqlLi_BookCoverSupInfoProvider.UpdateLi_BookCoverSupInfo(li_BookCoverSupInfo);
    }

    public static bool DeleteLi_BookCoverSupInfo(int li_BookCoverSupInfoID)
    {
        SqlLi_BookCoverSupInfoProvider sqlLi_BookCoverSupInfoProvider = new SqlLi_BookCoverSupInfoProvider();
        return sqlLi_BookCoverSupInfoProvider.DeleteLi_BookCoverSupInfo(li_BookCoverSupInfoID);
    }

    public static DataSet GetLi_BookCoverSupInfoByID(string id)
    {
        SqlLi_BookCoverSupInfoProvider sqlLi_BookCoverInfoProvider = new SqlLi_BookCoverSupInfoProvider();
        return sqlLi_BookCoverInfoProvider.GetAllLi_BookCoverSupInfosByID(id);

    }
}
