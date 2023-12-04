using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmploymentManager
{
	public Li_EmploymentManager()
	{
	}

    public static List<Li_Employment> GetAllLi_Employments()
    {
        List<Li_Employment> li_Employments = new List<Li_Employment>();
        SqlLi_EmploymentProvider sqlLi_EmploymentProvider = new SqlLi_EmploymentProvider();
        li_Employments = sqlLi_EmploymentProvider.GetAllLi_Employments();
        return li_Employments;
    }


    public static Li_Employment GetLi_EmploymentByID(int id)
    {
        Li_Employment li_Employment = new Li_Employment();
        SqlLi_EmploymentProvider sqlLi_EmploymentProvider = new SqlLi_EmploymentProvider();
        li_Employment = sqlLi_EmploymentProvider.GetLi_EmploymentByID(id);
        return li_Employment;
    }


    public static int InsertLi_Employment(Li_Employment li_Employment)
    {
        SqlLi_EmploymentProvider sqlLi_EmploymentProvider = new SqlLi_EmploymentProvider();
        return sqlLi_EmploymentProvider.InsertLi_Employment(li_Employment);
    }


    public static bool UpdateLi_Employment(Li_Employment li_Employment)
    {
        SqlLi_EmploymentProvider sqlLi_EmploymentProvider = new SqlLi_EmploymentProvider();
        return sqlLi_EmploymentProvider.UpdateLi_Employment(li_Employment);
    }

    public static bool DeleteLi_Employment(int li_EmploymentID)
    {
        SqlLi_EmploymentProvider sqlLi_EmploymentProvider = new SqlLi_EmploymentProvider();
        return sqlLi_EmploymentProvider.DeleteLi_Employment(li_EmploymentID);
    }



    public static DataTable   LoadGvEmployment()
    {
        SqlLi_EmploymentProvider sqlLi_EmploymentProvider = new SqlLi_EmploymentProvider();
        return sqlLi_EmploymentProvider.LoadGvEmployment();
    }

}
