using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
 


public class Li_TranferReturnToMainManager
{
	public Li_TranferReturnToMainManager()
	{
	}

    public static List<Li_TranferReturnToMain> GetAllLi_TranferReturnToMains()
    {
        List<Li_TranferReturnToMain> li_TranferReturnToMains = new List<Li_TranferReturnToMain>();
        SqlLi_TranferReturnToMainProvider sqlLi_TranferReturnToMainProvider = new SqlLi_TranferReturnToMainProvider();
        li_TranferReturnToMains = sqlLi_TranferReturnToMainProvider.GetAllLi_TranferReturnToMains();
        return li_TranferReturnToMains;
    }


    public static Li_TranferReturnToMain GetLi_TranferReturnToMainByID(int id)
    {
        Li_TranferReturnToMain li_TranferReturnToMain = new Li_TranferReturnToMain();
        SqlLi_TranferReturnToMainProvider sqlLi_TranferReturnToMainProvider = new SqlLi_TranferReturnToMainProvider();
        li_TranferReturnToMain = sqlLi_TranferReturnToMainProvider.GetLi_TranferReturnToMainByID(id);
        return li_TranferReturnToMain;
    }


    public static string  InsertLi_TranferReturnToMain(Li_TranferReturnToMain li_TranferReturnToMain)
    {
        SqlLi_TranferReturnToMainProvider sqlLi_TranferReturnToMainProvider = new SqlLi_TranferReturnToMainProvider();
        return sqlLi_TranferReturnToMainProvider.InsertLi_TranferReturnToMain(li_TranferReturnToMain);
    }


    public static bool UpdateLi_TranferReturnToMain(Li_TranferReturnToMain li_TranferReturnToMain)
    {
        SqlLi_TranferReturnToMainProvider sqlLi_TranferReturnToMainProvider = new SqlLi_TranferReturnToMainProvider();
        return sqlLi_TranferReturnToMainProvider.UpdateLi_TranferReturnToMain(li_TranferReturnToMain);
    }

    public static bool DeleteLi_TranferReturnToMain(int li_TranferReturnToMainID)
    {
        SqlLi_TranferReturnToMainProvider sqlLi_TranferReturnToMainProvider = new SqlLi_TranferReturnToMainProvider();
        return sqlLi_TranferReturnToMainProvider.DeleteLi_TranferReturnToMain(li_TranferReturnToMainID);
    }
}
