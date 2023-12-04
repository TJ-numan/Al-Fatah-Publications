using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_TrainingApprovalManager
{
	public Li_TrainingApprovalManager()
	{
	}

    public static List<Li_TrainingApproval> GetAllLi_TrainingApprovals()
    {
        List<Li_TrainingApproval> li_TrainingApprovals = new List<Li_TrainingApproval>();
        SqlLi_TrainingApprovalProvider sqlLi_TrainingApprovalProvider = new SqlLi_TrainingApprovalProvider();
        li_TrainingApprovals = sqlLi_TrainingApprovalProvider.GetAllLi_TrainingApprovals();
        return li_TrainingApprovals;
    }


    public static Li_TrainingApproval GetLi_TrainingApprovalByID(int id)
    {
        Li_TrainingApproval li_TrainingApproval = new Li_TrainingApproval();
        SqlLi_TrainingApprovalProvider sqlLi_TrainingApprovalProvider = new SqlLi_TrainingApprovalProvider();
        li_TrainingApproval = sqlLi_TrainingApprovalProvider.GetLi_TrainingApprovalByID(id);
        return li_TrainingApproval;
    }


    public static int InsertLi_TrainingApproval(Li_TrainingApproval li_TrainingApproval)
    {
        SqlLi_TrainingApprovalProvider sqlLi_TrainingApprovalProvider = new SqlLi_TrainingApprovalProvider();
        return sqlLi_TrainingApprovalProvider.InsertLi_TrainingApproval(li_TrainingApproval);
    }


    public static bool UpdateLi_TrainingApproval(Li_TrainingApproval li_TrainingApproval)
    {
        SqlLi_TrainingApprovalProvider sqlLi_TrainingApprovalProvider = new SqlLi_TrainingApprovalProvider();
        return sqlLi_TrainingApprovalProvider.UpdateLi_TrainingApproval(li_TrainingApproval);
    }

    public static bool DeleteLi_TrainingApproval(int li_TrainingApprovalID)
    {
        SqlLi_TrainingApprovalProvider sqlLi_TrainingApprovalProvider = new SqlLi_TrainingApprovalProvider();
        return sqlLi_TrainingApprovalProvider.DeleteLi_TrainingApproval(li_TrainingApprovalID);
    }
}
