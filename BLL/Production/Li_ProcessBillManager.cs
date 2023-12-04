using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_ProcessBillManager
{
	public Li_ProcessBillManager()
	{
	}

    public static List<Li_ProcessBill> GetAllLi_ProcessBills()
    {
        List<Li_ProcessBill> li_ProcessBills = new List<Li_ProcessBill>();
        SqlLi_ProcessBillProvider sqlLi_ProcessBillProvider = new SqlLi_ProcessBillProvider();
        li_ProcessBills = sqlLi_ProcessBillProvider.GetAllLi_ProcessBills();
        return li_ProcessBills;
    }


    public static Li_ProcessBill GetLi_ProcessBillByID(int id)
    {
        Li_ProcessBill li_ProcessBill = new Li_ProcessBill();
        SqlLi_ProcessBillProvider sqlLi_ProcessBillProvider = new SqlLi_ProcessBillProvider();
        li_ProcessBill = sqlLi_ProcessBillProvider.GetLi_ProcessBillByID(id);
        return li_ProcessBill;
    }


    public static int InsertLi_ProcessBill(Li_ProcessBill li_ProcessBill)
    {
        SqlLi_ProcessBillProvider sqlLi_ProcessBillProvider = new SqlLi_ProcessBillProvider();
        return sqlLi_ProcessBillProvider.InsertLi_ProcessBill(li_ProcessBill);
    }


    public static bool UpdateLi_ProcessBill(Li_ProcessBill li_ProcessBill)
    {
        SqlLi_ProcessBillProvider sqlLi_ProcessBillProvider = new SqlLi_ProcessBillProvider();
        return sqlLi_ProcessBillProvider.UpdateLi_ProcessBill(li_ProcessBill);
    }

    public static bool DeleteLi_ProcessBill(int li_ProcessBillID)
    {
        SqlLi_ProcessBillProvider sqlLi_ProcessBillProvider = new SqlLi_ProcessBillProvider();
        return sqlLi_ProcessBillProvider.DeleteLi_ProcessBill(li_ProcessBillID);
    }

    public static DataSet GetPlateProcessDetail(string ProcessID)
    {
         SqlLi_ProcessBillProvider sqlLi_ProcessBillProvider = new SqlLi_ProcessBillProvider();
         return sqlLi_ProcessBillProvider.GetPlateProcessDetail (ProcessID );
    }
}
