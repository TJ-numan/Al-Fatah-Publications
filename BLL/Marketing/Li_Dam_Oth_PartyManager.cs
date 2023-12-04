using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Dam_Oth_PartyManager
{
	public Li_Dam_Oth_PartyManager()
	{
	}

    public static List<Li_Dam_Oth_Party> GetAllLi_Dam_Oth_Parties()
    {
        List<Li_Dam_Oth_Party> li_Dam_Oth_Parties = new List<Li_Dam_Oth_Party>();
        SqlLi_Dam_Oth_PartyProvider sqlLi_Dam_Oth_PartyProvider = new SqlLi_Dam_Oth_PartyProvider();
        li_Dam_Oth_Parties = sqlLi_Dam_Oth_PartyProvider.GetAllLi_Dam_Oth_Parties();
        return li_Dam_Oth_Parties;
    }


    public static Li_Dam_Oth_Party GetLi_Dam_Oth_PartyByID(int id)
    {
        Li_Dam_Oth_Party li_Dam_Oth_Party = new Li_Dam_Oth_Party();
        SqlLi_Dam_Oth_PartyProvider sqlLi_Dam_Oth_PartyProvider = new SqlLi_Dam_Oth_PartyProvider();
        li_Dam_Oth_Party = sqlLi_Dam_Oth_PartyProvider.GetLi_Dam_Oth_PartyByID(id);
        return li_Dam_Oth_Party;
    }


    public static int InsertLi_Dam_Oth_Party(Li_Dam_Oth_Party li_Dam_Oth_Party)
    {
        SqlLi_Dam_Oth_PartyProvider sqlLi_Dam_Oth_PartyProvider = new SqlLi_Dam_Oth_PartyProvider();
        return sqlLi_Dam_Oth_PartyProvider.InsertLi_Dam_Oth_Party(li_Dam_Oth_Party);
    }


    public static bool UpdateLi_Dam_Oth_Party(Li_Dam_Oth_Party li_Dam_Oth_Party)
    {
        SqlLi_Dam_Oth_PartyProvider sqlLi_Dam_Oth_PartyProvider = new SqlLi_Dam_Oth_PartyProvider();
        return sqlLi_Dam_Oth_PartyProvider.UpdateLi_Dam_Oth_Party(li_Dam_Oth_Party);
    }

    public static bool DeleteLi_Dam_Oth_Party(int li_Dam_Oth_PartyID)
    {
        SqlLi_Dam_Oth_PartyProvider sqlLi_Dam_Oth_PartyProvider = new SqlLi_Dam_Oth_PartyProvider();
        return sqlLi_Dam_Oth_PartyProvider.DeleteLi_Dam_Oth_Party(li_Dam_Oth_PartyID);
    }
}
