using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_InfoStatusManager
{
	public Li_InfoStatusManager()
	{
	}

    public static List<Li_InfoStatus> GetAllLi_InfoStatuss()
    {
        List<Li_InfoStatus> li_InfoStatuss = new List<Li_InfoStatus>();
        SqlLi_InfoStatusProvider sqlLi_InfoStatusProvider = new SqlLi_InfoStatusProvider();
        li_InfoStatuss = sqlLi_InfoStatusProvider.GetAllLi_InfoStatuss();
        return li_InfoStatuss;
    }


    public static Li_InfoStatus GetLi_InfoStatusByID(int id)
    {
        Li_InfoStatus li_InfoStatus = new Li_InfoStatus();
        SqlLi_InfoStatusProvider sqlLi_InfoStatusProvider = new SqlLi_InfoStatusProvider();
        li_InfoStatus = sqlLi_InfoStatusProvider.GetLi_InfoStatusByID(id);
        return li_InfoStatus;
    }


    public static int InsertLi_InfoStatus(Li_InfoStatus li_InfoStatus)
    {
        SqlLi_InfoStatusProvider sqlLi_InfoStatusProvider = new SqlLi_InfoStatusProvider();
        return sqlLi_InfoStatusProvider.InsertLi_InfoStatus(li_InfoStatus);
    }


    public static bool UpdateLi_InfoStatus(Li_InfoStatus li_InfoStatus)
    {
        SqlLi_InfoStatusProvider sqlLi_InfoStatusProvider = new SqlLi_InfoStatusProvider();
        return sqlLi_InfoStatusProvider.UpdateLi_InfoStatus(li_InfoStatus);
    }

    public static bool DeleteLi_InfoStatus(int li_InfoStatusID)
    {
        SqlLi_InfoStatusProvider sqlLi_InfoStatusProvider = new SqlLi_InfoStatusProvider();
        return sqlLi_InfoStatusProvider.DeleteLi_InfoStatus(li_InfoStatusID);
    }
}
