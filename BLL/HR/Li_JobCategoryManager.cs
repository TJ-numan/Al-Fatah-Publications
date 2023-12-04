using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_JobCategoryManager
{
	public Li_JobCategoryManager()
	{
	}

    public static List<Li_JobCategory> GetAllLi_JobCategories()
    {
        List<Li_JobCategory> li_JobCategories = new List<Li_JobCategory>();
        SqlLi_JobCategoryProvider sqlLi_JobCategoryProvider = new SqlLi_JobCategoryProvider();
        li_JobCategories = sqlLi_JobCategoryProvider.GetAllLi_JobCategories();
        return li_JobCategories;
    }


    public static Li_JobCategory GetLi_JobCategoryByID(int id)
    {
        Li_JobCategory li_JobCategory = new Li_JobCategory();
        SqlLi_JobCategoryProvider sqlLi_JobCategoryProvider = new SqlLi_JobCategoryProvider();
        li_JobCategory = sqlLi_JobCategoryProvider.GetLi_JobCategoryByID(id);
        return li_JobCategory;
    }


    public static int InsertLi_JobCategory(Li_JobCategory li_JobCategory)
    {
        SqlLi_JobCategoryProvider sqlLi_JobCategoryProvider = new SqlLi_JobCategoryProvider();
        return sqlLi_JobCategoryProvider.InsertLi_JobCategory(li_JobCategory);
    }


    public static bool UpdateLi_JobCategory(Li_JobCategory li_JobCategory)
    {
        SqlLi_JobCategoryProvider sqlLi_JobCategoryProvider = new SqlLi_JobCategoryProvider();
        return sqlLi_JobCategoryProvider.UpdateLi_JobCategory(li_JobCategory);
    }

    public static bool DeleteLi_JobCategory(int li_JobCategoryID)
    {
        SqlLi_JobCategoryProvider sqlLi_JobCategoryProvider = new SqlLi_JobCategoryProvider();
        return sqlLi_JobCategoryProvider.DeleteLi_JobCategory(li_JobCategoryID);
    }
}
