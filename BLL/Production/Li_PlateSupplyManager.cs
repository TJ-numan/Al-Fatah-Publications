using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSupplyManager
{
	public Li_PlateSupplyManager()
	{
	}

    public static List<Li_PlateSupply> GetAllLi_PlateSupplies()
    {
        List<Li_PlateSupply> li_PlateSupplies = new List<Li_PlateSupply>();
        SqlLi_PlateSupplyProvider sqlLi_PlateSupplyProvider = new SqlLi_PlateSupplyProvider();
        li_PlateSupplies = sqlLi_PlateSupplyProvider.GetAllLi_PlateSupplies();
        return li_PlateSupplies;
    }


    public static Li_PlateSupply GetLi_PlateSupplyByID(int id)
    {
        Li_PlateSupply li_PlateSupply = new Li_PlateSupply();
        SqlLi_PlateSupplyProvider sqlLi_PlateSupplyProvider = new SqlLi_PlateSupplyProvider();
        li_PlateSupply = sqlLi_PlateSupplyProvider.GetLi_PlateSupplyByID(id);
        return li_PlateSupply;
    }


    public static int InsertLi_PlateSupply(Li_PlateSupply li_PlateSupply)
    {
        SqlLi_PlateSupplyProvider sqlLi_PlateSupplyProvider = new SqlLi_PlateSupplyProvider();
        return sqlLi_PlateSupplyProvider.InsertLi_PlateSupply(li_PlateSupply);
    }


    public static bool UpdateLi_PlateSupply(Li_PlateSupply li_PlateSupply)
    {
        SqlLi_PlateSupplyProvider sqlLi_PlateSupplyProvider = new SqlLi_PlateSupplyProvider();
        return sqlLi_PlateSupplyProvider.UpdateLi_PlateSupply(li_PlateSupply);
    }

    public static bool DeleteLi_PlateSupply(int li_PlateSupplyID)
    {
        SqlLi_PlateSupplyProvider sqlLi_PlateSupplyProvider = new SqlLi_PlateSupplyProvider();
        return sqlLi_PlateSupplyProvider.DeleteLi_PlateSupply(li_PlateSupplyID);
    }
}
