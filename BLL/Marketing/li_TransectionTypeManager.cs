using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_TransectionTypeManager
{
	public Li_TransectionTypeManager()
	{
	}

    public static List<Li_TransectionType> GetAllLi_TransectionTypes()
    {
        List<Li_TransectionType> li_TransectionTypes = new List<Li_TransectionType>();
        SqlLi_TransectionTypeProvider sqlLi_TransectionTypeProvider = new SqlLi_TransectionTypeProvider();
        li_TransectionTypes = sqlLi_TransectionTypeProvider.GetAllLi_TransectionTypes();
        return li_TransectionTypes;
    }


    public static Li_TransectionType GetLi_TransectionTypeByID(int id)
    {
        Li_TransectionType li_TransectionType = new Li_TransectionType();
        SqlLi_TransectionTypeProvider sqlLi_TransectionTypeProvider = new SqlLi_TransectionTypeProvider();
        li_TransectionType = sqlLi_TransectionTypeProvider.GetLi_TransectionTypeByID(id);
        return li_TransectionType;
    }


    public static int InsertLi_TransectionType(Li_TransectionType li_TransectionType)
    {
        SqlLi_TransectionTypeProvider sqlLi_TransectionTypeProvider = new SqlLi_TransectionTypeProvider();
        return sqlLi_TransectionTypeProvider.InsertLi_TransectionType(li_TransectionType);
    }


    public static bool UpdateLi_TransectionType(Li_TransectionType li_TransectionType)
    {
        SqlLi_TransectionTypeProvider sqlLi_TransectionTypeProvider = new SqlLi_TransectionTypeProvider();
        return sqlLi_TransectionTypeProvider.UpdateLi_TransectionType(li_TransectionType);
    }

    public static bool DeleteLi_TransectionType(int li_TransectionTypeID)
    {
        SqlLi_TransectionTypeProvider sqlLi_TransectionTypeProvider = new SqlLi_TransectionTypeProvider();
        return sqlLi_TransectionTypeProvider.DeleteLi_TransectionType(li_TransectionTypeID);
    }
}
