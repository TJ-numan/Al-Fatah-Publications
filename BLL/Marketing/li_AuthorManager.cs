using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;

using System.Xml.Linq;

public class li_AuthorManager
{
	public li_AuthorManager()
	{
	}

    public static List<li_Author> GetAll_Authors()
    {
        List<li_Author> li_Authors = new List<li_Author>();
        Sql_li_AuthorProvider Sql_li_AuthorProvider = new Sql_li_AuthorProvider();
        li_Authors = Sql_li_AuthorProvider.GetAll_Authors();
        return li_Authors;
    }
    public static List<li_Author> GetAll_ComboSourceData_Authors()
    {
        List<li_Author> li_Authors = new List<li_Author>();
        Sql_li_AuthorProvider Sql_li_AuthorProvider = new Sql_li_AuthorProvider();
        li_Authors = Sql_li_AuthorProvider.GetAll_ComboSourceData_Authors();
        return li_Authors;
    }
    

    public static li_Author Get_AuthorByAuthorID(int AuthorID)
    {
        li_Author li_Author = new li_Author();
        Sql_li_AuthorProvider Sql_li_AuthorProvider = new Sql_li_AuthorProvider();
        li_Author = Sql_li_AuthorProvider.Get_AuthorByAuthorID(AuthorID);
        return li_Author;
    }


    public static int Insert_Author(li_Author li_Author)
    {
        Sql_li_AuthorProvider Sql_li_AuthorProvider = new Sql_li_AuthorProvider();
        return Sql_li_AuthorProvider.Insert_Author(li_Author);
    }


    public static bool Update_Author(li_Author li_Author)
    {
        Sql_li_AuthorProvider Sql_li_AuthorProvider = new Sql_li_AuthorProvider();
        return Sql_li_AuthorProvider.Update_Author(li_Author);
    }

    public static bool Delete_Author(int li_AuthorID)
    {
        Sql_li_AuthorProvider Sql_li_AuthorProvider = new Sql_li_AuthorProvider();
        return Sql_li_AuthorProvider.Delete_Author(li_AuthorID);
    }
}

