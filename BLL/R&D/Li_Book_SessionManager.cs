using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Book_SessionManager
{
	public Li_Book_SessionManager()
	{
	}

    public static List<Li_Book_Session> GetAllLi_Book_Sessions()
    {
        List<Li_Book_Session> li_Book_Sessions = new List<Li_Book_Session>();
        SqlLi_Book_SessionProvider sqlLi_Book_SessionProvider = new SqlLi_Book_SessionProvider();
        li_Book_Sessions = sqlLi_Book_SessionProvider.GetAllLi_Book_Sessions();
        return li_Book_Sessions;
    }


    public static Li_Book_Session GetLi_Book_SessionByID(int id)
    {
        Li_Book_Session li_Book_Session = new Li_Book_Session();
        SqlLi_Book_SessionProvider sqlLi_Book_SessionProvider = new SqlLi_Book_SessionProvider();
        li_Book_Session = sqlLi_Book_SessionProvider.GetLi_Book_SessionByID(id);
        return li_Book_Session;
    }


    public static int InsertLi_Book_Session(Li_Book_Session li_Book_Session)
    {
        SqlLi_Book_SessionProvider sqlLi_Book_SessionProvider = new SqlLi_Book_SessionProvider();
        return sqlLi_Book_SessionProvider.InsertLi_Book_Session(li_Book_Session);
    }


    public static bool UpdateLi_Book_Session(Li_Book_Session li_Book_Session)
    {
        SqlLi_Book_SessionProvider sqlLi_Book_SessionProvider = new SqlLi_Book_SessionProvider();
        return sqlLi_Book_SessionProvider.UpdateLi_Book_Session(li_Book_Session);
    }

    public static bool DeleteLi_Book_Session(int li_Book_SessionID)
    {
        SqlLi_Book_SessionProvider sqlLi_Book_SessionProvider = new SqlLi_Book_SessionProvider();
        return sqlLi_Book_SessionProvider.DeleteLi_Book_Session(li_Book_SessionID);
    }

   


}
