using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq; 


public class Li_Script_ChapterManager
{
	public Li_Script_ChapterManager()
	{
	}

    public static List<Li_Script_Chapter> GetAllLi_Script_Chapters()
    {
        List<Li_Script_Chapter> li_Script_Chapters = new List<Li_Script_Chapter>();
        SqlLi_Script_ChapterProvider sqlLi_Script_ChapterProvider = new SqlLi_Script_ChapterProvider();
        li_Script_Chapters = sqlLi_Script_ChapterProvider.GetAllLi_Script_Chapters();
        return li_Script_Chapters;
    }


    public static Li_Script_Chapter GetLi_Script_ChapterByID(int id)
    {
        Li_Script_Chapter li_Script_Chapter = new Li_Script_Chapter();
        SqlLi_Script_ChapterProvider sqlLi_Script_ChapterProvider = new SqlLi_Script_ChapterProvider();
        li_Script_Chapter = sqlLi_Script_ChapterProvider.GetLi_Script_ChapterByID(id);
        return li_Script_Chapter;
    }


    public static int InsertLi_Script_Chapter(Li_Script_Chapter li_Script_Chapter)
    {
        SqlLi_Script_ChapterProvider sqlLi_Script_ChapterProvider = new SqlLi_Script_ChapterProvider();
        return sqlLi_Script_ChapterProvider.InsertLi_Script_Chapter(li_Script_Chapter);
    }


    public static bool UpdateLi_Script_Chapter(Li_Script_Chapter li_Script_Chapter)
    {
        SqlLi_Script_ChapterProvider sqlLi_Script_ChapterProvider = new SqlLi_Script_ChapterProvider();
        return sqlLi_Script_ChapterProvider.UpdateLi_Script_Chapter(li_Script_Chapter);
    }

    public static bool DeleteLi_Script_Chapter(int li_Script_ChapterID)
    {
        SqlLi_Script_ChapterProvider sqlLi_Script_ChapterProvider = new SqlLi_Script_ChapterProvider();
        return sqlLi_Script_ChapterProvider.DeleteLi_Script_Chapter(li_Script_ChapterID);
    }
}
