using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 

using Common;
using Common.Marketing;
using BLL.Marketing;

public class Li_SalesPersonManager
{
	public Li_SalesPersonManager()
	{
	}

    public static List<Li_SalesPerson> GetAllLi_SalesPersons(string tsoName)
    {
        List<Li_SalesPerson> li_SalesPersons = new List<Li_SalesPerson>();
        SqlLi_SalesPersonProvider sqlLi_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        li_SalesPersons = sqlLi_SalesPersonProvider.GetAllLi_SalesPersons(tsoName);
        return li_SalesPersons;
    }

    public static List<Li_SalesPerson> GetLi_SalesPersonsByTerritory(string Territory)
    {
        List<Li_SalesPerson> li_SalesPersons = new List<Li_SalesPerson>();
        SqlLi_SalesPersonProvider sqlLi_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        li_SalesPersons = sqlLi_SalesPersonProvider.GetLi_SalesPersonsByTerritory(  Territory);
        return li_SalesPersons;
    }
    public static List<Li_SalesPerson> GetLi_SalesPersonByID(string id,bool showAll)
    {
        List<Li_SalesPerson> li_SalesPerson = new List<Li_SalesPerson>();
        SqlLi_SalesPersonProvider sqlLi_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        li_SalesPerson = sqlLi_SalesPersonProvider.GetLi_SalesPersonByID(id,showAll );
        return li_SalesPerson;
    }

   

    public static string  InsertLi_SalesPerson(Li_SalesPerson li_SalesPerson)
    {
        SqlLi_SalesPersonProvider sqlLi_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        return sqlLi_SalesPersonProvider.InsertLi_SalesPerson(li_SalesPerson);
    }


    public static bool DeleteLi_SalesPerson(int li_SalesPersonID)
    {
        SqlLi_SalesPersonProvider sqlLi_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        return sqlLi_SalesPersonProvider.DeleteLi_SalesPerson(li_SalesPersonID);
    }

    public static DataSet Get_AllTSO(string tsoName)
    {
        DataSet ds = new DataSet();
        SqlLi_SalesPersonProvider Sql_li_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        ds = Sql_li_SalesPersonProvider.Get_AllTSO(tsoName);
        return ds;
    }
    public static DataSet Get_TSOByID(string ID)
    {
        DataSet ds = new DataSet();
        SqlLi_SalesPersonProvider Sql_li_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        ds = Sql_li_SalesPersonProvider.Get_TSOByID(ID);
        return ds;
    }

 public static DataSet GetAllLi_SalesPersonsByUserID(int UserID)
    {
        DataSet ds = new DataSet();
        SqlLi_SalesPersonProvider Sql_li_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        ds = Sql_li_SalesPersonProvider.GetAllLi_SalesPersonsByUserID(UserID);
        return ds;
    }



 public static DataSet GetLi_SalesPersonByID(string ID)
 {
     DataSet ds = new DataSet();
     SqlLi_SalesPersonProvider SqlLi_SalesPersonProvider = new SqlLi_SalesPersonProvider();
     ds = SqlLi_SalesPersonProvider.GetLi_SalesPersonByID(ID);
     return ds;
 }

    public static int UpdateLi_SalesPerson(Li_SalesPerson salesperson)
    {
        SqlLi_SalesPersonProvider sqlLi_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        return sqlLi_SalesPersonProvider.UpdateLi_SalesPerson(salesperson);
    }

    public static List<TSoInformation> Get_AllTSO()
    {
        SqlLi_SalesPersonProvider sqlLi_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        return sqlLi_SalesPersonProvider.Get_AllTSO();
    }

    //------------------rezaul hossain-----------------------------
    //public static List<Li_SalesPerson> GetAll_ComboBox_TSOInformations()
    //{
    //    List<Li_SalesPerson> li_TSOInformations = new List<Li_SalesPerson>();
    //    SqlLi_SalesPersonProvider Sql_li_TSOInformationProvider = new SqlLi_SalesPersonProvider();
    //    li_TSOInformations = SqlLi_SalesPersonProvider.GetAll_ComboBox_TSOInformations();
    //    return li_TSOInformations;
    //}

    public static List<Li_SalesPerson> GetLi_SalesPersonsByTerritory_OnlyActiveTSO(string Territory)
    {
        List<Li_SalesPerson> li_SalesPersons = new List<Li_SalesPerson>();
        SqlLi_SalesPersonProvider sqlLi_SalesPersonProvider = new SqlLi_SalesPersonProvider();
        li_SalesPersons = sqlLi_SalesPersonProvider.GetLi_SalesPersonsByTerritory_OnlyActiveTSO(Territory);
        return li_SalesPersons;
    }

    public static DataSet Get_AllSalesTargetInfoByTerCodeMonthYear(string terCode, int monthNo, int year, int CompanyID)
    {
        DataSet ds = new DataSet();
        sqlLi_SalesPersonProvider sqlLi_SalesPersonProvider = new sqlLi_SalesPersonProvider();
        ds = sqlLi_SalesPersonProvider.Get_AllSalesTargetInfoByTerCodeMonthYear(terCode, monthNo, year, CompanyID);

        return ds;
    }

}
