using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpMembershipManager
{
    public Li_EmpMembershipManager()
    {
    }

    public static List<Li_EmpMembership> GetAllLi_EmpMemberships()
    {
        List<Li_EmpMembership> li_EmpMemberships = new List<Li_EmpMembership>();
        SqlLi_EmpMembershipProvider sqlLi_EmpMembershipProvider = new SqlLi_EmpMembershipProvider();
        li_EmpMemberships = sqlLi_EmpMembershipProvider.GetAllLi_EmpMemberships();
        return li_EmpMemberships;
    }


    public static Li_EmpMembership GetLi_EmpMembershipByID(int id)
    {
        Li_EmpMembership li_EmpMembership = new Li_EmpMembership();
        SqlLi_EmpMembershipProvider sqlLi_EmpMembershipProvider = new SqlLi_EmpMembershipProvider();
        li_EmpMembership = sqlLi_EmpMembershipProvider.GetLi_EmpMembershipByID(id);
        return li_EmpMembership;
    }


    public static int InsertLi_EmpMembership(Li_EmpMembership li_EmpMembership)
    {
        SqlLi_EmpMembershipProvider sqlLi_EmpMembershipProvider = new SqlLi_EmpMembershipProvider();
        return sqlLi_EmpMembershipProvider.InsertLi_EmpMembership(li_EmpMembership);
    }


    public static bool UpdateLi_EmpMembership(Li_EmpMembership li_EmpMembership)
    {
        SqlLi_EmpMembershipProvider sqlLi_EmpMembershipProvider = new SqlLi_EmpMembershipProvider();
        return sqlLi_EmpMembershipProvider.UpdateLi_EmpMembership(li_EmpMembership);
    }

    public static bool DeleteLi_EmpMembership(int li_EmpMembershipID)
    {
        SqlLi_EmpMembershipProvider sqlLi_EmpMembershipProvider = new SqlLi_EmpMembershipProvider();
        return sqlLi_EmpMembershipProvider.DeleteLi_EmpMembership(li_EmpMembershipID);
    }
    public static DataTable LoadGvEmployeeMembership()
    {
        SqlLi_EmpMembershipProvider sqlLi_EmpMembershipProvider = new SqlLi_EmpMembershipProvider();
        return sqlLi_EmpMembershipProvider.LoadGvEmployeeMembership();
    }
}
