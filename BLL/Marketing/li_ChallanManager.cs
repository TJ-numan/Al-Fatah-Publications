using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_ChallanManager
{
	public li_ChallanManager()
	{
	}

    //loading chalanID for returnChalan

    //public static List<li_Challan > GetAll_ComboBox_ChallanInformation()
    //{
    //    List<li_Challan> li_LibraryInformations = new List<li_Challan>();
    //    Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
    //    li_LibraryInformations = Sql_li_ChallanProvider.GetAll_ComboBox_ChallanInformations();
    //    return li_LibraryInformations;
    //}
   public static DataSet LoadYear()
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.LoadYear();
        return ds;
    }

    public static List<li_Challan> GetAll_Challans()
    {
        List<li_Challan> li_Challans = new List<li_Challan>();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        li_Challans = Sql_li_ChallanProvider.GetAll_Challans();
        return li_Challans;
    }

    public static DataSet Get_ChallanBy_ChallanID(string ChallanID)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_ChallanBy_ChallanID(ChallanID);
        return ds;
    }
    public static li_Challan Get_ChallanByChallanID(string  ChallanID)
    {
        li_Challan li_Challan = new li_Challan();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        li_Challan = Sql_li_ChallanProvider.Get_ChallanByChallanID(ChallanID);
        return li_Challan;
    }


    public static string  Insert_Challan(li_Challan li_Challan)
    {
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        string id =  Sql_li_ChallanProvider.Insert_Challan(li_Challan);
        return id;
    }

    public static string Insert_Challan_Qawmi(li_Challan li_Challan)
    {
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        string id = Sql_li_ChallanProvider.Insert_Challan_Qawmi(li_Challan);
        return id;
    }

    public static bool Update_Challan(li_Challan li_Challan)
    {
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        return Sql_li_ChallanProvider.Update_Challan(li_Challan);
    }

    public static bool Delete_Challan(string  li_ChallanID ,string  Cause,int DeleBy)
    {
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        return Sql_li_ChallanProvider.Delete_Challan(li_ChallanID,Cause,DeleBy);
    }
    public static bool Delete_SpecimenChallan(string li_ChallanID, string Cause, int DeleBy)
    {
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        return Sql_li_ChallanProvider.Delete_SpecimenChallan(li_ChallanID, Cause, DeleBy);
    }

    public static DataSet Get_AllChallan(string fromDate,string toDate)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_AllChallan(fromDate,toDate);
        return ds;
    }
    public static DataSet Get_BoishakiChalan(string fromDate, string toDate,string LbraryID)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_BoishakiChalan(fromDate, toDate,LbraryID);
        return ds;
    }
    public static DataSet Get_DailyPackingCost(string fromdate,string todate,string libraryName,string MemoNo,bool IsQawmi)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_DailyPackingCost(  fromdate,  todate,libraryName,MemoNo,IsQawmi);
        return ds;
    }
    public static DataSet Get_DailyPackingCostByNameOrMemo(string libraryName, string MemoNo)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_DailyPackingCostByNameOrMemo(  libraryName,MemoNo);
        return ds;
    }

    public static DataSet Get_DailyPackingCost_Web(string fromdate, string todate, string libraryName, string MemoNo,int Area)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_DailyPackingCost_Web(fromdate, todate, libraryName, MemoNo,Area);
        return ds;
    }


    public static DataSet Get_DailyPackingCostDifference(string fromdate, string todate, string libraryName, string MemoNo)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_DailyPackingCostDifference(fromdate, todate, libraryName, MemoNo);
        return ds;
    }




    public static DataSet Get_DailyPaidChalan(string fromdate, string todate, string libraryName, string MemoNo,bool ISQawmi)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_DailyPaidChalan(fromdate, todate,libraryName,MemoNo,ISQawmi);
        return ds;
    }


    public static DataSet Get_DailyPaidChalan_Web(string fromdate, string todate, string libraryName, string MemoNo,int Area)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_DailyPaidChalan_Web(fromdate, todate,libraryName,MemoNo,Area );
        return ds;
    }

    public static DataSet Get_AllChallanForDelivery(string fromDate, string toDate, string FromMemoNo, string ToMemo)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_AllChallanForDelivery(fromDate, toDate, FromMemoNo,ToMemo );
        return ds;
    }


    public static DataSet Get_BookQtyByChallan(string ChalanID)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_BookQtyByChallan(  ChalanID);
        return ds;
    }

    public static DataSet Get_SpecimenBookQtyByChallan(string ChalanID)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_SpecimenBookQtyByChallan(ChalanID);
        return ds;
    }

    public static DataSet Get_AllChallanByName(string name )
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_AllChallanByName(  name);
        return ds;
    }

    public static DataSet Get_AllChallanIDByMemoNo(string MemoNo)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_AllChallanIDByMemoNo(MemoNo);
        return ds;
    }


    public static DataSet Get_AllSpecimenByMemoNo(string MemoNo)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_AllSpecimenDByMemoNo(MemoNo);
        return ds;
    }
  public static DataSet Get_ChallanAmountByChallanIDFromDetails(string ChallanID)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_ChallanAmountByChallanIDFromDetails(  ChallanID);
        return ds;
    }
  public static DataSet Get_SpecimenChallanAmountByChallanIDFromDetails(string ChallanID)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_SpecimenChallanAmountByChallanIDFromDetails(ChallanID);
        return ds;
    }
    public static DataSet GetChallanInformationByMemoForEdit(string MemoNo)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.GetChallanInformationByMemoForEdit(  MemoNo);
        return ds;
    }

    public static DataSet GetChallanDetailsInformationByChallanIDForEdit(string ChallanID)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.GetChallanDetailsInformationByChallanIDForEdit(  ChallanID);
        return ds;
    }
    
 



    public static DataSet Get_BookQtyFromReceive(   )
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_BookQtyByFromReceive() ;
        return ds;
    }




    public static DataSet Get_BookQtyFromChalan(   )
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider. Get_BookQtyByFromChalan();
        return ds;
    }

    public static DataSet UpdateStock(string BookCode, decimal Qty,bool IsCentralStore)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.UpdateStock(BookCode, Qty,IsCentralStore );
        return ds;
    }



    public static  DataTable DatewiseChallan(string fromdate, string todate,bool   Boishaki, bool  Alim, bool IsQawmi, int userID)
    {
        DataTable dt = new DataTable();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        dt = Sql_li_ChallanProvider.DatewiseChallan(fromdate, todate, Boishaki, Alim, IsQawmi, userID);
        return dt;
    }


    //--------------------rezaul Hossain----------------------
    public static DataSet GetChallanDetailsInformationByChallanID(string ChalanID)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.GetChallanDetailsInformationByChallanID(ChalanID);
        return ds;
    }
    public static DataSet UpdateStock(string BookCode, decimal Qty)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.UpdateStock(BookCode, Qty);
        return ds;
    }
    public static DataSet Get_AllSPChallanInfoByMemoNo(string MemoNo)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_AllSPChallanInfoByMemoNo(MemoNo);
        return ds;
    }
    public static bool Delete_ChallanSpeciman(string li_ChallanID, string Cause, int DeleBy)
    {
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        return Sql_li_ChallanProvider.Delete_ChallanSpeciman(li_ChallanID, Cause, DeleBy);
    }

    public static List<li_Challan> GetChallanInformationByMemoNo(string memoNo)
    {
        Sql_li_ChallanProvider aChallanInformationProvider = new Sql_li_ChallanProvider();
        return aChallanInformationProvider.GetChallanInformationByMemoNo(memoNo);
    }
    public static bool UpdateLi_Challan(li_Challan li_Challan)
    {
        Sql_li_ChallanProvider sqlLi_ChallanProvider = new Sql_li_ChallanProvider();
        return sqlLi_ChallanProvider.UpdateLi_Challan(li_Challan);
    }
    public static List<li_Challan> GetChallanInformationByMemoNoQ(string memoNo)
    {
        Sql_li_ChallanProvider aChallanInformationProvider = new Sql_li_ChallanProvider();
        return aChallanInformationProvider.GetChallanInformationByMemoNoQ(memoNo);
    }
    public static bool UpdateLi_ChallanQ(li_Challan li_Challan)
    {
        Sql_li_ChallanProvider sqlLi_ChallanProvider = new Sql_li_ChallanProvider();
        return sqlLi_ChallanProvider.UpdateLi_ChallanQ(li_Challan);
    }
    public static DataSet Get_AllChallanInfoByMemoNo(string MemoNo, string ComID)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_AllChallanInfoByMemoNo(MemoNo, ComID);
        return ds;
    }
    public static DataSet Get_AllSpecimenChallanInfoByMemoNo(string MemoNo)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_AllSpecimenChallanInfoByMemoNo(MemoNo);
        return ds;
    }

    //---------------------------01.04.2023-----------------------------------
    public static DataSet Get_DatewiseMemoForSummary(string fromdate, string todate, int Comp)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        ds = Sql_li_ChallanProvider.Get_DatewiseMemoForSummary(fromdate, todate, Comp);
        return ds;
    }
    public static string Insert_InvoiceSummaryChallan(li_Challan li_Challan)
    {
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        string id = Sql_li_ChallanProvider.Insert_InvoiceSummaryChallan(li_Challan);
        return id;
    }
    public static int Insert_InvoiceSummaryChallanDetails(li_Challan li_Challan)
    {
        Sql_li_ChallanProvider Sql_li_ChallanProvider = new Sql_li_ChallanProvider();
        return Sql_li_ChallanProvider.Insert_InvoiceSummaryChallanDetails(li_Challan);
       
    }
    public static bool Update_InvoiceSummaryForPrint(Int32 InvSL)
    {
        Sql_li_ChallanProvider sqlLi_ChallanProvider = new Sql_li_ChallanProvider();
        return sqlLi_ChallanProvider.Update_InvoiceSummaryForPrint(InvSL);
    }

    public static DataSet GetBookOrderDetailsByOrderNoForEdit(string MemoNo)
    {
        DataSet ds = new DataSet();
        Sql_li_ChallanProvider sqlLi_ChallanProvider = new Sql_li_ChallanProvider();
        ds = sqlLi_ChallanProvider.GetBookOrderDetailsByOrderNoForEdit(MemoNo);
        return ds;
    }

}

