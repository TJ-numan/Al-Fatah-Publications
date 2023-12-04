using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

public class Li_PaperReturnDetailManager
{
    public Li_PaperReturnDetailManager()
	{
	}

    public static List<Li_PaperReturnDetails> GetAllLi_PaperReturnDetails()
    {
        List<Li_PaperReturnDetails> li_PaperReturnDetails = new List<Li_PaperReturnDetails>();
        SqlLi_PaperReturnDetailProvider sqlLi_PaperReturnDetailProvider = new SqlLi_PaperReturnDetailProvider();
        li_PaperReturnDetails = sqlLi_PaperReturnDetailProvider.GetAllLi_PaperReturnDetails();
        return li_PaperReturnDetails;
    }


    public static Li_PaperReturnDetails GetLi_PaperReturnDetailsByID(int id)
    {
        Li_PaperReturnDetails li_PaperReturnDetails = new Li_PaperReturnDetails();
        SqlLi_PaperReturnDetailProvider sqlLi_PaperReturnDetailProvider = new SqlLi_PaperReturnDetailProvider();
        li_PaperReturnDetails = sqlLi_PaperReturnDetailProvider.GetLi_PaperReturnDetailsByID(id);
        return li_PaperReturnDetails;
    }


    public static int InsertLi_PaperReturnDetails(Li_PaperReturnDetails li_PaperReturnDetails)
    {
        SqlLi_PaperReturnDetailProvider sqlLi_PaperReturnDetailProvider = new SqlLi_PaperReturnDetailProvider();
        return sqlLi_PaperReturnDetailProvider.InsertLi_PaperReturnDetails(li_PaperReturnDetails);
    }


    public static bool UpdateLi_PaperReturnDetails(Li_PaperReturnDetails li_PaperReturnDetails)
    {
        SqlLi_PaperReturnDetailProvider sqlLi_PaperReturnDetailProvider = new SqlLi_PaperReturnDetailProvider();
        return sqlLi_PaperReturnDetailProvider.UpdateLi_PaperReturnDetails(li_PaperReturnDetails);
    }

    public static bool DeleteLi_PaperReturnDetails(int li_PaperReturnDetailsID)
    {
        SqlLi_PaperReturnDetailProvider sqlLi_PaperReturnDetailProvider = new SqlLi_PaperReturnDetailProvider();
        return sqlLi_PaperReturnDetailProvider.DeleteLi_PaperReturnDetails(li_PaperReturnDetailsID);
    }
}
