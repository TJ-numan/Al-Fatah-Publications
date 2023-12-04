using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_EditionManager
{
	public li_EditionManager()
	{
	}

    public static List<li_Edition> GetAll_Editions()
    {
        List<li_Edition> li_Editions = new List<li_Edition>();
        Sql_li_EditionProvider Sql_li_EditionProvider = new Sql_li_EditionProvider();
        li_Editions = Sql_li_EditionProvider.GetAll_Editions();
        return li_Editions;
    }


    public static li_Edition Get_EditionByEditonID(int EditonID)
    {
        li_Edition li_Edition = new li_Edition();
        Sql_li_EditionProvider Sql_li_EditionProvider = new Sql_li_EditionProvider();
        li_Edition = Sql_li_EditionProvider.Get_EditionByEditonID(EditonID);
        return li_Edition;
    }


    public static int Insert_Edition(li_Edition li_Edition)
    {
        Sql_li_EditionProvider Sql_li_EditionProvider = new Sql_li_EditionProvider();
        return Sql_li_EditionProvider.Insert_Edition(li_Edition);
    }


    public static bool Update_Edition(li_Edition li_Edition)
    {
        Sql_li_EditionProvider Sql_li_EditionProvider = new Sql_li_EditionProvider();
        return Sql_li_EditionProvider.Update_Edition(li_Edition);
    }

    public static bool Delete_Edition(int li_EditionID)
    {
        Sql_li_EditionProvider Sql_li_EditionProvider = new Sql_li_EditionProvider();
        return Sql_li_EditionProvider.Delete_Edition(li_EditionID);
    }

    public static string getDistinctEditionByBookID(string BookID)
    {
        Sql_li_EditionProvider Sql_li_EditionProvider = new Sql_li_EditionProvider();
        return Sql_li_EditionProvider.getDistinctEditionByBookID(  BookID);
    }
  public static string getPlanEditionByBookID(string BookID)
    {
        Sql_li_EditionProvider Sql_li_EditionProvider = new Sql_li_EditionProvider();
        return Sql_li_EditionProvider.getPlanEditionByBookID(  BookID);
    }

}

