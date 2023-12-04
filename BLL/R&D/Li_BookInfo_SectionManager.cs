using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_BookInfo_SectionManager
{
	public Li_BookInfo_SectionManager()
	{
	}

    public static List<Li_BookInfo_Section> GetAllLi_BookInfo_Sections()
    {
        List<Li_BookInfo_Section> li_BookInfo_Sections = new List<Li_BookInfo_Section>();
        SqlLi_BookInfo_SectionProvider sqlLi_BookInfo_SectionProvider = new SqlLi_BookInfo_SectionProvider();
        li_BookInfo_Sections = sqlLi_BookInfo_SectionProvider.GetAllLi_BookInfo_Sections();
        return li_BookInfo_Sections;
    }


    public static Li_BookInfo_Section GetLi_BookInfo_SectionByID(int id)
    {
        Li_BookInfo_Section li_BookInfo_Section = new Li_BookInfo_Section();
        SqlLi_BookInfo_SectionProvider sqlLi_BookInfo_SectionProvider = new SqlLi_BookInfo_SectionProvider();
        li_BookInfo_Section = sqlLi_BookInfo_SectionProvider.GetLi_BookInfo_SectionByID(id);
        return li_BookInfo_Section;
    }


    public static int InsertLi_BookInfo_Section(Li_BookInfo_Section li_BookInfo_Section)
    {
        SqlLi_BookInfo_SectionProvider sqlLi_BookInfo_SectionProvider = new SqlLi_BookInfo_SectionProvider();
        return sqlLi_BookInfo_SectionProvider.InsertLi_BookInfo_Section(li_BookInfo_Section);
    }


    public static bool UpdateLi_BookInfo_Section(Li_BookInfo_Section li_BookInfo_Section)
    {
        SqlLi_BookInfo_SectionProvider sqlLi_BookInfo_SectionProvider = new SqlLi_BookInfo_SectionProvider();
        return sqlLi_BookInfo_SectionProvider.UpdateLi_BookInfo_Section(li_BookInfo_Section);
    }

    public static bool DeleteLi_BookInfo_Section(int li_BookInfo_SectionID)
    {
        SqlLi_BookInfo_SectionProvider sqlLi_BookInfo_SectionProvider = new SqlLi_BookInfo_SectionProvider();
        return sqlLi_BookInfo_SectionProvider.DeleteLi_BookInfo_Section(li_BookInfo_SectionID);
    }
}
