using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 

public class Li_SectionManager
{
	public Li_SectionManager()
	{
	}

    public static List<Li_Section> GetAllLi_Sections()
    {
        List<Li_Section> li_Sections = new List<Li_Section>();
        SqlLi_SectionProvider sqlLi_SectionProvider = new SqlLi_SectionProvider();
        li_Sections = sqlLi_SectionProvider.GetAllLi_Sections();
        return li_Sections;
    }


    public static Li_Section GetLi_SectionByID(int id)
    {
        Li_Section li_Section = new Li_Section();
        SqlLi_SectionProvider sqlLi_SectionProvider = new SqlLi_SectionProvider();
        li_Section = sqlLi_SectionProvider.GetLi_SectionByID(id);
        return li_Section;
    }


    public static int InsertLi_Section(Li_Section li_Section)
    {
        SqlLi_SectionProvider sqlLi_SectionProvider = new SqlLi_SectionProvider();
        return sqlLi_SectionProvider.InsertLi_Section(li_Section);
    }


    public static bool UpdateLi_Section(Li_Section li_Section)
    {
        SqlLi_SectionProvider sqlLi_SectionProvider = new SqlLi_SectionProvider();
        return sqlLi_SectionProvider.UpdateLi_Section(li_Section);
    }

    public static bool DeleteLi_Section(int li_SectionID)
    {
        SqlLi_SectionProvider sqlLi_SectionProvider = new SqlLi_SectionProvider();
        return sqlLi_SectionProvider.DeleteLi_Section(li_SectionID);
    }

    public static DataTable LoadAllSection()
    {
        SqlLi_SectionProvider sqlLi_AllSection = new SqlLi_SectionProvider();
        return sqlLi_AllSection.LoadAllSection();
    }
    public static DataTable LoadHireSection()
    {
        SqlLi_SectionProvider sqlLi_HireSection = new SqlLi_SectionProvider();
        return sqlLi_HireSection.LoadHireSection();
    }
    public static DataTable LoadSectionByUser(int UserID)
    {
        SqlLi_SectionProvider sqlLi_AllSection = new SqlLi_SectionProvider();
        return sqlLi_AllSection.LoadSectionByUser(UserID);
    }
    //-----------------------Rezaul Hossain ------------------2021-06-02-------------------
    public static DataTable LoadAllSectionQawmi()
    {
        SqlLi_SectionProvider sqlLi_AllSection = new SqlLi_SectionProvider();
        return sqlLi_AllSection.LoadAllSectionQawmi();
    }
    public static DataTable LoadHireSectionQawmi()
    {
        SqlLi_SectionProvider sqlLi_HireSection = new SqlLi_SectionProvider();
        return sqlLi_HireSection.LoadHireSectionQawmi();
    }
}
