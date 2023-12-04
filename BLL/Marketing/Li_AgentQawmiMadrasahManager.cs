using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_AgentQawmiMadrasahManager
{
	public Li_AgentQawmiMadrasahManager()
	{
	}

    public static List<Li_AgentQawmiMadrasah> GetAllLi_AgentQawmiMadrasahs()
    {
        List<Li_AgentQawmiMadrasah> li_AgentQawmiMadrasahs = new List<Li_AgentQawmiMadrasah>();
        SqlLi_AgentQawmiMadrasahProvider sqlLi_AgentQawmiMadrasahProvider = new SqlLi_AgentQawmiMadrasahProvider();
        li_AgentQawmiMadrasahs = sqlLi_AgentQawmiMadrasahProvider.GetAllLi_AgentQawmiMadrasahs();
        return li_AgentQawmiMadrasahs;
    }


    public static Li_AgentQawmiMadrasah GetLi_AgentQawmiMadrasahByID(int id)
    {
        Li_AgentQawmiMadrasah li_AgentQawmiMadrasah = new Li_AgentQawmiMadrasah();
        SqlLi_AgentQawmiMadrasahProvider sqlLi_AgentQawmiMadrasahProvider = new SqlLi_AgentQawmiMadrasahProvider();
        li_AgentQawmiMadrasah = sqlLi_AgentQawmiMadrasahProvider.GetLi_AgentQawmiMadrasahByID(id);
        return li_AgentQawmiMadrasah;
    }


    public static int InsertLi_AgentQawmiMadrasah(Li_AgentQawmiMadrasah li_AgentQawmiMadrasah)
    {
        SqlLi_AgentQawmiMadrasahProvider sqlLi_AgentQawmiMadrasahProvider = new SqlLi_AgentQawmiMadrasahProvider();
        return sqlLi_AgentQawmiMadrasahProvider.InsertLi_AgentQawmiMadrasah(li_AgentQawmiMadrasah);
    }


    public static bool UpdateLi_AgentQawmiMadrasah(Li_AgentQawmiMadrasah li_AgentQawmiMadrasah)
    {
        SqlLi_AgentQawmiMadrasahProvider sqlLi_AgentQawmiMadrasahProvider = new SqlLi_AgentQawmiMadrasahProvider();
        return sqlLi_AgentQawmiMadrasahProvider.UpdateLi_AgentQawmiMadrasah(li_AgentQawmiMadrasah);
    }

    public static bool DeleteLi_AgentQawmiMadrasah(int li_AgentQawmiMadrasahID)
    {
        SqlLi_AgentQawmiMadrasahProvider sqlLi_AgentQawmiMadrasahProvider = new SqlLi_AgentQawmiMadrasahProvider();
        return sqlLi_AgentQawmiMadrasahProvider.DeleteLi_AgentQawmiMadrasah(li_AgentQawmiMadrasahID);
    }
}
