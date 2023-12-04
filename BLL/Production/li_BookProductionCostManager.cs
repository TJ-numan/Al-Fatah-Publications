using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_BookProductionCostManager
{
	public Li_BookProductionCostManager()
	{
	}

    public static List<Li_BookProductionCost> GetAllLi_BookProductionCosts()
    {
        List<Li_BookProductionCost> li_BookProductionCosts = new List<Li_BookProductionCost>();
        SqlLi_BookProductionCostProvider sqlLi_BookProductionCostProvider = new SqlLi_BookProductionCostProvider();
        li_BookProductionCosts = sqlLi_BookProductionCostProvider.GetAllLi_BookProductionCosts();
        return li_BookProductionCosts;
    }


    public static Li_BookProductionCost GetLi_BookProductionCostByID(int id)
    {
        Li_BookProductionCost li_BookProductionCost = new Li_BookProductionCost();
        SqlLi_BookProductionCostProvider sqlLi_BookProductionCostProvider = new SqlLi_BookProductionCostProvider();
        li_BookProductionCost = sqlLi_BookProductionCostProvider.GetLi_BookProductionCostByID(id);
        return li_BookProductionCost;
    }


    public static int InsertLi_BookProductionCost(Li_BookProductionCost li_BookProductionCost)
    {
        SqlLi_BookProductionCostProvider sqlLi_BookProductionCostProvider = new SqlLi_BookProductionCostProvider();
        return sqlLi_BookProductionCostProvider.InsertLi_BookProductionCost(li_BookProductionCost);
    }


    public static bool UpdateLi_BookProductionCost(Li_BookProductionCost li_BookProductionCost)
    {
        SqlLi_BookProductionCostProvider sqlLi_BookProductionCostProvider = new SqlLi_BookProductionCostProvider();
        return sqlLi_BookProductionCostProvider.UpdateLi_BookProductionCost(li_BookProductionCost);
    }

    public static bool DeleteLi_BookProductionCost(int li_BookProductionCostID)
    {
        SqlLi_BookProductionCostProvider sqlLi_BookProductionCostProvider = new SqlLi_BookProductionCostProvider();
        return sqlLi_BookProductionCostProvider.DeleteLi_BookProductionCost(li_BookProductionCostID);
    }
}
