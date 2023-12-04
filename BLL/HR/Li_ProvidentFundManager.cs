using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_ProvidentFundManager
{
	public Li_ProvidentFundManager()
	{
	}

    public static List<Li_ProvidentFund> GetAllLi_ProvidentFunds()
    {
        List<Li_ProvidentFund> li_ProvidentFunds = new List<Li_ProvidentFund>();
        SqlLi_ProvidentFundProvider sqlLi_ProvidentFundProvider = new SqlLi_ProvidentFundProvider();
        li_ProvidentFunds = sqlLi_ProvidentFundProvider.GetAllLi_ProvidentFunds();
        return li_ProvidentFunds;
    }


    public static Li_ProvidentFund GetLi_ProvidentFundByID(int id)
    {
        Li_ProvidentFund li_ProvidentFund = new Li_ProvidentFund();
        SqlLi_ProvidentFundProvider sqlLi_ProvidentFundProvider = new SqlLi_ProvidentFundProvider();
        li_ProvidentFund = sqlLi_ProvidentFundProvider.GetLi_ProvidentFundByID(id);
        return li_ProvidentFund;
    }


    public static int InsertLi_ProvidentFund(Li_ProvidentFund li_ProvidentFund)
    {
        SqlLi_ProvidentFundProvider sqlLi_ProvidentFundProvider = new SqlLi_ProvidentFundProvider();
        return sqlLi_ProvidentFundProvider.InsertLi_ProvidentFund(li_ProvidentFund);
    }


    public static bool UpdateLi_ProvidentFund(Li_ProvidentFund li_ProvidentFund)
    {
        SqlLi_ProvidentFundProvider sqlLi_ProvidentFundProvider = new SqlLi_ProvidentFundProvider();
        return sqlLi_ProvidentFundProvider.UpdateLi_ProvidentFund(li_ProvidentFund);
    }

    public static bool DeleteLi_ProvidentFund(int li_ProvidentFundID)
    {
        SqlLi_ProvidentFundProvider sqlLi_ProvidentFundProvider = new SqlLi_ProvidentFundProvider();
        return sqlLi_ProvidentFundProvider.DeleteLi_ProvidentFund(li_ProvidentFundID);
    }
}
