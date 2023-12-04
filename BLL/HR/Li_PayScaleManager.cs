using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PayScaleManager
{
	public Li_PayScaleManager()
	{
	}

    public static List<Li_PayScale> GetAllLi_PayScales()
    {
        List<Li_PayScale> li_PayScales = new List<Li_PayScale>();
        SqlLi_PayScaleProvider sqlLi_PayScaleProvider = new SqlLi_PayScaleProvider();
        li_PayScales = sqlLi_PayScaleProvider.GetAllLi_PayScales();
        return li_PayScales;
    }


    public static Li_PayScale GetLi_PayScaleByID(int id)
    {
        Li_PayScale li_PayScale = new Li_PayScale();
        SqlLi_PayScaleProvider sqlLi_PayScaleProvider = new SqlLi_PayScaleProvider();
        li_PayScale = sqlLi_PayScaleProvider.GetLi_PayScaleByID(id);
        return li_PayScale;
    }


    public static int InsertLi_PayScale(Li_PayScale li_PayScale)
    {
        SqlLi_PayScaleProvider sqlLi_PayScaleProvider = new SqlLi_PayScaleProvider();
        return sqlLi_PayScaleProvider.InsertLi_PayScale(li_PayScale);
    }


    public static bool UpdateLi_PayScale(Li_PayScale li_PayScale)
    {
        SqlLi_PayScaleProvider sqlLi_PayScaleProvider = new SqlLi_PayScaleProvider();
        return sqlLi_PayScaleProvider.UpdateLi_PayScale(li_PayScale);
    }

    public static bool DeleteLi_PayScale(int li_PayScaleID)
    {
        SqlLi_PayScaleProvider sqlLi_PayScaleProvider = new SqlLi_PayScaleProvider();
        return sqlLi_PayScaleProvider.DeleteLi_PayScale(li_PayScaleID);
    }
}
