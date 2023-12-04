using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperOriginBasicManager
{
	public Li_PaperOriginBasicManager()
	{
	}

    public static List<Li_PaperOriginBasic> GetAllLi_PaperOriginBasics()
    {
        List<Li_PaperOriginBasic> li_PaperOriginBasics = new List<Li_PaperOriginBasic>();
        SqlLi_PaperOriginBasicProvider sqlLi_PaperOriginBasicProvider = new SqlLi_PaperOriginBasicProvider();
        li_PaperOriginBasics = sqlLi_PaperOriginBasicProvider.GetAllLi_PaperOriginBasics();
        return li_PaperOriginBasics;
    }


    public static Li_PaperOriginBasic GetLi_PaperOriginBasicByID(int id)
    {
        Li_PaperOriginBasic li_PaperOriginBasic = new Li_PaperOriginBasic();
        SqlLi_PaperOriginBasicProvider sqlLi_PaperOriginBasicProvider = new SqlLi_PaperOriginBasicProvider();
        li_PaperOriginBasic = sqlLi_PaperOriginBasicProvider.GetLi_PaperOriginBasicByID(id);
        return li_PaperOriginBasic;
    }


    public static string  InsertLi_PaperOriginBasic(Li_PaperOriginBasic li_PaperOriginBasic)
    {
        SqlLi_PaperOriginBasicProvider sqlLi_PaperOriginBasicProvider = new SqlLi_PaperOriginBasicProvider();
        return sqlLi_PaperOriginBasicProvider.InsertLi_PaperOriginBasic(li_PaperOriginBasic);
    }


    public static bool UpdateLi_PaperOriginBasic(Li_PaperOriginBasic li_PaperOriginBasic)
    {
        SqlLi_PaperOriginBasicProvider sqlLi_PaperOriginBasicProvider = new SqlLi_PaperOriginBasicProvider();
        return sqlLi_PaperOriginBasicProvider.UpdateLi_PaperOriginBasic(li_PaperOriginBasic);
    }

    public static bool DeleteLi_PaperOriginBasic(int li_PaperOriginBasicID)
    {
        SqlLi_PaperOriginBasicProvider sqlLi_PaperOriginBasicProvider = new SqlLi_PaperOriginBasicProvider();
        return sqlLi_PaperOriginBasicProvider.DeleteLi_PaperOriginBasic(li_PaperOriginBasicID);
    }
}
