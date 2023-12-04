using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;


using Common; 


public class Li_AdminUserManager
{
	public Li_AdminUserManager()
	{
	}

    public static List<Li_AdminUser> GetAllLi_AdminUsers()
    {
        List<Li_AdminUser> li_AdminUsers = new List<Li_AdminUser>();
        SqlLi_AdminUserProvider sqlLi_AdminUserProvider = new SqlLi_AdminUserProvider();
        li_AdminUsers = sqlLi_AdminUserProvider.GetAllLi_AdminUsers();
        return li_AdminUsers;
    }


    public static Li_AdminUser GetLi_AdminUserByID(int id)
    {
        Li_AdminUser li_AdminUser = new Li_AdminUser();
        SqlLi_AdminUserProvider sqlLi_AdminUserProvider = new SqlLi_AdminUserProvider();
        li_AdminUser = sqlLi_AdminUserProvider.GetLi_AdminUserByID(id);
        return li_AdminUser;
    }


    public static int InsertLi_AdminUser(Li_AdminUser li_AdminUser)
    {
        SqlLi_AdminUserProvider sqlLi_AdminUserProvider = new SqlLi_AdminUserProvider();
        return sqlLi_AdminUserProvider.InsertLi_AdminUser(li_AdminUser);
    }


    public static bool UpdateLi_AdminUser(Li_AdminUser li_AdminUser)
    {
        SqlLi_AdminUserProvider sqlLi_AdminUserProvider = new SqlLi_AdminUserProvider();
        return sqlLi_AdminUserProvider.UpdateLi_AdminUser(li_AdminUser);
    }

    public static bool DeleteLi_AdminUser(int li_AdminUserID)
    {
        SqlLi_AdminUserProvider sqlLi_AdminUserProvider = new SqlLi_AdminUserProvider();
        return sqlLi_AdminUserProvider.DeleteLi_AdminUser(li_AdminUserID);
    }

    public static  DataSet GetUserInfo(string userName, string password)
    {
        DataSet ds = new DataSet();
        SqlLi_AdminUserProvider sqlUsers = new SqlLi_AdminUserProvider();
        ds = sqlUsers.GetUserInfo(userName, password);
        return ds;
    }

    public static DataSet GetUserAccess(int UserID, string FormId)
    {
        DataSet ds = new DataSet();
        SqlLi_AdminUserProvider sqlUsers = new SqlLi_AdminUserProvider();
        ds = sqlUsers.GetUserAccess(UserID, FormId);
        return ds;
    }

    public static int InsertLi_UserAccessLog(li_UserAccessLog li_UserAccessLog)
    {
        SqlLi_AdminUserProvider sqlLi_AdminUserProvider = new SqlLi_AdminUserProvider();
        return sqlLi_AdminUserProvider.InsertLi_UserAccessLog(li_UserAccessLog);
    }


    public static bool UpdateLi_UserAccessLog(li_UserAccessLog li_UserAccessLog)
    {
        SqlLi_AdminUserProvider sqlLi_AdminUserProvider = new SqlLi_AdminUserProvider();
        return sqlLi_AdminUserProvider.UpdateLi_UserAccessLog(li_UserAccessLog);
    }

    public static string UpdateLi_ChangePassword(int User_ID, string Name, string OldPassword, string NewPassword)
    {
        SqlLi_AdminUserProvider sqlLi_AdminUserProvider = new SqlLi_AdminUserProvider();
        return sqlLi_AdminUserProvider.UpdateLi_ChangePassword(User_ID, Name,OldPassword,NewPassword);
    }
}
