using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperTypeBasicManager
{
	public Li_PaperTypeBasicManager()
	{
	}

    public static List<Li_PaperTypeBasic> GetAllLi_PaperTypeBasics()
    {
        List<Li_PaperTypeBasic> li_PaperTypeBasics = new List<Li_PaperTypeBasic>();
        SqlLi_PaperTypeBasicProvider sqlLi_PaperTypeBasicProvider = new SqlLi_PaperTypeBasicProvider();
        li_PaperTypeBasics = sqlLi_PaperTypeBasicProvider.GetAllLi_PaperTypeBasics();
        return li_PaperTypeBasics;
    }


    public static List<Li_PaperTypeBasic> GetAllLi_PaperTypeBasics_ForInnerForma(bool IsCover)
    {
        List<Li_PaperTypeBasic> li_PaperTypeBasics = new List<Li_PaperTypeBasic>();
        SqlLi_PaperTypeBasicProvider sqlLi_PaperTypeBasicProvider = new SqlLi_PaperTypeBasicProvider();
        li_PaperTypeBasics = sqlLi_PaperTypeBasicProvider.GetAllLi_PaperTypeBasics_ForInnerForma(IsCover);
        return li_PaperTypeBasics;
    }

    public static Li_PaperTypeBasic GetLi_PaperTypeBasicByID(int id)
    {
        Li_PaperTypeBasic li_PaperTypeBasic = new Li_PaperTypeBasic();
        SqlLi_PaperTypeBasicProvider sqlLi_PaperTypeBasicProvider = new SqlLi_PaperTypeBasicProvider();
        li_PaperTypeBasic = sqlLi_PaperTypeBasicProvider.GetLi_PaperTypeBasicByID(id);
        return li_PaperTypeBasic;
    }


    public static string  InsertLi_PaperTypeBasic(Li_PaperTypeBasic li_PaperTypeBasic)
    {
        SqlLi_PaperTypeBasicProvider sqlLi_PaperTypeBasicProvider = new SqlLi_PaperTypeBasicProvider();
        return sqlLi_PaperTypeBasicProvider.InsertLi_PaperTypeBasic(li_PaperTypeBasic);
    }


    public static bool UpdateLi_PaperTypeBasic(Li_PaperTypeBasic li_PaperTypeBasic)
    {
        SqlLi_PaperTypeBasicProvider sqlLi_PaperTypeBasicProvider = new SqlLi_PaperTypeBasicProvider();
        return sqlLi_PaperTypeBasicProvider.UpdateLi_PaperTypeBasic(li_PaperTypeBasic);
    }

    public static bool DeleteLi_PaperTypeBasic(int li_PaperTypeBasicID)
    {
        SqlLi_PaperTypeBasicProvider sqlLi_PaperTypeBasicProvider = new SqlLi_PaperTypeBasicProvider();
        return sqlLi_PaperTypeBasicProvider.DeleteLi_PaperTypeBasic(li_PaperTypeBasicID);
    }
}
