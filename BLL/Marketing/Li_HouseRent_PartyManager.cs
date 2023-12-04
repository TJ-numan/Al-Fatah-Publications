using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_HouseRent_PartyManager
{
	public Li_HouseRent_PartyManager()
	{
	}

    public static List<Li_HouseRent_Party> GetAllLi_HouseRent_Parties()
    {
        List<Li_HouseRent_Party> li_HouseRent_Parties = new List<Li_HouseRent_Party>();
        SqlLi_HouseRent_PartyProvider sqlLi_HouseRent_PartyProvider = new SqlLi_HouseRent_PartyProvider();
        li_HouseRent_Parties = sqlLi_HouseRent_PartyProvider.GetAllLi_HouseRent_Parties();
        return li_HouseRent_Parties;
    }


    public static Li_HouseRent_Party GetLi_HouseRent_PartyByID(int id)
    {
        Li_HouseRent_Party li_HouseRent_Party = new Li_HouseRent_Party();
        SqlLi_HouseRent_PartyProvider sqlLi_HouseRent_PartyProvider = new SqlLi_HouseRent_PartyProvider();
        li_HouseRent_Party = sqlLi_HouseRent_PartyProvider.GetLi_HouseRent_PartyByID(id);
        return li_HouseRent_Party;
    }


    public static string InsertLi_HouseRent_Party(Li_HouseRent_Party li_HouseRent_Party)
    {
        SqlLi_HouseRent_PartyProvider sqlLi_HouseRent_PartyProvider = new SqlLi_HouseRent_PartyProvider();
        return sqlLi_HouseRent_PartyProvider.InsertLi_HouseRent_Party(li_HouseRent_Party);
    }


    public static bool UpdateLi_HouseRent_Party(Li_HouseRent_Party li_HouseRent_Party)
    {
        SqlLi_HouseRent_PartyProvider sqlLi_HouseRent_PartyProvider = new SqlLi_HouseRent_PartyProvider();
        return sqlLi_HouseRent_PartyProvider.UpdateLi_HouseRent_Party(li_HouseRent_Party);
    }

    public static bool DeleteLi_HouseRent_Party(int li_HouseRent_PartyID)
    {
        SqlLi_HouseRent_PartyProvider sqlLi_HouseRent_PartyProvider = new SqlLi_HouseRent_PartyProvider();
        return sqlLi_HouseRent_PartyProvider.DeleteLi_HouseRent_Party(li_HouseRent_PartyID);
    }

    public static DataSet GetAllLi_HouseRentPartyInfoByID(string PartyId)
    {
        SqlLi_HouseRent_PartyProvider sqlLi_HouseRent_PartyProvider = new SqlLi_HouseRent_PartyProvider();
        return sqlLi_HouseRent_PartyProvider.GetAllLi_HouseRentPartyByID(PartyId);

    }
}
