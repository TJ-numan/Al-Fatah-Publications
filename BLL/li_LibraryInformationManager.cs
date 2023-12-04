using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_LibraryInformationManager
{
	public Li_LibraryInformationManager()
	{
	}



    public static List<Li_LibraryInformation> GetAll_ComboBox_LibraryInformations()
    {
        List<Li_LibraryInformation> li_LibraryInformations = new List<Li_LibraryInformation>();
        SqlLi_LibraryInformationProvider Sql_li_LibraryInformationProvider = new SqlLi_LibraryInformationProvider();
        li_LibraryInformations = Sql_li_LibraryInformationProvider.GetAll_ComboBox_LibraryInformations();
        return li_LibraryInformations;
    }


    public static List<Li_LibraryInformation> GetAllLi_LibraryInformations()
    {
        List<Li_LibraryInformation> li_LibraryInformations = new List<Li_LibraryInformation>();
        SqlLi_LibraryInformationProvider sqlLi_LibraryInformationProvider = new SqlLi_LibraryInformationProvider();
        li_LibraryInformations = sqlLi_LibraryInformationProvider.GetAllLi_LibraryInformations();
        return li_LibraryInformations;
    }


    public static Li_LibraryInformation GetLi_LibraryInformationByID(int id)
    {
        Li_LibraryInformation li_LibraryInformation = new Li_LibraryInformation();
        SqlLi_LibraryInformationProvider sqlLi_LibraryInformationProvider = new SqlLi_LibraryInformationProvider();
        li_LibraryInformation = sqlLi_LibraryInformationProvider.GetLi_LibraryInformationByID(id);
        return li_LibraryInformation;
    }


    public static string  InsertLi_LibraryInformation(Li_LibraryInformation li_LibraryInformation)
    {
        SqlLi_LibraryInformationProvider sqlLi_LibraryInformationProvider = new SqlLi_LibraryInformationProvider();
        return sqlLi_LibraryInformationProvider.InsertLi_LibraryInformation(li_LibraryInformation);
    }


    public static bool UpdateLi_LibraryInformation(Li_LibraryInformation li_LibraryInformation)
    {
        SqlLi_LibraryInformationProvider sqlLi_LibraryInformationProvider = new SqlLi_LibraryInformationProvider();
        return sqlLi_LibraryInformationProvider.UpdateLi_LibraryInformation(li_LibraryInformation);
    }

    
    public static bool Delete_LibraryInformation(string li_LibraryInformationID, int userid)
    {
        SqlLi_LibraryInformationProvider Sql_li_LibraryInformationProvider = new SqlLi_LibraryInformationProvider();
        return Sql_li_LibraryInformationProvider.Delete_LibraryInformation(li_LibraryInformationID, userid);
    }



    public static DataSet GetSearchLibraryInformation(string LibraryName)
    {
        DataSet ds = new DataSet();
        SqlLi_LibraryInformationProvider SearchLibraryInformation = new SqlLi_LibraryInformationProvider();
        ds = SearchLibraryInformation.GetSearchLibraryInformation(LibraryName);
        return ds;
    }

    public static DataSet GetALLLibraryInformation(string LibraryName, string ID)
    {
        DataSet ds = new DataSet();
        SqlLi_LibraryInformationProvider SearchLibraryInformation = new SqlLi_LibraryInformationProvider();
        ds = SearchLibraryInformation.GetALLLibraryInformation(LibraryName, ID);
        return ds;
    }

    public static DataSet GetALLLibraryInformationByLibraryID(string libID)
    {
        DataSet ds = new DataSet();
        SqlLi_LibraryInformationProvider SearchLibraryInformation = new SqlLi_LibraryInformationProvider();
        ds = SearchLibraryInformation.GetALLLibraryInformationByLibraryID(libID);
        return ds;
    }
    public static DataSet GetLibraryInformationByLibraryIDForEdit(string libID)
    {
        DataSet ds = new DataSet();
        SqlLi_LibraryInformationProvider SearchLibraryInformation = new SqlLi_LibraryInformationProvider();
        ds = SearchLibraryInformation.GetLibraryInformationByLibraryIDForEdit(libID);
        return ds;
    }

    public static DataSet GetLibraryChalanReturnByLibraryID(string libID)
    {
        DataSet ds = new DataSet();
        SqlLi_LibraryInformationProvider SearchLibraryInformation = new SqlLi_LibraryInformationProvider();
        ds = SearchLibraryInformation.GetLibraryChalanReturnByLibraryID(libID);
        return ds;
    }

    public static DataSet GetDakhilBonusByLibraryID(string libID)
    {
        DataSet ds = new DataSet();
        SqlLi_LibraryInformationProvider SearchLibraryInformation = new SqlLi_LibraryInformationProvider();
        ds = SearchLibraryInformation.GetDakhilBonusByLibraryID(libID);
        return ds;
    }
    public static DataSet GetAll_ComboBox_LibraryInformationsByUser(int UserID)
    {
        DataSet ds = new DataSet();
        SqlLi_LibraryInformationProvider SearchLibraryInformation = new SqlLi_LibraryInformationProvider();
        ds = SearchLibraryInformation.GetAll_ComboBox_LibraryInformationsByUser(UserID);
        return ds;
    }
    public static DataSet GetAll_ComboBox_QCashLibraryInformationsByUser(int UserID)
    {
        DataSet ds = new DataSet();
        SqlLi_LibraryInformationProvider SearchLibraryInformation = new SqlLi_LibraryInformationProvider();
        ds = SearchLibraryInformation.GetAll_ComboBox_QCashLibraryInformationsByUser(UserID);
        return ds;
    }
}
