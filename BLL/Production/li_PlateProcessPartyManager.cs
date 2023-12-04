using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateProcessPartyManager
{
	public Li_PlateProcessPartyManager()
	{
	}

    public static List<Li_PlateProcessParty> GetAllLi_PlateProcessParties()
    {
        List<Li_PlateProcessParty> li_PlateProcessParties = new List<Li_PlateProcessParty>();
        SqlLi_PlateProcessPartyProvider sqlLi_PlateProcessPartyProvider = new SqlLi_PlateProcessPartyProvider();
        li_PlateProcessParties = sqlLi_PlateProcessPartyProvider.GetAllLi_PlateProcessParties();
        return li_PlateProcessParties;
    }


    public static Li_PlateProcessParty GetLi_PlateProcessPartyByID(int id)
    {
        Li_PlateProcessParty li_PlateProcessParty = new Li_PlateProcessParty();
        SqlLi_PlateProcessPartyProvider sqlLi_PlateProcessPartyProvider = new SqlLi_PlateProcessPartyProvider();
        li_PlateProcessParty = sqlLi_PlateProcessPartyProvider.GetLi_PlateProcessPartyByID(id);
        return li_PlateProcessParty;
    }


    public static string  InsertLi_PlateProcessParty(Li_PlateProcessParty li_PlateProcessParty)
    {
        SqlLi_PlateProcessPartyProvider sqlLi_PlateProcessPartyProvider = new SqlLi_PlateProcessPartyProvider();
        return sqlLi_PlateProcessPartyProvider.InsertLi_PlateProcessParty(li_PlateProcessParty);
    }


    public static bool UpdateLi_PlateProcessParty(Li_PlateProcessParty li_PlateProcessParty)
    {
        SqlLi_PlateProcessPartyProvider sqlLi_PlateProcessPartyProvider = new SqlLi_PlateProcessPartyProvider();
        return sqlLi_PlateProcessPartyProvider.UpdateLi_PlateProcessParty(li_PlateProcessParty);
    }

    public static bool DeleteLi_PlateProcessParty(int li_PlateProcessPartyID)
    {
        SqlLi_PlateProcessPartyProvider sqlLi_PlateProcessPartyProvider = new SqlLi_PlateProcessPartyProvider();
        return sqlLi_PlateProcessPartyProvider.DeleteLi_PlateProcessParty(li_PlateProcessPartyID);
    }

    public static DataSet GetLi_PlateBuyerInfoByID(string id)
    {
        SqlLi_PlateProcessPartyProvider sqlLi_PestingPartyInfoProvider = new SqlLi_PlateProcessPartyProvider();
        return sqlLi_PestingPartyInfoProvider.GetLi_PlateBuyerInfoByID(id);

    }


    public static DataSet GetLi_PlateProcessPartiesByID(string id)
    {
        SqlLi_PlateProcessPartyProvider sqlLi_PestingPartyInfoProvider = new SqlLi_PlateProcessPartyProvider();
        return sqlLi_PestingPartyInfoProvider.GetLi_PlateProcessPartiesByID(id);

    }
}
