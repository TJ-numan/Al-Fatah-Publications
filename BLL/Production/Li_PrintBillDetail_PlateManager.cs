using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PrintBillDetail_PlateManager
{
	public Li_PrintBillDetail_PlateManager()
	{
	}

    public static List<Li_PrintBillDetail_Plate> GetAllLi_PrintBillDetail_Plates()
    {
        List<Li_PrintBillDetail_Plate> li_PrintBillDetail_Plates = new List<Li_PrintBillDetail_Plate>();
        SqlLi_PrintBillDetail_PlateProvider sqlLi_PrintBillDetail_PlateProvider = new SqlLi_PrintBillDetail_PlateProvider();
        li_PrintBillDetail_Plates = sqlLi_PrintBillDetail_PlateProvider.GetAllLi_PrintBillDetail_Plates();
        return li_PrintBillDetail_Plates;
    }


    public static Li_PrintBillDetail_Plate GetLi_PrintBillDetail_PlateByID(int id)
    {
        Li_PrintBillDetail_Plate li_PrintBillDetail_Plate = new Li_PrintBillDetail_Plate();
        SqlLi_PrintBillDetail_PlateProvider sqlLi_PrintBillDetail_PlateProvider = new SqlLi_PrintBillDetail_PlateProvider();
        li_PrintBillDetail_Plate = sqlLi_PrintBillDetail_PlateProvider.GetLi_PrintBillDetail_PlateByID(id);
        return li_PrintBillDetail_Plate;
    }


    public static int InsertLi_PrintBillDetail_Plate(Li_PrintBillDetail_Plate li_PrintBillDetail_Plate)
    {
        SqlLi_PrintBillDetail_PlateProvider sqlLi_PrintBillDetail_PlateProvider = new SqlLi_PrintBillDetail_PlateProvider();
        return sqlLi_PrintBillDetail_PlateProvider.InsertLi_PrintBillDetail_Plate(li_PrintBillDetail_Plate);
    }


    public static bool UpdateLi_PrintBillDetail_Plate(Li_PrintBillDetail_Plate li_PrintBillDetail_Plate)
    {
        SqlLi_PrintBillDetail_PlateProvider sqlLi_PrintBillDetail_PlateProvider = new SqlLi_PrintBillDetail_PlateProvider();
        return sqlLi_PrintBillDetail_PlateProvider.UpdateLi_PrintBillDetail_Plate(li_PrintBillDetail_Plate);
    }

    public static bool DeleteLi_PrintBillDetail_Plate(int li_PrintBillDetail_PlateID)
    {
        SqlLi_PrintBillDetail_PlateProvider sqlLi_PrintBillDetail_PlateProvider = new SqlLi_PrintBillDetail_PlateProvider();
        return sqlLi_PrintBillDetail_PlateProvider.DeleteLi_PrintBillDetail_Plate(li_PrintBillDetail_PlateID);
    }
}
