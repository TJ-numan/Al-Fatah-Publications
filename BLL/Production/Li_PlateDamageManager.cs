using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;


public class Li_PlateDamageManager
{
    public Li_PlateDamageManager()
	{
	}

    public static List<Li_PlateDamage> GetAllLi_PlateDamage()
    {
        List<Li_PlateDamage> li_PlateDamage = new List<Li_PlateDamage>();
        SqlLi_PlateDamageProvider sqlLi_PlateDamageProvider = new SqlLi_PlateDamageProvider();
        li_PlateDamage = sqlLi_PlateDamageProvider.GetAllLi_PlateDamage();
        return li_PlateDamage;
    }


    public static Li_PlateDamage GetLi_PlateDamageID(int id)
    {
        Li_PlateDamage li_PlateDamage = new Li_PlateDamage();
        SqlLi_PlateDamageProvider sqlLi_PlateDamageProvider = new SqlLi_PlateDamageProvider();
        li_PlateDamage = sqlLi_PlateDamageProvider.GetLi_PlateDamageByID(id);
        return li_PlateDamage;
    }


    public static string InsertLi_PlateDamage(Li_PlateDamage li_PlateDamage)
    {
        SqlLi_PlateDamageProvider sqlLi_PlateDamageProvider = new SqlLi_PlateDamageProvider();
        return sqlLi_PlateDamageProvider.InsertLi_PlateDamage(li_PlateDamage);
    }


    public static bool UpdateLi_PlateDamage(Li_PlateDamage li_PlateDamage)
    {
        SqlLi_PlateDamageProvider sqlLi_PlateDamageProvider = new SqlLi_PlateDamageProvider();
        return sqlLi_PlateDamageProvider.UpdateLi_PlateDamage(li_PlateDamage);
    }

    public static bool DeleteLi_PlateDamage(int li_PlateDamageID)
    {
        SqlLi_PlateDamageProvider sqlLi_PlateDamageProvider = new SqlLi_PlateDamageProvider();
        return sqlLi_PlateDamageProvider.DeleteLi_PlateDamage(li_PlateDamageID);
    }

    public static string InsertLi_PlateDamageStock(Li_PlateDamage li_PlateDamage)
    {
        SqlLi_PlateDamageProvider sqlLi_PlateDamageProvider = new SqlLi_PlateDamageProvider();
        return sqlLi_PlateDamageProvider.InsertLi_PlateDamageStock(li_PlateDamage);
    }
   

}
