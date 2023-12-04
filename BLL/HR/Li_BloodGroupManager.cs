using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_BloodGroupManager
{
	public Li_BloodGroupManager()
	{
	}

    public static List<Li_BloodGroup> GetAllLi_BloodGroups()
    {
        List<Li_BloodGroup> li_BloodGroups = new List<Li_BloodGroup>();
        SqlLi_BloodGroupProvider sqlLi_BloodGroupProvider = new SqlLi_BloodGroupProvider();
        li_BloodGroups = sqlLi_BloodGroupProvider.GetAllLi_BloodGroups();
        return li_BloodGroups;
    }


    public static Li_BloodGroup GetLi_BloodGroupByID(int id)
    {
        Li_BloodGroup li_BloodGroup = new Li_BloodGroup();
        SqlLi_BloodGroupProvider sqlLi_BloodGroupProvider = new SqlLi_BloodGroupProvider();
        li_BloodGroup = sqlLi_BloodGroupProvider.GetLi_BloodGroupByID(id);
        return li_BloodGroup;
    }


    public static int InsertLi_BloodGroup(Li_BloodGroup li_BloodGroup)
    {
        SqlLi_BloodGroupProvider sqlLi_BloodGroupProvider = new SqlLi_BloodGroupProvider();
        return sqlLi_BloodGroupProvider.InsertLi_BloodGroup(li_BloodGroup);
    }


    public static bool UpdateLi_BloodGroup(Li_BloodGroup li_BloodGroup)
    {
        SqlLi_BloodGroupProvider sqlLi_BloodGroupProvider = new SqlLi_BloodGroupProvider();
        return sqlLi_BloodGroupProvider.UpdateLi_BloodGroup(li_BloodGroup);
    }

    public static bool DeleteLi_BloodGroup(int li_BloodGroupID)
    {
        SqlLi_BloodGroupProvider sqlLi_BloodGroupProvider = new SqlLi_BloodGroupProvider();
        return sqlLi_BloodGroupProvider.DeleteLi_BloodGroup(li_BloodGroupID);
    }
}
