using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

public class li_PlateTransferManager
{
    public li_PlateTransferManager()
	{
	}

    public static List<Li_PlateTransfer> GetAllLi_PlateTransfers()
    {
        List<Li_PlateTransfer> li_PlateTransfers = new List<Li_PlateTransfer>();
        Sqlli_PlateTransferProvider sqlLi_PlateTransferProvider = new Sqlli_PlateTransferProvider();
        li_PlateTransfers = sqlLi_PlateTransferProvider.GetAllLi_PlateTransfers();
        return li_PlateTransfers;
    }


    public static Li_PlateTransfer GetLi_PlateTransferByID(int id)
    {
        Li_PlateTransfer li_PlateTransfer = new Li_PlateTransfer();
        Sqlli_PlateTransferProvider sqlLi_PlateTransferProvider = new Sqlli_PlateTransferProvider();
        li_PlateTransfer = sqlLi_PlateTransferProvider.GetLi_PlateTransferByID(id);
        return li_PlateTransfer;
    }


    public static int InsertLi_PlateTransfer(Li_PlateTransfer li_PlateTransfer)
    {
        Sqlli_PlateTransferProvider sqlLi_PlateTransferProvider = new Sqlli_PlateTransferProvider();
        return sqlLi_PlateTransferProvider.InsertLi_PlateTransfer(li_PlateTransfer);
    }


    public static bool UpdateLi_PlateTransfer(Li_PlateTransfer li_PlateTransfer)
    {
        Sqlli_PlateTransferProvider sqlLi_PlateTransferProvider = new Sqlli_PlateTransferProvider();
        return sqlLi_PlateTransferProvider.UpdateLi_PlateTransfer(li_PlateTransfer);
    }

    public static bool DeleteLi_PlateTransfer(int li_PlateTransferID)
    {
        Sqlli_PlateTransferProvider sqlLi_PlateTransferProvider = new Sqlli_PlateTransferProvider();
        return sqlLi_PlateTransferProvider.DeleteLi_PlateTransfer(li_PlateTransferID);
    }
}
