using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using Common;
using Common.Marketing;

public class li_LibraryInformationManager
{
	public li_LibraryInformationManager()
	{
	}

    public static List<li_LibraryInformation> GetAll_LibraryInformations(bool IsQawmi)
    {
        List<li_LibraryInformation> li_LibraryInformations = new List<li_LibraryInformation>();
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        li_LibraryInformations = Sql_li_LibraryInformationProvider.GetAll_LibraryInformations(IsQawmi );
        return li_LibraryInformations;
    }

    public static List<li_LibraryInformation> GetAll_ComboBox_LibraryInformations(bool RSM, bool ASM, bool TSO, int RegionID, int AreaID, string TerritoryID)
    {
        List<li_LibraryInformation> li_LibraryInformations = new List<li_LibraryInformation>();
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        li_LibraryInformations = Sql_li_LibraryInformationProvider.GetAll_ComboBox_LibraryInformations(RSM, ASM, TSO, RegionID, AreaID, TerritoryID);
        return li_LibraryInformations;
    }

    public static List<li_LibraryInformation> GetAll_ComboBox_LibraryInformations()
    {
        List<li_LibraryInformation> li_LibraryInformations = new List<li_LibraryInformation>();
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        li_LibraryInformations = Sql_li_LibraryInformationProvider.GetAll_ComboBox_LibraryInformations();
        return li_LibraryInformations;
    }

    public static List<li_LibraryInformation> GetAll_ComboBox_LibraryInformationsByTerritory( string TerID)
    {
        List<li_LibraryInformation> li_LibraryInformations = new List<li_LibraryInformation>();
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        li_LibraryInformations = Sql_li_LibraryInformationProvider.GetAll_ComboBox_LibraryInformationsByTerritoryID(  TerID);
        return li_LibraryInformations;
    }

    public static List<li_LibraryInformation> GetAll_ComboBox_LibraryInformations(int UserID)
    {
        List<li_LibraryInformation> li_LibraryInformations = new List<li_LibraryInformation>();
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        li_LibraryInformations = Sql_li_LibraryInformationProvider.GetAll_ComboBox_LibraryInformations(UserID);
        return li_LibraryInformations;
    }
  
    public static li_LibraryInformation Get_LibraryInformationByLibraryID(int LibraryID)
    {
        li_LibraryInformation li_LibraryInformation = new li_LibraryInformation();
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        li_LibraryInformation = Sql_li_LibraryInformationProvider.Get_LibraryInformationByLibraryID(LibraryID);
        return li_LibraryInformation;
    }


    public static string  Insert_LibraryInformation(li_LibraryInformation li_LibraryInformation)
    {
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
      string ID =    Sql_li_LibraryInformationProvider.Insert_LibraryInformation(li_LibraryInformation);
      return ID;
    }
    public static bool Update_LibraryOpeningBalance(li_LibraryInformation li_LibraryInformation)
    {
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        return Sql_li_LibraryInformationProvider.Update_LibraryOpeningBalance(li_LibraryInformation);
    }

    public static bool Update_LibraryInformation(li_LibraryInformation li_LibraryInformation)
    {
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        return Sql_li_LibraryInformationProvider.Update_LibraryInformation(li_LibraryInformation);
    }

    public static bool Delete_LibraryInformation(string  li_LibraryInformationID,int userid)
    {
        li_libraryInformationProvider Sql_li_LibraryInformationProvider = new li_libraryInformationProvider();
        return Sql_li_LibraryInformationProvider.Delete_LibraryInformation(li_LibraryInformationID,userid);
    }

    public static DataSet GetSearchLibraryInformation(string LibraryName)
    {
        DataSet ds = new DataSet();
        li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
        ds = SearchLibraryInformation.GetSearchLibraryInformation(LibraryName);
        return ds;
    }

    public static DataSet GetALLLibraryInformation(string LibraryName,string ID)
    {
        DataSet ds = new DataSet();
        li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
        ds = SearchLibraryInformation.GetALLLibraryInformation(LibraryName,ID);
        return ds;
    }

    public static DataSet GetALLLibraryInformationByLibraryID(string libID)
    {
        DataSet ds = new DataSet();
        li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
        ds = SearchLibraryInformation.GetALLLibraryInformationByLibraryID(libID);
        return ds;
    }
    public static DataSet GetLibraryInformationByLibraryIDForEdit(string libID)
    {
        DataSet ds = new DataSet();
        li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
        ds = SearchLibraryInformation.GetLibraryInformationByLibraryIDForEdit(libID);
        return ds;
    }
    
    public static DataSet GetLibraryChalanReturnByLibraryID(string libID)
    {
        DataSet ds = new DataSet();
        li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
        ds = SearchLibraryInformation. GetLibraryChalanReturnByLibraryID(  libID);
        return ds;
    }

    public static DataSet GetDakhilBonusByLibraryID(string libID)
    {
        DataSet ds = new DataSet();
        li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
        ds = SearchLibraryInformation.GetDakhilBonusByLibraryID(  libID);
        return ds;
    }

    public static List<LibraryInformation> GetALLLibraryInformation()
    {
        li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
        return SearchLibraryInformation.GetALLLibraryInformation();
    }

   public static DataSet GetLibraryNameByTeritoryID(string TerCode)
    {
        DataSet ds = new DataSet();
        li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
        ds = SearchLibraryInformation.GetLibraryInfoByTeritoryID(TerCode);
        return ds;
    }
   public static DataSet GetLibraryNameByRegionID(string RegionID)
   {
       DataSet ds = new DataSet();
       li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
       ds = SearchLibraryInformation.GetLibraryInfoByRegionID(RegionID);
       return ds;
   }
   public static DataSet GetLibraryInfoByTeritoryIDQCash(string TerCode)
   {
       DataSet ds = new DataSet();
       li_libraryInformationProvider SearchLibraryInformation = new li_libraryInformationProvider();
       ds = SearchLibraryInformation.GetLibraryInfoByTeritoryIDQCash(TerCode);
       return ds;
   }
}
