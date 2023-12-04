using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_BookVersionInfoManager
{
	public li_BookVersionInfoManager()
	{
	}

    public static List<li_BookVersionInfo> GetAll_BookVersionInfos()
    {
        List<li_BookVersionInfo> li_BookVersionInfos = new List<li_BookVersionInfo>();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        li_BookVersionInfos = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfos();
        return li_BookVersionInfos;
    }
    public static List<li_BookVersionInfo> GetAll_BookVersionInfosByBookID(string BookID)
    {
        List<li_BookVersionInfo> li_BookVersionInfos = new List<li_BookVersionInfo>();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        li_BookVersionInfos = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosByBookID(BookID);
        return li_BookVersionInfos;
    }
    public static List<li_BookVersionInfo> GetAll_Combobox_BookVersionInfosByBookID(string BookID)
    {
        List<li_BookVersionInfo> li_BookVersionInfos = new List<li_BookVersionInfo>();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        li_BookVersionInfos = Sql_li_BookVersionInfoProvider.GetAll_Combobox_BookVersionInfosByBookID(BookID);
        return li_BookVersionInfos;
    }
    public static DataSet GetAll_BookVersionInfosWithRelation(string bookAcCode)
    {
        DataSet ds = new DataSet();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosWithRelation(bookAcCode);
        return ds;
    }

    public static DataSet GetAll_BookVersionInfosWithRelation_Alia(string bookAcCode)
    {
        DataSet ds = new DataSet();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosWithRelation_Alia(bookAcCode);
        return ds;
    }

    public static DataSet GetAll_BookVersionInfosWithRelation_Qawmi(string bookAcCode)
    {
        DataSet ds = new DataSet();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosWithRelation_Qawmi(bookAcCode);
        return ds;
    }


    public static DataSet GetAll_BookVersionInfosWithDiscount(string bookAcCode, string LibraryID)
    {
        DataSet ds = new DataSet();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosWithDiscount(  bookAcCode,  LibraryID);
        return ds;
    }


    public static DataSet GetAll_BookVersionInfosWithEdition(string bookAcCode)
    {
        DataSet ds = new DataSet();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosWithEdition(bookAcCode);
        return ds;
    }

    public static DataSet GetAll_BookVersionInfosWithEdition_Alia(string bookAcCode)
    {
        DataSet ds = new DataSet();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosWithEdition_Alia(bookAcCode);
        return ds;
    }
    public static DataSet GetAll_BookVersionInfosWithEdition_Qawmi(string bookAcCode)
    {
        DataSet ds = new DataSet();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosWithEdition_Qawmi(bookAcCode);
        return ds;
    }


    public static DataSet GetAll_BookVersionInfosWithEditionForReturn(string bookAcCode)
    {
        DataSet ds = new DataSet();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosWithEditionForReturn(bookAcCode);
        return ds;
    }
    public static DataSet GetAll_BookVersionInfosWithEditionForReturnByLibrary(string bookAcCode, string LibraryID)
    {
        DataSet ds = new DataSet();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookVersionInfosWithEditionForReturnByLibrary(  bookAcCode,  LibraryID);
        return ds;
    }
    public static li_BookVersionInfo Get_BookVersionInfoByBookAcCode(string BookAcCode)
    {
        li_BookVersionInfo li_BookVersionInfo = new li_BookVersionInfo();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        li_BookVersionInfo = Sql_li_BookVersionInfoProvider.Get_BookVersionInfoByBookAcCode(BookAcCode);
        return li_BookVersionInfo;
    }


    public static int  Insert_BookVersionInfo(li_BookVersionInfo li_BookVersionInfo)
    {
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        return   Sql_li_BookVersionInfoProvider.Insert_BookVersionInfo(li_BookVersionInfo);
    }


    public static bool Update_BookVersionInfo(li_BookVersionInfo li_BookVersionInfo)
    {
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        return Sql_li_BookVersionInfoProvider.Update_BookVersionInfo(li_BookVersionInfo);
    }

    public static bool Delete_BookVersionInfo(int li_BookVersionInfoID)
    {
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        return Sql_li_BookVersionInfoProvider.Delete_BookVersionInfo(li_BookVersionInfoID);
    }

    public static List<li_BookVersionInfo> Get_BookAcCodeByBookID(string BookID)
    {
        List<li_BookVersionInfo> li_BookInformation = new List<li_BookVersionInfo>();
        Sql_li_BookVersionInfoProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookVersionInfoProvider();
        li_BookInformation = Sql_li_BookVersionInfoProvider.Get_BookInformationByBookID(BookID);
        return li_BookInformation;
    }
}

