using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BankNameManager
{
	public Li_BankNameManager()
	{
	}

    public static List<Li_BankName> GetAllLi_BankNames()
    {
        List<Li_BankName> li_BankNames = new List<Li_BankName>();
        SqlLi_BankNameProvider sqlLi_BankNameProvider = new SqlLi_BankNameProvider();
        li_BankNames = sqlLi_BankNameProvider.GetAllLi_BankNames();
        return li_BankNames;
    }


    public static Li_BankName GetLi_BankNameByID(int id)
    {
        Li_BankName li_BankName = new Li_BankName();
        SqlLi_BankNameProvider sqlLi_BankNameProvider = new SqlLi_BankNameProvider();
        li_BankName = sqlLi_BankNameProvider.GetLi_BankNameByID(id);
        return li_BankName;
    }


    public static int InsertLi_BankName(Li_BankName li_BankName)
    {
        SqlLi_BankNameProvider sqlLi_BankNameProvider = new SqlLi_BankNameProvider();
        return sqlLi_BankNameProvider.InsertLi_BankName(li_BankName);
    }


    public static bool UpdateLi_BankName(Li_BankName li_BankName)
    {
        SqlLi_BankNameProvider sqlLi_BankNameProvider = new SqlLi_BankNameProvider();
        return sqlLi_BankNameProvider.UpdateLi_BankName(li_BankName);
    }

    public static bool DeleteLi_BankName(int li_BankNameID)
    {
        SqlLi_BankNameProvider sqlLi_BankNameProvider = new SqlLi_BankNameProvider();
        return sqlLi_BankNameProvider.DeleteLi_BankName(li_BankNameID);
    }

    public static DataSet GetLi_PayFor()
    {
        DataSet ds = new DataSet();
        SqlLi_BankNameProvider sqlLi_BankNameProvider = new SqlLi_BankNameProvider();
        ds = sqlLi_BankNameProvider.GetAllLi_Payfor();
        return ds;
    }
}
