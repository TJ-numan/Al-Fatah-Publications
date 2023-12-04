using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetReturnManager
{
	public Li_AssetReturnManager()
	{
	}

    public static List<Li_AssetReturn> GetAllLi_AssetReturns()
    {
        List<Li_AssetReturn> li_AssetReturns = new List<Li_AssetReturn>();
        SqlLi_AssetReturnProvider sqlLi_AssetReturnProvider = new SqlLi_AssetReturnProvider();
        li_AssetReturns = sqlLi_AssetReturnProvider.GetAllLi_AssetReturns();
        return li_AssetReturns;
    }


    public static Li_AssetReturn GetLi_AssetReturnByID(int id)
    {
        Li_AssetReturn li_AssetReturn = new Li_AssetReturn();
        SqlLi_AssetReturnProvider sqlLi_AssetReturnProvider = new SqlLi_AssetReturnProvider();
        li_AssetReturn = sqlLi_AssetReturnProvider.GetLi_AssetReturnByID(id);
        return li_AssetReturn;
    }


    public static int InsertLi_AssetReturn(Li_AssetReturn li_AssetReturn)
    {
        SqlLi_AssetReturnProvider sqlLi_AssetReturnProvider = new SqlLi_AssetReturnProvider();
        return sqlLi_AssetReturnProvider.InsertLi_AssetReturn(li_AssetReturn);
    }


    public static bool UpdateLi_AssetReturn(Li_AssetReturn li_AssetReturn)
    {
        SqlLi_AssetReturnProvider sqlLi_AssetReturnProvider = new SqlLi_AssetReturnProvider();
        return sqlLi_AssetReturnProvider.UpdateLi_AssetReturn(li_AssetReturn);
    }

    public static bool DeleteLi_AssetReturn(int li_AssetReturnID)
    {
        SqlLi_AssetReturnProvider sqlLi_AssetReturnProvider = new SqlLi_AssetReturnProvider();
        return sqlLi_AssetReturnProvider.DeleteLi_AssetReturn(li_AssetReturnID);
    }
}
