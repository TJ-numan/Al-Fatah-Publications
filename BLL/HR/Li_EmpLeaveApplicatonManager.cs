using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpLeaveApplicatonManager
{
	public Li_EmpLeaveApplicatonManager()
	{
	}

    public static List<Li_EmpLeaveApplicaton> GetAllLi_EmpLeaveApplicatons()
    {
        List<Li_EmpLeaveApplicaton> li_EmpLeaveApplicatons = new List<Li_EmpLeaveApplicaton>();
        SqlLi_EmpLeaveApplicatonProvider sqlLi_EmpLeaveApplicatonProvider = new SqlLi_EmpLeaveApplicatonProvider();
        li_EmpLeaveApplicatons = sqlLi_EmpLeaveApplicatonProvider.GetAllLi_EmpLeaveApplicatons();
        return li_EmpLeaveApplicatons;
    }


    public static Li_EmpLeaveApplicaton GetLi_EmpLeaveApplicatonByID(int id)
    {
        Li_EmpLeaveApplicaton li_EmpLeaveApplicaton = new Li_EmpLeaveApplicaton();
        SqlLi_EmpLeaveApplicatonProvider sqlLi_EmpLeaveApplicatonProvider = new SqlLi_EmpLeaveApplicatonProvider();
        li_EmpLeaveApplicaton = sqlLi_EmpLeaveApplicatonProvider.GetLi_EmpLeaveApplicatonByID(id);
        return li_EmpLeaveApplicaton;
    }


    public static int InsertLi_EmpLeaveApplicaton(Li_EmpLeaveApplicaton li_EmpLeaveApplicaton)
    {
        SqlLi_EmpLeaveApplicatonProvider sqlLi_EmpLeaveApplicatonProvider = new SqlLi_EmpLeaveApplicatonProvider();
        return sqlLi_EmpLeaveApplicatonProvider.InsertLi_EmpLeaveApplicaton(li_EmpLeaveApplicaton);
    }


    public static bool UpdateLi_EmpLeaveApplicaton(Li_EmpLeaveApplicaton li_EmpLeaveApplicaton)
    {
        SqlLi_EmpLeaveApplicatonProvider sqlLi_EmpLeaveApplicatonProvider = new SqlLi_EmpLeaveApplicatonProvider();
        return sqlLi_EmpLeaveApplicatonProvider.UpdateLi_EmpLeaveApplicaton(li_EmpLeaveApplicaton);
    }

    public static bool DeleteLi_EmpLeaveApplicaton(int li_EmpLeaveApplicatonID)
    {
        SqlLi_EmpLeaveApplicatonProvider sqlLi_EmpLeaveApplicatonProvider = new SqlLi_EmpLeaveApplicatonProvider();
        return sqlLi_EmpLeaveApplicatonProvider.DeleteLi_EmpLeaveApplicaton(li_EmpLeaveApplicatonID);
    }
}
