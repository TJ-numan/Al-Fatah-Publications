using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_CvBankManager
{
	public Li_CvBankManager()
	{
	}

    public static List<Li_CvBank> GetAllLi_CvBanks()
    {
        List<Li_CvBank> li_CvBanks = new List<Li_CvBank>();
        SqlLi_CvBankProvider sqlLi_CvBankProvider = new SqlLi_CvBankProvider();
        li_CvBanks = sqlLi_CvBankProvider.GetAllLi_CvBanks();
        return li_CvBanks;
    }


    public static Li_CvBank GetLi_CvBankByID(int id)
    {
        Li_CvBank li_CvBank = new Li_CvBank();
        SqlLi_CvBankProvider sqlLi_CvBankProvider = new SqlLi_CvBankProvider();
        li_CvBank = sqlLi_CvBankProvider.GetLi_CvBankByID(id);
        return li_CvBank;
    }


    public static int InsertLi_CvBank(Li_CvBank li_CvBank)
    {
        SqlLi_CvBankProvider sqlLi_CvBankProvider = new SqlLi_CvBankProvider();
        return sqlLi_CvBankProvider.InsertLi_CvBank(li_CvBank);
    }


    public static bool UpdateLi_CvBank(Li_CvBank li_CvBank)
    {
        SqlLi_CvBankProvider sqlLi_CvBankProvider = new SqlLi_CvBankProvider();
        return sqlLi_CvBankProvider.UpdateLi_CvBank(li_CvBank);
    }

    public static bool DeleteLi_CvBank(int li_CvBankID)
    {
        SqlLi_CvBankProvider sqlLi_CvBankProvider = new SqlLi_CvBankProvider();
        return sqlLi_CvBankProvider.DeleteLi_CvBank(li_CvBankID);
    }
}
