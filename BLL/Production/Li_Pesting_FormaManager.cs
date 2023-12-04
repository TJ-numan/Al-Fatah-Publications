using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Pesting_FormaManager
{
	public Li_Pesting_FormaManager()
	{
	}

    public static List<Li_Pesting_Forma> GetAllLi_Pesting_Formas()
    {
        List<Li_Pesting_Forma> li_Pesting_Formas = new List<Li_Pesting_Forma>();
        SqlLi_Pesting_FormaProvider sqlLi_Pesting_FormaProvider = new SqlLi_Pesting_FormaProvider();
        li_Pesting_Formas = sqlLi_Pesting_FormaProvider.GetAllLi_Pesting_Formas();
        return li_Pesting_Formas;
    }


    public static Li_Pesting_Forma GetLi_Pesting_FormaByID(int id)
    {
        Li_Pesting_Forma li_Pesting_Forma = new Li_Pesting_Forma();
        SqlLi_Pesting_FormaProvider sqlLi_Pesting_FormaProvider = new SqlLi_Pesting_FormaProvider();
        li_Pesting_Forma = sqlLi_Pesting_FormaProvider.GetLi_Pesting_FormaByID(id);
        return li_Pesting_Forma;
    }


    public static int InsertLi_Pesting_Forma(Li_Pesting_Forma li_Pesting_Forma)
    {
        SqlLi_Pesting_FormaProvider sqlLi_Pesting_FormaProvider = new SqlLi_Pesting_FormaProvider();
        return sqlLi_Pesting_FormaProvider.InsertLi_Pesting_Forma(li_Pesting_Forma);
    }


    public static bool UpdateLi_Pesting_Forma(Li_Pesting_Forma li_Pesting_Forma)
    {
        SqlLi_Pesting_FormaProvider sqlLi_Pesting_FormaProvider = new SqlLi_Pesting_FormaProvider();
        return sqlLi_Pesting_FormaProvider.UpdateLi_Pesting_Forma(li_Pesting_Forma);
    }

    public static bool DeleteLi_Pesting_Forma(int li_Pesting_FormaID)
    {
        SqlLi_Pesting_FormaProvider sqlLi_Pesting_FormaProvider = new SqlLi_Pesting_FormaProvider();
        return sqlLi_Pesting_FormaProvider.DeleteLi_Pesting_Forma(li_Pesting_FormaID);
    }


    public static DataSet  getPestingFormaDetailByOrder(string OrderNo)
    {
        SqlLi_Pesting_FormaProvider sqlLi_Pesting_FormaProvider = new SqlLi_Pesting_FormaProvider();
        return  sqlLi_Pesting_FormaProvider.getPestingFormaDetailByOrder(OrderNo);

    }
}
