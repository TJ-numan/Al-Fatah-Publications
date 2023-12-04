using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_PolithinPartyManager
{
	public Li_PolithinPartyManager()
	{
	}

    public static List<Li_PolithinParty> GetAllLi_PolithinParties()
    {
        List<Li_PolithinParty> li_PolithinParties = new List<Li_PolithinParty>();
        SqlLi_PolithinPartyProvider sqlLi_PolithinPartyProvider = new SqlLi_PolithinPartyProvider();
        li_PolithinParties = sqlLi_PolithinPartyProvider.GetAllLi_PolithinParties();
        return li_PolithinParties;
    }


    public static Li_PolithinParty GetLi_PolithinPartyByID(int id)
    {
        Li_PolithinParty li_PolithinParty = new Li_PolithinParty();
        SqlLi_PolithinPartyProvider sqlLi_PolithinPartyProvider = new SqlLi_PolithinPartyProvider();
        li_PolithinParty = sqlLi_PolithinPartyProvider.GetLi_PolithinPartyByID(id);
        return li_PolithinParty;
    }


    public static int InsertLi_PolithinParty(Li_PolithinParty li_PolithinParty)
    {
        SqlLi_PolithinPartyProvider sqlLi_PolithinPartyProvider = new SqlLi_PolithinPartyProvider();
        return sqlLi_PolithinPartyProvider.InsertLi_PolithinParty(li_PolithinParty);
    }


    public static bool UpdateLi_PolithinParty(Li_PolithinParty li_PolithinParty)
    {
        SqlLi_PolithinPartyProvider sqlLi_PolithinPartyProvider = new SqlLi_PolithinPartyProvider();
        return sqlLi_PolithinPartyProvider.UpdateLi_PolithinParty(li_PolithinParty);
    }

    public static bool DeleteLi_PolithinParty(int li_PolithinPartyID)
    {
        SqlLi_PolithinPartyProvider sqlLi_PolithinPartyProvider = new SqlLi_PolithinPartyProvider();
        return sqlLi_PolithinPartyProvider.DeleteLi_PolithinParty(li_PolithinPartyID);
    }
}
