using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Paper_M_UManager
{
	public Li_Paper_M_UManager()
	{
	}

    public static List<Li_Paper_M_U> GetAllLi_Paper_M_Us(string PaperType)
    {
        List<Li_Paper_M_U> li_Paper_M_Us = new List<Li_Paper_M_U>();
        SqlLi_Paper_M_UProvider sqlLi_Paper_M_UProvider = new SqlLi_Paper_M_UProvider();
        li_Paper_M_Us = sqlLi_Paper_M_UProvider.GetAllLi_Paper_M_Us( PaperType);
        return li_Paper_M_Us;
    }


    public static Li_Paper_M_U GetLi_Paper_M_UByID(int id)
    {
        Li_Paper_M_U li_Paper_M_U = new Li_Paper_M_U();
        SqlLi_Paper_M_UProvider sqlLi_Paper_M_UProvider = new SqlLi_Paper_M_UProvider();
        li_Paper_M_U = sqlLi_Paper_M_UProvider.GetLi_Paper_M_UByID(id);
        return li_Paper_M_U;
    }


    public static int InsertLi_Paper_M_U(Li_Paper_M_U li_Paper_M_U)
    {
        SqlLi_Paper_M_UProvider sqlLi_Paper_M_UProvider = new SqlLi_Paper_M_UProvider();
        return sqlLi_Paper_M_UProvider.InsertLi_Paper_M_U(li_Paper_M_U);
    }


    public static bool UpdateLi_Paper_M_U(Li_Paper_M_U li_Paper_M_U)
    {
        SqlLi_Paper_M_UProvider sqlLi_Paper_M_UProvider = new SqlLi_Paper_M_UProvider();
        return sqlLi_Paper_M_UProvider.UpdateLi_Paper_M_U(li_Paper_M_U);
    }

    public static bool DeleteLi_Paper_M_U(int li_Paper_M_UID)
    {
        SqlLi_Paper_M_UProvider sqlLi_Paper_M_UProvider = new SqlLi_Paper_M_UProvider();
        return sqlLi_Paper_M_UProvider.DeleteLi_Paper_M_U(li_Paper_M_UID);
    }
}
