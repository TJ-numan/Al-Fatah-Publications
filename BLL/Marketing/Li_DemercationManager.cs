using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BLL
{
    public class Li_DemercationManager
    {
        public Li_DemercationManager()
        {
        }

        public static List<Li_Demercation> GetAllLi_Demercations()
        {
            List<Li_Demercation> li_Demercations = new List<Li_Demercation>();
            SqlLi_DemercationProvider sqlLi_DemercationProvider = new SqlLi_DemercationProvider();
            li_Demercations = sqlLi_DemercationProvider.GetAllLi_Demercations();
            return li_Demercations;
        }


        public static Li_Demercation GetLi_DemercationByID(int id)
        {
            Li_Demercation li_Demercation = new Li_Demercation();
            SqlLi_DemercationProvider sqlLi_DemercationProvider = new SqlLi_DemercationProvider();
            li_Demercation = sqlLi_DemercationProvider.GetLi_DemercationByID(id);
            return li_Demercation;
        }


        public static int InsertLi_Demercation(Li_Demercation li_Demercation)
        {
            SqlLi_DemercationProvider sqlLi_DemercationProvider = new SqlLi_DemercationProvider();
            return sqlLi_DemercationProvider.InsertLi_Demercation(li_Demercation);
        }


        public static bool UpdateLi_Demercation(Li_Demercation li_Demercation)
        {
            SqlLi_DemercationProvider sqlLi_DemercationProvider = new SqlLi_DemercationProvider();
            return sqlLi_DemercationProvider.UpdateLi_Demercation(li_Demercation);
        }

        public static bool DeleteLi_Demercation(int li_DemercationID)
        {
            SqlLi_DemercationProvider sqlLi_DemercationProvider = new SqlLi_DemercationProvider();
            return sqlLi_DemercationProvider.DeleteLi_Demercation(li_DemercationID);
        }
    }

}
