using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_DistrictManager
{
	public li_DistrictManager()
	{
	}

    public static List<li_District> GetAll_Districts()
    {
        List<li_District> li_Districts = new List<li_District>();
        Sql_li_DistrictProvider Sql_li_DistrictProvider = new Sql_li_DistrictProvider();
        li_Districts = Sql_li_DistrictProvider.GetAll_Districts();
        return li_Districts;
    }

    public static DataTable GetAll_DistrictsByTerritory(string territoryCode)
    {
       
        Sql_li_DistrictProvider Sql_li_DistrictProvider = new Sql_li_DistrictProvider();
        return Sql_li_DistrictProvider.GetAll_DistrictsByTerritory(territoryCode);
      
    }


    public static DataSet GetAll_DistrictsWithRelation()
    {
       
        Sql_li_DistrictProvider Sql_li_DistrictProvider = new Sql_li_DistrictProvider();
        return   Sql_li_DistrictProvider.GetAll_DistrictsWithRelation();
      
    }


    public static li_District Get_DistrictByDistrictID(int DistrictID)
    {
        li_District li_District = new li_District();
        Sql_li_DistrictProvider Sql_li_DistrictProvider = new Sql_li_DistrictProvider();
        li_District = Sql_li_DistrictProvider.Get_DistrictByDistrictID(DistrictID);
        return li_District;
    }


    public static List < li_District> Get_AllDistrictByTeritoryID(string  TeritiryID)
    {
        List<li_District> li_District = new List<li_District>();
        Sql_li_DistrictProvider Sql_li_DistrictProvider = new Sql_li_DistrictProvider();
        li_District = Sql_li_DistrictProvider.Get_DistrictByTeritoryID(TeritiryID);
        return li_District;
    }

    public static int Insert_District(li_District li_District)
    {
        Sql_li_DistrictProvider Sql_li_DistrictProvider = new Sql_li_DistrictProvider();
        return Sql_li_DistrictProvider.Insert_District(li_District);
    }


    public static bool Update_District(li_District li_District)
    {
        Sql_li_DistrictProvider Sql_li_DistrictProvider = new Sql_li_DistrictProvider();
        return Sql_li_DistrictProvider.Update_District(li_District);
    }

    public static bool Delete_District(int li_DistrictID)
    {
        Sql_li_DistrictProvider Sql_li_DistrictProvider = new Sql_li_DistrictProvider();
        return Sql_li_DistrictProvider.Delete_District(li_DistrictID);
    }
}

