using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;


     public class li_OrganizationManager
    {

         public li_OrganizationManager()
         {

         }


         public static List<li_Organization> GetAll_Organization()
         {
             List<li_Organization> li_Organization = new List<li_Organization>();
             Sql_li_OrganizationProvider Sql_li_OrganizationProvider = new Sql_li_OrganizationProvider();
             li_Organization = Sql_li_OrganizationProvider.GetAll_Organization();
             return li_Organization;
         }



         public static string InsertOrganizationInformation(li_LibraryWiseOrganizationInformation li_LibraryWiseOrganizationInformation)
         {
             Sql_li_OrganizationProvider Sql_li_OrganizationProvider = new Sql_li_OrganizationProvider();

             return Sql_li_OrganizationProvider.Insert_OrganizationInformation(li_LibraryWiseOrganizationInformation); ;
         }

         public static List<li_Organization> Get_OrganizationByID(int ID)
         {

             List<li_Organization> li_Organization = new List<li_Organization>();
             Sql_li_OrganizationProvider Sql_li_OrganizationProvider = new Sql_li_OrganizationProvider();
             li_Organization = Sql_li_OrganizationProvider.Get_OrganizationByID(ID);
             return li_Organization;
         }

         public static DataSet Get_OrganizationByIDforEdit(int ID)
         {
             DataSet ds = new DataSet();
             Sql_li_OrganizationProvider Sql_li_OrganizationProvider = new Sql_li_OrganizationProvider();
             ds = Sql_li_OrganizationProvider.GetOrganizationInformationByID(ID);
             return ds;
         }

         public static DataSet GetALLOrganizationInformation(int ID)
         {
             DataSet ds = new DataSet();
             Sql_li_OrganizationProvider SearchOrganizationInformation = new Sql_li_OrganizationProvider();
             ds = SearchOrganizationInformation.GetOrganizationInformationByID(ID);
             return ds;
         }


         public static DataSet GetALLLibraryWiseOrganizationInformation(string LibraryID)
         {
             DataSet ds = new DataSet();
             Sql_li_OrganizationProvider SearchOrganizationInformation = new Sql_li_OrganizationProvider();
             ds = SearchOrganizationInformation.GetALLLibraryWiseOrganizatioInformation(LibraryID);
             return ds;
         }

         public static bool DeleteOrganizationFromDatabase(string LibraryID, int serialOrganization)
         {
             Sql_li_OrganizationProvider deleteOrganization = new Sql_li_OrganizationProvider();
             return deleteOrganization.Delete_OrganizationFromDatabase(LibraryID, serialOrganization);
         }


    }