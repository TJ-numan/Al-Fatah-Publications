using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LeaveTypeManager
{
	public Li_LeaveTypeManager()
	{
	}

    public static List<Li_LeaveType> GetAllLi_LeaveTypes()
    {
        List<Li_LeaveType> li_LeaveTypes = new List<Li_LeaveType>();
        SqlLi_LeaveTypeProvider sqlLi_LeaveTypeProvider = new SqlLi_LeaveTypeProvider();
        li_LeaveTypes = sqlLi_LeaveTypeProvider.GetAllLi_LeaveTypes();
        return li_LeaveTypes;
    }


    public static Li_LeaveType GetLi_LeaveTypeByID(int id)
    {
        Li_LeaveType li_LeaveType = new Li_LeaveType();
        SqlLi_LeaveTypeProvider sqlLi_LeaveTypeProvider = new SqlLi_LeaveTypeProvider();
        li_LeaveType = sqlLi_LeaveTypeProvider.GetLi_LeaveTypeByID(id);
        return li_LeaveType;
    }


    public static int InsertLi_LeaveType(Li_LeaveType li_LeaveType)
    {
        SqlLi_LeaveTypeProvider sqlLi_LeaveTypeProvider = new SqlLi_LeaveTypeProvider();
        return sqlLi_LeaveTypeProvider.InsertLi_LeaveType(li_LeaveType);
    }


    public static bool UpdateLi_LeaveType(Li_LeaveType li_LeaveType)
    {
        SqlLi_LeaveTypeProvider sqlLi_LeaveTypeProvider = new SqlLi_LeaveTypeProvider();
        return sqlLi_LeaveTypeProvider.UpdateLi_LeaveType(li_LeaveType);
    }

    public static bool DeleteLi_LeaveType(int li_LeaveTypeID)
    {
        SqlLi_LeaveTypeProvider sqlLi_LeaveTypeProvider = new SqlLi_LeaveTypeProvider();
        return sqlLi_LeaveTypeProvider.DeleteLi_LeaveType(li_LeaveTypeID);
    }
}
