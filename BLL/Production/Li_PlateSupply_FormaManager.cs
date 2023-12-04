using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_PlateSupply_FormaManager
{
	public Li_PlateSupply_FormaManager()
	{
	}

    public static List<Li_PlateSupply_Forma> GetAllLi_PlateSupply_Formas()
    {
        List<Li_PlateSupply_Forma> li_PlateSupply_Formas = new List<Li_PlateSupply_Forma>();
        SqlLi_PlateSupply_FormaProvider sqlLi_PlateSupply_FormaProvider = new SqlLi_PlateSupply_FormaProvider();
        li_PlateSupply_Formas = sqlLi_PlateSupply_FormaProvider.GetAllLi_PlateSupply_Formas();
        return li_PlateSupply_Formas;
    }


    public static Li_PlateSupply_Forma GetLi_PlateSupply_FormaByID(int id)
    {
        Li_PlateSupply_Forma li_PlateSupply_Forma = new Li_PlateSupply_Forma();
        SqlLi_PlateSupply_FormaProvider sqlLi_PlateSupply_FormaProvider = new SqlLi_PlateSupply_FormaProvider();
        li_PlateSupply_Forma = sqlLi_PlateSupply_FormaProvider.GetLi_PlateSupply_FormaByID(id);
        return li_PlateSupply_Forma;
    }


    public static string   InsertLi_PlateSupply_Forma(Li_PlateSupply_Forma li_PlateSupply_Forma)
    {
        SqlLi_PlateSupply_FormaProvider sqlLi_PlateSupply_FormaProvider = new SqlLi_PlateSupply_FormaProvider();
        return sqlLi_PlateSupply_FormaProvider.InsertLi_PlateSupply_Forma(li_PlateSupply_Forma);
    }


    public static bool UpdateLi_PlateSupply_Forma(Li_PlateSupply_Forma li_PlateSupply_Forma)
    {
        SqlLi_PlateSupply_FormaProvider sqlLi_PlateSupply_FormaProvider = new SqlLi_PlateSupply_FormaProvider();
        return sqlLi_PlateSupply_FormaProvider.UpdateLi_PlateSupply_Forma(li_PlateSupply_Forma);
    }

    public static bool DeleteLi_PlateSupply_Forma(int li_PlateSupply_FormaID)
    {
        SqlLi_PlateSupply_FormaProvider sqlLi_PlateSupply_FormaProvider = new SqlLi_PlateSupply_FormaProvider();
        return sqlLi_PlateSupply_FormaProvider.DeleteLi_PlateSupply_Forma(li_PlateSupply_FormaID);
    }


    public static DataSet getPlateOrderInfoByBookID(string BookID)
    {

        SqlLi_PlateSupply_FormaProvider sqlLi_PlateSupply_FormaProvider = new SqlLi_PlateSupply_FormaProvider();    
        return sqlLi_PlateSupply_FormaProvider .getPlateOrderInfoByBookID(BookID);

    }
    public static DataSet getPlateOrderInfoByEdition(string BookCode)
    {

        SqlLi_PlateSupply_FormaProvider sqlLi_PlateSupply_FormaProvider = new SqlLi_PlateSupply_FormaProvider();    
        return sqlLi_PlateSupply_FormaProvider .getPlateOrderInfoByEdition( BookCode );

    }

    public static DataSet  GetPlateDeliveryInforByPrintOrderNo(string OrderNo)
    {
 
        SqlLi_PlateSupply_FormaProvider sqlLi_PlateSupply_FormaProvider = new SqlLi_PlateSupply_FormaProvider();    
        return sqlLi_PlateSupply_FormaProvider .GetPlateDeliveryInforByPrintOrderNo( OrderNo); 

    }

    public static DataSet GetPlateDeliveryInforByPrintOrderNoAndPress(string OrderNo, string PressID, bool IsExtra)
    {
 
        SqlLi_PlateSupply_FormaProvider sqlLi_PlateSupply_FormaProvider = new SqlLi_PlateSupply_FormaProvider();    
        return sqlLi_PlateSupply_FormaProvider . GetPlateDeliveryInforByPrintOrderNoAndPress(  OrderNo,  PressID,   IsExtra); 

    }
}
