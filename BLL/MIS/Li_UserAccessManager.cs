using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Common.MIS;
using DAL.MIS;

namespace BLL.MIS
{
    public class Li_UserAccessManager
    {
        public static List<Li_AdminUser> GetAllUser()
        {
            SqlLi_UserAccessProvider accessProvider = new SqlLi_UserAccessProvider();
            return accessProvider.GetAllUser();
        }

        public static int InsertUserAccess(li_UserAccess access)
        {
           SqlLi_UserAccessProvider accessProvider = new SqlLi_UserAccessProvider();
           return accessProvider.InsertUserAccess(access);
        }
    }
}
