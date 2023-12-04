using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_ReturnDetailsManager
{
	public li_ReturnDetailsManager()
	{
	}

    public static List<li_ReturnDetails> GetAll_ReturnDetailss()
    {
        List<li_ReturnDetails> li_ReturnDetailss = new List<li_ReturnDetails>();
        Sql_li_ReturnDetailsProvider Sql_li_ReturnDetailsProvider = new Sql_li_ReturnDetailsProvider();
        li_ReturnDetailss = Sql_li_ReturnDetailsProvider.GetAll_ReturnDetailss();
        return li_ReturnDetailss;
    }

    //public static DataSet   GetAll_ReturnDetailssWithRelation()
    //{
    //    List<li_ReturnDetails> li_ReturnDetailss = new List<li_ReturnDetails>();
    //    Sql_li_ReturnDetailsProvider Sql_li_ReturnDetailsProvider = new Sql_li_ReturnDetailsProvider();
    //    li_ReturnDetailss = Sql_li_ReturnDetailsProvider.GetAll_ReturnDetailss();
    //    return li_ReturnDetailss;
    //}


    public static li_ReturnDetails Get_ReturnDetailsByReturnDetailsID(int ReturnDetailsID)
    {
        li_ReturnDetails li_ReturnDetails = new li_ReturnDetails();
        Sql_li_ReturnDetailsProvider Sql_li_ReturnDetailsProvider = new Sql_li_ReturnDetailsProvider();
        li_ReturnDetails = Sql_li_ReturnDetailsProvider.Get_ReturnDetailsByReturnDetailsID(ReturnDetailsID);
        return li_ReturnDetails;
    }


    public static int Insert_ReturnDetails(li_ReturnDetails li_ReturnDetails)
    {
        Sql_li_ReturnDetailsProvider Sql_li_ReturnDetailsProvider = new Sql_li_ReturnDetailsProvider();
        return Sql_li_ReturnDetailsProvider.Insert_ReturnDetails(li_ReturnDetails);
    }


    public static bool Update_ReturnDetails(li_ReturnDetails li_ReturnDetails)
    {
        Sql_li_ReturnDetailsProvider Sql_li_ReturnDetailsProvider = new Sql_li_ReturnDetailsProvider();
        return Sql_li_ReturnDetailsProvider.Update_ReturnDetails(li_ReturnDetails);
    }

    public static bool Delete_ReturnDetails(int li_ReturnDetailsID)
    {
        Sql_li_ReturnDetailsProvider Sql_li_ReturnDetailsProvider = new Sql_li_ReturnDetailsProvider();
        return Sql_li_ReturnDetailsProvider.Delete_ReturnDetails(li_ReturnDetailsID);
    }
}

