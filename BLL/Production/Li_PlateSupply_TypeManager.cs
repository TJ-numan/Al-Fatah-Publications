using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSupply_TypeManager
{
	public Li_PlateSupply_TypeManager()
	{
	}

    public static List<Li_PlateSupply_Type> GetAllLi_PlateSupply_Types()
    {
        List<Li_PlateSupply_Type> li_PlateSupply_Types = new List<Li_PlateSupply_Type>();
        SqlLi_PlateSupply_TypeProvider sqlLi_PlateSupply_TypeProvider = new SqlLi_PlateSupply_TypeProvider();
        li_PlateSupply_Types = sqlLi_PlateSupply_TypeProvider.GetAllLi_PlateSupply_Types();
        return li_PlateSupply_Types;
    }


    public static Li_PlateSupply_Type GetLi_PlateSupply_TypeByID(int id)
    {
        Li_PlateSupply_Type li_PlateSupply_Type = new Li_PlateSupply_Type();
        SqlLi_PlateSupply_TypeProvider sqlLi_PlateSupply_TypeProvider = new SqlLi_PlateSupply_TypeProvider();
        li_PlateSupply_Type = sqlLi_PlateSupply_TypeProvider.GetLi_PlateSupply_TypeByID(id);
        return li_PlateSupply_Type;
    }


    public static int InsertLi_PlateSupply_Type(Li_PlateSupply_Type li_PlateSupply_Type)
    {
        SqlLi_PlateSupply_TypeProvider sqlLi_PlateSupply_TypeProvider = new SqlLi_PlateSupply_TypeProvider();
        return sqlLi_PlateSupply_TypeProvider.InsertLi_PlateSupply_Type(li_PlateSupply_Type);
    }


    public static bool UpdateLi_PlateSupply_Type(Li_PlateSupply_Type li_PlateSupply_Type)
    {
        SqlLi_PlateSupply_TypeProvider sqlLi_PlateSupply_TypeProvider = new SqlLi_PlateSupply_TypeProvider();
        return sqlLi_PlateSupply_TypeProvider.UpdateLi_PlateSupply_Type(li_PlateSupply_Type);
    }

    public static bool DeleteLi_PlateSupply_Type(int li_PlateSupply_TypeID)
    {
        SqlLi_PlateSupply_TypeProvider sqlLi_PlateSupply_TypeProvider = new SqlLi_PlateSupply_TypeProvider();
        return sqlLi_PlateSupply_TypeProvider.DeleteLi_PlateSupply_Type(li_PlateSupply_TypeID);
    }
}
