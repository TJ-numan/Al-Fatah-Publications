using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpLeaveStatusManager
{
	public Li_EmpLeaveStatusManager()
	{
	}

    public static List<Li_EmpLeaveStatus> GetAllLi_EmpLeaveStatuss()
    {
        List<Li_EmpLeaveStatus> li_EmpLeaveStatuss = new List<Li_EmpLeaveStatus>();
        SqlLi_EmpLeaveStatusProvider sqlLi_EmpLeaveStatusProvider = new SqlLi_EmpLeaveStatusProvider();
        li_EmpLeaveStatuss = sqlLi_EmpLeaveStatusProvider.GetAllLi_EmpLeaveStatuss();
        return li_EmpLeaveStatuss;
    }


    public static Li_EmpLeaveStatus GetLi_EmpLeaveStatusByID(int id)
    {
        Li_EmpLeaveStatus li_EmpLeaveStatus = new Li_EmpLeaveStatus();
        SqlLi_EmpLeaveStatusProvider sqlLi_EmpLeaveStatusProvider = new SqlLi_EmpLeaveStatusProvider();
        li_EmpLeaveStatus = sqlLi_EmpLeaveStatusProvider.GetLi_EmpLeaveStatusByID(id);
        return li_EmpLeaveStatus;
    }


    public static int InsertLi_EmpLeaveStatus(Li_EmpLeaveStatus li_EmpLeaveStatus)
    {
        SqlLi_EmpLeaveStatusProvider sqlLi_EmpLeaveStatusProvider = new SqlLi_EmpLeaveStatusProvider();
        return sqlLi_EmpLeaveStatusProvider.InsertLi_EmpLeaveStatus(li_EmpLeaveStatus);
    }


    public static bool UpdateLi_EmpLeaveStatus(Li_EmpLeaveStatus li_EmpLeaveStatus)
    {
        SqlLi_EmpLeaveStatusProvider sqlLi_EmpLeaveStatusProvider = new SqlLi_EmpLeaveStatusProvider();
        return sqlLi_EmpLeaveStatusProvider.UpdateLi_EmpLeaveStatus(li_EmpLeaveStatus);
    }

    public static bool DeleteLi_EmpLeaveStatus(int li_EmpLeaveStatusID)
    {
        SqlLi_EmpLeaveStatusProvider sqlLi_EmpLeaveStatusProvider = new SqlLi_EmpLeaveStatusProvider();
        return sqlLi_EmpLeaveStatusProvider.DeleteLi_EmpLeaveStatus(li_EmpLeaveStatusID);
    }
}
