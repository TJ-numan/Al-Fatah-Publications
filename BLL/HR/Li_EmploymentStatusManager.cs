using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmploymentStatusManager
{
	public Li_EmploymentStatusManager()
	{
	}

    public static List<Li_EmploymentStatus> GetAllLi_EmploymentStatuss()
    {
        List<Li_EmploymentStatus> li_EmploymentStatuss = new List<Li_EmploymentStatus>();
        SqlLi_EmploymentStatusProvider sqlLi_EmploymentStatusProvider = new SqlLi_EmploymentStatusProvider();
        li_EmploymentStatuss = sqlLi_EmploymentStatusProvider.GetAllLi_EmploymentStatuss();
        return li_EmploymentStatuss;
    }


    public static Li_EmploymentStatus GetLi_EmploymentStatusByID(int id)
    {
        Li_EmploymentStatus li_EmploymentStatus = new Li_EmploymentStatus();
        SqlLi_EmploymentStatusProvider sqlLi_EmploymentStatusProvider = new SqlLi_EmploymentStatusProvider();
        li_EmploymentStatus = sqlLi_EmploymentStatusProvider.GetLi_EmploymentStatusByID(id);
        return li_EmploymentStatus;
    }


    public static int InsertLi_EmploymentStatus(Li_EmploymentStatus li_EmploymentStatus)
    {
        SqlLi_EmploymentStatusProvider sqlLi_EmploymentStatusProvider = new SqlLi_EmploymentStatusProvider();
        return sqlLi_EmploymentStatusProvider.InsertLi_EmploymentStatus(li_EmploymentStatus);
    }


    public static bool UpdateLi_EmploymentStatus(Li_EmploymentStatus li_EmploymentStatus)
    {
        SqlLi_EmploymentStatusProvider sqlLi_EmploymentStatusProvider = new SqlLi_EmploymentStatusProvider();
        return sqlLi_EmploymentStatusProvider.UpdateLi_EmploymentStatus(li_EmploymentStatus);
    }

    public static bool DeleteLi_EmploymentStatus(int li_EmploymentStatusID)
    {
        SqlLi_EmploymentStatusProvider sqlLi_EmploymentStatusProvider = new SqlLi_EmploymentStatusProvider();
        return sqlLi_EmploymentStatusProvider.DeleteLi_EmploymentStatus(li_EmploymentStatusID);
    }
}
