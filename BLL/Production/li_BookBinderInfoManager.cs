using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookBinderInfoManager
{
	public Li_BookBinderInfoManager()
	{
	}

    public static List<Li_BookBinderInfo> GetAllLi_BookBinderInfos()
    {
        List<Li_BookBinderInfo> li_BookBinderInfos = new List<Li_BookBinderInfo>();
        SqlLi_BookBinderInfoProvider sqlLi_BookBinderInfoProvider = new SqlLi_BookBinderInfoProvider();
        li_BookBinderInfos = sqlLi_BookBinderInfoProvider.GetAllLi_BookBinderInfos();
        return li_BookBinderInfos;
    }

    public static List<Li_BookBinderInfo> GetAllLi_BookBinderInfosForBill(string BookCode)
    {
        List<Li_BookBinderInfo> li_BookBinderInfos = new List<Li_BookBinderInfo>();
        SqlLi_BookBinderInfoProvider sqlLi_BookBinderInfoProvider = new SqlLi_BookBinderInfoProvider();
        li_BookBinderInfos = sqlLi_BookBinderInfoProvider.GetAllLi_BookBinderInfosForBill (BookCode);
        return li_BookBinderInfos;
    }

    public static Li_BookBinderInfo GetLi_BookBinderInfoByID(string  id)
    {
        Li_BookBinderInfo li_BookBinderInfo = new Li_BookBinderInfo();
        SqlLi_BookBinderInfoProvider sqlLi_BookBinderInfoProvider = new SqlLi_BookBinderInfoProvider();
        li_BookBinderInfo = sqlLi_BookBinderInfoProvider.GetLi_BookBinderInfoByID(id);
        return li_BookBinderInfo;
    }


    public static string  InsertLi_BookBinderInfo(Li_BookBinderInfo li_BookBinderInfo)
    {
        SqlLi_BookBinderInfoProvider sqlLi_BookBinderInfoProvider = new SqlLi_BookBinderInfoProvider();
        return sqlLi_BookBinderInfoProvider.InsertLi_BookBinderInfo(li_BookBinderInfo);
    }


    public static bool UpdateLi_BookBinderInfo(Li_BookBinderInfo li_BookBinderInfo)
    {
        SqlLi_BookBinderInfoProvider sqlLi_BookBinderInfoProvider = new SqlLi_BookBinderInfoProvider();
        return sqlLi_BookBinderInfoProvider.UpdateLi_BookBinderInfo(li_BookBinderInfo);
    }

    public static bool DeleteLi_BookBinderInfo(int li_BookBinderInfoID)
    {
        SqlLi_BookBinderInfoProvider sqlLi_BookBinderInfoProvider = new SqlLi_BookBinderInfoProvider();
        return sqlLi_BookBinderInfoProvider.DeleteLi_BookBinderInfo(li_BookBinderInfoID);
    }

    public static DataSet GetLi_BookBinderSupInfoByID(string id)
    {
        SqlLi_BookBinderInfoProvider sqlLi_BookBinderInfoProvider = new SqlLi_BookBinderInfoProvider();
        return sqlLi_BookBinderInfoProvider.GetAllLi_BookBinderSupInfosByID(id);

    }
}
