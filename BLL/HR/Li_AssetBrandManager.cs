using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetBrandManager
{
	public Li_AssetBrandManager()
	{
	}

    public static List<Li_AssetBrand> GetAllLi_AssetBrands()
    {
        List<Li_AssetBrand> li_AssetBrands = new List<Li_AssetBrand>();
        SqlLi_AssetBrandProvider sqlLi_AssetBrandProvider = new SqlLi_AssetBrandProvider();
        li_AssetBrands = sqlLi_AssetBrandProvider.GetAllLi_AssetBrands();
        return li_AssetBrands;
    }


    public static Li_AssetBrand GetLi_AssetBrandByID(int id)
    {
        Li_AssetBrand li_AssetBrand = new Li_AssetBrand();
        SqlLi_AssetBrandProvider sqlLi_AssetBrandProvider = new SqlLi_AssetBrandProvider();
        li_AssetBrand = sqlLi_AssetBrandProvider.GetLi_AssetBrandByID(id);
        return li_AssetBrand;
    }


    public static int InsertLi_AssetBrand(Li_AssetBrand li_AssetBrand)
    {
        SqlLi_AssetBrandProvider sqlLi_AssetBrandProvider = new SqlLi_AssetBrandProvider();
        return sqlLi_AssetBrandProvider.InsertLi_AssetBrand(li_AssetBrand);
    }


    public static bool UpdateLi_AssetBrand(Li_AssetBrand li_AssetBrand)
    {
        SqlLi_AssetBrandProvider sqlLi_AssetBrandProvider = new SqlLi_AssetBrandProvider();
        return sqlLi_AssetBrandProvider.UpdateLi_AssetBrand(li_AssetBrand);
    }

    public static bool DeleteLi_AssetBrand(int li_AssetBrandID)
    {
        SqlLi_AssetBrandProvider sqlLi_AssetBrandProvider = new SqlLi_AssetBrandProvider();
        return sqlLi_AssetBrandProvider.DeleteLi_AssetBrand(li_AssetBrandID);
    }

    public static DataSet GetAllLi_AssetBrandByID(int  BrandID)
    {
        SqlLi_AssetBrandProvider sqlLi_AssetBrandProvider = new SqlLi_AssetBrandProvider();
        return sqlLi_AssetBrandProvider.GetAllLi_AssetBrandByID( BrandID);

    }
}
