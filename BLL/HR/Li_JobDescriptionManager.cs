using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobDescriptionManager
{
	public Li_JobDescriptionManager()
	{
	}

    public static List<Li_JobDescription> GetAllLi_JobDescriptions()
    {
        List<Li_JobDescription> li_JobDescriptions = new List<Li_JobDescription>();
        SqlLi_JobDescriptionProvider sqlLi_JobDescriptionProvider = new SqlLi_JobDescriptionProvider();
        li_JobDescriptions = sqlLi_JobDescriptionProvider.GetAllLi_JobDescriptions();
        return li_JobDescriptions;
    }


    public static Li_JobDescription GetLi_JobDescriptionByID(int id)
    {
        Li_JobDescription li_JobDescription = new Li_JobDescription();
        SqlLi_JobDescriptionProvider sqlLi_JobDescriptionProvider = new SqlLi_JobDescriptionProvider();
        li_JobDescription = sqlLi_JobDescriptionProvider.GetLi_JobDescriptionByID(id);
        return li_JobDescription;
    }


    public static int InsertLi_JobDescription(Li_JobDescription li_JobDescription)
    {
        SqlLi_JobDescriptionProvider sqlLi_JobDescriptionProvider = new SqlLi_JobDescriptionProvider();
        return sqlLi_JobDescriptionProvider.InsertLi_JobDescription(li_JobDescription);
    }


    public static bool UpdateLi_JobDescription(Li_JobDescription li_JobDescription)
    {
        SqlLi_JobDescriptionProvider sqlLi_JobDescriptionProvider = new SqlLi_JobDescriptionProvider();
        return sqlLi_JobDescriptionProvider.UpdateLi_JobDescription(li_JobDescription);
    }

    public static bool DeleteLi_JobDescription(int li_JobDescriptionID)
    {
        SqlLi_JobDescriptionProvider sqlLi_JobDescriptionProvider = new SqlLi_JobDescriptionProvider();
        return sqlLi_JobDescriptionProvider.DeleteLi_JobDescription(li_JobDescriptionID);
    }
}
