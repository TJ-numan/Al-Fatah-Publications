using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Int_From_DatailManager
{
	public Li_Int_From_DatailManager()
	{
	}

    public static List<Li_Int_From_Datail> GetAllLi_Int_From_Datails()
    {
        List<Li_Int_From_Datail> li_Int_From_Datails = new List<Li_Int_From_Datail>();
        SqlLi_Int_From_DatailProvider sqlLi_Int_From_DatailProvider = new SqlLi_Int_From_DatailProvider();
        li_Int_From_Datails = sqlLi_Int_From_DatailProvider.GetAllLi_Int_From_Datails();
        return li_Int_From_Datails;
    }


    public static Li_Int_From_Datail GetLi_Int_From_DatailByID(int id)
    {
        Li_Int_From_Datail li_Int_From_Datail = new Li_Int_From_Datail();
        SqlLi_Int_From_DatailProvider sqlLi_Int_From_DatailProvider = new SqlLi_Int_From_DatailProvider();
        li_Int_From_Datail = sqlLi_Int_From_DatailProvider.GetLi_Int_From_DatailByID(id);
        return li_Int_From_Datail;
    }


    public static int InsertLi_Int_From_Datail(Li_Int_From_Datail li_Int_From_Datail,bool IsPartyChalan)
    {
        SqlLi_Int_From_DatailProvider sqlLi_Int_From_DatailProvider = new SqlLi_Int_From_DatailProvider();
        return sqlLi_Int_From_DatailProvider.InsertLi_Int_From_Datail(li_Int_From_Datail,IsPartyChalan);
    }


    public static bool UpdateLi_Int_From_Datail(Li_Int_From_Datail li_Int_From_Datail)
    {
        SqlLi_Int_From_DatailProvider sqlLi_Int_From_DatailProvider = new SqlLi_Int_From_DatailProvider();
        return sqlLi_Int_From_DatailProvider.UpdateLi_Int_From_Datail(li_Int_From_Datail);
    }

    public static bool DeleteLi_Int_From_Datail(int li_Int_From_DatailID)
    {
        SqlLi_Int_From_DatailProvider sqlLi_Int_From_DatailProvider = new SqlLi_Int_From_DatailProvider();
        return sqlLi_Int_From_DatailProvider.DeleteLi_Int_From_Datail(li_Int_From_DatailID);
    }
}
