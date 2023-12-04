using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_RegionManager
{
	public li_RegionManager()
	{
	}

    public static List<li_Region> GetAll_Regions()
    {
        List<li_Region> li_Regions = new List<li_Region>();
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        li_Regions = Sql_li_RegionProvider.GetAll_Regions();
        return li_Regions;
    }


    public static List<li_LibraryInformation> GetAll_ComboBox_LibraryInformations(bool RSM, bool ASM, bool TSO, int RegionID, int AreaID, string TerritoryID)
    {
        List<li_LibraryInformation> li_LibraryInformations = new List<li_LibraryInformation>();
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        li_LibraryInformations = Sql_li_LibraryInformationProvider.GetAll_ComboBox_LibraryInformations();
        return li_LibraryInformations;
    }


    public static List<li_Region> GetComboSourceData_Regions(int UserID)
    {
        List<li_Region> li_Regions = new List<li_Region>();
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        li_Regions = Sql_li_RegionProvider.GetComboSourceData_Regions(UserID);
        return li_Regions;
    }



    public static li_Region Get_RegionByRegionID(int RegionID)
    {
        li_Region li_Region = new li_Region();
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        li_Region = Sql_li_RegionProvider.Get_RegionByRegionID(RegionID);
        return li_Region;
    }


    public static int Insert_Region(li_Region li_Region)
    {
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        return Sql_li_RegionProvider.Insert_Region(li_Region);
    }


    public static bool Update_Region(li_Region li_Region)
    {
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        return Sql_li_RegionProvider.Update_Region(li_Region);
    }

    public static bool Delete_Region(int li_RegionID)
    {
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        return Sql_li_RegionProvider.Delete_Region(li_RegionID);
    }

    public static DataSet GetRegionByUser(int UserID)
    {
        DataSet ds = new DataSet();
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        ds = Sql_li_RegionProvider.GetRegionByUser(UserID);
        return ds;
    }

    public static DataSet GetRegion()
    {
        DataSet ds = new DataSet();
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        ds = Sql_li_RegionProvider.GetRegion();
        return ds;
    }

    public static DataSet GetRegionById(string regionId)
    {
        DataSet ds = new DataSet();
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        ds = Sql_li_RegionProvider.GetRegionbyId(regionId);
        return ds;
    }

    public static DataSet Getddl_Region()
    {
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        DataSet ds = new DataSet();
        ds = Sql_li_RegionProvider.Getddl_Region();
        return ds;
    }

    public static DataSet GetRegionByRegionMainId(string regionMainId)
    {
        DataSet ds = new DataSet();
        Sql_li_RegionProvider Sql_li_RegionProvider = new Sql_li_RegionProvider();
        ds = Sql_li_RegionProvider.GetRegionbyRegionMainId(regionMainId);
        return ds;
    }
    public static List<li_Region> Get_AllRegion()
    {
        Sql_li_RegionProvider sqlLi_RegionProvider = new Sql_li_RegionProvider();
        return sqlLi_RegionProvider.Get_AllRegion();
    }
}

