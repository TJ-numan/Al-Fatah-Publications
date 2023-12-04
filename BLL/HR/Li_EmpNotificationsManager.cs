using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;








public class Li_EmpNotificationsManager
{
	public Li_EmpNotificationsManager()
	{
	}

    public static List<Li_EmpNotifications> GetAllLi_EmpNotificationss()
    {
        List<Li_EmpNotifications> li_EmpNotificationss = new List<Li_EmpNotifications>();
        SqlLi_EmpNotificationsProvider sqlLi_EmpNotificationsProvider = new SqlLi_EmpNotificationsProvider();
        li_EmpNotificationss = sqlLi_EmpNotificationsProvider.GetAllLi_EmpNotificationss();
        return li_EmpNotificationss;
    }


    public static Li_EmpNotifications GetLi_EmpNotificationsByID(int id)
    {
        Li_EmpNotifications li_EmpNotifications = new Li_EmpNotifications();
        SqlLi_EmpNotificationsProvider sqlLi_EmpNotificationsProvider = new SqlLi_EmpNotificationsProvider();
        li_EmpNotifications = sqlLi_EmpNotificationsProvider.GetLi_EmpNotificationsByID(id);
        return li_EmpNotifications;
    }


    public static int InsertLi_EmpNotifications(Li_EmpNotifications li_EmpNotifications)
    {
        SqlLi_EmpNotificationsProvider sqlLi_EmpNotificationsProvider = new SqlLi_EmpNotificationsProvider();
        return sqlLi_EmpNotificationsProvider.InsertLi_EmpNotifications(li_EmpNotifications);
    }


    public static bool UpdateLi_EmpNotifications(Li_EmpNotifications li_EmpNotifications)
    {
        SqlLi_EmpNotificationsProvider sqlLi_EmpNotificationsProvider = new SqlLi_EmpNotificationsProvider();
        return sqlLi_EmpNotificationsProvider.UpdateLi_EmpNotifications(li_EmpNotifications);
    }

    public static bool DeleteLi_EmpNotifications(int li_EmpNotificationsID)
    {
        SqlLi_EmpNotificationsProvider sqlLi_EmpNotificationsProvider = new SqlLi_EmpNotificationsProvider();
        return sqlLi_EmpNotificationsProvider.DeleteLi_EmpNotifications(li_EmpNotificationsID);
    }
}
