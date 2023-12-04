using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_SpecimenChalanManager
{
	public Li_SpecimenChalanManager()
	{
	}

    public static List<Li_SpecimenChalan> GetAllLi_SpecimenChalans()
    {
        List<Li_SpecimenChalan> li_SpecimenChalans = new List<Li_SpecimenChalan>();
        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        li_SpecimenChalans = sqlLi_SpecimenChalanProvider.GetAllLi_SpecimenChalans();
        return li_SpecimenChalans;
    }


    public static Li_SpecimenChalan GetLi_SpecimenChalanByID(int id)
    {
        Li_SpecimenChalan li_SpecimenChalan = new Li_SpecimenChalan();
        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        li_SpecimenChalan = sqlLi_SpecimenChalanProvider.GetLi_SpecimenChalanByID(id);
        return li_SpecimenChalan;
    }


    public static string  InsertLi_SpecimenChalan(Li_SpecimenChalan li_SpecimenChalan)
    {
        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        return sqlLi_SpecimenChalanProvider.InsertLi_SpecimenChalan(li_SpecimenChalan);
    }


    public static bool UpdateLi_SpecimenChalan(Li_SpecimenChalan li_SpecimenChalan)
    {
        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        return sqlLi_SpecimenChalanProvider.UpdateLi_SpecimenChalan(li_SpecimenChalan);
    }

    public static bool DeleteLi_SpecimenChalan(int li_SpecimenChalanID)
    {
        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        return sqlLi_SpecimenChalanProvider.DeleteLi_SpecimenChalan(li_SpecimenChalanID);
    }

    public static DataSet GetSpecimenChallanInformationByMemoForEdit(string MemoNo)
    {
        DataSet ds = new DataSet();
        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        ds =  sqlLi_SpecimenChalanProvider.GetSpecimenChallanInformationByMemoForEdit(MemoNo);
        return ds;
    }

    public static DataSet GetSpecimenChallanDetailsInformationByChallanIDForEdit(string ChallanID)
    {
        DataSet ds = new DataSet();

        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
         ds =  sqlLi_SpecimenChalanProvider.GetSpecimenChallanDetailsInformationByChallanIDForEdit(ChallanID);
        return ds;
    }

    public static DataSet Get_DailyPackingCost(string fromdate, string todate, string Name, string MemoNo)
    {
        DataSet ds = new DataSet();
         SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        ds = sqlLi_SpecimenChalanProvider .Get_DailyPackingCost(fromdate, todate, Name, MemoNo);
        return ds;
    }


    public static DataSet Get_DailyPaidChalan(string fromdate, string todate, string Name, string MemoNo)
    {
        DataSet ds = new DataSet();
        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        ds = sqlLi_SpecimenChalanProvider.Get_DailyPaidChalan(fromdate, todate, Name, MemoNo);
        return ds;
    }
    public static DataSet getSpecimenForLetter(string TSOId, string FromDate, string ToDate)
    {
        DataSet ds = new DataSet();
        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        ds = sqlLi_SpecimenChalanProvider.getSpecimenForLetter(TSOId, FromDate, ToDate);
        return ds;
    }

    public static  DataTable getSpecimenForXML(string FromDate, string ToDate)
    {
        DataTable  dt = new  DataTable ();
        SqlLi_SpecimenChalanProvider sqlLi_SpecimenChalanProvider = new SqlLi_SpecimenChalanProvider();
        dt = sqlLi_SpecimenChalanProvider.getSpecimenForXML (  FromDate, ToDate);
        return dt;
    }
}
