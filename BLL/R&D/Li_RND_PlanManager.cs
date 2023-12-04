using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_RND_PlanManager
{
	public Li_RND_PlanManager()
	{
	}

    public static List<Li_RND_Plan> GetAllLi_RND_Plans()
    {
        List<Li_RND_Plan> li_RND_Plans = new List<Li_RND_Plan>();
        SqlLi_RND_PlanProvider sqlLi_RND_PlanProvider = new SqlLi_RND_PlanProvider();
        li_RND_Plans = sqlLi_RND_PlanProvider.GetAllLi_RND_Plans();
        return li_RND_Plans;
    }


    public static Li_RND_Plan GetLi_RND_PlanByID(int id)
    {
        Li_RND_Plan li_RND_Plan = new Li_RND_Plan();
        SqlLi_RND_PlanProvider sqlLi_RND_PlanProvider = new SqlLi_RND_PlanProvider();
        li_RND_Plan = sqlLi_RND_PlanProvider.GetLi_RND_PlanByID(id);
        return li_RND_Plan;
    }


    public static int InsertLi_RND_Plan(Li_RND_Plan li_RND_Plan)
    {
        SqlLi_RND_PlanProvider sqlLi_RND_PlanProvider = new SqlLi_RND_PlanProvider();
        return sqlLi_RND_PlanProvider.InsertLi_RND_Plan(li_RND_Plan);
    }


    public static bool UpdateLi_RND_Plan(Li_RND_Plan li_RND_Plan)
    {
        SqlLi_RND_PlanProvider sqlLi_RND_PlanProvider = new SqlLi_RND_PlanProvider();
        return sqlLi_RND_PlanProvider.UpdateLi_RND_Plan(li_RND_Plan);
    }

    public static bool DeleteLi_RND_Plan(int li_RND_PlanID)
    {
        SqlLi_RND_PlanProvider sqlLi_RND_PlanProvider = new SqlLi_RND_PlanProvider();
        return sqlLi_RND_PlanProvider.DeleteLi_RND_Plan(li_RND_PlanID);
    }


    public static DataSet GetPlanApproveStatus(string BookCode ,string Edition)
    {
        DataSet ds = new DataSet();
        SqlLi_RND_PlanProvider sqlLi_RND_PlanProvider = new SqlLi_RND_PlanProvider();
        ds = sqlLi_RND_PlanProvider .GetPlanApproveStatus (BookCode,Edition  );
        return ds;

    }


    public static DataSet GetPlanSections(string BookCode ,string Edition ,int IsStart)
    {
        DataSet ds = new DataSet();
        SqlLi_RND_PlanProvider sqlLi_RND_PlanProvider = new SqlLi_RND_PlanProvider();
        ds = sqlLi_RND_PlanProvider.GetPlanSections(BookCode,Edition, IsStart );
        return ds;

    }


    public static DataSet GetPlanTask(string BookCode, string Edition )
    {
        DataSet ds = new DataSet();
        SqlLi_RND_PlanProvider sqlLi_RND_PlanProvider = new SqlLi_RND_PlanProvider();
        ds = sqlLi_RND_PlanProvider.GetPlanTask(BookCode ,Edition);
        return ds;

    }


   public static DataSet UpdateRNDPlanApprove( int AppSerial , int AppBy , string BookCode )
    {
        DataSet ds = new DataSet();
        SqlLi_RND_PlanProvider sqlLi_RND_PlanProvider = new SqlLi_RND_PlanProvider();
        ds = sqlLi_RND_PlanProvider.UpdateRNDPlanApprove(   AppSerial ,   AppBy ,   BookCode );
        return ds;

    }
}
