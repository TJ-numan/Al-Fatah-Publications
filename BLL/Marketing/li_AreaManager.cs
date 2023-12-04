using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_AreaManager
{
	public li_AreaManager()
	{
	}

    public static List<li_Area> GetAll_Areas()
    {
        List<li_Area> li_Areas = new List<li_Area>();
        Sql_li_AreaProvider Sql_li_AreaProvider = new Sql_li_AreaProvider();
        li_Areas = Sql_li_AreaProvider.GetAll_Areas();
        return li_Areas;
    }

    public static DataSet GetAll_AreasWithRelation()
    {
        
        Sql_li_AreaProvider Sql_li_AreaProvider = new Sql_li_AreaProvider();
       return  Sql_li_AreaProvider.GetAll_AreasWithRelation();
        
    }


    public static li_Area Get_AreaByAreaID(int AreaID)
    {
        li_Area li_Area = new li_Area();
        Sql_li_AreaProvider Sql_li_AreaProvider = new Sql_li_AreaProvider();
        li_Area = Sql_li_AreaProvider.Get_AreaByAreaID(AreaID);
        return li_Area;
    }
    public static List<li_Area> Get_AreaByRegionID(int RegionID)
    {
        List<li_Area> li_Areas = new List<li_Area>();
        Sql_li_AreaProvider Sql_li_AreaProvider = new Sql_li_AreaProvider();
        li_Areas = Sql_li_AreaProvider.Get_AreaByRegionID(RegionID);
        return li_Areas;
    }
  
    public static int Insert_Area(li_Area li_Area)
    {
        Sql_li_AreaProvider Sql_li_AreaProvider = new Sql_li_AreaProvider();
        return Sql_li_AreaProvider.Insert_Area(li_Area);
    }


    public static bool Update_Area(li_Area li_Area)
    {
        Sql_li_AreaProvider Sql_li_AreaProvider = new Sql_li_AreaProvider();
        return Sql_li_AreaProvider.Update_Area(li_Area);
    }

    public static bool Delete_Area(int li_AreaID)
    {
        Sql_li_AreaProvider Sql_li_AreaProvider = new Sql_li_AreaProvider();
        return Sql_li_AreaProvider.Delete_Area(li_AreaID);
    }
}

