using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_SalaryManager
{
	public Li_SalaryManager()
	{
	}

    public static List<Li_Salary> GetAllLi_Salaries()
    {
        List<Li_Salary> li_Salaries = new List<Li_Salary>();
        SqlLi_SalaryProvider sqlLi_SalaryProvider = new SqlLi_SalaryProvider();
        li_Salaries = sqlLi_SalaryProvider.GetAllLi_Salaries();
        return li_Salaries;
    }


    public static Li_Salary GetLi_SalaryByID(int id)
    {
        Li_Salary li_Salary = new Li_Salary();
        SqlLi_SalaryProvider sqlLi_SalaryProvider = new SqlLi_SalaryProvider();
        li_Salary = sqlLi_SalaryProvider.GetLi_SalaryByID(id);
        return li_Salary;
    }


    public static int InsertLi_Salary(Li_Salary li_Salary)
    {
        SqlLi_SalaryProvider sqlLi_SalaryProvider = new SqlLi_SalaryProvider();
        return sqlLi_SalaryProvider.InsertLi_Salary(li_Salary);
    }


    public static bool UpdateLi_Salary(Li_Salary li_Salary)
    {
        SqlLi_SalaryProvider sqlLi_SalaryProvider = new SqlLi_SalaryProvider();
        return sqlLi_SalaryProvider.UpdateLi_Salary(li_Salary);
    }

    public static bool DeleteLi_Salary(int li_SalaryID)
    {
        SqlLi_SalaryProvider sqlLi_SalaryProvider = new SqlLi_SalaryProvider();
        return sqlLi_SalaryProvider.DeleteLi_Salary(li_SalaryID);
    }
}
