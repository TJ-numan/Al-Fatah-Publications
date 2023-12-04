using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PromotionalItemBasicManager
{
	public Li_PromotionalItemBasicManager()
	{
	}

    public static List<Li_PromotionalItemBasic> GetAllLi_PromotionalItemBasics()
    {
        List<Li_PromotionalItemBasic> li_PromotionalItemBasics = new List<Li_PromotionalItemBasic>();
        SqlLi_PromotionalItemBasicProvider sqlLi_PromotionalItemBasicProvider = new SqlLi_PromotionalItemBasicProvider();
        li_PromotionalItemBasics = sqlLi_PromotionalItemBasicProvider.GetAllLi_PromotionalItemBasics();
        return li_PromotionalItemBasics;
    }


    public static Li_PromotionalItemBasic GetLi_PromotionalItemBasicByID(int id)
    {
        Li_PromotionalItemBasic li_PromotionalItemBasic = new Li_PromotionalItemBasic();
        SqlLi_PromotionalItemBasicProvider sqlLi_PromotionalItemBasicProvider = new SqlLi_PromotionalItemBasicProvider();
        li_PromotionalItemBasic = sqlLi_PromotionalItemBasicProvider.GetLi_PromotionalItemBasicByID(id);
        return li_PromotionalItemBasic;
    }


    public static string  InsertLi_PromotionalItemBasic(Li_PromotionalItemBasic li_PromotionalItemBasic)
    {
        SqlLi_PromotionalItemBasicProvider sqlLi_PromotionalItemBasicProvider = new SqlLi_PromotionalItemBasicProvider();
        return sqlLi_PromotionalItemBasicProvider.InsertLi_PromotionalItemBasic(li_PromotionalItemBasic);
    }


    public static bool UpdateLi_PromotionalItemBasic(Li_PromotionalItemBasic li_PromotionalItemBasic)
    {
        SqlLi_PromotionalItemBasicProvider sqlLi_PromotionalItemBasicProvider = new SqlLi_PromotionalItemBasicProvider();
        return sqlLi_PromotionalItemBasicProvider.UpdateLi_PromotionalItemBasic(li_PromotionalItemBasic);
    }

    public static bool DeleteLi_PromotionalItemBasic(int li_PromotionalItemBasicID)
    {
        SqlLi_PromotionalItemBasicProvider sqlLi_PromotionalItemBasicProvider = new SqlLi_PromotionalItemBasicProvider();
        return sqlLi_PromotionalItemBasicProvider.DeleteLi_PromotionalItemBasic(li_PromotionalItemBasicID);
    }
}
