using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DAL;

namespace BLL
{
    public class Li_CompanyManager
    {
        public Li_CompanyManager()
        {
        }

        public static List<Li_Company> GetAllLi_Companies()
        {
            List<Li_Company> li_Companies = new List<Li_Company>();
            SqlLi_CompanyProvider sqlLi_CompanyProvider = new SqlLi_CompanyProvider();
            li_Companies = sqlLi_CompanyProvider.GetAllLi_Companies();
            return li_Companies;
        }


        public static Li_Company GetLi_CompanyByID(int id)
        {
            Li_Company li_Company = new Li_Company();
            SqlLi_CompanyProvider sqlLi_CompanyProvider = new SqlLi_CompanyProvider();
            li_Company = sqlLi_CompanyProvider.GetLi_CompanyByID(id);
            return li_Company;
        }


        public static int InsertLi_Company(Li_Company li_Company)
        {
            SqlLi_CompanyProvider sqlLi_CompanyProvider = new SqlLi_CompanyProvider();
            return sqlLi_CompanyProvider.InsertLi_Company(li_Company);
        }


        public static bool UpdateLi_Company(Li_Company li_Company)
        {
            SqlLi_CompanyProvider sqlLi_CompanyProvider = new SqlLi_CompanyProvider();
            return sqlLi_CompanyProvider.UpdateLi_Company(li_Company);
        }

        public static bool DeleteLi_Company(int li_CompanyID)
        {
            SqlLi_CompanyProvider sqlLi_CompanyProvider = new SqlLi_CompanyProvider();
            return sqlLi_CompanyProvider.DeleteLi_Company(li_CompanyID);
        }
    }

}
