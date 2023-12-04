using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintBillManager
{
	public Li_PrintBillManager()
	{
	}

    public static List<Li_PrintBill> GetAllLi_PrintBills()
    {
        List<Li_PrintBill> li_PrintBills = new List<Li_PrintBill>();
        SqlLi_PrintBillProvider sqlLi_PrintBillProvider = new SqlLi_PrintBillProvider();
        li_PrintBills = sqlLi_PrintBillProvider.GetAllLi_PrintBills();
        return li_PrintBills;
    }


    public static Li_PrintBill GetLi_PrintBillByID(int id)
    {
        Li_PrintBill li_PrintBill = new Li_PrintBill();
        SqlLi_PrintBillProvider sqlLi_PrintBillProvider = new SqlLi_PrintBillProvider();
        li_PrintBill = sqlLi_PrintBillProvider.GetLi_PrintBillByID(id);
        return li_PrintBill;
    }


    public static int InsertLi_PrintBill(Li_PrintBill li_PrintBill)
    {
        SqlLi_PrintBillProvider sqlLi_PrintBillProvider = new SqlLi_PrintBillProvider();
        return sqlLi_PrintBillProvider.InsertLi_PrintBill(li_PrintBill);
    }


    public static bool UpdateLi_PrintBill(Li_PrintBill li_PrintBill)
    {
        SqlLi_PrintBillProvider sqlLi_PrintBillProvider = new SqlLi_PrintBillProvider();
        return sqlLi_PrintBillProvider.UpdateLi_PrintBill(li_PrintBill);
    }

    public static bool DeleteLi_PrintBill(int li_PrintBillID)
    {
        SqlLi_PrintBillProvider sqlLi_PrintBillProvider = new SqlLi_PrintBillProvider();
        return sqlLi_PrintBillProvider.DeleteLi_PrintBill(li_PrintBillID);
    }
}
