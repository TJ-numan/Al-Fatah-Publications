using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BLL
{
    public class Li_RoutePlanDetailsManager
    {
        public Li_RoutePlanDetailsManager()
        {
        }

        public static List<Li_RoutePlanDetails> GetAllLi_RoutePlanDetailss()
        {
            List<Li_RoutePlanDetails> li_RoutePlanDetailss = new List<Li_RoutePlanDetails>();
            SqlLi_RoutePlanDetailsProvider sqlLi_RoutePlanDetailsProvider = new SqlLi_RoutePlanDetailsProvider();
            li_RoutePlanDetailss = sqlLi_RoutePlanDetailsProvider.GetAllLi_RoutePlanDetailss();
            return li_RoutePlanDetailss;
        }


        public static Li_RoutePlanDetails GetLi_RoutePlanDetailsByID(int id)
        {
            Li_RoutePlanDetails li_RoutePlanDetails = new Li_RoutePlanDetails();
            SqlLi_RoutePlanDetailsProvider sqlLi_RoutePlanDetailsProvider = new SqlLi_RoutePlanDetailsProvider();
            li_RoutePlanDetails = sqlLi_RoutePlanDetailsProvider.GetLi_RoutePlanDetailsByID(id);
            return li_RoutePlanDetails;
        }


        public static int InsertLi_RoutePlanDetails(Li_RoutePlanDetails li_RoutePlanDetails)
        {
            SqlLi_RoutePlanDetailsProvider sqlLi_RoutePlanDetailsProvider = new SqlLi_RoutePlanDetailsProvider();
            return sqlLi_RoutePlanDetailsProvider.InsertLi_RoutePlanDetails(li_RoutePlanDetails);
        }


        public static bool UpdateLi_RoutePlanDetails(Li_RoutePlanDetails li_RoutePlanDetails)
        {
            SqlLi_RoutePlanDetailsProvider sqlLi_RoutePlanDetailsProvider = new SqlLi_RoutePlanDetailsProvider();
            return sqlLi_RoutePlanDetailsProvider.UpdateLi_RoutePlanDetails(li_RoutePlanDetails);
        }

        public static bool DeleteLi_RoutePlanDetails(int li_RoutePlanDetailsID)
        {
            SqlLi_RoutePlanDetailsProvider sqlLi_RoutePlanDetailsProvider = new SqlLi_RoutePlanDetailsProvider();
            return sqlLi_RoutePlanDetailsProvider.DeleteLi_RoutePlanDetails(li_RoutePlanDetailsID);
        }
    }

}
