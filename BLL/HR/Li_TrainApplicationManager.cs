using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TrainApplicationManager
{
	public Li_TrainApplicationManager()
	{
	}

    public static List<Li_TrainApplication> GetAllLi_TrainApplications()
    {
        List<Li_TrainApplication> li_TrainApplications = new List<Li_TrainApplication>();
        SqlLi_TrainApplicationProvider sqlLi_TrainApplicationProvider = new SqlLi_TrainApplicationProvider();
        li_TrainApplications = sqlLi_TrainApplicationProvider.GetAllLi_TrainApplications();
        return li_TrainApplications;
    }


    public static Li_TrainApplication GetLi_TrainApplicationByID(int id)
    {
        Li_TrainApplication li_TrainApplication = new Li_TrainApplication();
        SqlLi_TrainApplicationProvider sqlLi_TrainApplicationProvider = new SqlLi_TrainApplicationProvider();
        li_TrainApplication = sqlLi_TrainApplicationProvider.GetLi_TrainApplicationByID(id);
        return li_TrainApplication;
    }


    public static int InsertLi_TrainApplication(Li_TrainApplication li_TrainApplication)
    {
        SqlLi_TrainApplicationProvider sqlLi_TrainApplicationProvider = new SqlLi_TrainApplicationProvider();
        return sqlLi_TrainApplicationProvider.InsertLi_TrainApplication(li_TrainApplication);
    }


    public static bool UpdateLi_TrainApplication(Li_TrainApplication li_TrainApplication)
    {
        SqlLi_TrainApplicationProvider sqlLi_TrainApplicationProvider = new SqlLi_TrainApplicationProvider();
        return sqlLi_TrainApplicationProvider.UpdateLi_TrainApplication(li_TrainApplication);
    }

    public static bool DeleteLi_TrainApplication(int li_TrainApplicationID)
    {
        SqlLi_TrainApplicationProvider sqlLi_TrainApplicationProvider = new SqlLi_TrainApplicationProvider();
        return sqlLi_TrainApplicationProvider.DeleteLi_TrainApplication(li_TrainApplicationID);
    }
}
