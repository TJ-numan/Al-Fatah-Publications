using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 
public class Li_EmployeeInfoManager
{
	public Li_EmployeeInfoManager()
	{
	}

    public static List<Li_EmployeeInfo> GetAllLi_EmployeeInfos()
    {
        List<Li_EmployeeInfo> li_EmployeeInfos = new List<Li_EmployeeInfo>();
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        li_EmployeeInfos = sqlLi_EmployeeInfoProvider.GetAllLi_EmployeeInfos();
        return li_EmployeeInfos;
    }


    public static Li_EmployeeInfo GetLi_EmployeeInfoByID(int id)
    {
        Li_EmployeeInfo li_EmployeeInfo = new Li_EmployeeInfo();
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        li_EmployeeInfo = sqlLi_EmployeeInfoProvider.GetLi_EmployeeInfoByID(id);
        return li_EmployeeInfo;
    }


    public static int InsertLi_EmployeeInfo(Li_EmployeeInfo li_EmployeeInfo)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.InsertLi_EmployeeInfo(li_EmployeeInfo);
    }


    public static bool UpdateLi_EmployeeInfo(Li_EmployeeInfo li_EmployeeInfo)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.UpdateLi_EmployeeInfo(li_EmployeeInfo);
    }

    public static bool DeleteLi_EmployeeInfo(int li_EmployeeInfoID)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.DeleteLi_EmployeeInfo(li_EmployeeInfoID);
    }
    public static DataSet GetEmployeeInfoForComboDataSource()
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.GetEmployeeInfoForComboDataSource();
    }
 
    public static DataTable  GetEmployeeNextSL() 
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.GetEmployeeNextSL();
    }
    public static DataTable LoadGvEmployeeInfo()
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.LoadGvEmployeeInfo();
    }


    public static DataTable LoadGvEmployeeInfoByEmpId(int EmpId)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.LoadGvEmployeeInfoEmpId(EmpId);
    }

    public static DataTable GetLi_EmployeeListByDepID(int DepId)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.GetLi_EmployeeListByDepID(DepId);
    }
    public static DataTable GetLi_EmployeeListBySecID(int SecId)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.GetLi_EmployeeListBySecID(SecId);
    }
    public static DataTable GetLi_EmployeeListRZBySecID(int SecId, int Employeer)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.GetLi_EmployeeRZListBySecID(SecId, Employeer);
    } 
    //----------------------Rezaul Hossain--------------2021-06-01----
    public static DataTable GetLi_EmployeeListBySecIDQawmi(int SecId)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.GetLi_EmployeeListBySecIDQawmi(SecId);
    }
    public static DataTable GetLi_EmployeeListRZBySecIDQawmi(int SecId, int Employeer)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.GetLi_EmployeeRZListBySecIDQawmi(SecId, Employeer);
    }

    public static DataTable GetLi_EmployeeListRZByEmployeer(int Employeer)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.GetLi_EmployeeListRZByEmployeer(Employeer);
    }
    public static DataTable GetLi_EmployeeListRZByEmployeerQawmi(int Employeer)
    {
        SqlLi_EmployeeInfoProvider sqlLi_EmployeeInfoProvider = new SqlLi_EmployeeInfoProvider();
        return sqlLi_EmployeeInfoProvider.GetLi_EmployeeListRZByEmployeerQawmi(Employeer);
    } 
}
