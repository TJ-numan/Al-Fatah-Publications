using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Int_FromManager
{
	public Li_Int_FromManager()
	{
	}

    public static List<Li_Int_From> GetAllLi_Int_Froms()
    {
        List<Li_Int_From> li_Int_Froms = new List<Li_Int_From>();
        SqlLi_Int_FromProvider sqlLi_Int_FromProvider = new SqlLi_Int_FromProvider();
        li_Int_Froms = sqlLi_Int_FromProvider.GetAllLi_Int_Froms();
        return li_Int_Froms;
    }


    public static Li_Int_From GetLi_Int_FromByID(int id)
    {
        Li_Int_From li_Int_From = new Li_Int_From();
        SqlLi_Int_FromProvider sqlLi_Int_FromProvider = new SqlLi_Int_FromProvider();
        li_Int_From = sqlLi_Int_FromProvider.GetLi_Int_FromByID(id);
        return li_Int_From;
    }


    public static string  InsertLi_Int_From(Li_Int_From li_Int_From,bool IspartyChalan)
    {
        SqlLi_Int_FromProvider sqlLi_Int_FromProvider = new SqlLi_Int_FromProvider();
        return sqlLi_Int_FromProvider.InsertLi_Int_From(li_Int_From,IspartyChalan);
    }


    public static bool UpdateLi_Int_From(Li_Int_From li_Int_From)
    {
        SqlLi_Int_FromProvider sqlLi_Int_FromProvider = new SqlLi_Int_FromProvider();
        return sqlLi_Int_FromProvider.UpdateLi_Int_From(li_Int_From);
    }

    public static bool DeleteLi_Int_From(int li_Int_FromID)
    {
        SqlLi_Int_FromProvider sqlLi_Int_FromProvider = new SqlLi_Int_FromProvider();
        return sqlLi_Int_FromProvider.DeleteLi_Int_From(li_Int_FromID);
    }
}
