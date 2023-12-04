using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



using Common;
using Common.Marketing;

public class li_BookInformationManager
{
	public li_BookInformationManager()
	{
	}

    public static DataSet GetEditionByBookID(string  BookID)
    {
        DataSet ds = new DataSet();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        ds = Sql_li_BookInformationProvider. GetEditionByBookID( BookID);
        return ds;
    }
    public static DataSet GetEdition()
    {
        DataSet ds = new DataSet();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        ds = Sql_li_BookInformationProvider.GetEdition();
        return ds;
    }

    public static DataSet GetAll_BookInformationsByClassTyGroup(string  CategoryID, int ClassID, int TypeID)
    {
        DataSet ds = new DataSet();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        ds = Sql_li_BookInformationProvider.GetAll_BookInformationsByClassTyGroup(CategoryID, ClassID, TypeID);
        return ds;
    }


    public static DataSet GetAll_BookInformations(string BookID,string BookName)
    {
      DataSet ds = new DataSet();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        ds = Sql_li_BookInformationProvider.GetAll_BookInformations(BookID,BookName);
        return ds;
    }
    public static DataSet GetAll_BookInformationsForEdit(string BookID)
    {
        DataSet ds = new DataSet();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        ds = Sql_li_BookInformationProvider.GetAll_BookInformationsForEdit(BookID);
        return ds;
    }

    public static DataSet GetBookInByCode(string BookCode)
    {
        DataSet ds = new DataSet();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        ds = Sql_li_BookInformationProvider.GetBookInByCode(  BookCode);
        return ds;
    }
    //public static DataSet   GetAll_BookInformationsWithRelation()
    //{
    //    List<li_BookInformation> li_BookInformations = new List<li_BookInformation>();
    //    Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
    //    li_BookInformations = Sql_li_BookInformationProvider.GetAll_BookInformations();
    //    return li_BookInformations;
    //}


    public static li_BookInformation Get_BookInformationByBookID(string BookID)
    {
        li_BookInformation li_BookInformation = new li_BookInformation();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformationByBookID(BookID);
        return li_BookInformation;
    }


