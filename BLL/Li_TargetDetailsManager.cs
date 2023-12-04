using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Xml.Linq;
public class Li_TargetDetailsManager
{
    public Li_TargetDetailsManager()
    {
    }

    public static List<Li_TargetDetails> GetAllLi_TargetDetails()
    {
        List<Li_TargetDetails> li_TargetDetails = new List<Li_TargetDetails>();
        SqlLi_TargetDetailsProvider sqlLi_TargetDetailsProvider = new SqlLi_TargetDetailsProvider();
        li_TargetDetails = sqlLi_TargetDetailsProvider.GetAllLi_TargetDetails();
        return li_TargetDetails;
    }


    public static Li_TargetDetails GetLi_TargetDetailByID(int id)
    {
        Li_TargetDetails li_TargetDetails = new Li_TargetDetails();
        SqlLi_TargetDetailsProvider sqlLi_TargetDetailsProvider = new SqlLi_TargetDetailsProvider();
        li_TargetDetails = sqlLi_TargetDetailsProvider.GetLi_TargetDetailByID(id);
        return li_TargetDetails;
    }


    public static int InsertLi_TargetDetail(Li_TargetDetails li_TargetDetails)
    {
        SqlLi_TargetDetailsProvider sqlLi_TargetDetailsProvider = new SqlLi_TargetDetailsProvider();
        return sqlLi_TargetDetailsProvider.InsertLi_TargetDetail(li_TargetDetails);
    }


    public static bool UpdateLi_TargetDetail(Li_TargetDetails li_TargetDetails)
    {
        SqlLi_TargetDetailsProvider sqlLi_TargetDetailsProvider = new SqlLi_TargetDetailsProvider();
        return sqlLi_TargetDetailsProvider.UpdateLi_TargetDetail(li_TargetDetails);
    }

    public static bool DeleteLi_TargetDetail(int li_TargetDetails)
    {
        SqlLi_TargetDetailsProvider sqlLi_TargetDetailsProvider = new SqlLi_TargetDetailsProvider();
        return sqlLi_TargetDetailsProvider.DeleteLi_TargetDetail(li_TargetDetails);
    }

    public static int InsertLi_SOTargetDetail(Li_TargetDetails li_TargetDetails)
    {
        SqlLi_TargetDetailsProvider sqlLi_TargetDetailsProvider = new SqlLi_TargetDetailsProvider();
        return sqlLi_TargetDetailsProvider.InsertLi_SOTargetDetail(li_TargetDetails);
    }


    public static bool IsDataExists(int year, int monthNo, string terCode)
    {
        throw new NotImplementedException();
    }
}
