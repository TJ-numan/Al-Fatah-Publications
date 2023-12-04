using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_MCQuesAnwerManager
{
	public Li_MCQuesAnwerManager()
	{
	}

    public static List<Li_MCQuesAnwer> GetAllLi_MCQuesAnwers()
    {
        List<Li_MCQuesAnwer> li_MCQuesAnwers = new List<Li_MCQuesAnwer>();
        SqlLi_MCQuesAnwerProvider sqlLi_MCQuesAnwerProvider = new SqlLi_MCQuesAnwerProvider();
        li_MCQuesAnwers = sqlLi_MCQuesAnwerProvider.GetAllLi_MCQuesAnwers();
        return li_MCQuesAnwers;
    }


    public static Li_MCQuesAnwer GetLi_MCQuesAnwerByID(int id)
    {
        Li_MCQuesAnwer li_MCQuesAnwer = new Li_MCQuesAnwer();
        SqlLi_MCQuesAnwerProvider sqlLi_MCQuesAnwerProvider = new SqlLi_MCQuesAnwerProvider();
        li_MCQuesAnwer = sqlLi_MCQuesAnwerProvider.GetLi_MCQuesAnwerByID(id);
        return li_MCQuesAnwer;
    }


    public static int InsertLi_MCQuesAnwer(Li_MCQuesAnwer li_MCQuesAnwer)
    {
        SqlLi_MCQuesAnwerProvider sqlLi_MCQuesAnwerProvider = new SqlLi_MCQuesAnwerProvider();
        return sqlLi_MCQuesAnwerProvider.InsertLi_MCQuesAnwer(li_MCQuesAnwer);
    }


    public static bool UpdateLi_MCQuesAnwer(Li_MCQuesAnwer li_MCQuesAnwer)
    {
        SqlLi_MCQuesAnwerProvider sqlLi_MCQuesAnwerProvider = new SqlLi_MCQuesAnwerProvider();
        return sqlLi_MCQuesAnwerProvider.UpdateLi_MCQuesAnwer(li_MCQuesAnwer);
    }

    public static bool DeleteLi_MCQuesAnwer(int li_MCQuesAnwerID)
    {
        SqlLi_MCQuesAnwerProvider sqlLi_MCQuesAnwerProvider = new SqlLi_MCQuesAnwerProvider();
        return sqlLi_MCQuesAnwerProvider.DeleteLi_MCQuesAnwer(li_MCQuesAnwerID);
    }
}
