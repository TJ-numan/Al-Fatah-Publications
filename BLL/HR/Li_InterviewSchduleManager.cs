using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_InterviewSchduleManager
{
	public Li_InterviewSchduleManager()
	{
	}

    public static List<Li_InterviewSchdule> GetAllLi_InterviewSchdules()
    {
        List<Li_InterviewSchdule> li_InterviewSchdules = new List<Li_InterviewSchdule>();
        SqlLi_InterviewSchduleProvider sqlLi_InterviewSchduleProvider = new SqlLi_InterviewSchduleProvider();
        li_InterviewSchdules = sqlLi_InterviewSchduleProvider.GetAllLi_InterviewSchdules();
        return li_InterviewSchdules;
    }


    public static Li_InterviewSchdule GetLi_InterviewSchduleByID(int id)
    {
        Li_InterviewSchdule li_InterviewSchdule = new Li_InterviewSchdule();
        SqlLi_InterviewSchduleProvider sqlLi_InterviewSchduleProvider = new SqlLi_InterviewSchduleProvider();
        li_InterviewSchdule = sqlLi_InterviewSchduleProvider.GetLi_InterviewSchduleByID(id);
        return li_InterviewSchdule;
    }


    public static int InsertLi_InterviewSchdule(Li_InterviewSchdule li_InterviewSchdule)
    {
        SqlLi_InterviewSchduleProvider sqlLi_InterviewSchduleProvider = new SqlLi_InterviewSchduleProvider();
        return sqlLi_InterviewSchduleProvider.InsertLi_InterviewSchdule(li_InterviewSchdule);
    }


    public static bool UpdateLi_InterviewSchdule(Li_InterviewSchdule li_InterviewSchdule)
    {
        SqlLi_InterviewSchduleProvider sqlLi_InterviewSchduleProvider = new SqlLi_InterviewSchduleProvider();
        return sqlLi_InterviewSchduleProvider.UpdateLi_InterviewSchdule(li_InterviewSchdule);
    }

    public static bool DeleteLi_InterviewSchdule(int li_InterviewSchduleID)
    {
        SqlLi_InterviewSchduleProvider sqlLi_InterviewSchduleProvider = new SqlLi_InterviewSchduleProvider();
        return sqlLi_InterviewSchduleProvider.DeleteLi_InterviewSchdule(li_InterviewSchduleID);
    }
}
