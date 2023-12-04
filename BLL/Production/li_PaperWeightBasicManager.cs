using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
  


public class Li_PaperWeightBasicManager
{
	public Li_PaperWeightBasicManager()
	{
	}

    public static List<Li_PaperWeightBasic> GetAllLi_PaperWeightBasics(string PaperSize)
    {
        List<Li_PaperWeightBasic> li_PaperWeightBasics = new List<Li_PaperWeightBasic>();
        SqlLi_PaperWeightBasicProvider sqlLi_PaperWeightBasicProvider = new SqlLi_PaperWeightBasicProvider();
        li_PaperWeightBasics = sqlLi_PaperWeightBasicProvider.GetAllLi_PaperWeightBasics(PaperSize);
        return li_PaperWeightBasics;
    }


    public static Li_PaperWeightBasic GetLi_PaperWeightBasicByID(int id)
    {
        Li_PaperWeightBasic li_PaperWeightBasic = new Li_PaperWeightBasic();
        SqlLi_PaperWeightBasicProvider sqlLi_PaperWeightBasicProvider = new SqlLi_PaperWeightBasicProvider();
        li_PaperWeightBasic = sqlLi_PaperWeightBasicProvider.GetLi_PaperWeightBasicByID(id);
        return li_PaperWeightBasic;
    }


    public static string  InsertLi_PaperWeightBasic(Li_PaperWeightBasic li_PaperWeightBasic)
    {
        SqlLi_PaperWeightBasicProvider sqlLi_PaperWeightBasicProvider = new SqlLi_PaperWeightBasicProvider();
        return sqlLi_PaperWeightBasicProvider.InsertLi_PaperWeightBasic(li_PaperWeightBasic);
    }


    public static bool UpdateLi_PaperWeightBasic(Li_PaperWeightBasic li_PaperWeightBasic)
    {
        SqlLi_PaperWeightBasicProvider sqlLi_PaperWeightBasicProvider = new SqlLi_PaperWeightBasicProvider();
        return sqlLi_PaperWeightBasicProvider.UpdateLi_PaperWeightBasic(li_PaperWeightBasic);
    }

    public static bool DeleteLi_PaperWeightBasic(int li_PaperWeightBasicID)
    {
        SqlLi_PaperWeightBasicProvider sqlLi_PaperWeightBasicProvider = new SqlLi_PaperWeightBasicProvider();
        return sqlLi_PaperWeightBasicProvider.DeleteLi_PaperWeightBasic(li_PaperWeightBasicID);
    }
}
