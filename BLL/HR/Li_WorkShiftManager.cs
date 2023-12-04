using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;

public class Li_WorkShiftManager
{
	public Li_WorkShiftManager()
	{
	}

    public static List<Li_WorkShift> GetAllLi_WorkShifts()
    {
        List<Li_WorkShift> li_WorkShifts = new List<Li_WorkShift>();
        SqlLi_WorkShiftProvider sqlLi_WorkShiftProvider = new SqlLi_WorkShiftProvider();
        li_WorkShifts = sqlLi_WorkShiftProvider.GetAllLi_WorkShifts();
        return li_WorkShifts;
    }


    public static Li_WorkShift GetLi_WorkShiftByID(int id)
    {
        Li_WorkShift li_WorkShift = new Li_WorkShift();
        SqlLi_WorkShiftProvider sqlLi_WorkShiftProvider = new SqlLi_WorkShiftProvider();
        li_WorkShift = sqlLi_WorkShiftProvider.GetLi_WorkShiftByID(id);
        return li_WorkShift;
    }


    public static int InsertLi_WorkShift(Li_WorkShift li_WorkShift)
    {
        SqlLi_WorkShiftProvider sqlLi_WorkShiftProvider = new SqlLi_WorkShiftProvider();
        return sqlLi_WorkShiftProvider.InsertLi_WorkShift(li_WorkShift);
    }


    public static bool UpdateLi_WorkShift(Li_WorkShift li_WorkShift)
    {
        SqlLi_WorkShiftProvider sqlLi_WorkShiftProvider = new SqlLi_WorkShiftProvider();
        return sqlLi_WorkShiftProvider.UpdateLi_WorkShift(li_WorkShift);
    }

    public static bool DeleteLi_WorkShift(int li_WorkShiftID)
    {
        SqlLi_WorkShiftProvider sqlLi_WorkShiftProvider = new SqlLi_WorkShiftProvider();
        return sqlLi_WorkShiftProvider.DeleteLi_WorkShift(li_WorkShiftID);
    }
}
