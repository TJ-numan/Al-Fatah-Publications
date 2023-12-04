using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BLL
{
    public class Li_PointsManager
    {
        public Li_PointsManager()
        {
        }

        public static List<Li_Points> GetAllLi_Pointss()
        {
            List<Li_Points> li_Pointss = new List<Li_Points>();
            SqlLi_PointsProvider sqlLi_PointsProvider = new SqlLi_PointsProvider();
            li_Pointss = sqlLi_PointsProvider.GetAllLi_Pointss();
            return li_Pointss;
        }


        public static Li_Points GetLi_PointsByID(int id)
        {
            Li_Points li_Points = new Li_Points();
            SqlLi_PointsProvider sqlLi_PointsProvider = new SqlLi_PointsProvider();
            li_Points = sqlLi_PointsProvider.GetLi_PointsByID(id);
            return li_Points;
        }


        public static int InsertLi_Points(Li_Points li_Points)
        {
            SqlLi_PointsProvider sqlLi_PointsProvider = new SqlLi_PointsProvider();
            return sqlLi_PointsProvider.InsertLi_Points(li_Points);
        }


        public static bool UpdateLi_Points(Li_Points li_Points)
        {
            SqlLi_PointsProvider sqlLi_PointsProvider = new SqlLi_PointsProvider();
            return sqlLi_PointsProvider.UpdateLi_Points(li_Points);
        }

        public static bool DeleteLi_Points(int li_PointsID)
        {
            SqlLi_PointsProvider sqlLi_PointsProvider = new SqlLi_PointsProvider();
            return sqlLi_PointsProvider.DeleteLi_Points(li_PointsID);
        }
    }

}
