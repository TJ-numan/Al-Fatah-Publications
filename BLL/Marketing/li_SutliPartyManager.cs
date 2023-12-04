using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SutliPartyManager
{
	public Li_SutliPartyManager()
	{
	}

    public static List<Li_SutliParty> GetAllLi_SutliParties()
    {
        List<Li_SutliParty> li_SutliParties = new List<Li_SutliParty>();
        SqlLi_SutliPartyProvider sqlLi_SutliPartyProvider = new SqlLi_SutliPartyProvider();
        li_SutliParties = sqlLi_SutliPartyProvider.GetAllLi_SutliParties();
        return li_SutliParties;
    }


    public static Li_SutliParty GetLi_SutliPartyByID(int id)
    {
        Li_SutliParty li_SutliParty = new Li_SutliParty();
        SqlLi_SutliPartyProvider sqlLi_SutliPartyProvider = new SqlLi_SutliPartyProvider();
        li_SutliParty = sqlLi_SutliPartyProvider.GetLi_SutliPartyByID(id);
        return li_SutliParty;
    }


    public static int InsertLi_SutliParty(Li_SutliParty li_SutliParty)
    {
        SqlLi_SutliPartyProvider sqlLi_SutliPartyProvider = new SqlLi_SutliPartyProvider();
        return sqlLi_SutliPartyProvider.InsertLi_SutliParty(li_SutliParty);
    }


    public static bool UpdateLi_SutliParty(Li_SutliParty li_SutliParty)
    {
        SqlLi_SutliPartyProvider sqlLi_SutliPartyProvider = new SqlLi_SutliPartyProvider();
        return sqlLi_SutliPartyProvider.UpdateLi_SutliParty(li_SutliParty);
    }

    public static bool DeleteLi_SutliParty(int li_SutliPartyID)
    {
        SqlLi_SutliPartyProvider sqlLi_SutliPartyProvider = new SqlLi_SutliPartyProvider();
        return sqlLi_SutliPartyProvider.DeleteLi_SutliParty(li_SutliPartyID);
    }
}
