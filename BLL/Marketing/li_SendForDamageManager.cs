using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SendForDamageManager
{
	public Li_SendForDamageManager()
	{
	}

    public static List<Li_SendForDamage> GetAllLi_SendForDamages()
    {
        List<Li_SendForDamage> li_SendForDamages = new List<Li_SendForDamage>();
        SqlLi_SendForDamageProvider sqlLi_SendForDamageProvider = new SqlLi_SendForDamageProvider();
        li_SendForDamages = sqlLi_SendForDamageProvider.GetAllLi_SendForDamages();
        return li_SendForDamages;
    }


    public static Li_SendForDamage GetLi_SendForDamageByID(int id)
    {
        Li_SendForDamage li_SendForDamage = new Li_SendForDamage();
        SqlLi_SendForDamageProvider sqlLi_SendForDamageProvider = new SqlLi_SendForDamageProvider();
        li_SendForDamage = sqlLi_SendForDamageProvider.GetLi_SendForDamageByID(id);
        return li_SendForDamage;
    }


    public static string  InsertLi_SendForDamage(Li_SendForDamage li_SendForDamage)
    {
        SqlLi_SendForDamageProvider sqlLi_SendForDamageProvider = new SqlLi_SendForDamageProvider();
        return sqlLi_SendForDamageProvider.InsertLi_SendForDamage(li_SendForDamage);
    }


    public static bool UpdateLi_SendForDamage(Li_SendForDamage li_SendForDamage)
    {
        SqlLi_SendForDamageProvider sqlLi_SendForDamageProvider = new SqlLi_SendForDamageProvider();
        return sqlLi_SendForDamageProvider.UpdateLi_SendForDamage(li_SendForDamage);
    }

    public static bool DeleteLi_SendForDamage(int li_SendForDamageID)
    {
        SqlLi_SendForDamageProvider sqlLi_SendForDamageProvider = new SqlLi_SendForDamageProvider();
        return sqlLi_SendForDamageProvider.DeleteLi_SendForDamage(li_SendForDamageID);
    }
}
