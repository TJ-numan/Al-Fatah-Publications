using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;


public class li_PlateTransferDetailManager
{
    public li_PlateTransferDetailManager()
	{
	}

    public static List<li_PlateTransferDetail> GetAllLi_PlateTransferDetails()
    {
        List<li_PlateTransferDetail> li_PlateTransferDetails = new List<li_PlateTransferDetail>();
        Sqlli_PlateTransferDetailProvider sqlLi_PlateTransferDetailProvider = new Sqlli_PlateTransferDetailProvider();
        li_PlateTransferDetails = sqlLi_PlateTransferDetailProvider.GetAllLi_PlateTransferDetails();
        return li_PlateTransferDetails;
    }


    public static li_PlateTransferDetail GetLi_PlateTransferDetailByID(int id)
    {
        li_PlateTransferDetail li_PlateTransferDetail = new li_PlateTransferDetail();
        Sqlli_PlateTransferDetailProvider sqlLi_PlateTransferDetailProvider = new Sqlli_PlateTransferDetailProvider();
        li_PlateTransferDetail = sqlLi_PlateTransferDetailProvider.GetLi_PlateTransferDetailByID(id);
        return li_PlateTransferDetail;
    }


    public static int InsertLi_PlateTransferDetail(li_PlateTransferDetail li_PlateTransferDetail)
    {
        Sqlli_PlateTransferDetailProvider sqlLi_PlateTransferDetailProvider = new Sqlli_PlateTransferDetailProvider();
        return sqlLi_PlateTransferDetailProvider.InsertLi_PlateTransferDetail(li_PlateTransferDetail);
    }


    public static bool UpdateLi_PlateTransferDetail(li_PlateTransferDetail li_PlateTransferDetail)
    {
        Sqlli_PlateTransferDetailProvider sqlLi_PlateTransferDetailProvider = new Sqlli_PlateTransferDetailProvider();
        return sqlLi_PlateTransferDetailProvider.UpdateLi_PlateTransferDetail(li_PlateTransferDetail);
    }

    public static bool DeleteLi_PlateTransferDetail(int li_PlateTransferDetailID)
    {
        Sqlli_PlateTransferDetailProvider sqlLi_PlateTransferDetailProvider = new Sqlli_PlateTransferDetailProvider();
        return sqlLi_PlateTransferDetailProvider.DeleteLi_PlateTransferDetail(li_PlateTransferDetailID);
    }
}
 