using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TraningFeedBackManager
{
	public Li_TraningFeedBackManager()
	{
	}

    public static List<Li_TraningFeedBack> GetAllLi_TraningFeedBacks()
    {
        List<Li_TraningFeedBack> li_TraningFeedBacks = new List<Li_TraningFeedBack>();
        SqlLi_TraningFeedBackProvider sqlLi_TraningFeedBackProvider = new SqlLi_TraningFeedBackProvider();
        li_TraningFeedBacks = sqlLi_TraningFeedBackProvider.GetAllLi_TraningFeedBacks();
        return li_TraningFeedBacks;
    }


    public static Li_TraningFeedBack GetLi_TraningFeedBackByID(int id)
    {
        Li_TraningFeedBack li_TraningFeedBack = new Li_TraningFeedBack();
        SqlLi_TraningFeedBackProvider sqlLi_TraningFeedBackProvider = new SqlLi_TraningFeedBackProvider();
        li_TraningFeedBack = sqlLi_TraningFeedBackProvider.GetLi_TraningFeedBackByID(id);
        return li_TraningFeedBack;
    }


    public static int InsertLi_TraningFeedBack(Li_TraningFeedBack li_TraningFeedBack)
    {
        SqlLi_TraningFeedBackProvider sqlLi_TraningFeedBackProvider = new SqlLi_TraningFeedBackProvider();
        return sqlLi_TraningFeedBackProvider.InsertLi_TraningFeedBack(li_TraningFeedBack);
    }


    public static bool UpdateLi_TraningFeedBack(Li_TraningFeedBack li_TraningFeedBack)
    {
        SqlLi_TraningFeedBackProvider sqlLi_TraningFeedBackProvider = new SqlLi_TraningFeedBackProvider();
        return sqlLi_TraningFeedBackProvider.UpdateLi_TraningFeedBack(li_TraningFeedBack);
    }

    public static bool DeleteLi_TraningFeedBack(int li_TraningFeedBackID)
    {
        SqlLi_TraningFeedBackProvider sqlLi_TraningFeedBackProvider = new SqlLi_TraningFeedBackProvider();
        return sqlLi_TraningFeedBackProvider.DeleteLi_TraningFeedBack(li_TraningFeedBackID);
    }
}
