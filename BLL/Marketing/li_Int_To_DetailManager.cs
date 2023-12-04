using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Int_To_DetailManager
{
	public Li_Int_To_DetailManager()
	{
	}

    public static List<Li_Int_To_Detail> GetAllLi_Int_To_Details()
    {
        List<Li_Int_To_Detail> li_Int_To_Details = new List<Li_Int_To_Detail>();
        SqlLi_Int_To_DetailProvider sqlLi_Int_To_DetailProvider = new SqlLi_Int_To_DetailProvider();
        li_Int_To_Details = sqlLi_Int_To_DetailProvider.GetAllLi_Int_To_Details();
        return li_Int_To_Details;
    }


    public static Li_Int_To_Detail GetLi_Int_To_DetailByID(int id)
    {
        Li_Int_To_Detail li_Int_To_Detail = new Li_Int_To_Detail();
        SqlLi_Int_To_DetailProvider sqlLi_Int_To_DetailProvider = new SqlLi_Int_To_DetailProvider();
        li_Int_To_Detail = sqlLi_Int_To_DetailProvider.GetLi_Int_To_DetailByID(id);
        return li_Int_To_Detail;
    }


    public static int InsertLi_Int_To_Detail(Li_Int_To_Detail li_Int_To_Detail,bool IsPartyChalan)
    {
        SqlLi_Int_To_DetailProvider sqlLi_Int_To_DetailProvider = new SqlLi_Int_To_DetailProvider();
        return sqlLi_Int_To_DetailProvider.InsertLi_Int_To_Detail(li_Int_To_Detail,IsPartyChalan);
    }


    public static bool UpdateLi_Int_To_Detail(Li_Int_To_Detail li_Int_To_Detail)
    {
        SqlLi_Int_To_DetailProvider sqlLi_Int_To_DetailProvider = new SqlLi_Int_To_DetailProvider();
        return sqlLi_Int_To_DetailProvider.UpdateLi_Int_To_Detail(li_Int_To_Detail);
    }

    public static bool DeleteLi_Int_To_Detail(int li_Int_To_DetailID)
    {
        SqlLi_Int_To_DetailProvider sqlLi_Int_To_DetailProvider = new SqlLi_Int_To_DetailProvider();
        return sqlLi_Int_To_DetailProvider.DeleteLi_Int_To_Detail(li_Int_To_DetailID);
    }
}