    public static li_BookInformation Get_BookInformationByBookName(string BookName)
    {
        li_BookInformation li_BookInformation = new li_BookInformation();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformationByBookName(BookName);
        return li_BookInformation;
    }

    
    public static List<li_BookInformation> Get_BookInformations_ComboSourceDataByBookACCode( string  BookAcCode)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_ComboSourceDataByBookACCode( BookAcCode);
        return li_BookInformation;
    } 
    
    public static List<li_BookInformation> Get_BookInformations_ComboSourceData()
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_ComboSourceData();
        return li_BookInformation;
    }
    public static List<li_BookInformation> Get_BookInformations_ComboSourceData_BySession(string BookGroup, int B_SessionId)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_ComboSourceData_BySession(BookGroup, B_SessionId);
        return li_BookInformation;
    }

   
    public static List<li_BookInformation> Get_BookInformations_Combo_BySection(int SectionID)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_Combo_BySection(SectionID );
        return li_BookInformation;
    }


    public static List<li_BookInformation> Get_BookInformationByCategory_ComboSourceData(string category)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformationByCategory_ComboSourceData(category);
        return li_BookInformation;
    }
    public static List<li_BookInformation> Get_BookInformationByCategory(string category)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformationByCategory(category);
        return li_BookInformation;
    }
   public static List<li_BookInformation> Get_BookInformationForRND()
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformationForRND();
        return li_BookInformation;
    }
    //GetComboSourceData

    public static void  Insert_BookInformation(li_BookInformation li_BookInformation)
    {
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
         Sql_li_BookInformationProvider.Insert_BookInformation(li_BookInformation);
    }


    public static bool Update_BookInformation(li_BookInformation li_BookInformation)
    {
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        return Sql_li_BookInformationProvider.Update_BookInformation(li_BookInformation);
    }

    public static bool Delete_BookInformation(int li_BookInformationID)
    {
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        return Sql_li_BookInformationProvider.Delete_BookInformation(li_BookInformationID);
    }

  public static void  Insert_BookInformation_Bangla(li_BookInformation li_BookInformation)
    {
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
         Sql_li_BookInformationProvider.Insert_BookInformation_Bangla(li_BookInformation);
    }

    public static List<BookInformation> GetAll_BookInformations()
    {
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        return Sql_li_BookInformationProvider.GetAll_BookInformations();
    }


    //----------------Rezaul Hossain--------------------------2020-----------------------
    public static DataSet GetAll_BookInformation(string BookName, string BookID)
    {
        DataSet ds = new DataSet();
        Sql_li_BookInformationProvider Sql_li_BookVersionInfoProvider = new Sql_li_BookInformationProvider();
        ds = Sql_li_BookVersionInfoProvider.GetAll_BookInformation(BookName, BookID);
        return ds;
    }
    //----------------Rezaul Hossain--------------------------2021-----------------------
    public static List<li_BookInformation> Get_BookInformations_Combo_BySectionQawmi(int SectionID)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_Combo_BySectionQawmi(SectionID);
        return li_BookInformation;
    }
    public static DataSet GetAll_BookInformationsByClassTyGroupRz(string CategoryID, int ClassID, int TypeID, int UserID)
    {
        DataSet ds = new DataSet();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        ds = Sql_li_BookInformationProvider.GetAll_BookInformationsByClassTyGroupRz(CategoryID, ClassID, TypeID, UserID);
        return ds;
    }
    public static List<li_BookInformation> Get_BookInformations_Combo_BySectionbyUserAndClassID(int UserID, int ClassID)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_Combo_BySectionbyUserAndClassID(UserID, ClassID);
        return li_BookInformation;
    }
    public static List<li_BookInformation> Get_BookInformationsByCompany(string Comp, int ClassID, int Type)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformationsByCompany(Comp, ClassID, Type);
        return li_BookInformation;
    }
    public static List<li_BookInformation> Get_BookInformations_Combo_BySectionForUpdate(int SectionID)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_Combo_BySectionForUpdate(SectionID);
        return li_BookInformation;
    }
    public static List<li_BookInformation> Get_BookInformations_Combo_BySectionbyUserAndClassIDQawmi(int UserID, int ClassID)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_Combo_BySectionbyUserAndClassIDQawmi(UserID, ClassID);
        return li_BookInformation;
    }
    public static List<li_BookInformation> Get_BookInformationsByUserAndClassIDForWorkOrderBook(int UserID, int ClassID)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformationsByUserAndClassIDForWorkOrderBook(UserID, ClassID);
        return li_BookInformation;
    }
    public static DataSet GetEditionByBookIDForRnDWorkOrderAlia(string BookID)
    {
        DataSet ds = new DataSet();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        ds = Sql_li_BookInformationProvider.GetEditionByBookIDForRnDWorkOrderAlia(BookID);
        return ds;
    }
    public static List<li_BookInformation> Get_BookInformations_Combo_ByUserAndClassIDForTeacherEntry(int UserID, int ClassID)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_Combo_ByUserAndClassIDForTeacherEntry(UserID, ClassID);
        return li_BookInformation;
    }
    public static List<li_BookInformation> Get_BookInformations_Combo_BySectionbyUserAndClassIDGraphics(int UserID, int ClassID)
    {
        List<li_BookInformation> li_BookInformation = new List<li_BookInformation>();
        Sql_li_BookInformationProvider Sql_li_BookInformationProvider = new Sql_li_BookInformationProvider();
        li_BookInformation = Sql_li_BookInformationProvider.Get_BookInformations_Combo_BySectionbyUserAndClassIDGraphics(UserID, ClassID);
        return li_BookInformation;
    }
}

