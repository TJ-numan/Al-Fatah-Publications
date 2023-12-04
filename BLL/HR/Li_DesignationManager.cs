using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using Common.R_D;

public class Li_DesignationManager
{
	public Li_DesignationManager()
	{
	}

    public static List<Li_Designation> GetAllLi_Designations()
    {
        List<Li_Designation> li_Designations = new List<Li_Designation>();
        SqlLi_DesignationProvider sqlLi_DesignationProvider = new SqlLi_DesignationProvider();
        li_Designations = sqlLi_DesignationProvider.GetAllLi_Designations();
        return li_Designations;
    }


    public static Li_Designation GetLi_DesignationByID(int id)
    {
        Li_Designation li_Designation = new Li_Designation();
        SqlLi_DesignationProvider sqlLi_DesignationProvider = new SqlLi_DesignationProvider();
        li_Designation = sqlLi_DesignationProvider.GetLi_DesignationByID(id);
        return li_Designation;
    }


    public static int InsertLi_Designation(Li_Designation li_Designation)
    {
        SqlLi_DesignationProvider sqlLi_DesignationProvider = new SqlLi_DesignationProvider();
        return sqlLi_DesignationProvider.InsertLi_Designation(li_Designation);
    }


    public static bool UpdateLi_Designation(Li_Designation li_Designation)
    {
        SqlLi_DesignationProvider sqlLi_DesignationProvider = new SqlLi_DesignationProvider();
        return sqlLi_DesignationProvider.UpdateLi_Designation(li_Designation);
    }

    public static bool DeleteLi_Designation(int li_DesignationID)
    {
        SqlLi_DesignationProvider sqlLi_DesignationProvider = new SqlLi_DesignationProvider();
        return sqlLi_DesignationProvider.DeleteLi_Designation(li_DesignationID);
    }
    //--------------------------Rezaul Hossain-----------------------------2020---------------------
    //public static li_DesignationR GetLi_DesignationByEmpID(int EmpId)
    //{
    //    li_DesignationR li_Designation = new li_DesignationR();
    //    SqlLi_DesignationProvider sqlLi_DesignationProvider = new SqlLi_DesignationProvider();
    //    li_Designation = sqlLi_DesignationProvider.GetLi_DesignationByEmpID(EmpId);
    //    return li_Designation;
    //}
    public static DataTable GetLi_DesignationByEmpID(int EmpId)
    {
        SqlLi_DesignationProvider sqlLi_DesignationProvider = new SqlLi_DesignationProvider();
        return sqlLi_DesignationProvider.GetLi_DesignationByEmpID(EmpId);
    } 
    //--------------Rezaul Hossain--------2021-06-01------------------------------
    public static DataTable GetLi_DesignationQawmiByEmpID(int EmpId)
    {
        SqlLi_DesignationProvider sqlLi_DesignationProvider = new SqlLi_DesignationProvider();
        return sqlLi_DesignationProvider.GetLi_DesignationQawmiByEmpID(EmpId);
    } 
}
