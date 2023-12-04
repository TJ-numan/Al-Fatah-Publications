using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_AuthorManager
{
	public Li_AuthorManager()
	{
	}

    public static List<Li_Author> GetAllLi_Authors()
    {
        List<Li_Author> li_Authors = new List<Li_Author>();
        SqlLi_AuthorProvider sqlLi_AuthorProvider = new SqlLi_AuthorProvider();
        li_Authors = sqlLi_AuthorProvider.GetAllLi_Authors();
        return li_Authors;
    }


    public static Li_Author GetLi_AuthorByID(int id)
    {
        Li_Author li_Author = new Li_Author();
        SqlLi_AuthorProvider sqlLi_AuthorProvider = new SqlLi_AuthorProvider();
        li_Author = sqlLi_AuthorProvider.GetLi_AuthorByID(id);
        return li_Author;
    }


    public static int InsertLi_Author(Li_Author li_Author)
    {
        SqlLi_AuthorProvider sqlLi_AuthorProvider = new SqlLi_AuthorProvider();
        return sqlLi_AuthorProvider.InsertLi_Author(li_Author);
    }


    public static bool UpdateLi_Author(Li_Author li_Author)
    {
        SqlLi_AuthorProvider sqlLi_AuthorProvider = new SqlLi_AuthorProvider();
        return sqlLi_AuthorProvider.UpdateLi_Author(li_Author);
    }

    public static bool DeleteLi_Author(int li_AuthorID)
    {
        SqlLi_AuthorProvider sqlLi_AuthorProvider = new SqlLi_AuthorProvider();
        return sqlLi_AuthorProvider.DeleteLi_Author(li_AuthorID);
    }
}
