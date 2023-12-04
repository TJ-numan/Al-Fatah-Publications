using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_DivisionManager
{
	public Li_DivisionManager()
	{
	}

    public static List<Li_Division> GetAllLi_Divisions()
    {
        List<Li_Division> li_Divisions = new List<Li_Division>();
        SqlLi_DivisionProvider sqlLi_DivisionProvider = new SqlLi_DivisionProvider();
        li_Divisions = sqlLi_DivisionProvider.GetAllLi_Divisions();
        return li_Divisions;
    }


    public static List<Li_Division> GetLi_DivisionByID(int id)
    {
        List<Li_Division> li_Divisions = new List<Li_Division>();
        SqlLi_DivisionProvider sqlLi_DivisionProvider = new SqlLi_DivisionProvider();
        li_Divisions = sqlLi_DivisionProvider.GetLi_DivisionByID(id);
        return li_Divisions;
    }


    public static int InsertLi_Division(Li_Division li_Division)
    {
        SqlLi_DivisionProvider sqlLi_DivisionProvider = new SqlLi_DivisionProvider();
        return sqlLi_DivisionProvider.InsertLi_Division(li_Division);
    }


    public static bool UpdateLi_Division(Li_Division li_Division)
    {
        SqlLi_DivisionProvider sqlLi_DivisionProvider = new SqlLi_DivisionProvider();
        return sqlLi_DivisionProvider.UpdateLi_Division(li_Division);
    }

    public static bool DeleteLi_Division(int li_DivisionID)
    {
        SqlLi_DivisionProvider sqlLi_DivisionProvider = new SqlLi_DivisionProvider();
        return sqlLi_DivisionProvider.DeleteLi_Division(li_DivisionID);
    }

    public static DataSet GetAll_DivisionWithDivId(string DivId)
    {
        SqlLi_DivisionProvider sqlLi_DivisionProvider = new SqlLi_DivisionProvider();
        return sqlLi_DivisionProvider.GetAll_DivisionWithDivId(DivId);
    }
}
