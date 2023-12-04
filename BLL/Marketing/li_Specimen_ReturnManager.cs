using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_Specimen_ReturnManager
{
	public Li_Specimen_ReturnManager()
	{
	}

    public static List<Li_Specimen_Return> GetAllLi_Specimen_Returns()
    {
        List<Li_Specimen_Return> li_Specimen_Returns = new List<Li_Specimen_Return>();
        SqlLi_Specimen_ReturnProvider sqlLi_Specimen_ReturnProvider = new SqlLi_Specimen_ReturnProvider();
        li_Specimen_Returns = sqlLi_Specimen_ReturnProvider.GetAllLi_Specimen_Returns();
        return li_Specimen_Returns;
    }


    public static Li_Specimen_Return GetLi_Specimen_ReturnByID(int id)
    {
        Li_Specimen_Return li_Specimen_Return = new Li_Specimen_Return();
        SqlLi_Specimen_ReturnProvider sqlLi_Specimen_ReturnProvider = new SqlLi_Specimen_ReturnProvider();
        li_Specimen_Return = sqlLi_Specimen_ReturnProvider.GetLi_Specimen_ReturnByID(id);
        return li_Specimen_Return;
    }


    public static string  InsertLi_Specimen_Return(Li_Specimen_Return li_Specimen_Return)
    {
        SqlLi_Specimen_ReturnProvider sqlLi_Specimen_ReturnProvider = new SqlLi_Specimen_ReturnProvider();
        return sqlLi_Specimen_ReturnProvider.InsertLi_Specimen_Return(li_Specimen_Return);
    }


    public static bool UpdateLi_Specimen_Return(Li_Specimen_Return li_Specimen_Return)
    {
        SqlLi_Specimen_ReturnProvider sqlLi_Specimen_ReturnProvider = new SqlLi_Specimen_ReturnProvider();
        return sqlLi_Specimen_ReturnProvider.UpdateLi_Specimen_Return(li_Specimen_Return);
    }

    public static bool DeleteLi_Specimen_Return(int li_Specimen_ReturnID)
    {
        SqlLi_Specimen_ReturnProvider sqlLi_Specimen_ReturnProvider = new SqlLi_Specimen_ReturnProvider();
        return sqlLi_Specimen_ReturnProvider.DeleteLi_Specimen_Return(li_Specimen_ReturnID);
    }

    public static DataSet GetAll_BookPriceAndTSOwiseQty(string TSOId, string bookAcCode)
    {
        DataSet ds = new DataSet();
        SqlLi_Specimen_ReturnProvider Sql_li_SpecimenAdjustmentProvider = new SqlLi_Specimen_ReturnProvider();
        ds = Sql_li_SpecimenAdjustmentProvider.GetAll_BookPriceAndTSOwiseQty(TSOId, bookAcCode);
        return ds;
    }
}
