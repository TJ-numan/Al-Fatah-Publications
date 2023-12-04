using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TrainInstituteManager
{
	public Li_TrainInstituteManager()
	{
	}

    public static List<Li_TrainInstitute> GetAllLi_TrainInstitutes()
    {
        List<Li_TrainInstitute> li_TrainInstitutes = new List<Li_TrainInstitute>();
        SqlLi_TrainInstituteProvider sqlLi_TrainInstituteProvider = new SqlLi_TrainInstituteProvider();
        li_TrainInstitutes = sqlLi_TrainInstituteProvider.GetAllLi_TrainInstitutes();
        return li_TrainInstitutes;
    }


    public static Li_TrainInstitute GetLi_TrainInstituteByID(int id)
    {
        Li_TrainInstitute li_TrainInstitute = new Li_TrainInstitute();
        SqlLi_TrainInstituteProvider sqlLi_TrainInstituteProvider = new SqlLi_TrainInstituteProvider();
        li_TrainInstitute = sqlLi_TrainInstituteProvider.GetLi_TrainInstituteByID(id);
        return li_TrainInstitute;
    }


    public static int InsertLi_TrainInstitute(Li_TrainInstitute li_TrainInstitute)
    {
        SqlLi_TrainInstituteProvider sqlLi_TrainInstituteProvider = new SqlLi_TrainInstituteProvider();
        return sqlLi_TrainInstituteProvider.InsertLi_TrainInstitute(li_TrainInstitute);
    }


    public static bool UpdateLi_TrainInstitute(Li_TrainInstitute li_TrainInstitute)
    {
        SqlLi_TrainInstituteProvider sqlLi_TrainInstituteProvider = new SqlLi_TrainInstituteProvider();
        return sqlLi_TrainInstituteProvider.UpdateLi_TrainInstitute(li_TrainInstitute);
    }

    public static bool DeleteLi_TrainInstitute(int li_TrainInstituteID)
    {
        SqlLi_TrainInstituteProvider sqlLi_TrainInstituteProvider = new SqlLi_TrainInstituteProvider();
        return sqlLi_TrainInstituteProvider.DeleteLi_TrainInstitute(li_TrainInstituteID);
    }
}
