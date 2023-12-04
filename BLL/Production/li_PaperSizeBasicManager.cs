using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperSizeBasicManager
{
	public Li_PaperSizeBasicManager()
	{
	}

    public static List<Li_PaperSizeBasic> GetAllLi_PaperSizeBasics()
    {
        List<Li_PaperSizeBasic> li_PaperSizeBasics = new List<Li_PaperSizeBasic>();
        SqlLi_PaperSizeBasicProvider sqlLi_PaperSizeBasicProvider = new SqlLi_PaperSizeBasicProvider();
        li_PaperSizeBasics = sqlLi_PaperSizeBasicProvider.GetAllLi_PaperSizeBasics();
        return li_PaperSizeBasics;
    }


    public static List<Li_PaperSizeBasic> GetLi_PaperSizeBasicByID(string  id)
    {
        List<Li_PaperSizeBasic> li_PaperSizeBasics = new List<Li_PaperSizeBasic>();
        SqlLi_PaperSizeBasicProvider sqlLi_PaperSizeBasicProvider = new SqlLi_PaperSizeBasicProvider();
        li_PaperSizeBasics = sqlLi_PaperSizeBasicProvider.GetLi_PaperSizeBasicByID(id);
        return li_PaperSizeBasics ;
    }


    public static string  InsertLi_PaperSizeBasic(Li_PaperSizeBasic li_PaperSizeBasic)
    {
        SqlLi_PaperSizeBasicProvider sqlLi_PaperSizeBasicProvider = new SqlLi_PaperSizeBasicProvider();
        return sqlLi_PaperSizeBasicProvider.InsertLi_PaperSizeBasic(li_PaperSizeBasic);
    }


    public static bool UpdateLi_PaperSizeBasic(Li_PaperSizeBasic li_PaperSizeBasic)
    {
        SqlLi_PaperSizeBasicProvider sqlLi_PaperSizeBasicProvider = new SqlLi_PaperSizeBasicProvider();
        return sqlLi_PaperSizeBasicProvider.UpdateLi_PaperSizeBasic(li_PaperSizeBasic);
    }

    public static bool DeleteLi_PaperSizeBasic(int li_PaperSizeBasicID)
    {
        SqlLi_PaperSizeBasicProvider sqlLi_PaperSizeBasicProvider = new SqlLi_PaperSizeBasicProvider();
        return sqlLi_PaperSizeBasicProvider.DeleteLi_PaperSizeBasic(li_PaperSizeBasicID);
    }
}
