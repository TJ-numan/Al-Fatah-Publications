using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Int_ToManager
{
	public Li_Int_ToManager()
	{
	}

    public static List<Li_Int_To> GetAllLi_Int_Tos()
    {
        List<Li_Int_To> li_Int_Tos = new List<Li_Int_To>();
        SqlLi_Int_ToProvider sqlLi_Int_ToProvider = new SqlLi_Int_ToProvider();
        li_Int_Tos = sqlLi_Int_ToProvider.GetAllLi_Int_Tos();
        return li_Int_Tos;
    }


    public static Li_Int_To GetLi_Int_ToByID(int id)
    {
        Li_Int_To li_Int_To = new Li_Int_To();
        SqlLi_Int_ToProvider sqlLi_Int_ToProvider = new SqlLi_Int_ToProvider();
        li_Int_To = sqlLi_Int_ToProvider.GetLi_Int_ToByID(id);
        return li_Int_To;
    }


    public static string  InsertLi_Int_To(Li_Int_To li_Int_To,bool IsPartyChalan)
    {
        SqlLi_Int_ToProvider sqlLi_Int_ToProvider = new SqlLi_Int_ToProvider();
        return sqlLi_Int_ToProvider.InsertLi_Int_To(li_Int_To,IsPartyChalan);
    }


    public static bool UpdateLi_Int_To(Li_Int_To li_Int_To)
    {
        SqlLi_Int_ToProvider sqlLi_Int_ToProvider = new SqlLi_Int_ToProvider();
        return sqlLi_Int_ToProvider.UpdateLi_Int_To(li_Int_To);
    }

    public static bool DeleteLi_Int_To(int li_Int_ToID)
    {
        SqlLi_Int_ToProvider sqlLi_Int_ToProvider = new SqlLi_Int_ToProvider();
        return sqlLi_Int_ToProvider.DeleteLi_Int_To(li_Int_ToID);
    }
}
