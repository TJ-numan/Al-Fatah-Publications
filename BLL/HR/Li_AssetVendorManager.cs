using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_AssetVendorManager
{
	public Li_AssetVendorManager()
	{
	}

    public static List<Li_AssetVendor> GetAllLi_AssetVendors()
    {
        List<Li_AssetVendor> li_AssetVendors = new List<Li_AssetVendor>();
        SqlLi_AssetVendorProvider sqlLi_AssetVendorProvider = new SqlLi_AssetVendorProvider();
        li_AssetVendors = sqlLi_AssetVendorProvider.GetAllLi_AssetVendors();
        return li_AssetVendors;
    }


    public static Li_AssetVendor GetLi_AssetVendorByID(int id)
    {
        Li_AssetVendor li_AssetVendor = new Li_AssetVendor();
        SqlLi_AssetVendorProvider sqlLi_AssetVendorProvider = new SqlLi_AssetVendorProvider();
        li_AssetVendor = sqlLi_AssetVendorProvider.GetLi_AssetVendorByID(id);
        return li_AssetVendor;
    }


    public static int InsertLi_AssetVendor(Li_AssetVendor li_AssetVendor)
    {
        SqlLi_AssetVendorProvider sqlLi_AssetVendorProvider = new SqlLi_AssetVendorProvider();
        return sqlLi_AssetVendorProvider.InsertLi_AssetVendor(li_AssetVendor);
    }


    public static bool UpdateLi_AssetVendor(Li_AssetVendor li_AssetVendor)
    {
        SqlLi_AssetVendorProvider sqlLi_AssetVendorProvider = new SqlLi_AssetVendorProvider();
        return sqlLi_AssetVendorProvider.UpdateLi_AssetVendor(li_AssetVendor);
    }

    public static bool DeleteLi_AssetVendor(int li_AssetVendorID)
    {
        SqlLi_AssetVendorProvider sqlLi_AssetVendorProvider = new SqlLi_AssetVendorProvider();
        return sqlLi_AssetVendorProvider.DeleteLi_AssetVendor(li_AssetVendorID);
    }

    public static DataSet GetAllLi_AssetVendorByID(int AssetVendorID)
    {
        SqlLi_AssetVendorProvider sqlLi_AssetVendorProvider = new SqlLi_AssetVendorProvider();
        return sqlLi_AssetVendorProvider.GetAllLi_AssetVendorByID(AssetVendorID);

    }
}
