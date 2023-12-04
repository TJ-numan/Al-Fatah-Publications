using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_WorkTypeRNDManager
{
	public Li_WorkTypeRNDManager()
	{
	}

    public static List<Li_WorkTypeRND> GetAllLi_WorkTypeRNDs()
    {
        List<Li_WorkTypeRND> li_WorkTypeRNDs = new List<Li_WorkTypeRND>();
        SqlLi_WorkTypeRNDProvider sqlLi_WorkTypeRNDProvider = new SqlLi_WorkTypeRNDProvider();
        li_WorkTypeRNDs = sqlLi_WorkTypeRNDProvider.GetAllLi_WorkTypeRNDs();
        return li_WorkTypeRNDs;
    }


    public static Li_WorkTypeRND GetLi_WorkTypeRNDByID(int id)
    {
        Li_WorkTypeRND li_WorkTypeRND = new Li_WorkTypeRND();
        SqlLi_WorkTypeRNDProvider sqlLi_WorkTypeRNDProvider = new SqlLi_WorkTypeRNDProvider();
        li_WorkTypeRND = sqlLi_WorkTypeRNDProvider.GetLi_WorkTypeRNDByID(id);
        return li_WorkTypeRND;
    }


    public static int InsertLi_WorkTypeRND(Li_WorkTypeRND li_WorkTypeRND)
    {
        SqlLi_WorkTypeRNDProvider sqlLi_WorkTypeRNDProvider = new SqlLi_WorkTypeRNDProvider();
        return sqlLi_WorkTypeRNDProvider.InsertLi_WorkTypeRND(li_WorkTypeRND);
    }


    public static bool UpdateLi_WorkTypeRND(Li_WorkTypeRND li_WorkTypeRND)
    {
        SqlLi_WorkTypeRNDProvider sqlLi_WorkTypeRNDProvider = new SqlLi_WorkTypeRNDProvider();
        return sqlLi_WorkTypeRNDProvider.UpdateLi_WorkTypeRND(li_WorkTypeRND);
    }

    public static bool DeleteLi_WorkTypeRND(int li_WorkTypeRNDID)
    {
        SqlLi_WorkTypeRNDProvider sqlLi_WorkTypeRNDProvider = new SqlLi_WorkTypeRNDProvider();
        return sqlLi_WorkTypeRNDProvider.DeleteLi_WorkTypeRND(li_WorkTypeRNDID);
    }
}
