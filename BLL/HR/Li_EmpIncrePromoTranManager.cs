using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpIncrePromoTranManager
{
	public Li_EmpIncrePromoTranManager()
	{
	}

    public static List<Li_EmpIncrePromoTran> GetAllLi_EmpIncrePromoTrans()
    {
        List<Li_EmpIncrePromoTran> li_EmpIncrePromoTrans = new List<Li_EmpIncrePromoTran>();
        SqlLi_EmpIncrePromoTranProvider sqlLi_EmpIncrePromoTranProvider = new SqlLi_EmpIncrePromoTranProvider();
        li_EmpIncrePromoTrans = sqlLi_EmpIncrePromoTranProvider.GetAllLi_EmpIncrePromoTrans();
        return li_EmpIncrePromoTrans;
    }


    public static Li_EmpIncrePromoTran GetLi_EmpIncrePromoTranByID(int id)
    {
        Li_EmpIncrePromoTran li_EmpIncrePromoTran = new Li_EmpIncrePromoTran();
        SqlLi_EmpIncrePromoTranProvider sqlLi_EmpIncrePromoTranProvider = new SqlLi_EmpIncrePromoTranProvider();
        li_EmpIncrePromoTran = sqlLi_EmpIncrePromoTranProvider.GetLi_EmpIncrePromoTranByID(id);
        return li_EmpIncrePromoTran;
    }


    public static int InsertLi_EmpIncrePromoTran(Li_EmpIncrePromoTran li_EmpIncrePromoTran)
    {
        SqlLi_EmpIncrePromoTranProvider sqlLi_EmpIncrePromoTranProvider = new SqlLi_EmpIncrePromoTranProvider();
        return sqlLi_EmpIncrePromoTranProvider.InsertLi_EmpIncrePromoTran(li_EmpIncrePromoTran);
    }


    public static bool UpdateLi_EmpIncrePromoTran(Li_EmpIncrePromoTran li_EmpIncrePromoTran)
    {
        SqlLi_EmpIncrePromoTranProvider sqlLi_EmpIncrePromoTranProvider = new SqlLi_EmpIncrePromoTranProvider();
        return sqlLi_EmpIncrePromoTranProvider.UpdateLi_EmpIncrePromoTran(li_EmpIncrePromoTran);
    }

    public static bool DeleteLi_EmpIncrePromoTran(int li_EmpIncrePromoTranID)
    {
        SqlLi_EmpIncrePromoTranProvider sqlLi_EmpIncrePromoTranProvider = new SqlLi_EmpIncrePromoTranProvider();
        return sqlLi_EmpIncrePromoTranProvider.DeleteLi_EmpIncrePromoTran(li_EmpIncrePromoTranID);
    }
}
