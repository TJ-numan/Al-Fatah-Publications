using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_RNDPlan_SectionManager
{
	public Li_RNDPlan_SectionManager()
	{
	}

    public static List<Li_RNDPlan_Section> GetAllLi_RNDPlan_Sections()
    {
        List<Li_RNDPlan_Section> li_RNDPlan_Sections = new List<Li_RNDPlan_Section>();
        SqlLi_RNDPlan_SectionProvider sqlLi_RNDPlan_SectionProvider = new SqlLi_RNDPlan_SectionProvider();
        li_RNDPlan_Sections = sqlLi_RNDPlan_SectionProvider.GetAllLi_RNDPlan_Sections();
        return li_RNDPlan_Sections;
    }


    public static Li_RNDPlan_Section GetLi_RNDPlan_SectionByID(int id)
    {
        Li_RNDPlan_Section li_RNDPlan_Section = new Li_RNDPlan_Section();
        SqlLi_RNDPlan_SectionProvider sqlLi_RNDPlan_SectionProvider = new SqlLi_RNDPlan_SectionProvider();
        li_RNDPlan_Section = sqlLi_RNDPlan_SectionProvider.GetLi_RNDPlan_SectionByID(id);
        return li_RNDPlan_Section;
    }


    public static int InsertLi_RNDPlan_Section(Li_RNDPlan_Section li_RNDPlan_Section)
    {
        SqlLi_RNDPlan_SectionProvider sqlLi_RNDPlan_SectionProvider = new SqlLi_RNDPlan_SectionProvider();
        return sqlLi_RNDPlan_SectionProvider.InsertLi_RNDPlan_Section(li_RNDPlan_Section);
    }


    public static bool UpdateLi_RNDPlan_Section(Li_RNDPlan_Section li_RNDPlan_Section)
    {
        SqlLi_RNDPlan_SectionProvider sqlLi_RNDPlan_SectionProvider = new SqlLi_RNDPlan_SectionProvider();
        return sqlLi_RNDPlan_SectionProvider.UpdateLi_RNDPlan_Section(li_RNDPlan_Section);
    }

    public static bool DeleteLi_RNDPlan_Section(int li_RNDPlan_SectionID)
    {
        SqlLi_RNDPlan_SectionProvider sqlLi_RNDPlan_SectionProvider = new SqlLi_RNDPlan_SectionProvider();
        return sqlLi_RNDPlan_SectionProvider.DeleteLi_RNDPlan_Section(li_RNDPlan_SectionID);
    }
}
