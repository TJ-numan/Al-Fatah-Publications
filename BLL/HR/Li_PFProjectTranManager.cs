using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFProjectTranManager
{
	public Li_PFProjectTranManager()
	{
	}

    public static List<Li_PFProjectTran> GetAllLi_PFProjectTrans()
    {
        List<Li_PFProjectTran> li_PFProjectTrans = new List<Li_PFProjectTran>();
        SqlLi_PFProjectTranProvider sqlLi_PFProjectTranProvider = new SqlLi_PFProjectTranProvider();
        li_PFProjectTrans = sqlLi_PFProjectTranProvider.GetAllLi_PFProjectTrans();
        return li_PFProjectTrans;
    }


    public static Li_PFProjectTran GetLi_PFProjectTranByID(int id)
    {
        Li_PFProjectTran li_PFProjectTran = new Li_PFProjectTran();
        SqlLi_PFProjectTranProvider sqlLi_PFProjectTranProvider = new SqlLi_PFProjectTranProvider();
        li_PFProjectTran = sqlLi_PFProjectTranProvider.GetLi_PFProjectTranByID(id);
        return li_PFProjectTran;
    }


    public static int InsertLi_PFProjectTran(Li_PFProjectTran li_PFProjectTran)
    {
        SqlLi_PFProjectTranProvider sqlLi_PFProjectTranProvider = new SqlLi_PFProjectTranProvider();
        return sqlLi_PFProjectTranProvider.InsertLi_PFProjectTran(li_PFProjectTran);
    }


    public static bool UpdateLi_PFProjectTran(Li_PFProjectTran li_PFProjectTran)
    {
        SqlLi_PFProjectTranProvider sqlLi_PFProjectTranProvider = new SqlLi_PFProjectTranProvider();
        return sqlLi_PFProjectTranProvider.UpdateLi_PFProjectTran(li_PFProjectTran);
    }

    public static bool DeleteLi_PFProjectTran(int li_PFProjectTranID)
    {
        SqlLi_PFProjectTranProvider sqlLi_PFProjectTranProvider = new SqlLi_PFProjectTranProvider();
        return sqlLi_PFProjectTranProvider.DeleteLi_PFProjectTran(li_PFProjectTranID);
    }
}
