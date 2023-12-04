using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetCategoryManager
{
	public Li_AssetCategoryManager()
	{
	}

    public static List<Li_AssetCategory> GetAllLi_AssetCategories()
    {
        List<Li_AssetCategory> li_AssetCategories = new List<Li_AssetCategory>();
        SqlLi_AssetCategoryProvider sqlLi_AssetCategoryProvider = new SqlLi_AssetCategoryProvider();
        li_AssetCategories = sqlLi_AssetCategoryProvider.GetAllLi_AssetCategories();
        return li_AssetCategories;
    }


    public static Li_AssetCategory GetLi_AssetCategoryByID(int id)
    {
        Li_AssetCategory li_AssetCategory = new Li_AssetCategory();
        SqlLi_AssetCategoryProvider sqlLi_AssetCategoryProvider = new SqlLi_AssetCategoryProvider();
        li_AssetCategory = sqlLi_AssetCategoryProvider.GetLi_AssetCategoryByID(id);
        return li_AssetCategory;
    }


    public static int InsertLi_AssetCategory(Li_AssetCategory li_AssetCategory)
    {
        SqlLi_AssetCategoryProvider sqlLi_AssetCategoryProvider = new SqlLi_AssetCategoryProvider();
        return sqlLi_AssetCategoryProvider.InsertLi_AssetCategory(li_AssetCategory);
    }


    public static bool UpdateLi_AssetCategory(Li_AssetCategory li_AssetCategory)
    {
        SqlLi_AssetCategoryProvider sqlLi_AssetCategoryProvider = new SqlLi_AssetCategoryProvider();
        return sqlLi_AssetCategoryProvider.UpdateLi_AssetCategory(li_AssetCategory);
    }

    public static bool DeleteLi_AssetCategory(int li_AssetCategoryID)
    {
        SqlLi_AssetCategoryProvider sqlLi_AssetCategoryProvider = new SqlLi_AssetCategoryProvider();
        return sqlLi_AssetCategoryProvider.DeleteLi_AssetCategory(li_AssetCategoryID);
    }

    public static DataSet GetAllLi_AssetCategoryByID(int AssetCatID)
    {
        SqlLi_AssetCategoryProvider sqlLi_AssetCategoryProvider = new SqlLi_AssetCategoryProvider();
        return sqlLi_AssetCategoryProvider.GetAllLi_AssetCategoryByID(AssetCatID);

    }
}
