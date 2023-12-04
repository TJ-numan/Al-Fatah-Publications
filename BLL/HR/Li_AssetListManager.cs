using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetListManager
{
	public Li_AssetListManager()
	{
	}

    public static List<Li_AssetList> GetAllLi_AssetLists()
    {
        List<Li_AssetList> li_AssetLists = new List<Li_AssetList>();
        SqlLi_AssetListProvider sqlLi_AssetListProvider = new SqlLi_AssetListProvider();
        li_AssetLists = sqlLi_AssetListProvider.GetAllLi_AssetLists();
        return li_AssetLists;
    }


    public static Li_AssetList GetLi_AssetListByID(int id)
    {
        Li_AssetList li_AssetList = new Li_AssetList();
        SqlLi_AssetListProvider sqlLi_AssetListProvider = new SqlLi_AssetListProvider();
        li_AssetList = sqlLi_AssetListProvider.GetLi_AssetListByID(id);
        return li_AssetList;
    }


    public static string InsertLi_AssetList(Li_AssetList li_AssetList)
    {
        SqlLi_AssetListProvider sqlLi_AssetListProvider = new SqlLi_AssetListProvider();
        return sqlLi_AssetListProvider.InsertLi_AssetList(li_AssetList);
    }


    public static bool UpdateLi_AssetList(Li_AssetList li_AssetList)
    {
        SqlLi_AssetListProvider sqlLi_AssetListProvider = new SqlLi_AssetListProvider();
        return sqlLi_AssetListProvider.UpdateLi_AssetList(li_AssetList);
    }

    public static bool DeleteLi_AssetList(int li_AssetListID)
    {
        SqlLi_AssetListProvider sqlLi_AssetListProvider = new SqlLi_AssetListProvider();
        return sqlLi_AssetListProvider.DeleteLi_AssetList(li_AssetListID);
    }
    public static DataTable    LoadGvAssetList()
    {
         DataTable dt = new DataTable();
         SqlLi_AssetListProvider sqlLi_AssetListProvider = new SqlLi_AssetListProvider();
         dt= sqlLi_AssetListProvider. LoadGvAssetList();
         return dt;
    }
    public static DataTable GetAllLi_AssetList_Load()
    {
         DataTable dt = new DataTable();
         SqlLi_AssetListProvider sqlLi_AssetListProvider = new SqlLi_AssetListProvider();
         dt = sqlLi_AssetListProvider.GetAllLi_AssetList_Load();
         return dt;
    }
    public static DataTable GetAllLi_AssetList_ByAssetId(int AssetId)
    {
        DataTable dt = new DataTable();
        SqlLi_AssetListProvider sqlLi_AssetListProvider = new SqlLi_AssetListProvider();
        dt = sqlLi_AssetListProvider.GetAllLi_AssetList_ByAssetId(AssetId);
        return dt;
    }


}
