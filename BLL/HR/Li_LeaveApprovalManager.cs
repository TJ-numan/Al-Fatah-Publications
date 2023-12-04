using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_LeaveApprovalManager
{
	public Li_LeaveApprovalManager()
	{
	}

    public static List<Li_LeaveApproval> GetAllLi_LeaveApprovals()
    {
        List<Li_LeaveApproval> li_LeaveApprovals = new List<Li_LeaveApproval>();
        SqlLi_LeaveApprovalProvider sqlLi_LeaveApprovalProvider = new SqlLi_LeaveApprovalProvider();
        li_LeaveApprovals = sqlLi_LeaveApprovalProvider.GetAllLi_LeaveApprovals();
        return li_LeaveApprovals;
    }


    public static Li_LeaveApproval GetLi_LeaveApprovalByID(int id)
    {
        Li_LeaveApproval li_LeaveApproval = new Li_LeaveApproval();
        SqlLi_LeaveApprovalProvider sqlLi_LeaveApprovalProvider = new SqlLi_LeaveApprovalProvider();
        li_LeaveApproval = sqlLi_LeaveApprovalProvider.GetLi_LeaveApprovalByID(id);
        return li_LeaveApproval;
    }


    public static int InsertLi_LeaveApproval(Li_LeaveApproval li_LeaveApproval)
    {
        SqlLi_LeaveApprovalProvider sqlLi_LeaveApprovalProvider = new SqlLi_LeaveApprovalProvider();
        return sqlLi_LeaveApprovalProvider.InsertLi_LeaveApproval(li_LeaveApproval);
    }


    public static bool UpdateLi_LeaveApproval(Li_LeaveApproval li_LeaveApproval)
    {
        SqlLi_LeaveApprovalProvider sqlLi_LeaveApprovalProvider = new SqlLi_LeaveApprovalProvider();
        return sqlLi_LeaveApprovalProvider.UpdateLi_LeaveApproval(li_LeaveApproval);
    }

    public static bool DeleteLi_LeaveApproval(int li_LeaveApprovalID)
    {
        SqlLi_LeaveApprovalProvider sqlLi_LeaveApprovalProvider = new SqlLi_LeaveApprovalProvider();
        return sqlLi_LeaveApprovalProvider.DeleteLi_LeaveApproval(li_LeaveApprovalID);
    }
}
