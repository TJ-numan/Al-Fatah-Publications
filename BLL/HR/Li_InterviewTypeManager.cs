using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_InterviewTypeManager
{
	public Li_InterviewTypeManager()
	{
	}

    public static List<Li_InterviewType> GetAllLi_InterviewTypes()
    {
        List<Li_InterviewType> li_InterviewTypes = new List<Li_InterviewType>();
        SqlLi_InterviewTypeProvider sqlLi_InterviewTypeProvider = new SqlLi_InterviewTypeProvider();
        li_InterviewTypes = sqlLi_InterviewTypeProvider.GetAllLi_InterviewTypes();
        return li_InterviewTypes;
    }


    public static Li_InterviewType GetLi_InterviewTypeByID(int id)
    {
        Li_InterviewType li_InterviewType = new Li_InterviewType();
        SqlLi_InterviewTypeProvider sqlLi_InterviewTypeProvider = new SqlLi_InterviewTypeProvider();
        li_InterviewType = sqlLi_InterviewTypeProvider.GetLi_InterviewTypeByID(id);
        return li_InterviewType;
    }


    public static int InsertLi_InterviewType(Li_InterviewType li_InterviewType)
    {
        SqlLi_InterviewTypeProvider sqlLi_InterviewTypeProvider = new SqlLi_InterviewTypeProvider();
        return sqlLi_InterviewTypeProvider.InsertLi_InterviewType(li_InterviewType);
    }


    public static bool UpdateLi_InterviewType(Li_InterviewType li_InterviewType)
    {
        SqlLi_InterviewTypeProvider sqlLi_InterviewTypeProvider = new SqlLi_InterviewTypeProvider();
        return sqlLi_InterviewTypeProvider.UpdateLi_InterviewType(li_InterviewType);
    }

    public static bool DeleteLi_InterviewType(int li_InterviewTypeID)
    {
        SqlLi_InterviewTypeProvider sqlLi_InterviewTypeProvider = new SqlLi_InterviewTypeProvider();
        return sqlLi_InterviewTypeProvider.DeleteLi_InterviewType(li_InterviewTypeID);
    }
}
