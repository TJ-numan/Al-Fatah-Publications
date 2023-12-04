using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperBrandBasicManager
{
	public Li_PaperBrandBasicManager()
	{
	}

    public static List<Li_PaperBrandBasic> GetAllLi_PaperBrandBasics()
    {
        List<Li_PaperBrandBasic> li_PaperBrandBasics = new List<Li_PaperBrandBasic>();
        SqlLi_PaperBrandBasicProvider sqlLi_PaperBrandBasicProvider = new SqlLi_PaperBrandBasicProvider();
        li_PaperBrandBasics = sqlLi_PaperBrandBasicProvider.GetAllLi_PaperBrandBasics();
        return li_PaperBrandBasics;
    }


    public static Li_PaperBrandBasic GetLi_PaperBrandBasicByID(int id)
    {
        Li_PaperBrandBasic li_PaperBrandBasic = new Li_PaperBrandBasic();
        SqlLi_PaperBrandBasicProvider sqlLi_PaperBrandBasicProvider = new SqlLi_PaperBrandBasicProvider();
        li_PaperBrandBasic = sqlLi_PaperBrandBasicProvider.GetLi_PaperBrandBasicByID(id);
        return li_PaperBrandBasic;
    }


    public static string  InsertLi_PaperBrandBasic(Li_PaperBrandBasic li_PaperBrandBasic)
    {
        SqlLi_PaperBrandBasicProvider sqlLi_PaperBrandBasicProvider = new SqlLi_PaperBrandBasicProvider();
        return sqlLi_PaperBrandBasicProvider.InsertLi_PaperBrandBasic(li_PaperBrandBasic);
    }


    public static bool UpdateLi_PaperBrandBasic(Li_PaperBrandBasic li_PaperBrandBasic)
    {
        SqlLi_PaperBrandBasicProvider sqlLi_PaperBrandBasicProvider = new SqlLi_PaperBrandBasicProvider();
        return sqlLi_PaperBrandBasicProvider.UpdateLi_PaperBrandBasic(li_PaperBrandBasic);
    }

    public static bool DeleteLi_PaperBrandBasic(int li_PaperBrandBasicID)
    {
        SqlLi_PaperBrandBasicProvider sqlLi_PaperBrandBasicProvider = new SqlLi_PaperBrandBasicProvider();
        return sqlLi_PaperBrandBasicProvider.DeleteLi_PaperBrandBasic(li_PaperBrandBasicID);
    }
}
