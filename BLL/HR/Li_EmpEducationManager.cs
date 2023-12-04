using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpEducationManager
{
	public Li_EmpEducationManager()
	{
	}

    public static List<Li_EmpEducation> GetAllLi_EmpEducations()
    {
        List<Li_EmpEducation> li_EmpEducations = new List<Li_EmpEducation>();
        SqlLi_EmpEducationProvider sqlLi_EmpEducationProvider = new SqlLi_EmpEducationProvider();
        li_EmpEducations = sqlLi_EmpEducationProvider.GetAllLi_EmpEducations();
        return li_EmpEducations;
    }


    public static Li_EmpEducation GetLi_EmpEducationByID(int id)
    {
        Li_EmpEducation li_EmpEducation = new Li_EmpEducation();
        SqlLi_EmpEducationProvider sqlLi_EmpEducationProvider = new SqlLi_EmpEducationProvider();
        li_EmpEducation = sqlLi_EmpEducationProvider.GetLi_EmpEducationByID(id);
        return li_EmpEducation;
    }


    public static int InsertLi_EmpEducation(Li_EmpEducation li_EmpEducation)
    {
        SqlLi_EmpEducationProvider sqlLi_EmpEducationProvider = new SqlLi_EmpEducationProvider();
        return sqlLi_EmpEducationProvider.InsertLi_EmpEducation(li_EmpEducation);
    }


    public static bool UpdateLi_EmpEducation(Li_EmpEducation li_EmpEducation)
    {
        SqlLi_EmpEducationProvider sqlLi_EmpEducationProvider = new SqlLi_EmpEducationProvider();
        return sqlLi_EmpEducationProvider.UpdateLi_EmpEducation(li_EmpEducation);
    }

    public static bool DeleteLi_EmpEducation(int li_EmpEducationID)
    {
        SqlLi_EmpEducationProvider sqlLi_EmpEducationProvider = new SqlLi_EmpEducationProvider();
        return sqlLi_EmpEducationProvider.DeleteLi_EmpEducation(li_EmpEducationID);
    }

    public static DataTable  LoadGvEmployeeEducation()
    {
        SqlLi_EmpEducationProvider sqlLi_EmpEducationProvider = new SqlLi_EmpEducationProvider();
        return sqlLi_EmpEducationProvider.LoadGvEmployeeEducation();
    }

}
