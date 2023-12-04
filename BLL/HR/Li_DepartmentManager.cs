using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_DepartmentManager
{
	public Li_DepartmentManager()
	{
	}

    public static List<Li_Department> GetAllLi_Departments()
    {
        List<Li_Department> li_Departments = new List<Li_Department>();
        SqlLi_DepartmentProvider sqlLi_DepartmentProvider = new SqlLi_DepartmentProvider();
        li_Departments = sqlLi_DepartmentProvider.GetAllLi_Departments();
        return li_Departments;
    }


    public static Li_Department GetLi_DepartmentByID(int id)
    {
        Li_Department li_Department = new Li_Department();
        SqlLi_DepartmentProvider sqlLi_DepartmentProvider = new SqlLi_DepartmentProvider();
        li_Department = sqlLi_DepartmentProvider.GetLi_DepartmentByID(id);
        return li_Department;
    }


    public static int InsertLi_Department(Li_Department li_Department)
    {
        SqlLi_DepartmentProvider sqlLi_DepartmentProvider = new SqlLi_DepartmentProvider();
        return sqlLi_DepartmentProvider.InsertLi_Department(li_Department);
    }


    public static bool UpdateLi_Department(Li_Department li_Department)
    {
        SqlLi_DepartmentProvider sqlLi_DepartmentProvider = new SqlLi_DepartmentProvider();
        return sqlLi_DepartmentProvider.UpdateLi_Department(li_Department);
    }

    public static bool DeleteLi_Department(int li_DepartmentID)
    {
        SqlLi_DepartmentProvider sqlLi_DepartmentProvider = new SqlLi_DepartmentProvider();
        return sqlLi_DepartmentProvider.DeleteLi_Department(li_DepartmentID);
    }

    public static DataTable loadDepartmentFromEmpInfo()
    {
        DataTable dt = new DataTable();
        SqlLi_DepartmentProvider sqlLi_DepartmentProvider = new SqlLi_DepartmentProvider();
        dt=  sqlLi_DepartmentProvider.loadDepartmentFromEmpInfo ();
        return dt;
    }
    //--------------------------Rezaul Hossain-----------------------------2020---------------------
    public static Li_Department GetLi_DepartmentByEmpID(int EmpId)
    {
        Li_Department li_Department = new Li_Department();
        SqlLi_DepartmentProvider sqlLi_DepartmentProvider = new SqlLi_DepartmentProvider();
        li_Department = sqlLi_DepartmentProvider.GetLi_DepartmentByEmpID(EmpId);
        return li_Department;
    }

}
