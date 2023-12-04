using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Paper_DeliveryManager
{
	public Li_Paper_DeliveryManager()
	{
	}

    public static List<Li_Paper_Delivery> GetAllLi_Paper_Deliveries()
    {
        List<Li_Paper_Delivery> li_Paper_Deliveries = new List<Li_Paper_Delivery>();
        SqlLi_Paper_DeliveryProvider sqlLi_Paper_DeliveryProvider = new SqlLi_Paper_DeliveryProvider();
        li_Paper_Deliveries = sqlLi_Paper_DeliveryProvider.GetAllLi_Paper_Deliveries();
        return li_Paper_Deliveries;
    }


    public static Li_Paper_Delivery GetLi_Paper_DeliveryByID(int id)
    {
        Li_Paper_Delivery li_Paper_Delivery = new Li_Paper_Delivery();
        SqlLi_Paper_DeliveryProvider sqlLi_Paper_DeliveryProvider = new SqlLi_Paper_DeliveryProvider();
        li_Paper_Delivery = sqlLi_Paper_DeliveryProvider.GetLi_Paper_DeliveryByID(id);
        return li_Paper_Delivery;
    }


    public static string  InsertLi_Paper_Delivery(Li_Paper_Delivery li_Paper_Delivery)
    {
        SqlLi_Paper_DeliveryProvider sqlLi_Paper_DeliveryProvider = new SqlLi_Paper_DeliveryProvider();
        return sqlLi_Paper_DeliveryProvider.InsertLi_Paper_Delivery(li_Paper_Delivery);
    }


    public static bool UpdateLi_Paper_Delivery(Li_Paper_Delivery li_Paper_Delivery)
    {
        SqlLi_Paper_DeliveryProvider sqlLi_Paper_DeliveryProvider = new SqlLi_Paper_DeliveryProvider();
        return sqlLi_Paper_DeliveryProvider.UpdateLi_Paper_Delivery(li_Paper_Delivery);
    }

    public static bool DeleteLi_Paper_Delivery(int li_Paper_DeliveryID)
    {
        SqlLi_Paper_DeliveryProvider sqlLi_Paper_DeliveryProvider = new SqlLi_Paper_DeliveryProvider();
        return sqlLi_Paper_DeliveryProvider.DeleteLi_Paper_Delivery(li_Paper_DeliveryID);
    }


    public static DataSet GetPaperBillInfo( string fromDate,string toDate, string SupplierID, string BillNo)
    {
        DataSet ds = new DataSet();
        SqlLi_Paper_DeliveryProvider sqlLi_Paper_DeliveryProvider = new SqlLi_Paper_DeliveryProvider();
        ds = sqlLi_Paper_DeliveryProvider.GetPaperBillInfo(fromDate, toDate, SupplierID, BillNo);
        return ds;
    }

    public static void  CancelPaperDelivery(int SlNo, string PressID, string PaperCode, decimal Qty, int deleBy, DateTime DeleteDate, string CauseOfDel, string DeleveryID)
    {
        
        SqlLi_Paper_DeliveryProvider sqlLi_Paper_DeliveryProvider = new SqlLi_Paper_DeliveryProvider();
        sqlLi_Paper_DeliveryProvider. CancelPaperDelivery(   SlNo,   PressID,   PaperCode,   Qty,   deleBy,   DeleteDate,   CauseOfDel,   DeleveryID);
       
    }
}
