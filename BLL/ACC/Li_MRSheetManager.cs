using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_MRSheetManager
{
	public Li_MRSheetManager()
	{
	}

    public static List<Li_MRSheet> GetAllLi_MRSheets()
    {
        List<Li_MRSheet> li_MRSheets = new List<Li_MRSheet>();
        SqlLi_MRSheetProvider sqlLi_MRSheetProvider = new SqlLi_MRSheetProvider();
        li_MRSheets = sqlLi_MRSheetProvider.GetAllLi_MRSheets();
        return li_MRSheets;
    }


    public static Li_MRSheet GetLi_MRSheetByID(int id)
    {
        Li_MRSheet li_MRSheet = new Li_MRSheet();
        SqlLi_MRSheetProvider sqlLi_MRSheetProvider = new SqlLi_MRSheetProvider();
        li_MRSheet = sqlLi_MRSheetProvider.GetLi_MRSheetByID(id);
        return li_MRSheet;
    }


    public static int InsertLi_MRSheet(Li_MRSheet li_MRSheet)
    {
        SqlLi_MRSheetProvider sqlLi_MRSheetProvider = new SqlLi_MRSheetProvider();
        return sqlLi_MRSheetProvider.InsertLi_MRSheet(li_MRSheet);
    }


    public static bool UpdateLi_MRSheetSenderMkt(Li_MRSheet li_MRSheet)
    {
        SqlLi_MRSheetProvider sqlLi_MRSheetProvider = new SqlLi_MRSheetProvider();
        return sqlLi_MRSheetProvider.UpdateLi_MRSheetSenderMkt(li_MRSheet);
    }
    public static bool UpdateLi_MRSheetSenderAcc(Li_MRSheet li_MRSheet)
    {
        SqlLi_MRSheetProvider sqlLi_MRSheetProvider = new SqlLi_MRSheetProvider();
        return sqlLi_MRSheetProvider.UpdateLi_MRSheetSenderAcc(li_MRSheet);
    }
    public static bool DeleteLi_MRSheet(int li_MRSheetID)
    {
        SqlLi_MRSheetProvider sqlLi_MRSheetProvider = new SqlLi_MRSheetProvider();
        return sqlLi_MRSheetProvider.DeleteLi_MRSheet(li_MRSheetID);
    }

    public static DataSet Get_DateWiseMRSheet(string fromDate,string toDate,bool heldUp)
    {
        SqlLi_MRSheetProvider sqlLi_MRSheetProvider = new SqlLi_MRSheetProvider();
        return sqlLi_MRSheetProvider.Get_DateWiseMRSheet(fromDate, toDate, heldUp );

    }
    public static DataTable  Get_MRSheetNoWiseDetails(int MRId)
    {
        SqlLi_MRSheetProvider sqlLi_MRSheetProvider = new SqlLi_MRSheetProvider();
        return sqlLi_MRSheetProvider.Get_MRSheetNoWiseDetails(MRId);

    }
    public static DataTable Get_MRSheetNoWiseDetailsForDoMR(int MRId, bool heldUp, int DepositForId)
    {
        SqlLi_MRSheetProvider sqlLi_MRSheetProvider = new SqlLi_MRSheetProvider();
        return sqlLi_MRSheetProvider.Get_MRSheetNoWiseDetailsForDoMR(MRId, heldUp, DepositForId);

    }

}
