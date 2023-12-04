using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_PFApplicationManager
{
	public Li_PFApplicationManager()
	{
	}

    public static List<Li_PFApplication> GetAllLi_PFApplications()
    {
        List<Li_PFApplication> li_PFApplications = new List<Li_PFApplication>();
        SqlLi_PFApplicationProvider sqlLi_PFApplicationProvider = new SqlLi_PFApplicationProvider();
        li_PFApplications = sqlLi_PFApplicationProvider.GetAllLi_PFApplications();
        return li_PFApplications;
    }


    public static Li_PFApplication GetLi_PFApplicationByID(int id)
    {
        Li_PFApplication li_PFApplication = new Li_PFApplication();
        SqlLi_PFApplicationProvider sqlLi_PFApplicationProvider = new SqlLi_PFApplicationProvider();
        li_PFApplication = sqlLi_PFApplicationProvider.GetLi_PFApplicationByID(id);
        return li_PFApplication;
    }


    public static int InsertLi_PFApplication(Li_PFApplication li_PFApplication)
    {
        SqlLi_PFApplicationProvider sqlLi_PFApplicationProvider = new SqlLi_PFApplicationProvider();
        return sqlLi_PFApplicationProvider.InsertLi_PFApplication(li_PFApplication);
    }


    public static bool UpdateLi_PFApplication(Li_PFApplication li_PFApplication)
    {
        SqlLi_PFApplicationProvider sqlLi_PFApplicationProvider = new SqlLi_PFApplicationProvider();
        return sqlLi_PFApplicationProvider.UpdateLi_PFApplication(li_PFApplication);
    }

    public static bool DeleteLi_PFApplication(int li_PFApplicationID)
    {
        SqlLi_PFApplicationProvider sqlLi_PFApplicationProvider = new SqlLi_PFApplicationProvider();
        return sqlLi_PFApplicationProvider.DeleteLi_PFApplication(li_PFApplicationID);
    }
}
