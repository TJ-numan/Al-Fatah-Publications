using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_GodownReceiveManager
{
	public Li_GodownReceiveManager()
	{
	}

    public static List<Li_GodownReceive> GetAllLi_GodownReceives()
    {
        List<Li_GodownReceive> li_GodownReceives = new List<Li_GodownReceive>();
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        li_GodownReceives = sqlLi_GodownReceiveProvider.GetAllLi_GodownReceives();
        return li_GodownReceives;
    }


    public static Li_GodownReceive GetLi_GodownReceiveByID(int id)
    {
        Li_GodownReceive li_GodownReceive = new Li_GodownReceive();
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        li_GodownReceive = sqlLi_GodownReceiveProvider.GetLi_GodownReceiveByID(id);
        return li_GodownReceive;
    }


    public static string  InsertLi_GodownReceive(Li_GodownReceive li_GodownReceive)
    {
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        return sqlLi_GodownReceiveProvider.InsertLi_GodownReceive(li_GodownReceive);
    }


    public static bool UpdateLi_GodownReceive(Li_GodownReceive li_GodownReceive)
    {
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        return sqlLi_GodownReceiveProvider.UpdateLi_GodownReceive(li_GodownReceive);
    }

    public static bool DeleteLi_GodownReceive(int li_GodownReceiveID)
    {
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        return sqlLi_GodownReceiveProvider.DeleteLi_GodownReceive(li_GodownReceiveID);
    }

    public static DataSet GetAll_GodownReceive(string memo)
    {

        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        return sqlLi_GodownReceiveProvider.GetAll_GodownReceive(memo);
    }

    public static DataSet GetAll_GodownReceiveForBill(string BinderID, string BookCode, string ReceiveType)
    {
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        return sqlLi_GodownReceiveProvider.GetAll_GodownReceiveForBill(BinderID, BookCode, ReceiveType);
    }

    public static DataSet GetDistinctReceive(string BinderID, string BookCode)
    {
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        return sqlLi_GodownReceiveProvider.GetDistinctReceive(BinderID, BookCode);
    }

    public static DataSet GetDistinctReceiveCover(string Supplier, string BookCode)
    {
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        return sqlLi_GodownReceiveProvider.GetDistinctReceiveCover(Supplier, BookCode);
    }


    public static DataSet GetAll_GodownReceiveCoverForBill(string BinderID, string BookCode, string ReceiveType)
    {
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        return sqlLi_GodownReceiveProvider.GetAll_GodownReceiveCoverForBill(BinderID, BookCode, ReceiveType);
    }

    public static DataSet GetAll_GodownReceiveCoverForBill_R2(int SourceID, string SupplierId)
    {
        SqlLi_GodownReceiveProvider sqlLi_GodownReceiveProvider = new SqlLi_GodownReceiveProvider();
        return sqlLi_GodownReceiveProvider.GetAll_GodownReceiveCoverForBill_R2(SourceID, SupplierId);
    }
}
