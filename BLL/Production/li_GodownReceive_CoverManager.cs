using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_GodownReceive_CoverManager
{
	public Li_GodownReceive_CoverManager()
	{
	}

    public static List<Li_GodownReceive_Cover> GetAllLi_GodownReceive_Covers()
    {
        List<Li_GodownReceive_Cover> li_GodownReceive_Covers = new List<Li_GodownReceive_Cover>();
        SqlLi_GodownReceive_CoverProvider sqlLi_GodownReceive_CoverProvider = new SqlLi_GodownReceive_CoverProvider();
        li_GodownReceive_Covers = sqlLi_GodownReceive_CoverProvider.GetAllLi_GodownReceive_Covers();
        return li_GodownReceive_Covers;
    }


    public static Li_GodownReceive_Cover GetLi_GodownReceive_CoverByID(int id)
    {
        Li_GodownReceive_Cover li_GodownReceive_Cover = new Li_GodownReceive_Cover();
        SqlLi_GodownReceive_CoverProvider sqlLi_GodownReceive_CoverProvider = new SqlLi_GodownReceive_CoverProvider();
        li_GodownReceive_Cover = sqlLi_GodownReceive_CoverProvider.GetLi_GodownReceive_CoverByID(id);
        return li_GodownReceive_Cover;
    }


    public static string  InsertLi_GodownReceive_Cover(Li_GodownReceive_Cover li_GodownReceive_Cover)
    {
        SqlLi_GodownReceive_CoverProvider sqlLi_GodownReceive_CoverProvider = new SqlLi_GodownReceive_CoverProvider();
        return sqlLi_GodownReceive_CoverProvider.InsertLi_GodownReceive_Cover(li_GodownReceive_Cover);
    }


    public static bool UpdateLi_GodownReceive_Cover(Li_GodownReceive_Cover li_GodownReceive_Cover)
    {
        SqlLi_GodownReceive_CoverProvider sqlLi_GodownReceive_CoverProvider = new SqlLi_GodownReceive_CoverProvider();
        return sqlLi_GodownReceive_CoverProvider.UpdateLi_GodownReceive_Cover(li_GodownReceive_Cover);
    }

    public static bool DeleteLi_GodownReceive_Cover(int li_GodownReceive_CoverID)
    {
        SqlLi_GodownReceive_CoverProvider sqlLi_GodownReceive_CoverProvider = new SqlLi_GodownReceive_CoverProvider();
        return sqlLi_GodownReceive_CoverProvider.DeleteLi_GodownReceive_Cover(li_GodownReceive_CoverID);
    }

    public static DataSet GetCoverSupplierforBill  (string BookCode,int Source)
    {
        DataSet ds = new DataSet();
        SqlLi_GodownReceive_CoverProvider sqlLi_GodownReceive_CoverProvider = new SqlLi_GodownReceive_CoverProvider();        
        ds =  sqlLi_GodownReceive_CoverProvider.GetCoverSupplierforBill (BookCode , Source);
        return ds;
    }
}
