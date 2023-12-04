using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_OffShiftManager
{
	public Li_OffShiftManager()
	{
	}

    public static List<Li_OffShift> GetAllLi_OffShifts()
    {
        List<Li_OffShift> li_OffShifts = new List<Li_OffShift>();
        SqlLi_OffShiftProvider sqlLi_OffShiftProvider = new SqlLi_OffShiftProvider();
        li_OffShifts = sqlLi_OffShiftProvider.GetAllLi_OffShifts();
        return li_OffShifts;
    }


    public static Li_OffShift GetLi_OffShiftByID(int id)
    {
        Li_OffShift li_OffShift = new Li_OffShift();
        SqlLi_OffShiftProvider sqlLi_OffShiftProvider = new SqlLi_OffShiftProvider();
        li_OffShift = sqlLi_OffShiftProvider.GetLi_OffShiftByID(id);
        return li_OffShift;
    }


    public static int InsertLi_OffShift(Li_OffShift li_OffShift)
    {
        SqlLi_OffShiftProvider sqlLi_OffShiftProvider = new SqlLi_OffShiftProvider();
        return sqlLi_OffShiftProvider.InsertLi_OffShift(li_OffShift);
    }


    public static bool UpdateLi_OffShift(Li_OffShift li_OffShift)
    {
        SqlLi_OffShiftProvider sqlLi_OffShiftProvider = new SqlLi_OffShiftProvider();
        return sqlLi_OffShiftProvider.UpdateLi_OffShift(li_OffShift);
    }

    public static bool DeleteLi_OffShift(int li_OffShiftID)
    {
        SqlLi_OffShiftProvider sqlLi_OffShiftProvider = new SqlLi_OffShiftProvider();
        return sqlLi_OffShiftProvider.DeleteLi_OffShift(li_OffShiftID);
    }
}
