using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpSalaryManager
{
	public Li_EmpSalaryManager()
	{
	}

    public static List<Li_EmpSalary> GetAllLi_EmpSalaries()
    {
        List<Li_EmpSalary> li_EmpSalaries = new List<Li_EmpSalary>();
        SqlLi_EmpSalaryProvider sqlLi_EmpSalaryProvider = new SqlLi_EmpSalaryProvider();
        li_EmpSalaries = sqlLi_EmpSalaryProvider.GetAllLi_EmpSalaries();
        return li_EmpSalaries;
    }


    public static Li_EmpSalary GetLi_EmpSalaryByID(int id)
    {
        Li_EmpSalary li_EmpSalary = new Li_EmpSalary();
        SqlLi_EmpSalaryProvider sqlLi_EmpSalaryProvider = new SqlLi_EmpSalaryProvider();
        li_EmpSalary = sqlLi_EmpSalaryProvider.GetLi_EmpSalaryByID(id);
        return li_EmpSalary;
    }


    public static int InsertLi_EmpSalary(Li_EmpSalary li_EmpSalary)
    {
        SqlLi_EmpSalaryProvider sqlLi_EmpSalaryProvider = new SqlLi_EmpSalaryProvider();
        return sqlLi_EmpSalaryProvider.InsertLi_EmpSalary(li_EmpSalary);
    }


    public static bool UpdateLi_EmpSalary(Li_EmpSalary li_EmpSalary)
    {
        SqlLi_EmpSalaryProvider sqlLi_EmpSalaryProvider = new SqlLi_EmpSalaryProvider();
        return sqlLi_EmpSalaryProvider.UpdateLi_EmpSalary(li_EmpSalary);
    }

    public static bool DeleteLi_EmpSalary(int li_EmpSalaryID)
    {
        SqlLi_EmpSalaryProvider sqlLi_EmpSalaryProvider = new SqlLi_EmpSalaryProvider();
        return sqlLi_EmpSalaryProvider.DeleteLi_EmpSalary(li_EmpSalaryID);
    }

    public static DataTable LoadGvEmployeeSalary()
    {
        SqlLi_EmpSalaryProvider sqlLi_EmpSalaryProvider = new SqlLi_EmpSalaryProvider();
        return sqlLi_EmpSalaryProvider. LoadGvEmployeeSalary();
    }
}
