using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BinderBillManager
{
	public Li_BinderBillManager()
	{
	}

    public static List<Li_BinderBill> GetAllLi_BinderBills()
    {
        List<Li_BinderBill> li_BinderBills = new List<Li_BinderBill>();
        SqlLi_BinderBillProvider sqlLi_BinderBillProvider = new SqlLi_BinderBillProvider();
        li_BinderBills = sqlLi_BinderBillProvider.GetAllLi_BinderBills();
        return li_BinderBills;
    }


    public static Li_BinderBill GetLi_BinderBillByID(int id)
    {
        Li_BinderBill li_BinderBill = new Li_BinderBill();
        SqlLi_BinderBillProvider sqlLi_BinderBillProvider = new SqlLi_BinderBillProvider();
        li_BinderBill = sqlLi_BinderBillProvider.GetLi_BinderBillByID(id);
        return li_BinderBill;
    }


    public static string  InsertLi_BinderBill(Li_BinderBill li_BinderBill)
    {
        SqlLi_BinderBillProvider sqlLi_BinderBillProvider = new SqlLi_BinderBillProvider();
        return sqlLi_BinderBillProvider.InsertLi_BinderBill(li_BinderBill);
    }


    public static bool UpdateLi_BinderBill(Li_BinderBill li_BinderBill)
    {
        SqlLi_BinderBillProvider sqlLi_BinderBillProvider = new SqlLi_BinderBillProvider();
        return sqlLi_BinderBillProvider.UpdateLi_BinderBill(li_BinderBill);
    }

    public static bool DeleteLi_BinderBill(int li_BinderBillID)
    {
        SqlLi_BinderBillProvider sqlLi_BinderBillProvider = new SqlLi_BinderBillProvider();
        return sqlLi_BinderBillProvider.DeleteLi_BinderBill(li_BinderBillID);
    }
}
