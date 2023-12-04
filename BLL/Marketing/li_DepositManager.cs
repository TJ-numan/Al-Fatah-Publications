using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DepositManager
{
	public Li_DepositManager()
	{
	}

    public static List<Li_Deposit> GetAllLi_Deposits()
    {
        List<Li_Deposit> li_Deposits = new List<Li_Deposit>();
        SqlLi_DepositProvider sqlLi_DepositProvider = new SqlLi_DepositProvider();
        li_Deposits = sqlLi_DepositProvider.GetAllLi_Deposits();
        return li_Deposits;
    }


    public static Li_Deposit GetLi_DepositByID(int id)
    {
        Li_Deposit li_Deposit = new Li_Deposit();
        SqlLi_DepositProvider sqlLi_DepositProvider = new SqlLi_DepositProvider();
        li_Deposit = sqlLi_DepositProvider.GetLi_DepositByID(id);
        return li_Deposit;
    }
    public static string  InsertLi_DepositByTSO(Li_Deposit li_Deposit)
    {
        SqlLi_DepositProvider sqlLi_DepositProvider = new SqlLi_DepositProvider();
        return sqlLi_DepositProvider.InsertLi_DepositByTSO(li_Deposit);
    }


    public static string  InsertLi_Deposit(Li_Deposit li_Deposit)
    {
        SqlLi_DepositProvider sqlLi_DepositProvider = new SqlLi_DepositProvider();
        return sqlLi_DepositProvider.InsertLi_Deposit(li_Deposit);
    }


    public static bool UpdateLi_Deposit(Li_Deposit li_Deposit)
    {
        SqlLi_DepositProvider sqlLi_DepositProvider = new SqlLi_DepositProvider();
        return sqlLi_DepositProvider.UpdateLi_Deposit(li_Deposit);
    }


    public static DataSet Get_DepositeByID(string MrNo, string com)
    {
        DataSet ds = new DataSet();
        SqlLi_DepositProvider SqlLi_DepositProvider = new SqlLi_DepositProvider();
        ds = SqlLi_DepositProvider.Get_DepositeByID(MrNo,com);
        return ds;
    }

    //public static DataSet Get_DepositeByID(string MemoNo)
    //{
    //    DataSet ds = new DataSet();
    //    SqlLi_DepositProvider SqlLi_DepositProvider = new SqlLi_DepositProvider();
    //    ds = SqlLi_DepositProvider.Get_DepositeByID(MemoNo);
    //    return ds;
    //}
    public static DataSet Get_DepositeByMemo(string MemoNo)
    {
        DataSet ds = new DataSet();
        SqlLi_DepositProvider SqlLi_DepositProvider = new SqlLi_DepositProvider();
        ds = SqlLi_DepositProvider.Get_DepositeByMemo(MemoNo);
        return ds;
    }
    public static DataSet Get_DepositeInvoiceByMemo(string MemoNo)
    {
        DataSet ds = new DataSet();
        SqlLi_DepositProvider SqlLi_DepositProvider = new SqlLi_DepositProvider();
        ds = SqlLi_DepositProvider.Get_DepositeInvoiceByMemo(MemoNo);
        return ds;
    }

    public static bool DeleteLi_Deposite(String Invoice, string MemoNo, int userid)
    {
        SqlLi_DepositProvider sqlLi_DepositeProvider = new SqlLi_DepositProvider();
        return sqlLi_DepositeProvider.DeleteLi_Deposite( Invoice, MemoNo, userid);
    }

    //------------------Rezaul Hossain-------------------------------------
    public static bool DeleteLi_Deposit(string MRNo, int userid, string del_cause, string Comp)
    {
        SqlLi_DepositProvider sqlLi_DepositeProvider = new SqlLi_DepositProvider();
        return sqlLi_DepositeProvider.DeleteLi_Deposit(MRNo, userid, del_cause, Comp);
    }
    //-------------------------Just for Deposit SpBonus -2021--------------------------------
    public static DataTable Get_DepositSpBonusInformation(string FromDate, string ToDate, int RegionID, int DivisionID, string TerritoryID, string Com)
    {
        SqlLi_DepositProvider sqlLi_DepositeProvider = new SqlLi_DepositProvider();
        return sqlLi_DepositeProvider.Get_DepositSpBonusInformation(FromDate, ToDate, RegionID, DivisionID, TerritoryID, Com);

    }
    public static string InsertLi_DepositSPBonus(Li_Deposit li_Deposit)
    {
        SqlLi_DepositProvider sqlLi_DepositProvider = new SqlLi_DepositProvider();
        return sqlLi_DepositProvider.InsertLi_DepositSPBonus(li_Deposit);
    }

}
