using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ReligionManager
{
	public Li_ReligionManager()
	{
	}

    public static List<Li_Religion> GetAllLi_Religions()
    {
        List<Li_Religion> li_Religions = new List<Li_Religion>();
        SqlLi_ReligionProvider sqlLi_ReligionProvider = new SqlLi_ReligionProvider();
        li_Religions = sqlLi_ReligionProvider.GetAllLi_Religions();
        return li_Religions;
    }


    public static Li_Religion GetLi_ReligionByID(int id)
    {
        Li_Religion li_Religion = new Li_Religion();
        SqlLi_ReligionProvider sqlLi_ReligionProvider = new SqlLi_ReligionProvider();
        li_Religion = sqlLi_ReligionProvider.GetLi_ReligionByID(id);
        return li_Religion;
    }


    public static int InsertLi_Religion(Li_Religion li_Religion)
    {
        SqlLi_ReligionProvider sqlLi_ReligionProvider = new SqlLi_ReligionProvider();
        return sqlLi_ReligionProvider.InsertLi_Religion(li_Religion);
    }


    public static bool UpdateLi_Religion(Li_Religion li_Religion)
    {
        SqlLi_ReligionProvider sqlLi_ReligionProvider = new SqlLi_ReligionProvider();
        return sqlLi_ReligionProvider.UpdateLi_Religion(li_Religion);
    }

    public static bool DeleteLi_Religion(int li_ReligionID)
    {
        SqlLi_ReligionProvider sqlLi_ReligionProvider = new SqlLi_ReligionProvider();
        return sqlLi_ReligionProvider.DeleteLi_Religion(li_ReligionID);
    }
}
