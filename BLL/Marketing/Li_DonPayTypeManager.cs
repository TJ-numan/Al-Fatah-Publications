using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DonPayTypeManager
{
	public Li_DonPayTypeManager()
	{
	}

    public static List<Li_DonPayType> GetAllLi_DonPayTypes()
    {
        List<Li_DonPayType> li_DonPayTypes = new List<Li_DonPayType>();
        SqlLi_DonPayTypeProvider sqlLi_DonPayTypeProvider = new SqlLi_DonPayTypeProvider();
        li_DonPayTypes = sqlLi_DonPayTypeProvider.GetAllLi_DonPayTypes();
        return li_DonPayTypes;
    }


    public static Li_DonPayType GetLi_DonPayTypeByID(int id)
    {
        Li_DonPayType li_DonPayType = new Li_DonPayType();
        SqlLi_DonPayTypeProvider sqlLi_DonPayTypeProvider = new SqlLi_DonPayTypeProvider();
        li_DonPayType = sqlLi_DonPayTypeProvider.GetLi_DonPayTypeByID(id);
        return li_DonPayType;
    }


    public static int InsertLi_DonPayType(Li_DonPayType li_DonPayType)
    {
        SqlLi_DonPayTypeProvider sqlLi_DonPayTypeProvider = new SqlLi_DonPayTypeProvider();
        return sqlLi_DonPayTypeProvider.InsertLi_DonPayType(li_DonPayType);
    }


    public static bool UpdateLi_DonPayType(Li_DonPayType li_DonPayType)
    {
        SqlLi_DonPayTypeProvider sqlLi_DonPayTypeProvider = new SqlLi_DonPayTypeProvider();
        return sqlLi_DonPayTypeProvider.UpdateLi_DonPayType(li_DonPayType);
    }

    public static bool DeleteLi_DonPayType(int li_DonPayTypeID)
    {
        SqlLi_DonPayTypeProvider sqlLi_DonPayTypeProvider = new SqlLi_DonPayTypeProvider();
        return sqlLi_DonPayTypeProvider.DeleteLi_DonPayType(li_DonPayTypeID);
    }

    public static DataSet GetAllLi_DonAcountTypes()
    {
        SqlLi_DonPayTypeProvider sqlLi_DonPayTypeProvider = new SqlLi_DonPayTypeProvider();
        return sqlLi_DonPayTypeProvider.GetAllLi_DonAcountTypes();
    }
}
