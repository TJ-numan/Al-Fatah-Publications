using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Dam_PartyManager
{
	public Li_Dam_PartyManager()
	{
	}

    public static List<Li_Dam_Party> GetAllLi_Dam_Parties()
    {
        List<Li_Dam_Party> li_Dam_Parties = new List<Li_Dam_Party>();
        SqlLi_Dam_PartyProvider sqlLi_Dam_PartyProvider = new SqlLi_Dam_PartyProvider();
        li_Dam_Parties = sqlLi_Dam_PartyProvider.GetAllLi_Dam_Parties();
        return li_Dam_Parties;
    }


    public static Li_Dam_Party GetLi_Dam_PartyByID(string  id)
    {
        Li_Dam_Party li_Dam_Party = new Li_Dam_Party();
        SqlLi_Dam_PartyProvider sqlLi_Dam_PartyProvider = new SqlLi_Dam_PartyProvider();
        li_Dam_Party = sqlLi_Dam_PartyProvider.GetLi_Dam_PartyByID(id);
        return li_Dam_Party;
    }


    public static int InsertLi_Dam_Party(Li_Dam_Party li_Dam_Party)
    {
        SqlLi_Dam_PartyProvider sqlLi_Dam_PartyProvider = new SqlLi_Dam_PartyProvider();
        return sqlLi_Dam_PartyProvider.InsertLi_Dam_Party(li_Dam_Party);
    }


    public static bool UpdateLi_Dam_Party(Li_Dam_Party li_Dam_Party)
    {
        SqlLi_Dam_PartyProvider sqlLi_Dam_PartyProvider = new SqlLi_Dam_PartyProvider();
        return sqlLi_Dam_PartyProvider.UpdateLi_Dam_Party(li_Dam_Party);
    }

    public static bool DeleteLi_Dam_Party(int li_Dam_PartyID)
    {
        SqlLi_Dam_PartyProvider sqlLi_Dam_PartyProvider = new SqlLi_Dam_PartyProvider();
        return sqlLi_Dam_PartyProvider.DeleteLi_Dam_Party(li_Dam_PartyID);
    }
}
