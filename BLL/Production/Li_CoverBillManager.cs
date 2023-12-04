using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_CoverBillManager
{
	public Li_CoverBillManager()
	{
	}

    public static List<Li_CoverBill> GetAllLi_CoverBills()
    {
        List<Li_CoverBill> li_CoverBills = new List<Li_CoverBill>();
        SqlLi_CoverBillProvider sqlLi_CoverBillProvider = new SqlLi_CoverBillProvider();
        li_CoverBills = sqlLi_CoverBillProvider.GetAllLi_CoverBills();
        return li_CoverBills;
    }


    public static Li_CoverBill GetLi_CoverBillByID(int id)
    {
        Li_CoverBill li_CoverBill = new Li_CoverBill();
        SqlLi_CoverBillProvider sqlLi_CoverBillProvider = new SqlLi_CoverBillProvider();
        li_CoverBill = sqlLi_CoverBillProvider.GetLi_CoverBillByID(id);
        return li_CoverBill;
    }


    public static string  InsertLi_CoverBill(Li_CoverBill li_CoverBill)
    {
        SqlLi_CoverBillProvider sqlLi_CoverBillProvider = new SqlLi_CoverBillProvider();
        return sqlLi_CoverBillProvider.InsertLi_CoverBill(li_CoverBill);
    }


    public static bool UpdateLi_CoverBill(Li_CoverBill li_CoverBill)
    {
        SqlLi_CoverBillProvider sqlLi_CoverBillProvider = new SqlLi_CoverBillProvider();
        return sqlLi_CoverBillProvider.UpdateLi_CoverBill(li_CoverBill);
    }

    public static bool DeleteLi_CoverBill(int li_CoverBillID)
    {
        SqlLi_CoverBillProvider sqlLi_CoverBillProvider = new SqlLi_CoverBillProvider();
        return sqlLi_CoverBillProvider.DeleteLi_CoverBill(li_CoverBillID);
    }
}
