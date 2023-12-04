using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintReqManager
{
	public Li_PrintReqManager()
	{
	}

    public static List<Li_PrintReq> GetAllLi_PrintReqs()
    {
        List<Li_PrintReq> li_PrintReqs = new List<Li_PrintReq>();
        SqlLi_PrintReqProvider sqlLi_PrintReqProvider = new SqlLi_PrintReqProvider();
        li_PrintReqs = sqlLi_PrintReqProvider.GetAllLi_PrintReqs();
        return li_PrintReqs;
    }


    public static Li_PrintReq GetLi_PrintReqByID(int id)
    {
        Li_PrintReq li_PrintReq = new Li_PrintReq();
        SqlLi_PrintReqProvider sqlLi_PrintReqProvider = new SqlLi_PrintReqProvider();
        li_PrintReq = sqlLi_PrintReqProvider.GetLi_PrintReqByID(id);
        return li_PrintReq;
    }


    public static string  InsertLi_PrintReq(Li_PrintReq li_PrintReq)
    {
        SqlLi_PrintReqProvider sqlLi_PrintReqProvider = new SqlLi_PrintReqProvider();
        return sqlLi_PrintReqProvider.InsertLi_PrintReq(li_PrintReq);
    }


    public static bool UpdateLi_PrintReq(Li_PrintReq li_PrintReq)
    {
        SqlLi_PrintReqProvider sqlLi_PrintReqProvider = new SqlLi_PrintReqProvider();
        return sqlLi_PrintReqProvider.UpdateLi_PrintReq(li_PrintReq);
    }

    public static bool DeleteLi_PrintReq(int li_PrintReqID)
    {
        SqlLi_PrintReqProvider sqlLi_PrintReqProvider = new SqlLi_PrintReqProvider();
        return sqlLi_PrintReqProvider.DeleteLi_PrintReq(li_PrintReqID);
    }


    public static string  IsExistPrintReq(int PrintSl,string  BookCode)
    {
        SqlLi_PrintReqProvider sqlLi_PrintReqProvider = new SqlLi_PrintReqProvider();
        return sqlLi_PrintReqProvider. IsExistPrintReq( PrintSl, BookCode);
    }

    public static DataSet GetPrintReqBasic()
    {
        SqlLi_PrintReqProvider sqlLi_PrintReqProvider = new SqlLi_PrintReqProvider();
        return sqlLi_PrintReqProvider.GetPrintReqBasic();
    }

    public static DataTable printRequisitionReport(string FromDate, string ToDate, string BookName, string Class, string Type, string Edition, int GID, string Category)
    {
        SqlLi_PrintReqProvider sqlLi_PrintReqProvider = new SqlLi_PrintReqProvider();
        return sqlLi_PrintReqProvider. printRequisitionReport(  FromDate,   ToDate,   BookName,   Class,   Type,   Edition,   GID,   Category);
    }

}
