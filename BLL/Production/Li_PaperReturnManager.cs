using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

public class Li_PaperReturnManager
{

    public Li_PaperReturnManager()
	{
	}

    public static List<Li_PaperReturn> GetAllLi_PaperReturn()
    {
        List<Li_PaperReturn> li_PaperReturn = new List<Li_PaperReturn>();
        SqlLi_PaperReturnProvider sqlLi_PaperReturnProvider = new SqlLi_PaperReturnProvider();
        li_PaperReturn = sqlLi_PaperReturnProvider.GetAllLi_PaperReturn();
        return li_PaperReturn;
    }


    public static Li_PaperReturn GetLi_PaperReturnID(int id)
    {
        Li_PaperReturn li_PaperReturn = new Li_PaperReturn();
        SqlLi_PaperReturnProvider sqlLi_PaperReturnProvider = new SqlLi_PaperReturnProvider();
        li_PaperReturn = sqlLi_PaperReturnProvider.GetLi_PaperReturnID(id);
        return li_PaperReturn;
    }


    public static int InsertLi_PaperReturn(Li_PaperReturn li_PaperReturn)
    {
        SqlLi_PaperReturnProvider sqlLi_PaperReturnProvider = new SqlLi_PaperReturnProvider();
        return sqlLi_PaperReturnProvider.InsertLi_PaperReturn(li_PaperReturn);
    }


    public static bool UpdateLi_PaperReturn(Li_PaperReturn li_PaperReturn)
    {
        SqlLi_PaperReturnProvider sqlLi_PaperReturnProvider = new SqlLi_PaperReturnProvider();
        return sqlLi_PaperReturnProvider.UpdateLi_PaperReturn(li_PaperReturn);
    }

    public static bool DeleteLi_PaperReturn(int li_PaperReturnID)
    {
        SqlLi_PaperReturnProvider sqlLi_PaperReturnProvider = new SqlLi_PaperReturnProvider();
        return sqlLi_PaperReturnProvider.DeleteLi_PaperReturn(li_PaperReturnID);
    }
}
