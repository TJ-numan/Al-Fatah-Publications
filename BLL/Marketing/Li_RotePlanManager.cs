using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BLL
{
    public class Li_RotePlanManager
    {
        public Li_RotePlanManager()
        {
        }

        public static List<Li_RotePlan> GetAllLi_RotePlans()
        {
            List<Li_RotePlan> li_RotePlans = new List<Li_RotePlan>();
            SqlLi_RotePlanProvider sqlLi_RotePlanProvider = new SqlLi_RotePlanProvider();
            li_RotePlans = sqlLi_RotePlanProvider.GetAllLi_RotePlans();
            return li_RotePlans;
        }


        public static Li_RotePlan GetLi_RotePlanByID(int id)
        {
            Li_RotePlan li_RotePlan = new Li_RotePlan();
            SqlLi_RotePlanProvider sqlLi_RotePlanProvider = new SqlLi_RotePlanProvider();
            li_RotePlan = sqlLi_RotePlanProvider.GetLi_RotePlanByID(id);
            return li_RotePlan;
        }


        public static int InsertLi_RotePlan(Li_RotePlan li_RotePlan)
        {
            SqlLi_RotePlanProvider sqlLi_RotePlanProvider = new SqlLi_RotePlanProvider();
            return sqlLi_RotePlanProvider.InsertLi_RotePlan(li_RotePlan);
        }


        public static bool UpdateLi_RotePlan(Li_RotePlan li_RotePlan)
        {
            SqlLi_RotePlanProvider sqlLi_RotePlanProvider = new SqlLi_RotePlanProvider();
            return sqlLi_RotePlanProvider.UpdateLi_RotePlan(li_RotePlan);
        }

        public static bool DeleteLi_RotePlan(int li_RotePlanID)
        {
            SqlLi_RotePlanProvider sqlLi_RotePlanProvider = new SqlLi_RotePlanProvider();
            return sqlLi_RotePlanProvider.DeleteLi_RotePlan(li_RotePlanID);
        }

        public static DataSet getRouteMappings(int ComID, int DemID, string LocationId)
        {
            DataSet ds = new DataSet();
            SqlLi_RotePlanProvider sqlLi_RotePlanProvider = new SqlLi_RotePlanProvider();
            ds = sqlLi_RotePlanProvider.getRouteMappings(ComID, DemID, LocationId);
            return ds;
        }
    }

}
