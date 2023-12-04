using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_LibraryOwnerManager
{
	public li_LibraryOwnerManager()
	{
	}

    public static List<li_LibraryOwner> GetAll_LibraryOwners()
    {
        List<li_LibraryOwner> li_LibraryOwners = new List<li_LibraryOwner>();
        Sql_li_LibraryOwnerProvider Sql_li_LibraryOwnerProvider = new Sql_li_LibraryOwnerProvider();
        li_LibraryOwners = Sql_li_LibraryOwnerProvider.GetAll_LibraryOwners();
        return li_LibraryOwners;
    }


    public static li_LibraryOwner Get_LibraryOwnerByLibraryOwnerID(string LibraryOwnerID)
    {
        li_LibraryOwner li_LibraryOwner = new li_LibraryOwner();
        Sql_li_LibraryOwnerProvider Sql_li_LibraryOwnerProvider = new Sql_li_LibraryOwnerProvider();
        li_LibraryOwner = Sql_li_LibraryOwnerProvider.Get_LibraryOwnerByLibraryOwnerID(LibraryOwnerID);
        return li_LibraryOwner;
    }


    public static string    Insert_LibraryOwner(li_LibraryOwner li_LibraryOwner)
    {
        Sql_li_LibraryOwnerProvider Sql_li_LibraryOwnerProvider = new Sql_li_LibraryOwnerProvider();
      string ID =   Sql_li_LibraryOwnerProvider.Insert_LibraryOwner(li_LibraryOwner);
      return ID;
    }


    public static bool Update_LibraryOwner(li_LibraryOwner li_LibraryOwner)
    {
        Sql_li_LibraryOwnerProvider Sql_li_LibraryOwnerProvider = new Sql_li_LibraryOwnerProvider();
        return Sql_li_LibraryOwnerProvider.Update_LibraryOwner(li_LibraryOwner);
    }

    public static bool Delete_LibraryOwner(int li_LibraryOwnerID)
    {
        Sql_li_LibraryOwnerProvider Sql_li_LibraryOwnerProvider = new Sql_li_LibraryOwnerProvider();
        return Sql_li_LibraryOwnerProvider.Delete_LibraryOwner(li_LibraryOwnerID);
    }


    public static DataSet GetALLLibraryOwnerInformation()
    {
        DataSet ds = new DataSet();
        Sql_li_LibraryOwnerProvider Sql_li_LibraryOwnerProvider = new Sql_li_LibraryOwnerProvider();
        ds = Sql_li_LibraryOwnerProvider.GetALLLibraryOwnerInformation();
        return ds;
    }
}

