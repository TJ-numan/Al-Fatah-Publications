using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Book_GManager
{
	public Li_Book_GManager()
	{
	}

    public static List<Li_Book_G> GetAllLi_Book_Gs()
    {
        List<Li_Book_G> li_Book_Gs = new List<Li_Book_G>();
        SqlLi_Book_GProvider sqlLi_Book_GProvider = new SqlLi_Book_GProvider();
        li_Book_Gs = sqlLi_Book_GProvider.GetAllLi_Book_Gs();
        return li_Book_Gs;
    }


    public static List<Li_Book_G> GetLi_Book_GByID(string  id)
    {
        List<Li_Book_G> li_Book_G = new List<Li_Book_G>();
        SqlLi_Book_GProvider sqlLi_Book_GProvider = new SqlLi_Book_GProvider();
        li_Book_G = sqlLi_Book_GProvider.GetLi_Book_GByID(id);
        return li_Book_G;
    }


    public static int InsertLi_Book_G(Li_Book_G li_Book_G)
    {
        SqlLi_Book_GProvider sqlLi_Book_GProvider = new SqlLi_Book_GProvider();
        return sqlLi_Book_GProvider.InsertLi_Book_G(li_Book_G);
    }


    public static bool UpdateLi_Book_G(Li_Book_G li_Book_G)
    {
        SqlLi_Book_GProvider sqlLi_Book_GProvider = new SqlLi_Book_GProvider();
        return sqlLi_Book_GProvider.UpdateLi_Book_G(li_Book_G);
    }

    public static bool DeleteLi_Book_G(int li_Book_GID)
    {
        SqlLi_Book_GProvider sqlLi_Book_GProvider = new SqlLi_Book_GProvider();
        return sqlLi_Book_GProvider.DeleteLi_Book_G(li_Book_GID);
    }


    public static DataSet GetBookGroupByMonth(string fromDate, string toDate  )
    {
        DataSet ds = new DataSet();
        SqlLi_Book_GProvider sqlLi_Book_GProvider = new SqlLi_Book_GProvider();
        ds = sqlLi_Book_GProvider .GetBookGroupByMonth ( fromDate, toDate   );
        return ds;

    }
    public static DataSet GetBookClassByMonth(string fromDate, string toDate, int GroupID )
    {
        DataSet ds = new DataSet();
        SqlLi_Book_GProvider sqlLi_Book_GProvider = new SqlLi_Book_GProvider();
        ds = sqlLi_Book_GProvider .GetBookClassByMonth ( fromDate, toDate ,    GroupID  );
        return ds;

    } 
    public static DataSet GetBookTypeByMonth(string fromDate, string toDate,  int GroupID ,int ClassID )
    {
        DataSet ds = new DataSet();
        SqlLi_Book_GProvider sqlLi_Book_GProvider = new SqlLi_Book_GProvider();
        ds = sqlLi_Book_GProvider.GetBookTypeByMonth(fromDate, toDate, GroupID, ClassID);
        return ds;

    }
}
