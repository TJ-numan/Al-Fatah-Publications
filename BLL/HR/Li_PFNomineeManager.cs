using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFNomineeManager
{
	public Li_PFNomineeManager()
	{
	}

    public static List<Li_PFNominee> GetAllLi_PFNominees()
    {
        List<Li_PFNominee> li_PFNominees = new List<Li_PFNominee>();
        SqlLi_PFNomineeProvider sqlLi_PFNomineeProvider = new SqlLi_PFNomineeProvider();
        li_PFNominees = sqlLi_PFNomineeProvider.GetAllLi_PFNominees();
        return li_PFNominees;
    }


    public static Li_PFNominee GetLi_PFNomineeByID(int id)
    {
        Li_PFNominee li_PFNominee = new Li_PFNominee();
        SqlLi_PFNomineeProvider sqlLi_PFNomineeProvider = new SqlLi_PFNomineeProvider();
        li_PFNominee = sqlLi_PFNomineeProvider.GetLi_PFNomineeByID(id);
        return li_PFNominee;
    }


    public static int InsertLi_PFNominee(Li_PFNominee li_PFNominee)
    {
        SqlLi_PFNomineeProvider sqlLi_PFNomineeProvider = new SqlLi_PFNomineeProvider();
        return sqlLi_PFNomineeProvider.InsertLi_PFNominee(li_PFNominee);
    }


    public static bool UpdateLi_PFNominee(Li_PFNominee li_PFNominee)
    {
        SqlLi_PFNomineeProvider sqlLi_PFNomineeProvider = new SqlLi_PFNomineeProvider();
        return sqlLi_PFNomineeProvider.UpdateLi_PFNominee(li_PFNominee);
    }

    public static bool DeleteLi_PFNominee(int li_PFNomineeID)
    {
        SqlLi_PFNomineeProvider sqlLi_PFNomineeProvider = new SqlLi_PFNomineeProvider();
        return sqlLi_PFNomineeProvider.DeleteLi_PFNominee(li_PFNomineeID);
    }
}
