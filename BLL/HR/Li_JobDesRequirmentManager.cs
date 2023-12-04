using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDesRequirmentManager
{
	public Li_JobDesRequirmentManager()
	{
	}

    public static List<Li_JobDesRequirment> GetAllLi_JobDesRequirments()
    {
        List<Li_JobDesRequirment> li_JobDesRequirments = new List<Li_JobDesRequirment>();
        SqlLi_JobDesRequirmentProvider sqlLi_JobDesRequirmentProvider = new SqlLi_JobDesRequirmentProvider();
        li_JobDesRequirments = sqlLi_JobDesRequirmentProvider.GetAllLi_JobDesRequirments();
        return li_JobDesRequirments;
    }


    public static Li_JobDesRequirment GetLi_JobDesRequirmentByID(int id)
    {
        Li_JobDesRequirment li_JobDesRequirment = new Li_JobDesRequirment();
        SqlLi_JobDesRequirmentProvider sqlLi_JobDesRequirmentProvider = new SqlLi_JobDesRequirmentProvider();
        li_JobDesRequirment = sqlLi_JobDesRequirmentProvider.GetLi_JobDesRequirmentByID(id);
        return li_JobDesRequirment;
    }


    public static int InsertLi_JobDesRequirment(Li_JobDesRequirment li_JobDesRequirment)
    {
        SqlLi_JobDesRequirmentProvider sqlLi_JobDesRequirmentProvider = new SqlLi_JobDesRequirmentProvider();
        return sqlLi_JobDesRequirmentProvider.InsertLi_JobDesRequirment(li_JobDesRequirment);
    }


    public static bool UpdateLi_JobDesRequirment(Li_JobDesRequirment li_JobDesRequirment)
    {
        SqlLi_JobDesRequirmentProvider sqlLi_JobDesRequirmentProvider = new SqlLi_JobDesRequirmentProvider();
        return sqlLi_JobDesRequirmentProvider.UpdateLi_JobDesRequirment(li_JobDesRequirment);
    }

    public static bool DeleteLi_JobDesRequirment(int li_JobDesRequirmentID)
    {
        SqlLi_JobDesRequirmentProvider sqlLi_JobDesRequirmentProvider = new SqlLi_JobDesRequirmentProvider();
        return sqlLi_JobDesRequirmentProvider.DeleteLi_JobDesRequirment(li_JobDesRequirmentID);
    }
}
