using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BoardQawmiMadrasahManager
{
	public Li_BoardQawmiMadrasahManager()
	{
	}

    public static List<Li_BoardQawmiMadrasah> GetAllLi_BoardQawmiMadrasahs()
    {
        List<Li_BoardQawmiMadrasah> li_BoardQawmiMadrasahs = new List<Li_BoardQawmiMadrasah>();
        SqlLi_BoardQawmiMadrasahProvider sqlLi_BoardQawmiMadrasahProvider = new SqlLi_BoardQawmiMadrasahProvider();
        li_BoardQawmiMadrasahs = sqlLi_BoardQawmiMadrasahProvider.GetAllLi_BoardQawmiMadrasahs();
        return li_BoardQawmiMadrasahs;
    }


    public static Li_BoardQawmiMadrasah GetLi_BoardQawmiMadrasahByID(int id)
    {
        Li_BoardQawmiMadrasah li_BoardQawmiMadrasah = new Li_BoardQawmiMadrasah();
        SqlLi_BoardQawmiMadrasahProvider sqlLi_BoardQawmiMadrasahProvider = new SqlLi_BoardQawmiMadrasahProvider();
        li_BoardQawmiMadrasah = sqlLi_BoardQawmiMadrasahProvider.GetLi_BoardQawmiMadrasahByID(id);
        return li_BoardQawmiMadrasah;
    }


    public static int InsertLi_BoardQawmiMadrasah(Li_BoardQawmiMadrasah li_BoardQawmiMadrasah)
    {
        SqlLi_BoardQawmiMadrasahProvider sqlLi_BoardQawmiMadrasahProvider = new SqlLi_BoardQawmiMadrasahProvider();
        return sqlLi_BoardQawmiMadrasahProvider.InsertLi_BoardQawmiMadrasah(li_BoardQawmiMadrasah);
    }


    public static bool UpdateLi_BoardQawmiMadrasah(Li_BoardQawmiMadrasah li_BoardQawmiMadrasah)
    {
        SqlLi_BoardQawmiMadrasahProvider sqlLi_BoardQawmiMadrasahProvider = new SqlLi_BoardQawmiMadrasahProvider();
        return sqlLi_BoardQawmiMadrasahProvider.UpdateLi_BoardQawmiMadrasah(li_BoardQawmiMadrasah);
    }

    public static bool DeleteLi_BoardQawmiMadrasah(int li_BoardQawmiMadrasahID)
    {
        SqlLi_BoardQawmiMadrasahProvider sqlLi_BoardQawmiMadrasahProvider = new SqlLi_BoardQawmiMadrasahProvider();
        return sqlLi_BoardQawmiMadrasahProvider.DeleteLi_BoardQawmiMadrasah(li_BoardQawmiMadrasahID);
    }
}
