using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_PlateBillManager
{
	public Li_PlateBillManager()
	{
	}

    public static List<Li_PlateBill> GetAllLi_PlateBills()
    {
        List<Li_PlateBill> li_PlateBills = new List<Li_PlateBill>();
        SqlLi_PlateBillProvider sqlLi_PlateBillProvider = new SqlLi_PlateBillProvider();
        li_PlateBills = sqlLi_PlateBillProvider.GetAllLi_PlateBills();
        return li_PlateBills;
    }


    public static Li_PlateBill GetLi_PlateBillByID(int id)
    {
        Li_PlateBill li_PlateBill = new Li_PlateBill();
        SqlLi_PlateBillProvider sqlLi_PlateBillProvider = new SqlLi_PlateBillProvider();
        li_PlateBill = sqlLi_PlateBillProvider.GetLi_PlateBillByID(id);
        return li_PlateBill;
    }


    public static int InsertLi_PlateBill(Li_PlateBill li_PlateBill)
    {
        SqlLi_PlateBillProvider sqlLi_PlateBillProvider = new SqlLi_PlateBillProvider();
        return sqlLi_PlateBillProvider.InsertLi_PlateBill(li_PlateBill);
    }


    public static bool UpdateLi_PlateBill(Li_PlateBill li_PlateBill)
    {
        SqlLi_PlateBillProvider sqlLi_PlateBillProvider = new SqlLi_PlateBillProvider();
        return sqlLi_PlateBillProvider.UpdateLi_PlateBill(li_PlateBill);
    }

    public static bool DeleteLi_PlateBill(int li_PlateBillID)
    {
        SqlLi_PlateBillProvider sqlLi_PlateBillProvider = new SqlLi_PlateBillProvider();
        return sqlLi_PlateBillProvider.DeleteLi_PlateBill(li_PlateBillID);
    }


    public static DataSet GetPlatePurchaseDetail(string SupplierID)
    {
        SqlLi_PlateBillProvider sqlLi_PlateBillProvider = new SqlLi_PlateBillProvider();
        return sqlLi_PlateBillProvider.GetPlatePurchaseDetail ( SupplierID);
    }
}
