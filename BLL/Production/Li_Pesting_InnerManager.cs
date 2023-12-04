using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Pesting_InnerManager
{
	public Li_Pesting_InnerManager()
	{
	}

    public static List<Li_Pesting_Inner> GetAllLi_Pesting_Inners()
    {
        List<Li_Pesting_Inner> li_Pesting_Inners = new List<Li_Pesting_Inner>();
        SqlLi_Pesting_InnerProvider sqlLi_Pesting_InnerProvider = new SqlLi_Pesting_InnerProvider();
        li_Pesting_Inners = sqlLi_Pesting_InnerProvider.GetAllLi_Pesting_Inners();
        return li_Pesting_Inners;
    }


    public static Li_Pesting_Inner GetLi_Pesting_InnerByID(int id)
    {
        Li_Pesting_Inner li_Pesting_Inner = new Li_Pesting_Inner();
        SqlLi_Pesting_InnerProvider sqlLi_Pesting_InnerProvider = new SqlLi_Pesting_InnerProvider();
        li_Pesting_Inner = sqlLi_Pesting_InnerProvider.GetLi_Pesting_InnerByID(id);
        return li_Pesting_Inner;
    }


    public static int InsertLi_Pesting_Inner(Li_Pesting_Inner li_Pesting_Inner)
    {
        SqlLi_Pesting_InnerProvider sqlLi_Pesting_InnerProvider = new SqlLi_Pesting_InnerProvider();
        return sqlLi_Pesting_InnerProvider.InsertLi_Pesting_Inner(li_Pesting_Inner);
    }


    public static bool UpdateLi_Pesting_Inner(Li_Pesting_Inner li_Pesting_Inner)
    {
        SqlLi_Pesting_InnerProvider sqlLi_Pesting_InnerProvider = new SqlLi_Pesting_InnerProvider();
        return sqlLi_Pesting_InnerProvider.UpdateLi_Pesting_Inner(li_Pesting_Inner);
    }

    public static bool DeleteLi_Pesting_Inner(int li_Pesting_InnerID)
    {
        SqlLi_Pesting_InnerProvider sqlLi_Pesting_InnerProvider = new SqlLi_Pesting_InnerProvider();
        return sqlLi_Pesting_InnerProvider.DeleteLi_Pesting_Inner(li_Pesting_InnerID);
    }


    public static DataSet getPestingInnerDetailByOrder(string OrderNo)
    {

        SqlLi_Pesting_InnerProvider sqlLi_Pesting_InnerProvider = new SqlLi_Pesting_InnerProvider(); 
        return  sqlLi_Pesting_InnerProvider. getPestingInnerDetailByOrder(OrderNo );

    }
}
