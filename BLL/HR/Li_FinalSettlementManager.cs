using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_FinalSettlementManager
{
	public Li_FinalSettlementManager()
	{
	}

    public static List<Li_FinalSettlement> GetAllLi_FinalSettlements()
    {
        List<Li_FinalSettlement> li_FinalSettlements = new List<Li_FinalSettlement>();
        SqlLi_FinalSettlementProvider sqlLi_FinalSettlementProvider = new SqlLi_FinalSettlementProvider();
        li_FinalSettlements = sqlLi_FinalSettlementProvider.GetAllLi_FinalSettlements();
        return li_FinalSettlements;
    }


    public static Li_FinalSettlement GetLi_FinalSettlementByID(int id)
    {
        Li_FinalSettlement li_FinalSettlement = new Li_FinalSettlement();
        SqlLi_FinalSettlementProvider sqlLi_FinalSettlementProvider = new SqlLi_FinalSettlementProvider();
        li_FinalSettlement = sqlLi_FinalSettlementProvider.GetLi_FinalSettlementByID(id);
        return li_FinalSettlement;
    }


    public static int InsertLi_FinalSettlement(Li_FinalSettlement li_FinalSettlement)
    {
        SqlLi_FinalSettlementProvider sqlLi_FinalSettlementProvider = new SqlLi_FinalSettlementProvider();
        return sqlLi_FinalSettlementProvider.InsertLi_FinalSettlement(li_FinalSettlement);
    }


    public static bool UpdateLi_FinalSettlement(Li_FinalSettlement li_FinalSettlement)
    {
        SqlLi_FinalSettlementProvider sqlLi_FinalSettlementProvider = new SqlLi_FinalSettlementProvider();
        return sqlLi_FinalSettlementProvider.UpdateLi_FinalSettlement(li_FinalSettlement);
    }

    public static bool DeleteLi_FinalSettlement(int li_FinalSettlementID)
    {
        SqlLi_FinalSettlementProvider sqlLi_FinalSettlementProvider = new SqlLi_FinalSettlementProvider();
        return sqlLi_FinalSettlementProvider.DeleteLi_FinalSettlement(li_FinalSettlementID);
    }
}
