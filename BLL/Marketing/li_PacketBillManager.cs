using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PacketBillManager
{
	public Li_PacketBillManager()
	{
	}

    public static List<Li_PacketBill> GetAllLi_PacketBills()
    {
        List<Li_PacketBill> li_PacketBills = new List<Li_PacketBill>();
        SqlLi_PacketBillProvider sqlLi_PacketBillProvider = new SqlLi_PacketBillProvider();
        li_PacketBills = sqlLi_PacketBillProvider.GetAllLi_PacketBills();
        return li_PacketBills;
    }


    public static Li_PacketBill GetLi_PacketBillByID(int id)
    {
        Li_PacketBill li_PacketBill = new Li_PacketBill();
        SqlLi_PacketBillProvider sqlLi_PacketBillProvider = new SqlLi_PacketBillProvider();
        li_PacketBill = sqlLi_PacketBillProvider.GetLi_PacketBillByID(id);
        return li_PacketBill;
    }


    public static int InsertLi_PacketBill(Li_PacketBill li_PacketBill)
    {
        SqlLi_PacketBillProvider sqlLi_PacketBillProvider = new SqlLi_PacketBillProvider();
        return sqlLi_PacketBillProvider.InsertLi_PacketBill(li_PacketBill);
    }
   public static int InsertLi_SpecimenPacketBill(Li_PacketBill li_PacketBill)
    {
        SqlLi_PacketBillProvider sqlLi_PacketBillProvider = new SqlLi_PacketBillProvider();
        return sqlLi_PacketBillProvider.InsertLi_SpecimenPacketBill(li_PacketBill);
    }


    public static bool UpdateLi_PacketBill(Li_PacketBill li_PacketBill)
    {
        SqlLi_PacketBillProvider sqlLi_PacketBillProvider = new SqlLi_PacketBillProvider();
        return sqlLi_PacketBillProvider.UpdateLi_PacketBill(li_PacketBill);
    }

    public static bool DeleteLi_PacketBill(int li_PacketBillID)
    {
        SqlLi_PacketBillProvider sqlLi_PacketBillProvider = new SqlLi_PacketBillProvider();
        return sqlLi_PacketBillProvider.DeleteLi_PacketBill(li_PacketBillID);
    }
}
