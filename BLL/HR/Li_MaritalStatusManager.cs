using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_MaritalStatusManager
{
	public Li_MaritalStatusManager()
	{
	}

    public static List<Li_MaritalStatus> GetAllLi_MaritalStatuss()
    {
        List<Li_MaritalStatus> li_MaritalStatuss = new List<Li_MaritalStatus>();
        SqlLi_MaritalStatusProvider sqlLi_MaritalStatusProvider = new SqlLi_MaritalStatusProvider();
        li_MaritalStatuss = sqlLi_MaritalStatusProvider.GetAllLi_MaritalStatuss();
        return li_MaritalStatuss;
    }


    public static Li_MaritalStatus GetLi_MaritalStatusByID(int id)
    {
        Li_MaritalStatus li_MaritalStatus = new Li_MaritalStatus();
        SqlLi_MaritalStatusProvider sqlLi_MaritalStatusProvider = new SqlLi_MaritalStatusProvider();
        li_MaritalStatus = sqlLi_MaritalStatusProvider.GetLi_MaritalStatusByID(id);
        return li_MaritalStatus;
    }


    public static int InsertLi_MaritalStatus(Li_MaritalStatus li_MaritalStatus)
    {
        SqlLi_MaritalStatusProvider sqlLi_MaritalStatusProvider = new SqlLi_MaritalStatusProvider();
        return sqlLi_MaritalStatusProvider.InsertLi_MaritalStatus(li_MaritalStatus);
    }


    public static bool UpdateLi_MaritalStatus(Li_MaritalStatus li_MaritalStatus)
    {
        SqlLi_MaritalStatusProvider sqlLi_MaritalStatusProvider = new SqlLi_MaritalStatusProvider();
        return sqlLi_MaritalStatusProvider.UpdateLi_MaritalStatus(li_MaritalStatus);
    }

    public static bool DeleteLi_MaritalStatus(int li_MaritalStatusID)
    {
        SqlLi_MaritalStatusProvider sqlLi_MaritalStatusProvider = new SqlLi_MaritalStatusProvider();
        return sqlLi_MaritalStatusProvider.DeleteLi_MaritalStatus(li_MaritalStatusID);
    }
}
