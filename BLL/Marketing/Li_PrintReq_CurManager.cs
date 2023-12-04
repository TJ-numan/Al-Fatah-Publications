using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintReq_CurManager
{
	public Li_PrintReq_CurManager()
	{
	}

    public static List<Li_PrintReq_Cur> GetAllLi_PrintReq_Curs()
    {
        List<Li_PrintReq_Cur> li_PrintReq_Curs = new List<Li_PrintReq_Cur>();
        SqlLi_PrintReq_CurProvider sqlLi_PrintReq_CurProvider = new SqlLi_PrintReq_CurProvider();
        li_PrintReq_Curs = sqlLi_PrintReq_CurProvider.GetAllLi_PrintReq_Curs();
        return li_PrintReq_Curs;
    }


    public static Li_PrintReq_Cur GetLi_PrintReq_CurByID(int id)
    {
        Li_PrintReq_Cur li_PrintReq_Cur = new Li_PrintReq_Cur();
        SqlLi_PrintReq_CurProvider sqlLi_PrintReq_CurProvider = new SqlLi_PrintReq_CurProvider();
        li_PrintReq_Cur = sqlLi_PrintReq_CurProvider.GetLi_PrintReq_CurByID(id);
        return li_PrintReq_Cur;
    }


    public static int InsertLi_PrintReq_Cur(Li_PrintReq_Cur li_PrintReq_Cur)
    {
        SqlLi_PrintReq_CurProvider sqlLi_PrintReq_CurProvider = new SqlLi_PrintReq_CurProvider();
        return sqlLi_PrintReq_CurProvider.InsertLi_PrintReq_Cur(li_PrintReq_Cur);
    }


    public static bool UpdateLi_PrintReq_Cur(Li_PrintReq_Cur li_PrintReq_Cur)
    {
        SqlLi_PrintReq_CurProvider sqlLi_PrintReq_CurProvider = new SqlLi_PrintReq_CurProvider();
        return sqlLi_PrintReq_CurProvider.UpdateLi_PrintReq_Cur(li_PrintReq_Cur);
    }

    public static bool DeleteLi_PrintReq_Cur(int li_PrintReq_CurID)
    {
        SqlLi_PrintReq_CurProvider sqlLi_PrintReq_CurProvider = new SqlLi_PrintReq_CurProvider();
        return sqlLi_PrintReq_CurProvider.DeleteLi_PrintReq_Cur(li_PrintReq_CurID);
    }


    public static bool ApprovedPrintReq(Li_PrintReq_Cur li_PrintReq_Cur)
    {
        SqlLi_PrintReq_CurProvider sqlLi_PrintReq_CurProvider = new SqlLi_PrintReq_CurProvider();
        return sqlLi_PrintReq_CurProvider.ApprovedPrintReq(li_PrintReq_Cur);
    }

    public static DataSet GetPrintReqQty(string BookCode)
    {
         SqlLi_PrintReq_CurProvider sqlLi_PrintReq_CurProvider = new SqlLi_PrintReq_CurProvider();       
        return  sqlLi_PrintReq_CurProvider.  GetPrintReqQty (  BookCode );

    }
    public static DataTable  GetPrintReqForPrint(string FromDate, string ToDate)
    {
         SqlLi_PrintReq_CurProvider sqlLi_PrintReq_CurProvider = new SqlLi_PrintReq_CurProvider();       
        return  sqlLi_PrintReq_CurProvider.  GetPrintReqForPrint (  FromDate ,  ToDate );

    }
}
