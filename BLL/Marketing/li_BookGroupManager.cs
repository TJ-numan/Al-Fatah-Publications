using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookGroupManager
{
	public Li_BookGroupManager()
	{
	}

    public static List<Li_BookGroup> GetAllLi_BookGroups()
    {
        List<Li_BookGroup> li_BookGroups = new List<Li_BookGroup>();
        SqlLi_BookGroupProvider sqlLi_BookGroupProvider = new SqlLi_BookGroupProvider();
        li_BookGroups = sqlLi_BookGroupProvider.GetAllLi_BookGroups();
        return li_BookGroups;
    }


    public static DataSet GetLi_BookGroupByID(string  id,bool IsCentralStore)
    {
         
        SqlLi_BookGroupProvider sqlLi_BookGroupProvider = new SqlLi_BookGroupProvider();
        return  sqlLi_BookGroupProvider.GetLi_BookGroupByID(id,IsCentralStore);
          
    }


    public static int InsertLi_BookGroup(Li_BookGroup li_BookGroup)
    {
        SqlLi_BookGroupProvider sqlLi_BookGroupProvider = new SqlLi_BookGroupProvider();
        return sqlLi_BookGroupProvider.InsertLi_BookGroup(li_BookGroup);
    }


    public static bool UpdateLi_BookGroup(Li_BookGroup li_BookGroup)
    {
        SqlLi_BookGroupProvider sqlLi_BookGroupProvider = new SqlLi_BookGroupProvider();
        return sqlLi_BookGroupProvider.UpdateLi_BookGroup(li_BookGroup);
    }

    public static bool DeleteLi_BookGroup(int li_BookGroupID)
    {
        SqlLi_BookGroupProvider sqlLi_BookGroupProvider = new SqlLi_BookGroupProvider();
        return sqlLi_BookGroupProvider.DeleteLi_BookGroup(li_BookGroupID);
    }
}
