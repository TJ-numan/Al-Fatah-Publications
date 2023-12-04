using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;




public class li_ChallanDetailsManager
{
	public li_ChallanDetailsManager()
	{
	}

    public static List<li_ChallanDetails> GetAll_ChallanDetailss()
    {
        List<li_ChallanDetails> li_ChallanDetailss = new List<li_ChallanDetails>();
        Sql_li_ChallanDetailsProvider Sql_li_ChallanDetailsProvider = new Sql_li_ChallanDetailsProvider();
        li_ChallanDetailss = Sql_li_ChallanDetailsProvider.GetAll_ChallanDetailss();
        return li_ChallanDetailss;
    }

    //public static DataSet   GetAll_ChallanDetailssWithRelation()
    //{
    //    List<li_ChallanDetails> li_ChallanDetailss = new List<li_ChallanDetails>();
    //    Sql_li_ChallanDetailsProvider Sql_li_ChallanDetailsProvider = new Sql_li_ChallanDetailsProvider();
    //    li_ChallanDetailss = Sql_li_ChallanDetailsProvider.GetAll_ChallanDetailss();
    //    return li_ChallanDetailss;
    ////}


    public static li_ChallanDetails Get_ChallanDetailsByChallanDetailsID(int ChallanDetailsID)
    {
        li_ChallanDetails li_ChallanDetails = new li_ChallanDetails();
        Sql_li_ChallanDetailsProvider Sql_li_ChallanDetailsProvider = new Sql_li_ChallanDetailsProvider();
        li_ChallanDetails = Sql_li_ChallanDetailsProvider.Get_ChallanDetailsByChallanDetailsID(ChallanDetailsID);
        return li_ChallanDetails;
    }


    public static int   Insert_ChallanDetails(li_ChallanDetails li_ChallanDetails)
    {
     Sql_li_ChallanDetailsProvider Sql_li_ChallanDetailsProvider = new Sql_li_ChallanDetailsProvider();
     Sql_li_ChallanDetailsProvider.Insert_ChallanDetails(li_ChallanDetails);
     return 1;
    }

    public static int Insert_ChallanDetails_Qawmi(li_ChallanDetails li_ChallanDetails)
    {
        Sql_li_ChallanDetailsProvider Sql_li_ChallanDetailsProvider = new Sql_li_ChallanDetailsProvider();
        Sql_li_ChallanDetailsProvider.Insert_ChallanDetails_Qawmi(li_ChallanDetails);
        return 1;
    }


    public static void  Update_ChallanDetails(li_ChallanDetails li_ChallanDetails)
    {
        Sql_li_ChallanDetailsProvider Sql_li_ChallanDetailsProvider = new Sql_li_ChallanDetailsProvider();
        Sql_li_ChallanDetailsProvider.Update_ChallanDetails(li_ChallanDetails);
    }

    public static bool Delete_ChallanDetails(string  li_ChallanDetailsID)
    {
        Sql_li_ChallanDetailsProvider Sql_li_ChallanDetailsProvider = new Sql_li_ChallanDetailsProvider();
        return Sql_li_ChallanDetailsProvider.Delete_ChallanDetails(li_ChallanDetailsID);
    }
}

