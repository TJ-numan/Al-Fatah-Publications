using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_VacancyReqApprovalManager
{
	public Li_VacancyReqApprovalManager()
	{
	}

    public static List<Li_VacancyReqApproval> GetAllLi_VacancyReqApprovals()
    {
        List<Li_VacancyReqApproval> li_VacancyReqApprovals = new List<Li_VacancyReqApproval>();
        SqlLi_VacancyReqApprovalProvider sqlLi_VacancyReqApprovalProvider = new SqlLi_VacancyReqApprovalProvider();
        li_VacancyReqApprovals = sqlLi_VacancyReqApprovalProvider.GetAllLi_VacancyReqApprovals();
        return li_VacancyReqApprovals;
    }


    public static Li_VacancyReqApproval GetLi_VacancyReqApprovalByID(int id)
    {
        Li_VacancyReqApproval li_VacancyReqApproval = new Li_VacancyReqApproval();
        SqlLi_VacancyReqApprovalProvider sqlLi_VacancyReqApprovalProvider = new SqlLi_VacancyReqApprovalProvider();
        li_VacancyReqApproval = sqlLi_VacancyReqApprovalProvider.GetLi_VacancyReqApprovalByID(id);
        return li_VacancyReqApproval;
    }


    public static int InsertLi_VacancyReqApproval(Li_VacancyReqApproval li_VacancyReqApproval)
    {
        SqlLi_VacancyReqApprovalProvider sqlLi_VacancyReqApprovalProvider = new SqlLi_VacancyReqApprovalProvider();
        return sqlLi_VacancyReqApprovalProvider.InsertLi_VacancyReqApproval(li_VacancyReqApproval);
    }


    public static bool UpdateLi_VacancyReqApproval(Li_VacancyReqApproval li_VacancyReqApproval)
    {
        SqlLi_VacancyReqApprovalProvider sqlLi_VacancyReqApprovalProvider = new SqlLi_VacancyReqApprovalProvider();
        return sqlLi_VacancyReqApprovalProvider.UpdateLi_VacancyReqApproval(li_VacancyReqApproval);
    }

    public static bool DeleteLi_VacancyReqApproval(int li_VacancyReqApprovalID)
    {
        SqlLi_VacancyReqApprovalProvider sqlLi_VacancyReqApprovalProvider = new SqlLi_VacancyReqApprovalProvider();
        return sqlLi_VacancyReqApprovalProvider.DeleteLi_VacancyReqApproval(li_VacancyReqApprovalID);
    }
}
