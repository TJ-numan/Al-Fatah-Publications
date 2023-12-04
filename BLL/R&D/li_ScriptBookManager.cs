using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_ScriptBookManager
{
	public Li_ScriptBookManager()
	{
	}

    public static List<Li_ScriptBook> GetAllLi_ScriptBooks()
    {
        List<Li_ScriptBook> li_ScriptBooks = new List<Li_ScriptBook>();
        SqlLi_ScriptBookProvider sqlLi_ScriptBookProvider = new SqlLi_ScriptBookProvider();
        li_ScriptBooks = sqlLi_ScriptBookProvider.GetAllLi_ScriptBooks();
        return li_ScriptBooks;
    }


    public static Li_ScriptBook GetLi_ScriptBookByID(int id)
    {
        Li_ScriptBook li_ScriptBook = new Li_ScriptBook();
        SqlLi_ScriptBookProvider sqlLi_ScriptBookProvider = new SqlLi_ScriptBookProvider();
        li_ScriptBook = sqlLi_ScriptBookProvider.GetLi_ScriptBookByID(id);
        return li_ScriptBook;
    }


    public static int InsertLi_ScriptBook(Li_ScriptBook li_ScriptBook)
    {
        SqlLi_ScriptBookProvider sqlLi_ScriptBookProvider = new SqlLi_ScriptBookProvider();
        return sqlLi_ScriptBookProvider.InsertLi_ScriptBook(li_ScriptBook);
    }


    public static bool UpdateLi_ScriptBook(Li_ScriptBook li_ScriptBook)
    {
        SqlLi_ScriptBookProvider sqlLi_ScriptBookProvider = new SqlLi_ScriptBookProvider();
        return sqlLi_ScriptBookProvider.UpdateLi_ScriptBook(li_ScriptBook);
    }

    public static bool DeleteLi_ScriptBook(int li_ScriptBookID)
    {
        SqlLi_ScriptBookProvider sqlLi_ScriptBookProvider = new SqlLi_ScriptBookProvider();
        return sqlLi_ScriptBookProvider.DeleteLi_ScriptBook(li_ScriptBookID);
    }
}
