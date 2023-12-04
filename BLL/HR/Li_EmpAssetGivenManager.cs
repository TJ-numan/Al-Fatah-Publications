using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpAssetGivenManager
{
	public Li_EmpAssetGivenManager()
	{
	}

    public static List<Li_EmpAssetGiven> GetAllLi_EmpAssetGivens()
    {
        List<Li_EmpAssetGiven> li_EmpAssetGivens = new List<Li_EmpAssetGiven>();
        SqlLi_EmpAssetGivenProvider sqlLi_EmpAssetGivenProvider = new SqlLi_EmpAssetGivenProvider();
        li_EmpAssetGivens = sqlLi_EmpAssetGivenProvider.GetAllLi_EmpAssetGivens();
        return li_EmpAssetGivens;
    }


    public static Li_EmpAssetGiven GetLi_EmpAssetGivenByID(int id)
    {
        Li_EmpAssetGiven li_EmpAssetGiven = new Li_EmpAssetGiven();
        SqlLi_EmpAssetGivenProvider sqlLi_EmpAssetGivenProvider = new SqlLi_EmpAssetGivenProvider();
        li_EmpAssetGiven = sqlLi_EmpAssetGivenProvider.GetLi_EmpAssetGivenByID(id);
        return li_EmpAssetGiven;
    }


    public static int InsertLi_EmpAssetGiven(Li_EmpAssetGiven li_EmpAssetGiven)
    {
        SqlLi_EmpAssetGivenProvider sqlLi_EmpAssetGivenProvider = new SqlLi_EmpAssetGivenProvider();
        return sqlLi_EmpAssetGivenProvider.InsertLi_EmpAssetGiven(li_EmpAssetGiven);
    }


    public static bool UpdateLi_EmpAssetGiven(Li_EmpAssetGiven li_EmpAssetGiven)
    {
        SqlLi_EmpAssetGivenProvider sqlLi_EmpAssetGivenProvider = new SqlLi_EmpAssetGivenProvider();
        return sqlLi_EmpAssetGivenProvider.UpdateLi_EmpAssetGiven(li_EmpAssetGiven);
    }

    public static bool DeleteLi_EmpAssetGiven(int li_EmpAssetGivenID)
    {
        SqlLi_EmpAssetGivenProvider sqlLi_EmpAssetGivenProvider = new SqlLi_EmpAssetGivenProvider();
        return sqlLi_EmpAssetGivenProvider.DeleteLi_EmpAssetGiven(li_EmpAssetGivenID);
    }
}
