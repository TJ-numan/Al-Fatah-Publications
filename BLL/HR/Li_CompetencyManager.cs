using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_CompetencyManager
{
	public Li_CompetencyManager()
	{
	}

    public static List<Li_Competency> GetAllLi_Competencies()
    {
        List<Li_Competency> li_Competencies = new List<Li_Competency>();
        SqlLi_CompetencyProvider sqlLi_CompetencyProvider = new SqlLi_CompetencyProvider();
        li_Competencies = sqlLi_CompetencyProvider.GetAllLi_Competencies();
        return li_Competencies;
    }


    public static Li_Competency GetLi_CompetencyByID(int id)
    {
        Li_Competency li_Competency = new Li_Competency();
        SqlLi_CompetencyProvider sqlLi_CompetencyProvider = new SqlLi_CompetencyProvider();
        li_Competency = sqlLi_CompetencyProvider.GetLi_CompetencyByID(id);
        return li_Competency;
    }


    public static int InsertLi_Competency(Li_Competency li_Competency)
    {
        SqlLi_CompetencyProvider sqlLi_CompetencyProvider = new SqlLi_CompetencyProvider();
        return sqlLi_CompetencyProvider.InsertLi_Competency(li_Competency);
    }


    public static bool UpdateLi_Competency(Li_Competency li_Competency)
    {
        SqlLi_CompetencyProvider sqlLi_CompetencyProvider = new SqlLi_CompetencyProvider();
        return sqlLi_CompetencyProvider.UpdateLi_Competency(li_Competency);
    }

    public static bool DeleteLi_Competency(int li_CompetencyID)
    {
        SqlLi_CompetencyProvider sqlLi_CompetencyProvider = new SqlLi_CompetencyProvider();
        return sqlLi_CompetencyProvider.DeleteLi_Competency(li_CompetencyID);
    }
}
