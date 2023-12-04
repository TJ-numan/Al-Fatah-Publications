using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EducationLevelManager
{
	public Li_EducationLevelManager()
	{
	}

    public static List<Li_EducationLevel> GetAllLi_EducationLevels()
    {
        List<Li_EducationLevel> li_EducationLevels = new List<Li_EducationLevel>();
        SqlLi_EducationLevelProvider sqlLi_EducationLevelProvider = new SqlLi_EducationLevelProvider();
        li_EducationLevels = sqlLi_EducationLevelProvider.GetAllLi_EducationLevels();
        return li_EducationLevels;
    }


    public static Li_EducationLevel GetLi_EducationLevelByID(int id)
    {
        Li_EducationLevel li_EducationLevel = new Li_EducationLevel();
        SqlLi_EducationLevelProvider sqlLi_EducationLevelProvider = new SqlLi_EducationLevelProvider();
        li_EducationLevel = sqlLi_EducationLevelProvider.GetLi_EducationLevelByID(id);
        return li_EducationLevel;
    }


    public static int InsertLi_EducationLevel(Li_EducationLevel li_EducationLevel)
    {
        SqlLi_EducationLevelProvider sqlLi_EducationLevelProvider = new SqlLi_EducationLevelProvider();
        return sqlLi_EducationLevelProvider.InsertLi_EducationLevel(li_EducationLevel);
    }


    public static bool UpdateLi_EducationLevel(Li_EducationLevel li_EducationLevel)
    {
        SqlLi_EducationLevelProvider sqlLi_EducationLevelProvider = new SqlLi_EducationLevelProvider();
        return sqlLi_EducationLevelProvider.UpdateLi_EducationLevel(li_EducationLevel);
    }

    public static bool DeleteLi_EducationLevel(int li_EducationLevelID)
    {
        SqlLi_EducationLevelProvider sqlLi_EducationLevelProvider = new SqlLi_EducationLevelProvider();
        return sqlLi_EducationLevelProvider.DeleteLi_EducationLevel(li_EducationLevelID);
    }
}
