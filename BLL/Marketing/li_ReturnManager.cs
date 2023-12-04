using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_ReturnManager
{
    public li_ReturnManager()
    {
    }

    public static List<li_Return> GetAll_Returns()
    {
        List<li_Return> li_Returns = new List<li_Return>();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        li_Returns = Sql_li_ReturnProvider.GetAll_Returns();
        return li_Returns;
    }

    //public static DataSet   GetAll_ReturnsWithRelation()
    //{
    //    List<li_Return> li_Returns = new List<li_Return>();
    //    Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
    //    li_Returns = Sql_li_ReturnProvider.GetAll_Returns();
    //    return li_Returns;
    //}


    public static li_Return Get_ReturnByReturnID(int ReturnID)
    {
        li_Return li_Return = new li_Return();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        li_Return = Sql_li_ReturnProvider.Get_ReturnByReturnID(ReturnID);
        return li_Return;
    }


    public static string Insert_Return(li_Return li_Return)
    {
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        return Sql_li_ReturnProvider.Insert_Return(li_Return);
    }


    public static bool Update_Return(li_Return li_Return)
    {
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        return Sql_li_ReturnProvider.Update_Return(li_Return);
    }

    public static DataSet Get_AllReturn(string fromdate, string todate)
    {
        DataSet ds = new DataSet();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        ds = Sql_li_ReturnProvider.Get_AllReturn(fromdate, todate);
        return ds;
    }

    public static DataSet GetReturnInformationByMemoForEdit(string MemoNo)
    {
        DataSet ds = new DataSet();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        ds = Sql_li_ReturnProvider.GetReturnInformationByMemoForEdit(MemoNo);
        return ds;
    }
    //--------------Rezaul Hossain Using Procedure----------------------
    public static DataSet GetReturnDetailsInformationByReturnIDForEdit(string ReturnID, String Comp)
    {
        DataSet ds = new DataSet();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        ds = Sql_li_ReturnProvider.GetReturnDetailsInformationByReturnIDForEdit(ReturnID, Comp);
        return ds;
    }


    public static DataSet Get_AllReturnIDByMemoNo(string MemoNo, string Comp)
    {
        DataSet ds = new DataSet();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        ds = Sql_li_ReturnProvider.Get_AllReturnIDByMemoNo(MemoNo, Comp);
        return ds;
    }

    public static bool Cancel_Return(string ReturnID, string Cause, int DeleBy)
    {
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        return Sql_li_ReturnProvider.Delete_Return(ReturnID, Cause, DeleBy);
    }
    public static bool Cancel_Return_Q(string ReturnID, string Cause, int DeleBy)
    {
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        return Sql_li_ReturnProvider.Delete_Return_Q(ReturnID, Cause, DeleBy);
    }

    public static DataSet Get_ReturnAmountByReturnIDFromDetails(string ReturnID)
    {
        DataSet ds = new DataSet();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        ds = Sql_li_ReturnProvider.Get_ReturnAmountByReturnIDFromDetails(ReturnID);
        return ds;
    }

    public static DataSet Get_BookQtyByReturn(string ReturnID)
    {
        DataSet ds = new DataSet();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        ds = Sql_li_ReturnProvider.Get_BookQtyByReturn(ReturnID);
        return ds;
    }


    public static DataSet UpdateReturnStock(string BookCode, int Qty)
    {
        DataSet ds = new DataSet();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        ds = Sql_li_ReturnProvider.UpdateReturnStock(BookCode, Qty);
        return ds;
    }


    public static bool Delete_Return(string li_ChallanID, string Cause, int DeleBy)
    {
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        return Sql_li_ReturnProvider.Delete_Return(li_ChallanID, Cause, DeleBy);
    }

    public static DataTable DatewiseReturn(string FromDate, string ToDate, int MemoFrom, int MemoTo, bool IsQawmi, int UserID)
    {
        DataTable dt = new DataTable();
        Sql_li_ReturnProvider Sql_li_ReturnProvider = new Sql_li_ReturnProvider();
        dt = Sql_li_ReturnProvider.DatewiseReturn(FromDate, ToDate, MemoFrom, MemoTo, IsQawmi, UserID);
        return dt;
    }
}




