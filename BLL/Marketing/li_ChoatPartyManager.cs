using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_ChoatPartyManager
{
	public Li_ChoatPartyManager()
	{
	}

    public static List<Li_ChoatParty> GetAllLi_ChoatParties()
    {
        List<Li_ChoatParty> li_ChoatParties = new List<Li_ChoatParty>();
        SqlLi_ChoatPartyProvider sqlLi_ChoatPartyProvider = new SqlLi_ChoatPartyProvider();
        li_ChoatParties = sqlLi_ChoatPartyProvider.GetAllLi_ChoatParties();
        return li_ChoatParties;
    }


    public static Li_ChoatParty GetLi_ChoatPartyByID(int id)
    {
        Li_ChoatParty li_ChoatParty = new Li_ChoatParty();
        SqlLi_ChoatPartyProvider sqlLi_ChoatPartyProvider = new SqlLi_ChoatPartyProvider();
        li_ChoatParty = sqlLi_ChoatPartyProvider.GetLi_ChoatPartyByID(id);
        return li_ChoatParty;
    }


    public static int InsertLi_ChoatParty(Li_ChoatParty li_ChoatParty)
    {
        SqlLi_ChoatPartyProvider sqlLi_ChoatPartyProvider = new SqlLi_ChoatPartyProvider();
        return sqlLi_ChoatPartyProvider.InsertLi_ChoatParty(li_ChoatParty);
    }


    public static bool UpdateLi_ChoatParty(Li_ChoatParty li_ChoatParty)
    {
        SqlLi_ChoatPartyProvider sqlLi_ChoatPartyProvider = new SqlLi_ChoatPartyProvider();
        return sqlLi_ChoatPartyProvider.UpdateLi_ChoatParty(li_ChoatParty);
    }

    public static bool DeleteLi_ChoatParty(int li_ChoatPartyID)
    {
        SqlLi_ChoatPartyProvider sqlLi_ChoatPartyProvider = new SqlLi_ChoatPartyProvider();
        return sqlLi_ChoatPartyProvider.DeleteLi_ChoatParty(li_ChoatPartyID);
    }
}
