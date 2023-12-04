using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 
public class Li_DepositForManager
{
	public Li_DepositForManager()
	{
	}

    public static List<Li_DepositFor> GetAllLi_DepositFors()
    {
        List<Li_DepositFor> li_DepositFors = new List<Li_DepositFor>();
        SqlLi_DepositForProvider sqlLi_DepositForProvider = new SqlLi_DepositForProvider();
        li_DepositFors = sqlLi_DepositForProvider.GetAllLi_DepositFors();
        return li_DepositFors;
    }


    public static Li_DepositFor GetLi_DepositForByID(int id)
    {
        Li_DepositFor li_DepositFor = new Li_DepositFor();
        SqlLi_DepositForProvider sqlLi_DepositForProvider = new SqlLi_DepositForProvider();
        li_DepositFor = sqlLi_DepositForProvider.GetLi_DepositForByID(id);
        return li_DepositFor;
    }


    public static int InsertLi_DepositFor(Li_DepositFor li_DepositFor)
    {
        SqlLi_DepositForProvider sqlLi_DepositForProvider = new SqlLi_DepositForProvider();
        return sqlLi_DepositForProvider.InsertLi_DepositFor(li_DepositFor);
    }


    public static bool UpdateLi_DepositFor(Li_DepositFor li_DepositFor)
    {
        SqlLi_DepositForProvider sqlLi_DepositForProvider = new SqlLi_DepositForProvider();
        return sqlLi_DepositForProvider.UpdateLi_DepositFor(li_DepositFor);
    }

    public static bool DeleteLi_DepositFor(int li_DepositForID)
    {
        SqlLi_DepositForProvider sqlLi_DepositForProvider = new SqlLi_DepositForProvider();
        return sqlLi_DepositForProvider.DeleteLi_DepositFor(li_DepositForID);
    }
}
