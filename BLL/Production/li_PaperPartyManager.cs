using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperPartyManager
{
	public Li_PaperPartyManager()
	{
	}

    public static List<Li_PaperParty> GetAllLi_PaperParties()
    {
        List<Li_PaperParty> li_PaperParties = new List<Li_PaperParty>();
        SqlLi_PaperPartyProvider sqlLi_PaperPartyProvider = new SqlLi_PaperPartyProvider();
        li_PaperParties = sqlLi_PaperPartyProvider.GetAllLi_PaperParties();
        return li_PaperParties;
    }


    public static Li_PaperParty GetLi_PaperPartyByID(int id)
    {
        Li_PaperParty li_PaperParty = new Li_PaperParty();
        SqlLi_PaperPartyProvider sqlLi_PaperPartyProvider = new SqlLi_PaperPartyProvider();
        li_PaperParty = sqlLi_PaperPartyProvider.GetLi_PaperPartyByID(id);
        return li_PaperParty;
    }

    public static DataSet GetAllLi_PestingPartyInfoByID(string PartyId)
    {
       SqlLi_PaperPartyProvider  sqlLi_PestingPartyInfoProvider = new SqlLi_PaperPartyProvider();
       return sqlLi_PestingPartyInfoProvider.GetAllLi_PaperPartyByID(PartyId);

    }


    public static string  InsertLi_PaperParty(Li_PaperParty li_PaperParty)
    {
        SqlLi_PaperPartyProvider sqlLi_PaperPartyProvider = new SqlLi_PaperPartyProvider();
        return sqlLi_PaperPartyProvider.InsertLi_PaperParty(li_PaperParty);
    }


    public static bool UpdateLi_PaperParty(Li_PaperParty li_PaperParty)
    {
        SqlLi_PaperPartyProvider sqlLi_PaperPartyProvider = new SqlLi_PaperPartyProvider();
        return sqlLi_PaperPartyProvider.UpdateLi_PaperParty(li_PaperParty);
    }

    public static bool DeleteLi_PaperParty(int li_PaperPartyID)
    {
        SqlLi_PaperPartyProvider sqlLi_PaperPartyProvider = new SqlLi_PaperPartyProvider();
        return sqlLi_PaperPartyProvider.DeleteLi_PaperParty(li_PaperPartyID);
    }
}
