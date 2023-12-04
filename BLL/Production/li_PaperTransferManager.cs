using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PaperTransferManager
{
	public Li_PaperTransferManager()
	{
	}

    public static List<Li_PaperTransfer> GetAllLi_PaperTransfers()
    {
        List<Li_PaperTransfer> li_PaperTransfers = new List<Li_PaperTransfer>();
        SqlLi_PaperTransferProvider sqlLi_PaperTransferProvider = new SqlLi_PaperTransferProvider();
        li_PaperTransfers = sqlLi_PaperTransferProvider.GetAllLi_PaperTransfers();
        return li_PaperTransfers;
    }


    public static Li_PaperTransfer GetLi_PaperTransferByID(int id)
    {
        Li_PaperTransfer li_PaperTransfer = new Li_PaperTransfer();
        SqlLi_PaperTransferProvider sqlLi_PaperTransferProvider = new SqlLi_PaperTransferProvider();
        li_PaperTransfer = sqlLi_PaperTransferProvider.GetLi_PaperTransferByID(id);
        return li_PaperTransfer;
    }


    public static int InsertLi_PaperTransfer(Li_PaperTransfer li_PaperTransfer)
    {
        SqlLi_PaperTransferProvider sqlLi_PaperTransferProvider = new SqlLi_PaperTransferProvider();
        return sqlLi_PaperTransferProvider.InsertLi_PaperTransfer(li_PaperTransfer);
    }


    public static bool UpdateLi_PaperTransfer(Li_PaperTransfer li_PaperTransfer)
    {
        SqlLi_PaperTransferProvider sqlLi_PaperTransferProvider = new SqlLi_PaperTransferProvider();
        return sqlLi_PaperTransferProvider.UpdateLi_PaperTransfer(li_PaperTransfer);
    }

    public static bool DeleteLi_PaperTransfer(int li_PaperTransferID)
    {
        SqlLi_PaperTransferProvider sqlLi_PaperTransferProvider = new SqlLi_PaperTransferProvider();
        return sqlLi_PaperTransferProvider.DeleteLi_PaperTransfer(li_PaperTransferID);
    }
}
