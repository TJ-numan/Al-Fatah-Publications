using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Book_PartManager
{
	public Li_Book_PartManager()
	{
	}

    public static List<Li_Book_Part> GetAllLi_Book_Parts()
    {
        List<Li_Book_Part> li_Book_Parts = new List<Li_Book_Part>();
        SqlLi_Book_PartProvider sqlLi_Book_PartProvider = new SqlLi_Book_PartProvider();
        li_Book_Parts = sqlLi_Book_PartProvider.GetAllLi_Book_Parts();
        return li_Book_Parts;
    }


    public static Li_Book_Part GetLi_Book_PartByID(int id)
    {
        Li_Book_Part li_Book_Part = new Li_Book_Part();
        SqlLi_Book_PartProvider sqlLi_Book_PartProvider = new SqlLi_Book_PartProvider();
        li_Book_Part = sqlLi_Book_PartProvider.GetLi_Book_PartByID(id);
        return li_Book_Part;
    }


    public static int InsertLi_Book_Part(Li_Book_Part li_Book_Part)
    {
        SqlLi_Book_PartProvider sqlLi_Book_PartProvider = new SqlLi_Book_PartProvider();
        return sqlLi_Book_PartProvider.InsertLi_Book_Part(li_Book_Part);
    }


    public static bool UpdateLi_Book_Part(Li_Book_Part li_Book_Part)
    {
        SqlLi_Book_PartProvider sqlLi_Book_PartProvider = new SqlLi_Book_PartProvider();
        return sqlLi_Book_PartProvider.UpdateLi_Book_Part(li_Book_Part);
    }

    public static bool DeleteLi_Book_Part(int li_Book_PartID)
    {
        SqlLi_Book_PartProvider sqlLi_Book_PartProvider = new SqlLi_Book_PartProvider();
        return sqlLi_Book_PartProvider.DeleteLi_Book_Part(li_Book_PartID);
    }
}
