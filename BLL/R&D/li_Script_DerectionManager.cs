using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Script_DerectionManager
{
	public Li_Script_DerectionManager()
	{
	}

    public static List<Li_Script_Derection> GetAllLi_Script_Derections()
    {
        List<Li_Script_Derection> li_Script_Derections = new List<Li_Script_Derection>();
        SqlLi_Script_DerectionProvider sqlLi_Script_DerectionProvider = new SqlLi_Script_DerectionProvider();
        li_Script_Derections = sqlLi_Script_DerectionProvider.GetAllLi_Script_Derections();
        return li_Script_Derections;
    }


    public static Li_Script_Derection GetLi_Script_DerectionByID(int id)
    {
        Li_Script_Derection li_Script_Derection = new Li_Script_Derection();
        SqlLi_Script_DerectionProvider sqlLi_Script_DerectionProvider = new SqlLi_Script_DerectionProvider();
        li_Script_Derection = sqlLi_Script_DerectionProvider.GetLi_Script_DerectionByID(id);
        return li_Script_Derection;
    }


    public static int InsertLi_Script_Derection(Li_Script_Derection li_Script_Derection)
    {
        SqlLi_Script_DerectionProvider sqlLi_Script_DerectionProvider = new SqlLi_Script_DerectionProvider();
        return sqlLi_Script_DerectionProvider.InsertLi_Script_Derection(li_Script_Derection);
    }


    public static bool UpdateLi_Script_Derection(Li_Script_Derection li_Script_Derection)
    {
        SqlLi_Script_DerectionProvider sqlLi_Script_DerectionProvider = new SqlLi_Script_DerectionProvider();
        return sqlLi_Script_DerectionProvider.UpdateLi_Script_Derection(li_Script_Derection);
    }

    public static bool DeleteLi_Script_Derection(int li_Script_DerectionID)
    {
        SqlLi_Script_DerectionProvider sqlLi_Script_DerectionProvider = new SqlLi_Script_DerectionProvider();
        return sqlLi_Script_DerectionProvider.DeleteLi_Script_Derection(li_Script_DerectionID);
    }
}
