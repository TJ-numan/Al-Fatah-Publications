using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;



public class Li_PlateReturnTransferManager
{
	public Li_PlateReturnTransferManager()
	{
	}

    public static List<Li_PlateReturnTransfer> GetAllLi_PlateReturnTransfers()
    {
        List<Li_PlateReturnTransfer> li_PlateReturnTransfers = new List<Li_PlateReturnTransfer>();
        SqlLi_PlateReturnTransferProvider sqlLi_PlateReturnTransferProvider = new SqlLi_PlateReturnTransferProvider();
        li_PlateReturnTransfers = sqlLi_PlateReturnTransferProvider.GetAllLi_PlateReturnTransfers();
        return li_PlateReturnTransfers;
    }


    public static Li_PlateReturnTransfer GetLi_PlateReturnTransferByID(int id)
    {
        Li_PlateReturnTransfer li_PlateReturnTransfer = new Li_PlateReturnTransfer();
        SqlLi_PlateReturnTransferProvider sqlLi_PlateReturnTransferProvider = new SqlLi_PlateReturnTransferProvider();
        li_PlateReturnTransfer = sqlLi_PlateReturnTransferProvider.GetLi_PlateReturnTransferByID(id);
        return li_PlateReturnTransfer;
    }


    public static string  InsertLi_PlateReturnTransfer(Li_PlateReturnTransfer li_PlateReturnTransfer)
    {
        SqlLi_PlateReturnTransferProvider sqlLi_PlateReturnTransferProvider = new SqlLi_PlateReturnTransferProvider();
        return sqlLi_PlateReturnTransferProvider.InsertLi_PlateReturnTransfer(li_PlateReturnTransfer);
    }


    public static bool UpdateLi_PlateReturnTransfer(Li_PlateReturnTransfer li_PlateReturnTransfer)
    {
        SqlLi_PlateReturnTransferProvider sqlLi_PlateReturnTransferProvider = new SqlLi_PlateReturnTransferProvider();
        return sqlLi_PlateReturnTransferProvider.UpdateLi_PlateReturnTransfer(li_PlateReturnTransfer);
    }

    public static bool DeleteLi_PlateReturnTransfer(int li_PlateReturnTransferID)
    {
        SqlLi_PlateReturnTransferProvider sqlLi_PlateReturnTransferProvider = new SqlLi_PlateReturnTransferProvider();
        return sqlLi_PlateReturnTransferProvider.DeleteLi_PlateReturnTransfer(li_PlateReturnTransferID);
    }
}
